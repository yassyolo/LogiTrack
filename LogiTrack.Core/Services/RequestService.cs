using LogisticsSystem.Infrastructure.Data.DataModels;
using LogiTrack.Core.Constants;
using LogiTrack.Core.Contracts;
using LogiTrack.Core.ViewModels.Delivery;
using LogiTrack.Core.ViewModels.Request;
using LogiTrack.Infrastructure.Data.DataModels;
using LogiTrack.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ocsp;
using Org.BouncyCastle.Asn1.X509.Qualified;
using Org.BouncyCastle.Pqc.Crypto.Utilities;
using System.Collections.Generic;
using System.Linq.Expressions;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;
using static LogiTrack.Infrastructure.Data.DataConstants.DataModelConstants;
using Vehicle = LogisticsSystem.Infrastructure.Data.DataModels.Vehicle;

namespace LogiTrack.Core.Services
{
    public class RequestService : IRequestService
    {
        private readonly IRepository repository;
        private readonly GeocodingService geocodingService;

        public RequestService(IRepository repository, GeocodingService geocodingService)
        {
            this.repository = repository;
            this.geocodingService = geocodingService;
        }

        public async Task MakeRequestAsync(MakeRequestViewModel model, string username)
        {
            var client = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.ClientCompany>().FirstOrDefaultAsync(x => x.User.UserName == username);

            var pickupAddress = new Infrastructure.Data.DataModels.Address
            {
                City = model.PickupCity,
                County = model.PickupCountry,
                Street = model.PickupStreet,
                Latitude = model.PickupLatitude,
                Longitude = model.PickupLongitude
            };

            var deliveryAddress = new Infrastructure.Data.DataModels.Address
            {
                City = model.DeliveryCity,
                County = model.DeliveryCountry,
                Street = model.DeliveryStreet,
                Latitude = model.DeliveryLatitude,
                Longitude = model.DeliveryLongitude
            };
            await repository.AddAsync(pickupAddress);
            await repository.AddAsync(deliveryAddress);
            await repository.SaveChangesAsync();

            var request = new LogisticsSystem.Infrastructure.Data.DataModels.Request
            {
                ClientCompanyId = client.Id,
                CargoType = model.CargoType,
                NumberOfNonStandartGoods = model.NumberOfNonStandartGoods,
                TypeOfGoods = model.TypeOfGoods,
                Type = model.Type,
                SharedTruck = model.SharedTruck,
                ApproximatePrice = model.ApproximatePrice,
                ExpectedDeliveryDate = model.ExpectedDeliveryDate,
                SpecialInstructions = model.SpecialInstructions,
                IsRefrigerated = model.IsRefrigerated,
                Status = StatusConstants.Pending,
                CreatedAt = DateTime.Now,
                PickupAddressId = pickupAddress.Id,
                DeliveryAddressId = deliveryAddress.Id,
                Kilometers = CalculateDistance(model.PickupLatitude, model.PickupLongitude, model.DeliveryLatitude, model.DeliveryLongitude),
            };
            await repository.AddAsync(request);
            await repository.SaveChangesAsync();

            if (model.PalletLength != null)
            {
                var standartCargo = new StandartCargo
                {
                    TypeOfPallet = model.TypeOfPallet,
                    NumberOfPallets = model.NumberOfPallets,
                    PalletLength = model.PalletLength,
                    PalletHeight = model.PalletHeight,
                    PalletWidth = model.PalletWidth,
                    WeightOfPallets = model.WeightOfPallets,
                    PalletsAreStackable = model.PalletsAreStackable,
                    PalletVolume = model.PalletLength * model.PalletWidth * model.PalletHeight / 1000000.0
                };
                await repository.AddAsync(standartCargo);
                await repository.SaveChangesAsync();
                request.StandartCargoId = standartCargo.Id;
                request.TotalVolume = (standartCargo.PalletVolume ?? 0) * (standartCargo.NumberOfPallets ?? 0);
                request.TotalWeight = (standartCargo.WeightOfPallets ?? 0) * (standartCargo.NumberOfPallets ?? 0);
            }
            request.RerefenceNumber = $"REQ-{request.Id}";

            var sharedTruck = request.SharedTruck == true ? "SharedTruck" : "NotSharedTruck";
            var quotient = $"{request.Type}For{sharedTruck}";

            var parameter = Expression.Parameter(typeof(PricesPerSize), "x");
            var property = Expression.Property(parameter, quotient);
            var lambda = Expression.Lambda<Func<PricesPerSize, double>>(property, parameter);

            var averageQuotient = await repository.AllReadonly<PricesPerSize>().Select(lambda).AverageAsync();
            var averageConstantExpenses = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Vehicle>().AverageAsync(x => x.ContantsExpenses);
            var fuelPrice = await repository.AllReadonly<Infrastructure.Data.DataModels.FuelPrice>().Where(x => x.Date == DateTime.Now || x.Date == DateTime.Now.AddDays(-1)).FirstOrDefaultAsync();
            var averageVehicleConsumption = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Vehicle>().AverageAsync(x => x.FuelConsumptionPer100Km);
            var fuelConsumption = (request.Kilometers / 100) * averageVehicleConsumption;
            var fuelCost = (decimal)fuelConsumption * fuelPrice.Price;
            var calculatedPrice = (decimal)(averageQuotient * request.Kilometers) + (averageConstantExpenses + fuelCost);
            request.CalculatedPrice = calculatedPrice + calculatedPrice * (decimal)0.20;
            await repository.SaveChangesAsync();

            if (model.Length != null && model.Length.Length > 0)
            {
                for (int i = 0; i < model.Length.Length; i++)
                {
                    var nonStandardCargo = new NonStandardCargo
                    {
                        RequestId = request.Id,
                        Description = model.Description[i],
                        Length = model.Length[i],
                        Width = model.Width[i],
                        Height = model.Height[i],
                        Weight = model.Weight[i]
                    };
                    nonStandardCargo.Volume = nonStandardCargo.Length * nonStandardCargo.Width * nonStandardCargo.Height / 1000000.0;
                    request.TotalVolume += nonStandardCargo.Volume;
                    request.TotalWeight += nonStandardCargo.Weight;

                    await repository.AddAsync(nonStandardCargo);
                }
            }
            var notification = new Notification
            {
                Title = "New Request",
                Message = $"New request with reference number {request.RerefenceNumber} has been made!",
                Date = DateTime.Now,
                UserId = client.User.Id
            };
            await repository.AddAsync(notification);

            await repository.SaveChangesAsync();
        }

        public double CalculateDistance(double pickupLatitude, double pickupLongitude, double deliveryLatitude, double deliveryLongitude)
        {
            const double R = 6371.0;
            double lat1 = pickupLatitude * (Math.PI / 180.0);
            double lon1 = pickupLongitude * (Math.PI / 180.0);
            double lat2 = deliveryLatitude * (Math.PI / 180.0);
            double lon2 = deliveryLongitude * (Math.PI / 180.0);

            double dLat = lat2 - lat1;
            double dLon = lon2 - lon1;

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Cos(lat1) * Math.Cos(lat2) * Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            double distance = R * c;

            return distance;
        }

        public async Task<IEnumerable<RequestsForSearchViewModel>> GetRequestsForCompanyAsync(string companyUsername, DateTime? startDate = null, DateTime? endDate = null, string? pickupAddress = null, string? deliveryAddress = null, bool? isApproved = null, decimal? minPrice = null, decimal? maxPrice = null, double? minWeight = null, double? maxWeight = null)
        {
            var requests = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Request>().Include(x => x.PickupAddress).Include(x => x.DeliveryAddress).Where(x => x.ClientCompany.User.UserName == companyUsername).ToListAsync();
            if (startDate != null)
            {
                requests = requests.Where(x => x.CreatedAt >= startDate).ToList();
            }
            if (minPrice != null)
            {
                requests = requests.Where(x => x.ApproximatePrice >= minPrice).ToList();
            }
            if (maxPrice != null)
            {
                requests = requests.Where(x => x.ApproximatePrice <= maxPrice).ToList();
            }
            if (minWeight != null)
            {
                requests = requests.Where(x => x.TotalWeight >= minWeight).ToList();
            }
            if (maxWeight != null)
            {
                requests = requests.Where(x => x.TotalWeight <= maxWeight).ToList();
            }
            if (endDate != null)
            {
                requests = requests.Where(x => x.CreatedAt <= endDate).ToList();
            }
            if (string.IsNullOrEmpty(deliveryAddress) == false)
            {
                requests = requests.Where(x => x.DeliveryAddress.City.ToLower().Contains(deliveryAddress.ToLower()) || x.DeliveryAddress.County.ToLower().Contains(deliveryAddress.ToLower()) || x.DeliveryAddress.Street.ToLower().Contains(deliveryAddress.ToLower())).ToList();
            }
            if (string.IsNullOrEmpty(pickupAddress) == false)
            {
                requests = requests.Where(x => x.PickupAddress.City.ToLower().Contains(pickupAddress.ToLower()) || x.PickupAddress.County.ToLower().Contains(pickupAddress.ToLower()) || x.PickupAddress.Street.ToLower().Contains(pickupAddress.ToLower())).ToList();
            }
            return requests.Select(x => new RequestsForSearchViewModel
            {
                Id = x.Id,
                ReferenceNumber = x.RerefenceNumber,
                PickupAddress = $"{x.PickupAddress.Street}, {x.PickupAddress.City}, {x.PickupAddress.County}",
                DeliveryAddress = $"{x.DeliveryAddress.Street}, {x.DeliveryAddress.City}, {x.DeliveryAddress.County}",
                ExpectedDeliveryDate = x.ExpectedDeliveryDate.ToString("dd-MM-yyyy"),
                CreationDate = x.CreatedAt.ToString("dd-MM-yyyy"),
                Approved = x.Status == StatusConstants.Approved,
                NumberOfItems = (x.StandartCargo?.NumberOfPallets ?? 0) + (x.NumberOfNonStandartGoods ?? 0).ToString(),
                TotalWeight = x.TotalWeight.ToString("F2"),
                TotalVolume = x.TotalVolume.ToString("F2"),
            });
        }

        public async Task<RequestViewModel?> GetRequestDetailsAsync(int id)
        {
            var model = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Request>()
                .Where(x => x.Id == id)
                .Include(x => x.StandartCargo)
                .Include(x => x.NonStandardCargos)
                .Include(x => x.PickupAddress)
                .Include(x => x.DeliveryAddress)
                .Include(x => x.Offer)
                .Select(x => new RequestViewModel
                {
                    Id = x.Id,
                    CargoType = x.CargoType,
                    ReferenceNumber = x.RerefenceNumber,
                    NumberOfNonStandartGoods = x.NumberOfNonStandartGoods.ToString(),
                    TypeOfGoods = x.TypeOfGoods,
                    PickupAddress = $"{x.PickupAddress.Street}, {x.PickupAddress.City}, {x.PickupAddress.County}",
                    DeliveryAddress = $"{x.DeliveryAddress.Street}, {x.DeliveryAddress.City}, {x.DeliveryAddress.County}",
                    SharedTruck = x.SharedTruck,
                    ApproximatePrice = x.ApproximatePrice.ToString(),
                    ExpectedDeliveryDate = x.ExpectedDeliveryDate.ToString("dd-MM-yyyy"),
                    Status = x.Status,
                    SpecialInstructions = x.SpecialInstructions,
                    IsRefrigerated = x.IsRefrigerated,
                    CreatedAt = x.CreatedAt.ToString("dd-MM-yyyy"),
                    Kilometers = x.Kilometers.ToString(),
                    TotalWeight = x.TotalWeight.ToString(),
                    TotalVolume = x.TotalVolume.ToString(),
                    PalletsCount = x.StandartCargo != null ? x.StandartCargo.NumberOfPallets.ToString() : string.Empty,
                    PalletsLength = x.StandartCargo != null ? x.StandartCargo.PalletLength.ToString() : string.Empty,
                    PalletsHeight = x.StandartCargo != null ? x.StandartCargo.PalletHeight.ToString() : string.Empty,
                    PalletsWidth = x.StandartCargo != null ? x.StandartCargo.PalletWidth.ToString() : string.Empty,
                    NonStandardCargo = x.NonStandardCargos.Select(c => new NonStandardCargoRequestViewModel
                    {
                        Length = c.Length.ToString(),
                        Width = c.Width.ToString(),
                        Height = c.Height.ToString(),
                        Weight = c.Weight
                    }).ToList(),
                })
                .FirstOrDefaultAsync();
            if (model != null)
            {
                var offer = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Offer>().Where(x => x.RequestId == model.Id).Select(x => new { x.Id }).FirstOrDefaultAsync();

                if (offer != null)
                {
                    model.OfferId = offer.Id;
                }
            }

            return model;
        }

        public async Task<IEnumerable<RequestsForSearchViewModel>> GetRequestsForCompanyBySearchTermAsync(string companyUsername, string? searchTerm)
        {
            var requests = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Request>()
                .Include(x => x.PickupAddress).Include(x => x.DeliveryAddress).Where(x => x.ClientCompany.User.UserName == companyUsername).ToListAsync();

            if (string.IsNullOrEmpty(searchTerm) == false)
            {
                requests = requests.Where(x =>
        x.DeliveryAddress.City.ToLower().Contains(searchTerm.ToLower()) ||
        x.DeliveryAddress.County.ToLower().Contains(searchTerm.ToLower()) ||
        x.DeliveryAddress.Street.ToLower().Contains(searchTerm.ToLower()) ||
        x.PickupAddress.City.ToLower().Contains(searchTerm.ToLower()) ||
        x.PickupAddress.County.ToLower().Contains(searchTerm.ToLower()) ||
        x.PickupAddress.Street.ToLower().Contains(searchTerm.ToLower()) ||
        x.CargoType.ToLower().Contains(searchTerm.ToLower()) ||
        x.RerefenceNumber.ToLower().Contains(searchTerm.ToLower()) ||
        x.SpecialInstructions.ToLower().Contains(searchTerm.ToLower()) ||
        x.Status.ToLower().Contains(searchTerm.ToLower()) ||
        (double.TryParse(searchTerm, out double weight) &&
            (x.TotalWeight <= weight || x.TotalWeight >= weight)) ||
        (decimal.TryParse(searchTerm, out decimal price) &&
            (x.ApproximatePrice <= price || x.ApproximatePrice >= price))
    )
    .ToList();

                return requests.Select(x => new RequestsForSearchViewModel
                {
                    Id = x.Id,
                    ReferenceNumber = x.RerefenceNumber,
                    PickupAddress = $"{x.PickupAddress.Street}, {x.PickupAddress.City}, {x.PickupAddress.County}",
                    DeliveryAddress = $"{x.DeliveryAddress.Street}, {x.DeliveryAddress.City}, {x.DeliveryAddress.County}",
                    ExpectedDeliveryDate = x.ExpectedDeliveryDate.ToString("dd-MM-yyyy"),
                    CreationDate = x.CreatedAt.ToString("dd-MM-yyyy"),
                    Approved = x.Status == StatusConstants.Approved,
                    NumberOfItems = (x.StandartCargo?.NumberOfPallets ?? 0) + (x.NumberOfNonStandartGoods ?? 0).ToString(),
                    TotalWeight = x.TotalWeight.ToString("F2"),
                    TotalVolume = x.TotalVolume.ToString("F2"),
                });
            }
            return new List<RequestsForSearchViewModel>();
        }

        public async Task<bool> RequestWithIdExistsAsync(int id)
        {
            return await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Request>().AnyAsync(x => x.Id == id);
        }

        public async Task<bool> RequestWithCompanyExistsAsync(int id, string username)
        {
            return await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Request>().AnyAsync(x => x.Id == id && x.ClientCompany.User.UserName == username);
        }

        public async Task<int> GetRequestIdByReferenceNumberAsync(string referenceNumber)
        {
            return await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Request>().Where(x => x.RerefenceNumber == referenceNumber).Select(x => x.Id).FirstOrDefaultAsync();
        }

        public async Task<RequestsDetailsForLogisticsViewModel?> GetRequestDetailsForLogisticsAsync(int id)
        {
            var model = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Request>().Where(x => x.Id == id)
               .Select(x => new RequestsDetailsForLogisticsViewModel
               {
                   Id = x.Id,
                   CargoType = x.CargoType,
                   NumberOfNonStandartGoods = x.NumberOfNonStandartGoods.ToString(),
                   TypeOfGoods = x.TypeOfGoods,
                   PickupAddress = $"{x.PickupAddress.Street}, {x.PickupAddress.City}, {x.PickupAddress.County}",
                   DeliveryAddress = $"{x.DeliveryAddress.Street}, {x.DeliveryAddress.City}, {x.DeliveryAddress.County}",
                   SharedTruck = x.SharedTruck,
                   ApproximatePrice = x.ApproximatePrice.ToString(),
                   ExpectedDeliveryDate = x.ExpectedDeliveryDate.ToString("dd-MM-yyyy"),
                   Status = x.Status,
                   SpecialInstructions = x.SpecialInstructions,
                   IsRefrigerated = x.IsRefrigerated,
                   CreatedAt = x.CreatedAt.ToString("dd-MM-yyyy"),
                   Kilometers = x.Kilometers.ToString(),
                   TotalWeight = x.TotalWeight.ToString(),
                   TotalVolume = x.TotalVolume.ToString(),
                   PalletsCount = x.StandartCargo != null ? x.StandartCargo.NumberOfPallets.ToString() : string.Empty,
                   PalletsLength = x.StandartCargo != null ? x.StandartCargo.PalletLength.ToString() : string.Empty,
                   PalletsHeight = x.StandartCargo != null ? x.StandartCargo.PalletHeight.ToString() : string.Empty,
                   PalletsWidth = x.StandartCargo != null ? x.StandartCargo.PalletWidth.ToString() : string.Empty,
                   ReferenceNumber = x.RerefenceNumber,
                   CompanyName = x.ClientCompany.Name,
                   CompanyId = x.ClientCompanyId,

               }).FirstOrDefaultAsync();
            model.OfferId = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Offer>().Where(x => x.RequestId == id).Select(x => x.Id).FirstOrDefaultAsync();
            var nonStandardCargos = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Request>().Where(x => x.Id == id).SelectMany(x => x.NonStandardCargos).ToListAsync();
            foreach (var item in nonStandardCargos)
            {
                var nonStandardCargo = new NonStandardCargoRequestViewModel
                {
                    Length = item.Length.ToString(),
                    Width = item.Width.ToString(),
                    Height = item.Height.ToString(),
                    Weight = item.Weight
                };
                model.NonStandardCargo.Add(nonStandardCargo);
            }
            return model;
        }

        public async Task<IEnumerable<RequestsForSearchViewModel>> GetRequestsForLogisticsAsync(DateTime? startDate = null, DateTime? endDate = null, bool isApproved = false, bool sharedTruck = false, double? minWeight = null, double? maxWeight = null, decimal? minPrice = null, decimal? maxPrice = null, string? pickupAddress = null, string? deliveryAddress = null)
        {
            var requests = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Request>().Include(x => x.ClientCompany).Include(x => x.PickupAddress).Include(x => x.DeliveryAddress).ToListAsync();
            if (startDate != null)
            {
                requests = requests.Where(x => x.CreatedAt >= startDate).ToList();
            }
            if (minPrice != null)
            {
                requests = requests.Where(x => x.ApproximatePrice >= minPrice).ToList();
            }
            if (maxPrice != null)
            {
                requests = requests.Where(x => x.ApproximatePrice <= maxPrice).ToList();
            }
            if (minWeight != null)
            {
                requests = requests.Where(x => x.TotalWeight >= minWeight).ToList();
            }
            if (maxWeight != null)
            {
                requests = requests.Where(x => x.TotalWeight <= maxWeight).ToList();
            }
            if (endDate != null)
            {
                requests = requests.Where(x => x.CreatedAt <= endDate).ToList();
            }
            if (string.IsNullOrEmpty(deliveryAddress) == false)
            {
                requests = requests.Where(x => x.DeliveryAddress.City.ToLower().Contains(deliveryAddress.ToLower()) || x.DeliveryAddress.County.ToLower().Contains(deliveryAddress.ToLower()) || x.DeliveryAddress.Street.ToLower().Contains(deliveryAddress.ToLower())).ToList();
            }
            if (string.IsNullOrEmpty(pickupAddress) == false)
            {
                requests = requests.Where(x => x.PickupAddress.City.ToLower().Contains(pickupAddress.ToLower()) || x.PickupAddress.County.ToLower().Contains(pickupAddress.ToLower()) || x.PickupAddress.Street.ToLower().Contains(pickupAddress.ToLower())).ToList();
            }

            return requests.Select(x => new RequestsForSearchViewModel
            {
                Id = x.Id,
                ReferenceNumber = x.RerefenceNumber,
                CompanyName = x.ClientCompany.Name,
                PickupAddress = $"{x.PickupAddress.Street}, {x.PickupAddress.City}, {x.PickupAddress.County}",
                DeliveryAddress = $"{x.DeliveryAddress.Street}, {x.DeliveryAddress.City}, {x.DeliveryAddress.County}",
                ExpectedDeliveryDate = x.ExpectedDeliveryDate.ToString("dd-MM-yyyy"),
                CreationDate = x.CreatedAt.ToString("dd-MM-yyyy"),
                Approved = x.Status == StatusConstants.Approved,
                NumberOfItems = (x.StandartCargo?.NumberOfPallets ?? 0) + (x.NumberOfNonStandartGoods ?? 0).ToString(),
                TotalWeight = x.TotalWeight.ToString("F2"),
                TotalVolume = x.TotalVolume.ToString("F2"),
            });
        }

        public async Task<IEnumerable<RequestsForSearchViewModel>> GetRequestsForLogisticsBySearchTermAsync(string? searchTerm)
        {
            var requests = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Request>()
               .Include(x => x.PickupAddress).Include(x => x.DeliveryAddress).Include(x => x.ClientCompany).ToListAsync();

            if (string.IsNullOrEmpty(searchTerm) == false)
            {
                requests = requests.Where(x => x.DeliveryAddress.City.ToLower().Contains(searchTerm.ToLower()) || x.DeliveryAddress.County.ToLower().Contains(searchTerm.ToLower()) || x.DeliveryAddress.Street.ToLower().Contains(searchTerm.ToLower())
                || x.PickupAddress.City.ToLower().Contains(searchTerm.ToLower()) || x.PickupAddress.County.ToLower().Contains(searchTerm.ToLower()) || x.PickupAddress.Street.ToLower().Contains(searchTerm.ToLower())
                || x.CargoType.ToLower().Contains(searchTerm.ToLower())
                || x.SpecialInstructions.ToLower().Contains(searchTerm.ToLower())
                || x.Status.ToLower().Contains(searchTerm.ToLower())
                || x.TotalWeight <= double.Parse(searchTerm)
                || x.TotalWeight >= double.Parse(searchTerm)
                || x.ApproximatePrice <= decimal.Parse(searchTerm)
                || x.ApproximatePrice <= decimal.Parse(searchTerm)).ToList();

                return requests.Select(x => new RequestsForSearchViewModel
                {
                    Id = x.Id,
                    ReferenceNumber = x.RerefenceNumber,
                    CompanyName = x.ClientCompany.Name,
                    PickupAddress = $"{x.PickupAddress.Street}, {x.PickupAddress.City}, {x.PickupAddress.County}",
                    DeliveryAddress = $"{x.DeliveryAddress.Street}, {x.DeliveryAddress.City}, {x.DeliveryAddress.County}",
                    ExpectedDeliveryDate = x.ExpectedDeliveryDate.ToString("dd-MM-yyyy"),
                    CreationDate = x.CreatedAt.ToString("dd-MM-yyyy"),
                    Approved = x.Status == StatusConstants.Approved,
                    NumberOfItems = (x.StandartCargo?.NumberOfPallets ?? 0) + (x.NumberOfNonStandartGoods ?? 0).ToString(),
                    TotalWeight = x.TotalWeight.ToString(),
                    TotalVolume = x.TotalVolume.ToString()
                });
            }
            return new List<RequestsForSearchViewModel>();
        }

        public async Task<List<RequestsDetailsForLogisticsViewModel>> GetPendingRequestsAsync(string? sharedTruck = null, DateTime? startDate = null, DateTime? endDate = null, double? minWeight = null, double? maxWeight = null, double? minVolume = null, double? maxVolume = null, string? pickupAddress = null, string? deliveryAddress = null)
        {
            var requests = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Request>().Where(x => x.Status == "Pending").Include(x => x.StandartCargo).Include(x => x.PickupAddress).Include(x => x.DeliveryAddress).Include(x => x.ClientCompany).ThenInclude(x => x.User).ToListAsync();
            if (startDate != null)
            {
                requests = requests.Where(x => x.CreatedAt >= startDate).ToList();
            }
            if (endDate != null)
            {
                requests = requests.Where(x => x.CreatedAt <= endDate).ToList();
            }
            if (string.IsNullOrEmpty(deliveryAddress) == false)
            {
                requests = requests.Where(x => x.DeliveryAddress.City.ToLower().Contains(deliveryAddress.ToLower()) || x.DeliveryAddress.County.ToLower().Contains(deliveryAddress.ToLower()) || x.DeliveryAddress.Street.ToLower().Contains(deliveryAddress.ToLower())).ToList();
            }
            if (string.IsNullOrEmpty(pickupAddress) == false)
            {
                requests = requests.Where(x => x.PickupAddress.City.ToLower().Contains(pickupAddress.ToLower()) || x.PickupAddress.County.ToLower().Contains(pickupAddress.ToLower()) || x.PickupAddress.Street.ToLower().Contains(pickupAddress.ToLower())).ToList();
            }
            if (minWeight != null)
            {
                requests = requests.Where(x => x.TotalWeight >= minWeight).ToList();
            }
            if (maxWeight != null)
            {
                requests = requests.Where(x => x.TotalWeight <= maxWeight).ToList();
            }
            if (minVolume != null)
            {
                requests = requests.Where(x => x.TotalVolume >= minVolume).ToList();
            }
            if (maxVolume != null)
            {
                requests = requests.Where(x => x.TotalVolume <= maxVolume).ToList();
            }
            bool shared = false;
            if (sharedTruck == "Shared")
            {
                requests = requests.Where(x => x.SharedTruck == true).ToList();
            }

            var model = requests
               .Select(x => new RequestsDetailsForLogisticsViewModel
               {
                   Id = x.Id,
                   CargoType = x.CargoType,
                   CompanyName = x.ClientCompany.Name,
                   NumberOfNonStandartGoods = x.NumberOfNonStandartGoods.ToString(),
                   TypeOfGoods = x.TypeOfGoods,
                   PickupAddress = $"{x.PickupAddress.Street}, {x.PickupAddress.City}, {x.PickupAddress.County}",
                   DeliveryAddress = $"{x.DeliveryAddress.Street}, {x.DeliveryAddress.City}, {x.DeliveryAddress.County}",
                   SharedTruck = x.SharedTruck,
                   ApproximatePrice = x.ApproximatePrice.ToString(),
                   ExpectedDeliveryDate = x.ExpectedDeliveryDate.ToString("dd-MM-yyyy"),
                   Status = x.Status,
                   SpecialInstructions = x.SpecialInstructions,
                   IsRefrigerated = x.IsRefrigerated,
                   CreatedAt = x.CreatedAt.ToString("dd-MM-yyyy"),
                   Kilometers = x.Kilometers.ToString(),
                   TotalWeight = x.TotalWeight.ToString(),
                   TotalVolume = x.TotalVolume.ToString(),
                   PalletsCount = x.StandartCargo != null ? x.StandartCargo.NumberOfPallets.ToString() : string.Empty,
                   PalletsLength = x.StandartCargo != null ? x.StandartCargo.PalletLength.ToString() : string.Empty,
                   PalletsHeight = x.StandartCargo != null ? x.StandartCargo.PalletHeight.ToString() : string.Empty,
                   PalletsWidth = x.StandartCargo != null ? x.StandartCargo.PalletWidth.ToString() : string.Empty,
                   ReferenceNumber = x.RerefenceNumber,
               }).ToList();
            foreach (var item in model)
            {
                var nonStandardCargos = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Request>().Where(x => x.Id == item.Id).SelectMany(x => x.NonStandardCargos).ToListAsync();

                foreach (var cargo in nonStandardCargos)
                {
                    var nonStandardCargo = new NonStandardCargoRequestViewModel
                    {
                        Length = cargo.Length.ToString(),
                        Width = cargo.Width.ToString(),
                        Height = cargo.Height.ToString(),
                        Weight = cargo.Weight
                    };
                    item.NonStandardCargo.Add(nonStandardCargo);
                }
            }
            return model ?? new List<RequestsDetailsForLogisticsViewModel>();
        }

        public async Task<PendingRequestDetailsViewModel?> GetPendingRequestDetailsAsync(int id)
        {
            var request = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Request>().Where(x => x.Id == id).Include(x => x.PickupAddress).Include(x => x.DeliveryAddress).Include(x => x.ClientCompany).FirstOrDefaultAsync();

            var model = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Request>().Where(x => x.Id == id).Include(x => x.PickupAddress).Include(x => x.DeliveryAddress).Include(x => x.ClientCompany)
                .Select(x => new PendingRequestDetailsViewModel()
                {
                    ReferenceNumber = x.RerefenceNumber,
                    ClientCompanyName = x.ClientCompany.Name,
                    RegistrationNumber = x.ClientCompany.RegistrationNumber,
                    ClientAddress = $"{x.ClientCompany.Address.City}, {x.ClientCompany.Address.City}, {x.ClientCompany.Address.Street}, {x.ClientCompany.Address.PostalCode} ",
                    ClientEmail = x.ClientCompany.User.Email,
                    ClientPhone = x.ClientCompany.User.PhoneNumber,
                    ClientId = x.ClientCompanyId,
                    CreatedOn = x.CreatedAt.ToString("dd-MM-yyyy"),
                    NumberOfPallets = x.StandartCargo != null ? x.StandartCargo.NumberOfPallets.ToString() : "0",
                    PalletLength = x.StandartCargo != null ? x.StandartCargo.PalletLength.ToString() : "0",
                    PalletWidth = x.StandartCargo != null ? x.StandartCargo.PalletWidth.ToString() : "0",
                    PalletHeight = x.StandartCargo != null ? x.StandartCargo.PalletHeight.ToString() : "0",
                    PalletVolume = x.StandartCargo != null ? x.StandartCargo.PalletVolume.ToString() : "0",
                    WeightOfPallets = x.StandartCargo != null ? x.StandartCargo.WeightOfPallets.ToString() : "0",
                    PalletsAreStackable = x.StandartCargo != null ? "Yes" : "No",
                    TypeOfGoods = x.TypeOfGoods,
                    PickupLatitude = x.PickupAddress.Latitude.ToString(),
                    PickupCity = x.PickupAddress.City,
                    PickupCountry = x.PickupAddress.County,
                    PickupStreet = x.PickupAddress.Street,
                    PickupLongitude = x.PickupAddress.Longitude.ToString(),
                    DeliveryCity = x.DeliveryAddress.City,
                    DeliveryCountry = x.DeliveryAddress.County,
                    DeliveryStreet = x.DeliveryAddress.Street,
                    DeliveryLatitude = x.DeliveryAddress.Latitude.ToString(),
                    DeliveryLongitude = x.DeliveryAddress.Longitude.ToString(),
                    SharedTruck = x.SharedTruck == true ? "Yes" : "No",
                    ExpectedDeliveryDate = x.ExpectedDeliveryDate.ToString("dd-MM-yyyy"),
                    SpecialInstructions = x.SpecialInstructions,
                    IsRefrigerated = x.IsRefrigerated == true ? "Yes" : "No",
                    ApproximatePrice = x.ApproximatePrice.ToString("F2"),
                }).FirstOrDefaultAsync();
            var suggestedStartDate = await GetSuggestedStartDateForNotSharedDelivery(id);

            model.NonStandardCargos = await repository.AllReadonly<Infrastructure.Data.DataModels.NonStandardCargo>().Where(x => x.RequestId == id)
                .Select(x => new NonStandardCargosViewModel
                {
                    Length = x.Length.ToString(),
                    Width = x.Width.ToString(),
                    Height = x.Height.ToString(),
                    Weight = x.Weight.ToString(),
                    Description = x.Description
                }).ToListAsync();

            model.PossibleDrivers = await GetPossibleDriversForDelivery(id, suggestedStartDate);
            var possibleVehicles = await GetPossibleVehiclesForDelivery(id, suggestedStartDate);
            if (possibleVehicles.Item1  is List<PossibleVehiclesForDeliveryViewModel> vehicles)
            {
                model.PossibleVehicles = vehicles;
                model.RequiredVehicleCount = possibleVehicles.Item2;
            }
            else if (possibleVehicles.Item1 is List<(PossibleVehiclesForDeliveryViewModel Primary, PossibleVehiclesForDeliveryViewModel Secondary, VehiclePairsLegend Legend)> vehiclePairs)
            {
                model.NeededVehiclePairs = vehiclePairs; 
                model.RequiredVehicleCount = possibleVehicles.Item2;
            }

            return model;
        }

        private async Task<(object, int)> GetPossibleVehiclesForDelivery(int id, DateTime suggestedStartDate)
        {
            var modelToReturn = new List<PossibleVehiclesForDeliveryViewModel>();
            var request = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Request>().Where(x => x.Id == id).FirstOrDefaultAsync();

            var reservedVehicles = await repository.AllReadonly<ReservedForDelivery>().Where(x => x.Start >= suggestedStartDate && x.End <= request.ExpectedDeliveryDate).Select(x => x.VehicleId)
                .ToListAsync();

            var possibleVehiclesByTime = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Vehicle>().Where(x => !reservedVehicles.Contains(x.Id)).Include(x => x.Deliveries)
                .ToListAsync();
            var requiredVehicleCount = 1;

            var pairsForBiggerRequest = await FindMostCompatibleVehiclesForBiggerRequestForNotSharedTruck(possibleVehiclesByTime, id);
            if (pairsForBiggerRequest.RequiredVehicles == 1)
            {
                var compatiableVehicles = await FindMostCompatibleVehiclesForNotSharedTruck(possibleVehiclesByTime, id);
                var cheapestId = compatiableVehicles.OrderByDescending(x => x.ContantsExpenses).ThenByDescending(x => x.FuelConsumptionPer100Km).ThenByDescending(x => x.PurchasePrice).FirstOrDefault()?.Id;
                var economicalId = compatiableVehicles.OrderByDescending(x => x.FuelConsumptionPer100Km).FirstOrDefault()?.Id;
                var ecologicalId = compatiableVehicles.OrderByDescending(x => x.EmissionFactor).FirstOrDefault()?.Id;
                var closestToMaintenanceId = compatiableVehicles.OrderBy(x => x.KilometersLeftToChangeParts).ThenByDescending(x => x.LastYearMaintenance).FirstOrDefault()?.Id;
                var mstOptimalId = compatiableVehicles.OrderByDescending(x => x.ContantsExpenses).ThenByDescending(x => x.FuelConsumptionPer100Km).ThenByDescending(x => x.EmissionFactor).FirstOrDefault()?.Id;

                foreach (var vehicle in compatiableVehicles)
                {
                    var deliveriesThisYear = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>().Where(x => x.VehicleId == vehicle.Id && x.ActualDeliveryDate.Value.Year == DateTime.Now.Year).ToListAsync();
                    var reservedForDelivery = await repository.AllReadonly<ReservedForDelivery>().Where(x => x.VehicleId == vehicle.Id).ToListAsync();
                    var currentDeliveries = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>().Where(x => x.VehicleId == vehicle.Id && x.DeliveryStep < 4).FirstOrDefaultAsync();
                    bool currentlyDelivering = currentDeliveries != null;
                    var vehicleModel = new PossibleVehiclesForDeliveryViewModel
                    {
                        Id = vehicle.Id,
                        VehicleType = vehicle.VehicleType,
                        RegistrationNumber = vehicle.RegistrationNumber,
                        EmissionFactor = vehicle.EmissionFactor.ToString(),
                        FuelConsumptionPer100km = vehicle.FuelConsumptionPer100Km.ToString(),
                        Height = vehicle.Height.ToString(),
                        Width = vehicle.Width.ToString(),
                        Length = vehicle.Length.ToString(),
                        Weight = vehicle.MaxWeightCapacity.ToString(),
                        KilometersTillChangingParts = vehicle.KilometersLeftToChangeParts,
                        Kilometers = vehicle.KilometersDriven,
                        CalculatedPrice = await CalculatePriceForRequest(vehicle, id),
                        ReservedDeliveriesCount = reservedForDelivery.Count(),
                        CurrentlyDelivering = currentlyDelivering,
                        DeliveriesThisYearCount = deliveriesThisYear.Count(),
                        Cheapest = cheapestId == vehicle.Id,
                        MostEconomical = economicalId == vehicle.Id,
                        MostEcological = ecologicalId == vehicle.Id,
                        ClosestToMaintenance = closestToMaintenanceId == vehicle.Id,
                        MostOptimal = mstOptimalId == vehicle.Id
                    };
                    modelToReturn.Add(vehicleModel);
                }
            }
          
            return requiredVehicleCount == 1 ? (modelToReturn, 1) : (new List<PossibleVehiclesForDeliveryViewModel>(), requiredVehicleCount);
        }

        public async Task<List<Vehicle>> FindMostCompatibleVehiclesForNotSharedTruck(List<Vehicle> vehicles, int id)
        {
            var request = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Request>().Where(x => x.Id == id).FirstOrDefaultAsync();
            var standartCargo = await repository.AllReadonly<StandartCargo>().Where(x => x.Id == request.StandartCargoId).FirstOrDefaultAsync();
            var nonStandardCargos = await repository.AllReadonly<NonStandardCargo>().Where(x => x.RequestId == id).ToListAsync();

            var compatibleVehicles = vehicles.Where(vehicle =>
                    vehicle.MaxWeightCapacity >= request.TotalWeight &&
                    vehicle.Volume >= request.TotalVolume &&
                    vehicle.IsRefrigerated == request.IsRefrigerated).ToList();

            if (!string.IsNullOrEmpty(standartCargo.TypeOfPallet))
            {
                compatibleVehicles = compatibleVehicles.Where(vehicle =>
                    (standartCargo.TypeOfPallet == "Euro" && vehicle.EuroPalletCapacity >= standartCargo.NumberOfPallets) ||
                    (standartCargo.TypeOfPallet == "Industrial" && vehicle.IndustrialPalletCapacity >= standartCargo.NumberOfPallets))
                    .ToList();
            }
            else if (nonStandardCargos?.Count > 0)
            {
                compatibleVehicles = compatibleVehicles.Where(vehicle =>
                {
                    bool fitsAllCargo = request.NonStandardCargos.All(cargo =>
                        cargo.Length <= vehicle.Length &&
                        cargo.Width <= vehicle.Width &&
                        cargo.Height <= vehicle.Height);
                    return fitsAllCargo;
                }).ToList();
            }

            var mostCompatibleVehicles = compatibleVehicles
                .OrderBy(vehicle => vehicle.MaxWeightCapacity - request.TotalWeight) 
                .ThenBy(vehicle => vehicle.Volume - request.TotalVolume) 
                .ToList();

            return mostCompatibleVehicles;
        }

        public async Task<(List<(Vehicle Primary, Vehicle? Secondary)>, int RequiredVehicles)> FindMostCompatibleVehiclesForBiggerRequestForNotSharedTruck(List<Vehicle> vehicles, int id)
        {
            var modelToReturn = new List<(PossibleVehiclesForDeliveryViewModel Primary, PossibleVehiclesForDeliveryViewModel Secondary, VehiclePairsLegend Legend)>();
            var request = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Request>()
                                          .Where(x => x.Id == id)
                                          .FirstOrDefaultAsync();
            var standartCargo = await repository.AllReadonly<StandartCargo>()
                                                .Where(x => x.Id == request.StandartCargoId)
                                                .FirstOrDefaultAsync();
            var nonStandardCargos = await repository.AllReadonly<NonStandardCargo>()
                                                    .Where(x => x.RequestId == id)
                                                    .ToListAsync();

            var compatibleVehicles = vehicles.Where(vehicle =>
                vehicle.MaxWeightCapacity >= request.TotalWeight ||
                vehicle.Volume >= request.TotalVolume &&
                vehicle.IsRefrigerated == request.IsRefrigerated).ToList();
            var requiredVehicles = 1;
            int? cheapestPairId = 0;
            int? economicalPairId = 0;
            int? ecologicalPairId = 0;
            int? closestToMaintenancePairId = 0;
            int? mostOptimalPairId = 0;

            if (!string.IsNullOrEmpty(standartCargo?.TypeOfPallet))
            {
                compatibleVehicles = compatibleVehicles.Where(vehicle =>
                    (standartCargo.TypeOfPallet == "Euro" && vehicle.EuroPalletCapacity >= standartCargo.NumberOfPallets) ||
                    (standartCargo.TypeOfPallet == "Industrial" && vehicle.IndustrialPalletCapacity >= standartCargo.NumberOfPallets))
                    .ToList();
            }
            else if (nonStandardCargos?.Count > 0)
            {
                compatibleVehicles = compatibleVehicles.Where(vehicle =>
                    request.NonStandardCargos.All(cargo =>
                        cargo.Length <= vehicle.Length &&
                        cargo.Width <= vehicle.Width &&
                        cargo.Height <= vehicle.Height))
                    .ToList();
            }

            var mostCompatibleVehicles = new List<(Vehicle Primary, Vehicle? Secondary)>();

            compatibleVehicles = compatibleVehicles
                .OrderBy(vehicle => vehicle.MaxWeightCapacity - request.TotalWeight)
                .ThenBy(vehicle => vehicle.Volume - request.TotalVolume)
                .ToList();

            foreach (var primary in compatibleVehicles)
            {
                if (primary.MaxWeightCapacity >= request.TotalWeight && primary.Volume >= request.TotalVolume)
                {
                    mostCompatibleVehicles.Add((Primary: primary, Secondary: null));
                }
                else
                {
                    foreach (var secondary in compatibleVehicles.Where(v => v != primary))
                    {
                        if (primary.MaxWeightCapacity + secondary.MaxWeightCapacity >= request.TotalWeight &&
                            primary.Volume + secondary.Volume >= request.TotalVolume)
                        {
                            requiredVehicles++;
                            mostCompatibleVehicles.Add((Primary: primary, Secondary: secondary));
                        }
                    }
                }
            }

            foreach (var pair in mostCompatibleVehicles)
            {
                var cheapestPair = new[] { pair.Primary, pair.Secondary }
                    .Where(x => x != null)  
                    .OrderBy(x => x.ContantsExpenses + (decimal)x.FuelConsumptionPer100Km + x.PurchasePrice)
                    .FirstOrDefault();
                cheapestPairId = cheapestPair?.Id;

                var economicalPair = new[] { pair.Primary, pair.Secondary }
                    .Where(x => x != null)
                    .OrderBy(x => x.FuelConsumptionPer100Km)
                    .FirstOrDefault();
                economicalPairId = economicalPair?.Id;

                var ecologicalPair = new[] { pair.Primary, pair.Secondary }
                    .Where(x => x != null)
                    .OrderBy(x => x.EmissionFactor)
                    .FirstOrDefault();
                ecologicalPairId = ecologicalPair?.Id;

                var closestToMaintenancePair = new[] { pair.Primary, pair.Secondary }
                    .Where(x => x != null)
                    .OrderBy(x => x.KilometersLeftToChangeParts)
                    .ThenByDescending(x => x.LastYearMaintenance)
                    .FirstOrDefault();
                closestToMaintenancePairId = closestToMaintenancePair?.Id;

                var mostOptimalPair = new[] { pair.Primary, pair.Secondary }
                    .Where(x => x != null)
                    .OrderByDescending(x => x.ContantsExpenses + (decimal)x.FuelConsumptionPer100Km)
                    .ThenByDescending(x => x.EmissionFactor)
                    .FirstOrDefault();
                mostOptimalPairId = mostOptimalPair?.Id;
            }
            foreach (var pair in mostCompatibleVehicles)
            {
                var deliveriesThisYearForVehicle1 = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>().Where(x => x.VehicleId == pair.Primary.Id && x.ActualDeliveryDate.Value.Year == DateTime.Now.Year).ToListAsync();
                var reservedForDeliveryForVehicle1 = await repository.AllReadonly<ReservedForDelivery>().Where(x => x.VehicleId == pair.Primary.Id).ToListAsync();
                var currentDeliveriesForVehicle1 = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>().Where(x => x.VehicleId == pair.Primary.Id && x.DeliveryStep < 4).FirstOrDefaultAsync();
                bool currentlyDelivering = currentDeliveriesForVehicle1 != null;
                var possibleVehicle1 = new PossibleVehiclesForDeliveryViewModel()
                {
                        Id = pair.Primary.Id,
                        VehicleType = pair.Primary.VehicleType,
                        RegistrationNumber = pair.Primary.RegistrationNumber,
                        EmissionFactor = pair.Primary.EmissionFactor.ToString(),
                        FuelConsumptionPer100km = pair.Primary.FuelConsumptionPer100Km.ToString(),
                        Height = pair.Primary.Height.ToString(),
                        Width = pair.Primary.Width.ToString(),
                        Length = pair.Primary.Length.ToString(),
                        Weight = pair.Primary.MaxWeightCapacity.ToString(),
                        KilometersTillChangingParts = pair.Primary.KilometersLeftToChangeParts,
                        Kilometers = pair.Primary.KilometersDriven,
                        CalculatedPrice = await CalculatePriceForRequest(pair.Primary, id),
                        ReservedDeliveriesCount = reservedForDeliveryForVehicle1.Count(),
                        CurrentlyDelivering = currentlyDelivering,
                        DeliveriesThisYearCount = deliveriesThisYearForVehicle1.Count(),
                };
                var deliveriesThisYearForVehicle2 = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>().Where(x => x.VehicleId == pair.Secondary.Id && x.ActualDeliveryDate.Value.Year == DateTime.Now.Year).ToListAsync();
                var reservedForDeliveryForVehicle2 = await repository.AllReadonly<ReservedForDelivery>().Where(x => x.VehicleId == pair.Secondary.Id).ToListAsync();
                var currentDeliveriesForVehicle2 = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>().Where(x => x.VehicleId == pair.Secondary.Id && x.DeliveryStep < 4).FirstOrDefaultAsync();
                bool currentlyDeliveringForVehicle2 = currentDeliveriesForVehicle1 != null;
                var possibleVehicle2 = new PossibleVehiclesForDeliveryViewModel()
                {
                    Id = pair.Secondary.Id,
                    VehicleType = pair.Secondary.VehicleType,
                    RegistrationNumber = pair.Secondary.RegistrationNumber,
                    EmissionFactor = pair.Secondary.EmissionFactor.ToString(),
                    FuelConsumptionPer100km = pair.Secondary.FuelConsumptionPer100Km.ToString(),
                    Height = pair.Secondary.Height.ToString(),
                    Width = pair.Secondary.Width.ToString(),
                    Length = pair.Secondary.Length.ToString(),
                    Weight = pair.Secondary.MaxWeightCapacity.ToString(),
                    KilometersTillChangingParts = pair.Secondary.KilometersLeftToChangeParts,
                    Kilometers = pair.Secondary.KilometersDriven,
                    CalculatedPrice = await CalculatePriceForRequest(pair.Secondary, id),
                    ReservedDeliveriesCount = reservedForDeliveryForVehicle2.Count(),
                    CurrentlyDelivering = currentlyDeliveringForVehicle2,
                    DeliveriesThisYearCount = deliveriesThisYearForVehicle2.Count(),
                };
                var vehiclePairsLegend = new VehiclePairsLegend()
                {
                    Cheapest = cheapestPairId == pair.Primary.Id || cheapestPairId == pair.Secondary.Id,
                    MostEconomical = economicalPairId == pair.Primary.Id || economicalPairId == pair.Secondary.Id,
                    MostEcological = ecologicalPairId == pair.Primary.Id || ecologicalPairId == pair.Secondary.Id,
                    ClosestToMaintenance = closestToMaintenancePairId == pair.Primary.Id || closestToMaintenancePairId == pair.Secondary.Id,
                    MostOptimal = mostOptimalPairId == pair.Primary.Id || mostOptimalPairId == pair.Secondary.Id                   
                };

                modelToReturn.Add((possibleVehicle1, possibleVehicle2, vehiclePairsLegend));
               
            }

            return (mostCompatibleVehicles, requiredVehicles);
        }

        private async Task<decimal> CalculatePriceForRequest(LogisticsSystem.Infrastructure.Data.DataModels.Vehicle vehicle, int id)
        {
            var request = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Request>().Where(x => x.Id == id).FirstOrDefaultAsync();
            var fuelConsumption = (request.Kilometers / 100) * vehicle.FuelConsumptionPer100Km;
            var fuelPrice = await repository.AllReadonly<Infrastructure.Data.DataModels.FuelPrice>().OrderByDescending(x => x.Date).FirstOrDefaultAsync();
            var fuelCost = (decimal)fuelConsumption * fuelPrice.Price;
            var requestType = request.Type;
            var shared = request.SharedTruck ? "SharedTruck" : "NotSharedTruck";
            var quotient = $"QuotientFor{requestType}{shared}";
            var expression = Expression.Parameter(typeof(PricesPerSize), "x");
            var property = Expression.Property(expression, quotient);
            var lambda = Expression.Lambda<Func<PricesPerSize, double>>(property, expression);
            var pricesPerSize = await repository.AllReadonly<PricesPerSize>().Where(x => x.VehicleId == vehicle.Id).Select(lambda).FirstOrDefaultAsync(); ;
            var calculatedPrice = (decimal)(pricesPerSize * request.Kilometers) + (vehicle.ContantsExpenses + fuelCost);
            return calculatedPrice + calculatedPrice * (decimal)0.20;
        }

        private async Task<DateTime> GetSuggestedStartDateForNotSharedDelivery(int id)
        {
            var request = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Request>().Where(x => x.Id == id).Include(x => x.StandartCargo).Include(x => x.PickupAddress).Include(x => x.DeliveryAddress).FirstOrDefaultAsync();

            string travelTimeResponse = await geocodingService.GetTravelTimeAsync(request.PickupAddress.Latitude.Value, request.PickupAddress.Longitude.Value, request.DeliveryAddress.Latitude.Value, request.DeliveryAddress.Longitude.Value);
            TimeSpan travelTime = ParseGoogleDuration(travelTimeResponse);

            var travelAndRestTime = GetDrivingTimeAndDays(travelTime);

            var cargoLoadingUnloadingTime = await GetCargoLoadigAndUnloadingTime(id);

            var totalBufferTime = await GetTotalBufferTime(id, travelTime, travelAndRestTime.drivingDays);

            TimeSpan totalTimeRequired = travelTime + travelAndRestTime.totalRestTime + cargoLoadingUnloadingTime.Item1 + cargoLoadingUnloadingTime.Item2 + totalBufferTime;

            DateTime currentTime = DateTime.Now;
            DateTime workingDayStart = currentTime.Date.AddHours(6);
            DateTime workingDayEnd = currentTime.Date.AddHours(20);

            DateTime suggestedStartDate = currentTime - totalTimeRequired;

            if (suggestedStartDate.TimeOfDay < workingDayStart.TimeOfDay)
            {
                suggestedStartDate = suggestedStartDate.AddDays(-1).Date.AddHours(18) - totalTimeRequired;
            }

            return suggestedStartDate;
        }

        private TimeSpan ParseGoogleDuration(string duration)
        {
            TimeSpan result = TimeSpan.Zero;

            var parts = duration.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < parts.Length; i += 2)
            {
                if (i + 1 >= parts.Length)
                    break;

                if (int.TryParse(parts[i], out int value))
                {
                    string unit = parts[i + 1].ToLower();
                    if (unit.StartsWith("day"))
                        result = result.Add(TimeSpan.FromDays(value));
                    else if (unit.StartsWith("hour"))
                        result = result.Add(TimeSpan.FromHours(value));
                    else if (unit.StartsWith("minute"))
                        result = result.Add(TimeSpan.FromMinutes(value));
                    else if (unit.StartsWith("second"))
                        result = result.Add(TimeSpan.FromSeconds(value));
                }
            }

            return result;
        }

        private async Task<(TimeSpan, TimeSpan)> GetCargoLoadigAndUnloadingTime(int id)
        {
            var request = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Request>().Where(x => x.Id == id).Include(x => x.StandartCargo).FirstOrDefaultAsync();
            var palletCount = await repository.AllReadonly<StandartCargo>().Where(x => x.Id == request.StandartCargoId).Select(x => x.NumberOfPallets).FirstOrDefaultAsync();
            var nonStandardCargos = await repository.AllReadonly<NonStandardCargo>().Where(x => x.RequestId == id).ToListAsync();

            TimeSpan loadingTime = TimeSpan.Zero;
            TimeSpan unloadingTime = TimeSpan.Zero;

            if (palletCount.HasValue && palletCount.Value > 0)
            {
                loadingTime += TimeSpan.FromMinutes(palletCount.Value * 7);
                unloadingTime += TimeSpan.FromMinutes(palletCount.Value * 7);
            }

            foreach (var cargo in nonStandardCargos)
            {
                loadingTime += TimeSpan.FromMinutes(cargo.Weight / 1000 * 20);
                unloadingTime += TimeSpan.FromMinutes(cargo.Weight / 1000 * 20);
            }

            return (loadingTime, unloadingTime);
        }

        private async Task<TimeSpan> GetTotalBufferTime(int id, TimeSpan travelTime, int deliveryDays)
        {
            TimeSpan bufferTime = TimeSpan.FromMinutes(30);

            TimeSpan additionalBuffer = travelTime.TotalHours > 6 ? TimeSpan.FromMinutes(60) : TimeSpan.Zero;

            TimeSpan dailyBuffer = TimeSpan.FromMinutes(deliveryDays * 15);

            var nonStandardCargos = await repository.AllReadonly<NonStandardCargo>().Where(x => x.RequestId == id).CountAsync();
            TimeSpan nonStandardCargoBuffer = nonStandardCargos > 0 ? TimeSpan.FromMinutes(30) : TimeSpan.Zero;

            return bufferTime + additionalBuffer + dailyBuffer + nonStandardCargoBuffer;
        }

        private (TimeSpan totalDailyDrivingTime, int drivingDays, TimeSpan totalRestTime) GetDrivingTimeAndDays(TimeSpan travelTime)
        {
            const int maxDrivingHoursPerDay = 9;
            const int restBreakMinutes = 30;
            const int breakAfterHours = 3;

            double totalDrivingHours = travelTime.TotalHours;
            int totalDrivingWithBreakSegments = (int)Math.Ceiling(totalDrivingHours / breakAfterHours);

            int totalRestBreaks = totalDrivingWithBreakSegments - 1;

            TimeSpan mandatoryRestTime = TimeSpan.FromMinutes(totalRestBreaks * restBreakMinutes);

            TimeSpan totalDailyDrivingTime = TimeSpan.FromHours(maxDrivingHoursPerDay) + mandatoryRestTime;

            int drivingDays = (int)Math.Ceiling(totalDrivingHours / maxDrivingHoursPerDay);

            TimeSpan totalOvernightRest = TimeSpan.FromHours((drivingDays - 1) * 10);

            TimeSpan totalRestTime = mandatoryRestTime + totalOvernightRest;

            return (totalDailyDrivingTime, drivingDays, totalRestTime);
        }

        private async Task<List<PossibleDriversForDeliveryViewModel>> GetPossibleDriversForDelivery(int id, DateTime suggestedStartDate)
        {
            var request = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Request>().Where(x => x.Id == id).Include(x => x.PickupAddress).Include(x => x.DeliveryAddress).FirstOrDefaultAsync();
            var reservedDrivers = await repository.AllReadonly<ReservedForDelivery>().Where(x => x.Start >= suggestedStartDate && x.End <= request.ExpectedDeliveryDate).Select(x => x.DriverId).ToListAsync();
            var possibleDrivers = await repository.AllReadonly<Infrastructure.Data.DataModels.Driver>().Where(x => !reservedDrivers.Contains(x.Id)).Include(x => x.Deliveries).ToListAsync();

            var licenseExpiringId = possibleDrivers.OrderBy(x => x.LicenseExpiryDate).FirstOrDefault()?.Id;
            var experiencedId = possibleDrivers.OrderByDescending(x => x.YearOfExperience).FirstOrDefault()?.Id;
            var fittestId = possibleDrivers.OrderBy(x => x.Age).FirstOrDefault()?.Id;

            var driverViewModels = new List<PossibleDriversForDeliveryViewModel>();

            foreach (var driver in possibleDrivers)
            {
                var deliveriesWithDriver = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>().Include(x => x.Offer).ThenInclude(x => x.Request).Where(x => x.DriverId == driver.Id).ToListAsync();
                var reservedDeliveriesCount = deliveriesWithDriver.Count(x => x.ActualDeliveryDate == null);
                var domesticDeliveriesThisYearCount = deliveriesWithDriver.Count(x => x.ActualDeliveryDate.HasValue && x.ActualDeliveryDate.Value.Year == DateTime.Now.Year && x.Offer.Request.Type == RequestTypeConstants.Domestic);
                var internationalDeliveriesThisYearCount = deliveriesWithDriver.Count(x => x.ActualDeliveryDate.HasValue && x.ActualDeliveryDate.Value.Year == DateTime.Now.Year && x.Offer.Request.Type == RequestTypeConstants.International);
                var successRate = deliveriesWithDriver.Count(d => d.ActualDeliveryDate <= d.Offer.Request.ExpectedDeliveryDate);
                double successRatePercentage = deliveriesWithDriver.Count() > 0 ? (successRate / (double)driver.Deliveries.Count()) * 100 : 0;

                var currentDelivery = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>().Where(x => x.DriverId == driver.Id && x.ActualDeliveryDate == null).FirstOrDefaultAsync();

                var latestDeliveryTracking = currentDelivery != null ? await repository.AllReadonly<Infrastructure.Data.DataModels.DeliveryTracking>().Where(x => x.DeliveryId == currentDelivery.Id)
                        .OrderByDescending(x => x.Timestamp)
                        .FirstOrDefaultAsync() : null;

                bool isNearby = latestDeliveryTracking != null &&
                    (latestDeliveryTracking.Latitude == request.PickupAddress.Latitude ||
                     latestDeliveryTracking.Longitude == request.PickupAddress.Longitude);
                driverViewModels.Add(new PossibleDriversForDeliveryViewModel
                {
                    Id = driver.Id,
                    DriverName = driver.Name,
                    KilometersDriven = deliveriesWithDriver.Sum(x => x.Offer.Request.Kilometers).ToString(),
                    Age = driver.Age,
                    DriverPhoneNumber = driver.User?.PhoneNumber,
                    ReservedDeliveriesCount = reservedDeliveriesCount,
                    InternationalDeliveriesThisYearCount = internationalDeliveriesThisYearCount,
                    DomesticsDeliveriesThisYearCount = domesticDeliveriesThisYearCount,
                    SuccessRate = successRatePercentage,
                    CurrentlyDelivering = reservedDeliveriesCount > 0,
                    LicenseExpiringSoon = licenseExpiringId == driver.Id,
                    Experienced = experiencedId == driver.Id,
                    Fit = fittestId == driver.Id,
                    LowWorkload = deliveriesWithDriver.Count() < 10
                });
            }

            return driverViewModels;
        }
    }
}

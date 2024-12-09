using LogisticsSystem.Infrastructure.Data.DataModels;
using LogiTrack.Core.Constants;
using LogiTrack.Core.Contracts;
using LogiTrack.Core.ViewModels.Delivery;
using LogiTrack.Core.ViewModels.Request;
using LogiTrack.Infrastructure.Data.DataModels;
using LogiTrack.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Pqc.Crypto.Utilities;
using System.Linq.Expressions;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;
using static LogiTrack.Infrastructure.Data.DataConstants.DataModelConstants;

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
            if( minPrice != null)
            {
                requests = requests.Where(x => x.ApproximatePrice >= minPrice).ToList();
            }
            if (maxPrice != null)
            {
                requests = requests.Where(x => x.ApproximatePrice <= maxPrice).ToList();
            }
            if(minWeight != null)
{
                requests = requests.Where(x => x.TotalWeight  >= minWeight).ToList();
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
                NumberOfItems =  (x.StandartCargo?.NumberOfPallets ?? 0) + (x.NumberOfNonStandartGoods ?? 0).ToString(),
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
                var offer = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Offer>().Where(x => x.RequestId == model.Id)  .Select(x => new { x.Id }) .FirstOrDefaultAsync();

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
            var requests = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Request>().Include(x => x.PickupAddress).Include(x => x.DeliveryAddress).ToListAsync();
            if (startDate != null)
            {
                requests = requests.Where(x => x.CreatedAt >= startDate).ToList();
            }
            if (endDate != null)
            {
                requests = requests.Where(x => x.CreatedAt <= endDate).ToList();
            }
            if(string.IsNullOrEmpty(deliveryAddress) == false)
            {
                requests = requests.Where(x => x.DeliveryAddress.City.ToLower().Contains(deliveryAddress.ToLower()) || x.DeliveryAddress.County.ToLower().Contains(deliveryAddress.ToLower()) || x.DeliveryAddress.Street.ToLower().Contains(deliveryAddress.ToLower())).ToList();
            }
            if (string.IsNullOrEmpty(pickupAddress) == false)
            {
                requests = requests.Where(x => x.PickupAddress.City.ToLower().Contains(pickupAddress.ToLower()) || x.PickupAddress.County.ToLower().Contains(pickupAddress.ToLower()) || x.PickupAddress.Street.ToLower().Contains(pickupAddress.ToLower())).ToList();
            }
            if (isApproved)
            {
                requests = requests.Where(x => x.Status == StatusConstants.Approved).ToList();
            }
            if (sharedTruck)
            {
                requests = requests.Where(x => x.SharedTruck).ToList();
            }
            if (minWeight != null)
            {
                requests = requests.Where(x => x.TotalWeight >= minWeight).ToList();
            }
            if (maxWeight != null)
            {
                requests = requests.Where(x => x.TotalWeight <= maxWeight).ToList();
            }
            if (minPrice != null)
            {
                requests = requests.Where(x => x.ApproximatePrice >= minPrice).ToList();
            }
            if (maxPrice != null)
            {
                requests = requests.Where(x => x.ApproximatePrice <= maxPrice).ToList();
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
                TotalWeight = x.TotalWeight.ToString(),
                TotalVolume = x.TotalVolume.ToString()
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
                TotalWeight = x.TotalWeight.ToString(),
                TotalVolume = x.TotalVolume.ToString()
            });
        }

        public async Task<List<RequestsDetailsForLogisticsViewModel>> GetPendingRequestsAsync(string sharedTruck = null, DateTime? startDate = null, DateTime? endDate = null, double? minWeight = null, double? maxWeight = null, double? minVolume = null, double? maxVolume = null, string? pickupAddress = null, string? deliveryAddress = null)
        {
            var requests = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Request>().Where(x => x.Status == "Pending").Include(x => x.PickupAddress).Include(x => x.DeliveryAddress).ToListAsync();
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
            return model;
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

            var reservedDrivers = await repository.AllReadonly<ReservedForDelivery>().Where(x => x.Start >= suggestedStartDate && x.End <= request.ExpectedDeliveryDate).Select(x => x.DriverId).ToListAsync();

            var possibleDrivers = await repository.AllReadonly<Infrastructure.Data.DataModels.Driver>()
                .Where(x => !reservedDrivers.Contains(x.Id)).ToListAsync();

            var driverStatistics = await repository.AllReadonly<Infrastructure.Data.DataModels.Driver>().Where(x => possibleDrivers.Select(p => p.Id).Contains(x.Id))
                .GroupBy(x => x.Id)
                .Select(x => new
                {
                    DriverId = x.Key,
                    ReservedForDeliveries = x.Count(),
                    DomesticDeliveriesThisYearCount = x.Count(d => d.Deliveries.Any(del => del.ActualDeliveryDate.Value.Year == DateTime.Now.Year && del.Offer.Request.Type == RequestTypeConstants.Domestic)),
                    InternationalDeliveriesThisYearCount = x.Count(d => d.Deliveries.Any(del => del.ActualDeliveryDate.Value.Year == DateTime.Now.Year && del.Offer.Request.Type == RequestTypeConstants.International)),
                    SuccessRate = x.Count(d => d.Deliveries.Any(del => del.ActualDeliveryDate <= del.Offer.Request.ExpectedDeliveryDate)),
                    FittestDriver = x.OrderBy(x => x.Age)
                })
                .ToListAsync();
            var licenseExpiring = possibleDrivers.OrderBy(x => x.LicenseExpiryDate).FirstOrDefault();
            var experienced = possibleDrivers.OrderBy(x => x.YearOfExperience).FirstOrDefault();
            var nearby = possibleDrivers.OrderBy(x => x.YearOfExperience).FirstOrDefault();

            /*model.PossibleDrivers = possibleDrivers.Select(async driver =>
            {
                var driverViewModels = await Task.WhenAll(possibleDrivers.Select(async driver =>
                {
                    var statistics = driverStatistics.FirstOrDefault(x => x.DriverId == driver.Id);
                    var currentlyDelivering = reservedDrivers.Contains(driver.Id);
                    var currentDelivery = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>()
                        .Where(x => x.DriverId == driver.Id && x.ActualDeliveryDate == null)
                        .FirstOrDefaultAsync();
                    var latesDeliveryTracking = currentDelivery != null
                        ? await repository.AllReadonly<Infrastructure.Data.DataModels.DeliveryTracking>()
                            .Where(x => x.DeliveryId == currentDelivery.Id)
                            .OrderByDescending(x => x.Timestamp)
                            .FirstOrDefaultAsync()
                        : null;

                    var nearby = latesDeliveryTracking != null &&
                        latesDeliveryTracking.Latitude == request.PickupAddress.Latitude &&
                        latesDeliveryTracking.Longitude == request.PickupAddress.Longitude;

                    return new PossibleDriversForDeliveryViewModel
                    {
                        Id = driver.Id,
                        DriverName = driver.Name,
                        DriverPhoneNumber = driver.User.PhoneNumber,
                        ReservedDeliveriesCount = statistics?.ReservedForDeliveries ?? 0,
                        InternationalDeliveriesThisYearCount = statistics?.InternationalDeliveriesThisYearCount ?? 0,
                        DomesticsDeliveriesThisYearCount = statistics?.DomesticDeliveriesThisYearCount ?? 0,
                        SuccessRate = statistics?.SuccessRate ?? 0,
                        CurrentlyDelivering = currentlyDelivering,
                    };
                }));

                model.PossibleDrivers = driverViewModels.ToList();
            };*/
            return model;
        }

        private async Task<DateTime> GetSuggestedStartDateForNotSharedDelivery(int id)
        {
            var request = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Request>().Where(x => x.Id == id).Include(x => x.StandartCargo).Include(x => x.PickupAddress).Include(x => x.DeliveryAddress).FirstOrDefaultAsync();

            string travelTimeResponse = await geocodingService.GetTravelTimeAsync(request.PickupAddress.Latitude.Value, request.PickupAddress.Longitude.Value, request.DeliveryAddress.Latitude.Value, request.DeliveryAddress.Longitude.Value);
            TimeSpan travelTime = TimeSpan.Parse(travelTimeResponse);

            var nonStandartCargos = await repository.AllReadonly<Infrastructure.Data.DataModels.NonStandardCargo>().Where(x => x.RequestId == id).ToListAsync();

            var palletCount = await repository.AllReadonly<Infrastructure.Data.DataModels.StandartCargo>().Where(x => x.Id == request.StandartCargoId).Select(x => x.NumberOfPallets).FirstOrDefaultAsync();
            TimeSpan loadingTime = TimeSpan.Zero;
            TimeSpan unloadingTime = TimeSpan.Zero;

            if (palletCount != null)
            {
                switch (palletCount)
                {
                    case 10:
                        loadingTime = TimeSpan.FromHours(1);
                        unloadingTime = TimeSpan.FromHours(1);
                        break;
                    case 20:
                        loadingTime = TimeSpan.FromHours(2);
                        unloadingTime = TimeSpan.FromHours(2);
                        break;
                    case >= 20:
                        loadingTime = TimeSpan.FromHours(3);
                        unloadingTime = TimeSpan.FromHours(3);
                        break;
                    default:
                        loadingTime = TimeSpan.FromHours(1);
                        unloadingTime = TimeSpan.FromHours(1);
                        break;
                }
            }

            foreach (var nonStandardCargo in nonStandartCargos)
            {
                if (nonStandardCargo.Weight == 200)
                {
                    loadingTime += TimeSpan.FromHours(2);
                    unloadingTime += TimeSpan.FromHours(2); 
                }
                else if (nonStandardCargo.Weight >= 200)
                {
                    loadingTime += TimeSpan.FromHours(1); 
                    unloadingTime += TimeSpan.FromHours(1); 
                }
            }

            TimeSpan totalTimeRequired = travelTime + loadingTime + unloadingTime;

            TimeSpan bufferTime = TimeSpan.FromMinutes(30);

            totalTimeRequired += bufferTime * 2; 

            var currentTime = DateTime.Now;

            var suggestedStartDate = currentTime.Add(totalTimeRequired.Negate());

            return suggestedStartDate;
        }
    }
}

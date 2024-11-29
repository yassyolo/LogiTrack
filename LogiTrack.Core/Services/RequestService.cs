using LogiTrack.Core.Constants;
using LogiTrack.Core.Contracts;
using LogiTrack.Core.ViewModels.Request;
using LogiTrack.Infrastructure.Data.DataModels;
using LogiTrack.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace LogiTrack.Core.Services
{
    public class RequestService : IRequestService
    {
        private readonly IRepository repository;

        public RequestService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task MakeRequestAsync(MakeRequestViewModel model, string username)
        {
            var client = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.ClientCompany>().FirstOrDefaultAsync(x => x.User.UserName == username);

            var pickupAddress = new Address
            {
                City = model.PickupCity,
                County = model.PickupCountry,
                Street = model.PickupStreet,
                Latitude = model.PickupLatitude,
                Longitude = model.PickupLongitude
            };

            var deliveryAddress = new Address
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
            //TODO: Add calculated price

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
            var model = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Request>().Where(x => x.Id == id)
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

                }).FirstOrDefaultAsync();
            var offer = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Offer>().FirstOrDefaultAsync(x => x.RequestId == id);
            if (offer != null)
            {
                model.OfferId = offer.Id;
            }
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
                   CreatedAt = x.CreatedAt.ToString("dd/MM/yyyy"),
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
        

        
    }
}

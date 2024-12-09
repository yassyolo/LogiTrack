using LogisticsSystem.Infrastructure.Data.DataModels;
using LogiTrack.Core.Constants;
using LogiTrack.Core.Contracts;
using LogiTrack.Core.ViewModels.Offer;
using LogiTrack.Core.ViewModels.Request;
using LogiTrack.Infrastructure.Data.DataModels;
using LogiTrack.Infrastructure.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace LogiTrack.Core.Services
{
    public class OfferService : IOfferService
    {
        private readonly IRepository repository;

        public OfferService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<OfferForSearchViewModel>?> GetOffersForCompanyAsync(string username, string? deliveryAddress = null, string? pickupAddress = null, DateTime? startDate = null, DateTime? endDate = null, decimal? minPrice = null, decimal? maxPrice = null, bool? isApproved = null, double ? minWeight = null, double? maxWeight = null)
        {
            var query = GetFilteredOffersQuery(x => x.Request.ClientCompany.User.UserName == username, deliveryAddress = null, pickupAddress = null, startDate = null, endDate = null, minPrice = null, maxPrice = null, isApproved = null,  minWeight = null, maxWeight = null);            

            var offers = await query.ToListAsync();
            return offers.Select(x => new OfferForSearchViewModel
            {
                OfferNumber = x?.OfferNumber,
                Status = x.OfferStatus,
                Id = x.Id,
                PickupAddress = $"{x.Request.PickupAddress.Street}, {x.Request.PickupAddress.City}, {x.Request.PickupAddress.County}",
                DeliveryAddress = $"{x.Request.DeliveryAddress.Street}, {x.Request.DeliveryAddress.City}, {x.Request.DeliveryAddress.County}",
                NumberOfPallets = x.Request.StandartCargo?.NumberOfPallets.ToString() ?? "0",
                TotalVolume = x.Request.TotalVolume.ToString(),
                TotalWeight = x.Request.TotalWeight.ToString(),
                NumberOfNonStandartGoods = x.Request.NumberOfNonStandartGoods.ToString(),
                ExpectedDeliveryDate = x.Request.ExpectedDeliveryDate.ToString("dd-MM-yyyy"),
                FinalPrice = x.FinalPrice.ToString(),
                OfferDate = x.OfferDate.ToString("dd-MM-yyyy"),
                Booked = x.OfferStatus == StatusConstants.Approved,
                TotalCargos = (x.Request.StandartCargo?.NumberOfPallets ?? 0) + (x.Request.NumberOfNonStandartGoods ?? 0).ToString(),
            }).ToList();
        }

        public async Task<List<OfferForSearchViewModel>?> GetOffersForCompanyBySearchTermAsync(string username, string? searchTerm = null)
        {
            var query = repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Offer>()
                 .Include(x => x.Request).ThenInclude(x => x.PickupAddress).Include(x => x.Request).ThenInclude(x => x.DeliveryAddress).Where(x => x.Request.ClientCompany.User.UserName == username).AsQueryable();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = FilterOffersBySearchTerm(query, searchTerm);

                var offers = await query.ToListAsync();

                return (offers.Select(x => new OfferForSearchViewModel
                {
                    Id = x.Id,
                    OfferNumber = x.OfferNumber,
                    Status = x.OfferStatus,
                    PickupAddress = $"{x.Request.PickupAddress.Street}, {x.Request.PickupAddress.City}, {x.Request.PickupAddress.County}",
                    DeliveryAddress = $"{x.Request.DeliveryAddress.Street}, {x.Request.DeliveryAddress.City}, {x.Request.DeliveryAddress.County}",
                    NumberOfNonStandartGoods = x.Request.NumberOfNonStandartGoods.ToString(),
                    ExpectedDeliveryDate = x.Request.ExpectedDeliveryDate.ToString("dd-MM-yyyy"),
                    FinalPrice = x.FinalPrice.ToString(),
                    OfferDate = x.OfferDate.ToString("dd-MM-yyyy"),
                    TotalCargos = (x.Request.StandartCargo?.NumberOfPallets ?? 0) + (x.Request.NumberOfNonStandartGoods ?? 0).ToString(),
                }).ToList());
            }
            return new List<OfferForSearchViewModel>();
        }

        public async Task<bool> OfferWithIdExistsAsync(int id)
        {
            return await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Offer>().AnyAsync(x => x.Id == id);
        }

        public async Task<bool> OfferWithCompanyExistsAsync(int id, string username)
        {
            var company = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.ClientCompany>().FirstOrDefaultAsync(x => x.User.UserName == username);

            return await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Offer>().AnyAsync(x => x.Id == id && x.Request.ClientCompanyId == company.Id);
        }

        public async Task<int> GetOfferIdByOfferNumberAsync(string offerNumber)
        {
            return await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Offer>().Where(x => x.OfferNumber == offerNumber).Select(x => x.Id).FirstOrDefaultAsync();
        }

        public async Task<OfferViewModel?> GetOfferDetailsAsync(int id)
        {
            var model = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Offer>().Where(x => x.Id == id)
                .Select( x => new OfferViewModel
                {
                    Id = x.Id,
                    RequestId = x.Request.Id,
                    CargoType = x.Request.CargoType,
                    ReferenceNumber = x.OfferNumber,
                    NumberOfNonStandartGoods = x.Request.NumberOfNonStandartGoods.ToString(),
                    TypeOfGoods = x.Request.TypeOfGoods,
                    PickupAddress = $"{x.Request.PickupAddress.Street}, {x.Request.PickupAddress.City}, {x.Request.PickupAddress.County}",
                    DeliveryAddress = $"{x.Request.DeliveryAddress.Street}, {x.Request.DeliveryAddress.City}, {x.Request.DeliveryAddress.County}",
                    SharedTruck = x.Request.SharedTruck,
                    ApproximatePrice = x.Request.ApproximatePrice.ToString(),
                    ExpectedDeliveryDate = x.Request.ExpectedDeliveryDate.ToString("dd-MM-yyyy"),
                    Status = x.Request.Status,
                    SpecialInstructions = x.Request.SpecialInstructions,
                    IsRefrigerated = x.Request.IsRefrigerated,
                    CreatedAt = x.Request.CreatedAt.ToString("dd-MM-yyyy"),
                    Kilometers = x.Request.Kilometers.ToString(),
                    TotalWeight = x.Request.TotalWeight.ToString(),
                    TotalVolume = x.Request.TotalVolume.ToString(),
                    PalletsCount = x.Request.StandartCargo != null ? x.Request.StandartCargo.NumberOfPallets.ToString() : string.Empty,
                    PalletsLength = x.Request.StandartCargo != null ? x.Request.StandartCargo.PalletLength.ToString() : string.Empty,
                    PalletsHeight = x.Request.StandartCargo != null ? x.Request.StandartCargo.PalletHeight.ToString() : string.Empty,
                    PalletsWidth = x.Request.StandartCargo != null ? x.Request.StandartCargo.PalletWidth.ToString() : string.Empty,
                    FinalPrice = x.FinalPrice.ToString(),
                    OfferDate = x.OfferDate.ToString("dd-MM-yyyy"),
                    OfferStatus = x.OfferStatus,
                    Notes = x.Notes,
                }).FirstOrDefaultAsync();

            model.DeliveryId = await repository.AllReadonly<Delivery>().Where(x => x.OfferId == id).Select(x => x.Id).FirstOrDefaultAsync();
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

        public async Task BookOfferAsync(int id, string username)
        {
            var company = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.ClientCompany>().FirstOrDefaultAsync(x => x.User.UserName == username);
            var offer = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Offer>().Include(x => x.Request).ThenInclude(x => x.ClientCompany).FirstOrDefaultAsync(x => x.Id == id && x.Request.ClientCompanyId == company.Id);
            var reservedForDelivery = await repository.AllReadonly<ReservedForDelivery>().FirstOrDefaultAsync(x => x.OfferId == offer.Id);
            var vehicle = await repository.AllReadonly<Vehicle>().FirstOrDefaultAsync(x => x.Id == reservedForDelivery.VehicleId);
            offer.OfferStatus = StatusConstants.Approved;
            var delivery = new Delivery
            {
                OfferId = offer.Id,
                Status = DeliveryStatusConstants.Pending,
                DriverId = reservedForDelivery.DriverId,
                VehicleId = reservedForDelivery.VehicleId,
                DeliveryStep = 1,
                CarbonEmission = (offer.Request.Kilometers * vehicle.FuelConsumptionPer100Km * vehicle.EmissionFactor) / 100
            };
            await repository.AddAsync(delivery);
            delivery.ReferenceNumber = $"DEL{delivery.Id}";
            await repository.SaveChangesAsync();

            var logisticsUser = await repository.AllReadonly<IdentityUser>().FirstOrDefaultAsync(x => x.UserName == "logistics");
            var speditorUser = await repository.AllReadonly<IdentityUser>().FirstOrDefaultAsync(x => x.UserName == "speditor");
            await CreateCalendarEventAsync(EventTypesConstants.NewDelivery, $"New delivery {delivery.ReferenceNumber} scheduled for {delivery.SuggestedDate:dd-MM-yyyy}.", DateTime.Now, speditorUser.Id);

            await CreateCalendarEventAsync(EventTypesConstants.NewDelivery, $"New delivery {delivery.ReferenceNumber} scheduled for {delivery.SuggestedDate:dd-MM-yyyy}.", DateTime.Now, logisticsUser.Id);

            await CreateCalendarEventAsync(EventTypesConstants.NewDelivery,$"New delivery {delivery.ReferenceNumber} scheduled for {delivery.SuggestedDate:dd-MM-yyyy}.",delivery.SuggestedDate,delivery.Driver.UserId);

            await CreateCalendarEventAsync(EventTypesConstants.NewDelivery, $"You have a new delivery: {delivery.ReferenceNumber}.", DateTime.Now,offer.Request.ClientCompany.UserId);

            await CreateNotificationAsync("New Delivery Assigned",$"Delivery {delivery.ReferenceNumber} is scheduled for {delivery.SuggestedDate:dd-MM-yyyy}. Please check the details.",delivery.Driver.UserId);

            await CreateNotificationAsync("New Delivery Created",$"A new delivery {delivery.ReferenceNumber} has been created for your company. Track it now!",offer.Request.ClientCompany.UserId);

            await CreateNotificationAsync("New Delivery Alert",$"A new delivery {delivery.ReferenceNumber} from {company.Name} is scheduled for {delivery.SuggestedDate:dd-MM-yyyy}.",logisticsUser.Id);

            await CreateNotificationAsync("New Delivery Alert", $"A new delivery {delivery.ReferenceNumber} from {company.Name} is scheduled for {delivery.SuggestedDate:dd-MM-yyyy}.", speditorUser.Id);

            await repository.SaveChangesAsync();       
        }      

        public async Task<AcceptOfferViewModel?> GetOfferForAcceptAsync(int id)
        {
            return await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Offer>().Where(x => x.Id == id).Select(x => new AcceptOfferViewModel
            {
                OfferNumber = x.OfferNumber,             
                Amount = x.FinalPrice.ToString(),
                OfferDate = x.OfferDate.ToString("dd-MM-yyyy"),
                RequestNumber = x.Request.RerefenceNumber,
                OfferId = x.Id, 
            }).SingleOrDefaultAsync();
        }

        public async Task<List<OfferForSearchViewModel>> GetOffersForLogisticsBySearchTermAsync(string? searchTerm = null)
        {
            var query = repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Offer>()
                 .Include(x => x.Request).ThenInclude(x => x.PickupAddress).Include(x => x.Request).ThenInclude(x => x.DeliveryAddress).AsQueryable();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = FilterOffersBySearchTerm(query, searchTerm);

                var offers = await query.ToListAsync();

                return (offers.Select(x => new OfferForSearchViewModel
                {
                    Id = x.Id,
                    OfferNumber = x.OfferNumber,
                    Status = x.OfferStatus,
                    PickupAddress = $"{x.Request.PickupAddress.Street}, {x.Request.PickupAddress.City}, {x.Request.PickupAddress.County}",
                    DeliveryAddress = $"{x.Request.DeliveryAddress.Street}, {x.Request.DeliveryAddress.City}, {x.Request.DeliveryAddress.County}",
                    NumberOfNonStandartGoods = x.Request.NumberOfNonStandartGoods.ToString(),
                    ExpectedDeliveryDate = x.Request.ExpectedDeliveryDate.ToString("dd-MM-yyyy"),
                    FinalPrice = x.FinalPrice.ToString(),
                    OfferDate = x.OfferDate.ToString("dd-MM-yyyy"),
                    TotalCargos = (x.Request.StandartCargo?.NumberOfPallets ?? 0) + (x.Request.NumberOfNonStandartGoods ?? 0).ToString(),
                }).ToList());
            }
            return new List<OfferForSearchViewModel>();
        }

        public async Task<List<OfferForSearchViewModel>> GetOffersForLogisticsAsync(string? deliveryAddress = null, string? pickupAddress = null, DateTime? startDate = null, DateTime? endDate = null, decimal? minPrice = null, decimal? maxPrice = null, bool? isApproved = null, double? minWeight = null, double? maxWeight = null)
        {
            var query = GetFilteredOffersQuery(null, deliveryAddress = null, pickupAddress = null, startDate = null, endDate = null, minPrice = null, maxPrice = null, isApproved = null, minWeight = null, maxWeight = null);            

            var offers = await query.ToListAsync();
            return offers.Select(x => new OfferForSearchViewModel
            {
                OfferNumber = x?.OfferNumber,
                Status = x.OfferStatus,
                Id = x.Id,
                PickupAddress = $"{x.Request.PickupAddress.Street}, {x.Request.PickupAddress.City}, {x.Request.PickupAddress.County}",
                DeliveryAddress = $"{x.Request.DeliveryAddress.Street}, {x.Request.DeliveryAddress.City}, {x.Request.DeliveryAddress.County}",
                NumberOfPallets = x.Request.StandartCargo?.NumberOfPallets.ToString() ?? "0",
                TotalVolume = x.Request.TotalVolume.ToString(),
                TotalWeight = x.Request.TotalWeight.ToString(),
                NumberOfNonStandartGoods = x.Request.NumberOfNonStandartGoods.ToString(),
                ExpectedDeliveryDate = x.Request.ExpectedDeliveryDate.ToString("dd-MM-yyyy"),
                FinalPrice = x.FinalPrice.ToString(),
                OfferDate = x.OfferDate.ToString("dd-MM-yyyy"),
                Booked = x.OfferStatus == StatusConstants.Approved,
                TotalCargos = (x.Request.StandartCargo?.NumberOfPallets ?? 0) + (x.Request.NumberOfNonStandartGoods ?? 0).ToString(),
            }).ToList();
        }

        private IQueryable<Offer?> FilterOffersBySearchTerm(IQueryable<Offer> query, string searchTerm)
        {
            var searchTermToLower = searchTerm.ToLower();
            return query.Where(x =>
                x.Request.DeliveryAddress.City.ToLower().Contains(searchTermToLower) ||
                x.Request.DeliveryAddress.County.ToLower().Contains(searchTermToLower) ||
                x.Request.DeliveryAddress.Street.ToLower().Contains(searchTermToLower) ||
                x.Request.PickupAddress.City.ToLower().Contains(searchTermToLower) ||
                x.Request.PickupAddress.County.ToLower().Contains(searchTermToLower) ||
                x.Request.PickupAddress.Street.ToLower().Contains(searchTermToLower) ||
                x.Request.CargoType.ToLower().Contains(searchTermToLower) ||
                x.Request.SpecialInstructions.ToLower().Contains(searchTermToLower) ||
                x.Request.Status.ToLower().Contains(searchTermToLower) ||
                x.FinalPrice >= decimal.Parse(searchTerm) ||
                x.FinalPrice <= decimal.Parse(searchTerm) ||
                x.Request.ExpectedDeliveryDate.ToString().Contains(searchTerm) ||
                x.Request.CreatedAt.ToString().Contains(searchTerm) ||
                x.Request.TypeOfGoods.ToLower().Contains(searchTerm.ToLower()) ||
                x.Request.StandartCargo.NumberOfPallets.ToString().Contains(searchTerm) ||
                x.Request.TotalVolume.ToString().Contains(searchTerm) ||
                x.Request.TotalWeight.ToString().Contains(searchTerm) ||
                x.Request.NumberOfNonStandartGoods.ToString().Contains(searchTerm) ||
                x.OfferDate.ToString().Contains(searchTerm) ||
                x.OfferStatus.ToLower().Contains(searchTerm) ||
                x.OfferNumber.ToLower().Contains(searchTerm) ||
                x.Request.RerefenceNumber.ToLower().Contains(searchTermToLower));
        }

        private IQueryable<Offer?> GetFilteredOffersQuery(Expression<Func<Offer, bool>>? companyFilter, string? deliveryAddress = null, string? pickupAddress = null, DateTime? startDate = null, DateTime? endDate = null, decimal? minPrice = null, decimal? maxPrice = null, bool? isApproved = null, double? minWeight = null, double? maxWeight = null)
        {
            var query = repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Offer>().Include(x => x.Request).ThenInclude(x => x.PickupAddress)
                .Include(x => x.Request).ThenInclude(x => x.DeliveryAddress).AsQueryable();

            if(companyFilter != null)
            {
                query = query.Where(companyFilter);
            }
            if (string.IsNullOrEmpty(deliveryAddress) == false)
            {
                query = query.Where(x => x.Request.DeliveryAddress.City.ToLower().Contains(deliveryAddress.ToLower()) || x.Request.DeliveryAddress.County.ToLower().Contains(deliveryAddress.ToLower()) || x.Request.DeliveryAddress.Street.ToLower().Contains(deliveryAddress.ToLower()));
            }
            if (minWeight != null)
            {
                query = query.Where(x => x.Request.TotalWeight >= minWeight);
            }
            if (maxWeight != null)
            {
                query = query.Where(x => x.Request.TotalWeight <= maxWeight);
            }
            if (string.IsNullOrEmpty(pickupAddress) == false)
            {
                query = query.Where(x => x.Request.PickupAddress.City.ToLower().Contains(pickupAddress.ToLower()) || x.Request.PickupAddress.County.ToLower().Contains(pickupAddress.ToLower()) || x.Request.PickupAddress.Street.ToLower().Contains(pickupAddress.ToLower()));
            }
            if (startDate != null)
            {
                query = query.Where(x => x.OfferDate >= startDate);
            }
            if (endDate != null)
            {
                query = query.Where(x => x.OfferDate <= endDate);
            }
            if (minPrice != null)
            {
                query = query.Where(x => x.FinalPrice >= minPrice);
            }
            if (maxPrice != null)
            {
                query = query.Where(x => x.FinalPrice <= maxPrice);
            }
            if (isApproved != null)
            {
                query = query.Where(x => x.OfferStatus == StatusConstants.Approved);
            }

            return query;
        }

        private async Task CreateNotificationAsync(string title, string message, string userId, bool isRead = false)
        {
            var notification = new Notification
            {
                Title = title,
                Message = message,
                UserId = userId,
                IsRead = isRead,
                Date = DateTime.Now
            };

            await repository.AddAsync(notification);
        }

        private async Task CreateCalendarEventAsync(string eventType, string title, DateTime date, string userId)
        {
            var calendarEvent = new CalendarEvent
            {
                EventType = eventType,
                Title = title,
                Date = date,
                UserId = userId
            };

            await repository.AddAsync(calendarEvent);
        }
    }
}

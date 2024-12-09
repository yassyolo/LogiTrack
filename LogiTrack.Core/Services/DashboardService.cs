using LogisticsSystem.Infrastructure.Data.DataModels;
using LogiTrack.Core.Constants;
using LogiTrack.Core.Contracts;
using LogiTrack.Core.ViewModels.Accountant;
using LogiTrack.Core.ViewModels.Clients;
using LogiTrack.Core.ViewModels.Delivery;
using LogiTrack.Core.ViewModels.Driver;
using LogiTrack.Core.ViewModels.Invoice;
using LogiTrack.Core.ViewModels.Logistics;
using LogiTrack.Core.ViewModels.Offer;
using LogiTrack.Core.ViewModels.Request;
using LogiTrack.Core.ViewModels.Speditor;
using LogiTrack.Infrastructure.Data.DataModels;
using LogiTrack.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace LogiTrack.Core.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IRepository repository;

        public DashboardService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<AccountantDashboardViewModel?> GetAccountantDashboardAsync()
        {
            var currentDate = DateTime.Now;
            var lastWeekDate = currentDate.AddDays(-7);
            var lastMonthDate = currentDate.AddDays(-31);

            var deliveriesQuery = repository.AllReadonly<Delivery>();
            var invoicesQuery = repository.AllReadonly<Invoice>();

            var model = new AccountantDashboardViewModel()
            {
                NewFinishedDeliveriesFromLastWeek = await deliveriesQuery.CountAsync(x => x.Status == DeliveryStatusConstants.Delivered && x.ActualDeliveryDate > lastWeekDate),
                NotPaidDeliveriesCount = await invoicesQuery.CountAsync(x => x.Delivery.Status == DeliveryStatusConstants.Delivered && x.IsPaid == false),
                InvoicesCount = await invoicesQuery.CountAsync(),
                InvoicesCountFromLastMonth = await invoicesQuery.Where(x => x.InvoiceDate > lastMonthDate).CountAsync(),
                DueAmountForDeliveries = (await invoicesQuery.Where(x => x.IsPaid == false).SumAsync(x => x.Delivery.Offer.FinalPrice)).ToString()
            };
            model.Last5NotPaidInvoices = await invoicesQuery.Where(x => x.IsPaid == false).OrderByDescending(x => x.InvoiceDate).Take(5)
                .Select(x => new InvoiceForDashboardViewModel
                {
                    Id = x.Id,
                    CreationDate = x.InvoiceDate.ToString("dd-MM-yyyy"),
                    Date = DateTime.Now.ToString("dd-MM-yyyy"),
                    InvoiceNumber = x.InvoiceNumber,
                    Amount = x.Delivery.Offer.FinalPrice.ToString(),
                }).ToListAsync();
            model.Last5NewDeliveries = await deliveriesQuery.Where(x => x.DeliveryStep == 4).OrderByDescending(x => x.ActualDeliveryDate).Take(5)
                .Select(x => new DeliveryForAccountantViewModel
                {
                    Id = x.Id,
                    ReferenceNumber = x.ReferenceNumber,
                    ClientCompanyName = x.Offer.Request.ClientCompany.Name,
                    DeliveryAddress = $"{x.Offer.Request.DeliveryAddress.City}, {x.Offer.Request.DeliveryAddress.County} ",
                    PickupAddress = $"{x.Offer.Request.PickupAddress.City}, {x.Offer.Request.PickupAddress.County} "
                }).ToListAsync();

            return model;
        }

        public async Task<ClientsDashboardViewModel?> GetClientCompanyDashboardAsync(string username)
        {
            var lastMonth = DateTime.Now.AddDays(-30);
            var company = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.ClientCompany>().FirstOrDefaultAsync(x => x.User.UserName == username);
            var invoicesQuery = repository.AllReadonly<Invoice>().Include(x => x.Delivery).ThenInclude(x => x.Offer).ThenInclude(x => x.Request).ThenInclude(x => x.ClientCompany).Where(x => x.Delivery.Offer.Request.ClientCompanyId == company.Id);
            var offersQuery = repository.AllReadonly<Offer>().Include(x => x.Request).ThenInclude(x => x.ClientCompany).Where(x => x.Request.ClientCompanyId == company.Id);
            var requestsQuery = repository.AllReadonly<Request>().Include(x => x.ClientCompany).Where(x => x.ClientCompanyId == company.Id);

            var offers = await offersQuery.OrderByDescending(x => x.OfferDate).Where(x => x.OfferStatus == StatusConstants.Pending).Take(5)
                .Select(x => new OfferForDashboardViewModel
                {
                    Id = x.Id,
                    ReferenceNumber = x.OfferNumber,
                    PickupAddress = $"{x.Request.PickupAddress.Street}, {x.Request.PickupAddress.City}, {x.Request.PickupAddress.County}",
                    DeliveryAddress = $"{x.Request.DeliveryAddress.Street}, {x.Request.DeliveryAddress.City}, {x.Request.DeliveryAddress.County}",
                    Price = x.FinalPrice.ToString(),
                }).ToListAsync();
            var invoices = await invoicesQuery.OrderByDescending(x => x.InvoiceDate).Take(5)
                 .Select(x => new InvoiceForDashboardViewModel
                 {
                     Id = x.Id,
                     Date = DateTime.Now.ToString("dd-MM-yyyy"),
                     InvoiceNumber = x.InvoiceNumber,
                     Amount = x.Delivery.Offer.FinalPrice.ToString(),
                     CreationDate = x.InvoiceDate.ToString("dd-MM-yyyy"),
                     IsPaid = x.IsPaid
                 })
                .ToListAsync();

            var deliveries = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>().Where(x => x.Offer.Request.ClientCompanyId == company.Id).Take(5)
                .Select(x => new DeliveryTrackingForDashboardViewModel
                {
                    Id = x.Id,
                    ReferenceNumber = x.ReferenceNumber,
                    DeliveryStep = x.DeliveryStep,
                    PickupAddress = $"{x.Offer.Request.PickupAddress.Street}, {x.Offer.Request.PickupAddress.City}, {x.Offer.Request.PickupAddress.County}",
                    DeliveryAddress = $"{x.Offer.Request.DeliveryAddress.Street}, {x.Offer.Request.DeliveryAddress.City}, {x.Offer.Request.DeliveryAddress.County}",
                    StatusUpdate = x.Status,
                }).ToListAsync();
            return new ClientsDashboardViewModel
            {
                LastFivePendingOffers = offers,
                LastFiveDeliveries = deliveries,
                LastFiveInvoices = invoices,
                DueAmountForDeliveries = await invoicesQuery.Where(x => x.IsPaid == false).SumAsync(x => x.Delivery.Offer.Request.CalculatedPrice),
                RequestsCount = await requestsQuery.CountAsync(),
                RequestsLastMonthCount = await requestsQuery.Where(x => x.CreatedAt >= lastMonth).CountAsync(),
                BookedOffersCount = await offersQuery.Where(x => x.OfferStatus == StatusConstants.Approved).CountAsync(),
                BookedOffersLastMonthCount = await offersQuery.Where(x => x.OfferStatus == StatusConstants.Approved && x.OfferDate >= lastMonth).CountAsync(),
                InvoicesCount = await invoicesQuery.CountAsync(),
                InvoiceLastMonthCount = await invoicesQuery.Where(x => x.InvoiceDate >= lastMonth).CountAsync(),
            };
        }

        public async Task<DriverDashboardViewModel?> GetDriverDashboardAsync(string username)
        {
            var deliveryQuery = repository.AllReadonly<Delivery>().Include(x => x.Offer).ThenInclude(x => x.Request).Where(x => x.Driver.User.UserName == username);
            var model = new DriverDashboardViewModel()
            {
                KilometersDriven = await deliveryQuery.SumAsync(x => x.Offer.Request.Kilometers),
                KilometersDrivenlastMonth = await deliveryQuery.Where(x => x.Offer.Request.ExpectedDeliveryDate.Month == DateTime.Now.Month - 1).SumAsync(x => x.Offer.Request.Kilometers),
                NewDeliveriesCount = await deliveryQuery.CountAsync(x => x.DeliveryStep == 1)
            };
            model.LastDeliveries = await deliveryQuery.OrderByDescending(x => x.Offer.OfferDate).Take(5)
                .Select(x => new DeliveryForDriverDashboardViewModel
                {
                    Id = x.Id,
                    ClientCompanyName = x.Offer.Request.ClientCompany.Name,
                    PickupAddress = $"{x.Offer.Request.PickupAddress.Street}, {x.Offer.Request.PickupAddress.City}, {x.Offer.Request.PickupAddress.County}",
                    DeliveryAddress = $"{x.Offer.Request.DeliveryAddress.Street}, {x.Offer.Request.DeliveryAddress.City}, {x.Offer.Request.DeliveryAddress.County}",
                    ReferenceNumber = x.ReferenceNumber
                })
                .ToListAsync();
            model.NewDeliveries = await deliveryQuery.Where(x => x.DeliveryStep == 1)
                .Select(x => new DeliveryForDriverDashboardViewModel
                {
                    Id = x.Id,
                    ClientCompanyName = x.Offer.Request.ClientCompany.Name,
                    PickupAddress = $"{x.Offer.Request.PickupAddress.Street}, {x.Offer.Request.PickupAddress.City}, {x.Offer.Request.PickupAddress.County}",
                    DeliveryAddress = $"{x.Offer.Request.DeliveryAddress.Street}, {x.Offer.Request.DeliveryAddress.City}, {x.Offer.Request.DeliveryAddress.County}",
                    ReferenceNumber = x.ReferenceNumber
                }).ToListAsync();
            return model;
        }

        public async Task<LogisticsDashboardViewModel?> GetLogisticsCompanyDashboardAsync()
        {
            var deliveryQuery = repository.All<Delivery>().Include(x => x.Offer).ThenInclude(o => o.Request).Include(x => x.Vehicle).AsQueryable();
            var clientsQuery = repository.All<ClientCompany>().AsQueryable();
            var requestsQuery = repository.All<Request>().AsQueryable();

            var lastWeek = DateTime.Now.AddDays(-7);
            var model = new LogisticsDashboardViewModel
            {
                DeliveriesCount = await deliveryQuery.CountAsync(),
                DeliveriesLastWeekCount = await deliveryQuery.Where(x => x.Offer.Request.CreatedAt > lastWeek).CountAsync(),
                PendingRegistrationsCount = await clientsQuery.Where(x => x.RegistrationStatus == StatusConstants.Pending).CountAsync(),
                RequestsCount = await requestsQuery.CountAsync(),
                RequestsLastWeekCount = await requestsQuery.Where(x => x.CreatedAt > lastWeek).CountAsync(),
            };
            model.DeliveresWithVehicles = await deliveryQuery.Include(x => x.Vehicle).Take(5)
                .Select(x => new DeliveryWithVehicleViewModel
                {
                    Id = x.Id,
                    ReferenceNumber = x.ReferenceNumber,
                    DeliveryAddress = $" {x.Offer.Request.DeliveryAddress.City}, {x.Offer.Request.DeliveryAddress.County}",
                    PickupAddress = $" {x.Offer.Request.PickupAddress.City}, {x.Offer.Request.PickupAddress.County}",
                    VehicleRegistrationNumber = x.Vehicle.RegistrationNumber,
                    DeliveryStep = x.DeliveryStep,
                }).ToListAsync();
            model.Last5BookedOffers = await repository.AllReadonly<Offer>().Include(x => x.Request).Take(5)
                .Select(x => new OfferForDashboardViewModel
                {
                    Id = x.Id,
                    ReferenceNumber = x.OfferNumber,
                    PickupAddress = $"{x.Request.PickupAddress.City}, {x.Request.PickupAddress.County}",
                    DeliveryAddress = $" {x.Request.DeliveryAddress.City}, {x.Request.DeliveryAddress.County}",
                    Price = x.FinalPrice.ToString(),
                    ClientName = x.Request.ClientCompany.Name,
                }).ToListAsync();
            return model;
        }

        public async Task<SpeditorDashboardViewModel?> GetSpeditorDashboardAsync()
        {
            var requestsQuery = repository.AllReadonly<Request>();
            var offersQuery = repository.AllReadonly<Offer>();
            var model = new SpeditorDashboardViewModel
            {
                TotalRequests = await requestsQuery.CountAsync(),
                TotalOffers = await offersQuery.CountAsync(),
                NewRequests = await requestsQuery.CountAsync(x => x.CreatedAt.Date <= DateTime.Now.Date.AddDays(-30)),
                AcceptedOffers = await offersQuery.CountAsync(x => x.OfferStatus == StatusConstants.Approved),
                AvailableDrivers = await repository.AllReadonly<Driver>().CountAsync(x => x.IsAvailable),
                AvailableVehicles = await repository.AllReadonly<Vehicle>().CountAsync(x => x.IsAvailable),
                FuelPrice = await repository.AllReadonly<FuelPrice>().OrderByDescending(x => x.Date).Select(x => x.Price).FirstOrDefaultAsync(),
            };
            model.LastFivePendingOffers = await offersQuery.OrderByDescending(x => x.OfferDate).Where(x => x.OfferStatus == StatusConstants.Pending).Take(5)
               .Select(x => new OfferForDashboardViewModel
               {
                   Id = x.Id,
                   ReferenceNumber = x.OfferNumber,
                   PickupAddress = $"{x.Request.PickupAddress.Street}, {x.Request.PickupAddress.City}, {x.Request.PickupAddress.County}",
                   DeliveryAddress = $"{x.Request.DeliveryAddress.Street}, {x.Request.DeliveryAddress.City}, {x.Request.DeliveryAddress.County}",
                   Price = x.FinalPrice.ToString(),
               }).ToListAsync();

            model.LastFiveDeliveries = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>().OrderByDescending(x => x.SuggestedDate).Take(5)
                .Select(x => new DeliveryTrackingForDashboardViewModel
                {
                    Id = x.Id,
                    ReferenceNumber = x.ReferenceNumber,
                    DeliveryStep = x.DeliveryStep,
                    PickupAddress = $"{x.Offer.Request.PickupAddress.Street}, {x.Offer.Request.PickupAddress.City}, {x.Offer.Request.PickupAddress.County}",
                    DeliveryAddress = $"{x.Offer.Request.DeliveryAddress.Street}, {x.Offer.Request.DeliveryAddress.City}, {x.Offer.Request.DeliveryAddress.County}",
                    StatusUpdate = x.Status,
                }).ToListAsync();

            model.LastFiveNewRequests = await requestsQuery.OrderByDescending(x => x.CreatedAt).Take(5)
                .Select(x => new RequestsForSearchViewModel
                {
                    Id = x.Id,
                    ReferenceNumber = x.RerefenceNumber,
                    PickupAddress = $"{x.PickupAddress.Street}, {x.PickupAddress.City}, {x.PickupAddress.County}",
                    DeliveryAddress = $"{x.DeliveryAddress.Street}, {x.DeliveryAddress.City}, {x.DeliveryAddress.County}",
                    NumberOfItems = ((x.StandartCargo != null ? x.StandartCargo.NumberOfPallets : 0) + (x.NumberOfNonStandartGoods ?? 0)).ToString(),
                    ExpectedDeliveryDate = x.ExpectedDeliveryDate.ToString(),
                    CompanyName = x.ClientCompany.Name,
                    Price = x.ApproximatePrice.ToString(),
                }).ToListAsync();
            return model;
        }       
    }
}

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
            var model = new AccountantDashboardViewModel()
            {
                NewFinishedDeliveriesFromLastWeek = await repository.All<Delivery>().CountAsync(x => x.Status == DeliveryStatusConstants.Delivered && x.ActualDeliveryDate > DateTime.Now.AddDays(-7)),
                NotPaidDeliveriesCount = await repository.All<Invoice>().CountAsync(x => x.Delivery.Status == DeliveryStatusConstants.Delivered && x.IsPaid == false),
                InvoicesCount = await repository.All<Invoice>().CountAsync(),
                InvoicesCountFromLastMonth = await repository.All<Invoice>().Where(x => x.InvoiceDate > DateTime.Now.AddDays(-31)).CountAsync(),
                DueAmountForDeliveries = repository.AllReadonly<Invoice>().Where(x => x.IsPaid == false).Sum(x => x.Delivery.Offer.FinalPrice).ToString()
            };
            model.Last5NotPaidInvoices = await repository.All<Invoice>().Where(x => x.IsPaid == false).OrderByDescending(x => x.InvoiceDate).Take(5)
                .Select(x => new InvoiceForDashboardViewModel
                {
                    Id = x.Id,
                    CreationDate = x.InvoiceDate.ToString("dd-MM-yyyy"),
                    Date = DateTime.Now.ToString("dd-MM-yyyy"),
                    InvoiceNumber = x.InvoiceNumber,
                    Amount = x.Delivery.Offer.FinalPrice.ToString(),
                }).ToListAsync();
            model.Last5NewDeliveries = await repository.All<Delivery>().Where(x => x.DeliveryStep == 4).OrderByDescending(x => x.ActualDeliveryDate).Take(5)
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
            var company = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.ClientCompany>().FirstOrDefaultAsync(x => x.User.UserName == username);
            var offers = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Offer>().OrderByDescending(x => x.OfferDate).Where(x => x.Request.ClientCompanyId == company.Id && x.OfferStatus == StatusConstants.Pending).Take(5)
                .Select(x => new OfferForDashboardViewModel
                {
                    Id = x.Id,
                    ReferenceNumber = x.OfferNumber,
                    PickupAddress = $"{x.Request.PickupAddress.Street}, {x.Request.PickupAddress.City}, {x.Request.PickupAddress.County}",
                    DeliveryAddress = $"{x.Request.DeliveryAddress.Street}, {x.Request.DeliveryAddress.City}, {x.Request.DeliveryAddress.County}",
                    Price = x.FinalPrice.ToString(),
                }).ToListAsync();
            var invoices = await repository.AllReadonly<Invoice>().OrderByDescending(x => x.InvoiceDate).Where(x => x.Delivery.Offer.Request.ClientCompanyId == company.Id).Take(5)
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
                DueAmountForDeliveries = await repository.AllReadonly<Invoice>().Where(x => x.Delivery.Offer.Request.ClientCompanyId == company.Id && x.IsPaid == false).SumAsync(x => x.Delivery.Offer.Request.CalculatedPrice),
                RequestsCount = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Request>().Where(x => x.ClientCompanyId == company.Id).CountAsync(),
                RequestsLastMonthCount = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Request>().Where(x => x.ClientCompanyId == company.Id && x.CreatedAt.Month >= DateTime.Now.Month - 1 && x.CreatedAt.Month <= DateTime.Now.Month).CountAsync(),
                BookedOffersCount = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Offer>().Where(x => x.Request.ClientCompanyId == company.Id && x.OfferStatus == StatusConstants.Approved).CountAsync(),
                BookedOffersLastMonthCount = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Offer>().Where(x => x.Request.ClientCompanyId == company.Id && x.OfferStatus == StatusConstants.Approved && x.OfferDate.Month >= DateTime.Now.Month - 1 && x.OfferDate.Month <= DateTime.Now.Month).CountAsync(),
                InvoicesCount = await repository.AllReadonly<Invoice>().Where(x => x.Delivery.Offer.Request.ClientCompanyId == company.Id).CountAsync(),
                InvoiceLastMonthCount = await repository.AllReadonly<Invoice>().Where(x => x.Delivery.Offer.Request.ClientCompanyId == company.Id && x.InvoiceDate.Month >= DateTime.Now.Month - 1 && x.InvoiceDate.Month <= DateTime.Now.Month).CountAsync(),
            };
        }

        public async Task<DriverDashboardViewModel?> GetDriverDashboardAsync(string username)
        {
            var driver = await repository.AllReadonly<Infrastructure.Data.DataModels.Driver>().Where(x => x.User.UserName == username).FirstOrDefaultAsync();
            var model = new DriverDashboardViewModel()
            {
                KilometersDriven = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>().Where(x => x.DriverId == driver.Id).SumAsync(x => x.Offer.Request.Kilometers),
                KilometersDrivenlastMonth = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>().Where(x => x.DriverId == driver.Id && x.Offer.Request.ExpectedDeliveryDate.Month == DateTime.Now.Month - 1).SumAsync(x => x.Offer.Request.Kilometers),
                NewDeliveriesCount = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>().Where(x => x.DeliveryStep == 1).CountAsync()
            };
            model.LastDeliveries = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>().Where(x => x.DriverId == driver.Id).OrderByDescending(x => x.Offer.OfferDate).Take(5)
                .Select(x => new DeliveryForDriverDashboardViewModel
                {
                    Id = x.Id,
                    ClientCompanyName = x.Offer.Request.ClientCompany.Name,
                    PickupAddress = $"{x.Offer.Request.PickupAddress.Street}, {x.Offer.Request.PickupAddress.City}, {x.Offer.Request.PickupAddress.County}",
                    DeliveryAddress = $"{x.Offer.Request.DeliveryAddress.Street}, {x.Offer.Request.DeliveryAddress.City}, {x.Offer.Request.DeliveryAddress.County}",
                    ReferenceNumber = x.ReferenceNumber
                })
                .ToListAsync();
            model.NewDeliveries = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>().Where(x => x.DriverId == driver.Id && x.DeliveryStep == 1)
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
            var model = new LogisticsDashboardViewModel
            {
                DeliveriesCount = await repository.AllReadonly<Delivery>().CountAsync(),
                DeliveriesLastWeekCount = await repository.AllReadonly<Delivery>().Where(x => x.Offer.Request.CreatedAt.Day == DateTime.Now.Day - 7).CountAsync(),
                PendingRegistrationsCount = await repository.AllReadonly<ClientCompany>().Where(x => x.RegistrationStatus == StatusConstants.Pending).CountAsync(),
                RequestsCount = await repository.AllReadonly<Request>().CountAsync(),
                RequestsLastWeekCount = await repository.AllReadonly<Request>().Where(x => x.CreatedAt.Day == DateTime.Now.Day - 7).CountAsync(),
            };
            model.DeliveresWithVehicles = await repository.AllReadonly<Delivery>().Include(x => x.Vehicle).Take(5)
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
            var request = await repository.AllReadonly<Request>().ToListAsync();
            var offers = await repository.AllReadonly<Offer>().ToListAsync();
            var model = new SpeditorDashboardViewModel
            {
                TotalRequests = request.Count(),
                TotalOffers = offers.Count(),
                NewRequests = request.Count(x => x.CreatedAt.Date <= DateTime.Now.Date.AddDays(-30)),
                AcceptedOffers = offers.Count(x => x.OfferStatus == StatusConstants.Approved),
                AvailableDrivers = await repository.AllReadonly<Driver>().CountAsync(x => x.IsAvailable),
                AvailableVehicles = await repository.AllReadonly<Vehicle>().CountAsync(x => x.IsAvailable),
                FuelPrice = await repository.AllReadonly<FuelPrice>().OrderByDescending(x => x.Date).Select(x => x.Price).FirstOrDefaultAsync(),
            };
            model.LastFivePendingOffers = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Offer>().OrderByDescending(x => x.OfferDate).Where(x => x.OfferStatus == StatusConstants.Pending).Take(5)
               .Select(x => new OfferForDashboardViewModel
               {
                   Id = x.Id,
                   ReferenceNumber = x.OfferNumber,
                   PickupAddress = $"{x.Request.PickupAddress.Street}, {x.Request.PickupAddress.City}, {x.Request.PickupAddress.County}",
                   DeliveryAddress = $"{x.Request.DeliveryAddress.Street}, {x.Request.DeliveryAddress.City}, {x.Request.DeliveryAddress.County}",
                   Price = x.FinalPrice.ToString(),
               }).ToListAsync();

            model.LastFiveDeliveries = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>().OrderByDescending(x => x.Offer.StartDate).Take(5)
                .Select(x => new DeliveryTrackingForDashboardViewModel
                {
                    Id = x.Id,
                    ReferenceNumber = x.ReferenceNumber,
                    DeliveryStep = x.DeliveryStep,
                    PickupAddress = $"{x.Offer.Request.PickupAddress.Street}, {x.Offer.Request.PickupAddress.City}, {x.Offer.Request.PickupAddress.County}",
                    DeliveryAddress = $"{x.Offer.Request.DeliveryAddress.Street}, {x.Offer.Request.DeliveryAddress.City}, {x.Offer.Request.DeliveryAddress.County}",
                    StatusUpdate = x.Status,
                }).ToListAsync();

            model.LastFiveNewRequests = await repository.AllReadonly<Request>().OrderByDescending(x => x.CreatedAt).Take(5)
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

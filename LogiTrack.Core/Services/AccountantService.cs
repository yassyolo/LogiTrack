using LogisticsSystem.Infrastructure.Data.DataModels;
using LogiTrack.Core.Constants;
using LogiTrack.Core.Contracts;
using LogiTrack.Core.CustomExceptions;
using LogiTrack.Core.ViewModels.Accountant;
using LogiTrack.Core.ViewModels.Clients;
using LogiTrack.Infrastructure.Data.DataModels;
using LogiTrack.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using static LogiTrack.Core.Constants.MessageConstants.ErrorMessages;

namespace LogiTrack.Core.Services
{
    public class AccountantService : IAccountantService
    {
        private readonly IRepository repository;

        public AccountantService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<AccountantDashboardViewModel?> GetAccountantIndexAsync()
        {
            var model =  new AccountantDashboardViewModel()
            {
                NewFinishedDeliveries = await repository.All<Delivery>().CountAsync(x => x.Status == DeliveryStatusConstants.Delivered),
                NotPaidDeliveries = await repository.All<Invoice>().CountAsync(x => x.Offer.Delivery.Status == DeliveryStatusConstants.Delivered && x.IsPaid == false),
                InvoicesCnt = await repository.All<Invoice>().CountAsync(),
                DueAmountForDeliveries = repository.AllReadonly<Invoice>().Where(x => x.IsPaid == false).Sum(x => x.Offer.FinalPrice).ToString()
            };
            var deliveryTrackingIds = await repository.AllReadonly<DeliveryTracking>().Where(x => x.StatusUpdate == DeliveryTrackingStatusConstants.Delivered).OrderByDescending(x => x.Timestamp).Select(x => x.Id).ToListAsync();
            model.Last5NotPaidInvoices = await repository.All<Invoice>().Where(x => x.IsPaid == false).OrderByDescending(x => x.InvoiceDate).Take(5)
                .Select(x => new InvoiceIndexViewModel
                {
                    Id = x.Id,
                    CreationDate = x.InvoiceDate.ToString("dd/MM/yyyy"),
                    Date = DateTime.Now.ToString("dd/MM/yyyy"),
                    Number = x.InvoiceNumber,
                    Amount = x.Offer.FinalPrice.ToString(),
                }).ToListAsync();
            model.Last5NewDeliveries = await repository.All<Delivery>().Where(x => deliveryTrackingIds.Contains(x.Id)).OrderByDescending(x => x.Offer.OfferDate).Take(5)
                .Select(x => new DeliveryForAccountantViewModel
                {
                    Id = x.Id,
                    ReferenceNumber = x.ReferenceNumber,
                    ClientCompanyName = x.Offer.Request.ClientCompany.Name,
                    DeliveryAddress = x.Offer.Request.DeliveryAddress,
                    PickupAddress  = x.Offer.Request.PickupAddress,
                }).ToListAsync();
           
            return model;
        }
    }
}

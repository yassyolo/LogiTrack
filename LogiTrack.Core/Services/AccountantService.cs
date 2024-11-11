using LogisticsSystem.Infrastructure.Data.DataModels;
using LogiTrack.Core.Constants;
using LogiTrack.Core.Contracts;
using LogiTrack.Core.CustomExceptions;
using LogiTrack.Core.ViewModels.Accountant;
using LogiTrack.Core.ViewModels.Clients;
using LogiTrack.Infrastructure.Data.DataModels;
using LogiTrack.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static LogiTrack.Core.Constants.MessageConstants.ErrorMessages;
using LogiTrack.Core.ViewModels.Invoice;
using LogiTrack.Core.ViewModels.Delivery;

namespace LogiTrack.Core.Services
{
    public class AccountantService : IAccountantService
    {
        private readonly IRepository repository;

        public AccountantService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<AccountantDashboardViewModel?> GetAccountantDashboardAsync()
        {
            var model =  new AccountantDashboardViewModel()
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
                    DeliveryAddress = $"{x.Offer.Request.DeliveryAddress.Street},{x.Offer.Request.DeliveryAddress.City}, {x.Offer.Request.DeliveryAddress.County} ",
                    PickupAddress  = $"{x.Offer.Request.PickupAddress.Street},{x.Offer.Request.PickupAddress.City}, {x.Offer.Request.PickupAddress.County} "
                }).ToListAsync();
           
            return model;
        }

    }
}

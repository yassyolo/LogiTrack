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
                    DeliveryAddress = x.Offer.Request.DeliveryAddress,
                    PickupAddress  = x.Offer.Request.PickupAddress,
                }).ToListAsync();
           
            return model;
        }

        public async Task<MarkAsPaidInvoiceViewModel?> GetInvoiceForPaymentAsync(int deliveryId)
        {
            var model = await repository.All<Invoice>().Include(x => x.Delivery).ThenInclude(x => x.Offer)
                .ThenInclude(x => x.Request).ThenInclude(x => x.ClientCompany).Where(x => x.DeliveryId == deliveryId )
                .Select(x => new MarkAsPaidInvoiceViewModel
                {
                    InvoiceId = x.Id,
                    DeliveryId = x.Delivery.Id,
                    InvoiceNumber = x.InvoiceNumber,
                    Amount = x.Delivery.Offer.FinalPrice.ToString(),
                    ClientName = x.Delivery.Offer.Request.ClientCompany.Name,
                    ClientRegistrationNumber = x.Delivery.Offer.Request.ClientCompany.RegistrationNumber,
                    InvoiceDate = x.InvoiceDate.ToString("dd-MM-yyyy"),
                    Today = DateTime.Now.ToString("dd-MM-yyyy"),
                }).FirstOrDefaultAsync();
            return model;
        }

        public async Task<bool> InvoiceWithIdExistsAsync(int invoiceId)
        {
            return await repository.AllReadonly<Invoice>().AnyAsync(x => x.Id == invoiceId);
        }

        public async Task<int> MarkInvoiceAsPaidAsync(int id)
        {
            var invoice = await repository.All<Invoice>().Include(x => x.Delivery).ThenInclude(x => x.Offer)
                .ThenInclude(x => x.Request).ThenInclude(x => x.ClientCompany).FirstOrDefaultAsync(x => x.Id == id);
            if (invoice == null)
            {
                throw new ArgumentException(InvoiceNotFoundErrorMessage);
            }
            invoice.IsPaid = true;
            await repository.SaveChangesAsync();
            var calendarEvent = new CalendarEvent
            {
                EventType = EventTypesConstants.InvoicePaid,
                Date = DateTime.Now,
                Title = $"Delivery {invoice.Delivery.ReferenceNumber} paid",
                ClientCompanyId = invoice.Delivery.Offer.Request.ClientCompany.Id
            };
            await repository.AddAsync(calendarEvent);
            await repository.SaveChangesAsync();
            return invoice.DeliveryId;
        }

    }
}

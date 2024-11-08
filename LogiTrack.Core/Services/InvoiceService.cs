using LogisticsSystem.Infrastructure.Data.DataModels;
using LogiTrack.Core.Constants;
using LogiTrack.Core.Contracts;
using LogiTrack.Core.ViewModels.Accountant;
using static LogiTrack.Core.Constants.MessageConstants.ErrorMessages;
using LogiTrack.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using LogiTrack.Infrastructure.Data.DataModels;

namespace LogiTrack.Core.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IRepository repository;

        public InvoiceService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<MarkAsPaidInvoiceViewModel?> GetInvoiceForPaymentAsync(int deliveryId)
        {
            var model = await repository.All<Invoice>().Include(x => x.Delivery).ThenInclude(x => x.Offer)
                .ThenInclude(x => x.Request).ThenInclude(x => x.ClientCompany).Where(x => x.DeliveryId == deliveryId)
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

        public async Task<List<ViewModels.Accountant.InvoiceForDeliveryViewModel>> GetInvoicesAsync(string? deliveryReferenceNumber = null, DateTime? startDate = null, DateTime? endDate = null, string? companyName = null, bool? isPaid = null)
        {
            var invoices = await repository.All<Invoice>().Include(x => x.Delivery).ThenInclude(x => x.Offer)
                .ThenInclude(x => x.Request).ThenInclude(x => x.ClientCompany).ToListAsync();
            if (string.IsNullOrEmpty(deliveryReferenceNumber) == false)
            {
                invoices = invoices.Where(x => x.Delivery.ReferenceNumber == deliveryReferenceNumber).ToList();
            }
            if (startDate != null)
            {
                invoices = invoices.Where(x => x.InvoiceDate >= startDate).ToList();
            }
            if (endDate != null)
            {
                invoices = invoices.Where(x => x.InvoiceDate <= endDate).ToList();
            }
            if (string.IsNullOrEmpty(companyName) == false)
            {
                invoices = invoices.Where(x => x.Delivery.Offer.Request.ClientCompany.Name == companyName).ToList();
            }

            if (isPaid != null)
            {
                invoices = invoices.Where(x => x.IsPaid == isPaid).ToList();
            }
            //TODO: add files
            return invoices.Select(x => new ViewModels.Accountant.InvoiceForDeliveryViewModel
            {
                DeliveryId = x.DeliveryId,
                Number = x.InvoiceNumber,
                Date = x.InvoiceDate.ToString("dd-MM-yyyy"),
                IsPaid = x.IsPaid,
                Amount = x.Delivery.Offer.FinalPrice.ToString(),
                Description = x.Description,
            }).ToList();
        }

        public async Task<List<InvoiceForDeliveryViewModel>> GetInvoicesForCompanyAsync(string username, string? deliveryReferenceNumber, DateTime? startDate, DateTime? endDate, decimal? minPrice, decimal? maxPrice, bool isPaid)
        {
            var invoices = await repository.All<Invoice>().Include(x => x.Delivery).ThenInclude(x => x.Offer)
                .ThenInclude(x => x.Request).ThenInclude(x => x.ClientCompany).Where(x => x.Delivery.Offer.Request.ClientCompany.User.UserName == username).ToListAsync();
            if (string.IsNullOrEmpty(deliveryReferenceNumber) == false)
            {
                invoices = invoices.Where(x => x.Delivery.ReferenceNumber == deliveryReferenceNumber).ToList();
            }
            if (startDate != null)
            {
                invoices = invoices.Where(x => x.InvoiceDate >= startDate).ToList();
            }
            if (endDate != null)
            {
                invoices = invoices.Where(x => x.InvoiceDate <= endDate).ToList();
            }
            if (minPrice != null)
            {
                invoices = invoices.Where(x => x.Delivery.Offer.FinalPrice < minPrice).ToList();
            }
            if (maxPrice != null)
            {
                invoices = invoices.Where(x => x.Delivery.Offer.FinalPrice > maxPrice).ToList();
            }

            if (isPaid != null)
            {
                invoices = invoices.Where(x => x.IsPaid == isPaid).ToList();
            }
            //TODO: add files
            return invoices.Select(x => new ViewModels.Accountant.InvoiceForDeliveryViewModel
            {
                DeliveryId = x.DeliveryId,
                Number = x.InvoiceNumber,
                Date = x.InvoiceDate.ToString("dd-MM-yyyy"),
                IsPaid = x.IsPaid,
                Amount = x.Delivery.Offer.FinalPrice.ToString(),
                Description = x.Description,
            }).ToList();
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

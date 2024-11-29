using LogisticsSystem.Infrastructure.Data.DataModels;
using LogiTrack.Core.Constants;
using LogiTrack.Core.Contracts;
using static LogiTrack.Core.Constants.MessageConstants.ErrorMessages;
using LogiTrack.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using LogiTrack.Infrastructure.Data.DataModels;
using LogiTrack.Core.ViewModels.Invoice;
using Microsoft.AspNetCore.Identity;

namespace LogiTrack.Core.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IRepository repository;
        private readonly IGoogleDriveService googleDriveService;

        public InvoiceService(IRepository repository, IGoogleDriveService googleDriveService)
        {
            this.repository = repository;
            this.googleDriveService = googleDriveService;
        }

        public async Task<MarkAsPaidInvoiceViewModel?> GetInvoiceForPaymentAsync(int deliveryId)
        {
            var model = await repository.All<Invoice>().Include(x => x.Delivery).ThenInclude(x => x.Offer)
                .ThenInclude(x => x.Request).ThenInclude(x => x.ClientCompany).Where(x => x.DeliveryId == deliveryId)
                .Select(x => new MarkAsPaidInvoiceViewModel
                {
                    InvoiceId = x.Id,
                    DeliveryId = x.Delivery.Id,
                    DeliveryReferenceNumber = x.Delivery.ReferenceNumber,
                    InvoiceNumber = x.InvoiceNumber,
                    Amount = x.Delivery.Offer.FinalPrice.ToString(),
                    ClientName = x.Delivery.Offer.Request.ClientCompany.Name,
                    ClientRegistrationNumber = x.Delivery.Offer.Request.ClientCompany.RegistrationNumber,
                    InvoiceDate = x.InvoiceDate.ToString("dd-MM-yyyy"),
                    Today = DateTime.Now.ToString("dd-MM-yyyy"),
                }).FirstOrDefaultAsync();
            return model;
        }

        public async Task<List<InvoiceForDeliveryViewModel>> GetInvoicesAsync(string? deliveryReferenceNumber = null, DateTime? startDate = null, DateTime? endDate = null, string? companyName = null, bool? isPaid = null, decimal? minAmount = null, decimal? maxAmount = null)
        {
            var invoices = await repository.All<Invoice>().Include(x => x.Delivery).ThenInclude(x => x.Offer)
                .ThenInclude(x => x.Request).ThenInclude(x => x.ClientCompany).ToListAsync();
            if (string.IsNullOrEmpty(deliveryReferenceNumber) == false)
            {
                invoices = invoices.Where(x => x.Delivery.ReferenceNumber == deliveryReferenceNumber).ToList();
            }
            if(minAmount != null)
            {
                invoices = invoices.Where(x => x.Delivery.Offer.FinalPrice >= minAmount).ToList();
            }
            if (maxAmount != null)
            {
                invoices = invoices.Where(x => x.Delivery.Offer.FinalPrice <= maxAmount).ToList();
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
            var invoicesToShow =  invoices.Select(x => new InvoiceForDeliveryViewModel
            {
                DeliveryId = x.DeliveryId,
                PaymentDate = x.PaidDate.HasValue ? x.PaidDate.Value.ToString("dd-MM-yyyy") : string.Empty,
                Number = x.InvoiceNumber,
                Date = x.InvoiceDate.ToString("dd-MM-yyyy"),
                IsPaid = x.IsPaid,
                Amount = x.Delivery.Offer.FinalPrice.ToString(),
                Description = x.Description,
                FileId = x.FileId
            }).ToList();
            foreach (var invoice in invoicesToShow)
            {
                invoice.FileUrl = await googleDriveService.GetFileUrlAsync(invoice.FileId);
            }
            return invoicesToShow;  
        }

        public async Task<List<InvoiceForDeliveryViewModel>> GetInvoicesForCompanyAsync(string username, string? deliveryReferenceNumber = null, DateTime? startDate = null, DateTime? endDate = null, decimal? minPrice = null, decimal? maxPrice = null, bool? isPaid = null)     
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
            var invoicesToShow = invoices.Select(x => new InvoiceForDeliveryViewModel
            {
                DeliveryId = x.DeliveryId,
                PaymentDate = x.PaidDate.HasValue ? x.PaidDate.Value.ToString("dd-MM-yyyy") : string.Empty,
                Number = x.InvoiceNumber,
                Date = x.InvoiceDate.ToString("dd-MM-yyyy"),
                IsPaid = x.IsPaid,
                Amount = x.Delivery.Offer.FinalPrice.ToString(),
                Description = x.Description,
                FileId = x.FileId,
                Status = x.Status
            }).ToList();
            foreach (var invoice in invoicesToShow)
            {
                invoice.FileUrl = await googleDriveService.GetFileUrlAsync(invoice.FileId);
            }
            return invoicesToShow;
        }

        public async Task<bool> InvoiceWithIdExistsAsync(int invoiceId)
        {
            return await repository.AllReadonly<Invoice>().AnyAsync(x => x.Id == invoiceId);
        }

        public async Task<int> MarkInvoiceAsPaidAsync(int id)
        {
            var invoice = await repository.All<Invoice>().Include(x => x.Delivery).ThenInclude(x => x.Offer)
                .ThenInclude(x => x.Request).ThenInclude(x => x.ClientCompany).FirstOrDefaultAsync(x => x.Id == id);

            invoice.IsPaid = true;
            if(DateTime.Now > invoice.Delivery.ActualDeliveryDate.Value.AddDays(-30))
            {
                invoice.PaidOnTime = false;
            }
            else
            {
                invoice.PaidOnTime = true;
            }
            
            await repository.SaveChangesAsync();
            var calendarEvent = new CalendarEvent
            {
                EventType = EventTypesConstants.InvoicePaid,
                Date = DateTime.Now,
                Title = $"Delivery {invoice.Delivery.ReferenceNumber} paid",
                UserId = invoice.Delivery.Offer.Request.ClientCompany.User.Id
            };
            var logisticsUser = await repository.AllReadonly<IdentityUser>().FirstOrDefaultAsync(x => x.UserName == "logistics");
            var calendarEventForLogistics = new CalendarEvent
            {
                EventType = EventTypesConstants.InvoicePaid,
                Date = DateTime.Now,
                Title = $"Delivery {invoice.Delivery.ReferenceNumber} paid",
                UserId = logisticsUser.Id
            };  
            await repository.AddAsync(calendarEventForLogistics);
            await repository.AddAsync(calendarEvent);
            await repository.SaveChangesAsync();
            return invoice.DeliveryId;
        }      
    }
}

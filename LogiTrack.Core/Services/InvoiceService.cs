using LogisticsSystem.Infrastructure.Data.DataModels;
using LogiTrack.Core.Constants;
using LogiTrack.Core.Contracts;
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
            var model = await repository.AllReadonly<Invoice>().Where(x => x.DeliveryId == deliveryId)
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
                }).SingleOrDefaultAsync();
            return model;
        }

        public async Task<List<InvoiceForDeliveryViewModel>> GetInvoicesAsync(string? deliveryReferenceNumber = null, DateTime? startDate = null, DateTime? endDate = null, string? companyName = null, bool? isPaid = null, decimal? minAmount = null, decimal? maxAmount = null)
        {
            var query = repository.AllReadonly<Invoice>().Include(x => x.Delivery).ThenInclude(x => x.Offer)
                .ThenInclude(x => x.Request).ThenInclude(x => x.ClientCompany).AsQueryable();
            if (string.IsNullOrEmpty(deliveryReferenceNumber) == false)
            {
                query = query.Where(x => x.Delivery.ReferenceNumber == deliveryReferenceNumber);
            }
            if(minAmount != null)
            {
                query = query.Where(x => x.Delivery.Offer.FinalPrice >= minAmount);
            }
            if (maxAmount != null)
            {
                query = query.Where(x => x.Delivery.Offer.FinalPrice <= maxAmount);
            }
            if (startDate != null)
            {
                query = query.Where(x => x.InvoiceDate >= startDate);
            }
            if (endDate != null)
            {
                query = query.Where(x => x.InvoiceDate <= endDate);
            }
            if (string.IsNullOrEmpty(companyName) == false)
            {
                query = query.Where(x => x.Delivery.Offer.Request.ClientCompany.Name == companyName);
            }
            if (isPaid != null)
            {
                query = query.Where(x => x.IsPaid == isPaid);
            }

            var invoices = await query.ToListAsync();

            var fileIds = invoices.Select(x => x.FileId).Distinct().ToList();
            var fileUrlTasks = fileIds.Select(x => googleDriveService.GetFileUrlAsync(x)).ToArray();
            var fileUrls = await Task.WhenAll(fileUrlTasks);

            var invoicesToShow =  invoices.Select((x, index) => new InvoiceForDeliveryViewModel
            {
                DeliveryId = x.DeliveryId,
                PaymentDate = x.PaidDate.HasValue ? x.PaidDate.Value.ToString("dd-MM-yyyy") : string.Empty,
                Number = x.InvoiceNumber,
                Date = x.InvoiceDate.ToString("dd-MM-yyyy"),
                IsPaid = x.IsPaid,
                Amount = x.Delivery.Offer.FinalPrice.ToString(),
                Description = x.Description,
                FileId = x.FileId,
                FileUrl = fileUrls.ElementAtOrDefault(index)
            }).ToList();

            return invoicesToShow;  
        }

        public async Task<List<InvoiceForDeliveryViewModel>> GetInvoicesForCompanyAsync(string username, string? deliveryReferenceNumber = null, DateTime? startDate = null, DateTime? endDate = null, decimal? minPrice = null, decimal? maxPrice = null, bool? isPaid = null)     
        {
            var query = repository.AllReadonly<Invoice>().Include(x => x.Delivery).ThenInclude(x => x.Offer)
                .ThenInclude(x => x.Request).ThenInclude(x => x.ClientCompany).Where(x => x.Delivery.Offer.Request.ClientCompany.User.UserName == username).AsQueryable();
            if (string.IsNullOrEmpty(deliveryReferenceNumber) == false)
            {
                query = query.Where(x => x.Delivery.ReferenceNumber == deliveryReferenceNumber);
            }
            if (startDate != null)
            {
                query = query.Where(x => x.InvoiceDate >= startDate);
            }
            if (endDate != null)
            {
                query = query.Where(x => x.InvoiceDate <= endDate);
            }
            if (minPrice != null)
            {
                query = query.Where(x => x.Delivery.Offer.FinalPrice < minPrice);
            }
            if (maxPrice != null)
            {
                query = query.Where(x => x.Delivery.Offer.FinalPrice > maxPrice);
            }

            if (isPaid != null)
            {
                query = query.Where(x => x.IsPaid == isPaid);
            }

            var invoices = await query.ToListAsync();

            var fileIds = invoices.Select(x => x.FileId).Distinct().ToList();
            var fileUrlTasks = fileIds.Select(x => googleDriveService.GetFileUrlAsync(x)).ToList();
            var fileUrls = await Task.WhenAll(fileUrlTasks);
            var invoicesToShow = invoices.Select((x, index) => new InvoiceForDeliveryViewModel
            {
                DeliveryId = x.DeliveryId,
                PaymentDate = x.PaidDate.HasValue ? x.PaidDate.Value.ToString("dd-MM-yyyy") : string.Empty,
                Number = x.InvoiceNumber,
                Date = x.InvoiceDate.ToString("dd-MM-yyyy"),
                IsPaid = x.IsPaid,
                Amount = x.Delivery.Offer.FinalPrice.ToString(),
                Description = x.Description,
                FileId = x.FileId,
                Status = x.Status,
                FileUrl = fileUrls.ElementAtOrDefault(index)
            }).ToList();

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
            invoice.PaidOnTime = DateTime.Now <= invoice.Delivery.ActualDeliveryDate.Value.AddDays(30);
            
            var calendarEvent = new CalendarEvent
            {
                EventType = EventTypesConstants.InvoicePaid,
                Date = DateTime.Now,
                Title = $"Delivery {invoice.Delivery.ReferenceNumber} paid!",
                UserId = invoice.Delivery.Offer.Request.ClientCompany.User.Id
            };

            var logisticsUser = await repository.AllReadonly<IdentityUser>().FirstOrDefaultAsync(x => x.UserName == "logistics");
            if (logisticsUser != null)
            {
                var calendarEventForLogistics = new CalendarEvent
                {
                    EventType = EventTypesConstants.InvoicePaid,
                    Date = DateTime.Now,
                    Title = $"Delivery {invoice.InvoiceNumber} paid!",
                    UserId = logisticsUser.Id
                };

                var logisticsNotification = new Notification
                {
                    Message = $"Delivery {invoice.InvoiceNumber} paid!",
                    Title = "Invoice paid",
                    Date = DateTime.Now,
                    UserId = logisticsUser.Id
                };

                await repository.AddAsync(calendarEventForLogistics);
                await repository.AddAsync(logisticsNotification);
            }
            await repository.AddAsync(calendarEvent);

            await repository.SaveChangesAsync();
            return invoice.DeliveryId;
        }      
    }
}

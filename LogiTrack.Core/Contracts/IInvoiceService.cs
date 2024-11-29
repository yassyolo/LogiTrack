using LogiTrack.Core.ViewModels.Invoice;

namespace LogiTrack.Core.Contracts
{
    public interface IInvoiceService
    {
        Task<MarkAsPaidInvoiceViewModel?> GetInvoiceForPaymentAsync(int deliveryId);
        Task<List<InvoiceForDeliveryViewModel>> GetInvoicesAsync(string? deliveryReferenceNumber = null, DateTime? startDate = null, DateTime? endDate = null, string? companyName = null, bool? isPaid = null, decimal? minAmount = null, decimal? maxAmount = null);
        Task<List<InvoiceForDeliveryViewModel>> GetInvoicesForCompanyAsync(string username, string? deliveryReferenceNumber = null, DateTime? startDate = null, DateTime? endDate = null, decimal? minPrice = null, decimal? maxPrice = null, bool? isPaid = null);      
        Task<bool> InvoiceWithIdExistsAsync(int invoiceId);
        Task<int> MarkInvoiceAsPaidAsync(int id);
    }
}

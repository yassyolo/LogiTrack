using LogiTrack.Core.ViewModels.Accountant;

namespace LogiTrack.Core.Contracts
{
    public interface IInvoiceService
    {
        Task<MarkAsPaidInvoiceViewModel?> GetInvoiceForPaymentAsync(int deliveryId);
        Task<List<InvoiceForDeliveryViewModel>> GetInvoicesAsync(string? deliveryReferenceNumber = null, DateTime? startDate = null, DateTime? endDate = null, string? companyName = null, bool? isPaid = null);
        Task<List<InvoiceForDeliveryViewModel>> GetInvoicesForCompanyAsync(string username, string? deliveryReferenceNumber, DateTime? startDate, DateTime? endDate, decimal? minPrice, decimal? maxPrice, bool isPaid);
        Task<bool> InvoiceWithIdExistsAsync(int invoiceId);
        Task<int> MarkInvoiceAsPaidAsync(int id);
    }
}

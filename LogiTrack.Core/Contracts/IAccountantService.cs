
using LogiTrack.Core.ViewModels.Accountant;

namespace LogiTrack.Core.Contracts
{
    public interface IAccountantService
    {
        Task<AccountantDashboardViewModel?> GetAccountantDashboardAsync();
        Task<MarkAsPaidInvoiceViewModel?> GetInvoiceForPaymentAsync(int deliveryId);
        Task<bool> InvoiceWithIdExistsAsync(int invoiceId);
        Task<int> MarkInvoiceAsPaidAsync(int id);
    }
}

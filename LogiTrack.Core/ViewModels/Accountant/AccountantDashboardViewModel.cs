using LogiTrack.Core.ViewModels.Clients;
using LogiTrack.Core.ViewModels.Delivery;
using LogiTrack.Core.ViewModels.Invoice;

namespace LogiTrack.Core.ViewModels.Accountant
{
    public class AccountantDashboardViewModel
    {
        public int NewFinishedDeliveriesFromLastWeek { get; set; }
        public int NotPaidDeliveriesCount { get; set; }
        public int InvoicesCount { get; set; }
        public int InvoicesCountFromLastMonth { get; set; }
        public string DueAmountForDeliveries { get; set; } = string.Empty;
        public List<InvoiceForDashboardViewModel> Last5NotPaidInvoices { get; set; } = new List<InvoiceForDashboardViewModel>();
        public List<DeliveryForAccountantViewModel> Last5NewDeliveries { get; set; } = new List<DeliveryForAccountantViewModel>();
    }
}

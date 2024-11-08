using LogiTrack.Core.ViewModels.Accountant;

namespace LogiTrack.Core.ViewModels.Clients
{
    public class MyInvoicesViewModel
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string? DeliveryReferenceNumber { get; set; }
        public string? SearchTerm { get; set; }
        public bool IsPaid { get; set; } = false;
        public List<InvoiceForDeliveryViewModel> Invoices { get; set; } = new List<InvoiceForDeliveryViewModel>();

    }
}

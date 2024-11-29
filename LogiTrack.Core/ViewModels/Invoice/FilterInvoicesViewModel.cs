namespace LogiTrack.Core.ViewModels.Invoice
{
    public class FilterInvoicesViewModel
    {
        public List<InvoiceForDeliveryViewModel> Invoices { get; set; } = new List<InvoiceForDeliveryViewModel>();
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? CompanyName { get; set; }
        public string? DeliveryReferenceNumber { get; set; }
        public string? SearchTerm { get; set; }
        public bool IsPaid { get; set; } = false;
        public decimal? MinAmount { get; set; }
        public decimal? MaxAmount { get; set; }
    }
}

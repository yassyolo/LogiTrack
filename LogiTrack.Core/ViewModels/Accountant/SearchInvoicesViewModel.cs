namespace LogiTrack.Core.ViewModels.Accountant
{
    public class SearchInvoicesViewModel
    {
        public List<InvoiceForDeliveryViewModel> Invoices { get; set; } = new List<InvoiceForDeliveryViewModel>();
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? CompanyName { get; set; }
        public string? DeliveryReferenceNumber { get; set; }
        public string? SearchTerm { get; set; }
        public bool IsPaid { get; set; } = false;
    }
}

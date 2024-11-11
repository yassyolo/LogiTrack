namespace LogiTrack.Core.ViewModels.Invoice
{
    public class InvoiceForDashboardViewModel
    {
        public int Id { get; set; }
        public string Date { get; set; } = string.Empty;
        public string CreationDate { get; set; } = string.Empty;
        public string InvoiceNumber { get; set; } = string.Empty;
        public string Amount { get; set; } = string.Empty;
        public bool IsPaid { get; set; }
    }
}

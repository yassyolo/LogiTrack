namespace LogiTrack.Core.ViewModels.Invoice
{
    public class InvoiceForDeliveryViewModel
    {
        public int DeliveryId { get; set; }
        public string? Number { get; set; }
        public string Date { get; set; } = string.Empty;
        public string PaymentDate { get; set; } = string.Empty;
        public bool IsPaid { get; set; }
        public string Amount { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string FileUrl { get; set; } = string.Empty;
        public string FileId { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}

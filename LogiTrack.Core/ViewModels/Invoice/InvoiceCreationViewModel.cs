namespace LogiTrack.Core.ViewModels.Invoice
{
    internal class InvoiceCreationViewModel
    {
        public string InvoiceNumber { get; set; } = string.Empty;
        public string ClientCompanyName { get; set; } = string.Empty;
        public string DeliveryReferenceNumber { get; set; } = string.Empty;
        public DateTime DeliveryDate { get; set; }
        public decimal Price { get; set; }
        public string PickupAddress { get; set; } = string.Empty;
        public string DeliveryAddress { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
    }
}

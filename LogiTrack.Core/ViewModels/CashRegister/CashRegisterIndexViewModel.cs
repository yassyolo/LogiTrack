namespace LogiTrack.Core.ViewModels.CashRegister
{
    public class CashRegisterIndexViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string DeliveryReferenceNumber { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Amount { get; set; } = string.Empty;
        public string DateSubmitted { get; set; } = string.Empty;
        public string FileUrl { get; set; } = string.Empty;
        public string FileId { get; set; } = string.Empty;
        public int DeliveryId { get; set; }
    }
}

namespace LogiTrack.Core.ViewModels.Delivery
{
    public class DeliveryForClientsDeliveriesViewModel
    {
        public int Id { get; set; }
        public string ReferenceNumber { get; set; } = string.Empty;
        public string PickupAddress { get; set; } = string.Empty;
        public string DeliveryAddress { get; set; } = string.Empty;
        public bool IsDelivered { get; set; }
        public string ExpectedDeliveryDate { get; set; } = string.Empty;
        public string ActualDeliveryDate { get; set; } = string.Empty;
        public bool IsPaid { get; set; }
        public string FinalPrice { get; set; } = string.Empty;
        public string TotalWeight { get; set; } = string.Empty;
        public string TotalVolume { get; set; } = string.Empty;
        public string TotalItems { get; set; } = string.Empty;
    }
}

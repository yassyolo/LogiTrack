namespace LogiTrack.Core.ViewModels.Delivery
{
    public class DeliveryTrackingForDashboardViewModel
    {
        public int Id { get; set; }
        public string ReferenceNumber { get; set; } = string.Empty;
        public int DeliveryStep { get; set; }
        public string PickupAddress { get; set; } = string.Empty;
        public string DeliveryAddress { get; set; } = string.Empty;
        public string StatusUpdate { get; set; } = string.Empty;
    }
}

namespace LogiTrack.Core.ViewModels.Delivery
{
    public class DeliveryForDriverDashboardViewModel
    {
        public int Id { get; set; }
        public string ClientCompanyName { get; set; } = string.Empty;
        public string PickupAddress { get; set; } = string.Empty;
        public string DeliveryAddress { get; set; } = string.Empty;
        public string ReferenceNumber { get; set; } = string.Empty;
    }
}

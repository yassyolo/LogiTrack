namespace LogiTrack.Core.ViewModels.Delivery
{
    public class DeliveryWithVehicleViewModel
    {
        public int Id { get; set; }
        public string ReferenceNumber { get; set; } = string.Empty;
        public string VehicleRegistrationNumber { get; set; } = string.Empty;
        public string PickupAddress { get; set; } = string.Empty;
        public string DeliveryAddress { get; set; } = string.Empty;
        public int DeliveryStep { get; set; }

    }
}

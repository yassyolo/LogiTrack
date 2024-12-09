namespace LogiTrack.Core.ViewModels.Request
{
    public class PossibleVehiclesForDeliveryViewModel
    {
        public int Id { get; set; }
        public string VehicleType { get; set; } = string.Empty;
        public string RegistrationNumber { get; set; }= string.Empty;
        public double KilometersTillChanginParts { get; set; }
        public double KilometersLastYear { get; set; }
        public decimal CalculatedPrice { get; set; }
        public int ReservedDeliveriesCount { get; set; }
    }
}

namespace LogiTrack.Core.ViewModels.Request
{
    public class PossibleVehiclesForDeliveryViewModel
    {
        public int Id { get; set; }
        public string VehicleType { get; set; } = string.Empty;
        public string RegistrationNumber { get; set; }= string.Empty;
        public string EmissionFactor { get; set; } = string.Empty;
        public string FuelConsumptionPer100km { get; set; } = string.Empty;
        public string Height { get; set; } = string.Empty;
        public string Width { get; set; } = string.Empty;
        public string Length { get; set; } = string.Empty;
        public string Weight { get; set; } = string.Empty;
        public double KilometersTillChangingParts { get; set; }
        public double Kilometers { get; set; }
        public decimal CalculatedPrice { get; set; }
        public int ReservedDeliveriesCount { get; set; }
        public bool CurrentlyDelivering { get; set; }
        public int DeliveriesThisYearCount { get; set; }
        public bool Cheapest { get; set; }
        public bool MostEconomical { get; set; }
        public bool MostEcological { get; set; }
        public bool ClosestToMaintenance { get; set; }
        public bool MostOptimal { get; set; }
    }
}

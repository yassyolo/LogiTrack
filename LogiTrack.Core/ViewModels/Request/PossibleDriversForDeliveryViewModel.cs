namespace LogiTrack.Core.ViewModels.Request
{
    public class PossibleDriversForDeliveryViewModel
    {
        public int Id { get; set; }
        public string? DriverName { get; set; }
        public string? DriverPhoneNumber { get; set; }
        public int Age { get; set; }
        public string KilometersDriven { get; set; } = string.Empty;
        public int ReservedDeliveriesCount { get; set; }
        public int InternationalDeliveriesThisYearCount { get; set; }
        public int DomesticsDeliveriesThisYearCount { get; set; }
        public bool CurrentlyDelivering { get; set; }
        public double SuccessRate { get; set; }
        public bool LicenseExpiringSoon { get; set; }
        public bool Experienced { get; set; }
        public bool Fit { get; set; }
        public bool Nearby { get; set; }
        public bool LowWorkload { get; set; }
    }
}

namespace LogiTrack.Core.ViewModels.Driver
{
    public class DriverForLogisticsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string LicenseNumber { get; set; } = string.Empty;
        public string LicenseExpiryDate { get; set; } = string.Empty;
        public int InternatinalDeliveries { get; set; }
        public int DomesticDeliveries { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Salary { get; set; } = string.Empty;
        public string Age { get; set; } = string.Empty;
        public string YearOfExperience { get; set; } = string.Empty;
        public string MonthsOfExperience { get; set; } = string.Empty;
        public bool IsAvailable { get; set; } 
        public string? Preferrences { get; set; }
    }
}

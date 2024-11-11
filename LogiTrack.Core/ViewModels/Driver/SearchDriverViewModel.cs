namespace LogiTrack.Core.ViewModels.Driver
{
    public class SearchDriverViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string? SearchTerm { get; set; }
        public string? LicenseNumber { get; set; }
        public string? Salary { get; set; }
        public bool IsAvailable { get; set; }
        public List<DriverForLogisticsViewModel> Drivers { get; set; } = new List<DriverForLogisticsViewModel>();
    }
}

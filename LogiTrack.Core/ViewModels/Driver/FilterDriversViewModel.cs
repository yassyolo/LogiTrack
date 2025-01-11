namespace LogiTrack.Core.ViewModels.Driver
{
    public class FilterDriversViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string? SearchTerm { get; set; }
        public string? LicenseNumber { get; set; }
        public decimal? MinSalary { get; set; }
        public decimal? MaxSalary { get; set; }
        public bool IsAvailable { get; set; }
        public List<DriverForLogisticsViewModel> Drivers { get; set; } = new List<DriverForLogisticsViewModel>();
    }
}

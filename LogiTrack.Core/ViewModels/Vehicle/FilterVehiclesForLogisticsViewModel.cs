namespace LogiTrack.Core.ViewModels.Vehicle
{
    public class FilterVehiclesForLogisticsViewModel
    {
        public string? RegistrationNumber { get; set; } 
        public string? VehicleType { get; set; } 
        public bool Refrigerated { get; set; }
        public bool ForMaintentance { get; set; }
        public double? MinWeightCapacity { get; set; }
        public double? MaxWeightCapacity { get; set; }
        public double? MinVolume { get; set; }
        public double? MaxVolume { get; set; }
        public string? SearchTerm { get; set; } 
        public List<VehicleDetailsViewModel> Vehicles { get; set; } = new List<VehicleDetailsViewModel>();
    }
}

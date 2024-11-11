namespace LogiTrack.Core.ViewModels.Vehicle
{
    public class SearchVehicleViewModel
    {
        public VehicleIndexViewModel Vehicle { get; set; } = null!;
        public string SearchTerm { get; set; } = string.Empty;
    }
}

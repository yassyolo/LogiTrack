namespace LogiTrack.Core.ViewModels.Vehicle
{
    public class ChangeQuotientsForVehicleViewModel
    {
        public int Id { get; set; }
        public double QuotientForDomesticNotSharedTruck { get; set; }
        public double QuotientForDomesticSharedTruck { get; set; }
        public double QuotientForInternationalNotSharedTruck { get; set; }
        public double QuotientForInternationalSharedTruck { get; set; }
    }
}

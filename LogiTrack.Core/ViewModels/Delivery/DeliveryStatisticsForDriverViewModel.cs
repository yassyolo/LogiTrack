namespace LogiTrack.Core.ViewModels.Delivery
{
    public class DeliveryStatisticsForDriverViewModel
    {
        public int TotalSuccessfulCompleted { get; set; } 
        public double TotalKilometers { get; set; } 
        public double TotalCarbonEmission { get; set; }
        public int TotalDomesticDeliveries { get; set; }
        public int TotalInternationalDeliveries { get; set; } 
    }
}

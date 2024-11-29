namespace LogiTrack.Core.ViewModels.Delivery
{
    public class DeliveryStatisticsForClientViewModel
    {
        public int TotalDeliveries { get; set; }
        public double Kilometers { get; set; }
        public double CO2Emissions { get; set; }
        public double AverageDeliveryTime { get; set; }
        public double AverageDeliveryDistance { get; set; }
    }
}

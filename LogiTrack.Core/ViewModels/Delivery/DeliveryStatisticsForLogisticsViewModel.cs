namespace LogiTrack.Core.ViewModels.Delivery
{
    public class DeliveryStatisticsForLogisticsViewModel
    {
        public int TotalDeliveries { get; set; }
        public int DeliveredDeliveries { get; set; }
        public int UndeliveredDeliveries { get; set; }
        public double KiloMetersDriven { get; set; }
        public double CO2Emissions { get; set; }
        public double AverageDeliveryTime { get; set; }
        public double AverageDeliveryDistance { get; set; }
        public decimal Profit { get; set; }
        public decimal Loss { get; set; }    
    }
}

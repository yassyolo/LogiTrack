namespace LogiTrack.Core.ViewModels.Request
{
    public class RequestStatisticsForClientViewModel
    {
        public int TotalRequests { get; set; }
        public int TotalRequestsWithOffers { get; set; }
        public double AverageWeight { get; set; }
        public double AverageVolume { get; set; }
        public decimal AveragePrice { get; set; }
    }
}

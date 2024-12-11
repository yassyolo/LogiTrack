namespace LogiTrack.Core.ViewModels.Request
{
    public class AllPendingRequestsViewModel
    {
        public string? PickupAddress { get; set; } 
        public string? DeliveryAddress { get; set; } 
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double? MinWeight { get; set; }
        public double? MaxWeight { get; set; }
        public double? MinVolume { get; set; }
        public double? MaxVolume { get; set; }
        public string? SharedTruck { get; set; } 
        public List<RequestsDetailsForLogisticsViewModel> Requests { get; set; } =  new List<RequestsDetailsForLogisticsViewModel>();
    }
}

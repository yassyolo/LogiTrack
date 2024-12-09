namespace LogiTrack.Core.ViewModels.Request
{
    public class AllPendingRequestsViewModel
    {
        public string? PickupAddress { get; set; } = string.Empty;
        public string? DeliveryAddress { get; set; } = string.Empty;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double? MinWeight { get; set; }
        public double? MaxWeight { get; set; }
        public double? MinVolume { get; set; }
        public double? MaxVolume { get; set; }
        public string SharedTruck { get; set; } = string.Empty;
        public List<RequestsDetailsForLogisticsViewModel> Requests { get; set; } =  new List<RequestsDetailsForLogisticsViewModel>();
    }
}

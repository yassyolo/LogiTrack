namespace LogiTrack.Core.ViewModels.Request
{
    public class FilterRequestsForLogisticsViewModel
    {
        public string? PickupAddress { get; set; } = string.Empty;
        public string? DeliveryAddress { get; set; } = string.Empty;
        public string? SearchTerm { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsApproved { get; set; }
        public bool SharedTruck { get; set; }
        public double? MinWeight { get; set; }
        public double? MaxWeight { get; set; }
        public decimal? MinPrice{ get; set; }
        public decimal? MaxPrice { get; set; }
        public IEnumerable<RequestsForSearchViewModel> Requests { get; set; } = new List<RequestsForSearchViewModel>();
    }
}

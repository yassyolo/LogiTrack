namespace LogiTrack.Core.ViewModels.Request
{
    public class FilterRequestsViewModel
    {
        public string? DeliveryAddress { get; set; }
        public string? PickupAddress { get; set; }
        public string? SearchTerm { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public double? MinWeight { get; set; }
        public double? MaxWeight { get; set; }
        public bool IsApproved { get; set; }
        public IEnumerable<RequestsForSearchViewModel> Requests { get; set; } = new List<RequestsForSearchViewModel>();
    }
}

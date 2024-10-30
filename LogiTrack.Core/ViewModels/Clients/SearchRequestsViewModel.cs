namespace LogiTrack.Core.ViewModels.Clients
{
    public class SearchRequestsViewModel
    {
        public string? DeliveryAddress { get; set; }
        public string? PickupAddress { get; set; }
        public string? SearchTerm { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsApproved { get; set; }
        public IEnumerable<RequestsForSearchViewModel> Requests { get; set; } = new List<RequestsForSearchViewModel>();
    }
}

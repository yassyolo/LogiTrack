using LogiTrack.Core.ViewModels.Delivery;

namespace LogiTrack.Core.ViewModels.Driver
{
    public class SearchDeliveryForDriverViewModel
    {
        public string? ReferenceNumber { get; set; }
        public string? DeliveryAddress { get; set; }
        public string? PickupAddress { get; set; }
        public string? SearchTerm { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsNew { get; set; }
        public List<DeliveryViewModel> Deliveries { get; set; } = new List<DeliveryViewModel>();
    }
}

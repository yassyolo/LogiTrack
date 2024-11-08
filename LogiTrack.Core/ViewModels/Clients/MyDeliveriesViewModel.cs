using LogiTrack.Core.ViewModels.Delivery;

namespace LogiTrack.Core.ViewModels.Clients
{
    public class MyDeliveriesViewModel
    {
        public string? ReferenceNumber { get; set; }
        public string? SearchTerm { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public bool IsPaid { get; set; }
        public bool IsDelivered { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<DeliveryForMyDeliveriesViewModel> Deliveries { get; set; } = new List<DeliveryForMyDeliveriesViewModel>();
    }
}

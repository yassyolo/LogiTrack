namespace LogiTrack.Core.ViewModels.Delivery
{
    public class ClientsDeliveriesViewModel
    {
        public string? ReferenceNumber { get; set; }
        public string? SearchTerm { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public bool IsPaid { get; set; }
        public bool IsDelivered { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<DeliveryForClientsDeliveriesViewModel> Deliveries { get; set; } = new List<DeliveryForClientsDeliveriesViewModel>();
    }
}

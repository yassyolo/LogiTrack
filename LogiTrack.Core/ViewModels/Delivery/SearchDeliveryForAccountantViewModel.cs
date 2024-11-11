namespace LogiTrack.Core.ViewModels.Delivery
{
    public class SearchDeliveryForAccountantViewModel
    {
        public string? ReferenceNumber { get; set; } 
        public string? SearchTerm { get; set; } 
        public string? ClientCompanyName { get; set; }
        public bool IsPaid { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<DeliveryViewModel> Deliveries { get; set; } = new List<DeliveryViewModel>();
    }
}

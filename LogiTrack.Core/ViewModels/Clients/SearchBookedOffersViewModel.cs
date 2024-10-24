namespace LogiTrack.Core.ViewModels.Clients
{
    public class SearchBookedOffersViewModel
    {
        public List<OfferForSearchViewModel> Offers { get; set; } = new List<OfferForSearchViewModel>();
        public string? DeliveryAddress { get; set; }
        public string? PickupAddress { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public bool Undelivered { get; set; }   
    }
}

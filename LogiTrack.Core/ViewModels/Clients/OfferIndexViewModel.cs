namespace LogiTrack.Core.ViewModels.Clients
{
    public class OfferIndexViewModel
    {
        public int Id { get; set; }
        public string PickupAddress { get; set; } = string.Empty;
        public string DeliveryAddress { get; set; } = string.Empty;

        public string Price { get; set; } = string.Empty;
    }
}

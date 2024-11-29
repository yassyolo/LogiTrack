using LogiTrack.Core.ViewModels.Clients;
using LogiTrack.Core.ViewModels.Request;

namespace LogiTrack.Core.ViewModels.Offer
{
    public class OfferForSearchViewModel
    {
        public string OfferNumber { get; set; } = string.Empty;
        public string TotalCargos { get; set; } = string.Empty;
        public int Id { get; set; }
        public string? NumberOfPallets { get; set; }        
        public string? NumberOfNonStandartGoods { get; set; } = string.Empty;
        public string TotalWeight { get; set; } = string.Empty;
        public string TotalVolume { get; set; } = string.Empty;
        public string PickupAddress { get; set; } = string.Empty;
        public string DeliveryAddress { get; set; } = string.Empty;
        public string ExpectedDeliveryDate { get; set; } = string.Empty;
        public string FinalPrice { get; set; } = string.Empty;
        public string OfferDate { get; set; } = string.Empty;
        public bool Booked { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}

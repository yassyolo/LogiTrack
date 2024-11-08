namespace LogiTrack.Core.ViewModels.Clients
{
    public class OfferForSearchViewModel
    {
        public string OfferNumber { get; set; } = string.Empty;
        public int Id { get; set; }
        public string? NumberOfPallets { get; set; }
        public string? PalletLength { get; set; } = string.Empty;
        public string? PalletWidth { get; set; } = string.Empty;
        public string? PalletHeight { get; set; } = string.Empty;
        public string? NumberOfNonStandartGoods { get; set; } = string.Empty;
        public List<NonStandardCargoRequestViewModel> NonStandardCargo { get; set; } = new List<NonStandardCargoRequestViewModel>();
        public string TotalWeight { get; set; } = string.Empty;
        public string TotalVolume { get; set; } = string.Empty;
        public string PickupAddress { get; set; } = string.Empty;
        public string DeliveryAddress { get; set; } = string.Empty;
        public string ExpectedDeliveryDate { get; set; } = string.Empty;
        public string FinalPrice { get; set; } = string.Empty;
        public string OfferDate { get; set; } = string.Empty;
        public bool Booked { get; set; }
        public bool IsApproved { get; set; }
        public string TotalItems { get; set; } = string.Empty;
    }
}

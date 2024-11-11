using LogiTrack.Core.ViewModels.Clients;
using LogiTrack.Core.ViewModels.Request;

namespace LogiTrack.Core.ViewModels.Offer
{
    public class OfferViewModel
    {
        public int Id { get; set; }
        public string CargoType { get; set; } = string.Empty; //standard , not standard
        public string? NumberOfNonStandartGoods { get; set; }
        public string TypeOfGoods { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty; //domestic, international
        public string PickupAddress { get; set; } = string.Empty;
        public string DeliveryAddress { get; set; } = string.Empty;
        public bool SharedTruck { get; set; }
        public string ApproximatePrice { get; set; } = string.Empty; //given by the company
        public string ExpectedDeliveryDate { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty; //pending, accepted, rejected
        public string SpecialInstructions { get; set; } = string.Empty;
        public bool IsRefrigerated { get; set; }

        public string CreatedAt { get; set; } = string.Empty;
        public string Kilometers { get; set; } = string.Empty;

        public string TotalWeight { get; set; } = string.Empty;
        public string TotalVolume { get; set; } = string.Empty;
        public string PalletsCount { get; set; } = string.Empty;
        public string PalletsLength { get; set; } = string.Empty;
        public string PalletsHeight { get; set; } = string.Empty;
        public string PalletsWidth { get; set; } = string.Empty;
        public List<NonStandardCargoRequestViewModel> NonStandardCargo { get; set; } = new List<NonStandardCargoRequestViewModel>();
        public string FinalPrice { get; set; } = string.Empty;
        public string OfferDate { get; set; } = string.Empty;
        public string OfferStatus { get; set; } = string.Empty;
        public string? Notes { get; set; }
        public bool Booked { get; set; }
    }
}

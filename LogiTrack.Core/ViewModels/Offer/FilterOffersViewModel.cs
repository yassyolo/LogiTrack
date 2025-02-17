﻿namespace LogiTrack.Core.ViewModels.Offer
{
    public class FilterOffersViewModel
    {
        public List<OfferForSearchViewModel> Offers { get; set; } = new List<OfferForSearchViewModel>();
        public string? DeliveryAddress { get; set; } 
        public string? PickupAddress { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsApproved { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string? SearchTerm { get; set; }
        public double? MinWeight { get; set; }
        public double? MaxWeight { get; set; }
    }
}

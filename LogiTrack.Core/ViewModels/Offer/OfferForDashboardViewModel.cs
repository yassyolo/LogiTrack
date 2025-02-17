﻿namespace LogiTrack.Core.ViewModels.Offer
{
    public class OfferForDashboardViewModel
    {
        public int Id { get; set; }
        public string ReferenceNumber { get; set; } = string.Empty;
        public string PickupAddress { get; set; } = string.Empty;
        public string DeliveryAddress { get; set; } = string.Empty;
        public string Price { get; set; } = string.Empty;
        public string ClientName { get; set; } = string.Empty;
    }
}

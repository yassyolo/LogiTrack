using LogiTrack.Core.ViewModels.Delivery;
using LogiTrack.Core.ViewModels.Offer;
using LogiTrack.Core.ViewModels.Request;

namespace LogiTrack.Core.ViewModels.Speditor
{
    public class SpeditorDashboardViewModel
    {
        public int TotalRequests { get; set; }
        public int NewRequests { get; set; }
        public int AcceptedOffers { get; set; }
        public int TotalOffers { get; set; }
        public int AvailableVehicles { get; set; }
        public int AvailableDrivers { get; set; }
        public int PendingRequestsCount { get; set; }
        public decimal FuelPrice { get; set; } 
        public IEnumerable<RequestsForSearchViewModel> LastFiveNewRequests { get; set; } = new List<RequestsForSearchViewModel>();
        public IEnumerable<OfferForDashboardViewModel> LastFivePendingOffers { get; set; } = new List<OfferForDashboardViewModel>();
        public IEnumerable<DeliveryTrackingForDashboardViewModel> LastFiveDeliveries { get; set; } = new List<DeliveryTrackingForDashboardViewModel>();
    }
}

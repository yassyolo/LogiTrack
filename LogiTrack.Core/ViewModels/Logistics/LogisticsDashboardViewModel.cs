using LogiTrack.Core.ViewModels.Delivery;
using LogiTrack.Core.ViewModels.Offer;

namespace LogiTrack.Core.ViewModels.Logistics
{
    public class LogisticsDashboardViewModel
    {
        public int PendingRegistrationsCount { get; set; }
        public int RequestsCount { get; set; }
        public int RequestsLastWeekCount { get; set; }
        public int DeliveriesCount { get; set; }
        public int DeliveriesLastWeekCount { get; set; }
        public List<DeliveryWithVehicleViewModel> DeliveresWithVehicles { get; set;  } = new List<DeliveryWithVehicleViewModel>(); 
        public List<OfferForDashboardViewModel> Last5BookedOffers { get; set; } = new List<OfferForDashboardViewModel>();
    }
}

using LogiTrack.Core.ViewModels.Delivery;

namespace LogiTrack.Core.ViewModels.Driver
{
    public class DriverDashboardViewModel
    {
        public int NewDeliveriesCount { get; set; } 
        public double KilometersDriven { get; set; }
        public List<DeliveryViewModel> Last5Deliveries { get; set; } = new List<DeliveryViewModel>();
        public List<DeliveryViewModel> NewDeliveries { get; set; } = new List<DeliveryViewModel>();
    }
}

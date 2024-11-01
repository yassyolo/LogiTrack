using LogiTrack.Core.ViewModels.Delivery;

namespace LogiTrack.Core.ViewModels.Driver
{
    public class DriverDashboardViewModel
    {
        public int NewDeliveriesCount { get; set; }
        public double KilometersDriven { get; set; }
        public double KilometersDrivenlastMonth { get; set; } 
        public List<DeliveryForDriverDashboardViewModel> LastDeliveries { get; set; } = new List<DeliveryForDriverDashboardViewModel>();
        public List<DeliveryForDriverDashboardViewModel> NewDeliveries { get; set; } = new List<DeliveryForDriverDashboardViewModel>();
    }
}

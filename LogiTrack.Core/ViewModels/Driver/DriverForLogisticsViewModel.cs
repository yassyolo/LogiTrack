using LogiTrack.Core.ViewModels.Delivery;

namespace LogiTrack.Core.ViewModels.Driver
{
    public class DriverForLogisticsViewModel
    {
        public int Id { get; set; }
        public decimal AdditionalCost { get; set; }
        public decimal AverageAdditionalCost { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string LicenseNumber { get; set; } = string.Empty;
        public string LicenseExpiryDate { get; set; } = string.Empty;
        public string AverageDeliveryTime { get; set; } = string.Empty;
        public string AverageDeliveryDistance { get; set; } = string.Empty;
        public int InternatinalDeliveries { get; set; }
        public int DomesticDeliveries { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Salary { get; set; } = string.Empty;
        public string Age { get; set; } = string.Empty;
        public string YearOfExperience { get; set; } = string.Empty;
        public string MonthsOfExperience { get; set; } = string.Empty;
        public bool IsAvailable { get; set; } 
        public string? Preferrences { get; set; }       
        public string PhoneNumber { get; set; } = string.Empty;      
        public List<DeliveryForClientsDeliveriesViewModel> Deliveries { get; set; } = new List<DeliveryForClientsDeliveriesViewModel>();
        public double KiloMetersDriven { get; set; }
        public int DeliveriesCount { get; set; }
        public int SuccessfulDeliveriesCount { get; set; }
        public int UndeliveryDeliveriesCount { get; set; }
        public string DaysTillExpiry { get; set; } = string.Empty;
    }
}

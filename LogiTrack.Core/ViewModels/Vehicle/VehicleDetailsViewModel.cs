using LogiTrack.Core.ViewModels.Delivery;

namespace LogiTrack.Core.ViewModels.Vehicle
{
    public class VehicleDetailsViewModel
    {
        public int Id { get; set; }
        public string QuotientForDomesticNotSharedTruck { get; set; } = string.Empty;
        public string QuotientForDomesticSharedTruck { get; set; } = string.Empty;
        public string QuotientForInternationalNotSharedTruck { get; set; } = string.Empty;
        public string QuotientForInternationalSharedTruck { get; set; } = string.Empty;
        public decimal AdditionalCost { get; set; }
        public double AverageKilometers { get; set; }
        public double EmissionFactorFrAllDeliveries { get; set; }
        public decimal AverageAdditionalCost { get; set; }
        public string RegistrationNumber { get; set; } = string.Empty;
        public string EmisionFactor { get; set; } = string.Empty;
        public string FuelPer100Km { get; set; } = string.Empty;
        public bool IsRefrigerated { get; set; }
        public string VehicleType { get; set; } = string.Empty;
        public string Length { get; set; } = string.Empty;
        public string Width { get; set; } = string.Empty;
        public string Height { get; set; } = string.Empty;
        public string Volume { get; set; } = string.Empty;
        public string EuroPalletCapacity { get; set; } = string.Empty;
        public string IndustrialPalletCapacity { get; set; } = string.Empty;
        public bool ArePalletsStackable { get; set; }
        public string MaxWeightCapacity { get; set; } = string.Empty;
        public string FuelConsumptionPer100Km { get; set; } = string.Empty;
        public string VehicleStatus { get; set; } = string.Empty;
        public int DaysTillMaintenance { get; set; } 
        public string LastYearMaintenance { get; set; } = string.Empty;
        public string KilometersDriven { get; set; } = string.Empty;
        public double KilometersLeftToChangeParts { get; set; } 
        public List<DeliveryForClientsDeliveriesViewModel> Deliveries { get; set; } = new List<DeliveryForClientsDeliveriesViewModel>();
        public string PurchasePrice { get; set; } = string.Empty;
        public string ContantsExpenses { get; set; } = string.Empty;
        public int DeliveriesLastMonth { get; set; }
        public int NotOnTimeDeliveries { get; set; }
    }
}

using LogiTrack.Core.ViewModels.Clients;
using LogiTrack.Core.ViewModels.Delivery;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LogiTrack.Core.ViewModels.Vehicle
{
    public class VehicleDetailsViewModel
    {
        public int Id { get; set; }
        public string RegistrationNumber { get; set; } = string.Empty;
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
        public string DaysTillMaintenance { get; set; } = string.Empty;
        public DateTime LastYearMaintenance { get; set; }
        public string KilometersDriven { get; set; } = string.Empty;
        public string KilometersLeftToChangeParts { get; set; } = string.Empty;
        public List<DeliveryForClientsDeliveriesViewModel> Deliveries { get; set; } = new List<DeliveryForClientsDeliveriesViewModel>();
        public string PurchasePrice { get; set; } = string.Empty;
        public string ContantsExpenses { get; set; } = string.Empty;
    }
}

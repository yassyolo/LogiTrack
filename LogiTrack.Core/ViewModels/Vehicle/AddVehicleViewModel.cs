using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LogiTrack.Core.ViewModels.Vehicle
{
    public class AddVehicleViewModel
    {
        public int Id { get; set; }
        public bool IsRefrigerated { get; set; }
        public string RegistrationNumber { get; set; } = string.Empty;
        public string VehicleType { get; set; } = string.Empty;
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public int EuroPalletCapacity { get; set; }
        public int IndustrialPalletCapacity { get; set; }
        public bool ArePalletsStackable { get; set; }
        public double MaxWeightCapacity { get; set; }
        public double FuelConsumptionPer100Km { get; set; }
        public DateTime LastYearMaintenance { get; set; }
        public double KilometersDriven { get; set; }
        public double KilometersToChangeParts { get; set; }
        public double KilometersLeftToChangeParts { get; set; }
        public decimal PurchasePrice { get; set; }
        public double EmissionFactor { get; set; }
        public decimal ContantsExpenses { get; set; }
        public double QuotientForDomesticNotSharedTruck { get; set; }
        public double QuotientForDomesticSharedTruck { get; set; }
        public double QuotientForInternationalNotSharedTruck { get; set; }
        public double QuotientForInternationalSharedTruck { get; set; }
    }
}

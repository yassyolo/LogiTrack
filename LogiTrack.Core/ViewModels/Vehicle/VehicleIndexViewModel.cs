using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogiTrack.Core.ViewModels.Vehicle
{
    public class VehicleIndexViewModel
    {
        public int Id { get; set; }
        public string RegistrationNumber { get; set; } = string.Empty;
        public string VehicleType { get; set; } = string.Empty;
        public string Length { get; set; } = string.Empty;
        public string Width { get; set; } = string.Empty;
        public string Height { get; set; } = string.Empty;
        public string EuroPalletCapacity { get; set; } = string.Empty;
        public string IndustrialPalletCapacity { get; set; } = string.Empty;
        public string MaxWeightCapacity { get; set; } = string.Empty;
        public string FuelConsumptionPer100Km { get; set; } = string.Empty;
        public string MaintenanceDue { get; set; } = string.Empty;
        public string DomesticPriceForNotSharedTruck { get; set; } = string.Empty;
        public string DomesticPriceForSharedTruck { get; set; } = string.Empty;
        public string InternationalPriceForNotSharedTruck { get; set; } = string.Empty;
        public string InternationalPriceForSharedTruck { get; set; } = string.Empty;

    }
}

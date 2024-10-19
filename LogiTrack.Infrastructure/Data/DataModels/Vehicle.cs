using LogiTrack.Infrastructure.Data.DataModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static LogiTrack.Infrastructure.Data.DataConstants.DataModelConstants.Vehicle;

namespace LogisticsSystem.Infrastructure.Data.DataModels
{
    [Comment("Vehicle Entity")]
    public class Vehicle
    {
        [Key]
        [Comment("Vehicle identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Vehicle registration number")]
        [StringLength(RegistartionNumberMaxLength)]
        public string RegistrationNumber { get; set; } = string.Empty;

        [Required]
        [Comment("Vehicle type")]
        [StringLength(VehicleTypeMaxLength)]
        public string VehicleType { get; set; } = string.Empty;

        [Required]
        [Comment("Vehicle length")]
        [Range(MetricsMinValue, MetricsMaxValue)]
        public double Length { get; set; }

        [Required]
        [Comment("Vehicle width")]
        [Range(MetricsMinValue, MetricsMaxValue)]
        public double Width { get; set; }

        [Required]
        [Comment("Vehicle height")]
        [Range(MetricsMinValue, MetricsMaxValue)]
        public double Height { get; set; }

        [Required]
        [Comment("Vehicle volume")]
        [Range(VolumeMinValue, VolumeMaxValue)]
        public double Volume { get; set; }

        [Required]
        [Comment("Euro pallets capacity")]
        [Range(PalletCapacityMinValue, PalletCapacityMaxValue)]
        public int? EuroPalletCapacity { get; set; } 

        [Required]
        [Comment("Industrial pallets capacity")]
        [Range(PalletCapacityMinValue, PalletCapacityMaxValue)]
        public int? IndustrialPalletCapacity { get; set; }

        [Required]
        [Comment("Are the pallets stackable")]
        public bool ArePalletsStackable { get; set; }

        [Required]
        [Comment("Max weight capacity")]
        [Range(MetricsMinValue, MetricsMaxValue)]
        public double MaxWeightCapacity { get; set; }

        [Required]
        [Comment("Fuel consumption per 100 km")]
        [Range(FuelConsumptionMinValue, FuelConsumptionMaxValue)]
        public double FuelConsumptionPer100Km { get; set; }

        [Required]
        [Comment("Vehicle status")]
        [StringLength(VehicleStatusMaxLength)]
        public string VehicleStatus { get; set; } = string.Empty;

        [Comment("Maintenance due date")]
        [Required]
        public DateTime? MaintenanceDue { get; set; }

        [Comment("Vehicle's delivery")]
        public IEnumerable<Delivery> Deliveries { get; set; } = new List<Delivery>();
    }
}

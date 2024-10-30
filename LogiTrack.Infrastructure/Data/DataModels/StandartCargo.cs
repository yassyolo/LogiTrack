using LogisticsSystem.Infrastructure.Data.DataModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static LogiTrack.Infrastructure.Data.DataConstants.DataModelConstants.Request;

namespace LogiTrack.Infrastructure.Data.DataModels
{
    [Comment("Standart Cargo Entity")]
    public class StandartCargo
    {
        [Key]
        [Comment("Standard cargo identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Request identifier")]
        public int RequestId { get; set; }

        [Comment("Request associated with this standard cargo")]
        [ForeignKey(nameof(RequestId))]
        public Request Request { get; set; } = null!;

        [Comment("Type of pallet")]
        [StringLength(TypeOfPalletMaxLength)]
        public string? TypeOfPallet { get; set; } = string.Empty; //euro, industrial

        [Comment("Number of pallets")]
        [Range(NumberOfPalletsMinValue, NumberOfPalletsMaxValue)]
        public int? NumberOfPallets { get; set; }

        [Comment("Pallet length")]
        [Range(PalletMetricsValue, PalletMetricsMaxValue)]
        public double? PalletLength { get; set; } //in cm

        [Comment("Pallet width")]
        [Range(PalletMetricsValue, PalletMetricsMaxValue)]
        public double? PalletWidth { get; set; }

        [Comment("Pallet height")]
        [Range(PalletMetricsValue, PalletMetricsMaxValue)]
        public double? PalletHeight { get; set; }

        [Comment("Pallet volume")]
        [Range(PalletVolumeMinValue, PalletVolumeMaxValue)]
        public double? PalletVolume { get; set; }

        [Comment("Weight of pallets")]
        [Range(PalletWeightMinValue, PalletWeightMaxValue)]
        public double? WeightOfPallets { get; set; }

        [Comment("Are the pallets stackable")]
        public bool? PalletsAreStackable { get; set; } //only if the truck is not shared
    }
}

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static LogiTrack.Core.Constants.MessageConstants.ErrorMessages;
using static LogiTrack.Infrastructure.Data.DataConstants.DataModelConstants.Request;

namespace LogiTrack.Core.ViewModels.Clients
{
    public class MakeRequestViewModel
    {
        [Required(ErrorMessage = RequiredFieldErrorMessage)]
        [StringLength(CargoTypeMaxLength, MinimumLength = CargoTypeMinLength, ErrorMessage = LengthErrorMessage)]
        public string CargoType { get; set; } = string.Empty; //standard , not standard

        #region Standart Cargo(Pallet) Metrics
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

        #endregion

        #region Non-standard Cargo Metrics

        [Comment("Number of non-standart goods")]
        [Range(NumberOfNonStandartGoodsMinValue, NumberOfNonStandartGoodsMaxValue)]
        public int? NumberOfNonStandartGoods { get; set; }

        [Comment("Length of the goods")]
        [Range(GoodsMetricsMinValue, GoodsMetricsMaxValue)]
        public int? Length { get; set; }

        [Comment("Width of the goods")]
        [Range(GoodsMetricsMinValue, GoodsMetricsMaxValue)]
        public int? Width { get; set; }

        [Comment("Height of the goods")]
        [Range(GoodsMetricsMinValue, GoodsMetricsMaxValue)]
        public int? Height { get; set; }

        [Comment("Volume of the goods")]
        [Range(GoodsVolumeMinValue, GoodsVolumeMaxValue)]
        public double? Volume { get; set; }

        [Comment("Weight of the goods")]
        [Range(GoodsWeightMinValue, GoodsWeightMaxValue)]
        public double? Weight { get; set; }

        #endregion

        [Required(ErrorMessage = RequiredFieldErrorMessage)]
        [StringLength(TypeOfGoodsMaxLength)]
        public string TypeOfGoods { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredFieldErrorMessage)]
        [StringLength(RequestTypeMaxLength)]
        public string Type { get; set; } = string.Empty; //domestic, international

        [Required]
        [Comment("Pickup address latitude")]
        [Range(LatitudeMinValue, LatitudeMaxValue)]
        public double PickupLatitude { get; set; }

        [Required]
        [Comment("Pickup address longitude")]
        [Range(LongitudeMinValue, LongitudeMaxValue)]
        public double PickupLongitude { get; set; }

        [Required]
        [Comment("Delivery address latitude")]
        [Range(LatitudeMinValue, LatitudeMaxValue)]
        public double DeliveryLatitude { get; set; }

        [Required]
        [Comment("Delivery address longitude")]
        [Range(LongitudeMinValue, LongitudeMaxValue)]
        public double DeliveryLongitude { get; set; }

        [Required(ErrorMessage = RequiredFieldErrorMessage)]
        public bool SharedTruck { get; set; }

        [Required(ErrorMessage = RequiredFieldErrorMessage)]
        [Range(PriceMinValue, PriceMaxValue)]
        public decimal ApproximatePrice { get; set; } //given by the company

        [Required(ErrorMessage = RequiredFieldErrorMessage)]
        [Comment("Expected delivery date")]
        public DateTime ExpectedDeliveryDate { get; set; }

        [Comment("Special instructions")]
        [StringLength(SpecialInstructionsMaxLength)]
        public string SpecialInstructions { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredFieldErrorMessage)]
        [Comment("Is the cargo refrigerated")]
        public bool IsRefrigerated { get; set; }
    }
}

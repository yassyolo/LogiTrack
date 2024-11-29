using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static LogiTrack.Core.Constants.MessageConstants.ErrorMessages;
using static LogiTrack.Infrastructure.Data.DataConstants.DataModelConstants.Request;
using Org.BouncyCastle.Asn1.Mozilla;

namespace LogiTrack.Core.ViewModels.Request
{
    public class MakeRequestViewModel
    {
        [Required(ErrorMessage = RequiredFieldErrorMessage)]
        [StringLength(CargoTypeMaxLength, MinimumLength = CargoTypeMinLength, ErrorMessage = LengthErrorMessage)]
        public string CargoType { get; set; } = string.Empty; 

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

        public double? PalletHeight { get; set; }

        [Comment("Weight of pallets")]
        [Range(PalletWeightMinValue, PalletWeightMaxValue)]
        public double? WeightOfPallets { get; set; }

        [Comment("Are the pallets stackable")]
        public bool PalletsAreStackable { get; set; } //only if the truck is not shared

        public int? NumberOfNonStandartGoods { get; set; }

        [Required(ErrorMessage = RequiredFieldErrorMessage)]
        [StringLength(TypeOfGoodsMaxLength)]
        public string TypeOfGoods { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredFieldErrorMessage)]
        [StringLength(RequestTypeMaxLength)]
        public string Type { get; set; } = string.Empty; //domestic, international

        public string PickupStreet { get; set; } = string.Empty;
        public string PickupCity { get; set; } = string.Empty;
        public string PickupCountry { get; set; } = string.Empty;
        public double PickupLatitude { get; set; }
        public double PickupLongitude { get; set; }
        public string DeliveryStreet { get; set; } = string.Empty;
        public string DeliveryCity { get; set; } = string.Empty;
        public string DeliveryCountry { get; set; } = string.Empty;
        public double DeliveryLatitude { get; set; }
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
        // [StringLength(SpecialInstructionsMaxLength)]
        public string SpecialInstructions { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredFieldErrorMessage)]
        [Comment("Is the cargo refrigerated")]
        public bool IsRefrigerated { get; set; }
        public int[]? Length { get; set; } = Array.Empty<int>();

        public int[]? Width { get; set; } = Array.Empty<int>();

        public int[]? Height { get; set; } = Array.Empty<int>();
        public string[]? Description { get; set; } = Array.Empty<string>();
        public double[]? Weight { get; set; } = Array.Empty<double>();
    }
}

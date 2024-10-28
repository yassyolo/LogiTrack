using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static LogiTrack.Infrastructure.Data.DataConstants.DataModelConstants.Request;

namespace LogisticsSystem.Infrastructure.Data.DataModels
{
    //TODO: add a non-standard goods entity as separate one
    [Comment("Request Entity")]
    public class Request
    {
        [Key]
        [Comment("Request identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Client Company identifier")]
        public int ClientCompanyId { get; set; }

        [Comment("Client Company of the request")]
        [ForeignKey(nameof(ClientCompanyId))]
        public ClientCompany ClientCompany { get; set; } = null!;

        [Required]
        [Comment("Cargo type")]
        [StringLength(CargoTypeMaxLength)]
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
        public double? Length { get; set; }

        [Comment("Width of the goods")]
        [Range(GoodsMetricsMinValue, GoodsMetricsMaxValue)]
        public double? Width { get; set; }

        [Comment("Height of the goods")]
        [Range(GoodsMetricsMinValue, GoodsMetricsMaxValue)]
        public double? Height { get; set; }

        [Comment("Volume of the goods")]
        [Range(GoodsVolumeMinValue, GoodsVolumeMaxValue)]
        public double? Volume { get; set; }

        [Comment("Weight of the goods")]
        [Range(GoodsWeightMinValue, GoodsWeightMaxValue)]
        public double? Weight { get; set; }

        #endregion

        [Required]
        [Comment("Type of goods")]
        [StringLength(TypeOfGoodsMaxLength)]
        public string TypeOfGoods { get; set; } = string.Empty;

        [Required]
        [Comment("Type of the request")]
        [StringLength(RequestTypeMaxLength)]
        public string Type { get; set; } = string.Empty; //domestic, international

        //TODO: ADD MIGRATION FOR THIS
        [Required]
        [Comment("Pickup address")]
        [StringLength(AddressMaxLength)]
        public string PickupAddress { get; set; } = string.Empty;

        [Required]
        [Comment("Pickup address latitude")]
        [Range(LatitudeMinValue, LatitudeMaxValue)]
        public double PickupLatitude { get; set; }

        [Required]
        [Comment("Pickup address longitude")]
        [Range(LongitudeMinValue, LongitudeMaxValue)]
        public double PickupLongitude { get; set; }

        [Required]
        [Comment("Delivery address")]
        [StringLength(AddressMaxLength)]
        public string DeliveryAddress { get; set; } = string.Empty;

        [Required]
        [Comment("Delivery address latitude")]
        [Range(LatitudeMinValue, LatitudeMaxValue)]
        public double DeliveryLatitude { get; set; }

        [Required]
        [Comment("Delivery address longitude")]
        [Range(LongitudeMinValue, LongitudeMaxValue)]
        public double DeliveryLongitude { get; set; }

        [Required]
        [Comment("Will the vehicle be shared or no")]
        public bool SharedTruck { get; set; }

        [Required]
        [Comment("Approximate price given by the company")]
        [Range(PriceMinValue, PriceMaxValue)]
        public decimal ApproximatePrice { get; set; } //given by the company

        [Comment("Automatically calculated price")]
        [Range(PriceMinValue, PriceMaxValue)]
        public decimal CalculatedPrice { get; set; }

        [Required]
        [Comment("Expected delivery date")]
        public DateTime ExpectedDeliveryDate { get; set; }

        [Comment("Status of the request")]
        [StringLength(RequestStatusMaxLength)]
        public string Status { get; set; } = string.Empty; //pending, accepted, rejected

        [Comment("Special instructions")]
        [StringLength(SpecialInstructionsMaxLength)]
        public string SpecialInstructions { get; set; } = string.Empty;

        [Required]
        [Comment("Is the cargo refrigerated")]
        public bool IsRefrigerated { get; set; }

        [Comment("Offer identifier")]
        public int? OfferId { get; set; }

        [Comment("Offer")]
        [ForeignKey(nameof(OfferId))]
        public Offer? Offer { get; set; }

        [Required]
        [Comment("Date of creation")]
        public DateTime CreatedAt { get; set; }

        public double Kilometers { get; set; }
    }
}

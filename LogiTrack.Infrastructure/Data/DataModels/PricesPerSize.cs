using LogisticsSystem.Infrastructure.Data.DataModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static LogiTrack.Infrastructure.Data.DataConstants.DataModelConstants.PricePerSize;

namespace LogiTrack.Infrastructure.Data.DataModels
{
    [Comment("Prices per size entity")]
    public class PricesPerSize
    {
        [Comment("Prices per size identifier")]
        [Key]
        public int Id { get; set; }

        [Comment("Vehicle identifier")]
        public int VehicleId { get; set; }

        [Comment("Vehicle")]
        [ForeignKey(nameof(VehicleId))]
        public Vehicle Vehicle { get; set; } = null!;

        [Comment("Quotient for domestic not shared truck")]
        [Range(QuotientMinValue, QuotientMaxValue)]
        public double QuotientForDomesticNotSharedTruck { get; set; }

        [Comment("Quotient for domestic shared truck")]
        [Range(QuotientMinValue, QuotientMaxValue)]
        public double QuotientForDomesticSharedTruck { get; set; }

        [Comment("Quotient for international not shared truck")]
        [Range(QuotientMinValue, QuotientMaxValue)]
        public double QuotientForInternationalNotSharedTruck { get; set; }

        [Comment("Quotient for international shared truck")]
        [Range(QuotientMinValue, QuotientMaxValue)]
        public double QuotientForInternationalSharedTruck { get; set; }

        [Required]
        [Comment("Domestic price for shared truck")]
        [Range(PriceMinValue, PriceMaxValue)]
        public decimal DomesticPriceForNotSharedTruck { get; set; }

        [Required]
        [Comment("Domestic price for shared truck")]
        [Range(PriceMinValue, PriceMaxValue)]
        public decimal DomesticPriceForSharedTruck { get; set; }

        [Required]
        [Comment("International price for shared truck")]
        [Range(PriceMinValue, PriceMaxValue)]
        public decimal InternationalPriceForNotSharedTruck { get; set; }

        [Required]
        [Comment("International price for shared truck")]
        [Range(PriceMinValue, PriceMaxValue)]
        public decimal InternationalPriceForSharedTruck { get; set; }
    }
}

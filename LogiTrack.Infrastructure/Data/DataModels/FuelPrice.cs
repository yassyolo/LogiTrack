using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static LogiTrack.Infrastructure.Data.DataConstants.DataModelConstants.FuelPrice;

namespace LogiTrack.Infrastructure.Data.DataModels
{
    [Comment("Fuel Prices Entity")]
    public class FuelPrice
    {
        [Key]
        [Comment("Fuel Price identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Fuel price")]
        [Range(PriceMinValue, PriceMaxValue)]
        public decimal Price { get; set; }

        [Required]
        [Comment("Date")]
        public DateTime Date { get; set; }
    }
}

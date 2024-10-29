using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static LogiTrack.Infrastructure.Data.DataConstants.DataModelConstants.Request;
using LogisticsSystem.Infrastructure.Data.DataModels;

namespace LogiTrack.Infrastructure.Data.DataModels
{
    [Comment("Non-Standard Cargo Entity")]
    public class NonStandardCargo
    {
        [Key]
        [Comment("Non-standard cargo identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Request identifier")]
        public int RequestId { get; set; }

        [Comment("Request associated with this non-standard cargo")]
        [ForeignKey(nameof(RequestId))]
        public Request Request { get; set; } = null!;

        [Required]
        [Comment("Length of the goods")]
        [Range(GoodsMetricsMinValue, GoodsMetricsMaxValue)]
        public double Length { get; set; }

        [Required]
        [Comment("Width of the goods")]
        [Range(GoodsMetricsMinValue, GoodsMetricsMaxValue)]
        public double Width { get; set; }

        [Required]
        [Comment("Height of the goods")]
        [Range(GoodsMetricsMinValue, GoodsMetricsMaxValue)]
        public double Height { get; set; }

        [Required]
        [Comment("Volume of the goods")]
        [Range(GoodsVolumeMinValue, GoodsVolumeMaxValue)]
        public double Volume { get; set; }

        [Required]
        [Comment("Weight of the goods")]
        [Range(GoodsWeightMinValue, GoodsWeightMaxValue)]
        public double Weight { get; set; }

        [Comment("Description of the non-standard cargo")]
        [StringLength(100)]
        public string? Description { get; set; }
    }
}

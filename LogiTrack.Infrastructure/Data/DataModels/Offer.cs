using LogiTrack.Infrastructure.Data.DataModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static LogiTrack.Infrastructure.Data.DataConstants.DataModelConstants.Offer;

namespace LogisticsSystem.Infrastructure.Data.DataModels
{
    [Comment("Offer Entity")]
    public class Offer
    {
        [Key]
        [Comment("Offer identifier")]
        public int Id { get; set; }

        [Comment("Request identifier")]
        public int RequestId { get; set; }

        [Comment("Request")]
        [ForeignKey(nameof(RequestId))]
        public Request Request { get; set; } = null!;

        [Comment("Company identifier")]
        [Range(PriceMinValue, PriceMaxValue)]
        [Required]
        public decimal FinalPrice { get; set; }

        [Comment("Offer status")]
        [StringLength(OfferStatusMaxLength)]
        [Required]
        public string OfferStatus { get; set; } = string.Empty;

        [Comment("Offer date")]
        [Required]
        public DateTime OfferDate { get; set; }

        [Comment("Notes for the offer")]
        [StringLength(NotesMaxLength)]
        public string? Notes { get; set; }

        [Comment("Delivery identifier")]
        public int? DeliveryId { get; set; }

        [Comment("Delivery")]
        [ForeignKey(nameof(DeliveryId))]
        public Delivery? Delivery { get; set; } = null;
    }
}

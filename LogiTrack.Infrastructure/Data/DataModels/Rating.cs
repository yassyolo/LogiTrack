using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogiTrack.Infrastructure.Data.DataModels
{
    [Comment("Rating Entity")]
    public class Rating
    {
        [Key]
        [Comment("Rating identifier")]
        public int Id { get; set; }

        [Comment("Rating stars")]
        [Range(1, 5)]
        public int RatingStars { get; set; }

        [Comment("Rating comment")]
        public string Comment { get; set; } = string.Empty;

        [Comment("Delivery identifier")]
        public int DeliveryId { get; set; }

        [ForeignKey(nameof(DeliveryId))]
        [Comment("Delivery")]
        public Delivery Delivery { get; set; } = null!;

    }
}

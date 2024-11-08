using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogiTrack.Infrastructure.Data.DataModels
{
    [Comment("Rating Entity")]
    public class Rating
    {
        [Key]
        public int Id { get; set; }
        public int RatingStars { get; set; }
        public string Comment { get; set; } = string.Empty;
        public int DeliveryId { get; set; }
        [ForeignKey(nameof(DeliveryId))]
        public Delivery Delivery { get; set; } = null!;

    }
}

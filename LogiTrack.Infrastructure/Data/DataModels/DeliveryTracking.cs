using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static LogiTrack.Infrastructure.Data.DataConstants.DataModelConstants.DeliveryTracking;

namespace LogiTrack.Infrastructure.Data.DataModels
{
    [Comment("Delivery Tracking Entity")]
    public class DeliveryTracking { 

        [Key]
        public int Id { get; set; }

        [Comment("Delivery identifier")]
        public int DeliveryId { get; set; }

        [Comment("Delivery")]
        [ForeignKey(nameof(DeliveryId))]
        public Delivery Delivery { get; set; } = null!;

        [Comment("Driver identifier")]
        public int DriverId { get; set; }

        [Comment("Driver")]
        [ForeignKey(nameof(DriverId))] 
        public Driver Driver { get; set; } = null!;

        [Comment("Status update")]
        [StringLength(TrackingStatusMaxLength)]
        [Required]
        public string StatusUpdate { get; set; } = string.Empty;

        [Comment("Notes")]
        [StringLength(TrackingNotesMaxLength)]
        public string? Notes { get; set; }

        [Comment("Timestamp")]
        [Required]
        public DateTime Timestamp { get; set; }

        [Comment("Latitude")]
        [Required]
        [Range(LatitudeMinValue, LatitudeMaxValue)]
        public double Latitude { get; set; }

        [Comment("Longitude")]
        [Required]
        [Range(LongitudeMinValue, LongitudeMaxValue)]
        public double Longitude { get; set; }

        [Comment("Address")]
        [StringLength(AddressMaxLength)]
        [Required]

        public string Address { get; set; } = string.Empty;
    }
}

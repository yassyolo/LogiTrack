using LogisticsSystem.Infrastructure.Data.DataModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogiTrack.Infrastructure.Data.DataModels
{
    public class ReservedForDelivery
    {
        [Key]
        [Comment("Reserved for delivery identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Vehicle identifier")]
        public int VehicleId { get; set; }

        [ForeignKey(nameof(VehicleId))]
        [Comment("Vehicle")]
        public Vehicle Vehicle { get; set; } = null!;

        [Required]
        [Comment("Offer identifier")]
        public int OfferId { get; set; }

        [ForeignKey(nameof(OfferId))]
        [Comment("Offer")]
        public Offer Offer { get; set; } = null!;

        [Required]
        [Comment("Request identifier")]
        public int RequestId { get; set; }

        [ForeignKey(nameof(RequestId))]
        [Comment("Request")]
        public Request Request { get; set; } = null!;

        [Required]
        [Comment("Driver identifier")]
        public int DriverId { get; set; }

        [ForeignKey(nameof(DriverId))]
        [Comment("Driver")]
        public Driver Driver { get; set; } = null!;

        [Required]
        [Comment("Start date")]
        public DateTime Start { get; set; }

        [Required]
        [Comment("End date")]
        public DateTime End { get; set; }
    }
}

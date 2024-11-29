using LogisticsSystem.Infrastructure.Data.DataModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogiTrack.Infrastructure.Data.DataModels
{
    public class ReservedForDelivery
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int VehicleId { get; set; }

        [ForeignKey(nameof(VehicleId))]
        public Vehicle Vehicle { get; set; } = null!;

        [Required]
        public int OfferId { get; set; }

        [ForeignKey(nameof(OfferId))]
        public Offer Offer { get; set; } = null!;

        [Required]
        public int RequestId { get; set; }

        [ForeignKey(nameof(RequestId))]
        public Request Request { get; set; } = null!;

        [Required]
        public int DriverId { get; set; }

        [ForeignKey(nameof(DriverId))]
        public Driver Driver { get; set; } = null!;
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}

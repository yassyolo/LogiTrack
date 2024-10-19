using LogisticsSystem.Infrastructure.Data.DataModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static LogiTrack.Infrastructure.Data.DataConstants.DataModelConstants.Delivery;

namespace LogiTrack.Infrastructure.Data.DataModels
{
    [Comment("Delivery Entity")]
    public class Delivery
    {
        [Key]
        [Comment("Delivery identifier")]
        public int Id { get; set; }

        [Comment("Vehicle identifier")]
        public int VehicleId { get; set; }

        [Comment("Vehicle")]
        [ForeignKey(nameof(VehicleId))]
        public Vehicle Vehicle { get; set; } = null!;

        [Comment("Driver identifier")]
        public int DriverId { get; set; }

        [Comment("Driver")]
        [ForeignKey(nameof(DriverId))]
        public Driver Driver { get; set; } = null!;

        [Comment("Offer identifier")]
        public int OfferId { get; set; }

        [Comment("Offer")]
        [ForeignKey(nameof(OfferId))]
        public Offer Offer { get; set; } = null!;

        [Comment("Delivery status")]
        [StringLength(DeliveryStatusMaxLength)]
        [Required]
        public string Status { get; set; } = string.Empty;

        [Comment("Delivery total expenses")]
        [Range(DeliveryPriceMinValue, DeliveryPriceMaxValue)]
        public decimal TotalExpenses { get; set; }

        [Comment("Delivery total income")]
        [Range(DeliveryPriceMinValue, DeliveryPriceMaxValue)]
        public decimal Profit { get; set; }

        [Comment("Delivery reference number")]
        [Required]
        public string ReferenceNumber { get; set; } = string.Empty; 

        [Comment("Delivery trackings")]
        public IEnumerable<DeliveryTracking> DeliveryTrackings { get; set; } = new List<DeliveryTracking>();

        [Comment("Delivery cash registers")]
        public IEnumerable<CashRegister> CashRegisters { get; set; } = new List<CashRegister>();
    }
}

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static LogiTrack.Infrastructure.Data.DataConstants.DataModelConstants.CashRegister;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogiTrack.Infrastructure.Data.DataModels
{
    [Comment("Cash Register Entity")]
    public class CashRegister
    {
        [Key]
        [Comment("Cash Register identifier")]
        public int Id { get; set; }

        [Comment("Delivery identifier")]
        public int DeliveryId { get; set; }

        [Comment("Delivery")]
        [ForeignKey(nameof(DeliveryId))]
        public Delivery Delivery { get; set; } = null!;

        [Comment("Description of the cash register")]
        [Required]
        [StringLength(RegisterDescriptionMaxLength)]
        public string Description { get; set; } = string.Empty;

        [Comment("Type of the register")]
        [Required]
        [StringLength(RegisterTypeMaxLength)]
        public string Type { get; set; } = string.Empty;

        [Comment("Amount of the register")]
        [Required]
        [Range(RegisterAmountMinValue, RegisterAmountMinValue)]
        public decimal Amount { get; set; }

        [Comment("Date submitted")]
        [Required]
        public DateTime DateSubmitted { get; set; }

        [Comment("File identifier in Google drive")]
        public string FileId { get; set; } = string.Empty;
    }
}

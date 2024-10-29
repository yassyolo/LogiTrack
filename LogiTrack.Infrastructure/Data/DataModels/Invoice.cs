using LogiTrack.Infrastructure.Data.DataModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticsSystem.Infrastructure.Data.DataModels
{
    [Comment("Invoice Entity")]
    public class Invoice
    {
        [Key]
        [Comment("Invoice identifier")]
        public int Id { get; set; }

        [Comment("Delivery identifier")]
        public int DeliveryId { get; set; }

        [Comment("Delivery")]
        [ForeignKey(nameof(DeliveryId))]
        public Delivery Delivery { get; set; } = null!;

        [Comment("Invoice number")]
        [Required]
        public string InvoiceNumber { get; set; } = string.Empty;

        [Comment("Invoice date")]
        [Required]
        public DateTime InvoiceDate { get; set; }

        [Required]
        [Comment("Invoice description")]
        public string Description { get; set; } = string.Empty;

        [Comment("Is invoice paid")]
        public bool IsPaid { get; set; }
    }
}

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

        [Comment("File identifier in Google drive")]
        public string FileId { get; set; } = string.Empty;

        [Comment("Invoice status")]
        public string Status { get; set; } = string.Empty;

        [Comment("Is invoice paid on time")]
        public bool? PaidOnTime { get; set; }

        [Comment("Invoice paid date")]
        public DateTime? PaidDate { get; set; }
    }
}

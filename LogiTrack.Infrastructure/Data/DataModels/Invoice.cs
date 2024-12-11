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
        public string Status { get; set; } = string.Empty;
        public bool? PaidOnTime { get; set; }
        public DateTime? PaidDate { get; set; }
    }
}

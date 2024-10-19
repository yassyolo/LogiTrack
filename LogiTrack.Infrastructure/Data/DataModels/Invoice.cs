using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LogiTrack.Infrastructure.Data.DataConstants.DataModelConstants;

namespace LogisticsSystem.Infrastructure.Data.DataModels
{
    [Comment("Invoice Entity")]
    public class Invoice
    {
        [Key]
        [Comment("Invoice identifier")]
        public int Id { get; set; }

        [Comment("Offer identifier")]
        public int OfferId { get; set; }

        [Comment("Offer")]
        [ForeignKey(nameof(OfferId))]
        public Offer Offer { get; set; } = null!;

        [Comment("Invoice number")]
        [Required]
        public string InvoiceNumber { get; set; } = string.Empty;

        [Comment("Invoice date")]
        [Required]
        public DateTime InvoiceDate { get; set; }
    }
}

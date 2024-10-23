using LogisticsSystem.Infrastructure.Data.DataModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static LogiTrack.Infrastructure.Data.DataConstants.DataModelConstants.CalendarEvent;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogiTrack.Infrastructure.Data.DataModels
{
    [Comment("Calendar Event Entity")]
    public class CalendarEvent
    {
        [Key]
        [Comment("Calendar Event identifier")]
        public int Id { get; set; }

        [Comment("Title")]
        [StringLength(EventTitleMaxLength)]
        [Required]
        public string Title { get; set; }  = string.Empty;

        [Comment("Date")]
        [Required]
        public DateTime Date { get; set; }

        [Required]
        [Comment("Event Type")]
        [StringLength(EventTypeMaxLength)]
        public string EventType { get; set; } = string.Empty;

        [Comment("Client Company identifier")]
        public int ClientCompanyId { get; set; }

        [Comment("Client Company")]
        [ForeignKey(nameof(ClientCompanyId))]
        public ClientCompany ClientCompany { get; set; } = null!;
    }
}

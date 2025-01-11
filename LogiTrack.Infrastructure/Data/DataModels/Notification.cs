using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogiTrack.Infrastructure.Data.DataModels
{
    [Comment("Notification Entity")]
    public class Notification
    {
        [Key]
        [Comment("Notification identifier")]
        public int Id { get; set; }

        [Comment("Notification message")]
        [Required]
        public string Message { get; set; } = string.Empty;

        [Comment("Notification title")]
        [Required]
        public string Title { get; set; } = string.Empty;

        [Comment("Notification date")]
        [Required]
        public DateTime Date { get; set; }

        [Comment("User identifier")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        [Comment("User")]
        public IdentityUser User { get; set; } = null!;

        [Comment("Notification is read")]
        public bool IsRead { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static LogiTrack.Infrastructure.Data.DataConstants.DataModelConstants.Driver;

namespace LogiTrack.Infrastructure.Data.DataModels
{
    [Comment("Driver Entity")]
    public class Driver
    {
        [Key]
        [Comment("Driver identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Driver's name")]
        [StringLength(DriverNameMaxLength)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Comment("Driver's license number")]
        [StringLength(DriverLicenceNumberMaxLength)]
        public string LicenseNumber { get; set; } = string.Empty;

        [Required]
        [Comment("Driver's license expiry date")]
        public DateTime LicenseExpiryDate { get; set; }

        [Comment("User")]
        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;

        [Comment("User identifier")]
        public string UserId { get; set; } = string.Empty;

        [Required]
        [Comment("Driver's salary")]
        [Range(SalaryMinValue, SalaryMaxValue)]
        public decimal Salary { get; set; }

        [Required]
        [Comment("Driver's age")]
        [Range(AgeMinValue, AgeMaxValue)]
        public int Age { get; set; }

        [Required]
        [Comment("Driver's year of experience")]
        [Range(YearOfExperienceMinValue, YearOfExperienceMaxValue)]
        public int YearOfExperience { get; set; }

        [Required]
        [Comment("Driver's months of experience")]
        [Range(MonthsOfExperienceMinValue, MonthsOfExperienceMaxValue)]
        public int MonthsOfExperience { get; set; }

        [Required]
        [Comment("Is driver available")]
        public bool IsAvailable { get; set; }

        [Comment("Driver's preferrences")]
        [StringLength(PreferrencesMaxLength)]
        public string? Preferrences { get; set; }

        [Comment("Driver's deliveries")]
        public IEnumerable<Delivery> Deliveries { get; set; } = new List<Delivery>();
    }
}

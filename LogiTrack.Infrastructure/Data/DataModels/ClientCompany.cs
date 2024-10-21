using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static LogiTrack.Infrastructure.Data.DataConstants.DataModelConstants.ClientCompany;

namespace LogisticsSystem.Infrastructure.Data.DataModels
{
    [Comment("Client Company Entity")]
    public class ClientCompany
    {
        [Key]
        public int Id { get; set; }

        [Comment("User identifier")]
        public string? UserId { get; set; } 

        [ForeignKey(nameof(UserId))]
        [Comment("User")]
        public IdentityUser? User { get; set; } 

        [Required]
        [StringLength(CompanyNameMaxLength)]
        [Comment("Company Name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Comment("Company's registration status")]
        [StringLength(100)]
        public string RegistrationStatus { get; set; } = string.Empty;

        [Required]
        [Comment("Person whom we are contacting")]
        [StringLength(ContactPersonMaxLength)]
        public string ContactPerson { get; set; } = string.Empty;

        [Required]
        [Comment("Company's alternative phone number")]
        [StringLength(PhoneNumberMaxLength)]
        public string AlternativePhoneNumber { get; set; } = string.Empty;

        [Required]
        [Comment("Company's registration number")]
        [StringLength(RegistrationNumberMaxLength)]
        public string RegistrationNumber { get; set; } = string.Empty;

        [Required]
        [Comment("Company's industry")]
        [StringLength(IndustryMaxLength)]
        public string Industry { get; set; } = string.Empty;

        [Required]
        [Comment("Company's address")]
        [StringLength(StreetMaxLength)]
        public string Street { get; set; } = string.Empty;

        [Required]
        [Comment("Company's city")]
        [StringLength(CityMaxLength)]
        public string City { get; set; } = string.Empty;

        [Required]
        [Comment("Company's postal code")]
        [StringLength(PostalCodeMaxLength)]
        public string PostalCode { get; set; } = string.Empty;

        [Required]
        [Comment("Company's country")]
        [StringLength(CountryMaxLength)]
        public string Country { get; set; } = string.Empty;

        [Required]
        [Comment("Registration created at")]
        public DateTime CreatedAt { get; set; }

        [Comment("Company's requests")]
        public IEnumerable<Request> Requests { get; set; } = new List<Request>();

        [Comment("Company's offers")]
        public IEnumerable<Offer> Offers { get; set; } = new List<Offer>();

        [Comment("Company's invoices")]
        public IEnumerable<Invoice> Invoices { get; set; } = new List<Invoice>();
    }
}

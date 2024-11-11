using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static LogiTrack.Infrastructure.Data.DataConstants.DataModelConstants.Address;

namespace LogiTrack.Infrastructure.Data.DataModels
{
    [Comment("Address Entity")]
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(StreetMaxLength)]
        [Comment("Street name and number")]
        public string Street { get; set; } = string.Empty;

        [Required]
        [StringLength(CityMaxLength)]
        [Comment("County or region")]
        public string County { get; set; } = string.Empty;

        [Required]
        [StringLength(CountryMaxLength)]
        [Comment("City name")]
        public string City { get; set; } = string.Empty;

        [Comment("Company's postal code")]
        [StringLength(PostalCodeMaxLength)]
        public string? PostalCode { get; set; }

        [Range(LatitudeMinValue, LatitudeMaxValue)]
        [Comment("Latitude of the address")]
        public string? Latitude { get; set; }

        [Range(LongitudeMinValue, LongitudeMaxValue)]
        [Comment("Longitude of the address")]
        public string? Longitude { get; set; }
    }
}

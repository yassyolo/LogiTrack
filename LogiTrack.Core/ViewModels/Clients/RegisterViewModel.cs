using System.ComponentModel.DataAnnotations;
using static LogiTrack.Core.Constants.MessageConstants.ErrorMessages;
using static LogiTrack.Infrastructure.Data.DataConstants.DataModelConstants.ClientCompany;

namespace LogiTrack.Core.ViewModels.Clients
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = RequiredFieldErrorMessage)]
        [StringLength(CompanyNameMaxLength, MinimumLength = CompanyNameMinLength, ErrorMessage = LengthErrorMessage)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredFieldErrorMessage)]
        [StringLength(ContactPersonMaxLength, MinimumLength = ContactPersonMinLength, ErrorMessage = LengthErrorMessage)]
        public string ContactPerson { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredFieldErrorMessage)]
        [EmailAddress(ErrorMessage = InvalidEmailErrorMessage)]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredFieldErrorMessage)]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength, ErrorMessage = LengthErrorMessage)]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredFieldErrorMessage)]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength, ErrorMessage = LengthErrorMessage)]
        public string AlternativePhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredFieldErrorMessage)]
        [StringLength(RegistrationNumberMaxLength, MinimumLength = RegistrationNumberMinLength, ErrorMessage = LengthErrorMessage)]
        public string RegistrationNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredFieldErrorMessage)]
        [StringLength(IndustryMaxLength, MinimumLength = IndustryMinLength, ErrorMessage = LengthErrorMessage)]
        public string Industry { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredFieldErrorMessage)]
        [StringLength(StreetMaxLength, MinimumLength = StreetMinLength, ErrorMessage = LengthErrorMessage)]
        public string Street { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredFieldErrorMessage)]
        [StringLength(CityMaxLength, MinimumLength = CityMinLength, ErrorMessage = LengthErrorMessage)]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredFieldErrorMessage)]
        [StringLength(PostalCodeMaxLength, MinimumLength = PostalCodeMinLength, ErrorMessage = LengthErrorMessage)]
        public string PostalCode { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredFieldErrorMessage)]
        [StringLength(CountryMaxLength, MinimumLength = CountryMinLength, ErrorMessage = LengthErrorMessage)]
        public string Country { get; set; } = string.Empty;
    }
}

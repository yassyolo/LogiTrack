using static LogiTrack.Infrastructure.Data.DataConstants.DataModelConstants.Driver;
using static LogiTrack.Core.Constants.MessageConstants.ErrorMessages;
using System.ComponentModel.DataAnnotations;
namespace LogiTrack.Core.ViewModels.Driver
{
    public class SearchDriverByLicenseNumberViewModel
    {
        [Required(ErrorMessage = RequiredFieldErrorMessage)]
       // [StringLength(DriverLicenceNumberMaxLength, MinimumLength = DriverLicenceNumberMinLength, ErrorMessage = LengthErrorMessage)]

        public string LicenseNumber { get; set; } = string.Empty;
    }
}

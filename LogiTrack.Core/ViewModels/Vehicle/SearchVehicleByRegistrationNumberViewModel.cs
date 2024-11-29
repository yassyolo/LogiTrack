using static LogiTrack.Infrastructure.Data.DataConstants.DataModelConstants.Vehicle;
using static LogiTrack.Core.Constants.MessageConstants.ErrorMessages;
using System.ComponentModel.DataAnnotations;
namespace LogiTrack.Core.ViewModels.Vehicle
{
    public class SearchVehicleByRegistrationNumberViewModel
    {
        [Required(ErrorMessage = RequiredFieldErrorMessage)]
        //[StringLength(RegistartionNumberMaxLength, MinimumLength = RegistartionNumberMinLength, ErrorMessage = LengthErrorMessage)]
        public string RegistrationNumber { get; set; } = string.Empty;
    }
}

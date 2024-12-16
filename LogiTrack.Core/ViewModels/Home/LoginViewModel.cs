using System.ComponentModel.DataAnnotations;
using static LogiTrack.Core.Constants.MessageConstants.ErrorMessages;

namespace LogiTrack.Core.ViewModels.Home
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = RequiredFieldErrorMessage)]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredFieldErrorMessage)]
        public string Password { get; set; } = string.Empty;
    }
}

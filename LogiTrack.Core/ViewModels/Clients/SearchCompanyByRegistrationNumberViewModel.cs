using System.ComponentModel.DataAnnotations;
using static LogiTrack.Infrastructure.Data.DataConstants.DataModelConstants.CashRegister;
using static LogiTrack.Core.Constants.MessageConstants.ErrorMessages;

namespace LogiTrack.Core.ViewModels.Clients
{
    public class SearchCompanyByRegistrationNumberViewModel
    {
        [Required(ErrorMessage = RequiredFieldErrorMessage)]

        public string RegistrationNumber { get; set; } = string.Empty;
    }
}

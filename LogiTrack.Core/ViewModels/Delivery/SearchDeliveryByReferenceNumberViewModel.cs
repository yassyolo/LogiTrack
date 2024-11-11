using System.ComponentModel.DataAnnotations;
using static LogiTrack.Core.Constants.MessageConstants.ErrorMessages;
using static LogiTrack.Infrastructure.Data.DataConstants.DataModelConstants.Delivery;

namespace LogiTrack.Core.ViewModels.Delivery
{
    public class SearchDeliveryByReferenceNumberViewModel
    {
        [Required(ErrorMessage = RequiredFieldErrorMessage)]
        [StringLength(ReferenceNumberMaxLength, MinimumLength = ReferenceNumberMinLength, ErrorMessage = LengthErrorMessage)]
        public string ReferenceNumber { get; set; } = string.Empty;
    }
}

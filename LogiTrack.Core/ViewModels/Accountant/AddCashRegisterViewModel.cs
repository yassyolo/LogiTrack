using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using static LogiTrack.Infrastructure.Data.DataConstants.DataModelConstants.CashRegister;
using static LogiTrack.Core.Constants.MessageConstants.ErrorMessages;
using System.Threading.Tasks;

namespace LogiTrack.Core.ViewModels.Accountant
{
    public class AddCashRegisterViewModel
    {
        public int DeliveryId { get; set; }

        [Required(ErrorMessage = RequiredFieldErrorMessage)]
        [StringLength(RegisterDescriptionMaxLength, MinimumLength = RegisterDescriptionMinLength, ErrorMessage = LengthErrorMessage)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredFieldErrorMessage)]
        [StringLength(RegisterTypeMaxLength, MinimumLength = RegisterTypeMinLength, ErrorMessage = LengthErrorMessage)]
        public string Type { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredFieldErrorMessage)]
        [Range(RegisterAmountMinValue, RegisterAmountMinValue, ErrorMessage = InvalidAmountErrorMessage)]
        public decimal Amount { get; set; }
    }
}

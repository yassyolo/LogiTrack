using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static LogiTrack.Infrastructure.Data.DataConstants.DataModelConstants.PricePerSize;
using static LogiTrack.Core.Constants.MessageConstants.ErrorMessages;

namespace LogiTrack.Core.ViewModels.Accountant
{
    public class AddPricesForVehicleViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredFieldErrorMessage)]
        [Range(PriceMinValue, PriceMaxValue, ErrorMessage = InvalidPriceErrorMessage)]
        public decimal DomesticPriceForNotSharedTruck { get; set; }

        [Required(ErrorMessage = RequiredFieldErrorMessage)]
        [Range(PriceMinValue, PriceMaxValue, ErrorMessage = InvalidPriceErrorMessage)]
        public decimal DomesticPriceForSharedTruck { get; set; }

        [Required(ErrorMessage = RequiredFieldErrorMessage)]
        [Range(PriceMinValue, PriceMaxValue, ErrorMessage = InvalidPriceErrorMessage)]
        public decimal InternationalPriceForNotSharedTruck { get; set; }

        [Required(ErrorMessage = RequiredFieldErrorMessage)]
        [Range(PriceMinValue, PriceMaxValue, ErrorMessage = InvalidPriceErrorMessage)]
        public decimal InternationalPriceForSharedTruck { get; set; }
    }
}

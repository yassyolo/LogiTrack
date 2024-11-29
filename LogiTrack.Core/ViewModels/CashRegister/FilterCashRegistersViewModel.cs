using System.ComponentModel.DataAnnotations;
using static LogiTrack.Infrastructure.Data.DataConstants.DataModelConstants.ClientCompany;
using static LogiTrack.Core.Constants.MessageConstants.ErrorMessages;
using static LogiTrack.Infrastructure.Data.DataConstants.DataModelConstants.Delivery;
using static LogiTrack.Infrastructure.Data.DataConstants.DataModelConstants.SearchTerm;
using static LogiTrack.Infrastructure.Data.DataConstants.DataModelConstants.CashRegister;


namespace LogiTrack.Core.ViewModels.CashRegister
{
    public class FilterCashRegistersViewModel
    {
        public List<CashRegisterIndexViewModel> CashRegisters { get; set; } = new List<CashRegisterIndexViewModel>();
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        [StringLength(CompanyNameMaxLength, MinimumLength = CompanyNameMinLength, ErrorMessage = LengthErrorMessage)]
        public string? CompanyName { get; set; }

        [StringLength(ReferenceNumberMaxLength, MinimumLength = ReferenceNumberMinLength, ErrorMessage = LengthErrorMessage)]
        public string? DeliveryReferenceNumber { get; set; }

        [StringLength(SearchTermMaxLength, MinimumLength = SearchTermMinLength, ErrorMessage = LengthErrorMessage)]
        public string? SearchTerm { get; set; }

        [StringLength(RegisterTypeMaxLength, MinimumLength = RegisterTypeMinLength, ErrorMessage = LengthErrorMessage)]
        public string? Type { get; set; } = string.Empty;
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
    }
}

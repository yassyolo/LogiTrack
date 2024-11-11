using System.ComponentModel.DataAnnotations;
using static LogiTrack.Core.Constants.MessageConstants.ErrorMessages;
using static LogiTrack.Infrastructure.Data.DataConstants.DataModelConstants.ClientCompany;
using static LogiTrack.Infrastructure.Data.DataConstants.DataModelConstants.SearchTerm;


namespace LogiTrack.Core.ViewModels.Clients
{
    public class SearchClientsViewModel
    {
        [StringLength(CompanyNameMaxLength, MinimumLength = CompanyNameMinLength, ErrorMessage = LengthErrorMessage)]
        public string? Name { get; set; }

        [StringLength(SearchTermMaxLength, MinimumLength = SearchTermMinLength, ErrorMessage = LengthErrorMessage)]
        public string? SearchTerm { get; set; }

        [StringLength(RegistrationNumberMaxLength, MinimumLength = RegistrationNumberMinLength, ErrorMessage = LengthErrorMessage)]
        public string? RegistrationNumber { get; set; }
        public bool Active { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
        public List<ClientsForClientregisterViewModel> Clients { get; set; } = new List<ClientsForClientregisterViewModel>();
    }
}

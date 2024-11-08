
using LogiTrack.Core.ViewModels.Clients;
using LogiTrack.Core.ViewModels.Logistics;
using LogiTrack.Infrastructure.Data.DataModels;
using Microsoft.AspNetCore.Identity;

namespace LogiTrack.Core.Contracts
{
    public interface IClientsService
    {
        Task<IdentityUser> ApprovePendingRegistrationForCompanyWithIdAsync(int id);
        Task BookOfferAsync(int id, string username);
        Task<bool> CompanyWithIdExistsAsync(int id);
        Task<ClientsDashboardViewModel?> GetClientCompanyDashboardAsync(string username);
        Task<List<CalendarEventViewModel>?> GetClientCompanyEventsAsync(string username);
        Task<List<ClientsForClientregisterViewModel>> GetClientsForClientsRegisterAsync(bool? active, string? name, string? email, string? registrationNumber);
        Task<List<ClientsForClientregisterViewModel>> GetClientsForClientsRegisterBySearchTermAsync(string? searchTerm);
        Task<ContactDetailsViewModel?> GetCompanyContactDetailsAsync(string username);
        Task<CompanyDetailsViewModel?> GetCompanyDetailsAsync(string username);
        Task<string?> GetLogisticsCompanyDashboardAsync();
        Task<NewCompanyDetailsForLogisticsViewModel?> GetNewCompanyDetailsForLogisticsAsync(int id);
        Task<OfferDetailsViewModel?> GetOfferDetailsAsync(int id);
        Task<int> GetOfferIdByOfferNumberAsync(string offerNumber);
        Task<List<OfferForSearchViewModel>?> GetOffersForCompanyAsync(string username, string? deliveryAddress = null, string? pickupAddress = null, DateTime? startDate = null, DateTime? endDate = null, decimal? minPrice = null, decimal? maxPrice = null, bool? isApproved = null);
        Task<List<OfferForSearchViewModel>?> GetOffersForCompanyBySearchTermAsync(string username, string? searchTerm = null);
        Task<List<PendingRegistrationsViewModel>?> GetPendingRegistrationsAsync();
        Task<RequestDetailsViewModel?> GetRequestDetailsAsync(int id);
        Task<IEnumerable<RequestsForSearchViewModel>> GetRequestsForCompanyAsync(string companyUsername, DateTime? startDate = null, DateTime? endDate = null, string? pickupAddress = null, string? deliveryAddress = null, bool? isApproved = null);
        Task<IEnumerable<RequestsForSearchViewModel>> GetRequestsForCompanyBySearchTermAsync(string companyUsername, string? searchTerm);
        Task<bool> LogisticsUserWithUsernameExistsAsync(string username);
        Task MakeRequestAsync(MakeRequestViewModel model, string userEmail);
        Task<bool> OfferWithCompanyExistsAsync(int id, string username);
        Task<bool> OfferWithIdExistsAsync(int id);
        Task RegisterClientCompanyAsync(RegisterViewModel model, IdentityUser user);
        Task<IdentityUser> RegisterUserAsync(RegisterViewModel model);
        Task RejectPendingRegistrationForCompanyWithIdAsync(int id);
        Task<bool> RequestWithCompanyExistsAsync(int id, string username);
        Task<bool> RequestWithIdExistsAsync(int id);
        Task<bool> UserWithEmailExistsAsync(string email);
        Task<bool> UserWithPhoneNumberExistsAsync(string phoneNumber);
    }
}

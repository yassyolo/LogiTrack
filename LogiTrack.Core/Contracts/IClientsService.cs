
using LogiTrack.Core.ViewModels.Clients;
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
        Task<ContactDetailsViewModel?> GetCompanyContactDetailsAsync(string username);
        Task<CompanyDetailsViewModel?> GetCompanyDetailsAsync(string username);
        Task<List<OfferForSearchViewModel>?> GetOffersForCompanyAsync(string username, string? deliveryAddress = null, string? pickupAddress = null, DateTime? startDate = null, DateTime? endDate = null);
        Task<List<PendingRegistrationsViewModel>?> GetPendingRegistrationsAsync();
        Task<IEnumerable<RequestsForSearchViewModel>> GetRequestsForCompanyAsync(string companyUsername, DateTime? startDate = null, DateTime? endDate = null, string? pickupAddress = null, string? deliveryAddress = null, bool? isApproved = null);
        Task MakeRequestAsync(MakeRequestViewModel model, string userEmail);
        Task<bool> OfferWithCompanyExistsAsync(int id, string username);
        Task<bool> OfferWithIdExistsAsync(int id);
        Task RegisterClientCompanyAsync(RegisterViewModel model, IdentityUser user);
        Task<IdentityUser> RegisterUserAsync(RegisterViewModel model);
        Task RejectPendingRegistrationForCompanyWithIdAsync(int id);
        Task<bool> UserWithEmailExistsAsync(string email);
        Task<bool> UserWithPhoneNumberExistsAsync(string phoneNumber);
    }
}


using LogiTrack.Core.ViewModels.Clients;
using LogiTrack.Infrastructure.Data.DataModels;
using Microsoft.AspNetCore.Identity;

namespace LogiTrack.Core.Contracts
{
    public interface IClientsService
    {
        Task<IdentityUser> ApprovePendingRegistrationForCompanyWithIdAsync(int id);
        Task<bool> CompanyWithIdExistsAsync(int id);
        Task<DashboardViewModel?> GetClientCompanyDashboardAsync(string username);
        Task<List<CalendarEventViewModel>?> GetClientCompanyEventsAsync(string username);
        Task<ContactDetailsViewModel?> GetCompanyContactDetailsAsync(string username);
        Task<CompanyDetailsViewModel?> GetCompanyDetailsAsync(string username);
        Task<List<PendingRegistrationsViewModel>?> GetPendingRegistrationsAsync();
        Task MakeRequestAsync(MakeRequestViewModel model, string userEmail);
        Task RegisterClientCompanyAsync(RegisterViewModel model, IdentityUser user);
        Task<IdentityUser> RegisterUserAsync(RegisterViewModel model);
        Task RejectPendingRegistrationForCompanyWithIdAsync(int id);
        Task<bool> UserWithEmailExistsAsync(string email);
        Task<bool> UserWithPhoneNumberExistsAsync(string phoneNumber);
    }
}

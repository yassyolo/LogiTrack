using LogiTrack.Core.ViewModels.Clients;
using Microsoft.AspNetCore.Identity;

namespace LogiTrack.Core.Contracts
{
    public interface IUserService
    {
        Task<bool> LogisticsUserWithUsernameExistsAsync(string username);
        Task<IdentityUser> ApprovePendingRegistrationForCompanyWithIdAsync(int id);
        Task<string> GetCompanyUsernameByIdAsync(int id);
        Task RegisterClientCompanyAsync(RegisterViewModel model, IdentityUser user);
        Task<IdentityUser> RegisterUserAsync(RegisterViewModel model);
        Task<bool> UserWithEmailExistsAsync(string email);
        Task<bool> UserWithPhoneNumberExistsAsync(string phoneNumber);
    }
}

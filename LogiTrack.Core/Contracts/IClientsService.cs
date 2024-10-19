
using LogiTrack.Core.ViewModels.Clients;
using Microsoft.AspNetCore.Identity;

namespace LogiTrack.Core.Contracts
{
    public interface IClientsService
    {
        Task MakeRequestAsync(MakeRequestViewModel model, string userEmail);
        Task RegisterClientCompanyAsync(RegisterViewModel model, IdentityUser user);
        Task<IdentityUser> RegisterUserAsync(RegisterViewModel model);
        Task<bool> UserWithEmailExistsAsync(string email);
        Task<bool> UserWithPhoneNumberExistsAsync(string phoneNumber);
    }
}

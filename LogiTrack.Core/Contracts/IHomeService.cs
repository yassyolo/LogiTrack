using Microsoft.AspNetCore.Identity;

namespace LogiTrack.Core.Contracts
{
    public interface IHomeService
    {
        Task<IdentityUser?> GetUserByUsernameAsync(string username);
        Task MarkNotificationAsReadAsync(int id);
        Task<bool> NotificationWithIdExistsdAsync(int id);
    }
}

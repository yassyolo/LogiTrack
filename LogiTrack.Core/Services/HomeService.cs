using LogiTrack.Core.Contracts;
using LogiTrack.Infrastructure.Data.DataModels;
using LogiTrack.Infrastructure.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LogiTrack.Core.Services
{
    public class HomeService : IHomeService
    {
        private readonly IRepository repository;

        public HomeService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IdentityUser?> GetUserByEmailAsync(string email)
        {
            return await repository.AllReadonly<IdentityUser>().FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task MarkNotificationAsReadAsync(int id)
        {
            var notification = await repository.All<Notification>().FirstOrDefaultAsync(x => x.Id == id);
            notification.IsRead = true;
            await repository.SaveChangesAsync();
        }

        public async Task<bool> NotificationWithIdExistsdAsync(int id)
        {
            return await repository.AllReadonly<Notification>().AnyAsync(x => x.Id == id);
        }
    }
}

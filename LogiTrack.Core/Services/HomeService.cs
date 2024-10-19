using LogiTrack.Core.Contracts;
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
    }
}

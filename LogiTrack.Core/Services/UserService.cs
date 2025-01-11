using LogiTrack.Core.Constants;
using LogiTrack.Core.Contracts;
using LogiTrack.Core.ViewModels.Clients;
using LogiTrack.Core.ViewModels.Notifications;
using LogiTrack.Infrastructure.Data.DataModels;
using LogiTrack.Infrastructure.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LogiTrack.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository repository;

        public UserService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<bool> LogisticsUserWithUsernameExistsAsync(string username)
        {
            return await repository.AllReadonly<IdentityUser>().AnyAsync(x => x.UserName == username);
        }

        public async Task<bool> UserWithUsernameExistsAsync(string username)
        {
            return await repository.AllReadonly<IdentityUser>().AnyAsync(x => x.UserName == username);
        }

        public async Task<IdentityUser> ApprovePendingRegistrationForCompanyWithIdAsync(int id)
        {
            var company = await repository.All<LogisticsSystem.Infrastructure.Data.DataModels.ClientCompany>().Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id);
            company.RegistrationStatus = StatusConstants.Approved;
            await repository.SaveChangesAsync();
            return company.User;
        }

        public async Task RegisterClientCompanyAsync(RegisterViewModel model, IdentityUser user)
        {
            var address = new Address
            {
                Street = model.Street,
                City = model.City,
                PostalCode = model.PostalCode,
                County = model.Country
            };
            await repository.AddAsync(address);
            await repository.SaveChangesAsync();
            var client = new LogisticsSystem.Infrastructure.Data.DataModels.ClientCompany
            {
                Name = model.Name,
                AddressId = address.Id,
                Industry = model.Industry,
                AlternativePhoneNumber = model.AlternativePhoneNumber,
                RegistrationNumber = model.RegistrationNumber,
                RegistrationStatus = StatusConstants.Pending,
                ContactPerson = model.ContactPerson,
                UserId = user.Id,
                CreatedAt = DateTime.Now,
            };

            await repository.AddAsync(client);
            await repository.SaveChangesAsync();
        }

        public async Task<IdentityUser> RegisterUserAsync(RegisterViewModel model)
        {
            var user = new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber
            };
            await repository.AddAsync(user);
            await repository.SaveChangesAsync();
            return user;
        }

        public async Task<bool> UserWithEmailExistsAsync(string email)
        {
            return await repository.AllReadonly<IdentityUser>().AnyAsync(x => x.Email == email);
        }

        public async Task<bool> UserWithPhoneNumberExistsAsync(string phoneNumber)
        {
            return await repository.AllReadonly<IdentityUser>().AnyAsync(x => x.PhoneNumber == phoneNumber);
        }

        public async Task<string> GetCompanyUsernameByIdAsync(int id)
        {
            return await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.ClientCompany>().Where(x => x.Id == id).Select(x => x.User.UserName).FirstOrDefaultAsync();
        }

        public async Task<List<NotificationViewModel>?> GetNotificationsForUserAsync(string username)
        {
            return await repository.AllReadonly<Notification>().Where(x => x.User.UserName == username).Select(x => new NotificationViewModel
            {
                Id = x.Id,
                Message = x.Message,
                Title = x.Title,
                Date = x.Date.ToString("dd-MM-yyyy"),
                IsRead = x.IsRead
            }).ToListAsync();
        }

        public async Task<bool> NotificationWithIdExistsForUserAsync(int id, string username)
        {
            return await repository.AllReadonly<Notification>().AnyAsync(x => x.Id == id && x.User.UserName == username);
        }

        public async Task<IdentityUser> GetClientUserByRequestIdAsync(int requestId)
        {
            return await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Request>().Include(x => x.ClientCompany).ThenInclude(x => x.User).Where(x => x.Id == requestId).Select(x => x.ClientCompany.User).FirstOrDefaultAsync();
        }
    }
}

using LogiTrack.Core.Contracts;
using LogiTrack.Core.ViewModels.Driver;
using LogiTrack.Infrastructure.Data.DataModels;
using LogiTrack.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace LogiTrack.Core.Services
{
    public class DriverService : IDriverService
    {
        private readonly IRepository repository;

        public DriverService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<bool> DriverHasDeliveryAsync(string username, int deliveryId)
        {
            return await repository.AllReadonly<Delivery>().AnyAsync(x => x.Id == deliveryId && x.Driver.User.UserName == username);
        }

        public async Task<bool> DriverWithUsernameExistsAsync(string username)
        {
            return await repository.AllReadonly<Driver>().AnyAsync(x => x.User.UserName == username);
        }

        public async Task<DriverDetailsViewModel?> GetDriverDetailsAsync(string username)
        {
            return await repository.AllReadonly<Driver>().Where(x => x.User.UserName == username)
                .Select(x => new DriverDetailsViewModel
                {
                    Name = x.Name,                   
                    Username = x.User.UserName,
                    Salary = x.Salary.ToString(),
                    Age = x.Age.ToString(),
                    YearOfExperience = x.YearOfExperience.ToString(),
                    MonthsOfExperience = x.MonthsOfExperience.ToString(),
                    Preferrences = x.Preferrences
                }).FirstOrDefaultAsync();
        }

        public async Task<LicenseViewModel?> GetDriversLicenseAsync(string username)
        {
            return await repository.AllReadonly<Driver>().Where(x => x.User.UserName == username)
                .Select(x => new LicenseViewModel
                {
                    LicenseNumber = x.LicenseNumber,
                    LicenseExpiryDate = x.LicenseExpiryDate,
                }).FirstOrDefaultAsync();
        }
    }
}

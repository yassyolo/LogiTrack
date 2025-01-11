using LogiTrack.Core.ViewModels.Delivery;
using LogiTrack.Core.ViewModels.Driver;
using Microsoft.AspNetCore.Identity;

namespace LogiTrack.Core.Contracts
{
    public interface IDriverService
    {
        Task<bool> DriverHasDeliveryAsync(string username, int deliveryId);
        Task<bool> DriverWithUsernameExistsAsync(string username);
        Task<DriverViewModel?> GetDriverDetailsAsync(string username);
        Task<LicenseViewModel?> GetDriversLicenseAsync(string username);
        Task AddStatusForDeliveryAsync(int deliveryId, AddStatusViewModel model, string username, string address);
        Task<List<DriverForLogisticsViewModel>> GetDriversAsync(string? name = null, string? licenseNumber = null, bool? isAvailable = null, decimal? minSalary = null, decimal? maxSalary = null);
        Task<List<DriverForLogisticsViewModel>> GetDriversBySearchtermAsync(string? searchTerm);
        Task<bool> DriverWithIdExistsAsync(int id);
        Task<DriverForLogisticsViewModel?> GetDriverDetailsForLogisticsAsync(int id);
        Task<int> GetDriverByLicenseNumberAsync(string licenseNumber);
        Task<IdentityUser> AddDriverUserAsync(AddDriverViewModel model);
        Task AddDriverAsync(AddDriverViewModel model, string id);
        Task<AddDriverViewModel?> GetDriverForEditAsync(int id);
        Task EditDriverAsync(int id, AddDriverViewModel model);
        
    }
}

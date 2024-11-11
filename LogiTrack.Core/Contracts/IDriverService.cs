
using LogiTrack.Core.ViewModels.Delivery;
using LogiTrack.Core.ViewModels.Driver;

namespace LogiTrack.Core.Contracts
{
    public interface IDriverService
    {
        Task<bool> DriverHasDeliveryAsync(string username, int deliveryId);
        Task<bool> DriverWithUsernameExistsAsync(string username);
        Task<ViewModels.Driver.DriverViewModel?> GetDriverDetailsAsync(string username);
        Task<LicenseViewModel?> GetDriversLicenseAsync(string username);
        Task AddStatusForDeliveryAsync(int deliveryId, AddStatusViewModel model, string username, string address);
        Task<DriverDashboardViewModel?> GetDriverDashboardAsync(string username);
        Task<List<DriverForLogisticsViewModel>> GetDriversAsync(string? name = null, string? licenseNumber = null, bool? isAvailable = null, string? salary = null);
        Task<List<DriverForLogisticsViewModel>> GetDriversBySearchtermAsync(string? searchTerm);
        Task<bool> DriverWithIdExistsAsync(int id);
        Task<DriverForLogisticsViewModel?> GetDriverDetailsForLogisticsAsync(int id);
    }
}

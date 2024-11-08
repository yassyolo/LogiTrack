
using LogiTrack.Core.ViewModels.Delivery;
using LogiTrack.Core.ViewModels.Driver;

namespace LogiTrack.Core.Contracts
{
    public interface IDriverService
    {
        Task<bool> DriverHasDeliveryAsync(string username, int deliveryId);
        Task<bool> DriverWithUsernameExistsAsync(string username);
        Task<DriverDetailsViewModel?> GetDriverDetailsAsync(string username);
        Task<LicenseViewModel?> GetDriversLicenseAsync(string username);
        Task AddStatusForDeliveryAsync(int deliveryId, AddStatusViewModel model, string username, string address);
        Task<DriverDashboardViewModel?> GetDriverDashboardAsync(string username);
    }
}

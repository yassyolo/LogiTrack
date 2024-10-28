
using LogiTrack.Core.ViewModels;
using LogiTrack.Core.ViewModels.Accountant;
using LogiTrack.Core.ViewModels.Delivery;
using LogiTrack.Core.ViewModels.Driver;

namespace LogiTrack.Core.Contracts
{
    public interface IDeliveryService
    {
        Task AddCashRegisterForDeliveryAsync(int id, AddCashRegisterViewModel model, Microsoft.AspNetCore.Http.IFormFile file);
        Task AddStatusForDeliveryAsync(int id, AddStatusViewModel model, string username);
        Task<bool> DeliveryWithIdExistsAsync(int deliveryId);
        Task<bool> DriverHasDeliveryAsync(string username, int id);
        Task<bool> DriverWithUsernameExistsAsync(string username);
        Task<List<CashRegisterIndexViewModel>> GetCashRegistersForDeliveryAsync(int id, DateTime? startDate, DateTime? endDate, string type);
        Task<int> GetDeliveryByReferenceNumberAsync(string referenceNumber);
        Task<DeliveryForAccountantViewModel> GetDeliveryDetailsForAccountantAsync(int id);
        Task<DeliveryForDriverViewModel?> GetDeliveryDetailsForDriverAsync(int id);
        Task<List<DeliveryViewModel>?> GetDeliveryForDriverAsync(string username, string? referenceNumber = null, DateTime? endDate = null, DateTime? startDate = null, string? deliveryAddress = null, string? pickupAddress = null, string? companyName = null);
        Task<DeliveryViewModel> GetDeliveryForDriverByReferenceNumberAsync(string searchTerm);
        Task<List<DeliveryViewModel>?> GetDeliveryForDriverBySearchtermAsync(string username, string? searchTerm);
        Task<DriverDashboardViewModel?> GetDriverDashboardAsync(string username);
        Task<List<DeliveryViewModel>?> GetNewDeliveryForDriverAsync(string username, string? referenceNumber = null, DateTime? endDate = null, DateTime? startDate = null, string? deliveryAddress = null, string? pickupAddress = null, string? companyName = null);
    }
}

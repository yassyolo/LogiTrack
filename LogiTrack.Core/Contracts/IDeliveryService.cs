
using LogiTrack.Core.ViewModels;
using LogiTrack.Core.ViewModels.Accountant;
using LogiTrack.Core.ViewModels.Delivery;
using LogiTrack.Core.ViewModels.Driver;

namespace LogiTrack.Core.Contracts
{
    public interface IDeliveryService
    {
        Task AddCashRegisterForDeliveryAsync(int id, AddCashRegisterViewModel model, Microsoft.AspNetCore.Http.IFormFile file);
        Task AddStatusForDeliveryAsync(int deliveryId, AddStatusViewModel model, string username, string address);
        Task<bool> DeliveryWithIdExistsAsync(int deliveryId);
        Task<bool> DriverHasDeliveryAsync(string username, int id);
        Task<bool> DriverWithUsernameExistsAsync(string username);
        Task<List<CashRegisterIndexViewModel>> GetCashRegistersForDeliveryAsync(string? referenceNumber = null, DateTime? startDate = null, DateTime? endDate = null, string? type = null);
        Task<int> GetDeliveryByReferenceNumberAsync(string referenceNumber);
        Task<DeliveryForAccountantViewModel> GetDeliveryDetailsForAccountantAsync(int id);
        Task<DeliveryForDriverViewModel?> GetDeliveryDetailsForDriverAsync(int id);
        Task<List<DeliveryViewModel>> GetDeliveryForAccountantAsync( string? referenceNumber, DateTime? endDate, DateTime? startDate, string? clientCompanyName, bool? isPaid);
        Task<List<DeliveryViewModel>?> GetDeliveriesForDriverAsync(string username, string? referenceNumber = null, DateTime? endDate = null, DateTime? startDate = null, string? deliveryAddress = null, string? pickupAddress = null, bool? isNew = null);
        Task<List<DeliveryViewModel>?> GetDeliveriesForDriverBySearchtermAsync(string username, string? searchTerm);
        Task<DriverDashboardViewModel?> GetDriverDashboardAsync(string username);
        Task<List<DeliveryViewModel>?> GetNewDeliveryForDriverAsync(string username, string? referenceNumber = null, DateTime? endDate = null, DateTime? startDate = null, string? deliveryAddress = null, string? pickupAddress = null, string? companyName = null);
        Task<List<DeliveryViewModel>> GetDeliveriesForAccountantBySearchtermAsync(string? searchTerm = null);
    }
}

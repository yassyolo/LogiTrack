
using LogiTrack.Core.ViewModels.Accountant;
using LogiTrack.Core.ViewModels.Delivery;

namespace LogiTrack.Core.Contracts
{
    public interface IDeliveryService
    {
        Task AddCashRegisterForDeliveryAsync(int id, AddCashRegisterViewModel model, Microsoft.AspNetCore.Http.IFormFile file);
        Task AddStatusForDeliveryAsync(int id, AddStatusViewModel model, string username);
        Task<bool> DeliveryWithIdExistsAsync(int deliveryId);
        Task<bool> DriverHasDeliveryAsync(string username, int id);
        Task<bool> DriverWithUsernameExistsAsync(string username);
        Task<DeliveryIndexViewModel> GetDeliveryByReferenceNumberAsync(string searchTerm);
        Task<DeliveryViewModel> GetDeliveryForDriverByReferenceNumberAsync(string searchTerm);
    }
}


using LogiTrack.Core.ViewModels;
using LogiTrack.Core.ViewModels.Accountant;
using LogiTrack.Core.ViewModels.Clients;
using LogiTrack.Core.ViewModels.Delivery;
using LogiTrack.Core.ViewModels.Driver;

namespace LogiTrack.Core.Contracts
{
    public interface IDeliveryService
    {      
        Task<bool> DeliveryWithIdExistsAsync(int deliveryId);
        Task<int> GetDeliveryByReferenceNumberAsync(string referenceNumber);
        Task<DeliveryForAccountantViewModel> GetDeliveryDetailsForAccountantAsync(int id);
        Task<DeliveryForDriverViewModel?> GetDeliveryDetailsForDriverAsync(int id);
        Task<List<DeliveryViewModel>> GetDeliveryForAccountantAsync( string? referenceNumber, DateTime? endDate, DateTime? startDate, string? clientCompanyName, bool? isPaid);
        Task<List<DeliveryViewModel>?> GetDeliveriesForDriverAsync(string username, string? referenceNumber = null, DateTime? endDate = null, DateTime? startDate = null, string? deliveryAddress = null, string? pickupAddress = null, bool? isNew = null);
        Task<List<DeliveryViewModel>?> GetDeliveriesForDriverBySearchtermAsync(string username, string? searchTerm);
        Task<List<DeliveryViewModel>?> GetNewDeliveryForDriverAsync(string username, string? referenceNumber = null, DateTime? endDate = null, DateTime? startDate = null, string? deliveryAddress = null, string? pickupAddress = null, string? companyName = null);
        Task<List<DeliveryViewModel>> GetDeliveriesForAccountantBySearchtermAsync(string? searchTerm = null);
        Task<bool> DeliveryWithCompanyExistsAsync(int deliveryId, string username);
        Task<DeliveryDetailsForClientViewModel?> GetDeliveryDetailsForCompanyAsync(int id);
        Task LeaveRatingForDeliveryAsync(int id, string? comment, int ratingStars);
        Task<List<DeliveryForMyDeliveriesViewModel>?> GetDeliveriesForClientAsync(string username, string? referenceNumber, DateTime? endDate, DateTime? startDate, decimal? minPrice, decimal? maxPrice, bool isDelivered, bool isPaid);
        Task<List<DeliveryForMyDeliveriesViewModel>?> GetDeliveriesForClientBySearchtermAsync(string username, string? searchTerm);
    }
}

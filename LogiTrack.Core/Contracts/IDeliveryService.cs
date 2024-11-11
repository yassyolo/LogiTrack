using LogiTrack.Core.ViewModels.Delivery;

namespace LogiTrack.Core.Contracts
{
    public interface IDeliveryService
    {      
        Task<bool> DeliveryWithIdExistsAsync(int deliveryId);
        Task<int> GetDeliveryByReferenceNumberForAccountantAsync(string referenceNumber);
        Task<DeliveryForAccountantViewModel> GetDeliveryDetailsForAccountantAsync(int id);
        Task<DeliveryForDriverViewModel?> GetDeliveryDetailsForDriverAsync(int id);
        Task<List<DeliveryViewModel>> GetDeliveryForAccountantAsync( string? referenceNumber, DateTime? endDate, DateTime? startDate, string? clientCompanyName, bool? isPaid);
        Task<List<DeliveryViewModel>?> GetDeliveriesForDriverAsync(string username, string? referenceNumber = null, DateTime? endDate = null, DateTime? startDate = null, string? deliveryAddress = null, string? pickupAddress = null, bool? isNew = null);
        Task<List<DeliveryViewModel>?> GetDeliveriesForDriverBySearchtermAsync(string username, string? searchTerm);
        Task<List<DeliveryViewModel>?> GetNewDeliveryForDriverAsync(string username, string? referenceNumber = null, DateTime? endDate = null, DateTime? startDate = null, string? deliveryAddress = null, string? pickupAddress = null, string? companyName = null);
        Task<List<DeliveryViewModel>> GetDeliveriesForAccountantBySearchtermAsync(string? searchTerm = null);
        Task<bool> DeliveryWithCompanyExistsAsync(int deliveryId, string username);
        Task<DeliveryForClientViewModel?> GetDeliveryDetailsForCompanyAsync(int id);
        Task LeaveRatingForDeliveryAsync(int id, string? comment, int ratingStars);
        Task<List<DeliveryForClientsDeliveriesViewModel>?> GetDeliveriesForClientAsync(string username, string? referenceNumber, DateTime? endDate, DateTime? startDate, decimal? minPrice, decimal? maxPrice, bool isDelivered, bool isPaid);
        Task<List<DeliveryForClientsDeliveriesViewModel>?> GetDeliveriesForClientBySearchtermAsync(string username, string? searchTerm);
    }
}

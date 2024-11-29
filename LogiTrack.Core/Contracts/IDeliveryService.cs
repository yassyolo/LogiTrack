using LogiTrack.Core.ViewModels.Delivery;

namespace LogiTrack.Core.Contracts
{
    public interface IDeliveryService
    {      
        Task<bool> DeliveryWithIdExistsAsync(int deliveryId);
        Task<int> GetDeliveryByReferenceNumberAsync(string referenceNumber);
        Task<DeliveryForAccountantViewModel> GetDeliveryDetailsForAccountantAsync(int id);
        Task<DeliveryForDriverViewModel?> GetDeliveryDetailsForDriverAsync(int id);
        Task<List<DeliveryViewModel>> GetDeliveriesForAccountantAsync( string? referenceNumber, DateTime? endDate, DateTime? startDate, string? clientCompanyName, bool? isPaid);
        Task<List<DeliveryViewModel>?> GetDeliveriesForDriverAsync(string username, string? referenceNumber = null, DateTime? endDate = null, DateTime? startDate = null, string? deliveryAddress = null, string? pickupAddress = null, bool? isNew = null);
        Task<List<DeliveryViewModel>?> GetDeliveriesForDriverBySearchtermAsync(string username, string? searchTerm);
        Task<List<DeliveryViewModel>?> GetNewDeliveryForDriverAsync(string username, string? referenceNumber = null, DateTime? endDate = null, DateTime? startDate = null, string? deliveryAddress = null, string? pickupAddress = null, string? companyName = null);
        Task<List<DeliveryViewModel>> GetDeliveriesForAccountantBySearchtermAsync(string? searchTerm = null);
        Task<bool> DeliveryWithCompanyExistsAsync(int deliveryId, string username);
        Task<DeliveryForClientViewModel?> GetDeliveryDetailsForCompanyAsync(int id);
        Task LeaveRatingForDeliveryAsync(int id, string? comment, int ratingStars);
        Task<List<DeliveryForClientsDeliveriesViewModel>?> GetDeliveriesForClientAsync(string username, string? referenceNumber = null, DateTime? endDate = null, DateTime? startDate = null, decimal? minPrice = null, decimal? maxPrice = null, bool? isDelivered = null, bool? isPaid = null);
        Task<List<DeliveryForClientsDeliveriesViewModel>?> GetDeliveriesForClientBySearchtermAsync(string username, string? searchTerm = null);
        Task<DelliveryDetailsForLogisticsViewModel?> GetDeliveryDetailsForLogisticsAsync(int id);
        Task<List<DeliveryForClientsDeliveriesViewModel>> GetDeliveriesForLogisticsBySearchtermAsync(string? searchTerm = null);
        Task<List<DeliveryForClientsDeliveriesViewModel>> GetDeliveriesForLogisticsAsync(string? referenceNumber = null, DateTime? endDate = null, DateTime? startDate = null, decimal? minPrice = null, decimal? maxPrice = null, bool? isDelivered = null, bool? isPaid = null, string? pickupAddress = null, string? deliveryAddress = null);
    }
}

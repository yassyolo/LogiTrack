using LogiTrack.Core.ViewModels.Request;

namespace LogiTrack.Core.Contracts
{
    public interface IRequestService
    {
        Task MakeRequestAsync(MakeRequestViewModel model, string username);
        Task<IEnumerable<RequestsForSearchViewModel>> GetRequestsForCompanyAsync(string companyUsername, DateTime? startDate = null, DateTime? endDate = null, string? pickupAddress = null, string? deliveryAddress = null, bool? isApproved = null, decimal? minPrice = null, decimal? maxPrice = null, double? minWeight = null, double? maxWeight = null);
        Task<IEnumerable<RequestsForSearchViewModel>> GetRequestsForCompanyBySearchTermAsync(string companyUsername, string? searchTerm);
        Task<bool> RequestWithCompanyExistsAsync(int id, string username);
        Task<bool> RequestWithIdExistsAsync(int id);
        Task<int> GetRequestIdByReferenceNumberAsync(string referenceNumber);
        Task<RequestsDetailsForLogisticsViewModel?> GetRequestDetailsForLogisticsAsync(int id);
        Task<IEnumerable<RequestsForSearchViewModel>> GetRequestsForLogisticsAsync(DateTime? startDate= null, DateTime? endDate = null, bool isApproved = false, bool sharedTruck = false, double? minWeight = null, double? maxWeight = null, decimal? minPrice = null, decimal? maxPrice = null, string? pickupAddress = null, string? deliveryAddress = null);
        Task<IEnumerable<RequestsForSearchViewModel>> GetRequestsForLogisticsBySearchTermAsync(string? searchTerm);      
        Task<RequestViewModel?> GetRequestDetailsAsync(int id);
        Task<List<RequestsDetailsForLogisticsViewModel>> GetPendingRequestsAsync(string sharedTruck = null, DateTime? startDate= null, DateTime? endDate = null, double? minWeight = null, double? maxWeight = null, double? minVolume = null, double? maxVolume = null, string? pickupAddress = null, string? deliveryAddress = null);
        Task<PendingRequestDetailsViewModel?> GetPendingRequestDetailsAsync(int id);
    }
}

using LogiTrack.Core.ViewModels.Offer;

namespace LogiTrack.Core.Contracts
{
    public interface IOfferService
    {
        Task<OfferViewModel?> GetOfferDetailsAsync(int id);
        Task<int> GetOfferIdByOfferNumberAsync(string offerNumber);
        Task<List<OfferForSearchViewModel>?> GetOffersForCompanyAsync(string username, string? deliveryAddress = null, string? pickupAddress = null, DateTime? startDate = null, DateTime? endDate = null, decimal? minPrice = null, decimal? maxPrice = null, bool? isApproved = null, double? minWeight = null, double? maxWeight = null);
        Task<List<OfferForSearchViewModel>?> GetOffersForCompanyBySearchTermAsync(string username, string? searchTerm = null);
        Task<bool> OfferWithCompanyExistsAsync(int id, string username);
        Task<bool> OfferWithIdExistsAsync(int id);
        Task BookOfferAsync(int id, string username);      
        Task<AcceptOfferViewModel?> GetOfferForAcceptAsync(int id);
        Task<List<OfferForSearchViewModel>> GetOffersForLogisticsBySearchTermAsync(string? searchTerm = null);
        Task<List<OfferForSearchViewModel>> GetOffersForLogisticsAsync(string? deliveryAddress = null, string? pickupAddress = null, DateTime? startDate = null, DateTime? endDate = null, decimal? minPrice = null, decimal? maxPrice = null, bool? isApproved = null, double? minWeight = null, double? maxWeight = null);
    }
}

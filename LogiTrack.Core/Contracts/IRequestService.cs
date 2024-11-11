using LogiTrack.Core.ViewModels.Request;

namespace LogiTrack.Core.Contracts
{
    public interface IRequestService
    {
        Task MakeRequestAsync(MakeRequestViewModel model, string userEmail);
        Task<IEnumerable<RequestsForSearchViewModel>> GetRequestsForCompanyAsync(string companyUsername, DateTime? startDate = null, DateTime? endDate = null, string? pickupAddress = null, string? deliveryAddress = null, bool? isApproved = null);
        Task<IEnumerable<RequestsForSearchViewModel>> GetRequestsForCompanyBySearchTermAsync(string companyUsername, string? searchTerm);
        Task<bool> RequestWithCompanyExistsAsync(int id, string username);
        Task<bool> RequestWithIdExistsAsync(int id);
    }
}

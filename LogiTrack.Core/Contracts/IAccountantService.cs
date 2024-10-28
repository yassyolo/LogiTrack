
using LogiTrack.Core.ViewModels.Accountant;

namespace LogiTrack.Core.Contracts
{
    public interface IAccountantService
    {
        Task<AccountantDashboardViewModel?> GetAccountantIndexAsync();
    }
}

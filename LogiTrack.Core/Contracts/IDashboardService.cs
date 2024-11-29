using LogiTrack.Core.ViewModels.Accountant;
using LogiTrack.Core.ViewModels.Clients;
using LogiTrack.Core.ViewModels.Driver;
using LogiTrack.Core.ViewModels.Logistics;
using LogiTrack.Core.ViewModels.Speditor;

namespace LogiTrack.Core.Contracts
{
    public interface IDashboardService
    {
        Task<AccountantDashboardViewModel?> GetAccountantDashboardAsync();
        Task<ClientsDashboardViewModel?> GetClientCompanyDashboardAsync(string username);
        Task<DriverDashboardViewModel?> GetDriverDashboardAsync(string username);
        Task<LogisticsDashboardViewModel?> GetLogisticsCompanyDashboardAsync();
        Task<SpeditorDashboardViewModel?> GetSpeditorDashboardAsync();
    }
}

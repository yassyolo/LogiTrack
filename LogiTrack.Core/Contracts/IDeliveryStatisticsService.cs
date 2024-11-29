using LogiTrack.Core.ViewModels.CashRegister;
using LogiTrack.Core.ViewModels.Invoice;

namespace LogiTrack.Core.Contracts
{
    public interface IDeliveryStatisticsService
    {
        Task<(int domesticDeliveries, int internationalDeliveries)> GetDestinationTypesForDriverAsync(string username);
        Task<(string[], List<int>)> GetDeliveriesCountForDriverAsync(string username);
        Task<(double successRate, double averageDelay)> GetDeliveryTimesForDriverAsync(string username);
        Task<CashRegisterStatisticsViewModel?> GetCashRegisterStatisticsAsync();
        Task<Dictionary<string, int>> GetCashRegisterTypesDistributionAsync();
        Task<Dictionary<string, decimal>> GetGetTotalAdditionalCostsByDeliveryTypeAsync();
        Task<(decimal, decimal)> GetCashRegistersAmountAsync();
        Task<InvoiceStatisticsViewModel?> GetInvoicesStatisticsAsync();
        Task<Dictionary<string, int>> GetInvoicesByStatusAsync();
        Task<Dictionary<string, decimal>> GetTop10ClientsByOverdueAmountAsync();
        Task<Dictionary<string, decimal>> GetLatePaymentsByClientAsync();
        Task<(string[], List<int>)> GetDeliveriesCountForCompanyAsync(string username);
        Task<(int domesticDeliveries, int internationalDeliveries)> GetDestinationTypesForCompanyAsync(string username);
        Task<(double successRate, double averageDelay)> GetDeliveryTimesForCompanyAsync(string username);
        Task<Dictionary<string, int>> GetInvoicesStatusDistributionAsync(string username);
        Task<decimal> GetTotalSpendingForCompanyAsync(string username);
        Task<InvoiceStatisticsForClientViewModel?> GetInvoicesStatisticsForClientAsync(string username);
        Task<(double, double)> GetCarbonEmissionsForCompanyAsync(string username, int id);
        Task<(string[], List<int>)> GetDeliveryCountsAsync();
        Task<(int domesticDeliveries, int internationalDeliveries)> GetDestinationTypesAsync();
        Task<(double successRate, double averageDelay)> GetDeliveryTimesAsync();
        Task<(string[], List<int>)> GetDeliveryCountsForDriverAsync(int id);
        Task<Dictionary<string, int>> GetPopularDeliveryCitiesAsync();
        Task<Dictionary<int, int>> GetDeliveryRatingsDistributionAsync();
    }
}

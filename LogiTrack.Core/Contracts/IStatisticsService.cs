using LogiTrack.Core.ViewModels.Clients;
using LogiTrack.Core.ViewModels.Delivery;
using LogiTrack.Core.ViewModels.Driver;
using LogiTrack.Core.ViewModels.FuelPrice;
using LogiTrack.Core.ViewModels.Offer;
using LogiTrack.Core.ViewModels.Request;
using LogiTrack.Core.ViewModels.Vehicle;

namespace LogiTrack.Core.Contracts
{
    public interface IStatisticsService
    {
        Task<DeliveryStatisticsForDriverViewModel?> GetDeliveryStatisticsForDriverAsync(string username);       
        Task<DeliveryStatisticsForClientViewModel?> GetDeliveryStatisticsForCompanyAsync(string username);     
        Task<Dictionary<int, int>> GetMonthlyRequestPattersForClientRequestsAsync(string username);
        Task<double> GetAverageResponseTimeForClientRequestsAsync(string username);
        Task<Dictionary<string, int>> GetRequestStatusDistributionForCompanyAsync(string username);
        Task<Dictionary<string, int>> GetRequestStatusDistributionAsync();
        Task<RequestStatisticsForClientViewModel?> GetRequestStatisticsForCompanyAsync(string username);   
        Task<List<(string offerReference, decimal approximatePrice, decimal finalPrice)>> GetRequestPriceDifferenceForDeliveriesAsync(string username);
        Task<List<(string offerReference, decimal approximatePrice, decimal finalPrice)>> GetRequestPriceDifferenceForDeliveriesAsync(int id);
        Task<OfferStatisticsForClientViewModel?> GetOfferStatisticsForCompanyAsync(string username);
        Task<(int, int)> GetOffersAcceptanceRateForCompanyAsync(string username);
        Task<(int, int)> GetCargoRatiosForCompanyAsync(string username);
        Task<(string[], decimal[], decimal[])> GetDifferencesInOfferPricesForCompanyAsync(string username);
        Task<List<ExpiringLicenseViewModel>> GetDriversExpiryLicensesCountAsync();
        Task<DriversStatisticsViewModel?> GetDriversStatisticsAsync();
        Task<Dictionary<string, int>> GetTop10DriversByDeliveriesAsync();
        Task<Dictionary<string, int>> GetLicenseExpirationOverviewAsync();
        Task<Dictionary<string, int>> GetDriverAvailabilityAsync();
        Task<Dictionary<double, decimal>> GetDistanceAdditionalCostDataAsync();
        Task<Dictionary<string, decimal>> GetTop10DeliveriesByAdditionalCostAsync();
        Task<(int, int)> GetClientRequestToDeliveryDataAsync(int id);
        Task<(decimal, decimal)> GetClientDeliveryCostStatisticsAsync(int id);
        Task<DeliveryStatisticsForLogisticsViewModel?> GetDeliveryStatisticsAsync();
        Task<ClientsStatisticsViewModel?> GetClientsStatisticsAsync();
        Task<Dictionary<string, decimal>> GetTop10ClientsAsync();
        Task<Dictionary<string, int>> GetTop10ClientsByDeliveriesAsync();
        Task<(decimal, int)> GetVehicleCostsDataForVehicleAsync(int id);
        Task<(string[], double, int)> GetDistanceAndDeliveriesForVehicleAsync(int id);       
        Task<Dictionary<string, int>> GetTopVehiclesWithMostDeliveriesAsync();
        Task<Dictionary<string, decimal>> GetTopVehiclesByAdditionalCostsAsync();
        Task<Dictionary<string, double>> GetTopVehiclesByKilometersAsync();
        Task<Dictionary<string, int>> GetTopVehiclesDueForMaintenanceAsync();
        Task<Dictionary<string, double>> GetTopVehiclesClosestToKilometersAsync();
        Task<(int domesticDeliveries, int internationalDeliveries)> GetDeliveryTypesForDriverAsync(int id);
        Task<Dictionary<string, int>> GetTopDriversWithInternationalDeliveriesAsync();
        Task<Dictionary<string, int>> GetTopDriversByExperienceAsync();
        Task<Dictionary<int, int>> GetMonthlyRequestPattersAsync();
        Task<(double successRate, double averageDelay)> GetDeliveryTimesForDriverAsync(int id);
        Task<(double, double)> GetResponseTimeForRequestsAsync();
        Task<Dictionary<string, int>> GetTopClientsAsync();
        Task<(int, int)> GetCargoRatiosAsync();
        Task<(string[], decimal[], decimal[])> GetDifferencesInOfferPricesForRequestsAsync();
        Task<(int, int)> GetOffersAcceptanceRateAsync();
        Task<OfferStatisticsForClientViewModel?> GetOfferStatisticsAsync();
        Task<RequestStatisticsForClientViewModel?> GetRequestStatisticsForLogisticsAsync();
        Task<decimal> GetRevenueDataForCompanyAsync(string companyUsername);
        Task<int> GetVehiclesForRepairmentAsync();
        Task<VehicleStatisticsViewmodel?> GetVehicleStatisticsAsync();
        Task<FuelPricesStatisticsViewModel?> GetFuelPricesStatisticsAsync();
        Task<(decimal, decimal)> MaxAndTodayPriceRatioAsync();
        Task<Dictionary<int, decimal>> GetMonthlyFuelPricesAsync();
        Task<Dictionary<string, decimal>> GetFuelPricesForYearAsync();
    }
}

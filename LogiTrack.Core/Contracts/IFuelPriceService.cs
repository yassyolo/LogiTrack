using LogiTrack.Core.ViewModels.FuelPrice;

namespace LogiTrack.Core.Contracts
{
    public interface IFuelPriceService
    {
        Task AddFuelPriceAsync(AddFuelPriceViewModel model);
        Task<List<FuelPriceViewModel>> GetFuelPricesAsync(decimal? minPrice, decimal? maxPrice, string? startDate, string? endDate);
    }
}

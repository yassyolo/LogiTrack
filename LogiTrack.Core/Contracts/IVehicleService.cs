
using LogiTrack.Core.ViewModels.Accountant;
using LogiTrack.Core.ViewModels.Vehicle;

namespace LogiTrack.Core.Contracts
{
    public interface IVehicleService
    {
        Task AddPricesForVehicleAsync(int vehicleId, AddPricesForVehicleViewModel model);
        Task ChagePricesForVehicleAsync(int pricePerSizeId, AddPricesForVehicleViewModel model);
        Task<AddPricesForVehicleViewModel?> GetPricesForVehicleAsync(int vehicleId);
        Task<bool> VehicleWithIdExistsAsync(int vehicleId);
        Task<VehicleIndexViewModel> GetVehicleByRegistrationNumberAsync(string searchTerm);
    }
}

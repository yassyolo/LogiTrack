using LogiTrack.Core.ViewModels.FuelPrice;
using LogiTrack.Core.ViewModels.Vehicle;

namespace LogiTrack.Core.Contracts
{
    public interface IVehicleService
    {
        Task<bool> VehicleWithIdExistsAsync(int vehicleId);
        Task<int> GetVehicleIdByRegistrationNumberAsync(string registrationNumber);        
        Task<VehicleDetailsViewModel?> GetVehicleDetailsAsync(int id);
        Task<List<VehicleDetailsViewModel>> GetVehiclesAsync(bool refrigerated, string? registrationNumber = null, string? vehicleType = null, double? minWeightCapacity = null, double? maxWeightCapacity = null, double? minVolume = null, double? maxVolume = null, bool forMaintentance = false);
        Task<List<VehicleDetailsViewModel>> GetVehiclesBySearchTermAsync(string? searchTerm);
        Task<bool> VehicleWithRegistrationNumberExistsAsync(int id);
        Task AddVehicleAsync(AddVehicleViewModel model);
        Task<AddVehicleViewModel?> GetVehicleForEditAsync(int id);
        Task EditVehicleAsync(int id, AddVehicleViewModel model);
        Task<ChangeQuotientsForVehicleViewModel?> GetQuotientsForVehicleAsync(int id);
        Task ChageQuotientsForVehicleAsync(int id, ChangeQuotientsForVehicleViewModel model);
    }
}

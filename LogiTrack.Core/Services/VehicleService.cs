using LogisticsSystem.Infrastructure.Data.DataModels;
using LogiTrack.Core.Contracts;
using LogiTrack.Core.CustomExceptions;
using LogiTrack.Core.ViewModels.Accountant;
using LogiTrack.Infrastructure.Data.DataModels;
using LogiTrack.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace LogiTrack.Core.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IRepository repository;

        public VehicleService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<VehicleIndexViewModel> GetVehicleByRegistrationNumberAsync(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return new VehicleIndexViewModel();
            }
            var vehicle = await repository.AllReadonly<Vehicle>().FirstOrDefaultAsync(x => x.RegistrationNumber == searchTerm);
            if (vehicle == null)
            {
                throw new VehicleNotFoundException();
            }
            var pricesPerSize = await repository.AllReadonly<PricesPerSize>().FirstOrDefaultAsync(x => x.VehicleId == vehicle.Id);
            if (pricesPerSize == null)
            {
                throw new PricesPerSizeNotFoundException();
            }

            var model = new VehicleIndexViewModel
            {
                Id = vehicle.Id,
                RegistrationNumber = vehicle.RegistrationNumber,
                Length = vehicle.Length.ToString(),
                Width = vehicle.Width.ToString(),
                Height = vehicle.Height.ToString(),
                EuroPalletCapacity = vehicle.EuroPalletCapacity.ToString(),
                IndustrialPalletCapacity = vehicle.IndustrialPalletCapacity.ToString(),
                MaxWeightCapacity = vehicle.MaxWeightCapacity.ToString(),
                FuelConsumptionPer100Km = vehicle.FuelConsumptionPer100Km.ToString(),
                MaintenanceDue = vehicle.LastYearMaintenance.ToString("dd/MM/yyyy"),
            };
            if (pricesPerSize != null)
            {
                model.InternationalPriceForNotSharedTruck = pricesPerSize.InternationalPriceForNotSharedTruck.ToString();
                model.InternationalPriceForSharedTruck = pricesPerSize.InternationalPriceForSharedTruck.ToString();
                model.DomesticPriceForSharedTruck = pricesPerSize.DomesticPriceForSharedTruck.ToString();
                model.DomesticPriceForNotSharedTruck = pricesPerSize.DomesticPriceForNotSharedTruck.ToString();
            }
            else
            {
                model.InternationalPriceForNotSharedTruck = "0";
                model.InternationalPriceForSharedTruck = "0";
                model.DomesticPriceForSharedTruck = "0";
                model.DomesticPriceForNotSharedTruck = "0";
            }
            return model;
        }

        public async Task AddPricesForVehicleAsync(int vehicleId, AddPricesForVehicleViewModel model)
        {
            var vehicle = await repository.All<Vehicle>().FirstOrDefaultAsync(x => x.Id == vehicleId);
            var pricePerSize = new PricesPerSize
            {
                Vehicle = vehicle,
                VehicleId = vehicleId,
                DomesticPriceForNotSharedTruck = model.DomesticPriceForNotSharedTruck,
                DomesticPriceForSharedTruck = model.DomesticPriceForSharedTruck,
                InternationalPriceForNotSharedTruck = model.InternationalPriceForNotSharedTruck,
                InternationalPriceForSharedTruck = model.InternationalPriceForSharedTruck,
            };
            await repository.AddAsync(pricePerSize);
            await repository.SaveChangesAsync();
        }

        public async Task ChagePricesForVehicleAsync(int pricePerSizeId, AddPricesForVehicleViewModel model)
        {
            var pricePerSize = await repository.All<PricesPerSize>().FirstOrDefaultAsync(x => x.Id == pricePerSizeId);
            pricePerSize.DomesticPriceForNotSharedTruck = model.DomesticPriceForNotSharedTruck;
            pricePerSize.DomesticPriceForSharedTruck = model.DomesticPriceForSharedTruck;
            pricePerSize.InternationalPriceForNotSharedTruck = model.InternationalPriceForNotSharedTruck;
            pricePerSize.InternationalPriceForSharedTruck = model.InternationalPriceForSharedTruck;

            await repository.SaveChangesAsync();
        }

        public async Task<AddPricesForVehicleViewModel?> GetPricesForVehicleAsync(int vehicleId)
        {
            return await repository.AllReadonly<PricesPerSize>()
                .Where(x => x.VehicleId == vehicleId)
                .Select(x => new AddPricesForVehicleViewModel
                {
                    Id = x.Id,
                    DomesticPriceForNotSharedTruck = x.DomesticPriceForNotSharedTruck,
                    DomesticPriceForSharedTruck = x.DomesticPriceForSharedTruck,
                    InternationalPriceForNotSharedTruck = x.InternationalPriceForNotSharedTruck,
                    InternationalPriceForSharedTruck = x.InternationalPriceForSharedTruck,
                })
                .FirstOrDefaultAsync();
        }

        public async Task<bool> VehicleWithIdExistsAsync(int id)
        {
            return await repository.AllReadonly<Vehicle>().AnyAsync(v => v.Id == id);
        }
    }
}

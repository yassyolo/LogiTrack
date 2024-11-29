using LogiTrack.Core.Contracts;
using LogiTrack.Core.ViewModels.FuelPrice;
using LogiTrack.Infrastructure.Data.DataModels;
using LogiTrack.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace LogiTrack.Core.Services
{
    public class FuelPriceService : IFuelPriceService
    {
        private readonly IRepository repository;

        public FuelPriceService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task AddFuelPriceAsync(AddFuelPriceViewModel model)
        {
            var fuelPrice = new FuelPrice
            {
                Date = DateTime.Now,
                Price = model.Price
            };
            await repository.AddAsync(fuelPrice);
            await repository.SaveChangesAsync();
        }

        public async Task<List<FuelPriceViewModel>> GetFuelPricesAsync(decimal? minPrice, decimal? maxPrice, string? startDate, string? endDate)
        {
            var fuelPrices = await repository.AllReadonly<FuelPrice>().ToListAsync();
            if (minPrice != null)
            {
                fuelPrices = fuelPrices.Where(x => x.Price >= minPrice).ToList();
            }
            if (maxPrice != null)
            {
                fuelPrices = fuelPrices.Where(x => x.Price <= maxPrice).ToList();
            }
            if (string.IsNullOrEmpty(startDate) == false)
            {
                fuelPrices = fuelPrices.Where(x => x.Date >= DateTime.Parse(startDate)).ToList();
            }
            if (string.IsNullOrEmpty(endDate) == false)
            {
                fuelPrices = fuelPrices.Where(x => x.Date <= DateTime.Parse(endDate)).ToList();
            }
            return fuelPrices.Select(x => new FuelPriceViewModel
            {
                Id = x.Id,
                Price = x.Price,
                Date = x.Date,
                Type = "Diesel"
            }).ToList();
        }
    }
}

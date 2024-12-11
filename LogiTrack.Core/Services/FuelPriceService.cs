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
            var query = repository.AllReadonly<FuelPrice>().AsQueryable();
            if (minPrice != null)
            {
				query = query.Where(x => x.Price >= minPrice);
            }
            if (maxPrice != null)
            {
				query = query.Where(x => x.Price <= maxPrice);
            }
            if (string.IsNullOrEmpty(startDate) == false)
            {
				query = query.Where(x => x.Date >= DateTime.Parse(startDate));
            }
            if (string.IsNullOrEmpty(endDate) == false)
            {
				query = query.Where(x => x.Date <= DateTime.Parse(endDate));
            }

            var fuelPrices = await query.ToListAsync();

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

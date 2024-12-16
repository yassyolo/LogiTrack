using LogisticsSystem.Infrastructure.Data.DataModels;
using LogiTrack.Core.Constants;
using LogiTrack.Core.Contracts;
using LogiTrack.Core.ViewModels.Clients;
using LogiTrack.Core.ViewModels.Delivery;
using LogiTrack.Core.ViewModels.Driver;
using LogiTrack.Core.ViewModels.FuelPrice;
using LogiTrack.Core.ViewModels.Offer;
using LogiTrack.Core.ViewModels.Request;
using LogiTrack.Core.ViewModels.Vehicle;
using LogiTrack.Infrastructure.Data.DataModels;
using LogiTrack.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace LogiTrack.Core.Services
{
	public class StatisticsService : IStatisticsService
    {
        private readonly IRepository repository;

        public StatisticsService(IRepository repository)
        {
            this.repository = repository;
        }

       

        public async Task<DeliveryStatisticsForDriverViewModel?> GetDeliveryStatisticsForDriverAsync(string username)
        {
            var driver = await repository.AllReadonly<Driver>().FirstOrDefaultAsync(x => x.User.UserName == username);
            return new DeliveryStatisticsForDriverViewModel()
            {
                TotalCarbonEmission = await repository.AllReadonly<LogiTrack.Infrastructure.Data.DataModels.Delivery>().Where(x => x.DriverId == driver.Id).SumAsync(x => x.Offer.Request.Kilometers * (x.Vehicle.FuelConsumptionPer100Km / 100) * x.Vehicle.EmissionFactor),
                TotalDomesticDeliveries = await repository.AllReadonly<LogiTrack.Infrastructure.Data.DataModels.Delivery>().Where(x => x.DriverId == driver.Id && x.Offer.Request.Type == RequestTypeConstants.Domestic).CountAsync(),
                TotalInternationalDeliveries = await repository.AllReadonly<LogiTrack.Infrastructure.Data.DataModels.Delivery>().Where(x => x.DriverId == driver.Id && x.Offer.Request.Type == RequestTypeConstants.International).CountAsync(),
                TotalKilometers = await repository.AllReadonly<LogiTrack.Infrastructure.Data.DataModels.Delivery>().Where(x => x.DriverId == driver.Id).SumAsync(x => x.Offer.Request.Kilometers),
                TotalSuccessfulCompleted = await repository.AllReadonly<LogiTrack.Infrastructure.Data.DataModels.Delivery>().Where(x => x.DriverId == driver.Id && x.DeliveryStep == 4 && x.Offer.Request.ExpectedDeliveryDate >= x.ActualDeliveryDate).CountAsync(),
            };
        }
        

        public async Task<DeliveryStatisticsForClientViewModel?> GetDeliveryStatisticsForCompanyAsync(string username)
        {
            var client = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.ClientCompany>().FirstOrDefaultAsync(x => x.User.UserName == username);
            var deliveries = await repository.AllReadonly<LogiTrack.Infrastructure.Data.DataModels.Delivery>().Include(x => x.Offer).ThenInclude(x => x.Request).Where(x => x.Offer.Request.ClientCompanyId == client.Id).ToListAsync();
            return new DeliveryStatisticsForClientViewModel()
            {
                TotalDeliveries = deliveries.Count(),
                AverageDeliveryTime = deliveries.Where(x => x.Offer.Request.ClientCompanyId == client.Id).Average(x => (x.ActualDeliveryDate - x.Offer.OfferDate).Value.TotalDays),
                AverageDeliveryDistance = deliveries.Where(x => x.Offer.Request.ClientCompanyId == client.Id).Average(x => x.Offer.Request.Kilometers),
                Kilometers = deliveries.Where(x => x.Offer.Request.ClientCompanyId == client.Id).Sum(x => x.Offer.Request.Kilometers),
                CO2Emissions = deliveries.Where(x => x.Offer.Request.ClientCompanyId == client.Id).Sum(x => x.CarbonEmission),
            };
        }
       
        public async Task<RequestStatisticsForClientViewModel?> GetRequestStatisticsForCompanyAsync(string username)
        {
            var requests = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Request>().Where(x => x.ClientCompany.User.UserName == username).ToListAsync();
            return new RequestStatisticsForClientViewModel
            {
                TotalRequestsWithOffers = await repository.AllReadonly<Offer>().CountAsync(),
                AveragePrice = requests.Average(x => x.ApproximatePrice),
                TotalRequests = requests.Count(),
                AverageVolume = requests.Average(x => x.TotalVolume),
                AverageWeight = requests.Average(x => x.TotalWeight),
            };
        }

        public async Task<Dictionary<string, int>> GetRequestStatusDistributionAsync()
        {
            var dictionary = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Request>()
                .GroupBy(x => x.Status)
                .Select(x => new
                {
                    Status = x.Key,
                    Count = x.Count()
                }).ToDictionaryAsync(x => x.Status, x => x.Count);
            return dictionary;
        }

        public async Task<Dictionary<string, int>> GetRequestStatusDistributionForCompanyAsync(string username)
        {
            var company = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.ClientCompany>().FirstOrDefaultAsync(x => x.User.UserName == username);
            var dictionary = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Request>().Where(x => x.ClientCompanyId == company.Id)
                .GroupBy(x => x.Status)
                .Select(x => new
                {
                    Status = x.Key,
                    Count = x.Count()
                }).ToDictionaryAsync(x => x.Status, x => x.Count);
            return dictionary;
        }

        public async Task<double> GetAverageResponseTimeForClientRequestsAsync(string username)
        {
            var requests = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Offer>()
                .Include(x => x.Request).ThenInclude(x => x.ClientCompany).ThenInclude(x => x.User)
                .Where(x => x.Request.ClientCompany.User.UserName == username)
                .Where(x => x.OfferDate != null && x.Request.CreatedAt != null)
                .ToListAsync();

            if (requests.Any() == false)
            {
                return 0;
            }

            var timeDifferences = requests
                .Select(x => (x.OfferDate - x.Request.CreatedAt).TotalDays)
                .ToList();

            if (timeDifferences.Any() == false)
            {
                return 0;
            }

            return timeDifferences.Average();
        }

        public async Task<Dictionary<int, int>> GetMonthlyRequestPattersForClientRequestsAsync(string username)
        {
            var requests = await repository.AllReadonly<Request>().Where(x => x.ClientCompany.User.UserName == username).ToListAsync();
            if (requests.Any() == false)
            {
                return new Dictionary<int, int>();
            }
            var model = await repository.AllReadonly<Request>().Where(x => x.ClientCompany.User.UserName == username)
                .Where(x => x.CreatedAt.Month == DateTime.Now.Month)
                .GroupBy(x => x.CreatedAt.Day)
                .Select(x => new
                {
                    Day = x.Key,
                    Count = x.Count()
                })
                .ToDictionaryAsync(x => x.Day, x => x.Count);
            return model;
        }

       
        public async Task<List<(string offerReference, decimal approximatePrice, decimal finalPrice)>> GetRequestPriceDifferenceForDeliveriesAsync(string username)
        {
            var deliveries = await repository.AllReadonly<Request>().Where(x => x.ClientCompany.User.UserName == username)
           .Join(repository.AllReadonly<Offer>(),
           r => r.Id,
           o => o.RequestId,
           (r, o) => new
           {
               offerReference = o.OfferNumber,
               approximatePrice = r.ApproximatePrice,
               finalPrice = o.FinalPrice
           })
          .Select(x => new
          {
           x.offerReference,
           x.approximatePrice,
           x.finalPrice
          })
       .ToListAsync();
            return deliveries.Select(x => (x.offerReference, x.approximatePrice, x.finalPrice)).ToList();
        }

        public async Task<List<(string offerReference, decimal approximatePrice, decimal finalPrice)>> GetRequestPriceDifferenceForDeliveriesAsync(int id)
        {
            var requests = await repository.AllReadonly<Request>().Include(x => x.ClientCompany).Where(x => x.ClientCompanyId == id).ToListAsync();
            var deliveries = await repository.AllReadonly<Request>().Include(x => x.ClientCompany).Where(x => x.ClientCompanyId == id)
                   .Join(repository.AllReadonly<Offer>(),
           r => r.Id,
           o => o.RequestId,
           (r, o) => new
           {
               offerReference = o.OfferNumber,
               approximatePrice = r.ApproximatePrice,
               finalPrice = o.FinalPrice
           })
       .Select(x => new
       {
           x.offerReference,
           x.approximatePrice,
           x.finalPrice
       })
       .ToListAsync();
            return deliveries.Select(x => (x.offerReference, x.approximatePrice, x.finalPrice)).ToList();

        }
        
        public async Task<(string[], decimal[], decimal[])> GetDifferencesInOfferPricesForCompanyAsync(string username)
        {
            var company = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.ClientCompany>().FirstOrDefaultAsync(x => x.User.UserName == username);
            var offers = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Offer>().Include(x => x.Request).Where(x => x.Request.ClientCompanyId == company.Id).ToListAsync();
            var offerRefNumbers = offers.Select(x => x.OfferNumber).ToArray();
            var offerPrices = offers.Select(x => x.FinalPrice).ToArray();
            var approximatePrices = offers.Select(x => x.Request.ApproximatePrice).ToArray();
            return (offerRefNumbers, offerPrices, approximatePrices);
        }
        public async Task<(int, int)> GetOffersAcceptanceRateForCompanyAsync(string username)
        {
            var company = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.ClientCompany>().FirstOrDefaultAsync(x => x.User.UserName == username);
            var offers = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Offer>().Where(x => x.Request.ClientCompanyId == company.Id).Take(10).ToListAsync();
            var acceptedOffers = offers.Where(x => x.OfferStatus == StatusConstants.Approved).Count();
            var declinedOffers = offers.Where(x => x.OfferStatus == StatusConstants.Rejected).Count();
            return (acceptedOffers, declinedOffers);
        }



        public async Task<OfferStatisticsForClientViewModel?> GetOfferStatisticsForCompanyAsync(string username)
        {
            var offers = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Offer>().Include(x => x.Request).Where(x => x.Request.ClientCompany.User.UserName == username).ToListAsync();
            return new OfferStatisticsForClientViewModel()
            {
                AverageVolume = offers.Average(x => x.Request.TotalVolume),
                AverageWeight = offers.Average(x => x.Request.TotalWeight),
                AveragePrice = offers.Average(x => x.FinalPrice),
                TotalPallets = offers.Sum(x => x.Request.StandartCargo?.NumberOfPallets ?? 0),
            };
        }

        public async Task<(int, int)> GetCargoRatiosForCompanyAsync(string username)
        {
            var requests = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Request>().Where(x => x.ClientCompany.User.UserName == username).Take(10).ToListAsync();
            var standartCargoCount = requests.Count(x => x.StandartCargo != null);
            var nonStandartCargoCount = requests.Count(x => x.NumberOfNonStandartGoods != null);
            return (standartCargoCount, nonStandartCargoCount);
        }
        public async Task<List<ExpiringLicenseViewModel>> GetDriversExpiryLicensesCountAsync()
        {
            var drivers = await repository.AllReadonly<Infrastructure.Data.DataModels.Driver>()
                 .Where(x => x.LicenseExpiryDate <= DateTime.Now.AddDays(30) && x.LicenseExpiryDate >= DateTime.Now)
                  .Select(x => new ExpiringLicenseViewModel
                  {
                      Name = x.Name,
                      ExpirationDate = x.LicenseExpiryDate.ToString("YYYY-MM-DD")
                  })
                  .ToListAsync();

            return drivers;
        }

        public async Task<DriversStatisticsViewModel?> GetDriversStatisticsAsync()
        {
            return new DriversStatisticsViewModel
            {
                TotalDrivers = await repository.AllReadonly<Driver>().CountAsync(),
                AvailableDrivers = await repository.AllReadonly<Driver>().CountAsync(x => x.IsAvailable),
                WithExpiringLicense = await repository.AllReadonly<Driver>().CountAsync(x => x.LicenseExpiryDate.Date <= DateTime.Now.Date.AddDays(30)),
            };
        }

        public async Task<Dictionary<string, int>> GetTop10DriversByDeliveriesAsync()
        {
            var drivers = await repository.AllReadonly<Delivery>().Include(x => x.Driver).ToListAsync();
            var dictionary = drivers.GroupBy(x => x.Driver.LicenseNumber)
                .OrderByDescending(x => x.Count())
                .Take(10)
                .ToDictionary(x => x.Key, x => x.Count());
            return dictionary;
        }

        public async Task<Dictionary<string, int>> GetLicenseExpirationOverviewAsync()
        {
            var drivers = await repository.AllReadonly<Driver>().ToListAsync();
            var expiring30Days = drivers.Count(x => x.LicenseExpiryDate.Date <= DateTime.Now.Date.AddDays(30));
            var expiring60Days = drivers.Count(x => x.LicenseExpiryDate.Date <= DateTime.Now.Date.AddDays(60));
            var expiring90Days = drivers.Count(x => x.LicenseExpiryDate.Date <= DateTime.Now.Date.AddDays(90));
            return new Dictionary<string, int>
            {
              { "Expiring in 30 Days", expiring30Days },
              { "Expiring in 60 Days", expiring60Days },
              { "Expiring in 90 Days", expiring90Days }
            };
        }

        public async Task<Dictionary<string, int>> GetDriverAvailabilityAsync()
        {
            var drivers = await repository.AllReadonly<Driver>().ToListAsync();
            var dictionary = drivers.GroupBy(x => x.IsAvailable)
                .ToDictionary(x => x.Key ? "Available" : "Not Available", x => x.Count());
            return dictionary;
        }
        public async Task<Dictionary<double, decimal>> GetDistanceAdditionalCostDataAsync()
        {
            var cashRegisters = await repository.AllReadonly<CashRegister>().Include(x => x.Delivery).ThenInclude(x => x.Offer).ThenInclude(x => x.Request).ToListAsync();
            var dictionary = cashRegisters.GroupBy(x => x.Delivery.Offer.Request.Kilometers)
                .ToDictionary(x => x.Key, x => x.Sum(x => x.Amount));
            return dictionary;
        }

        public async Task<Dictionary<string, decimal>> GetTop10DeliveriesByAdditionalCostAsync()
        {
            var cashRegisters = await repository.AllReadonly<CashRegister>().Include(x => x.Delivery).ThenInclude(x => x.Offer).ThenInclude(x => x.Request).ToListAsync();
            var dictionary = cashRegisters.GroupBy(x => x.Delivery.ReferenceNumber)
                .ToDictionary(x => x.Key, x => x.Sum(x => x.Amount));
            return dictionary;
        }

        public async Task<(int, int)> GetClientRequestToDeliveryDataAsync(int id)
        {
            var deliveries = await repository.AllReadonly<Delivery>().Include(x => x.Offer).ThenInclude(x => x.Request).ThenInclude(x => x.ClientCompany).Where(x => x.Offer.Request.ClientCompany.Id == id).CountAsync();
            var requests = await repository.AllReadonly<Request>().Include(x => x.ClientCompany).Where(x => x.ClientCompanyId == id).CountAsync();
            return (requests, deliveries);
        }

        public async Task<(decimal, decimal)> GetClientDeliveryCostStatisticsAsync(int id)
        {
            var deliveries = await repository.AllReadonly<Delivery>().Include(x => x.Offer).ThenInclude(x => x.Request).ThenInclude(x => x.ClientCompany).Where(x => x.Offer.Request.ClientCompany.Id == id).ToListAsync();
            var maxCost = deliveries.Max(x => x.Offer.FinalPrice);
            var avgCost = deliveries.Average(x => x.Offer.FinalPrice);
            return (maxCost, avgCost);
        }

        public async Task<DeliveryStatisticsForLogisticsViewModel?> GetDeliveryStatisticsAsync()
        {
            var deliveries = await repository.AllReadonly<Delivery>().Include(x => x.Offer).ThenInclude(x => x.Request).ToListAsync();
            return new DeliveryStatisticsForLogisticsViewModel()
            {
                TotalDeliveries = deliveries.Count(),
                DeliveredDeliveries = deliveries.Count(x => x.DeliveryStep == 4),
                UndeliveredDeliveries = deliveries.Count(x => x.DeliveryStep < 4),
                KiloMetersDriven = deliveries.Sum(x => x.Offer.Request.Kilometers),
                Profit = deliveries.Sum(x => x.Offer.FinalPrice),
                Loss = await repository.AllReadonly<CashRegister>().SumAsync(x => x.Amount),
                CO2Emissions = deliveries.Sum(x => x.CarbonEmission),
                AverageDeliveryDistance = deliveries.Average(x => x.Offer.Request.Kilometers),
            };
        }

        public async Task<ClientsStatisticsViewModel?> GetClientsStatisticsAsync()
        {
            var clients = await repository.All<LogisticsSystem.Infrastructure.Data.DataModels.ClientCompany>().ToListAsync();
            var model = new ClientsStatisticsViewModel
            {
                TotalClients = clients.Count(),
                NewRegistrations = clients.Where(x => x.CreatedAt.Date <= DateTime.Now.Date.AddDays(-30)).Count(),
                SatisfiedClients = await repository.All<Rating>().CountAsync(x => x.RatingStars == 4)
            };
            return model;
        }

        public async Task<Dictionary<string, decimal>> GetTop10ClientsAsync()
        {
            var deliveries = await repository.All<Delivery>().Include(x => x.Offer).ThenInclude(x => x.Request).ThenInclude(x => x.ClientCompany).ToListAsync();
            var dictionary = deliveries.GroupBy(x => x.Offer.Request.ClientCompany.Name)
                .OrderByDescending(x => x.Sum(x => x.Offer.FinalPrice))
                .Take(10)
                .ToDictionary(x => x.Key, x => x.Sum(x => x.Offer.FinalPrice));
            return dictionary;
        }

        public async Task<Dictionary<string, int>> GetTop10ClientsByDeliveriesAsync()
        {
            var deliveries = await repository.All<Delivery>().Include(x => x.Offer).ThenInclude(x => x.Request).ThenInclude(x => x.ClientCompany).ToListAsync();
            var dictionary = deliveries.GroupBy(x => x.Offer.Request.ClientCompany.Name)
                .OrderByDescending(x => x.Count())
                .Take(10)
                .ToDictionary(x => x.Key, x => x.Count());
            return dictionary;
        }

        public async Task<(decimal, int)> GetVehicleCostsDataForVehicleAsync(int id)
        {
            var vehicle = await repository.AllReadonly<Vehicle>().FirstOrDefaultAsync(x => x.Id == id);
            var deliveriesCnt = await repository.AllReadonly<Delivery>().Where(x => x.VehicleId == id).CountAsync();
            var cashRegisters = await repository.AllReadonly<CashRegister>().Where(x => x.Delivery.VehicleId == id && x.Type == "Vehicle Expenses").SumAsync(x => x.Amount);
            return (cashRegisters, deliveriesCnt);
        }

        public async Task<(string[], double, int)> GetDistanceAndDeliveriesForVehicleAsync(int id)
        {
            var vehicle = await repository.AllReadonly<Vehicle>().FirstOrDefaultAsync(x => x.Id == id);
            var deliveries = await repository.AllReadonly<Delivery>().Where(x => x.VehicleId == id).ToListAsync();
            var totalDistance = await repository.AllReadonly<Delivery>().Where(x => x.VehicleId == id).SumAsync(x => x.Offer.Request.Kilometers);
            var deliveriesCnt = await repository.AllReadonly<Delivery>().Where(x => x.VehicleId == id).CountAsync();
            var list = new[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            return (list, totalDistance, deliveriesCnt);
        }

        

        public async Task<Dictionary<string, int>> GetTopVehiclesWithMostDeliveriesAsync()
        {
            var deliveries = await repository.AllReadonly<LogiTrack.Infrastructure.Data.DataModels.Delivery>().Include(x => x.Vehicle).ToListAsync();
            var dictionary = deliveries.GroupBy(x => x.Vehicle.RegistrationNumber)
                .OrderByDescending(x => x.Count())
                .Take(10)
                .ToDictionary(x => x.Key, x => x.Count());
            return dictionary;
        }

        public async Task<Dictionary<string, decimal>> GetTopVehiclesByAdditionalCostsAsync()
        {
            var cashRegisters = await repository.AllReadonly<CashRegister>().Include(x => x.Delivery).ThenInclude(x => x.Vehicle).ToListAsync();
            var dictionary = cashRegisters.GroupBy(x => x.Delivery.Vehicle.RegistrationNumber)
                .ToDictionary(x => x.Key, x => x.Sum(x => x.Amount));
            return dictionary;
        }

        public async Task<Dictionary<string, double>> GetTopVehiclesByKilometersAsync()
        {
            var deliveries = await repository.AllReadonly<LogiTrack.Infrastructure.Data.DataModels.Delivery>().Include(x => x.Vehicle).Include(x => x.Offer).ThenInclude(x => x.Request).ToListAsync();
            var dictionary = deliveries.GroupBy(x => x.Vehicle.RegistrationNumber)
                .Take(5)
                .ToDictionary(x => x.Key, x => x.Sum(x => x.Offer.Request.Kilometers));
            return dictionary;
        }

        public async Task<Dictionary<string, int>> GetTopVehiclesDueForMaintenanceAsync()
        {
            var vehicles = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Vehicle>().ToListAsync();
            var topVehicles = vehicles.OrderByDescending(x => x.LastYearMaintenance).GroupBy(x => x.RegistrationNumber).Take(5).ToDictionary(
            x => x.Key,
            x => (DateTime.Now - x.Max(v => v.LastYearMaintenance)).Days
        );
            return topVehicles;
        }



        public async Task<Dictionary<string, double>> GetTopVehiclesClosestToKilometersAsync()
        {
            var vehicles = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Vehicle>().ToListAsync();
            var dictionary = vehicles.OrderByDescending(x => x.KilometersLeftToChangeParts).GroupBy(x => x.RegistrationNumber)
                .OrderByDescending(x => x.Sum(x => x.KilometersLeftToChangeParts))
                .Take(5)
                .ToDictionary(x => x.Key, x => x.Sum(x => x.KilometersLeftToChangeParts));
            return dictionary;
        }

        public async Task<(int domesticDeliveries, int internationalDeliveries)> GetDeliveryTypesForDriverAsync(int id)
        {
            var domesticDeliveries = await repository.AllReadonly<LogiTrack.Infrastructure.Data.DataModels.Delivery>().Where(x => x.DriverId == id && x.Offer.Request.Type == RequestTypeConstants.Domestic).CountAsync();
            var internationalDeliveries = await repository.AllReadonly<LogiTrack.Infrastructure.Data.DataModels.Delivery>().Where(x => x.DriverId == id && x.Offer.Request.Type == RequestTypeConstants.International).CountAsync();
            return (domesticDeliveries, internationalDeliveries);
        }



        public async Task<Dictionary<string, int>> GetTopDriversWithInternationalDeliveriesAsync()
        {
            var deliveries = await repository.AllReadonly<LogiTrack.Infrastructure.Data.DataModels.Delivery>().Include(x => x.Driver).Include(x => x.Offer).ThenInclude(x => x.Request).ToListAsync();
            var dictionary = deliveries.GroupBy(x => x.Driver.LicenseNumber)
                .OrderByDescending(x => x.Count(x => x.Offer.Request.Type == RequestTypeConstants.International))
                .Take(5)
                .ToDictionary(x => x.Key, x => x.Count(x => x.Offer.Request.Type == RequestTypeConstants.International));
            return dictionary;
        }

        public async Task<Dictionary<string, int>> GetTopDriversByExperienceAsync()
        {
            var drivers = await repository.AllReadonly<Driver>().ToListAsync();
            var dictionary = drivers.GroupBy(x => x.LicenseNumber)
                .OrderByDescending(x => x.Sum(y => y.YearOfExperience * 12 + y.MonthsOfExperience))
                .Take(5)
                .ToDictionary(x => x.Key, x => x.Sum(y => y.YearOfExperience * 12 + y.MonthsOfExperience));
            return dictionary;
        }

        public async Task<Dictionary<int, int>> GetMonthlyRequestPattersAsync()
        {
            var requests = await repository.AllReadonly<Request>().ToListAsync();
            if (requests.Any() == false)
            {
                return new Dictionary<int, int>();
            }
            var model = await repository.AllReadonly<Request>()
                .Where(x => x.CreatedAt.Month == DateTime.Now.Month)
                .GroupBy(x => x.CreatedAt.Day)
                .Select(x => new
                {
                    Day = x.Key,
                    Count = x.Count()
                })
                .ToDictionaryAsync(x => x.Day, x => x.Count);
            return model;
        }

        public async Task<(double successRate, double averageDelay)> GetDeliveryTimesForDriverAsync(int id)
        {
            var deliveries = await repository.AllReadonly<LogiTrack.Infrastructure.Data.DataModels.Delivery>()
               .Include(x => x.Offer).ThenInclude(x => x.Request).ThenInclude(x => x.ClientCompany).ThenInclude(x => x.User).Where(x => x.DriverId == id).ToListAsync();

            var totalDeliveries = deliveries.Count;
            if (totalDeliveries == 0)
            {
                return (0, 0);
            }

            var successfulDeliveries = deliveries.Count(x => x.DeliveryStep == 4 && (x.Offer.Request.ExpectedDeliveryDate >= x.ActualDeliveryDate));

            var successRate = (successfulDeliveries / (double)totalDeliveries) * 100;

            var delays = deliveries.Where(x => x.DeliveryStep == 4 && x.Offer.Request.ExpectedDeliveryDate < x.ActualDeliveryDate)
                .Select(x => (x.ActualDeliveryDate - x.Offer.Request.ExpectedDeliveryDate)?.TotalHours ?? 0)
                .ToList();

            var averageDelay = delays.Any() ? delays.Average() : 0;

            return (successRate, averageDelay);
        }
        public async Task<(double, double)> GetResponseTimeForRequestsAsync()
        {
            var offer = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Offer>().Include(x => x.Request).ToListAsync();
            var responseTimes = offer.Select(x => (x.OfferDate - x.Request.CreatedAt).TotalHours).ToList();

            if (offer == null || !offer.Any())
            {
                return (0, 0);
            }

            var maxResponseTime = responseTimes.Max();
            var averageResponseTime = responseTimes.Average();

            return (maxResponseTime, averageResponseTime);
        }

        public async Task<Dictionary<string, int>> GetTopClientsAsync()
        {
            var requests = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Request>().Include(x => x.ClientCompany).ToListAsync();
            var dictionary = requests.GroupBy(x => x.ClientCompany.Name)
                .OrderByDescending(x => x.Count())
                .Take(10)
                .ToDictionary(x => x.Key, x => x.Count());
            return dictionary;
        }

        public async Task<(int, int)> GetCargoRatiosAsync()
        {
            var requests = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Request>().Take(10).ToListAsync();
            var standartCargoCount = requests.Count(x => x.StandartCargo != null);
            var nonStandartCargoCount = requests.Count(x => x.NumberOfNonStandartGoods != null);
            return (standartCargoCount, nonStandartCargoCount);
        }

        public async Task<(string[], decimal[], decimal[])> GetDifferencesInOfferPricesForRequestsAsync()
        {
            var offers = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Offer>().Include(x => x.Request).Take(10).ToListAsync();
            var offerRefNumbers = offers.Select(x => x.OfferNumber).ToArray();
            var offerPrices = offers.Select(x => x.FinalPrice).ToArray();
            var approximatePrices = offers.Select(x => x.Request.ApproximatePrice).ToArray();
            return (offerRefNumbers, offerPrices, approximatePrices);
        }

        public async Task<(int, int)> GetOffersAcceptanceRateAsync()
        {
            var offers = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Offer>().Take(10).ToListAsync();
            var acceptedOffers = offers.Where(x => x.OfferStatus == StatusConstants.Approved).Count();
            var declinedOffers = offers.Where(x => x.OfferStatus == StatusConstants.Rejected).Count();
            return (acceptedOffers, declinedOffers);
        }
        public async Task<OfferStatisticsForClientViewModel?> GetOfferStatisticsAsync()
        {
            var offers = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Offer>().Include(x => x.Request).ToListAsync();
            return new OfferStatisticsForClientViewModel()
            {
                AverageVolume = offers.Average(x => x.Request.TotalVolume),
                AverageWeight = offers.Average(x => x.Request.TotalWeight),
                AveragePrice = offers.Average(x => x.FinalPrice),
                TotalPallets = offers.Sum(x => x.Request.StandartCargo?.NumberOfPallets ?? 0),
            };
        }
        public async Task<RequestStatisticsForClientViewModel?> GetRequestStatisticsForLogisticsAsync()
        {
            var requests = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Request>().ToListAsync();
            return new RequestStatisticsForClientViewModel
            {
                TotalRequestsWithOffers = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Offer>().CountAsync(),
                AveragePrice = requests.Average(x => x.ApproximatePrice),
                TotalRequests = requests.Count(),
                AverageVolume = requests.Average(x => x.TotalVolume),
                AverageWeight = requests.Average(x => x.TotalWeight),
            };
        }

        public async Task<decimal> GetRevenueDataForCompanyAsync(string companyUsername)
        {
            return await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Invoice>()
                .Where(x => x.Delivery.Offer.Request.ClientCompany.User.UserName == companyUsername)
                .SumAsync(x => x.Delivery.Offer.FinalPrice);
        }

        public async Task<int> GetVehiclesForRepairmentAsync()
        {
            return await repository.AllReadonly<Vehicle>().Where(x => x.LastYearMaintenance.AddMonths(1) >= DateTime.Now || x.KilometersLeftToChangeParts >= 500).CountAsync();
        }

        public async Task<VehicleStatisticsViewmodel?> GetVehicleStatisticsAsync()
        {
            var distanceTravelled = await repository.AllReadonly<Delivery>().SumAsync(x => x.Offer.Request.Kilometers);

            return new VehicleStatisticsViewmodel
            {
                TotalVehiclesCount = await repository.AllReadonly<Vehicle>().CountAsync(),
                TotalDistanceTravelled = distanceTravelled.ToString(),
                TotalFuelConsumed = (await repository.AllReadonly<Vehicle>().SumAsync(x => distanceTravelled / 100 * x.FuelConsumptionPer100Km)).ToString(),
                RefrigeratedVehiclesCount = await repository.AllReadonly<Vehicle>().Where(x => x.IsRefrigerated).CountAsync(),
                AverageDistancePerVehicle = (await repository.AllReadonly<Delivery>().SumAsync(x => x.Offer.Request.Kilometers) / await repository.AllReadonly<Vehicle>().CountAsync()).ToString(),
                VehiclesForRepairment = await repository.AllReadonly<Vehicle>().Where(x => x.LastYearMaintenance.AddMonths(1) >= DateTime.Now || x.KilometersLeftToChangeParts >= 500).CountAsync(),
            };
        }
        public async Task<FuelPricesStatisticsViewModel?> GetFuelPricesStatisticsAsync()
        {
            var fuelPrices = await repository.AllReadonly<FuelPrice>().ToListAsync();
            var todayPrice = fuelPrices.FirstOrDefault(x => x.Date.Date == DateTime.Now.Date)?.Price ?? 0;
            return new FuelPricesStatisticsViewModel
            {
                TodayPrice = fuelPrices.FirstOrDefault(x => x.Date.Date == DateTime.Now.Date)?.Price.ToString() ?? "0",
                AveragePrice = fuelPrices.Average(x => x.Price).ToString(),
                MaxPrice = fuelPrices.Max(x => x.Price).ToString(),
                MinPrice = fuelPrices.Min(x => x.Price).ToString(),
                Today = DateTime.Now.ToString("dd-MM-yyyy"),
            };
        }

        public async Task<(decimal, decimal)> MaxAndTodayPriceRatioAsync()
        {
            var fuelPrices = await repository.AllReadonly<FuelPrice>().ToListAsync();
            var maxPrice = fuelPrices.Max(x => x.Price);
            var todayPrice = fuelPrices.FirstOrDefault(x => x.Date.Date == DateTime.Now.Date)?.Price ?? 0;
            return (todayPrice, maxPrice);
        }

        public async Task<Dictionary<int, decimal>> GetMonthlyFuelPricesAsync()
        {
            var fuelPrices = await repository.AllReadonly<FuelPrice>().ToListAsync();
            var dictionary = fuelPrices.GroupBy(x => x.Date.Day)
                .ToDictionary(x => x.Key, x => x.Average(x => x.Price));
            return dictionary;
        }

        public async Task<Dictionary<string, decimal>> GetFuelPricesForYearAsync()
        {
            var fuelprices = await repository.AllReadonly<FuelPrice>().ToListAsync();
            var dictionary = fuelprices.GroupBy(x => x.Date.Month)
                .ToDictionary(x => x.Key.ToString(), x => x.Average(x => x.Price));
            return dictionary;
        }
    }
}

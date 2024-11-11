using LogiTrack.Core.Constants;
using LogiTrack.Core.Contracts;
using LogiTrack.Core.ViewModels.Delivery;
using LogiTrack.Core.ViewModels.Driver;
using LogiTrack.Infrastructure.Data.DataModels;
using LogiTrack.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace LogiTrack.Core.Services
{
    public class DriverService : IDriverService
    {
        private readonly IRepository repository;

        public DriverService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<bool> DriverHasDeliveryAsync(string username, int deliveryId)
        {
            return await repository.AllReadonly<Delivery>().AnyAsync(x => x.Id == deliveryId && x.Driver.User.UserName == username);
        }

        public async Task<bool> DriverWithUsernameExistsAsync(string username)
        {
            return await repository.AllReadonly<Driver>().AnyAsync(x => x.User.UserName == username);
        }

        public async Task<DriverViewModel?> GetDriverDetailsAsync(string username)
        {
            return await repository.AllReadonly<Driver>().Where(x => x.User.UserName == username)
                .Select(x => new DriverViewModel
                {
                    Name = x.Name,                   
                    Username = x.User.UserName,
                    Salary = x.Salary.ToString(),
                    Age = x.Age.ToString(),
                    YearOfExperience = x.YearOfExperience.ToString(),
                    MonthsOfExperience = x.MonthsOfExperience.ToString(),
                    Preferrences = x.Preferrences
                }).FirstOrDefaultAsync();
        }

        public async Task<LicenseViewModel?> GetDriversLicenseAsync(string username)
        {
            return await repository.AllReadonly<Driver>().Where(x => x.User.UserName == username)
                .Select(x => new LicenseViewModel
                {
                    LicenseNumber = x.LicenseNumber,
                    LicenseExpiryDate = x.LicenseExpiryDate,
                }).FirstOrDefaultAsync();
        }

        public async Task<DriverDashboardViewModel?> GetDriverDashboardAsync(string username)
        {
            var driver = await repository.AllReadonly<Infrastructure.Data.DataModels.Driver>().Where(x => x.User.UserName == username).FirstOrDefaultAsync();
            var model = new DriverDashboardViewModel()
            {
                KilometersDriven = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>().Where(x => x.DriverId == driver.Id).SumAsync(x => x.Offer.Request.Kilometers),
                KilometersDrivenlastMonth = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>().Where(x => x.DriverId == driver.Id && x.Offer.Request.ExpectedDeliveryDate.Month == DateTime.Now.Month - 1).SumAsync(x => x.Offer.Request.Kilometers),
                NewDeliveriesCount = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>().Where(x => x.DeliveryStep == 1).CountAsync()
            };
            model.LastDeliveries = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>().Where(x => x.DriverId == driver.Id).OrderByDescending(x => x.Offer.OfferDate).Take(5)
                .Select(x => new DeliveryForDriverDashboardViewModel
                {
                    Id = x.Id,
                    ClientCompanyName = x.Offer.Request.ClientCompany.Name,
                    PickupAddress = $"{x.Offer.Request.PickupAddress.Street}, {x.Offer.Request.PickupAddress.City}, {x.Offer.Request.PickupAddress.County}",
                    DeliveryAddress = $"{x.Offer.Request.DeliveryAddress.Street}, {x.Offer.Request.DeliveryAddress.City}, {x.Offer.Request.DeliveryAddress.County}",
                    ReferenceNumber = x.ReferenceNumber
                })
                .ToListAsync();
            model.NewDeliveries = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>().Where(x => x.DriverId == driver.Id && x.DeliveryStep == 1)
                .Select(x => new DeliveryForDriverDashboardViewModel
                {
                    Id = x.Id,
                    ClientCompanyName = x.Offer.Request.ClientCompany.Name,
                    PickupAddress = $"{x.Offer.Request.PickupAddress.Street}, {x.Offer.Request.PickupAddress.City}, {x.Offer.Request.PickupAddress.County}",
                    DeliveryAddress = $"{x.Offer.Request.DeliveryAddress.Street}, {x.Offer.Request.DeliveryAddress.City}, {x.Offer.Request.DeliveryAddress.County}",
                    ReferenceNumber = x.ReferenceNumber
                }).ToListAsync();
            return model;
        }

        public async Task AddStatusForDeliveryAsync(int deliveryId, AddStatusViewModel model, string username, string address)
        {
            var driver = await repository.All<Infrastructure.Data.DataModels.Driver>().FirstOrDefaultAsync(x => x.User.UserName == username);
            var delivery = await repository.All<Infrastructure.Data.DataModels.Delivery>().FirstOrDefaultAsync(x => x.Id == deliveryId && x.DriverId == driver.Id);
            var deliveryTracking = new Infrastructure.Data.DataModels.DeliveryTracking
            {
                DeliveryId = deliveryId,
                DriverId = driver.Id,
                Notes = model.Notes,
                Timestamp = DateTime.Now,
                StatusUpdate = model.StatusUpdate,
                Latitude = model.Latitude.Value,
                Longitude = model.Longitude.Value,
                Address = address
            };
            var calendarEvent = new Infrastructure.Data.DataModels.CalendarEvent
            {
                EventType = model.StatusUpdate,
                Date = DateTime.Now,
                ClientCompanyId = delivery.Offer.Request.ClientCompanyId
            };
            switch (model.StatusUpdate)
            {
                case DeliveryTrackingStatusConstants.Collected:
                    delivery.DeliveryStep = 2;
                    calendarEvent.Title = $"Delivery {delivery.ReferenceNumber} collected";
                    break;
                case DeliveryTrackingStatusConstants.InTransit:
                    delivery.DeliveryStep = 3;
                    break;
                case DeliveryTrackingStatusConstants.Delivered:
                    delivery.DeliveryStep = 4;
                    calendarEvent.Title = $"Delivery {delivery.ReferenceNumber} delivered";
                    break;
            }
            await repository.AddAsync(calendarEvent);
            await repository.AddAsync(deliveryTracking);
            await repository.SaveChangesAsync();
        }

        public async Task<List<DriverForLogisticsViewModel>> GetDriversAsync(string? name = null, string? licenseNumber = null, bool? isAvailable = null, string? salary = null)
        {
            var drivers = await repository.AllReadonly<Infrastructure.Data.DataModels.Driver>()
                .Include(x => x.User).ToListAsync();
            if (name != null)
            {
                drivers = drivers.Where(x => x.Name.Contains(name)).ToList();
            }
            if (licenseNumber != null)
            {
                drivers = drivers.Where(x => x.LicenseNumber.Contains(licenseNumber)).ToList();
            }
            if (isAvailable != null)
            {
                drivers = drivers.Where(x => x.IsAvailable == isAvailable).ToList();
            }
            if (salary != null)
            {
                drivers = drivers.Where(x => x.Salary.ToString().Contains(salary)).ToList();
            }
            return drivers.Select(x => new DriverForLogisticsViewModel
            {
                Id = x.Id,
                Name = x.Name,
                LicenseNumber = x.LicenseNumber,
                LicenseExpiryDate = x.LicenseExpiryDate.ToString(),
                InternatinalDeliveries = x.Deliveries.Count(x => x.Offer.Request.Type == RequestTypeConstants.International),
                DomesticDeliveries = x.Deliveries.Count(x => x.Offer.Request.Type == RequestTypeConstants.Domestic),
                Username = x.User.UserName,
                Salary = x.Salary.ToString(),
                Age = x.Age.ToString(),
                YearOfExperience = x.YearOfExperience.ToString(),
                MonthsOfExperience = x.MonthsOfExperience.ToString(),
                IsAvailable = x.IsAvailable,
                Preferrences = x.Preferrences
            }).ToList();
     
        }

        public async Task<List<DriverForLogisticsViewModel>> GetDriversBySearchtermAsync(string? searchTerm)
        {
            var drivers = await repository.AllReadonly<Infrastructure.Data.DataModels.Driver>().ToListAsync();
            if (searchTerm != null)
            {
                drivers = drivers.Where(x => x.Name.Contains(searchTerm) || x.LicenseNumber.Contains(searchTerm) || x.Salary.ToString().Contains(searchTerm)).ToList();
            }
            return drivers.Select(x => new DriverForLogisticsViewModel
            {
                Id = x.Id,
                Name = x.Name,
                LicenseNumber = x.LicenseNumber,
                LicenseExpiryDate = x.LicenseExpiryDate.ToString(),
                InternatinalDeliveries = x.Deliveries.Count(x => x.Offer.Request.Type == RequestTypeConstants.International),
                DomesticDeliveries = x.Deliveries.Count(x => x.Offer.Request.Type == RequestTypeConstants.Domestic),
                Username = x.User.UserName,
                Salary = x.Salary.ToString(),
                Age = x.Age.ToString(),
                YearOfExperience = x.YearOfExperience.ToString(),
                MonthsOfExperience = x.MonthsOfExperience.ToString(),
                IsAvailable = x.IsAvailable,
                Preferrences = x.Preferrences
            }).ToList();
        }

        public async Task<bool> DriverWithIdExistsAsync(int id)
        {
            return await repository.AllReadonly<Infrastructure.Data.DataModels.Driver>().AnyAsync(x => x.Id == id);
        }

        public async Task<DriverForLogisticsViewModel?> GetDriverDetailsForLogisticsAsync(int id)
        {
            return await    repository.AllReadonly<Infrastructure.Data.DataModels.Driver>().Where(x => x.Id == id)
                .Select(x => new DriverForLogisticsViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Phone = x.User.PhoneNumber,
                    LicenseNumber = x.LicenseNumber,
                    LicenseExpiryDate = x.LicenseExpiryDate.ToString(),
                    InternatinalDeliveries = x.Deliveries.Count(x => x.Offer.Request.Type == RequestTypeConstants.International),
                    DomesticDeliveries = x.Deliveries.Count(x => x.Offer.Request.Type == RequestTypeConstants.Domestic),
                    Username = x.User.UserName,
                    Salary = x.Salary.ToString(),
                    Age = x.Age.ToString(),
                    YearOfExperience = x.YearOfExperience.ToString(),
                    MonthsOfExperience = x.MonthsOfExperience.ToString(),
                    IsAvailable = x.IsAvailable,
                    Preferrences = x.Preferrences
                }).FirstOrDefaultAsync();
        }
    }
}

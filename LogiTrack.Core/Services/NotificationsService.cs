using LogiTrack.Infrastructure.Data.DataModels;
using LogiTrack.Infrastructure;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace LogiTrack.Core.Services
{
    public class NotificationsService : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public NotificationsService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await SendNotificationsAsync();

                await Task.Delay(TimeSpan.FromDays(3), stoppingToken);
            }
        }

        private async Task SendNotificationsAsync()
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var logisticsUser = dbContext.Users.Where(x => x.UserName == "logistics").ToList();
                var speditorUser = dbContext.Users.Where(x => x.UserName == "speditor").ToList();

                var drivers = dbContext.Drivers.Where(x => x.LicenseExpiryDate.AddDays(30) >= DateTime.Now).ToList(); 
                var vehiclesForYearlyMaintenance = dbContext.Vehicles.Where(x => x.LastYearMaintenance.AddYears(1) >= DateTime.Now.AddDays(-30)).ToList();
                var vehiclesForPartsChange = dbContext.Vehicles.Where(x => x.KilometersLeftToChangeParts <= 1000).ToList();

                foreach (var driver in drivers)
                {                   
                    var notificationForDriver = new Notification
                    {
                        Title = "License Expiry",
                        Message = $"Your license will expire on {driver.LicenseExpiryDate.ToString("dd-MM-yyyy")}",
                        Date = DateTime.Now,
                        UserId = driver.UserId
                    };
                    var notificationForLogistics = new Notification
                    {
                        Title = "License Expiry",
                        Message = $"Driver {driver.Name} license will expire on {driver.LicenseExpiryDate.ToString("dd-MM-yyyy")}.",
                        Date = DateTime.Now,
                        UserId = logisticsUser[0].Id
                    };
                    var notificationForSpeditor = new Notification
                    {
                        Title = "License Expiry",
                        Message = $"Driver {driver.Name} license will expire on {driver.LicenseExpiryDate.ToString("dd-MM-yyyy")}.",
                        Date = DateTime.Now,
                        UserId = speditorUser[0].Id
                    };
                    dbContext.Notifications.Add(notificationForSpeditor);
                    dbContext.Notifications.Add(notificationForLogistics);
                    dbContext.Notifications.Add(notificationForDriver);
                }

                foreach (var vehicle in vehiclesForYearlyMaintenance)
                {
                    var notificationForLogistics = new Notification
                    {
                        Title = "License Expiry",
                        Message = $"Vehicle with reg. No. {vehicle.RegistrationNumber} should go to yearly maintenance in {(vehicle.LastYearMaintenance.AddYears(1) - DateTime.Now).Days} days.",
                        Date = DateTime.Now,
                        UserId = logisticsUser[0].Id
                    };
                    var notificationForSpeditor = new Notification
                    {
                        Title = "License Expiry",
                        Message = $"Vehicle with reg. No. {vehicle.RegistrationNumber} should go to yearly maintenance in {(vehicle.LastYearMaintenance.AddYears(1) - DateTime.Now).Days} days.",
                        Date = DateTime.Now,
                        UserId = speditorUser[0].Id
                    };
                    dbContext.Notifications.Add(notificationForSpeditor);
                    dbContext.Notifications.Add(notificationForLogistics);
                }

                foreach(var vehicle in vehiclesForYearlyMaintenance)
                {
                    var notificationForLogistics = new Notification
                    {
                        Title = "License Expiry",
                        Message = $"Vehicle with reg. No. {vehicle.RegistrationNumber} should have its parts changed in {vehicle.KilometersLeftToChangeParts} km.",
                        Date = DateTime.Now,
                        UserId = logisticsUser[0].Id
                    };
                    var notificationForSpeditor = new Notification
                    {
                        Title = "License Expiry",
                        Message = $"Vehicle with reg. No. {vehicle.RegistrationNumber} should have its parts changed in {vehicle.KilometersLeftToChangeParts} km.",
                        Date = DateTime.Now,
                        UserId = speditorUser[0].Id
                    };
                    dbContext.Notifications.Add(notificationForSpeditor);
                    dbContext.Notifications.Add(notificationForLogistics);
                }

                await dbContext.SaveChangesAsync();
            }
        }
    
    }
}

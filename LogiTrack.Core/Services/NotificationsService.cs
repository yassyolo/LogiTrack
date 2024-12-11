using LogiTrack.Infrastructure.Data.DataModels;
using LogiTrack.Infrastructure;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using LogisticsSystem.Infrastructure.Data.DataModels;

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
				try
				{
					await SendNotificationsAsync(stoppingToken);
				}
				catch (Exception ex)
				{
				}

				await Task.Delay(TimeSpan.FromDays(3), stoppingToken);
            }
        }

        private async Task SendNotificationsAsync(CancellationToken cancellationToken)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
				var logisticsUser = await dbContext.Users.SingleOrDefaultAsync(x => x.UserName == "logistics", cancellationToken);
                var speditorUser = await dbContext.Users.SingleOrDefaultAsync(x => x.UserName == "speditor", cancellationToken);


				var drivers = await dbContext.Drivers.Where(x => x.LicenseExpiryDate <= DateTime.Now.AddDays(30)).ToListAsync(cancellationToken);
				var vehiclesForYearlyMaintenance = await dbContext.Vehicles.Where(x => x.LastYearMaintenance.AddYears(1) <= DateTime.Now.AddDays(30)).ToListAsync(cancellationToken); 
                var vehiclesForPartsChange = await dbContext.Vehicles.Where(x => x.KilometersLeftToChangeParts <= 1000).ToListAsync(cancellationToken);

				foreach (var driver in drivers)
				{
					AddDriverNotification(dbContext, driver, logisticsUser.Id, speditorUser.Id);
				}

				foreach (var vehicle in vehiclesForYearlyMaintenance)
				{
					AddVehicleMaintenanceNotification(dbContext, vehicle, logisticsUser.Id, speditorUser.Id);
				}

				foreach (var vehicle in vehiclesForPartsChange)
				{
					AddVehiclePartsChangeNotification(dbContext, vehicle, logisticsUser.Id, speditorUser.Id);
				}

				await dbContext.SaveChangesAsync(cancellationToken);
			}
        }
		private void AddDriverNotification(ApplicationDbContext dbContext, Driver driver, string logisticsUserId, string speditorUserId)
		{
			var driverNotification = new Notification
			{
				Title = "License Expiry",
				Message = $"Your license will expire on {driver.LicenseExpiryDate:dd-MM-yyyy}.",
				Date = DateTime.Now,
				UserId = driver.UserId
			};
			var logisticsNotification = new Notification
			{
				Title = "License Expiry",
				Message = $"Driver {driver.Name}'s license will expire on {driver.LicenseExpiryDate:dd-MM-yyyy}.",
				Date = DateTime.Now,
				UserId = logisticsUserId
			};
			var speditorNotification = new Notification
			{
				Title = "License Expiry",
				Message = $"Driver {driver.Name}'s license will expire on {driver.LicenseExpiryDate:dd-MM-yyyy}.",
				Date = DateTime.Now,
				UserId = speditorUserId
			};

			dbContext.Notifications.AddRange(driverNotification, logisticsNotification, speditorNotification);
		}

		private void AddVehicleMaintenanceNotification(ApplicationDbContext dbContext, Vehicle vehicle, string logisticsUserId, string speditorUserId)
		{
			var maintenanceDaysLeft = (vehicle.LastYearMaintenance.AddYears(1) - DateTime.Now).Days;
			var logisticsNotification = new Notification
			{
				Title = "Yearly Maintenance Due",
				Message = $"Vehicle with reg. No. {vehicle.RegistrationNumber} requires yearly maintenance in {maintenanceDaysLeft} days.",
				Date = DateTime.Now,
				UserId = logisticsUserId
			};
			var speditorNotification = new Notification
			{
				Title = "Yearly Maintenance Due",
				Message = $"Vehicle with reg. No. {vehicle.RegistrationNumber} requires yearly maintenance in {maintenanceDaysLeft} days.",
				Date = DateTime.Now,
				UserId = speditorUserId
			};

			dbContext.Notifications.AddRange(logisticsNotification, speditorNotification);
		}

		private void AddVehiclePartsChangeNotification(ApplicationDbContext dbContext, Vehicle vehicle, string logisticsUserId, string speditorUserId)
		{
			var logisticsNotification = new Notification
			{
				Title = "Parts Replacement Due",
				Message = $"Vehicle with reg. No. {vehicle.RegistrationNumber} needs parts replaced in {vehicle.KilometersLeftToChangeParts} km.",
				Date = DateTime.Now,
				UserId = logisticsUserId
			};
			var speditorNotification = new Notification
			{
				Title = "Parts Replacement Due",
				Message = $"Vehicle with reg. No. {vehicle.RegistrationNumber} needs parts replaced in {vehicle.KilometersLeftToChangeParts} km.",
				Date = DateTime.Now,
				UserId = speditorUserId
			};

			dbContext.Notifications.AddRange(logisticsNotification, speditorNotification);
		}

	}
}

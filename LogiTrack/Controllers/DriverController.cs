using LogiTrack.Core.Contracts;
using static LogiTrack.Core.Constants.MessageConstants.ErrorMessages;
using Microsoft.AspNetCore.Mvc;
using LogiTrack.Core.ViewModels.Delivery;
using LogiTrack.Core.Services;
using Microsoft.AspNetCore.Authorization;
using LogiTrack.Core.Constants;
using LogiTrack.Extensions;

namespace LogiTrack.Controllers
{
    [Authorize(Roles = UserRolesConstants.Driver)]
    public class DriverController : Controller
    {
        private readonly IDeliveryService deliveryService;
        private readonly IDriverService driverService;
        private readonly GeocodingService geocodingService;
        private readonly IEventService eventService;
        private readonly IStatisticsService statisticsService;
        private readonly IDashboardService dashboardService;
        private readonly IDeliveryStatisticsService deliveryStatisticsService;

        public DriverController(IDeliveryService deliveryService, IDriverService driverService, GeocodingService geocodingService, IEventService eventService, IStatisticsService statisticsService, IDashboardService dashboardService, IDeliveryStatisticsService deliveryStatisticsService)
        {
            this.deliveryService = deliveryService;
            this.driverService = driverService;
            this.geocodingService = geocodingService;
            this.eventService = eventService;
            this.statisticsService = statisticsService;
            this.dashboardService = dashboardService;
            this.deliveryStatisticsService = deliveryStatisticsService;
        }

        [HttpGet]
        public async Task<IActionResult> Dashboard()
        {
            var username = User.GetUsername();
            if (await driverService.DriverWithUsernameExistsAsync(username) == false)
            {
                return BadRequest(DriverNotFoundErrorMessage);
            }
            var model = await dashboardService.GetDriverDashboardAsync(username);
            return View(model);
        }

        [HttpGet]
        public async Task<JsonResult> GetCalendarEvents()
        {
            var username = User.GetUsername();
            var model = await eventService.GetUserEventsAsync(username);
            return Json(model);
        }

        [HttpGet]
        public IActionResult SearchDelivery()
        {
            var model = new SearchDeliveryByReferenceNumberViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SearchDelivery(SearchDeliveryByReferenceNumberViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            var username = User.GetUsername();
            if (await driverService.DriverWithUsernameExistsAsync(username) == false)
            {
                return BadRequest(DriverNotFoundErrorMessage);
            }

            var deliveryId = await deliveryService.GetDeliveryByReferenceNumberAsync(model.ReferenceNumber);
            if (deliveryId == default)
            {
                TempData["NotFound"] = DeliveryNotFoundErrorMessage;
                return View(model);
            }

            if (await driverService.DriverHasDeliveryAsync(username, deliveryId) == false)
            {
                TempData["NotAuthorize"] = DriverDoesNotHaveDeliveryErrorMessage;
                return View(model);
            }

            return RedirectToAction(nameof(DeliveryDetails), new { id = deliveryId });
        }

        [HttpGet]
        public async Task<IActionResult> DeliveryDetails(int id)
        {
            if (await deliveryService.DeliveryWithIdExistsAsync(id) == false)
            {
                return NotFound(DeliveryNotFoundErrorMessage);
            }

            var username = User.GetUsername();
            if (await driverService.DriverWithUsernameExistsAsync(username) == false)
            {
                return BadRequest(DriverNotFoundErrorMessage);
            }

            if (await driverService.DriverHasDeliveryAsync(username, id) == false)
            {
                return Unauthorized(DriverDoesNotHaveDeliveryErrorMessage);
            }

            var model = await deliveryService.GetDeliveryDetailsForDriverAsync(id);
            return View(model);
        }
      
        [HttpGet]
        public async Task<IActionResult> AddStatus(int id)
        {
            if (await deliveryService.DeliveryWithIdExistsAsync(id) == false)
            {
                return BadRequest(DeliveryNotFoundErrorMessage);
            }

            var username = User.GetUsername();
            if (await driverService.DriverWithUsernameExistsAsync(username) == false)
            {
                return BadRequest(DriverNotFoundErrorMessage);
            }

            if (await driverService.DriverHasDeliveryAsync(username, id) == false)
            {
                return Unauthorized(DriverDoesNotHaveDeliveryErrorMessage);
            }

            var model = new AddStatusViewModel
            {
                DeliveryId = id
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddStatus(int id, AddStatusViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }
            if(model.Latitude == null || model.Longitude == null)
            {
                return View(model);
            }

            var address = await geocodingService.GetAddress(model.Latitude.Value, model.Longitude.Value);
            if (address == null)
            {
                ModelState.AddModelError(string.Empty, InvalidCoordinatesErrorMessage);
                return View(model);
            }

            var username = User.GetUsername();
            await driverService.AddStatusForDeliveryAsync(id, model, username, address);

            return RedirectToAction(nameof(DeliveryDetails), new { id = id });
        }

        [HttpGet]
        public async Task<IActionResult> SearchDeliveries([FromQuery] FilterDeliveriesForDriverViewModel query)
        {
            var username = User.GetUsername();
            if (await driverService.DriverWithUsernameExistsAsync(username) == false)
            {
                return BadRequest(DriverNotFoundErrorMessage);
            }

            var model = await deliveryService.GetDeliveriesForDriverBySearchtermAsync(username, query.SearchTerm);
            query.Deliveries = model;
            model = await deliveryService.GetDeliveriesForDriverAsync(username, query.ReferenceNumber, query.EndDate, query.StartDate, query.DeliveryAddress, query.PickupAddress, query.IsNew);
            query.Deliveries = model;
            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> Details()
        {
            var username = User.GetUsername();
            if (await driverService.DriverWithUsernameExistsAsync(username) == false)
            {
                return BadRequest(DriverNotFoundErrorMessage);
            }
            var model = await driverService.GetDriverDetailsAsync(username);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> LicenseDetails()
        {
            var username = User.GetUsername();
            if (await driverService.DriverWithUsernameExistsAsync(username) == false)
            {
                return BadRequest(DriverNotFoundErrorMessage);
            }

            var model = await driverService.GetDriversLicenseAsync(username);
            if(model.LicenseExpiryDate < DateTime.Now.AddDays(-30))
            {
                TempData["LicenseExpired"] = LicenseExpirationErrorMessage;
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DeliveryStatistics()
        {
            var username = User.GetUsername();
            if (await driverService.DriverWithUsernameExistsAsync(username) == false)
            {
                return BadRequest(DriverNotFoundErrorMessage);
            }
            var model = await statisticsService.GetDeliveryStatisticsForDriverAsync(username);
            return View(model);
        }

        [HttpGet]
        public async Task<JsonResult> GetDeliveryTypes()
        {
            var username = User.GetUsername();

            var model = await deliveryStatisticsService.GetDestinationTypesForDriverAsync(username);
            return Json(new { Domestic = model.domesticDeliveries, International = model.internationalDeliveries });
        }
        
        [HttpGet]
        public async Task<JsonResult> GetDeliveryCounts()
        {
            var username = User.GetUsername();
            
            var model = await deliveryStatisticsService.GetDeliveriesCountForDriverAsync(username);
            return Json(new { months = model.Item1, deliveries = model.Item2 });
        }

        [HttpGet]
        public async Task<JsonResult> GetDeliveryTimes()
        {
            var username = User.GetUsername();

            var model = await deliveryStatisticsService.GetDeliveryTimesForDriverAsync(username);
            return Json(new { successRate = model.successRate, averageDelay = model.averageDelay });
        }
    }
}

using LogiTrack.Core.Contracts;
using LogiTrack.Core.ViewModels.Accountant;
using static LogiTrack.Core.Constants.MessageConstants.ErrorMessages;
using Microsoft.AspNetCore.Mvc;
using LogiTrack.Core.ViewModels.Delivery;
using LogiTrack.Extensions;
using LogiTrack.Core.ViewModels.Driver;
using LogiTrack.Core.Services;

namespace LogiTrack.Controllers
{
    public class DriverController : Controller
    {
        private readonly IDeliveryService deliveryService;
        private readonly IDriverService driverService;
        private readonly GeocodingService geocodingService;

        public DriverController(IDeliveryService deliveryService, IDriverService driverService, GeocodingService geocodingService)
        {
            this.deliveryService = deliveryService;
            this.driverService = driverService;
            this.geocodingService = geocodingService;
        }

        [HttpGet]
        public async Task<IActionResult> Dashboard()
        {
            /*var username = User.GetUsername();
            if (await driverService.DriverWithUsernameExistsAsync(username) == false)
            {
                return BadRequest(DriverNotFoundErrorMessage);
            }*/
            var model = await deliveryService.GetDriverDashboardAsync("driver1@example.com");
            return View(model);
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

            /*var username = User.GetUsername();
            if (await driverService.DriverWithUsernameExistsAsync(username) == false)
            {
                return BadRequest(DriverNotFoundErrorMessage);
            }*/

            var deliveryId = await deliveryService.GetDeliveryByReferenceNumberAsync(model.ReferenceNumber);
            if (deliveryId == null)
            {
                TempData["NotFound"] = DeliveryNotFoundErrorMessage;
                return View(model);
            }

            if (await driverService.DriverHasDeliveryAsync("driver1@example.com", deliveryId) == false)
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

            /*var username = User.GetUsername();
            if (await driverService.DriverWithUsernameExistsAsync(username) == false)
            {
                return BadRequest(DriverNotFoundErrorMessage);
            }

            if (await driverService.DriverHasDeliveryAsync("speditor", id) == false)
            {
                return Unauthorized(DriverDoesNotHaveDeliveryErrorMessage);
            }*/

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

            //var username = User.GetUsername();
            var username = "driver1@example.com";
            if (await deliveryService.DriverWithUsernameExistsAsync(username) == false)
            {
                return BadRequest(DriverNotFoundErrorMessage);
            }

            if (await deliveryService.DriverHasDeliveryAsync(username, id) == false)
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
            //var username = User.GetUsername();
            var username = "driver1@example.com";
            await deliveryService.AddStatusForDeliveryAsync(id, model, username, address);
            return RedirectToAction(nameof(DeliveryDetails), new { id = id });
        }

        [HttpGet]
        public async Task<IActionResult> SearchDeliveries([FromQuery] SearchDeliveryForDriverViewModel query)
        {
            var username = "driver1@example.com";
            if (await driverService.DriverWithUsernameExistsAsync(username) == false)
            {
                return BadRequest(DriverNotFoundErrorMessage);
            }
            var model = await deliveryService.GetDeliveriesForDriverAsync(username, query.ReferenceNumber, query.EndDate, query.StartDate, query.DeliveryAddress, query.PickupAddress, query.IsNew);
            query.Deliveries = model;
            model = await deliveryService.GetDeliveriesForDriverBySearchtermAsync(username, query.SearchTerm);
            query.Deliveries = model;
            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> Details()
        {
            var username = "driver1@example.com";
            if (await deliveryService.DriverWithUsernameExistsAsync(username) == false)
            {
                return BadRequest(DriverNotFoundErrorMessage);
            }
            var model = await driverService.GetDriverDetailsAsync(username);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> LicenseDetails()
        {
            var username = "driver1@example.com";
            if (await deliveryService.DriverWithUsernameExistsAsync(username) == false)
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
    }
}

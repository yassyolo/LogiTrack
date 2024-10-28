using LogiTrack.Core.Contracts;
using LogiTrack.Core.CustomExceptions;
using LogiTrack.Core.Services;
using LogiTrack.Core.ViewModels.Accountant;
using static LogiTrack.Core.Constants.MessageConstants.ErrorMessages;
using Microsoft.AspNetCore.Mvc;
using LogiTrack.Core.ViewModels.Delivery;
using LogiTrack.Extensions;

namespace LogiTrack.Controllers
{
    public class DriverController : Controller
    {
        private readonly IDeliveryService deliveryService;

        public DriverController(IDeliveryService deliveryService)
        {
            this.deliveryService = deliveryService;
        }

        [HttpGet]
        public async Task<IActionResult> Dashboard()
        {
            /*var username = User.GetUsername();
            if (await deliveryService.DriverWithUsernameExistsAsync(username) == false)
            {
                return BadRequest(DriverNotFoundErrorMessage);
            }*/
            var model = await deliveryService.GetDriverDashboardAsync("speditor");
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
            if (await deliveryService.DriverWithUsernameExistsAsync(username) == false)
            {
                return BadRequest(DriverNotFoundErrorMessage);
            }*/
            var deliveryId = await deliveryService.GetDeliveryByReferenceNumberAsync(model.ReferenceNumber);
            if (deliveryId == null)
            {
                TempData["NotFound"] = DeliveryNotFoundErrorMessage;
                return View(model);
            }
            if (await deliveryService.DriverHasDeliveryAsync("speditor", deliveryId)== false)
            {
                TempData["NotAuthorize"] = DriverDoesNotHaveDeliveryErrorMessage;
                return View(model);
            }
            return RedirectToAction(nameof(DeliveryDetails), new { id = deliveryId });
        }

        public async Task<IActionResult> DeliveryDetails(int id)
        {
            if (await deliveryService.DeliveryWithIdExistsAsync(id) == false)
            {
                return NotFound(DeliveryNotFoundErrorMessage);
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
            //var username = User.GetUsername();
            var username = "speditor";
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
            //TODO: add validation
            if(model.Latitude == null || model.Longitude == null)
            {
                return View(model);
            }
            //var username = User.GetUsername();
            var username = "speditor";
            await deliveryService.AddStatusForDeliveryAsync(id, model, username);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> SearchDeliveries([FromQuery] SearchDeliveryViewModel query)
        {
            var username = "speditor";
            if (await deliveryService.DriverWithUsernameExistsAsync(username) == false)
            {
                return BadRequest(DriverNotFoundErrorMessage);
            }
            var model = await deliveryService.GetDeliveryForDriverAsync(username, query.ReferenceNumber, query.EndDate, query.StartDate, query.DeliveryAddress, query.PickupAddress);
            query.Delivery = model;
            model = await deliveryService.GetDeliveryForDriverBySearchtermAsync(username, query.SearchTerm);
            query.Delivery = model;
            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> NewDeliveries([FromQuery] SearchDeliveryViewModel query)
        {
            var username = "speditor";
            if (await deliveryService.DriverWithUsernameExistsAsync(username) == false)
            {
                return BadRequest(DriverNotFoundErrorMessage);
            }
            var model = await deliveryService.GetNewDeliveryForDriverAsync(username, query.ReferenceNumber, query.EndDate, query.StartDate, query.DeliveryAddress, query.PickupAddress);
            query.Delivery = model;
            return View(query);
        }
    }
}

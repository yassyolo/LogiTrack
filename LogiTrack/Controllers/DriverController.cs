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

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> SearchDelivery([FromQuery] SearchDeliveryViewModel query)
        {
            try
            {
                var model = await deliveryService.GetDeliveryForDriverByReferenceNumberAsync(query.SearchTerm);
                query.SearchTerm = model.ReferenceNumber;
                query.Delivery = model;
                return View(query);
            }
            catch (DeliveryNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> AddStatus(int id)
        {
            if (await deliveryService.DeliveryWithIdExistsAsync(id) == false)
            {
                return BadRequest(DeliveryNotFoundErrorMessage);
            }
            var username = User.GetUsername();
            if (await deliveryService.DriverWithUsernameExistsAsync(username) == false)
            {
                return BadRequest(DriverNotFoundErrorMessage);
            }
            if (await deliveryService.DriverHasDeliveryAsync(username, id))
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
            var username = User.GetUsername();
            await deliveryService.AddStatusForDeliveryAsync(id, model, username);
            return RedirectToAction("Index");
        }
    }
}

using LogiTrack.Core.Contracts;
using LogiTrack.Core.CustomExceptions;
using LogiTrack.Core.ViewModels.Accountant;
using static LogiTrack.Core.Constants.MessageConstants.ErrorMessages;
using Microsoft.AspNetCore.Mvc;
using LogiTrack.Core.Constants;

namespace LogiTrack.Controllers
{
    public class AccountantController : Controller
    {
        private readonly IAccountantService accountantService;
        private readonly IVehicleService vehicleService;
        private readonly IDeliveryService deliveryService;

        public AccountantController(IAccountantService accountantService, IVehicleService vehicleService, IDeliveryService deliveryService)
        {
            this.accountantService = accountantService;
            this.vehicleService = vehicleService;
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
                var model = await deliveryService.GetDeliveryByReferenceNumberAsync(query.SearchTerm);
                query.SearchTerm = model.ReferenceNumber;
                query.Delivery = model;
                return View(query);
            }
            catch(DeliveryNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> AddCashRegister(int id)
        {
            if (await deliveryService.DeliveryWithIdExistsAsync(id) == false)
            {
                return NotFound(DeliveryNotFoundErrorMessage);
            }
            var model = new AddCashRegisterViewModel()
            {
                DeliveryId = id
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCashRegister(int id, AddCashRegisterViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }
            try
            {
                await deliveryService.AddCashRegisterForDeliveryAsync(id, model);
                return RedirectToAction(nameof(Index));
            }
            catch (DeliveryNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}

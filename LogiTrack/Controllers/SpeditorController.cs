using LogiTrack.Core.Contracts;
using LogiTrack.Core.CustomExceptions;
using static LogiTrack.Core.Constants.MessageConstants.ErrorMessages;
using Microsoft.AspNetCore.Mvc;
using LogiTrack.Core.ViewModels.Vehicle;

namespace LogiTrack.Controllers
{
    public class SpeditorController : Controller
    {
        private readonly IVehicleService vehicleService;

        public SpeditorController(IVehicleService vehicleService)
        {
            this.vehicleService = vehicleService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> SearchVehicle([FromQuery] SearchVehicleViewModel query)
        {
            try
            {
                var model = await vehicleService.GetVehicleByRegistrationNumberAsync(query.SearchTerm);
                query.SearchTerm = model.RegistrationNumber;
                query.Vehicle = model;
                return View(query);
            }
            catch (PricesPerSizeNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (VehicleNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ChangePricesForVehicle(int id)
        {
            if (await vehicleService.VehicleWithIdExistsAsync(id) == false)
            {
                return NotFound(VehicleNotFoundErrorMessage);
            }
            var model = await vehicleService.GetPricesForVehicleAsync(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePricesForVehicle(int id, AddPricesForVehicleViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }
            try
            {
                await vehicleService.ChagePricesForVehicleAsync(id, model);
                return RedirectToAction(nameof(Index));
            }
            catch (VehicleNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> AddPricesForVehicle(int id)
        {
            if (await vehicleService.VehicleWithIdExistsAsync(id) == false)
            {
                return NotFound(VehicleNotFoundErrorMessage);
            }
            var model = new AddPricesForVehicleViewModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPricesForVehicle(int id, AddPricesForVehicleViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }
            await vehicleService.AddPricesForVehicleAsync(id, model);
            return RedirectToAction(nameof(Index));
        }
    }
}

using LogiTrack.Core.Contracts;
using static LogiTrack.Core.Constants.MessageConstants.ErrorMessages;
using Microsoft.AspNetCore.Mvc;
using LogiTrack.Core.ViewModels.Clients;
using LogiTrack.Core.ViewModels.Delivery;
using LogiTrack.Core.ViewModels.Driver;
using Microsoft.AspNetCore.Identity;
using static LogiTrack.Core.Helpers.RandomPasswordGenerator;
using LogiTrack.Core.ViewModels.Vehicle;
using LogiTrack.Core.ViewModels.FuelPrice;
using LogiTrack.Core.ViewModels.Offer;
using LogiTrack.Core.ViewModels.Request;

namespace LogiTrack.Controllers
{
    public class SpeditorController : Controller
    {
        private readonly IVehicleService vehicleService;
        private readonly IClientsService clientsService;
        private readonly IUserService userService;
        private readonly IDeliveryService deliveryService;
        private readonly IDriverService driverService;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IOfferService offerService;
        private readonly IStatisticsService statisticsService;
        private readonly IDashboardService dashboardService;
        private IFuelPriceService fuelPriceService;
        private IRequestService requestService;

        public SpeditorController(IVehicleService vehicleService, IClientsService clientsService, IUserService userService, IDeliveryService deliveryService, IDriverService driverService, UserManager<IdentityUser> userManager, IOfferService offerService, IStatisticsService statisticsService, IDashboardService dashboardService, IFuelPriceService fuelPriceService, IRequestService requestService)
        {
            this.vehicleService = vehicleService;
            this.clientsService = clientsService;
            this.userService = userService;
            this.deliveryService = deliveryService;
            this.driverService = driverService;
            this.userManager = userManager;
            this.offerService = offerService;
            this.statisticsService = statisticsService;
            this.dashboardService = dashboardService;
            this.fuelPriceService = fuelPriceService;
            this.requestService = requestService;
        }

        [HttpGet]
        public async Task<IActionResult> Dashboard()
        {
            var model = await dashboardService.GetSpeditorDashboardAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ClientsRegister([FromQuery] FilterClientsViewModel query)
        {
            var model = await clientsService.GetClientsForClientsRegisterBySearchTermAsync(query.SearchTerm);
            query.Clients = model;
            model = await clientsService.GetClientsForClientsRegisterAsync(query.Active, query.Name, query.Email, query.RegistrationNumber, query.PhoneNumber);
            query.Clients = model;

            return View(query);
        }

        [HttpGet]
        public IActionResult SearchCompany()
        {
            var model = new SearchCompanyByRegistrationNumberViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SearchCompany(SearchCompanyByRegistrationNumberViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }
            var companyId = await clientsService.GetCompanyIdByRegistrationNumberAsync(model.RegistrationNumber);
            if (companyId == default)
            {
                TempData["NotFound"] = "Company not found";
                return View(model);
            }
            return RedirectToAction(nameof(ClientDetails), new { id = companyId });
        }

        [HttpGet]
        public async Task<IActionResult> ClientDetails(int id)
        {
            if (await clientsService.CompanyWithIdExistsAsync(id) == false)
            {
                return NotFound("Company not found");
            }
            var model = await clientsService.GetClientDetailsAsync(id);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ChangeQuotients(int id)
        {
            if (await vehicleService.VehicleWithIdExistsAsync(id) == false)
            {
                return NotFound(VehicleNotFoundErrorMessage);
            }
            var model = await vehicleService.GetQuotientsForVehicleAsync(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeQuotients(int id, ChangeQuotientsForVehicleViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }
            if (await vehicleService.VehicleWithIdExistsAsync(id) == false)
            {
                return NotFound(VehicleNotFoundErrorMessage);
            }
            await vehicleService.ChageQuotientsForVehicleAsync(id, model);
            return RedirectToAction(nameof(VehicleDetails), new {id = id});
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
            var deliveryId = await deliveryService.GetDeliveryByReferenceNumberAsync(model.ReferenceNumber);
            if (deliveryId == default)
            {
                TempData["NotFound"] = DeliveryNotFoundErrorMessage;
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
            var model = await deliveryService.GetDeliveryDetailsForLogisticsAsync(id);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DeliveryStatistics()
        {
            var model = await statisticsService.GetDeliveryStatisticsAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DeliveriesRegister([FromQuery] FilterDeliveriesForLogististicsViewModel query)
        {
            var model = await deliveryService.GetDeliveriesForLogisticsBySearchtermAsync(query.SearchTerm);
            query.Deliveries = model;
            model = await deliveryService.GetDeliveriesForLogisticsAsync(query.ReferenceNumber, query.EndDate, query.StartDate, query.MinPrice, query.MaxPrice, query.IsDelivered, query.IsPaid, query.PickupAddress, query.DeliveryAddress);
            query.Deliveries = model;

            return View(query);
        }

        [HttpGet]
        public IActionResult SearchDriver()
        {
            var model = new SearchDriverByLicenseNumberViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SearchDriver(SearchDriverByLicenseNumberViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            var driverId = await driverService.GetDriverByLicenseNumberAsync(model.LicenseNumber);
            if (driverId == default)
            {
                TempData["NotFound"] = "Driver not found";
                return View(model);
            }
            return RedirectToAction(nameof(DriverDetails), new { id = driverId });
        }

        [HttpGet]
        public async Task<IActionResult> DriverDetails(int id)
        {
            if (await driverService.DriverWithIdExistsAsync(id) == false)
            {
                return NotFound("Driver not found");
            }
            var model = await driverService.GetDriverDetailsForLogisticsAsync(id);
            return View(model);
        }

        [HttpGet]
        public IActionResult AddDriver()
        {
            var model = new AddDriverViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddDriver(AddDriverViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            var user = await driverService.AddDriverUserAsync(model);
            if (user == null)
            {
                return BadRequest();
            }
            var generatedPassword = GenerateRandomPassword();   
            await userManager.AddPasswordAsync(user, generatedPassword);
            await driverService.AddDriverAsync(model, user.Id);
            return RedirectToAction(nameof(DriversRegister));
        }

        [HttpGet]
        public async Task<IActionResult> EditDriver(int id)
        {
            if (await driverService.DriverWithIdExistsAsync(id) == false)
            {
                return NotFound(DriverNotFoundErrorMessage);
            }
            var model = await driverService.GetDriverForEditAsync(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditDriver(int id, AddDriverViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }
            await driverService.EditDriverAsync(id, model);
            return RedirectToAction(nameof(DriversRegister));
        }

        [HttpGet]
        public async Task<IActionResult> DriversRegister([FromQuery] FilterDriversViewModel query)
        {
            var model = await driverService.GetDriversBySearchtermAsync(query.SearchTerm);
            query.Drivers = model;
            model = await driverService.GetDriversAsync(query.Name, query.LicenseNumber, query.IsAvailable, query.MinSalary, query.MaxSalary);
            query.Drivers = model;

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> DriverStatistics()
        {
            var model = await statisticsService.GetDriversStatisticsAsync();
            return View(model);
        }

        [HttpGet]
        public IActionResult AddVehicle()
        {
            var model = new AddVehicleViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddVehicle(AddVehicleViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }
            await vehicleService.AddVehicleAsync(model);
            return RedirectToAction(nameof(VehiclesRegister));
        }

        [HttpGet]
        public IActionResult SearchVehicle()
        {
            var model = new SearchVehicleByRegistrationNumberViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SearchVehicle(SearchVehicleByRegistrationNumberViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            var vehicleId = await vehicleService.GetVehicleIdByRegistrationNumberAsync(model.RegistrationNumber);
            if (vehicleId == default)
            {
                TempData["NotFound"] = "Vehicle not found";
                return View(model);
            }
            return RedirectToAction(nameof(VehicleDetails), new { id = vehicleId });
        }

        [HttpGet]
        public async Task<IActionResult> VehiclesRegister([FromQuery] FilterVehiclesForLogisticsViewModel query)
        {
            var model = await vehicleService.GetVehiclesBySearchTermAsync(query.SearchTerm);
            query.Vehicles = model;
            model = await vehicleService.GetVehiclesAsync(query.Refrigerated, query.RegistrationNumber, query.VehicleType, query.MinWeightCapacity, query.MaxWeightCapacity, query.MinVolume, query.MaxVolume, query.ForMaintentance);
            query.Vehicles = model;
            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> VehicleDetails(int id)
        {
            if (await vehicleService.VehicleWithRegistrationNumberExistsAsync(id) == false)
            {
                return NotFound("Vehicle not found");
            }
            var model = await vehicleService.GetVehicleDetailsAsync(id);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> VehicleStatistics()
        {
            var model = await statisticsService.GetVehicleStatisticsAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditVehicle(int id)
        {
            if (await vehicleService.VehicleWithIdExistsAsync(id) == false)
            {
                return NotFound("Vehicle not found");
            }
            var model = await vehicleService.GetVehicleForEditAsync(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditVehicle(int id, AddVehicleViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }
            await vehicleService.EditVehicleAsync(id, model);
            return RedirectToAction(nameof(VehiclesRegister));
        }

        [HttpGet]
        public IActionResult AddFuelPrice()
        {
            var model = new AddFuelPriceViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddFuelPrice(AddFuelPriceViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }
            await fuelPriceService.AddFuelPriceAsync(model);
            return RedirectToAction(nameof(FuelPricesRegister));
        }

        [HttpGet]
        public async Task<IActionResult> FuelPricesRegister([FromQuery] FilterFuelPricesViewModel query)
        {
            var model = await fuelPriceService.GetFuelPricesAsync(query.MinPrice, query.MaxPrice, query.StartDate, query.EndDate);
            query.FuelPrices = model;
            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> FuelPricesStatistics()
        {
            var model = await statisticsService.GetFuelPricesStatisticsAsync();
            return View(model);
        }
        
        [HttpGet]
        public async Task<JsonResult> MaxAndTodayPriceRatio()
        {
            var model = await statisticsService.MaxAndTodayPriceRatioAsync();
            return Json(new { currentPrice = model.Item1, maxPrice  = model.Item2});
        }
        
        [HttpGet]
        public async Task<JsonResult> GetMonthlyFuelPrices()
        {
            var model = await statisticsService.GetMonthlyFuelPricesAsync();
            return Json(model);
        }
        
        [HttpGet]
        public async Task<JsonResult> GetFuelPricesForYear()
        {
            var model = await statisticsService.GetFuelPricesForYearAsync();
            return Json(model);
        }

        [HttpGet]
        public async Task<IActionResult> OffersRegister([FromQuery] FilterOffersViewModel query)
        {
            var model = await offerService.GetOffersForLogisticsBySearchTermAsync(query.SearchTerm);
            query.Offers = model;
            model = await offerService.GetOffersForLogisticsAsync(query.DeliveryAddress, query.PickupAddress, query.StartDate, query.EndDate, query.MinPrice, query.MaxPrice, query.IsApproved, query.MinWeight, query.MaxWeight);
            query.Offers = model;
            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> OfferDetails(int id)
        {
            if (await offerService.OfferWithIdExistsAsync(id) == false)
            {
                return BadRequest(OfferNotFoundErrorMessage);
            }
            var model = await offerService.GetOfferDetailsAsync(id);
            return View(model);
        }
        [HttpGet]
        public IActionResult SearchOffer()
        {
            var model = new SearchOfferByOfferNumberViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SearchOffer(SearchOfferByOfferNumberViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            var offerId = await offerService.GetOfferIdByOfferNumberAsync(model.OfferNumber);
            if (offerId == default)
            {
                TempData["NotFound"] = "Offer not found.";
                return View(model);
            }

            return RedirectToAction(nameof(OfferDetails), new { id = offerId });
        }

        [HttpGet]
        public async Task<IActionResult> PendingRequests([FromQuery] AllPendingRequestsViewModel query)
        {
            var model = await requestService.GetPendingRequestsAsync(query.SharedTruck, query.StartDate,query.EndDate,query.MinWeight,query.MaxWeight,query.MinVolume,query.MaxVolume,query.PickupAddress,query.DeliveryAddress);
            query.Requests = model;
            return View(query); 
        }
        [HttpGet]
        public async Task<IActionResult> RequestsStatistics()
        {
            var model = await statisticsService.GetRequestStatisticsForLogisticsAsync();
            return View(model);
        }
        [HttpGet]
        public IActionResult SearchRequest()
        {
            var model = new SearchRequestByReferenceNumberViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SearchRequest(SearchRequestByReferenceNumberViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }
            var requestId = await requestService.GetRequestIdByReferenceNumberAsync(model.ReferenceNumber);
            if (requestId == default)
            {
                TempData["NotFound"] = "Request not found.";
                return View(model);
            }

            return RedirectToAction(nameof(RequestDetails), new { id = requestId });
        }

        [HttpGet]
        public async Task<IActionResult> RequestDetails(int id)
        {
            if (await requestService.RequestWithIdExistsAsync(id) == false)
            {
                return BadRequest(RequestNotFoundErrorMessage);
            }

            var model = await requestService.GetRequestDetailsForLogisticsAsync(id);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> RequestsRegister([FromQuery] FilterRequestsForLogisticsViewModel query)
        {
            var model = await requestService.GetRequestsForLogisticsBySearchTermAsync(query.SearchTerm);
            query.Requests = model;
            model = await requestService.GetRequestsForLogisticsAsync(query.StartDate, query.EndDate, query.IsApproved, query.SharedTruck, query.MinWeight, query.MaxWeight, query.MinPrice, query.MaxPrice, query.PickupAddress, query.DeliveryAddress);
            query.Requests = model;

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> PendingRequestDetails(int id)
        {
            var model = await requestService.GetPendingRequestDetailsAsync(id);
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> OfferStatistics()
        {
            var model = await statisticsService.GetOfferStatisticsAsync();
            return View(model);
        }
    }
}

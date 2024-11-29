using LogiTrack.Core.Contracts;
using LogiTrack.Core.ViewModels.CashRegister;
using LogiTrack.Core.ViewModels.Clients;
using LogiTrack.Core.ViewModels.Delivery;
using LogiTrack.Core.ViewModels.Driver;
using LogiTrack.Core.ViewModels.Invoice;
using LogiTrack.Core.ViewModels.Offer;
using LogiTrack.Core.ViewModels.Request;
using LogiTrack.Core.ViewModels.Vehicle;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static LogiTrack.Core.Constants.MessageConstants.ErrorMessages;
using static LogiTrack.Core.Helpers.RandomPasswordGenerator;

namespace LogiTrack.Controllers
{
    public class LogisticsController : Controller
    {
        private readonly IClientsService clientsService;
        private readonly IUserService userService;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IEmailSenderService emailSenderService;
        private readonly IDriverService driverService;
        private readonly IVehicleService vehicleService;
        private readonly IRequestService requestService;
        private readonly ICashRegisterService cashRegisterService;
        private readonly IInvoiceService invoiceService;
        private readonly IOfferService offerService;
        private readonly IDeliveryService deliveryService;
        private readonly IStatisticsService statisticsService;
        private readonly IEventService eventService;
        private readonly IDashboardService dashboardService;
        private readonly IDeliveryStatisticsService deliveryStatisticsService;

        public LogisticsController(IClientsService clientsService, IUserService userService, UserManager<IdentityUser> userManager, IEmailSenderService emailSenderService, IDriverService driverService, IVehicleService vehicleService, IRequestService requestService, ICashRegisterService cashRegisterService, IInvoiceService invoiceService, IOfferService offerService, IDeliveryService deliveryService, IStatisticsService statisticsService, IEventService eventService, IDashboardService dashboardService, IDeliveryStatisticsService deliveryStatisticsService)
        {
            this.clientsService = clientsService;
            this.userService = userService;
            this.userManager = userManager;
            this.emailSenderService = emailSenderService;
            this.driverService = driverService;
            this.vehicleService = vehicleService;
            this.requestService = requestService;
            this.cashRegisterService = cashRegisterService;
            this.invoiceService = invoiceService;
            this.offerService = offerService;
            this.deliveryService = deliveryService;
            this.statisticsService = statisticsService;
            this.eventService = eventService;
            this.dashboardService = dashboardService;
            this.deliveryStatisticsService = deliveryStatisticsService;
        }

        [HttpGet]
        public async Task<IActionResult> Dashboard()
        {
            //var username = User.GetUsername();
            var username = "logistics";
            if (await userService.LogisticsUserWithUsernameExistsAsync(username) == false)
            {
                return BadRequest("Not found");
            }
            var model = await dashboardService.GetLogisticsCompanyDashboardAsync();
            return View(model);
        }
       
        [HttpGet]
        public async Task<JsonResult> GetCalendarEvents()
        {
            //var username = User.GetUsername();
            var username = "logistics";

            var model = await eventService.GetUserEventsAsync(username);
            return Json(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetPendingRegistrations()
        {
            var model = await clientsService.GetPendingRegistrationsAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> NewCompanyDetails(int id)
        {
            if (await clientsService.CompanyWithIdExistsAsync(id) == false)
            {
                return NotFound("Company not found");
            }
            var model = await clientsService.GetNewCompanyDetailsForLogisticsAsync(id);
            return View(model);
        }

        [HttpPut]
        public async Task<IActionResult> ApprovePendingRegistration(int id)
        {
            if (await clientsService.CompanyWithIdExistsAsync(id) == false)
            {
                return BadRequest(ClientCompanyNotFoundErrorMessage);
            }
            var user = await userService.ApprovePendingRegistrationForCompanyWithIdAsync(id);
            var generatedPassword = GenerateRandomPassword();
            var result = await userManager.AddPasswordAsync(user, generatedPassword);
            if (result.Succeeded)
            {
                var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                var confirmationLink = Url.Action(nameof(ConfirmEmail), "Logistics", new { userId = user.Id, token = token }, Request.Scheme);

                var emailBody = $"<h1>Confirm Your Email</h1><p>Please confirm your email by clicking the link: <a href='{confirmationLink}'>Confirm Email</a></p>";
                await emailSenderService.SendEmailAsync(user.Email, "Email Confirmation", emailBody);
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    return BadRequest(error.Description);
                }
            }
            return RedirectToAction(nameof(GetPendingRegistrations));
        }

        [HttpPut]
        public async Task<IActionResult> RejectPendingRegistration(int id)
        {
            if (await clientsService.CompanyWithIdExistsAsync(id) == false)
            {
                return BadRequest(ClientCompanyNotFoundErrorMessage);
            }
            await clientsService.RejectPendingRegistrationForCompanyWithIdAsync(id);
                      
            return RedirectToAction(nameof(GetPendingRegistrations));
        }

        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return BadRequest();
            }
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return BadRequest();
            }
            var result = userManager.ConfirmEmailAsync(user, token);
            if (result.Result.Succeeded)
            {
                return RedirectToAction(nameof(GetPendingRegistrations));
            }
            return RedirectToAction(nameof(GetPendingRegistrations));
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
        public async Task<JsonResult> GetRequestPriceDifferences(int id)
        {
            var model = await statisticsService.GetRequestPriceDifferenceForDeliveriesAsync(id);
            var result = model.Select(item => new
            {
                offerReference = item.offerReference,
                approximatePrice = item.approximatePrice,
                finalPrice = item.finalPrice
            }).ToList();

            return Json(result);
        }

        [HttpGet]
        public async Task<JsonResult> GetDeliveryTypes() //TODO:add company username
        {
            //var companyUsername = User.GetUsername();
            var username = "clientcompany1";
            /*if (await clientsService.UserWithEmailExistsAsync(username) == false)
             *{
             *  return BadRequest(ClientCompanyNotFoundErrorMessage);
             }*/
            var model = await deliveryStatisticsService.GetDestinationTypesForCompanyAsync(username);
            return Json(new { Domestic = model.domesticDeliveries, International = model.internationalDeliveries });
        }

        [HttpGet]
        public async Task<JsonResult> GetVehiclesForRepairment()
        {
            var data = await statisticsService.GetVehiclesForRepairmentAsync();
            return Json(new { data = data });
        }

        [HttpGet]
        public async Task<JsonResult> GetDeliveryCountsForCompany(int id)
        {
            var companyUsername = await userService.GetCompanyUsernameByIdAsync(id);
          
            var model = await deliveryStatisticsService.GetDeliveriesCountForCompanyAsync(companyUsername);
            return Json(new { months = model.Item1, deliveries = model.Item2 });
        }
        
        [HttpGet]
        public async Task<JsonResult> GetRevenueDataForCompany(int id)
        {
            var companyUsername = await userService.GetCompanyUsernameByIdAsync(id);

            var model = await statisticsService.GetRevenueDataForCompanyAsync(companyUsername);
            return Json(new { totalRevenue = model });
        }
        
        [HttpGet]
        public async Task<JsonResult> GetVehicleCostsDataForVehicle(int id)
        {
            var model = await statisticsService.GetVehicleCostsDataForVehicleAsync(id);
            return Json(new { totalCosts = model.Item1, numDeliveries = model.Item2 });
        }
        
        [HttpGet]
        public async Task<JsonResult> GetDistanceAndDeliveriesForVehicle(int id)
        {
            var model = await statisticsService.GetDistanceAndDeliveriesForVehicleAsync(id);
            return Json(new { months = model.Item1, totalDistance = model.Item2, totalDeliveries = model.Item3 });
        }

        [HttpGet]
        public async Task<IActionResult> VehicleStatistics()
        {
            var model = await statisticsService.GetVehicleStatisticsAsync();
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
            /*var companyUsername = User.GetUsername();
            if (await clientsService.UserWithEmailExistsAsync(companyUsername) == false)
            {
                return BadRequest(ClientCompanyNotFoundErrorMessage);
            }*/

            var model = await requestService.GetRequestsForLogisticsAsync(query.StartDate, query.EndDate, query.IsApproved, query.SharedTruck, query.MinWeight, query.MaxWeight, query.MinPrice, query.MaxPrice, query.PickupAddress, query.DeliveryAddress);
            query.Requests = model;
            model = await requestService.GetRequestsForLogisticsBySearchTermAsync(query.SearchTerm);
            query.Requests = model;
            return View(query);
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
        public async Task<IActionResult> ClientsStatistics()
        {
            var model = await statisticsService.GetClientsStatisticsAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<JsonResult> GetTop10Clients()
        {
            var model = await statisticsService.GetTop10ClientsAsync();
            return Json(model);
        }
        
        [HttpGet]
        public async Task<JsonResult> GetTop10ClientsByDeliveries()
        {
            var model = await statisticsService.GetTop10ClientsByDeliveriesAsync();
            return Json(model);
        }

        [HttpGet]
        public async Task<IActionResult> DriverStatistics()
        {
            var model = await statisticsService.GetDriversStatisticsAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<JsonResult> GetDriversExpiryLicenses()
        {
            var expiringLicenses = await statisticsService.GetDriversExpiryLicensesCountAsync();
            return Json(new { expiringLicenses = expiringLicenses });
        }

        [HttpGet]
        public async Task<JsonResult> GetTop10DriversByDeliveries()
        {
            var model = await statisticsService.GetTop10DriversByDeliveriesAsync();
            return Json(model);
        }

        [HttpGet]
        public async Task<JsonResult> GetLicenseExpirationOverview()
        {
            var model = await statisticsService.GetLicenseExpirationOverviewAsync();
            return Json(model);
        }

        [HttpGet]
        public async Task<JsonResult> GetDriverAvailability()
        {
            var model = await statisticsService.GetDriverAvailabilityAsync();
            return Json(model);
        }

        [HttpGet]
        public async Task<IActionResult> SearchCashRegisters([FromQuery] FilterCashRegistersViewModel query)
        {
            try
            {
                var model = await cashRegisterService.GetCashRegistersAsync(query.DeliveryReferenceNumber, query.StartDate, query.EndDate, query.Type, query.MinPrice, query.MaxPrice);
                query.CashRegisters = model;
                return View(query);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> CashRegisterStatistics()
        {
            var model = await deliveryStatisticsService.GetCashRegisterStatisticsAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<JsonResult> GetDistanceAdditionalCostData()
        {
            var data = await statisticsService.GetDistanceAdditionalCostDataAsync();
            return Json(data); 
        }

        [HttpGet]
        public async Task<JsonResult> GetTop10DeliveriesByAdditionalCost()
        {
            var data = await statisticsService.GetTop10DeliveriesByAdditionalCostAsync();
            return Json(data); 
        }

        [HttpGet]
        public async Task<JsonResult> GetClientRequestToDeliveryConversionRate(int id)
        {
            var data = await statisticsService.GetClientRequestToDeliveryDataAsync(id);
            return Json(new { requests = data.Item1, deliveries = data.Item2 }); 
        }

        [HttpGet]
        public async Task<JsonResult> GetClientDeliveryCostStatistics(int id)
        {
            var result = await statisticsService.GetClientDeliveryCostStatisticsAsync(id);
            return Json(new { maxCost  = result.Item1, avgCost = result.Item2}); 
        }

        [HttpGet]
        public async Task<IActionResult> InvoicesStatistics()
        {
            var model = await deliveryStatisticsService.GetInvoicesStatisticsAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> InvoicesRegister([FromQuery] FilterInvoicesViewModel query)
        {
            try
            {
                var model = await invoiceService.GetInvoicesAsync(query.DeliveryReferenceNumber, query.StartDate, query.EndDate, query.CompanyName, query.IsPaid, query.MinAmount, query.MaxAmount);
                query.Invoices = model;
                return View(query);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
        public async Task<JsonResult> GetDeliveryCounts()
        {
            var model = await deliveryStatisticsService.GetDeliveryCountsAsync();
            return Json(new { months = model.Item1, deliveries = model.Item2 });
        }

        [HttpGet]
        public async Task<JsonResult> GetDestinationTypes()
        {
            var model = await deliveryStatisticsService.GetDestinationTypesAsync();
            return Json(new { Domestic = model.domesticDeliveries, International = model.internationalDeliveries });
        }
        [HttpGet]
        public async Task<JsonResult> GetDeliveryTimes()
        {
            var model = await deliveryStatisticsService.GetDeliveryTimesAsync();
            return Json(new { successRate = model.successRate, averageDelay = model.averageDelay });
        }
        
        [HttpGet]
        public async Task<JsonResult> GetPopularDeliveryCities()
        {
            var model = await deliveryStatisticsService.GetPopularDeliveryCitiesAsync();
            var result = model.Select(c => new
            {
                city = c.Key, 
                deliveryCount = c.Value 
            });

            return Json(result);
        }
        
        [HttpGet]
        public async Task<JsonResult> GetDeliveryRatingsDistribution()
        {
            var model = await deliveryStatisticsService.GetDeliveryRatingsDistributionAsync();
            var result = model.Select(c => new
            {
                rating = c.Key, 
                count = c.Value 
            });

            return Json(result);
        }

        [HttpGet]
        public async Task<JsonResult> GetTopVehiclesWithMostDeliveries()
        {
            var topVehicles = await statisticsService.GetTopVehiclesWithMostDeliveriesAsync();
            return Json(topVehicles);
        }

        [HttpGet]
        public async Task<JsonResult> GetTopVehiclesByAdditionalCosts()
        {
            var result = await statisticsService.GetTopVehiclesByAdditionalCostsAsync();
            return Json(result);
        }

        [HttpGet]
        public async Task<JsonResult> GetTopVehiclesByKilometers()
        {
            var result = await statisticsService.GetTopVehiclesByKilometersAsync();
            return Json(result);
        }

        [HttpGet]
        public async Task<JsonResult> GetTopVehiclesDueForMaintenance()
        {
            var result = await statisticsService.GetTopVehiclesDueForMaintenanceAsync();
            return Json(result);
        }
        
        [HttpGet]
        public async Task<JsonResult> GetTopVehiclesClosestToKilometers()
        {
            var result = await statisticsService.GetTopVehiclesClosestToKilometersAsync();
            return Json(result);
        }

        [HttpGet]
        public async Task<JsonResult> GetDeliveryTypesForDriver(int id) 
        {
            var model = await statisticsService.GetDeliveryTypesForDriverAsync(id);
            return Json(new { Domestic = model.domesticDeliveries, International = model.internationalDeliveries });
        }

        [HttpGet]
        public async Task<JsonResult> GetDeliveryCountsForDriver(int id)
        {
            var model = await deliveryStatisticsService.GetDeliveryCountsForDriverAsync(id);
            return Json(new { months = model.Item1, deliveries = model.Item2 });
        }

        [HttpGet]
        public async Task<JsonResult> GetDeliveryTimesForDriver(int id)
        {
            var model = await statisticsService.GetDeliveryTimesForDriverAsync(id);
            return Json(new { successRate = model.successRate, averageDelay = model.averageDelay });
        }

        [HttpGet]
        public async Task<JsonResult> GetTopDriversWithInternationalDeliveries()
        {
            var model = await statisticsService.GetTopDriversWithInternationalDeliveriesAsync();
            return Json(model);
        }
        
        [HttpGet]
        public async Task<JsonResult> GetTopDriversByExperience()
        {
            var model = await statisticsService.GetTopDriversByExperienceAsync();
            return Json(model);
        }

        [HttpGet]
        public async Task<IActionResult> RequestsStatistics()
        {
            var model = await statisticsService.GetRequestStatisticsForLogisticsAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<JsonResult> GetMonthlyRequestPatterns()
        {
            var model = await statisticsService.GetMonthlyRequestPattersAsync();
            return Json(new { data = model });
        }

        [HttpGet]
        public async Task<JsonResult> GetRequestStatusDistribution()
        {
            var model = await statisticsService.GetRequestStatusDistributionAsync();
            return Json(new { statusCounts = model });
        }

        [HttpGet]
        public async Task<JsonResult> GetAverageResponseTime()
        {
            var model = await statisticsService.GetResponseTimeForRequestsAsync();
            return Json(new { maxResponseTime = model.Item1, averageResponseTime = model.Item2 });
        }
       
        [HttpGet]
        public async Task<JsonResult> GetTopClients()
        {
            var model = await statisticsService.GetTopClientsAsync();
            return Json(model);
        }

        [HttpGet]
        public async Task<JsonResult> GetOffersAcceptanceRate()
        {
            var model = await statisticsService.GetOffersAcceptanceRateAsync();
            return Json(new { accepted = model.Item1, rejected = model.Item2 });
        }

        [HttpGet]
        public async Task<JsonResult> GetDifferencesInOfferPrices()
        {
            var model = await statisticsService.GetDifferencesInOfferPricesForRequestsAsync();
            return Json(new { offers = model.Item1, clientPrices = model.Item2, companyPrices = model.Item3 });
        }

        [HttpGet]
        public async Task<IActionResult> OfferStatistics()
        {
            var model = await statisticsService.GetOfferStatisticsAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<JsonResult> GetCargoRatios()
        {
            var model = await statisticsService.GetCargoRatiosAsync();
            return Json(new { standardCount = model.Item1, nonStandardCount = model.Item2 });
        }
    }
}

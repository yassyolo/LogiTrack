using LogiTrack.Core.Contracts;
using LogiTrack.Core.ViewModels.Clients;
using static LogiTrack.Core.Constants.MessageConstants.ErrorMessages;
using static LogiTrack.Core.Constants.UserRolesConstants;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using LogiTrack.Core.Services;
using Microsoft.AspNetCore.Authorization;
using LogiTrack.Core.ViewModels.Invoice;
using LogiTrack.Core.ViewModels.Offer;
using LogiTrack.Core.ViewModels.Request;
using LogiTrack.Core.ViewModels.Delivery;

namespace LogiTrack.Controllers
{
    public class ClientsController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IClientsService clientsService;
        private readonly GeocodingService geocodingService;
        private readonly IDeliveryService deliveryService;
        private readonly IInvoiceService invoiceService;
        private readonly IRequestService requestService;
        private readonly IOfferService offerService;
        private readonly IEventService eventService;
        private readonly IStatisticsService statisticsService;
        private readonly IDashboardService dashboardService;
        private readonly IUserService userService;
        private readonly IDeliveryStatisticsService deliveryStatisticsService;

        public ClientsController(UserManager<IdentityUser> userManager, IClientsService clientsService, GeocodingService geocodingService, IDeliveryService deliveryService, IInvoiceService invoiceService, IRequestService requestService, IOfferService offerService, IEventService eventService, IStatisticsService statisticsService, IDashboardService dashboardService, IUserService userService, IDeliveryStatisticsService deliveryStatisticsService)
        {
            this.userManager = userManager;
            this.clientsService = clientsService;
            this.geocodingService = geocodingService;
            this.deliveryService = deliveryService;
            this.invoiceService = invoiceService;
            this.requestService = requestService;
            this.offerService = offerService;
            this.eventService = eventService;
            this.statisticsService = statisticsService;
            this.dashboardService = dashboardService;
            this.userService = userService;
            this.deliveryStatisticsService = deliveryStatisticsService;
        }

        [HttpGet]
        public async Task<IActionResult> Dashboard()
        {
            /*var username = User.GetUsername();
            if (await clientsService.UserWithEmailExistsAsync(username) == false)
            {
                return BadRequest(ClientCompanyNotFoundErrorMessage);
            }*/
            var model = await dashboardService.GetClientCompanyDashboardAsync("clientcompany1");
            return View(model);
        }

        [HttpGet]
        public async Task<JsonResult> GetCalendarEvents()
        {
            /*var username = User.GetUsername();
            if (await clientsService.UserWithEmailExistsAsync(username) == false)
            {
                return BadRequest(ClientCompanyNotFoundErrorMessage);
            }*/
            var model = await eventService.GetUserEventsAsync("clientcompany1");
            return Json(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            var model = new RegisterViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }
            if (await userService.UserWithEmailExistsAsync(model.Email))
            {
                ModelState.AddModelError("Email", EmailAlreadyExistsErrorMessage);
                return View(model);
            }
            if (await userService.UserWithPhoneNumberExistsAsync(model.PhoneNumber))
            {
                ModelState.AddModelError("PhoneNumber", PhoneNumberAlreadyExistsErrorMessage);
                return View(model);
            }
            if (await userService.UserWithPhoneNumberExistsAsync(model.AlternativePhoneNumber))
            {
                ModelState.AddModelError("AlternativePhoneNumber", PhoneNumberAlreadyExistsErrorMessage);
                return View(model);
            }
            var user = await userService.RegisterUserAsync(model);
            await userService.RegisterClientCompanyAsync(model, user);

            return RedirectToAction(nameof(SuccessfullRegistration));
        }

        [HttpGet]
        public IActionResult SuccessfullRegistration()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MakeRequest()
        {
            var model = new MakeRequestViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MakeRequest(MakeRequestViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            var pickupAddress = $"{model.PickupStreet}, {model.PickupCity}, {model.PickupCountry}";
            var pickupCoordinates = await geocodingService.GetCoordinates(pickupAddress);
            if (pickupCoordinates == null)
            {
                ModelState.AddModelError("PickupAddress", InvalidAddressErrorMessage);
                return View(model);           
            }

            var deliveryAddress = $"{model.DeliveryStreet}, {model.DeliveryCity}, {model.DeliveryCountry}";
            var deliveryCoordinates = await geocodingService.GetCoordinates(deliveryAddress);
            if (deliveryCoordinates == null)
            {
                ModelState.AddModelError("DeliveryAddress", InvalidAddressErrorMessage);
                return View(model);
            }

            model.DeliveryLatitude = deliveryCoordinates.Value.Latitude;
            model.DeliveryLongitude = deliveryCoordinates.Value.Longtitude;
            model.PickupLatitude = pickupCoordinates.Value.Latitude;
            model.PickupLongitude = pickupCoordinates.Value.Longtitude;

            /*var username = User.GetUsername();
             if (await clientsService.UserWithEmailExistsAsync(username) == false)
             {
                 return BadRequest(ClientCompanyNotFoundErrorMessage);
             }*/

             await requestService.MakeRequestAsync(model, "clientcompany1");
             return RedirectToAction(nameof(MyRequests));           
        }

        [HttpGet]
        public async Task<IActionResult> MyRequests([FromQuery] FilterRequestsViewModel query)
        {
            /*var companyUsername = User.GetUsername();
            if (await clientsService.UserWithEmailExistsAsync(companyUsername) == false)
            {
                return BadRequest(ClientCompanyNotFoundErrorMessage);
            }*/
            var model = await requestService.GetRequestsForCompanyBySearchTermAsync("clientcompany1", query.SearchTerm);
            query.Requests = model;
            model = await requestService.GetRequestsForCompanyAsync("clientcompany1", query.StartDate, query.EndDate, query.PickupAddress, query.DeliveryAddress, query.IsApproved, query.MinPrice, query.MaxPrice, query.MinWeight, query.MaxWeight);
            query.Requests = model;
            
            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> RequestDetails(int id)
        {
            if (await requestService.RequestWithIdExistsAsync(id) == false)
            {
                return BadRequest(RequestNotFoundErrorMessage);
            }

            //var companyUsername = User.GetUsername();
            var username = "clientcompany1";
            /*if (await clientsService.UserWithEmailExistsAsync(username) == false)
            {
                return BadRequest(ClientCompanyNotFoundErrorMessage);
            }*/

            if (await requestService.RequestWithCompanyExistsAsync(id, username) == false)
            {
                return Unauthorized(CompanyDoesNotHaveRequestErrorMessage);
            }
            var model = await requestService.GetRequestDetailsAsync(id);
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

            //var companyUsername = User.GetUsername();
            var username = "clientcompany1";
            /*if (await clientsService.UserWithEmailExistsAsync(username) == false)
            {
                return BadRequest(ClientCompanyNotFoundErrorMessage);
            }*/
            if (await offerService.OfferWithCompanyExistsAsync(offerId, username) == false)
            {
                TempData["NotAuthorized"] = "Company does not have this offer.";
                return View(model);
            }
            return RedirectToAction(nameof(OfferDetails), new { id = offerId });
        }

        [HttpGet]
        public IActionResult HaveOffer()
        {
            return View();
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
        public async Task<IActionResult> AcceptOffer(int id)
        {
            if (await offerService.OfferWithIdExistsAsync(id) == false)
            {
                return BadRequest(OfferNotFoundErrorMessage);
            }
            var model = await offerService.GetOfferForAcceptAsync(id);
            return View(model);
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            var model = new ChangePasswordViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Home");
            }
            if (model.CurrentPassword == model.NewPassword)
            {
                ModelState.AddModelError("NewPassword", NewPasswordLikeCurrentPasswordErrorMessage);
                return View(model);
            }
            var passwordValidation = await userManager.PasswordValidators.First().ValidateAsync(userManager, user, model.NewPassword);
            if (passwordValidation.Succeeded == false)
            {
                foreach (var error in passwordValidation.Errors)
                {
                    ModelState.AddModelError("NewPassword", error.Description);
                    return View(model);
                }
            }
            var result = await userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
         
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(CompanyDetails));
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> CompanyDetails()
        {
            //var companyUsername = User.GetUsername();
            var username = "clientcompany1";
            /*if (await clientsService.UserWithEmailExistsAsync(username) == false)
            {
                return BadRequest(ClientCompanyNotFoundErrorMessage);
            }*/
            var model = await clientsService.GetCompanyDetailsAsync(username);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ContactDetails()
        {
            //var companyUsername = User.GetUsername();
            var username = "clientcompany1";
            /*if (await clientsService.UserWithEmailExistsAsync(username) == false)
            {
                return BadRequest(ClientCompanyNotFoundErrorMessage);
            }*/
            var model = await clientsService.GetCompanyContactDetailsAsync(username);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> MyOffers([FromQuery] FilterOffersViewModel query)
        {
            //var companyUsername = User.GetUsername();
            var username = "clientcompany1";
            /*if (await clientsService.UserWithEmailExistsAsync(username) == false)
            {
                return BadRequest(ClientCompanyNotFoundErrorMessage);
            }*/
            var model = await offerService.GetOffersForCompanyBySearchTermAsync(username, query.SearchTerm);
            query.Offers = model;
            model = await offerService.GetOffersForCompanyAsync(username, query.DeliveryAddress, query.PickupAddress, query.StartDate, query.EndDate, query.MinPrice, query.MaxPrice, query.IsApproved, query.MinWeight, query.MaxWeight);
            query.Offers = model;
            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> BookOffer(int id)
        {
            //var companyUsername = User.GetUsername();
            var username = "clientcompany1";
            /*if (await clientsService.UserWithEmailExistsAsync(username) == false)
            {
                return BadRequest(ClientCompanyNotFoundErrorMessage);
            }*/
            if (await offerService.OfferWithIdExistsAsync(id) == false)
            {
                return BadRequest(OfferNotFoundErrorMessage);
            }
            if(await offerService.OfferWithCompanyExistsAsync(id, username) == false)
            {
                return Unauthorized(CompanyDoesNotHaveOfferErrorMessage);
            }

            await offerService.BookOfferAsync(id, username);
            return RedirectToAction(nameof(MyOffers));
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
            //var companyUsername = User.GetUsername();
            var username = "clientcompany1";
            /*if (await clientsService.UserWithEmailExistsAsync(username) == false)
            {
                return BadRequest(ClientCompanyNotFoundErrorMessage);
            }*/

            var deliveryId = await deliveryService.GetDeliveryByReferenceNumberAsync(model.ReferenceNumber);
            if (deliveryId == default)
            {
                TempData["NotFound"] = DeliveryNotFoundErrorMessage;
                return View(model);
            }

            if(await deliveryService.DeliveryWithCompanyExistsAsync(deliveryId, username) == false)
            {
                TempData["NotAuthorized"] = CompanyDoesNotHaveDeliveryErrorMessage;
                return View(model);
            }
            return RedirectToAction(nameof(DeliveryDetails), new { id = deliveryId });
        }

        [HttpGet]
        public async Task<IActionResult> DeliveryDetails(int id)
        {
            if (await deliveryService.DeliveryWithIdExistsAsync(id) == false)
            {
                return BadRequest(DeliveryNotFoundErrorMessage);
            }

            var model = await deliveryService.GetDeliveryDetailsForCompanyAsync(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LeaveRating(int id, DeliveryForClientViewModel model)
        {
            if (await deliveryService.DeliveryWithIdExistsAsync(id) == false)
            {
                return BadRequest(DeliveryNotFoundErrorMessage);
            }
            //var companyUsername = User.GetUsername();
            var username = "clientcompany1";
            /*if (await clientsService.UserWithEmailExistsAsync(username) == false)
             *{
             *  return BadRequest(ClientCompanyNotFoundErrorMessage);
             }*/
            if (await deliveryService.DeliveryWithCompanyExistsAsync(id, username) == false)
            {
                return Unauthorized(CompanyDoesNotHaveDeliveryErrorMessage);
            }

            await deliveryService.LeaveRatingForDeliveryAsync(id, model.Comment, model.RatingStars);
            return RedirectToAction(nameof(DeliveryDetails), new { id = id });
        }

        [HttpGet]
        public async Task<IActionResult> MyDeliveries([FromQuery] ClientsDeliveriesViewModel query)
        {
            //var companyUsername = User.GetUsername();
            var username = "clientcompany1";
            /*if (await clientsService.UserWithEmailExistsAsync(username) == false)
             *{
             *  return BadRequest(ClientCompanyNotFoundErrorMessage);
             }*/
            var model = await deliveryService.GetDeliveriesForClientBySearchtermAsync(username, query.SearchTerm);
            query.Deliveries = model;
            model = await deliveryService.GetDeliveriesForClientAsync(username, query.ReferenceNumber, query.EndDate, query.StartDate, query.MinPrice, query.MaxPrice, query.IsDelivered, query.IsPaid);
            query.Deliveries = model;
            
            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> MyInvoices([FromQuery] ClientsInvoicesViewModel query)
        {
            //var companyUsername = User.GetUsername();
            var username = "clientcompany1";
            /*if (await clientsService.UserWithEmailExistsAsync(username) == false)
             *{
             *  return BadRequest(ClientCompanyNotFoundErrorMessage);
             }*/
            try
            {
                var model = await invoiceService.GetInvoicesForCompanyAsync(username, query.DeliveryReferenceNumber, query.StartDate, query.EndDate, query.MinPrice, query.MaxPrice, query.IsPaid);
                query.Invoices = model;
                
                return View(query);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> DeliveryStatistics()
        {
            //var companyUsername = User.GetUsername();
            var username = "clientcompany1";
            /*if (await clientsService.UserWithEmailExistsAsync(username) == false)
             *{
             *  return BadRequest(ClientCompanyNotFoundErrorMessage);
             }*/
            var model = await statisticsService.GetDeliveryStatisticsForCompanyAsync(username);
            return View(model);
        }

        [HttpGet]
        public async Task<JsonResult> GetDeliveryTypes()
        {
            //var companyUsername = User.GetUsername();
            var username = "clientcompany1";
            /*if (await clientsService.UserWithEmailExistsAsync(username) == false)
             *{
             *  return BadRequest(ClientCompanyNotFoundErrorMessage);
             }*/
            var model = await deliveryStatisticsService.GetDestinationTypesForCompanyAsync(username);
            return Json(new { Domestic = model.domesticDeliveries, International = model.internationalDeliveries});
        }
      
        [HttpGet]
        public async Task<JsonResult> GetDeliveryCounts()
        {
            //var companyUsername = User.GetUsername();
            var username = "clientcompany1";
            /*if (await clientsService.UserWithEmailExistsAsync(username) == false)
             *{
             *  return BadRequest(ClientCompanyNotFoundErrorMessage);
             }*/
            var model = await deliveryStatisticsService.GetDeliveriesCountForCompanyAsync(username);
            return Json(new {months = model.Item1, deliveries = model.Item2});
        }

        [HttpGet]
        public async Task<JsonResult> GetDeliveryTimes()
        {
            //var companyUsername = User.GetUsername();
            var username = "clientcompany1";
            /*if (await clientsService.UserWithEmailExistsAsync(username) == false)
             *{
             *  return BadRequest(ClientCompanyNotFoundErrorMessage);
             }*/
            var model = await deliveryStatisticsService.GetDeliveryTimesForCompanyAsync(username);
            return Json(new { successRate = model.successRate, averageDelay = model.averageDelay });
        }

        [HttpGet]
        public async Task<IActionResult> RequestStatistics()
        {
            //var companyUsername = User.GetUsername();
            var username = "clientcompany1";
            /*if (await clientsService.UserWithEmailExistsAsync(username) == false)
             *{
             *  return BadRequest(ClientCompanyNotFoundErrorMessage);
             }*/
            var model = await statisticsService.GetRequestStatisticsForCompanyAsync(username);
            return View(model);
        }

        [HttpGet]
        public async Task<JsonResult> GetRequestStatusDistribution()
        {
            //var companyUsername = User.GetUsername();
            var username = "clientcompany1";
            /*if (await clientsService.UserWithEmailExistsAsync(username) == false)
             *{
             *  return BadRequest(ClientCompanyNotFoundErrorMessage);
             }*/
            var model = await statisticsService.GetRequestStatusDistributionForCompanyAsync(username);
            return Json(new { statusCounts = model });
        }

        [HttpGet]
        public async Task<JsonResult> GetAverageResponseTime()
        {
            //var companyUsername = User.GetUsername();
            var username = "clientcompany1";
            /*if (await clientsService.UserWithEmailExistsAsync(username) == false)
             *{
             *  return BadRequest(ClientCompanyNotFoundErrorMessage);
             }*/
            var model = await statisticsService.GetAverageResponseTimeForClientRequestsAsync(username);

            return Json(new { averageResponseTime = model});
        }

        [HttpGet]
        public async Task<JsonResult> GetMonthlyRequestPatterns()
        {
            //var companyUsername = User.GetUsername();
            var username = "clientcompany1";
            /*if (await clientsService.UserWithEmailExistsAsync(username) == false)
             *{
             *  return BadRequest(ClientCompanyNotFoundErrorMessage);
             }*/
            var model = await statisticsService.GetMonthlyRequestPattersForClientRequestsAsync(username);

            return Json(new {data = model});
        }

        [HttpGet]
        public async Task<IActionResult> InvoicesStatistics()
        {
            //var companyUsername = User.GetUsername();
            var username = "clientcompany1";
            /*if (await clientsService.UserWithEmailExistsAsync(username) == false)
             *{
             *  return BadRequest(ClientCompanyNotFoundErrorMessage);
             }*/
            var model = await deliveryStatisticsService.GetInvoicesStatisticsForClientAsync(username);
            return View(model);
        }

        [HttpGet]
        public async Task<JsonResult> GetInvoicesStatusDistribution()
        {
            //var companyUsername = User.GetUsername();
            var username = "clientcompany1";
            /*if (await clientsService.UserWithEmailExistsAsync(username) == false)
             *{
             *  return BadRequest(ClientCompanyNotFoundErrorMessage);
             }*/
            var model = await deliveryStatisticsService.GetInvoicesStatusDistributionAsync(username);
            return Json(new { statusCounts = model });
        }

        [HttpGet]
        public async Task<JsonResult> GetTotalSpending()
        {
            //var companyUsername = User.GetUsername();
            var username = "clientcompany1";
            /*if (await clientsService.UserWithEmailExistsAsync(username) == false)
             *{
             *  return BadRequest(ClientCompanyNotFoundErrorMessage);
             }*/
            var totalSpent = await deliveryStatisticsService.GetTotalSpendingForCompanyAsync(username);
            return Json(new { totalSpent = totalSpent });
        }

        [HttpGet]
        public async Task<JsonResult> GetRequestPriceDifferences()
        {
            //var companyUsername = User.GetUsername();
            var username = "clientcompany1";
            /*if (await clientsService.UserWithEmailExistsAsync(username) == false)
             *{
             *  return BadRequest(ClientCompanyNotFoundErrorMessage);
             }*/
            var model = await statisticsService.GetRequestPriceDifferenceForDeliveriesAsync(username);
            var result = model.Select(item => new
            {
                offerReference = item.offerReference,
                approximatePrice = item.approximatePrice,
                finalPrice = item.finalPrice
            }).ToList();

            return Json(result);
        }
        
        [HttpGet]
        public async Task<JsonResult> GetCarbonEmission(int id)
        {
            //var companyUsername = User.GetUsername();
            var username = "clientcompany1";
            /*if (await clientsService.UserWithEmailExistsAsync(username) == false)
             *{
             *  return BadRequest(ClientCompanyNotFoundErrorMessage);
             }*/
            var model = await deliveryStatisticsService.GetCarbonEmissionsForCompanyAsync(username, id);
            return Json(new { specificDeliveryEmission = model.Item1, totalEmissions = model.Item2 });
        }

        [HttpGet]
        public async Task<IActionResult> OfferStatistics()
        {
            //var companyUsername = User.GetUsername();
            var username = "clientcompany1";
            /*if (await clientsService.UserWithEmailExistsAsync(username) == false)
             *{
             *  return BadRequest(ClientCompanyNotFoundErrorMessage);
             }*/
            var model = await statisticsService.GetOfferStatisticsForCompanyAsync(username);
            return View(model);
        }

        [HttpGet]
        public async Task<JsonResult> GetOffersAcceptanceRate()
        {
            //var companyUsername = User.GetUsername();
            var username = "clientcompany1";
            /*if (await clientsService.UserWithEmailExistsAsync(username) == false)
             *{
             *  return BadRequest(ClientCompanyNotFoundErrorMessage);
             }*/
            var model = await statisticsService.GetOffersAcceptanceRateForCompanyAsync(username);
            return Json(new { accepted = model.Item1, rejected = model.Item2 });
        }
        
        [HttpGet]
        public async Task<JsonResult> GetDifferencesInOfferPrices()
        {
            //var companyUsername = User.GetUsername();
            var username = "clientcompany1";
            /*if (await clientsService.UserWithEmailExistsAsync(username) == false)
             *{
             *  return BadRequest(ClientCompanyNotFoundErrorMessage);
             }*/
            var model = await statisticsService.GetDifferencesInOfferPricesForCompanyAsync(username);
            return Json(new { offers = model.Item1, clientPrices = model.Item2, companyPrices = model.Item3 });
        }        
        
        [HttpGet]
        public async Task<JsonResult> GetCargoRatios()
        {
            //var companyUsername = User.GetUsername();
            var username = "clientcompany1";
            /*if (await clientsService.UserWithEmailExistsAsync(username) == false)
             *{
             *  return BadRequest(ClientCompanyNotFoundErrorMessage);
             }*/
            var model = await statisticsService.GetCargoRatiosForCompanyAsync(username);
            return Json(new { standardCount = model.Item1, nonStandardCount = model.Item2});
        }

        //TODO: Add method for booking offer
    }
}

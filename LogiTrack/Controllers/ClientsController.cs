using LogiTrack.Core.Contracts;
using LogiTrack.Core.ViewModels.Clients;
using static LogiTrack.Core.Constants.MessageConstants.ErrorMessages;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using LogiTrack.Core.Services;
using LogiTrack.Extensions;
using LogiTrack.Core.CustomExceptions;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

namespace LogiTrack.Controllers
{
    public class ClientsController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IClientsService clientsService;
        private readonly GeocodingService geocodingService;

        public ClientsController(UserManager<IdentityUser> userManager, IClientsService clientsService, GeocodingService geocodingService)
        {
            this.userManager = userManager;
            this.clientsService = clientsService;
            this.geocodingService = geocodingService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var username = User.GetUsername();
            if (await clientsService.UserWithEmailExistsAsync(username) == false)
            {
                return BadRequest(ClientCompanyNotFoundErrorMessage);
            }
            var model = await clientsService.GetClientCompanyDashboardAsync(username);
            return View(model);
        }


        [HttpGet]
        public async Task<JsonResult> GetCalendarEvents()
        {
            var model = await clientsService.GetClientCompanyEventsAsync("clientcompany1");
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
            if (await clientsService.UserWithEmailExistsAsync(model.Email))
            {
                ModelState.AddModelError("Email", EmailAlreadyExistsErrorMessage);
                return View(model);
            }
            if (await clientsService.UserWithPhoneNumberExistsAsync(model.PhoneNumber))
            {
                ModelState.AddModelError("PhoneNumber", PhoneNumberAlreadyExistsErrorMessage);
                return View(model);
            }
            var user = await clientsService.RegisterUserAsync(model);
            await userManager.AddToRoleAsync(user, "ClientCompany");
            await clientsService.RegisterClientCompanyAsync(model, user);

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
            var pickupCoordinates = await geocodingService.GetCoordinates(model.PickupAddress);
            if (pickupCoordinates == null)
            {
                ModelState.AddModelError("PickupAddress", InvalidAddressErrorMessage);
                return View(model);           
            }
            var deliveryCoordinates = await geocodingService.GetCoordinates(model.DeliveryAddress);
            if (deliveryCoordinates == null)
            {
                ModelState.AddModelError("DeliveryAddress", InvalidAddressErrorMessage);
                return View(model);
            }
            model.DeliveryLatitude = deliveryCoordinates.Value.Latitude;
            model.DeliveryLongitude = deliveryCoordinates.Value.Longtitude;
            model.PickupLatitude = pickupCoordinates.Value.Latitude;
            model.PickupLongitude = pickupCoordinates.Value.Longtitude;

            var userEmail = User.GetEmail();
            try
            {
                await clientsService.MakeRequestAsync(model, userEmail);
                return RedirectToAction(nameof(MyRequests));
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ClientCompanyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        public async Task<IActionResult> MyRequests()
        {
            return View();
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
            var username = User.GetUsername();
            if (await clientsService.UserWithEmailExistsAsync(username) == false)
            {
                return BadRequest(ClientCompanyNotFoundErrorMessage);
            }
            var model = await clientsService.GetCompanyDetailsAsync(username);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ContactDetails()
        {
            var username = User.GetUsername();
            if (await clientsService.UserWithEmailExistsAsync(username) == false)
            {
                return BadRequest(ClientCompanyNotFoundErrorMessage);
            }
            var model = await clientsService.GetCompanyContactDetailsAsync(username);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> MyOffers([FromQuery] SearchOffersViewModel query)
        {
            var username = User.GetUsername();
            if (await clientsService.UserWithEmailExistsAsync(username) == false)
            {
                return BadRequest(ClientCompanyNotFoundErrorMessage);
            }
            var model = await clientsService.GetOffersForCompanyAsync(username, query.DeliveryAddress, query.PickupAddress, query.StartDate, query.EndDate);
            query.Offers = model;
            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> BookOffer(int id)
        {
            var username = User.GetUsername();
            if (await clientsService.UserWithEmailExistsAsync(username) == false)
            {
                return BadRequest(ClientCompanyNotFoundErrorMessage);
            }
            if(await clientsService.OfferWithIdExistsAsync(id) == false)
            {
                return BadRequest(OfferNotFoundErrorMessage);
            }
            if(await clientsService.OfferWithCompanyExistsAsync(id, username) == false)
            {
                return Unauthorized(CompanyDoesNotHaveOfferErrorMessage);
            }
            await clientsService.BookOfferAsync(id, username);
            return RedirectToAction(nameof(AprovedOrders));
        }

        private object AprovedOrders()
        {
            throw new NotImplementedException();
        }
    }
}

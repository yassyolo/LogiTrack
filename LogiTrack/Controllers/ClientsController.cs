using LogiTrack.Core.Contracts;
using LogiTrack.Core.ViewModels.Clients;
using static LogiTrack.Core.Constants.MessageConstants.ErrorMessages;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using LogiTrack.Core.Services;
using LogiTrack.Extensions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using LogiTrack.Core.CustomExceptions;

namespace LogiTrack.Controllers
{
    public class ClientsController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IClientsService clientsService;
        public ClientsController(UserManager<IdentityUser> userManager, IClientsService clientsService)
        {
            this.userManager = userManager;
            this.clientsService = clientsService;
        }

        public IActionResult Index()
        {
            return View();
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
            if(await clientsService.UserWithEmailExistsAsync(model.Email))
            {
                ModelState.AddModelError("Email", EmailAlreadyExistsErrorMessage);
                return View(model);
            }
            if(await clientsService.UserWithPhoneNumberExistsAsync(model.PhoneNumber))
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
    }
}

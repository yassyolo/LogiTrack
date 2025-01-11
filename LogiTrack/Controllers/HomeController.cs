using LogiTrack.Core.Contracts;
using LogiTrack.Core.ViewModels.Home;
using LogiTrack.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static LogiTrack.Core.Constants.MessageConstants.ErrorMessages;
using static LogiTrack.Core.Constants.UserRolesConstants;

namespace LogiTrack.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IHomeService homeService;
        private readonly IUserService userService;

        public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, IHomeService homeService, IUserService userService)
        {
            this.logger = logger;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.homeService = homeService;
            this.userService = userService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            var model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            var user = await homeService.GetUserByUsernameAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, InvalidEmailErrorMessage);
                return View(model);
            }

            var passwordCheck = await userManager.CheckPasswordAsync(user, model.Password);
            if (passwordCheck == false)
            {
                ModelState.AddModelError(string.Empty, InvalidLoginAttemptErrorMessage);
                return View(model);
            }
            
            var result2 = await signInManager.PasswordSignInAsync(user, model.Password, false, false);
            if (result2.Succeeded == false)
            {
                ModelState.AddModelError(string.Empty, InvalidLoginAttemptErrorMessage);
                return View(model);
            }
            if(await userManager.IsInRoleAsync(user, ClientCompany))
            {
                return RedirectToAction("Dashboard", "Clients");
            }
            else if (await userManager.IsInRoleAsync(user, Logistics))
            {
                return RedirectToAction("Dashboard", "Logistics");
            }
            else if (await userManager.IsInRoleAsync(user, Accountant))
            {
                return RedirectToAction("Dashboard", "Accountant");
            }
            else if (await userManager.IsInRoleAsync(user, Speditor))
            {
                return RedirectToAction("Dashboard", "Speditor");
            }
            else if (await userManager.IsInRoleAsync(user, Driver))
            {
                return RedirectToAction("Dashboard", "Driver");
            }

            ModelState.AddModelError(string.Empty, InvalidLoginAttemptErrorMessage);
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
        public async Task<JsonResult> GetNotificationsCount()
        {
            var username = User.GetUsername();
            var data = await userService.GetNotificationsForUserAsync(username);
            var result = data.Count();
            return Json(result);
        }
        [HttpGet]
        public async Task<IActionResult> Notifications()
        {
            var username = User.GetUsername();
            if (await userService.UserWithUsernameExistsAsync(username) == false)
            {
                return BadRequest("Not found");
            }
            var model = await userService.GetNotificationsForUserAsync(username);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> MarkAsRead(int id)
        {
            var username = User.GetUsername();
            if (await userService.UserWithUsernameExistsAsync(username) == false)
            {
                return BadRequest("Not found");
            }
            if (await userService.NotificationWithIdExistsForUserAsync(id, username) == false)
            {
                return Unauthorized();
            }
            if(await homeService.NotificationWithIdExistsdAsync(id) == false)
            {
                return BadRequest();
            }
            await homeService.MarkNotificationAsReadAsync(id);
            return RedirectToAction(nameof(Notifications));
        }
    }
}

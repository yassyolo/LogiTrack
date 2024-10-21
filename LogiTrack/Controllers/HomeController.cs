using LogiTrack.Core.Contracts;
using LogiTrack.Core.ViewModels.Home;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static LogiTrack.Core.Constants.MessageConstants.ErrorMessages;

namespace LogiTrack.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IHomeService homeService;

        public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, IHomeService homeService)
        {
            this.logger = logger;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.homeService = homeService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            var model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            var user = await homeService.GetUserByEmailAsync(model.Email);
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
            var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);
            if (result.Succeeded == false)
            {
                ModelState.AddModelError(string.Empty, InvalidLoginAttemptErrorMessage);
                return View(model);
            }
            if(await userManager.IsInRoleAsync(user, "ClientCompany"))
            {
                return RedirectToAction("Index", "ClientCompany");
            }
            else if (await userManager.IsInRoleAsync(user, "LogisticsCompany"))
            {
                return RedirectToAction("Index", "LogisticsCompany");
            }
            else if (await userManager.IsInRoleAsync(user, "Accountant"))
            {
                return RedirectToAction("Index", "Accountant");
            }
            else if (await userManager.IsInRoleAsync(user, "Speditor"))
            {
                return RedirectToAction("Index", "Speditor");
            }

            ModelState.AddModelError(string.Empty, InvalidLoginAttemptErrorMessage);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}

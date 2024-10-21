using LogiTrack.Core.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static LogiTrack.Core.Constants.MessageConstants.ErrorMessages;
using static LogiTrack.Core.Helpers.RandomPasswordGenerator;

namespace LogiTrack.Controllers
{
    public class LogisticsController : Controller
    {
        private readonly IClientsService clientsService;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IEmailSenderService emailSenderService;

        public LogisticsController(IClientsService clientsService, UserManager<IdentityUser> userManager, IEmailSenderService emailSenderService)
        {
            this.clientsService = clientsService;
            this.userManager = userManager;
            this.emailSenderService = emailSenderService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetPendingRegistrations()
        {
            var model = await clientsService.GetPendingRegistrationsAsync();
            return View(model);
        }

        [HttpPut]
        public async Task<IActionResult> ApprovePendingRegistration(int id)
        {
            if (await clientsService.CompanyWithIdExistsAsync(id) == false)
            {
                return BadRequest(ClientCompanyNotFoundErrorMessage);
            }
            var user = await clientsService.ApprovePendingRegistrationForCompanyWithIdAsync(id);
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

        [HttpPut]
        public async Task<IActionResult> RejectPendingRegistration(int id)
        {
            await clientsService.RejectPendingRegistrationForCompanyWithIdAsync(id);
            return RedirectToAction(nameof(GetPendingRegistrations));
        }
    }
}

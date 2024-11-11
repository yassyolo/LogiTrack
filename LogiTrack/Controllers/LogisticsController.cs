using LogiTrack.Core.Contracts;
using LogiTrack.Core.ViewModels.Clients;
using LogiTrack.Core.ViewModels.Driver;
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
        private readonly UserManager<IdentityUser> userManager;
        private readonly IEmailSenderService emailSenderService;
        private readonly IDriverService driverService;

        public LogisticsController(IClientsService clientsService, UserManager<IdentityUser> userManager, IEmailSenderService emailSenderService, IDriverService driverService)
        {
            this.clientsService = clientsService;
            this.userManager = userManager;
            this.emailSenderService = emailSenderService;
            this.driverService = driverService;
        }

        [HttpGet]
        public async Task<IActionResult> Dashboard()
        {
            //var username = User.GetUsername();
            var username = "logistics";
            if (await clientsService.LogisticsUserWithUsernameExistsAsync(username) == false)
            {
                return BadRequest("Not found");
            }
            var model = await clientsService.GetLogisticsCompanyDashboardAsync();
            return View(model);
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

        [HttpGet]
        public async Task<IActionResult> ClientsRegister([FromQuery] SearchClientsViewModel query)
        {
            var model = await clientsService.GetClientsForClientsRegisterAsync(query.Active, query.Name, query.Email, query.RegistrationNumber);
            query.Clients = model;
            model = await clientsService.GetClientsForClientsRegisterBySearchTermAsync(query.SearchTerm);
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
        public async Task<IActionResult> VehiclesRegister([FromQuery] SearchVehicleForLogisticsViewModel query)
        {
            var model = await clientsService.GetVehiclesAsync(query.Refrigerated, query.RegistrationNumber, query.VehicleType, query.MinWeightCapacity, query.MaxWeightCapacity, query.MinVolume, query.MaxVolume);
            query.Vehicles = model;
            model = await clientsService.GetVehiclesBySearchTermAsync(query.SearchTerm);
            query.Vehicles = model;
            return View(query);
        }
        [HttpGet]
        public async Task<IActionResult> VehicleDetails(int id)
        {
            if (await clientsService.VehicleWithIdExistsAsync(id) == false)
            {
                return NotFound("Vehicle not found");
            }
            var model = await clientsService.GetVehicleDetailsAsync(id);
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> DriversRegister([FromQuery] SearchDriverViewModel query)
        {
            var model = await driverService.GetDriversAsync(query.Name, query.LicenseNumber, query.IsAvailable, query.Salary);
            query.Drivers = model;
            model = await driverService.GetDriversBySearchtermAsync(query.SearchTerm);
            query.Drivers = model;
            return View(query);
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
    }
}

using LogiTrack.Core.Contracts;
using LogiTrack.Core.CustomExceptions;
using static LogiTrack.Core.Constants.MessageConstants.ErrorMessages;
using Microsoft.AspNetCore.Mvc;
using LogiTrack.Core.ViewModels.Invoice;
using LogiTrack.Core.ViewModels.CashRegister;
using LogiTrack.Core.ViewModels.Delivery;

namespace LogiTrack.Controllers
{
    public class AccountantController : Controller
    {
        private readonly IAccountantService accountantService;
        private readonly IVehicleService vehicleService;
        private readonly IDeliveryService deliveryService;
        private readonly ICashRegisterService cashRegisterService;
        private readonly IInvoiceService invoiceService;

        public AccountantController(IAccountantService accountantService, IVehicleService vehicleService, IDeliveryService deliveryService, ICashRegisterService cashRegisterService, IInvoiceService invoiceService)
        {
            this.accountantService = accountantService;
            this.vehicleService = vehicleService;
            this.deliveryService = deliveryService;
            this.cashRegisterService = cashRegisterService;
            this.invoiceService = invoiceService;
        }

        [HttpGet]
        public async Task<IActionResult> Dashboard()
        {
            var model = await accountantService.GetAccountantDashboardAsync();
            return View(model);
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
            var deliveryId = await deliveryService.GetDeliveryByReferenceNumberForAccountantAsync(model.ReferenceNumber);
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
            var model = await deliveryService.GetDeliveryDetailsForAccountantAsync(id);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddCashRegister(int id)
        {
            if (await deliveryService.DeliveryWithIdExistsAsync(id) == false)
            {
                return NotFound(DeliveryNotFoundErrorMessage);
            }
            var model = new AddCashRegisterViewModel()
            {
                DeliveryId = id
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCashRegister(int id, AddCashRegisterViewModel model, IFormFile file)
        {
 
            if (ModelState.IsValid == false)
            {
                return View(model);
            }
            try
            {
                await cashRegisterService.AddCashRegisterForDeliveryAsync(id, model, file);
                return RedirectToAction(nameof(DeliveryDetails), new { id = id });
            }
            catch (DeliveryNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> SearchCashRegisters([FromQuery] SearchCashRegistersViewModel query)
        {
            try
            {
                var model = await cashRegisterService.GetCashRegistersForDeliveryAsync(query.DeliveryReferenceNumber, query.StartDate, query.EndDate, query.Type);
                query.CashRegisters = model;
                return View(query);
            }
            catch (DeliveryNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> SearchInvoices([FromQuery] SearchInvoicesViewModel query)
        {
            try
            {
                var model = await invoiceService.GetInvoicesAsync(query.DeliveryReferenceNumber, query.StartDate, query.EndDate, query.CompanyName, query.IsPaid);
                query.Invoices = model;
                return View(query);
            }
            catch (DeliveryNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> SearchDeliveries([FromQuery] SearchDeliveryForAccountantViewModel query)
        {
            var model = await deliveryService.GetDeliveryForAccountantAsync(query.ReferenceNumber, query.EndDate, query.StartDate, query.ClientCompanyName, query.IsPaid);
            query.Deliveries = model;
            model = await deliveryService.GetDeliveriesForAccountantBySearchtermAsync(query.SearchTerm);
            query.Deliveries = model;
            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> MarkAsPaid(int id)
        {
            if (await deliveryService.DeliveryWithIdExistsAsync(id) == false)
            {
                return NotFound(DeliveryNotFoundErrorMessage);
            }
            var model = await invoiceService.GetInvoiceForPaymentAsync(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> MarkAsPaidSuccessful(int id)
        {
            if(await invoiceService.InvoiceWithIdExistsAsync(id) == false)
            {
                return NotFound(InvoiceNotFoundErrorMessage);
            }
            var deliveryId = await invoiceService.MarkInvoiceAsPaidAsync(id);
            return RedirectToAction(nameof(DeliveryDetails), new { id = deliveryId });
        }
    }
}

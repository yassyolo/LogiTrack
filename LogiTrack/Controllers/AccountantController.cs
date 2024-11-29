using LogiTrack.Core.Contracts;
using static LogiTrack.Core.Constants.MessageConstants.ErrorMessages;
using Microsoft.AspNetCore.Mvc;
using LogiTrack.Core.ViewModels.Invoice;
using LogiTrack.Core.ViewModels.CashRegister;
using LogiTrack.Core.ViewModels.Delivery;

namespace LogiTrack.Controllers
{
    public class AccountantController : Controller
    {
        private readonly IVehicleService vehicleService;
        private readonly IDeliveryService deliveryService;
        private readonly ICashRegisterService cashRegisterService;
        private readonly IInvoiceService invoiceService;
        private readonly IStatisticsService statisticsService;
        private readonly IDashboardService dashboardService;
        private readonly IDeliveryStatisticsService deliveryStatisticsService;

        public AccountantController(IVehicleService vehicleService, IDeliveryService deliveryService, ICashRegisterService cashRegisterService, IInvoiceService invoiceService, IStatisticsService statisticsService, IDashboardService dashboardService, IDeliveryStatisticsService deliveryStatisticsService)
        {
            this.vehicleService = vehicleService;
            this.deliveryService = deliveryService;
            this.cashRegisterService = cashRegisterService;
            this.invoiceService = invoiceService;
            this.statisticsService = statisticsService;
            this.dashboardService = dashboardService;
            this.deliveryStatisticsService = deliveryStatisticsService;
        }

        [HttpGet]
        public async Task<IActionResult> Dashboard()
        {
            var model = await dashboardService.GetAccountantDashboardAsync();
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
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
        public async Task<IActionResult> SearchInvoices([FromQuery] FilterInvoicesViewModel query)
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
        public async Task<IActionResult> SearchDeliveries([FromQuery] FilterDeliveriesForAccountantViewModel query)
        {
            var model = await deliveryService.GetDeliveriesForAccountantBySearchtermAsync(query.SearchTerm);
            query.Deliveries = model;
            model = await deliveryService.GetDeliveriesForAccountantAsync(query.ReferenceNumber, query.EndDate, query.StartDate, query.ClientCompanyName, query.IsPaid);
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

        [HttpGet]
        public async Task<IActionResult> CashRegistersStatistics()
        {
            var model = await deliveryStatisticsService.GetCashRegisterStatisticsAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<JsonResult> GetCashRegisterTypesDistribution()
        {
            var data = await deliveryStatisticsService.GetCashRegisterTypesDistributionAsync();
            return Json(data);
        }

        [HttpGet]
        public async Task<JsonResult> AdditionalCostsForCashRegisters()
        {
            var model = await deliveryStatisticsService.GetCashRegistersAmountAsync();
            return Json(new { maxAdditionalCost = model.Item1, averageAdditionalCost = model.Item2 });
        }        

        [HttpGet]
        public async Task<JsonResult> GetTotalAdditionalCostsByDeliveryType()
        {
            var data = await deliveryStatisticsService.GetGetTotalAdditionalCostsByDeliveryTypeAsync();
            return Json(data);
        }

        [HttpGet]
        public async Task<IActionResult> InvoicesStatistics()
        {
            var model = await deliveryStatisticsService.GetInvoicesStatisticsAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<JsonResult> GetInvoicesByStatus()
        {
            var data = await deliveryStatisticsService.GetInvoicesByStatusAsync();
            return Json(data);
        }
        
        [HttpGet]
        public async Task<JsonResult> GetTop10ClientsByOverdueAmount()
        {
            var data = await deliveryStatisticsService.GetTop10ClientsByOverdueAmountAsync();
            return Json(data);
        }
        
        [HttpGet]
        public async Task<JsonResult> GetLatePaymentsByClient()
        {
            var data = await deliveryStatisticsService.GetLatePaymentsByClientAsync();
            return Json(data);
        }

    }
}

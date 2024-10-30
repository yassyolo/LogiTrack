﻿using LogiTrack.Core.Contracts;
using LogiTrack.Core.CustomExceptions;
using LogiTrack.Core.ViewModels.Accountant;
using static LogiTrack.Core.Constants.MessageConstants.ErrorMessages;
using Microsoft.AspNetCore.Mvc;
using LogiTrack.Core.Constants;

namespace LogiTrack.Controllers
{
    public class AccountantController : Controller
    {
        private readonly IAccountantService accountantService;
        private readonly IVehicleService vehicleService;
        private readonly IDeliveryService deliveryService;

        public AccountantController(IAccountantService accountantService, IVehicleService vehicleService, IDeliveryService deliveryService)
        {
            this.accountantService = accountantService;
            this.vehicleService = vehicleService;
            this.deliveryService = deliveryService;
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
            var deliveryId = await deliveryService.GetDeliveryByReferenceNumberAsync(model.ReferenceNumber);
            if (deliveryId == null)
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
                await deliveryService.AddCashRegisterForDeliveryAsync(id, model, file);
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
                var model = await deliveryService.GetCashRegistersForDeliveryAsync(query.DeliveryReferenceNumber, query.StartDate, query.EndDate, query.Type);
                query.CashRegisters = model;
                return View(query);
            }
            catch (DeliveryNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> SearchDeliveries([FromQuery] SearchDeliveryViewModel query)
        {
            var model = await deliveryService.GetDeliveryForAccountantAsync(query.ReferenceNumber, query.EndDate, query.StartDate, query.ClientCompanyName, query.IsPaid);
            query.Delivery = model;
            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> MarkAsPaid(int id)
        {
            if (await deliveryService.DeliveryWithIdExistsAsync(id) == false)
            {
                return NotFound(DeliveryNotFoundErrorMessage);
            }
            var model = await accountantService.GetInvoiceForPaymentAsync(id);
            return View(model);
        }
        public async Task<IActionResult> MarkAsPaidSuccessful(int id)
        {
            if(await accountantService.InvoiceWithIdExistsAsync(id) == false)
            {
                return NotFound(InvoiceNotFoundErrorMessage);
            }
            var deliveryId = await accountantService.MarkInvoiceAsPaidAsync(id);
            return RedirectToAction(nameof(DeliveryDetails), new { id = deliveryId });
        }
    }
}

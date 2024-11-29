using LogiTrack.Core.Contracts;
using LogiTrack.Core.CustomExceptions;
using LogiTrack.Core.ViewModels.CashRegister;
using LogiTrack.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace LogiTrack.Core.Services
{
    public class CashRegisterService : ICashRegisterService
    {
        private readonly IRepository repository;
        private readonly IGoogleDriveService googleDriveService;

        public CashRegisterService(IRepository repository, IGoogleDriveService googleDriveService)
        {
            this.repository = repository;
            this.googleDriveService = googleDriveService;
        }

        public async Task AddCashRegisterForDeliveryAsync(int deliveryId, AddCashRegisterViewModel model, Microsoft.AspNetCore.Http.IFormFile file)
        {
            var delivery = await repository.All<Infrastructure.Data.DataModels.Delivery>().FirstOrDefaultAsync(x => x.Id == deliveryId);
            if (delivery == null)
            {
                throw new DeliveryNotFoundException();
            }
            string fileId = null;
            if (file != null && file.Length != 0)
            {
                var mimeType = file.ContentType;
                var tempFilePath = Path.GetTempFileName();
                using (var stream = new FileStream(tempFilePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                fileId = await googleDriveService.UploadFileAsync(tempFilePath, mimeType, "1hwrv9sZTBKLc6eN7AEr73WodN3lnBGhp");
            }
            var cashRegister = new Infrastructure.Data.DataModels.CashRegister
            {
                DeliveryId = deliveryId,
                Amount = model.Amount,
                Description = model.Description,
                DateSubmitted = DateTime.Now,
                FileId = fileId
            };
            if (!string.IsNullOrEmpty(model.Type))
            {
                cashRegister.Type = model.Type;
            }
            else
            {
                cashRegister.Type = model.CustomType;
            }
            await repository.AddAsync(cashRegister);
            delivery.TotalExpenses += model.Amount;
            delivery.Profit -= model.Amount;
            await repository.SaveChangesAsync();
        }

        public async Task<List<CashRegisterIndexViewModel>> GetCashRegistersAsync(string? referenceNumber = null, DateTime? startDate = null, DateTime? endDate = null, string? type = null, decimal? minPrice = null, decimal? maxPrice = null)
        {
            var cashRegisters = await repository.AllReadonly<Infrastructure.Data.DataModels.CashRegister>()
                .Include(x => x.Delivery).ToListAsync();
            if (startDate != null)
            {
                cashRegisters = cashRegisters.Where(x => x.DateSubmitted >= startDate).ToList();
            }
            if (endDate != null)
            {
                cashRegisters = cashRegisters.Where(x => x.DateSubmitted <= endDate).ToList();
            }
            if (string.IsNullOrEmpty(referenceNumber) == false)
            {
                cashRegisters = cashRegisters.Where(x => x.Delivery.ReferenceNumber == referenceNumber).ToList();
            }
            if (string.IsNullOrEmpty(type) == false)
            {
                cashRegisters = cashRegisters.Where(x => x.Type == type).ToList();
            }
            if (minPrice != null)
            {
                cashRegisters = cashRegisters.Where(x => x.Amount >= minPrice).ToList();
            }
            if (maxPrice != null)
            {
                cashRegisters = cashRegisters.Where(x => x.Amount <= maxPrice).ToList();
            }
            var carshregistersToShow =  cashRegisters.Select(x => new CashRegisterIndexViewModel
            {
                Id = x.Id,
                Type = x.Type,
                DeliveryId = x.DeliveryId,
                Amount = x.Amount.ToString(),
                Description = x.Description,
                DateSubmitted = x.DateSubmitted.ToString("dd-MM-yyyy"),
                DeliveryReferenceNumber = x.Delivery.ReferenceNumber,
                FileId = x.FileId
            }).ToList();

            foreach (var register in carshregistersToShow)
            {
                register.FileUrl = await googleDriveService.GetFileUrlAsync(register.FileId);
            }
            return carshregistersToShow;
        }      
    }
}

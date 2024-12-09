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
                FileId = fileId,
                Type = string.IsNullOrEmpty(model.Type) ? model.CustomType : model.Type
            };           
            await repository.AddAsync(cashRegister);

            delivery.TotalExpenses += model.Amount;
            delivery.Profit -= model.Amount;

            await repository.SaveChangesAsync();
        }

        public async Task<List<CashRegisterIndexViewModel>> GetCashRegistersAsync(string? referenceNumber = null, DateTime? startDate = null, DateTime? endDate = null, string? type = null, decimal? minPrice = null, decimal? maxPrice = null)
        {
            var query = repository.AllReadonly<Infrastructure.Data.DataModels.CashRegister>().Include(x => x.Delivery).AsQueryable();
            if (startDate != null)
            {
                query = query.Where(x => x.DateSubmitted >= startDate);
            }
            if (endDate != null)
            {
                query = query.Where(x => x.DateSubmitted <= endDate);
            }
            if (string.IsNullOrEmpty(referenceNumber) == false)
            {
                query = query.Where(x => x.Delivery.ReferenceNumber == referenceNumber);
            }
            if (string.IsNullOrEmpty(type) == false)
            {
                query = query.Where(x => x.Type == type);
            }
            if (minPrice != null)
            {
                query = query.Where(x => x.Amount >= minPrice);
            }
            if (maxPrice != null)
            {
                query = query.Where(x => x.Amount <= maxPrice);
            }

            var cashRegisters = await query.ToListAsync();

            var fileIds = cashRegisters.Select(x => x.FileId).Distinct().ToList();

            var fileUrlTask = fileIds.Select(x => googleDriveService.GetFileUrlAsync(x)).ToArray();
            var fileUrls = await Task.WhenAll(fileUrlTask);
            var carshregistersToShow =  cashRegisters.Select((x, index) => new CashRegisterIndexViewModel
            {
                Id = x.Id,
                Type = x.Type,
                DeliveryId = x.DeliveryId,
                Amount = x.Amount.ToString(),
                Description = x.Description,
                DateSubmitted = x.DateSubmitted.ToString("dd-MM-yyyy"),
                DeliveryReferenceNumber = x.Delivery.ReferenceNumber,
                FileId = x.FileId,
                FileUrl = fileUrls.ElementAtOrDefault(index)
            }).ToList();

            return carshregistersToShow;
        }      
    }
}

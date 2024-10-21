using LogiTrack.Core.Contracts;
using LogiTrack.Core.CustomExceptions;
using LogiTrack.Core.ViewModels.Accountant;
using LogiTrack.Infrastructure.Data.DataModels;
using LogiTrack.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace LogiTrack.Core.Services
{
    public class DeliveryService : IDeliveryService
    {
        private readonly IRepository repository;
        private readonly IGoogleDriveService googleDriveService;

        public DeliveryService(IRepository repository, IGoogleDriveService googleDriveService)
        {
            this.repository = repository;
            this.googleDriveService = googleDriveService;
        }

       

        public async Task AddCashRegisterForDeliveryAsync(int id, AddCashRegisterViewModel model, Microsoft.AspNetCore.Http.IFormFile file)
        {
            var delivery = await repository.All<Delivery>().FirstOrDefaultAsync(x => x.Id == id);
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
            var cashRegister = new CashRegister
            {
                DeliveryId = id,
                Type = model.Type,
                Amount = model.Amount,
                Description = model.Description,
                DateSubmitted = DateTime.UtcNow,
                FileId = fileId
            };
            await repository.AddAsync(cashRegister);
            await repository.SaveChangesAsync();
        }

        public async Task<bool> DeliveryWithIdExistsAsync(int deliveryId)
        {
            return await repository.AllReadonly<Delivery>().AnyAsync(x => x.Id == deliveryId);
        }

        public async Task<DeliveryIndexViewModel> GetDeliveryByReferenceNumberAsync(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return null;
            }
            var delivery = await repository.AllReadonly<Delivery>().Where(x => x.ReferenceNumber == searchTerm)
                .Include(x => x.Vehicle)
                .Include(x => x.Driver)
                .Include(x => x.Offer)
                .FirstOrDefaultAsync(x => x.ReferenceNumber == searchTerm); 
            if (delivery == null)
            {
                throw new DeliveryNotFoundException();
            }
            var model = new DeliveryIndexViewModel
            {
                Id = delivery.Id,
                VehicleId = delivery.VehicleId,
                DriverId = delivery.DriverId,
                ReferenceNumber = delivery.ReferenceNumber,
                TotalExpenses = delivery.TotalExpenses.ToString(),
                Profit = delivery.Profit.ToString(),               
            };
            var cashRegisters = await repository.AllReadonly<CashRegister>().Where(x => x.DeliveryId == delivery.Id)
                .Select(x => new CashRegisterIndexViewModel()
                {
                    Id = x.Id,
                    Type = x.Type,
                    Amount = x.Amount.ToString(),
                    Description = x.Description,
                    DateSubmitted = x.DateSubmitted.ToString("dd/MM/yyyy")

                })
                .ToListAsync();
            model.CashRegisters = cashRegisters;
            return model;
        }

    }
}

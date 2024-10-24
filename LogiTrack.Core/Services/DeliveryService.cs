using LogiTrack.Core.Constants;
using LogiTrack.Core.Contracts;
using LogiTrack.Core.CustomExceptions;
using LogiTrack.Core.ViewModels.Accountant;
using LogiTrack.Core.ViewModels.Delivery;
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

        public async Task AddStatusForDeliveryAsync(int id, AddStatusViewModel model, string username)
        {
            var driver = await repository.All<Driver>().FirstOrDefaultAsync(x => x.User.UserName == username);
            var delivery = await repository.All<Delivery>().FirstOrDefaultAsync(x => x.Id == id && x.DriverId == driver.Id);
            var deliveryTracking = new DeliveryTracking
            {
                DeliveryId = id,
                DriverId = driver.Id,
                Notes = model.Notes,
                Timestamp = DateTime.UtcNow,
                StatusUpdate = model.StatusUpdate,
                Latitude = model.Latitude,
                Longitude = model.Longitude
            };
            switch (model.StatusUpdate)
            {
                    case DeliveryStepConstants.Booked:
                      delivery.DeliveryStep = 1;
                    break;
                    case DeliveryStepConstants.Collected:
                      delivery.DeliveryStep = 2;
                    break;
                    case DeliveryStepConstants.InTransit:
                      delivery.DeliveryStep = 3;
                    break;
                    case DeliveryStepConstants.Delivered:
                      delivery.DeliveryStep = 4;
                    break;
            }
            await repository.AddAsync(deliveryTracking);
            await repository.SaveChangesAsync();
        }

        public async Task<bool> DeliveryWithIdExistsAsync(int deliveryId)
        {
            return await repository.AllReadonly<Delivery>().AnyAsync(x => x.Id == deliveryId);
        }

        public async Task<bool> DriverHasDeliveryAsync(string username, int id)
        {
            return await repository.AllReadonly<Delivery>().AnyAsync(x => x.Driver.User.UserName == username && x.Id == id);
        }

        public async Task<bool> DriverWithUsernameExistsAsync(string username)
        {
            return await repository.AllReadonly<Driver>().AnyAsync(x => x.User.UserName == username);
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

        public async Task<DeliveryViewModel> GetDeliveryForDriverByReferenceNumberAsync(string searchTerm)
        {
            return await repository.AllReadonly<Delivery>().Where(x => x.ReferenceNumber == searchTerm)
                .Include(x => x.Vehicle)
                .Include(x => x.Driver)
                .Include(x => x.Offer)
                .Select(x => new DeliveryViewModel
                {
                    Id = x.Id,
                    RequestId = x.Offer.RequestId,
                    ClientCompanyId = x.Offer.Request.ClientCompanyId,
                    ClientCompanyName = x.Offer.Request.ClientCompany.Name,
                    CargoType = x.Offer.Request.CargoType,
                    TypeOfPallet = x.Offer.Request.TypeOfPallet,
                    NumberOfPallets = x.Offer.Request.NumberOfPallets,
                    PalletLength = x.Offer.Request.PalletLength.ToString(),
                    PalletWidth = x.Offer.Request.PalletWidth.ToString(),
                    PalletHeight = x.Offer.Request.PalletHeight.ToString(),
                    PalletVolume = x.Offer.Request.PalletVolume.ToString(),
                    WeightOfPallets = x.Offer.Request.WeightOfPallets.ToString(),
                    PalletsAreStackable = x.Offer.Request.PalletsAreStackable,
                    NumberOfNonStandartGoods = x.Offer.Request.NumberOfNonStandartGoods,
                    Length = x.Offer.Request.Length.ToString(),
                    Width = x.Offer.Request.Width.ToString(),
                    Height = x.Offer.Request.Height.ToString(),
                    Volume = x.Offer.Request.Volume.ToString(),
                    Weight = x.Offer.Request.Weight.ToString(),
                    TypeOfGoods = x.Offer.Request.TypeOfGoods,
                    PickupAddress = x.Offer.Request.PickupAddress,
                    DeliveryAddress = x.Offer.Request.DeliveryAddress,
                    SharedTruck = x.Offer.Request.SharedTruck,
                    ExpectedDeliveryDate= x.Offer.Request.ExpectedDeliveryDate.ToString("dd/MM/yyyy"),
                    SpecialInstructions = x.Offer.Request.SpecialInstructions,
                    IsRefrigerated = x.Offer.Request.IsRefrigerated,
                    ReferenceNumber = x.ReferenceNumber
                })
                .FirstOrDefaultAsync();
        }
    }
}

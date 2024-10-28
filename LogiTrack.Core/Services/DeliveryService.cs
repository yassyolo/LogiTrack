using LogisticsSystem.Infrastructure.Data.DataModels;
using LogiTrack.Core.Constants;
using LogiTrack.Core.Contracts;
using LogiTrack.Core.CustomExceptions;
using LogiTrack.Core.ViewModels;
using LogiTrack.Core.ViewModels.Accountant;
using LogiTrack.Core.ViewModels.Delivery;
using LogiTrack.Core.ViewModels.Driver;
using LogiTrack.Infrastructure.Data.DataModels;
using LogiTrack.Infrastructure.Repository;
using MailKit.Search;
using Microsoft.EntityFrameworkCore;
using static LogiTrack.Infrastructure.Data.DataConstants.DataModelConstants;

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
            var delivery = await repository.All<Infrastructure.Data.DataModels.Delivery>().FirstOrDefaultAsync(x => x.Id == id);
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
            var driver = await repository.All<Infrastructure.Data.DataModels.Driver>().FirstOrDefaultAsync(x => x.User.UserName == username);
            var delivery = await repository.All<Infrastructure.Data.DataModels.Delivery>().FirstOrDefaultAsync(x => x.Id == id && x.DriverId == driver.Id);
            var deliveryTracking = new Infrastructure.Data.DataModels.DeliveryTracking
            {
                DeliveryId = id,
                DriverId = driver.Id,
                Notes = model.Notes,
                Timestamp = DateTime.UtcNow,
                StatusUpdate = model.StatusUpdate,
                Latitude = (double)model.Latitude,
                Longitude = (double)model.Longitude
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
            return await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>().AnyAsync(x => x.Id == deliveryId);
        }

        public async Task<bool> DriverHasDeliveryAsync(string username, int id)
        {
            return await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>()
                    .Include(x => x.Driver)
                    .ThenInclude(x => x.User) 
                    .AnyAsync(x => x.Driver.User.UserName == username && x.Id == id);
        }

        public async Task<bool> DriverWithUsernameExistsAsync(string username)
        {
            return await repository.AllReadonly<Infrastructure.Data.DataModels.Driver>().AnyAsync(x => x.User.UserName == username);
        }

        public async Task<List<CashRegisterIndexViewModel>> GetCashRegistersForDeliveryAsync(int id, DateTime? startDate, DateTime? endDate, string type)
        {
            var cashRegisters = await repository.AllReadonly<Infrastructure.Data.DataModels.CashRegister>().Where(x => x.DeliveryId == id).ToListAsync();
            if (startDate != null)
            {
                cashRegisters = cashRegisters.Where(x => x.DateSubmitted >= startDate).ToList();
            }
            if (endDate != null)
            {
                cashRegisters = cashRegisters.Where(x => x.DateSubmitted <= endDate).ToList();
            }
            if (string.IsNullOrEmpty(type) == false)
            {
                cashRegisters = cashRegisters.Where(x => x.Type == type).ToList();
            }
            return cashRegisters.Select(x => new CashRegisterIndexViewModel
            {
                Id = x.Id,
                Type = x.Type,
                Amount = x.Amount.ToString(),
                Description = x.Description,
                DateSubmitted = x.DateSubmitted.ToString("dd/MM/yyyy")
            }).ToList();
        }

        public async Task<int> GetDeliveryByReferenceNumberAsync(string referenceNumber)
        {
            var deliveryId = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>().Where(x => x.ReferenceNumber == referenceNumber).Select(x => x.Id).FirstOrDefaultAsync();
            return deliveryId == null ? 0 : deliveryId;
        }

        public async Task<DeliveryForAccountantViewModel> GetDeliveryDetailsForAccountantAsync(int id)
        {
            var delivery = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>().Where(x => x.Id == id)
                .Include(x => x.Vehicle)
                .Include(x => x.Driver)
                .Include(x => x.Offer)
                .ThenInclude(x => x.Request)
                .ThenInclude(x => x.ClientCompany)
                .FirstOrDefaultAsync(); 
            if (delivery == null)
            {
                throw new DeliveryNotFoundException();
            }
            var model = new DeliveryForAccountantViewModel
            {
                Id = delivery.Id,
                ClientCompanyName = delivery.Offer.Request.ClientCompany.Name,
                CargoType = delivery.Offer.Request.CargoType,
                TypeOfPallet = delivery.Offer.Request.TypeOfPallet,
                NumberOfPallets = delivery.Offer.Request.NumberOfPallets,
                PalletLength = delivery.Offer.Request.PalletLength.ToString(),
                PalletWidth = delivery.Offer.Request.PalletWidth.ToString(),
                PalletHeight = delivery.Offer.Request.PalletHeight.ToString(),
                PalletVolume = delivery.Offer.Request.PalletVolume.ToString(),
                WeightOfPallets = delivery.Offer.Request.WeightOfPallets.ToString(),
                PalletsAreStackable = delivery.Offer.Request.PalletsAreStackable,
                NumberOfNonStandartGoods = delivery.Offer.Request.NumberOfNonStandartGoods,
                Length = delivery.Offer.Request.Length.ToString(),
                Width = delivery.Offer.Request.Width.ToString(),
                Height = delivery.Offer.Request.Height.ToString(),
                Volume = delivery.Offer.Request.Volume.ToString(),
                Weight = delivery.Offer.Request.Weight.ToString(),
                TypeOfGoods = delivery.Offer.Request.TypeOfGoods,
                PickupAddress = delivery.Offer.Request.PickupAddress,
                DeliveryAddress = delivery.Offer.Request.DeliveryAddress,
                SharedTruck = delivery.Offer.Request.SharedTruck,
                IsRefrigerated = delivery.Offer.Request.IsRefrigerated,
                VehicleRegistrationNumber = delivery.Vehicle.RegistrationNumber.ToString(),
                TotalExpenses = delivery.TotalExpenses.ToString(),
                Profit = delivery.Profit.ToString(),
                ReferenceNumber = delivery.ReferenceNumber,
                DriverName = delivery.Driver.Name,
            };

            var cashRegisters = await repository.AllReadonly<Infrastructure.Data.DataModels.CashRegister>().Where(x => x.DeliveryId == delivery.Id)
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

        public async Task<DeliveryForDriverViewModel?> GetDeliveryDetailsForDriverAsync(int id)
        {
            var delivery = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>().Where(x => x.Id == id)
                .Include(x => x.Vehicle)
                .Include(x => x.Driver)
                .Include(x => x.Offer)
                .ThenInclude(x => x.Request)
                .ThenInclude(x => x.ClientCompany)
                .FirstOrDefaultAsync();
            return new DeliveryForDriverViewModel
            {
                Id = delivery.Id,
                ClientCompanyName = delivery.Offer.Request.ClientCompany.Name,
                CargoType = delivery.Offer.Request.CargoType,
                TypeOfPallet = delivery.Offer.Request.TypeOfPallet,
                NumberOfPallets = delivery.Offer.Request.NumberOfPallets.ToString(),
                PalletLength = delivery.Offer.Request.PalletLength.ToString(),
                PalletWidth = delivery.Offer.Request.PalletWidth.ToString(),
                PalletHeight = delivery.Offer.Request.PalletHeight.ToString(),
                PalletVolume = delivery.Offer.Request.PalletVolume.ToString(),
                WeightOfPallets = delivery.Offer.Request.WeightOfPallets.ToString(),
                PalletsAreStackable = delivery.Offer.Request.PalletsAreStackable,
                NumberOfNonStandartGoods = delivery.Offer.Request.NumberOfNonStandartGoods.ToString(),
                Length = delivery.Offer.Request.Length.ToString(),
                Width = delivery.Offer.Request.Width.ToString(),
                Height = delivery.Offer.Request.Height.ToString(),
                Volume = delivery.Offer.Request.Volume.ToString(),
                Weight = delivery.Offer.Request.Weight.ToString(),
                TypeOfGoods = delivery.Offer.Request.TypeOfGoods,
                PickupAddress = delivery.Offer.Request.PickupAddress,
                PickupLatitude = delivery.Offer.Request.PickupLatitude.ToString(),
                PickupLongitude = delivery.Offer.Request.PickupLongitude.ToString(),
                DeliveryLatitude = delivery.Offer.Request.DeliveryLatitude.ToString(),
                DeliveryLongitude = delivery.Offer.Request.DeliveryLongitude.ToString(),
                DeliveryAddress = delivery.Offer.Request.DeliveryAddress,
                SharedTruck = delivery.Offer.Request.SharedTruck,
                ExpectedDeliveryDate = delivery.Offer.Request.ExpectedDeliveryDate.ToString("dd/MM/yyyy"),
                SpecialInstructions = delivery.Offer.Request.SpecialInstructions,
                IsRefrigerated = delivery.Offer.Request.IsRefrigerated,
                ReferenceNumber = delivery.ReferenceNumber,
                RegistrationNumber = delivery.Vehicle.RegistrationNumber,
                VehicleType = delivery.Vehicle.VehicleType,
            };
        }

        public async Task<List<DeliveryViewModel>?> GetDeliveryForDriverAsync(string username, string referenceNumber = null, DateTime? endDate = null, DateTime? startDate = null, string? deliveryAddress = null, string? pickupAddress = null, string? cientCompany = null)
        {
            var deliveries = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>()
                .Include(x => x.Vehicle)
                .Include(x => x.Driver)
                .Include(x => x.Offer)
                .ThenInclude(x => x.Request)
                .ThenInclude(x => x.ClientCompany)
                .Where(x => x.Driver.User.UserName == username)
                .ToListAsync();

            if (string.IsNullOrEmpty(referenceNumber) == false)
            {
                deliveries = deliveries.Where(x => x.ReferenceNumber == referenceNumber).ToList();
            }
            if (endDate != null)
            {
                deliveries = deliveries.Where(x => x.Offer.Request.ExpectedDeliveryDate <= endDate).ToList();
            }
            if (startDate != null)
            {
                deliveries = deliveries.Where(x => x.Offer.Request.ExpectedDeliveryDate >= startDate).ToList();
            }
            if (string.IsNullOrEmpty(deliveryAddress) == false)
            {
                deliveries = deliveries.Where(x => x.Offer.Request.DeliveryAddress.Contains(deliveryAddress)).ToList();
            }
            if (string.IsNullOrEmpty(pickupAddress) == false)
            {
                deliveries = deliveries.Where(x => x.Offer.Request.PickupAddress.Contains(pickupAddress)).ToList();
            }
            if(string.IsNullOrEmpty(cientCompany) == false)
            {
                deliveries = deliveries.Where(x => x.Offer.Request.ClientCompany.Name.Contains(cientCompany)).ToList();
            }
            var deliveriesToShow = deliveries.Select(x => new DeliveryViewModel
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
                ExpectedDeliveryDate = x.Offer.Request.ExpectedDeliveryDate.ToString("dd/MM/yyyy"),
                SpecialInstructions = x.Offer.Request.SpecialInstructions,
                IsRefrigerated = x.Offer.Request.IsRefrigerated,
                ReferenceNumber = x.ReferenceNumber
            }).ToList();
            return deliveriesToShow;
        }

        public async Task<DeliveryViewModel> GetDeliveryForDriverByReferenceNumberAsync(string searchTerm)
        {
            return await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>().Where(x => x.ReferenceNumber == searchTerm)
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

        public async Task<List<DeliveryViewModel>?> GetDeliveryForDriverBySearchtermAsync(string username, string? searchTerm)
        {
            var deliveries = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>()
               .Include(x => x.Vehicle)
               .Include(x => x.Driver)
               .Include(x => x.Offer)
               .ThenInclude(x => x.Request)
               .ThenInclude(x => x.ClientCompany)
               .Where(x => x.Driver.User.UserName == username)
               .ToListAsync();

            if (string.IsNullOrEmpty(searchTerm) == false)
            {
                deliveries = deliveries.Where(x => x.Offer.Request.ClientCompany.Name.ToLower().Contains(searchTerm.ToLower()) 
                || x.Offer.Request.DeliveryAddress.ToLower().Contains(searchTerm.ToLower()) 
                ||x.Offer.Request.PickupAddress.ToLower().Contains(searchTerm.ToLower()) 
                ||x.ReferenceNumber.ToLower().Contains(searchTerm.ToLower())
                 ).ToList();
            }
            var deliveriesToShow = deliveries.Select(x => new DeliveryViewModel
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
                ExpectedDeliveryDate = x.Offer.Request.ExpectedDeliveryDate.ToString("dd/MM/yyyy"),
                SpecialInstructions = x.Offer.Request.SpecialInstructions,
                IsRefrigerated = x.Offer.Request.IsRefrigerated,
                ReferenceNumber = x.ReferenceNumber
            }).ToList();
            return deliveriesToShow;
        }

        public async Task<DriverDashboardViewModel?> GetDriverDashboardAsync(string username)
        {
            var driver = await repository.AllReadonly<Infrastructure.Data.DataModels.Driver>().Where(x => x.User.UserName == username)
                .Include(x => x.User)
                .FirstOrDefaultAsync();
            var model = new DriverDashboardViewModel()
            {
                KilometersDriven = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>().Where(x => x.DriverId == driver.Id).SumAsync(x => x.Offer.Request.Kilometers),
                NewDeliveriesCount = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>().Where(x => x.DeliveryStep == 1).CountAsync(),
            };
            model.Last5Deliveries = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>().Where(x => x.DriverId == driver.Id).OrderByDescending(x => x.Offer.OfferDate).Take(5)
                .Select(x => new DeliveryViewModel
                {
                    Id = x.Id,
                    ClientCompanyName = x.Offer.Request.ClientCompany.Name,
                    PickupAddress = x.Offer.Request.PickupAddress,
                    DeliveryAddress = x.Offer.Request.DeliveryAddress,
                    ReferenceNumber = x.ReferenceNumber
                })
                .ToListAsync();
            model.NewDeliveries = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>().Where(x => x.DriverId == driver.Id && x.DeliveryStep == 1)
                .Select(x => new DeliveryViewModel
                {
                    Id = x.Id,
                    ClientCompanyName = x.Offer.Request.ClientCompany.Name,
                    PickupAddress = x.Offer.Request.PickupAddress,
                    DeliveryAddress = x.Offer.Request.DeliveryAddress,
                    ReferenceNumber = x.ReferenceNumber
                }).ToListAsync();
            return model;
        }

        public async Task<List<DeliveryViewModel>?> GetNewDeliveryForDriverAsync(string username, string? referenceNumber = null, DateTime? endDate = null, DateTime? startDate = null, string? deliveryAddress = null, string? pickupAddress = null, string? companyName = null)
        {
            var deliveries = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>()
               .Include(x => x.Vehicle)
               .Include(x => x.Driver)
               .Include(x => x.Offer)
               .ThenInclude(x => x.Request)
               .ThenInclude(x => x.ClientCompany)
               .Where(x => x.Driver.User.UserName == username && x.DeliveryStep == 1)
               .ToListAsync();

            if (string.IsNullOrEmpty(referenceNumber) == false)
            {
                deliveries = deliveries.Where(x => x.ReferenceNumber == referenceNumber).ToList();
            }
            if (endDate != null)
            {
                deliveries = deliveries.Where(x => x.Offer.Request.ExpectedDeliveryDate <= endDate).ToList();
            }
            if (startDate != null)
            {
                deliveries = deliveries.Where(x => x.Offer.Request.ExpectedDeliveryDate >= startDate).ToList();
            }
            if (string.IsNullOrEmpty(deliveryAddress) == false)
            {
                deliveries = deliveries.Where(x => x.Offer.Request.DeliveryAddress.Contains(deliveryAddress)).ToList();
            }
            if (string.IsNullOrEmpty(pickupAddress) == false)
            {
                deliveries = deliveries.Where(x => x.Offer.Request.PickupAddress.Contains(pickupAddress)).ToList();
            }
            if (string.IsNullOrEmpty(companyName) == false)
            {
                deliveries = deliveries.Where(x => x.Offer.Request.ClientCompany.Name.Contains(companyName)).ToList();
            }
            var deliveriesToShow = deliveries.Select(x => new DeliveryViewModel
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
                ExpectedDeliveryDate = x.Offer.Request.ExpectedDeliveryDate.ToString("dd/MM/yyyy"),
                SpecialInstructions = x.Offer.Request.SpecialInstructions,
                IsRefrigerated = x.Offer.Request.IsRefrigerated,
                ReferenceNumber = x.ReferenceNumber
            }).ToList();
            return deliveriesToShow;
        }
    }
}

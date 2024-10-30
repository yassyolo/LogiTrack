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
            if(!string.IsNullOrEmpty(model.Type))
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

        public async Task AddStatusForDeliveryAsync(int deliveryId, AddStatusViewModel model, string username, string address)
        {
            var driver = await repository.All<Infrastructure.Data.DataModels.Driver>().FirstOrDefaultAsync(x => x.User.UserName == username);
            var delivery = await repository.All<Infrastructure.Data.DataModels.Delivery>().FirstOrDefaultAsync(x => x.Id == deliveryId && x.DriverId == driver.Id);
            var deliveryTracking = new Infrastructure.Data.DataModels.DeliveryTracking
            {
                DeliveryId = deliveryId,
                DriverId = driver.Id,
                Notes = model.Notes,
                Timestamp = DateTime.Now,
                StatusUpdate = model.StatusUpdate,
                Latitude = model.Latitude.Value,
                Longitude = model.Longitude.Value,
                Address = address
            };
            var calendarEvent = new Infrastructure.Data.DataModels.CalendarEvent
            {
                EventType = model.StatusUpdate,
                Date = DateTime.Now,
                ClientCompanyId = delivery.Offer.Request.ClientCompanyId
            };
            switch (model.StatusUpdate)
            {
                    case DeliveryTrackingStatusConstants.Collected:
                      delivery.DeliveryStep = 2;
                      calendarEvent.Title = $"Delivery {delivery.ReferenceNumber} collected";
                    break;
                    case DeliveryTrackingStatusConstants.InTransit:
                      delivery.DeliveryStep = 3;
                    break;
                    case DeliveryTrackingStatusConstants.Delivered:
                      delivery.DeliveryStep = 4;
                      calendarEvent.Title = $"Delivery {delivery.ReferenceNumber} delivered";
                    break;
            }
            await repository.AddAsync(calendarEvent);
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
                    .AnyAsync(x => x.Driver.User.UserName == username && x.Id == id);
        }

        public async Task<bool> DriverWithUsernameExistsAsync(string username)
        {
            return await repository.AllReadonly<Infrastructure.Data.DataModels.Driver>().AnyAsync(x => x.User.UserName == username);
        }

        public async Task<List<CashRegisterIndexViewModel>> GetCashRegistersForDeliveryAsync(string? referenceNumber = null, DateTime? startDate = null, DateTime? endDate = null, string? type = null)
        {
            var cashRegisters = await repository.AllReadonly<Infrastructure.Data.DataModels.CashRegister>().ToListAsync();
            if (startDate != null)
            {
                cashRegisters = cashRegisters.Where(x => x.DateSubmitted >= startDate).ToList();
            }
            if (endDate != null)
            {
                cashRegisters = cashRegisters.Where(x => x.DateSubmitted <= endDate).ToList();
            }
            if(string.IsNullOrEmpty(referenceNumber) == false)
            {               
                cashRegisters = cashRegisters.Where(x => x.Delivery.ReferenceNumber == referenceNumber).ToList();
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
                DateSubmitted = x.DateSubmitted.ToString("dd-MM-yyyy")
            }).ToList();
        }

        public async Task<int> GetDeliveryByReferenceNumberAsync(string referenceNumber)
        {
            var deliveryId = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>().Where(x => x.ReferenceNumber == referenceNumber).Select(x => x.Id).FirstOrDefaultAsync();
            return deliveryId;
        }

        public async Task<DeliveryForAccountantViewModel> GetDeliveryDetailsForAccountantAsync(int id)
        {
            var delivery = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>().Where(x => x.Id == id)
                .Include(x => x.Vehicle)
                .Include(x => x.Driver)
                .Include(x => x.Offer)
                .ThenInclude(x => x.Request)
                .ThenInclude(x => x.ClientCompany)
                .ThenInclude(x => x.User)
                .FirstOrDefaultAsync(); 
            var model = new DeliveryForAccountantViewModel
            {
                Id = delivery.Id,
                ClientCompanyName = delivery.Offer.Request.ClientCompany.Name,
                ClientAddress = $"{delivery.Offer.Request.ClientCompany.City}, {delivery.Offer.Request.ClientCompany.City}, {delivery.Offer.Request.ClientCompany.Street}, {delivery.Offer.Request.ClientCompany.PostalCode} ",
                ClientEmail = delivery.Offer.Request.ClientCompany.User.Email,
                ClientPhone = delivery.Offer.Request.ClientCompany.User.PhoneNumber,
                CargoType = delivery.Offer.Request.CargoType,
                TypeOfPallet = delivery.Offer.Request.StandartCargo.TypeOfPallet,
                NumberOfPallets = delivery.Offer.Request.StandartCargo.NumberOfPallets,
                PalletLength = delivery.Offer.Request.StandartCargo.PalletLength.ToString(),
                PalletWidth = delivery.Offer.Request.StandartCargo.PalletWidth.ToString(),
                PalletHeight = delivery.Offer.Request.StandartCargo.PalletHeight.ToString(),
                PalletVolume = delivery.Offer.Request.StandartCargo.PalletVolume.ToString(),
                WeightOfPallets = delivery.Offer.Request.StandartCargo.WeightOfPallets.ToString(),
                PalletsAreStackable = delivery.Offer.Request.StandartCargo.PalletsAreStackable,
                NumberOfNonStandartGoods = delivery.Offer.Request.NumberOfNonStandartGoods,
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
                ActualDeliveryDate = delivery.ActualDeliveryDate.ToString("dd-MM-yyyy"),
                VehicleType = delivery.Vehicle.VehicleType,
                RegistrationNumber = delivery.Vehicle.RegistrationNumber,
                Age = delivery.Driver.Age.ToString(),
                Name = delivery.Driver.Name,    
                Salary = delivery.Driver.Salary.ToString(),
                YearOfExperience = delivery.Driver.YearOfExperience.ToString(),
                MonthsOfExperience = delivery.Driver.MonthsOfExperience.ToString(),
                DeliveryStep = delivery.DeliveryStep,
                IsPaid = await repository.AllReadonly<Invoice>().AnyAsync(x => x.DeliveryId == delivery.Id && x.IsPaid == true)
            };

            var cashRegisters = await repository.AllReadonly<Infrastructure.Data.DataModels.CashRegister>().Where(x => x.DeliveryId == delivery.Id)
                .Select(x => new CashRegisterIndexViewModel()
                {
                    Id = x.Id,
                    Type = x.Type,
                    Amount = x.Amount.ToString(),
                    Description = x.Description,
                    DateSubmitted = x.DateSubmitted.ToString("dd-MM-yyyy"),    
                    FileId = x.FileId
                })
                .ToListAsync();
            foreach (var register in cashRegisters)
            {
               register.FileUrl = await googleDriveService.GetFileUrlAsync(register.FileId);
            }
            model.CashRegisters = cashRegisters;
            model.NonStandardCargos = await repository.AllReadonly<Infrastructure.Data.DataModels.NonStandardCargo>().Where(x => x.RequestId == delivery.Offer.RequestId)
                .Select(x => new NonStandardCargosViewModel
                {
                    Length = x.Length.ToString(),
                    Width = x.Width.ToString(),
                    Height = x.Height.ToString(),
                    Weight = x.Weight.ToString()
                }).ToListAsync();
            var invoice = await repository.AllReadonly<Invoice>().Where(x => x.DeliveryId == delivery.Id)
                .Select(x => new InvoiceFordeliveryViewModel
                {
                    IsPaid = x.IsPaid,
                    Amount = x.Delivery.Offer.FinalPrice.ToString(),
                    Date = x.InvoiceDate.ToString("dd-MM-yyyy"),
                    Description = x.Description,
                    Number = x.InvoiceNumber,
                    FileId = x.FileId
                }).FirstOrDefaultAsync();
            invoice.FileUrl = await googleDriveService.GetFileUrlAsync(invoice.FileId);
            model.Invoice = invoice;
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
            var model =  new DeliveryForDriverViewModel
            {
                Id = delivery.Id,
                ClientCompanyName = delivery.Offer.Request.ClientCompany.Name,
                CargoType = delivery.Offer.Request.CargoType,
                TypeOfPallet = delivery.Offer.Request.StandartCargo.TypeOfPallet,
                NumberOfPallets = delivery.Offer.Request.StandartCargo.NumberOfPallets.ToString(),
                PalletLength = delivery.Offer.Request.StandartCargo.PalletLength.ToString(),
                PalletWidth = delivery.Offer.Request.StandartCargo.PalletWidth.ToString(),
                PalletHeight = delivery.Offer.Request.StandartCargo.PalletHeight.ToString(),
                PalletVolume = delivery.Offer.Request.StandartCargo.PalletVolume.ToString(),
                WeightOfPallets = delivery.Offer.Request.StandartCargo.WeightOfPallets.ToString(),
                PalletsAreStackable = delivery.Offer.Request.StandartCargo.PalletsAreStackable,
                NumberOfNonStandartGoods = delivery.Offer.Request.NumberOfNonStandartGoods.ToString(),
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
                DeliveryStep = delivery.DeliveryStep
            };
            model.DeliveryTrackings = await repository.AllReadonly<Infrastructure.Data.DataModels.DeliveryTracking>().Where(x => x.DeliveryId == id)
                .Select(x => new DeliveryTrackingViewModel
                {
                    Timestamp = x.Timestamp.ToString("dd/MM/yyyy"),
                    StatusUpdate = x.StatusUpdate,
                    Address = x.Address,
                })
                .ToListAsync();
            model.NonStandardCargos = await repository.AllReadonly<Infrastructure.Data.DataModels.NonStandardCargo>().Where(x => x.RequestId == delivery.Offer.RequestId)
                .Select(x => new NonStandardCargosViewModel
                {
                    Length = x.Length.ToString(),
                    Width = x.Width.ToString(),
                    Height = x.Height.ToString(),
                    Weight = x.Weight.ToString()
                }).ToListAsync();

            return model;
        }

        public async Task<List<DeliveryViewModel>> GetDeliveryForAccountantAsync( string? referenceNumber = null, DateTime? endDate = null, DateTime? startDate = null, string? clientCompanyName = null, bool? isPaid = null)
        {
            var deliveries = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>()
               .Include(x => x.Vehicle)
               .Include(x => x.Driver)
               .Include(x => x.Offer)
               .ThenInclude(x => x.Request)
               .ThenInclude(x => x.ClientCompany)
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
            if (string.IsNullOrEmpty(clientCompanyName) == false)
            {
                deliveries = deliveries.Where(x => x.Offer.Request.ClientCompany.Name.Contains(clientCompanyName)).ToList();
            }
            if (isPaid == false)
            {              
                deliveries = deliveries.Where(x => x.Invoice.IsPaid == false).ToList();
            }
            else if(isPaid == true)
            {
                deliveries = deliveries.Where(x => x.Invoice.IsPaid == true).ToList();
            }
            var deliveriesToShow = deliveries.Select(x => new DeliveryViewModel
            {
                Id = x.Id,
                RequestId = x.Offer.RequestId,
                ClientCompanyId = x.Offer.Request.ClientCompanyId,
                ClientCompanyName = x.Offer.Request.ClientCompany.Name,
                CargoType = x.Offer.Request.CargoType,
                TypeOfPallet = x.Offer.Request.StandartCargo.TypeOfPallet,
                NumberOfPallets = x.Offer.Request.StandartCargo.NumberOfPallets,
                PalletLength = x.Offer.Request.StandartCargo.PalletLength.ToString(),
                PalletWidth = x.Offer.Request.StandartCargo.PalletWidth.ToString(),
                PalletHeight = x.Offer.Request.StandartCargo.PalletHeight.ToString(),
                PalletVolume = x.Offer.Request.StandartCargo.PalletVolume.ToString(),
                WeightOfPallets = x.Offer.Request.StandartCargo.WeightOfPallets.ToString(),
                PalletsAreStackable = x.Offer.Request.StandartCargo.PalletsAreStackable,
                NumberOfNonStandartGoods = x.Offer.Request.NumberOfNonStandartGoods,
                TypeOfGoods = x.Offer.Request.TypeOfGoods,
                PickupAddress = x.Offer.Request.PickupAddress,
                DeliveryAddress = x.Offer.Request.DeliveryAddress,
                SharedTruck = x.Offer.Request.SharedTruck,
                ExpectedDeliveryDate = x.Offer.Request.ExpectedDeliveryDate.ToString("dd/MM/yyyy"),
                SpecialInstructions = x.Offer.Request.SpecialInstructions,
                IsRefrigerated = x.Offer.Request.IsRefrigerated,
                ReferenceNumber = x.ReferenceNumber,
                //IsPaid = x.Offer.Invoice.IsPaid
            }).ToList();
            return deliveriesToShow;
        }

        public async Task<List<DeliveryViewModel>?> GetDeliveriesForDriverAsync(string username, string referenceNumber = null, DateTime? endDate = null, DateTime? startDate = null, string? deliveryAddress = null, string? pickupAddress = null, bool? isNew = null)
        {
            var deliveries = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>()
                .Include(x => x.Vehicle)
                .Include(x => x.Driver)
                .Include(x => x.Offer)
                .ThenInclude(x => x.Request)
                .ThenInclude(x => x.ClientCompany)
                .Where(x => x.Driver.User.UserName == username)
                .ToListAsync();

            if(isNew == true)
            {
                deliveries = deliveries.Where(x => x.DeliveryStep == 1).ToList();
            }  
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
           
            var deliveriesToShow = deliveries.Select(x => new DeliveryViewModel
            {
                Id = x.Id,
                RequestId = x.Offer.RequestId,
                ClientCompanyId = x.Offer.Request.ClientCompanyId,
                ClientCompanyName = x.Offer.Request.ClientCompany.Name,
                CargoType = x.Offer.Request.CargoType,
                TypeOfPallet = x.Offer.Request.StandartCargo.TypeOfPallet,
                NumberOfPallets = x.Offer.Request.StandartCargo.NumberOfPallets,
                PalletLength = x.Offer.Request.StandartCargo.PalletLength.ToString(),
                PalletWidth = x.Offer.Request.StandartCargo.PalletWidth.ToString(),
                PalletHeight = x.Offer.Request.StandartCargo.PalletHeight.ToString(),
                PalletVolume = x.Offer.Request.StandartCargo.PalletVolume.ToString(),
                WeightOfPallets = x.Offer.Request.StandartCargo.WeightOfPallets.ToString(),
                PalletsAreStackable = x.Offer.Request.StandartCargo.PalletsAreStackable,
                NumberOfNonStandartGoods = x.Offer.Request.NumberOfNonStandartGoods,
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
                    TypeOfPallet = x.Offer.Request.StandartCargo.TypeOfPallet,
                    NumberOfPallets = x.Offer.Request.StandartCargo.NumberOfPallets,
                    PalletLength = x.Offer.Request.StandartCargo.PalletLength.ToString(),
                    PalletWidth = x.Offer.Request.StandartCargo.PalletWidth.ToString(),
                    PalletHeight = x.Offer.Request.StandartCargo.PalletHeight.ToString(),
                    PalletVolume = x.Offer.Request.StandartCargo.PalletVolume.ToString(),
                    WeightOfPallets = x.Offer.Request.StandartCargo.WeightOfPallets.ToString(),
                    PalletsAreStackable = x.Offer.Request.StandartCargo.PalletsAreStackable,
                    NumberOfNonStandartGoods = x.Offer.Request.NumberOfNonStandartGoods,
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

        public async Task<List<DeliveryViewModel>?> GetDeliveriesForDriverBySearchtermAsync(string username, string? searchTerm)
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
                TypeOfPallet = x.Offer.Request.StandartCargo.TypeOfPallet,
                NumberOfPallets = x.Offer.Request.StandartCargo.NumberOfPallets,
                PalletLength = x.Offer.Request.StandartCargo.PalletLength.ToString(),
                PalletWidth = x.Offer.Request.StandartCargo.PalletWidth.ToString(),
                PalletHeight = x.Offer.Request.StandartCargo.PalletHeight.ToString(),
                PalletVolume = x.Offer.Request.StandartCargo.PalletVolume.ToString(),
                WeightOfPallets = x.Offer.Request.StandartCargo.WeightOfPallets.ToString(),
                PalletsAreStackable = x.Offer.Request.StandartCargo.PalletsAreStackable,
                NumberOfNonStandartGoods = x.Offer.Request.NumberOfNonStandartGoods,
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
            var driver = await repository.AllReadonly<Infrastructure.Data.DataModels.Driver>().Where(x => x.User.UserName == username).FirstOrDefaultAsync();
            var model = new DriverDashboardViewModel()
            {
                KilometersDriven = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>().Where(x => x.DriverId == driver.Id).SumAsync(x => x.Offer.Request.Kilometers),
                NewDeliveriesCount = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>().Where(x => x.DeliveryStep == 1).CountAsync()
            };
            model.LastDeliveries = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>().Where(x => x.DriverId == driver.Id).OrderByDescending(x => x.Offer.OfferDate).Take(5)
                .Select(x => new DeliveryForDriverDashboardViewModel
                {
                    Id = x.Id,
                    ClientCompanyName = x.Offer.Request.ClientCompany.Name,
                    PickupAddress = x.Offer.Request.PickupAddress,
                    DeliveryAddress = x.Offer.Request.DeliveryAddress,
                    ReferenceNumber = x.ReferenceNumber
                })
                .ToListAsync();
            model.NewDeliveries = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>().Where(x => x.DriverId == driver.Id && x.DeliveryStep == 1)
                .Select(x => new DeliveryForDriverDashboardViewModel
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
                TypeOfPallet = x.Offer.Request.StandartCargo.TypeOfPallet,
                NumberOfPallets = x.Offer.Request.StandartCargo.NumberOfPallets,
                PalletLength = x.Offer.Request.StandartCargo.PalletLength.ToString(),
                PalletWidth = x.Offer.Request.StandartCargo.PalletWidth.ToString(),
                PalletHeight = x.Offer.Request.StandartCargo.PalletHeight.ToString(),
                PalletVolume = x.Offer.Request.StandartCargo.PalletVolume.ToString(),
                WeightOfPallets = x.Offer.Request.StandartCargo.WeightOfPallets.ToString(),
                PalletsAreStackable = x.Offer.Request.StandartCargo.PalletsAreStackable,
                NumberOfNonStandartGoods = x.Offer.Request.NumberOfNonStandartGoods,
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

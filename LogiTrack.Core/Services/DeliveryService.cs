using LogisticsSystem.Infrastructure.Data.DataModels;
using LogiTrack.Core.Contracts;
using LogiTrack.Core.CustomExceptions;
using LogiTrack.Core.ViewModels.CashRegister;
using LogiTrack.Core.ViewModels.Delivery;
using LogiTrack.Core.ViewModels.Invoice;
using LogiTrack.Infrastructure.Data.DataModels;
using LogiTrack.Infrastructure.Repository;
using Microsoft.AspNetCore.Identity;
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

        public async Task<bool> DeliveryWithIdExistsAsync(int deliveryId)
        {
            return await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>().AnyAsync(x => x.Id == deliveryId);
        }

        public async Task<int> GetDeliveryByReferenceNumberAsync(string referenceNumber)
        {
            return await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>().Where(x => x.ReferenceNumber == referenceNumber).Select(x => x.Id).FirstOrDefaultAsync();
        }

        public async Task<DeliveryForAccountantViewModel> GetDeliveryDetailsForAccountantAsync(int id)
        {
            var model = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>().Where(x => x.Id == id)
                 .Where(x => x.Id == id)
                .Include(x => x.Vehicle)
                .Include(x => x.Driver)
                .Include(x => x.Offer)
                .ThenInclude(x => x.Request)
                .ThenInclude(x => x.ClientCompany) 
                .ThenInclude(x => x.User)  
                .Include(x => x.Offer)
                .ThenInclude(x => x.Request)
                .ThenInclude(x => x.PickupAddress)
                .Include(x => x.Offer)
                .ThenInclude(x => x.Request)
                .ThenInclude(x => x.DeliveryAddress)
                .Include(x => x.Offer)
                .ThenInclude(x => x.Request)
                .ThenInclude(x => x.StandartCargo)
                .Include(x => x.Invoice)
                .Select(x => new DeliveryForAccountantViewModel()
                {
					Id = x.Id,
					ClientCompanyName = x.Offer.Request.ClientCompany.Name,
					ClientAddress = $"{x.Offer.Request.ClientCompany.Address.City}, {x.Offer.Request.ClientCompany.Address.City}, {x.Offer.Request.ClientCompany.Address.Street}, {x.Offer.Request.ClientCompany.Address.PostalCode} ",
					ClientEmail = x.Offer.Request.ClientCompany.User.Email,
					ClientPhone = x.Offer.Request.ClientCompany.User.PhoneNumber,
					PickupAddress = $"{x.Offer.Request.PickupAddress.Street}, {x.Offer.Request.PickupAddress.City}, {x.Offer.Request.PickupAddress.County}",
					DeliveryAddress = $"{x.Offer.Request.DeliveryAddress.Street}, {x.Offer.Request.DeliveryAddress.City}, {x.Offer.Request.DeliveryAddress.County}",
					Profit = x.Profit.ToString(),
					ReferenceNumber = x.ReferenceNumber,
					VehicleType = x.Vehicle.VehicleType,
					RegistrationNumber = x.Vehicle.RegistrationNumber,
					Age = x.Driver.Age.ToString(),
					Name = x.Driver.Name,
					Salary = x.Driver.Salary.ToString(),
					YearOfExperience = x.Driver.YearOfExperience.ToString(),
					MonthsOfExperience = x.Driver.MonthsOfExperience.ToString(),
					DeliveryStep = x.DeliveryStep,
					IsPaid = x.Invoice.IsPaid
				})
                .FirstOrDefaultAsync();

            var cashRegisters = await repository.AllReadonly<Infrastructure.Data.DataModels.CashRegister>().Where(x => x.DeliveryId == id).ToListAsync();

            var fileIds = cashRegisters.Select(x => x.FileId).Distinct().ToList();
            var fileUrlTasks = fileIds.Select(x => googleDriveService.GetFileUrlAsync(x)).ToArray();
            var fileUrls = await Task.WhenAll(fileUrlTasks);

            var cashRegistersModel = cashRegisters
                .Select((x, index) => new CashRegisterIndexViewModel()
                {
                    Id = x.Id,
                    DeliveryId = x.DeliveryId,
                    Type = x.Type,
                    Amount = x.Amount.ToString(),
                    Description = x.Description,
                    DateSubmitted = x.DateSubmitted.ToString("dd-MM-yyyy"),
                    FileId = x.FileId,
                    FileUrl = fileUrls.ElementAtOrDefault(index)
                })
                .ToList();

            model.CashRegisters = cashRegistersModel;
            model.NonStandardCargos = await GetNonStandartCargosForDelivery(id);

            model.Invoice = await GetInvoiceForDelivery(id);

            return model;
        }

        private async Task<InvoiceForDeliveryViewModel> GetInvoiceForDelivery(int id)
        {
            var delivery = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>().Where(x => x.Id == id).FirstOrDefaultAsync();
            var invoice = await repository.AllReadonly<Invoice>().Where(x => x.Id == delivery.InvoiceId)
                .Select(x => new InvoiceForDeliveryViewModel
                {
                    IsPaid = x.IsPaid,
                    Amount = x.Delivery.Offer.FinalPrice.ToString(),
                    Date = x.InvoiceDate.ToString("dd-MM-yyyy"),
                    Description = x.Description,
                    Number = x.InvoiceNumber,
                    FileId = x.FileId
                }).FirstOrDefaultAsync();

            if (invoice != null)
            {
                invoice.FileUrl = await googleDriveService.GetFileUrlAsync(invoice.FileId);
            }

            return invoice;
        }
        public async Task<DeliveryForDriverViewModel?> GetDeliveryDetailsForDriverAsync(int id)
        {
            var delivery = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>().Where(x => x.Id == id)
                .Include(x => x.Vehicle)
                .Include(x => x.Driver)
                .Include(x => x.Offer)
                .ThenInclude(x => x.Request)
                .ThenInclude(x => x.StandartCargo)
                .Include(x => x.Offer)
                .ThenInclude(x => x.Request)
                .ThenInclude(x => x.ClientCompany)
                 .Include(x => x.Offer)
                 .ThenInclude(x => x.Request)
                 .ThenInclude(x => x.PickupAddress)
                 .Include(x => x.Offer)
                 .ThenInclude(x => x.Request)
                 .ThenInclude(x => x.DeliveryAddress)
                .FirstOrDefaultAsync();
            var vehicle = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Vehicle>().Where(x => x.Id == delivery.VehicleId).FirstOrDefaultAsync();
            var model = new DeliveryForDriverViewModel
            {
                Id = delivery?.Id ?? throw new DeliveryNotFoundException(),
                ClientCompanyName = delivery.Offer.Request.ClientCompany.Name,
                CurrentTime = DateTime.Now.ToString("dd-MM-yyyy, HH:mm"),
                NumberOfPallets = delivery.Offer.Request.StandartCargo?.NumberOfPallets.ToString() ?? "0",
                PalletLength = delivery.Offer.Request.StandartCargo?.PalletLength.ToString() ?? "0",
                PalletWidth = delivery.Offer.Request.StandartCargo?.PalletWidth.ToString() ?? "0",
                PalletHeight = delivery.Offer.Request.StandartCargo?.PalletHeight.ToString() ?? "0",
                PalletVolume = delivery.Offer.Request.StandartCargo?.PalletVolume.ToString() ?? "0",
                WeightOfPallets = delivery.Offer.Request.StandartCargo?.WeightOfPallets.ToString() ?? "0",
                PalletsAreStackable = delivery.Offer.Request.StandartCargo?.PalletsAreStackable == true ? "Yes" : "No",
                TypeOfGoods = delivery.Offer.Request.TypeOfGoods,
                PickupLatitude = delivery.Offer.Request.PickupAddress.Latitude.ToString(),
                PickupCity = delivery.Offer.Request.PickupAddress.City,
                PickupCountry = delivery.Offer.Request.PickupAddress.County,
                PickupStreet = delivery.Offer.Request.PickupAddress.Street,
                PickupLongitude = delivery.Offer.Request.PickupAddress.Longitude.ToString(),
                DeliveryCity = delivery.Offer.Request.DeliveryAddress.City,
                DeliveryCountry = delivery.Offer.Request.DeliveryAddress.County,
                DeliveryStreet = delivery.Offer.Request.DeliveryAddress.Street,
                DeliveryLatitude = delivery.Offer.Request.DeliveryAddress.Latitude.ToString(),
                DeliveryLongitude = delivery.Offer.Request.DeliveryAddress.Longitude.ToString(),
                SharedTruck = delivery.Offer.Request.SharedTruck == true ? "Yes" : "No",
                ExpectedDeliveryDate = delivery.Offer.Request.ExpectedDeliveryDate.ToString("dd-MM-yyyy"),
                SpecialInstructions = delivery.Offer.Request.SpecialInstructions,
                IsRefrigerated = delivery.Offer.Request.IsRefrigerated == true ? "Yes" : "No",
                ReferenceNumber = delivery.ReferenceNumber,
                RegistrationNumber = vehicle.RegistrationNumber,
                VehicleType = vehicle.VehicleType,
                VehicleHeight = vehicle.Height.ToString(),
                VehicleLength = vehicle.Length.ToString(),
                VehicleWidth = vehicle.Width.ToString(),
                VehicleWeightCapacity = vehicle.MaxWeightCapacity.ToString(),
                FuelConsumptionPer100Km = vehicle.FuelConsumptionPer100Km.ToString(),
                DeliveryStep = delivery.DeliveryStep
            };

            model.DeliveryTrackings = await GetDeliveryTrackingsForDelivery(id);

            model.NonStandardCargos = await GetNonStandartCargosForDelivery(id);

            return model;
        }

        private async Task<List<NonStandardCargosViewModel>> GetNonStandartCargosForDelivery(int id)
        {
            var delivery = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>().Include(x => x.Offer).ThenInclude(x => x.Request).Where(x => x.Id == id).FirstOrDefaultAsync();
            return await repository.AllReadonly<Infrastructure.Data.DataModels.NonStandardCargo>().Where(x => x.RequestId == delivery.Offer.RequestId)
                            .Select(x => new NonStandardCargosViewModel
                            {
                                Length = x.Length.ToString(),
                                Width = x.Width.ToString(),
                                Height = x.Height.ToString(),
                                Weight = x.Weight.ToString(),
                                Description = x.Description
                            }).ToListAsync();
        }

        public async Task<List<DeliveryViewModel>> GetDeliveriesForAccountantAsync(string? referenceNumber = null, DateTime? endDate = null, DateTime? startDate = null, string? clientCompanyName = null, bool? isPaid = null)
        {
            var query = repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>()
               .Include(x => x.Vehicle)
               .Include(x => x.Driver)
               .Include(x => x.Offer)
               .ThenInclude(x => x.Request)
               .ThenInclude(x => x.ClientCompany)
               .Include(x => x.Offer)
               .ThenInclude(x => x.Request)
               .ThenInclude(x => x.PickupAddress)
               .Include(x => x.Offer)
               .ThenInclude(x => x.Request)
               .ThenInclude(x => x.DeliveryAddress)
               .Include(x => x.Invoice)
               .AsQueryable();

            if (string.IsNullOrEmpty(referenceNumber) == false)
            {
                query = query.Where(x => x.ReferenceNumber == referenceNumber);
            }
            if (endDate != null)
            {
                query = query.Where(x => x.Offer.Request.ExpectedDeliveryDate <= endDate);
            }
            if (startDate != null)
            {
                query = query.Where(x => x.Offer.Request.ExpectedDeliveryDate >= startDate);
            }
            if (string.IsNullOrEmpty(clientCompanyName) == false)
            {
                query = query.Where(x => x.Offer.Request.ClientCompany.Name.Contains(clientCompanyName));
            }
            if (isPaid == false)
            {
                query = query.Where(x => x.Invoice.IsPaid == false);
            }
            else if (isPaid == true)
            {
                query = query.Where(x => x.Invoice.IsPaid == true);
            }

            var deliveries = await query.ToListAsync();
            var deliveriesToShow = deliveries.Select(x => new DeliveryViewModel
            {
                Id = x.Id,
                RequestId = x.Offer.RequestId,
                ClientCompanyId = x.Offer.Request.ClientCompanyId,
                ClientCompanyName = x.Offer.Request.ClientCompany.Name,
                CargoType = x.Offer.Request.CargoType,
                TotalCargos = (x.Offer.Request.StandartCargo?.NumberOfPallets ?? 0) + (x.Offer.Request.NumberOfNonStandartGoods ?? 0).ToString(),
                TotalVolume = x.Offer.Request.TotalVolume.ToString("F2"),
                TotalWeight = x.Offer.Request.TotalWeight.ToString("F2"),
                PickupAddress = $"{x.Offer.Request.PickupAddress.City}, {x.Offer.Request.PickupAddress.County}",
                DeliveryAddress = $"{x.Offer.Request.DeliveryAddress.City}, {x.Offer.Request.DeliveryAddress.County}",
                ExpectedDeliveryDate = x.Offer.Request.ExpectedDeliveryDate.ToString("dd-MM-yyyy"),
                ReferenceNumber = x.ReferenceNumber,
                IsPaid = x.Invoice?.IsPaid ?? false,
                ActualDeliveryDate = x.ActualDeliveryDate.HasValue ? x.ActualDeliveryDate.Value.ToString("dd-MM-yyyy") : string.Empty
            }).ToList();
            return deliveriesToShow;
        }

        public async Task<List<DeliveryViewModel>?> GetDeliveriesForDriverAsync(string username, string? referenceNumber = null, DateTime? endDate = null, DateTime? startDate = null, string? deliveryAddress = null, string? pickupAddress = null, bool? isNew = null)
        {
            var query = repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>()
                .Include(x => x.Vehicle)
                .Include(x => x.Driver)
                .Include(x => x.Offer)
                .ThenInclude(x => x.Request)
                .ThenInclude(x => x.StandartCargo)
                .Include(x => x.Offer)
                .ThenInclude(x => x.Request)
                .ThenInclude(x => x.ClientCompany)
                .Include(x => x.Offer)
                .ThenInclude(x => x.Request)
                .ThenInclude(x => x.PickupAddress)
                .Include(x => x.Offer)
                .ThenInclude(x => x.Request)
                .ThenInclude(x => x.DeliveryAddress)
                .Where(x => x.Driver.User.UserName == username)
                .AsQueryable();

            if (isNew == true)
            {
                query = query.Where(x => x.DeliveryStep == 1);
            }
            if (string.IsNullOrEmpty(referenceNumber) == false)
            {
                query = query.Where(x => x.ReferenceNumber == referenceNumber);
            }
            if (endDate != null)
            {
                query = query.Where(x => x.Offer.Request.ExpectedDeliveryDate <= endDate);
            }
            if (startDate != null)
            {
                query = query.Where(x => x.Offer.Request.ExpectedDeliveryDate >= startDate);
            }
            if (string.IsNullOrEmpty(deliveryAddress) == false)
            {
                query = query.Where(x => x.Offer.Request.DeliveryAddress.City.ToLower().Contains(deliveryAddress.ToLower()) || x.Offer.Request.DeliveryAddress.County.ToLower().Contains(deliveryAddress.ToLower()) || x.Offer.Request.DeliveryAddress.Street.ToLower().Contains(deliveryAddress.ToLower()));
            }
            if (string.IsNullOrEmpty(pickupAddress) == false)
            {
                query = query.Where(x => x.Offer.Request.PickupAddress.City.ToLower().Contains(pickupAddress.ToLower()) || x.Offer.Request.PickupAddress.County.ToLower().Contains(pickupAddress.ToLower()) || x.Offer.Request.PickupAddress.Street.ToLower().Contains(pickupAddress.ToLower()));
            }

            var deliveries = await query.ToListAsync();
            var deliveriesToShow = deliveries.Select(x => new DeliveryViewModel
            {
                Id = x.Id,
                RequestId = x.Offer.RequestId,
                ClientCompanyId = x.Offer.Request.ClientCompanyId,
                ClientCompanyName = x.Offer.Request.ClientCompany.Name,
                CargoType = x.Offer.Request.CargoType,
                TotalCargos = (x.Offer.Request.StandartCargo?.NumberOfPallets ?? 0) + (x.Offer.Request.NumberOfNonStandartGoods ?? 0).ToString(),
                TotalVolume = x.Offer.Request.TotalVolume.ToString("F2"),
                TotalWeight = x.Offer.Request.TotalWeight.ToString("F2"),
                TypeOfGoods = x.Offer.Request.TypeOfGoods,
                PickupAddress = $"{x.Offer.Request.PickupAddress.Street}, {x.Offer.Request.PickupAddress.City}, {x.Offer.Request.PickupAddress.County}",
                DeliveryAddress = $"{x.Offer.Request.DeliveryAddress.Street}, {x.Offer.Request.DeliveryAddress.City}, {x.Offer.Request.DeliveryAddress.County}",
                SharedTruck = x.Offer.Request.SharedTruck,
                ExpectedDeliveryDate = x.Offer.Request.ExpectedDeliveryDate.ToString("dd-MM-yyyy"),
                SpecialInstructions = x.Offer.Request.SpecialInstructions,
                IsRefrigerated = x.Offer.Request.IsRefrigerated,
                ReferenceNumber = x.ReferenceNumber,
                IsNew = x.DeliveryStep == 1 ? true : false,
                ActualDeliveryDate = x.ActualDeliveryDate.HasValue ? x.ActualDeliveryDate.Value.ToString("dd-MM-yyyy") : string.Empty
            }).ToList();
            return deliveriesToShow;
        }

        public async Task<List<DeliveryViewModel>?> GetDeliveriesForDriverBySearchtermAsync(string username, string? searchTerm)
        {
            var query = repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>()
               .Include(x => x.Vehicle)
               .Include(x => x.Driver)
               .Include(x => x.Offer)
               .ThenInclude(x => x.Request)
               .ThenInclude(x => x.ClientCompany)
               .Include(x => x.Offer)
               .ThenInclude(x => x.Request)
               .ThenInclude(x => x.PickupAddress)
               .Include(x => x.Offer)
               .ThenInclude(x => x.Request)
               .ThenInclude(x => x.DeliveryAddress)
               .Where(x => x.Driver.User.UserName == username)
               .AsQueryable();

            if (string.IsNullOrEmpty(searchTerm) == false)
            {
                query = GetDeliveryAsQueryableBySearchTerm(query, searchTerm);

                var deliveries = await query.ToListAsync();
                return deliveries.Select(x => new DeliveryViewModel
                {
                    Id = x.Id,
                    RequestId = x.Offer.RequestId,
                    ClientCompanyId = x.Offer.Request.ClientCompanyId,
                    ClientCompanyName = x.Offer.Request.ClientCompany.Name,
                    CargoType = x.Offer.Request.CargoType,
                    TotalCargos = (x.Offer.Request.StandartCargo?.NumberOfPallets ?? 0) + (x.Offer.Request.NumberOfNonStandartGoods ?? 0).ToString(),
                    TotalVolume = x.Offer.Request.TotalVolume.ToString("F2"),
                    TotalWeight = x.Offer.Request.TotalWeight.ToString("F2"),
                    TypeOfGoods = x.Offer.Request.TypeOfGoods,
                    PickupAddress = $"{x.Offer.Request.PickupAddress.Street}, {x.Offer.Request.PickupAddress.City}, {x.Offer.Request.PickupAddress.County}",
                    DeliveryAddress = $"{x.Offer.Request.DeliveryAddress.Street}, {x.Offer.Request.DeliveryAddress.City}, {x.Offer.Request.DeliveryAddress.County}",
                    SharedTruck = x.Offer.Request.SharedTruck,
                    ExpectedDeliveryDate = x.Offer.Request.ExpectedDeliveryDate.ToString("dd-MM-yyyy"),
                    SpecialInstructions = x.Offer.Request.SpecialInstructions,
                    IsRefrigerated = x.Offer.Request.IsRefrigerated,
                    ReferenceNumber = x.ReferenceNumber,
                    IsNew = x.DeliveryStep == 1 ? true : false
                }).ToList();
            }

            return new List<DeliveryViewModel>();
        }

        public async Task<List<DeliveryViewModel>> GetDeliveriesForAccountantBySearchtermAsync(string? searchTerm = null)
        {
            var query = repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>()
              .Include(x => x.Vehicle)
              .Include(x => x.Driver)
              .Include(x => x.Offer)
              .ThenInclude(x => x.Request)
              .ThenInclude(x => x.ClientCompany)
              .Include(x => x.Offer)
              .ThenInclude(x => x.Request)
              .ThenInclude(x => x.PickupAddress)
              .Include(x => x.Offer)
              .ThenInclude(x => x.Request)
              .ThenInclude(x => x.DeliveryAddress)
              .Include(x => x.Invoice)
              .AsQueryable();

            if (string.IsNullOrEmpty(searchTerm) == false)
            {
                query = GetDeliveryAsQueryableBySearchTerm(query, searchTerm);

                var deliveries = await query.ToListAsync();
                return deliveries.Select(x => new DeliveryViewModel
                {
                    Id = x.Id,
                    RequestId = x.Offer.RequestId,
                    ClientCompanyId = x.Offer.Request.ClientCompanyId,
                    ClientCompanyName = x.Offer.Request.ClientCompany.Name,
                    CargoType = x.Offer.Request.CargoType,
                    TotalCargos = (x.Offer.Request.StandartCargo?.NumberOfPallets ?? 0) + (x.Offer.Request.NumberOfNonStandartGoods ?? 0).ToString(),
                    TotalVolume = x.Offer.Request.TotalVolume.ToString(),
                    TotalWeight = x.Offer.Request.TotalWeight.ToString(),
                    PickupAddress = $"{x.Offer.Request.PickupAddress.City}, {x.Offer.Request.PickupAddress.County}",
                    DeliveryAddress = $"{x.Offer.Request.DeliveryAddress.City}, {x.Offer.Request.DeliveryAddress.County}",
                    ExpectedDeliveryDate = x.Offer.Request.ExpectedDeliveryDate.ToString("dd-MM-yyyy"),
                    ReferenceNumber = x.ReferenceNumber,
                    IsPaid = x.Invoice?.IsPaid ?? false,
                    ActualDeliveryDate = x.ActualDeliveryDate.HasValue ? x.ActualDeliveryDate.Value.ToString("dd-MM-yyyy") : string.Empty
                }).ToList();
            }

            return new List<DeliveryViewModel>();
        }

        private IQueryable<Infrastructure.Data.DataModels.Delivery?> GetDeliveryAsQueryableBySearchTerm(IQueryable<Infrastructure.Data.DataModels.Delivery?> query, string searchTerm)
        {
            decimal? parsedPrice = null;
            if (decimal.TryParse(searchTerm, out decimal finalPrice))
            {
                parsedPrice = finalPrice;
            }
            var searchTermToLower = searchTerm.ToLower();

             return query.Where(x =>
             x.Offer.Request.DeliveryAddress.City.ToLower().Contains(searchTermToLower) ||
             x.Offer.Request.DeliveryAddress.County.ToLower().Contains(searchTermToLower) ||
             x.Offer.Request.DeliveryAddress.Street.ToLower().Contains(searchTermToLower) ||
             x.Offer.Request.PickupAddress.City.ToLower().Contains(searchTermToLower) ||
             x.Offer.Request.PickupAddress.County.ToLower().Contains(searchTermToLower) ||
             x.Offer.Request.PickupAddress.Street.ToLower().Contains(searchTermToLower) ||
             x.ReferenceNumber.ToLower().Contains(searchTermToLower) ||
             x.Offer.FinalPrice == parsedPrice ||
             x.Offer.Request.ExpectedDeliveryDate.ToString("dd-MM-yyyy").Contains(searchTerm) ||
             x.Offer.Request.TotalWeight.ToString().Contains(searchTerm) ||
             x.Offer.Request.TotalVolume.ToString().Contains(searchTerm) ||
             x.Offer.Request.NumberOfNonStandartGoods.ToString().Contains(searchTerm) ||
             x.Offer.Request.StandartCargo.NumberOfPallets.ToString().Contains(searchTerm) ||
             x.Offer.Request.TypeOfGoods.ToLower().Contains(searchTermToLower) ||
             x.Offer.Request.CargoType.ToLower().Contains(searchTermToLower) ||
             x.Offer.Request.SpecialInstructions.ToLower().Contains(searchTermToLower) ||
             x.Offer.Request.IsRefrigerated.ToString().ToLower().Contains(searchTermToLower) ||
             x.Offer.Request.SharedTruck.ToString().ToLower().Contains(searchTermToLower) ||
             x.Offer.Request.ClientCompany.Name.ToLower().Contains(searchTermToLower));           
        }

        public async Task<bool> DeliveryWithCompanyExistsAsync(int deliveryId, string username)
        {
            return await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>().AnyAsync(x => x.Id == deliveryId && x.Offer.Request.ClientCompany.User.UserName == username);
        }

        public async Task<DeliveryForClientViewModel?> GetDeliveryDetailsForCompanyAsync(int id)
        {
            var delivery = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>().Where(x => x.Id == id)
               .Include(x => x.Vehicle)
               .Include(x => x.Driver)
               .Include(x => x.Offer)
               .ThenInclude(x => x.Request)
               .ThenInclude(x => x.StandartCargo)
               .Include(x => x.Offer)
               .ThenInclude(x => x.Request)
               .ThenInclude(x => x.ClientCompany)
               .Include(x => x.Offer)
               .ThenInclude(x => x.Request)
               .ThenInclude(x => x.PickupAddress)
               .Include(x => x.Offer)
               .ThenInclude(x => x.Request)
               .ThenInclude(x => x.DeliveryAddress)
               .FirstOrDefaultAsync();

            var model = new DeliveryForClientViewModel
            {
                Id = delivery?.Id ?? throw new DeliveryNotFoundException(),
                CurrentTime = DateTime.Now.ToString("dd-MM-yyyy, HH:mm"),
                RequestId = delivery.Offer.RequestId,
                OfferId = delivery.OfferId,
                CarbonEmission = delivery.CarbonEmission,
                HasRated = await repository.AllReadonly<Rating>().AnyAsync(x => x.DeliveryId == delivery.Id),
                ApproximatePrice = delivery.Offer.Request.ApproximatePrice.ToString(),
                FinalPrice = delivery.Offer.FinalPrice.ToString(),
                OfferDate = delivery.Offer.OfferDate.ToString("dd-MM-yyyy"),
                ActualDeliveryDate = delivery.ActualDeliveryDate.GetValueOrDefault().ToString("dd-MM-yyyy"),
                CargoType = delivery.Offer.Request.CargoType,
                TypeOfPallet = delivery.Offer.Request.StandartCargo?.TypeOfPallet.ToString() ?? "0",
                NumberOfPallets = delivery.Offer.Request.StandartCargo?.NumberOfPallets.ToString() ?? "0",
                PalletLength = delivery.Offer.Request.StandartCargo?.PalletLength.ToString() ?? "0",
                PalletWidth = delivery.Offer.Request.StandartCargo?.PalletWidth.ToString() ?? "0",
                PalletHeight = delivery.Offer.Request.StandartCargo?.PalletHeight.ToString() ?? "0",
                PalletVolume = delivery.Offer.Request.StandartCargo?.PalletVolume.ToString() ?? "0",
                WeightOfPallets = delivery.Offer.Request.StandartCargo?.WeightOfPallets.ToString() ?? "0",
                PalletsAreStackable = delivery.Offer.Request.StandartCargo?.PalletsAreStackable == true ? "Yes" : "No",
                NumberOfNonStandartGoods = delivery.Offer.Request.NumberOfNonStandartGoods.ToString() ?? "0",
                TypeOfGoods = delivery.Offer.Request.TypeOfGoods,
                PickupAddress = $"{delivery.Offer.Request.PickupAddress.Street}, {delivery.Offer.Request.PickupAddress.City}, {delivery.Offer.Request.PickupAddress.County}",
                DeliveryAddress = $"{delivery.Offer.Request.DeliveryAddress.Street}, {delivery.Offer.Request.DeliveryAddress.City}, {delivery.Offer.Request.DeliveryAddress.County}",
                PickupLatitude = delivery.Offer.Request.PickupAddress.Latitude.ToString(),
                PickupCity = delivery.Offer.Request.PickupAddress.City,
                PickupCountry = delivery.Offer.Request.PickupAddress.County,
                PickupStreet = delivery.Offer.Request.PickupAddress.Street,
                PickupLongitude = delivery.Offer.Request.PickupAddress.Longitude.ToString(),
                DeliveryCity = delivery.Offer.Request.DeliveryAddress.City,
                DeliveryCountry = delivery.Offer.Request.DeliveryAddress.County,
                DeliveryStreet = delivery.Offer.Request.DeliveryAddress.Street,
                DeliveryLatitude = delivery.Offer.Request.DeliveryAddress.Latitude.ToString(),
                DeliveryLongitude = delivery.Offer.Request.DeliveryAddress.Longitude.ToString(),
                SharedTruck = delivery.Offer.Request.SharedTruck == true ? "Yes" : "No",
                ExpectedDeliveryDate = delivery.Offer.Request.ExpectedDeliveryDate.ToString("dd-MM-yyyy"),
                SpecialInstructions = delivery.Offer.Request.SpecialInstructions,
                IsRefrigerated = delivery.Offer.Request.IsRefrigerated == true ? "Yes" : "No",
                ReferenceNumber = delivery.ReferenceNumber,
                RegistrationNumber = delivery.Vehicle.RegistrationNumber,
                VehicleType = delivery.Vehicle.VehicleType,
                DeliveryStep = delivery.DeliveryStep,
            };

            model.DeliveryTrackings = await GetDeliveryTrackingsForDelivery(id);

            model.NonStandardCargos = await GetNonStandartCargosForDelivery(id);

            model.Invoice = await GetInvoiceForDelivery(id);
            var invoice = await repository.AllReadonly<Invoice>().FirstOrDefaultAsync(x => x.Id == delivery.Id);
            model.DaysTillPayment = invoice.IsPaid ? "0" : (DateTime.Now - delivery.ActualDeliveryDate).GetValueOrDefault().Days.ToString();

            return model;
        }

        private async Task<List<DeliveryTrackingViewModel>> GetDeliveryTrackingsForDelivery(int id)
        {
            return await repository.AllReadonly<Infrastructure.Data.DataModels.DeliveryTracking>().Where(x => x.DeliveryId == id)
                .Select(x => new DeliveryTrackingViewModel
                {
                    Timestamp = x.Timestamp.ToString("dd-MM-yyyy"),
                    StatusUpdate = x.StatusUpdate,
                    Address = x.Address,
                })
                .ToListAsync();
        }

        public async Task LeaveRatingForDeliveryAsync(int id, string? comment, int ratingStars)
        {
            var delivery = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>().Where(x => x.Id == id).FirstOrDefaultAsync();
            var rating = new Rating
            {
                DeliveryId = delivery.Id,
                Comment = comment,
                RatingStars = ratingStars
            };
            await repository.AddAsync(rating);

            var logisticsUser = await repository.AllReadonly<IdentityUser>().FirstOrDefaultAsync(x => x.UserName == "logistics");
            var notification = new Notification
            {
                Title = "Rating",
                Message = $"You have received a rating for delivery with reference number {delivery.ReferenceNumber}  - {rating.RatingStars} / 5.",
                UserId = logisticsUser.Id,
                Date = DateTime.Now,
                IsRead = false
            };
            var notificationForCompany = new Notification
            {
                Title = "Rating",
                Message = $"You have left a rating for delivery with reference number {delivery.ReferenceNumber} - {rating.RatingStars} / 5.",
                UserId = delivery.Offer.Request.ClientCompany.UserId,
                Date = DateTime.Now,
                IsRead = false
            };

            await repository.AddAsync(notification);
            await repository.AddAsync(notificationForCompany);
            await repository.SaveChangesAsync();
        }

        public async Task<List<DeliveryForClientsDeliveriesViewModel>?> GetDeliveriesForClientAsync(string username, string? referenceNumber = null, DateTime? endDate = null, DateTime? startDate = null, decimal? minPrice = null, decimal? maxPrice = null, bool? isDelivered = null, bool? isPaid = null)
        {
            var deliveries = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>()
                .Include(x => x.Vehicle)
                .Include(x => x.Driver)
                .Include(x => x.Offer)
                .ThenInclude(x => x.Request)
                .ThenInclude(x => x.ClientCompany)
                .Include(x => x.Offer)
                .ThenInclude(x => x.Request)
                .ThenInclude(x => x.PickupAddress)
                .Include(x => x.Offer)
                .ThenInclude(x => x.Request)
                .ThenInclude(x => x.DeliveryAddress)
                .Include(x => x.Invoice)
                .Where(x => x.Offer.Request.ClientCompany.User.UserName == username)
                .ToListAsync();
            if (isDelivered != null)
            {
                deliveries = deliveries.Where(x => x.DeliveryStep == 4).ToList();
            }
            if (isPaid != null)
            {
                deliveries = deliveries.Where(x => x.Invoice.IsPaid == true).ToList();
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
            if (minPrice != null)
            {
                deliveries = deliveries.Where(x => x.Offer.FinalPrice >= minPrice).ToList();
            }
            if (maxPrice != null)
            {
                deliveries = deliveries.Where(x => x.Offer.FinalPrice <= maxPrice).ToList();
            }
            var model = deliveries.Select(x => new DeliveryForClientsDeliveriesViewModel()
            {
                Id = x.Id,
                ReferenceNumber = x.ReferenceNumber,
                DeliveryAddress = $"{x.Offer.Request.DeliveryAddress.Street}, {x.Offer.Request.DeliveryAddress.City}, {x.Offer.Request.DeliveryAddress.County}",
                PickupAddress = $"{x.Offer.Request.PickupAddress.Street}, {x.Offer.Request.PickupAddress.City}, {x.Offer.Request.PickupAddress.County}",
                ExpectedDeliveryDate = x.Offer.Request.ExpectedDeliveryDate.ToString("dd-MM-yyyy"),
                FinalPrice = x.Offer.FinalPrice.ToString(),
                IsPaid = x.Invoice.IsPaid,
                IsDelivered = x.DeliveryStep == 4 ? true : false,
                TotalWeight = x.Offer.Request.TotalWeight.ToString(),
                TotalVolume = x.Offer.Request.TotalVolume.ToString(),
                TotalItems = (x.Offer.Request.StandartCargo?.NumberOfPallets ?? 0) + (x.Offer.Request.NumberOfNonStandartGoods ?? 0).ToString(),
                ActualDeliveryDate = x.ActualDeliveryDate.GetValueOrDefault().ToString("dd-MM-yyyy")
            }).ToList();
            return model;
        }

        public async Task<List<DeliveryForClientsDeliveriesViewModel>?> GetDeliveriesForClientBySearchtermAsync(string username, string? searchTerm)
        {
            var deliveries = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>()
                .Include(x => x.Vehicle)
                .Include(x => x.Driver)
                .Include(x => x.Offer)
                .ThenInclude(x => x.Request)
                .ThenInclude(x => x.ClientCompany)
                .Include(x => x.Offer)
                .ThenInclude(x => x.Request)
                .ThenInclude(x => x.PickupAddress)
                .Include(x => x.Offer)
                .ThenInclude(x => x.Request)
                .ThenInclude(x => x.DeliveryAddress)
                .Include(x => x.Invoice)
                .Where(x => x.Offer.Request.ClientCompany.User.UserName == username)
                .ToListAsync();
            if (string.IsNullOrEmpty(searchTerm) == false)
            {
                deliveries = deliveries
                     .Where(x =>
         x.Offer.Request.DeliveryAddress.City.ToLower().Contains(searchTerm.ToLower()) ||
         x.Offer.Request.DeliveryAddress.County.ToLower().Contains(searchTerm.ToLower()) ||
         x.Offer.Request.DeliveryAddress.Street.ToLower().Contains(searchTerm.ToLower()) ||
         x.Offer.Request.PickupAddress.City.ToLower().Contains(searchTerm.ToLower()) ||
         x.Offer.Request.PickupAddress.County.ToLower().Contains(searchTerm.ToLower()) ||
         x.Offer.Request.PickupAddress.Street.ToLower().Contains(searchTerm.ToLower()) ||
         x.ReferenceNumber.ToLower().Contains(searchTerm.ToLower()) ||
         (decimal.TryParse(searchTerm, out decimal finalPrice) && x.Offer.FinalPrice == finalPrice) ||
         x.Offer.Request.ExpectedDeliveryDate.ToString("dd-MM-yyyy").Contains(searchTerm) ||
         x.Offer.Request.TotalWeight.ToString().Contains(searchTerm) ||
         x.Offer.Request.TotalVolume.ToString().Contains(searchTerm) ||
         x.Offer.Request.NumberOfNonStandartGoods.ToString().Contains(searchTerm) ||
         x.Offer.Request.StandartCargo.NumberOfPallets.ToString().Contains(searchTerm) ||
         x.Offer.Request.TypeOfGoods.ToLower().Contains(searchTerm.ToLower()) ||
         x.Offer.Request.CargoType.ToLower().Contains(searchTerm.ToLower()) ||
         x.Offer.Request.SpecialInstructions.ToLower().Contains(searchTerm.ToLower()) ||
         x.Offer.Request.IsRefrigerated.ToString().ToLower().Contains(searchTerm.ToLower()) ||
         x.Offer.Request.SharedTruck.ToString().ToLower().Contains(searchTerm.ToLower()) ||
         x.Offer.Request.ClientCompany.Name.ToLower().Contains(searchTerm.ToLower())
     )
     .ToList();
                return deliveries.Select(x => new DeliveryForClientsDeliveriesViewModel()
                {
                    Id = x.Id,
                    ReferenceNumber = x.ReferenceNumber,
                    DeliveryAddress = $"{x.Offer.Request.DeliveryAddress.Street}, {x.Offer.Request.DeliveryAddress.City}, {x.Offer.Request.DeliveryAddress.County}",
                    PickupAddress = $"{x.Offer.Request.PickupAddress.Street}, {x.Offer.Request.PickupAddress.City}, {x.Offer.Request.PickupAddress.County}",
                    ExpectedDeliveryDate = x.Offer.Request.ExpectedDeliveryDate.ToString("dd-MM-yyyy"),
                    FinalPrice = x.Offer.FinalPrice.ToString(),
                    IsPaid = x.Invoice.IsPaid,
                    IsDelivered = x.DeliveryStep == 4 ? true : false,
                    TotalWeight = x.Offer.Request.TotalWeight.ToString(),
                    TotalVolume = x.Offer.Request.TotalVolume.ToString(),
                    TotalItems = (x.Offer.Request.StandartCargo?.NumberOfPallets ?? 0) + (x.Offer.Request.NumberOfNonStandartGoods ?? 0).ToString(),
                    ActualDeliveryDate = x.ActualDeliveryDate.GetValueOrDefault().ToString("dd-MM-yyyy")
                }).ToList();
            }

            return new List<DeliveryForClientsDeliveriesViewModel>();
        }

        public async Task<DelliveryDetailsForLogisticsViewModel?> GetDeliveryDetailsForLogisticsAsync(int id)
        {
            var delivery = await repository.AllReadonly<Delivery>().FirstOrDefaultAsync(x => x.Id == id);
            delivery = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>().Where(x => x.Id == id)
               .Include(x => x.Vehicle)
               .Include(x => x.Driver)
               .Include(x => x.Offer)
               .ThenInclude(x => x.Request)
               .ThenInclude(x => x.ClientCompany)
               .ThenInclude(x => x.User)
               .Include(x => x.Offer)
               .ThenInclude(x => x.Request)
               .ThenInclude(x => x.ClientCompany)
               .ThenInclude(x => x.Address)
               .Include(x => x.Offer)
               .ThenInclude(x => x.Request)
               .ThenInclude(x => x.PickupAddress)
               .Include(x => x.Offer)
               .ThenInclude(x => x.Request)
               .ThenInclude(x => x.DeliveryAddress)

               .FirstOrDefaultAsync();
            var model = new DelliveryDetailsForLogisticsViewModel
            {
                Id = delivery.Id,
                ClientId = delivery.Offer.Request.ClientCompanyId,
                DriverId = delivery.DriverId,
                VehicleId = delivery.VehicleId,
                ClientCompanyName = delivery.Offer.Request.ClientCompany.Name,
                ClientAddress = $"{delivery.Offer.Request.ClientCompany.Address.City}, {delivery.Offer.Request.ClientCompany.Address.City}, {delivery.Offer.Request.ClientCompany.Address.Street}, {delivery.Offer.Request.ClientCompany.Address.PostalCode} ",
                ClientEmail = delivery.Offer.Request.ClientCompany.User.Email,
                ClientPhone = delivery.Offer.Request.ClientCompany.User.PhoneNumber,
                CurrentTime = DateTime.Now.ToString("dd-MM-yyyy, HH:mm"),
                Age = delivery.Driver.Age.ToString(),
                Name = delivery.Driver.Name,
                Salary = delivery.Driver.Salary.ToString(),
                YearOfExperience = delivery.Driver.YearOfExperience.ToString(),
                MonthsOfExperience = delivery.Driver.MonthsOfExperience.ToString(),
                LicenseNumber = delivery.Driver.LicenseNumber,
                RequestId = delivery.Offer.RequestId,
                OfferId = delivery.OfferId,
                CarbonEmission = delivery.CarbonEmission,
                HasRated = await repository.AllReadonly<Rating>().AnyAsync(x => x.DeliveryId == delivery.Id),
                ApproximatePrice = delivery.Offer.Request.ApproximatePrice.ToString(),
                FinalPrice = delivery.Offer.FinalPrice.ToString(),
                OfferDate = delivery.Offer.OfferDate.ToString("dd-MM-yyyy"),
                ActualDeliveryDate = delivery.ActualDeliveryDate.GetValueOrDefault().ToString("dd-MM-yyyy"),
                CargoType = delivery.Offer.Request.CargoType,
                TypeOfPallet = delivery.Offer.Request.StandartCargo?.TypeOfPallet.ToString() ?? "0",
                NumberOfPallets = delivery.Offer.Request.StandartCargo?.NumberOfPallets.ToString() ?? "0",
                PalletLength = delivery.Offer.Request.StandartCargo?.PalletLength.ToString() ?? "0",
                PalletWidth = delivery.Offer.Request.StandartCargo?.PalletWidth.ToString() ?? "0",
                PalletHeight = delivery.Offer.Request.StandartCargo?.PalletHeight.ToString() ?? "0",
                PalletVolume = delivery.Offer.Request.StandartCargo?.PalletVolume.ToString() ?? "0",
                WeightOfPallets = delivery.Offer.Request.StandartCargo?.WeightOfPallets.ToString() ?? "0",
                PalletsAreStackable = delivery.Offer.Request.StandartCargo?.PalletsAreStackable == true ? "Yes" : "No",
                NumberOfNonStandartGoods = delivery.Offer.Request.NumberOfNonStandartGoods.ToString() ?? "0",
                TypeOfGoods = delivery.Offer.Request.TypeOfGoods,
                PickupAddress = $"{delivery.Offer.Request.PickupAddress.Street}, {delivery.Offer.Request.PickupAddress.City}, {delivery.Offer.Request.PickupAddress.County}",
                DeliveryAddress = $"{delivery.Offer.Request.DeliveryAddress.Street}, {delivery.Offer.Request.DeliveryAddress.City}, {delivery.Offer.Request.DeliveryAddress.County}",
                PickupLatitude = delivery.Offer.Request.PickupAddress.Latitude.ToString(),
                PickupCity = delivery.Offer.Request.PickupAddress.City,
                PickupCountry = delivery.Offer.Request.PickupAddress.County,
                PickupStreet = delivery.Offer.Request.PickupAddress.Street,
                PickupLongitude = delivery.Offer.Request.PickupAddress.Longitude.ToString(),
                DeliveryCity = delivery.Offer.Request.DeliveryAddress.City,
                DeliveryCountry = delivery.Offer.Request.DeliveryAddress.County,
                DeliveryStreet = delivery.Offer.Request.DeliveryAddress.Street,
                DeliveryLatitude = delivery.Offer.Request.DeliveryAddress.Latitude.ToString(),
                DeliveryLongitude = delivery.Offer.Request.DeliveryAddress.Longitude.ToString(),
                SharedTruck = delivery.Offer.Request.SharedTruck == true ? "Yes" : "No",
                ExpectedDeliveryDate = delivery.Offer.Request.ExpectedDeliveryDate.ToString("dd-MM-yyyy"),
                SpecialInstructions = delivery.Offer.Request.SpecialInstructions,
                IsRefrigerated = delivery.Offer.Request.IsRefrigerated == true ? "Yes" : "No",
                ReferenceNumber = delivery.ReferenceNumber,
                DeliveryStep = delivery.DeliveryStep,
                RegistrationNumber = delivery.Vehicle.RegistrationNumber,
                VehicleType = delivery.Vehicle.VehicleType,
                VehicleHeight = delivery.Vehicle.Height.ToString(),
                VehicleLength = delivery.Vehicle.Length.ToString(),
                VehicleWidth = delivery.Vehicle.Width.ToString(),
                VehicleWeightCapacity = delivery.Vehicle.MaxWeightCapacity.ToString(),
                FuelConsumptionPer100Km = delivery.Vehicle.FuelConsumptionPer100Km.ToString(),
            };
            var rating = await repository.AllReadonly<Rating>().Where(x => x.DeliveryId == delivery.Id).FirstOrDefaultAsync();
            if (rating != null)
            {
                model.RatingStars = rating.RatingStars;
                model.Comment = rating.Comment;
            }
            model.DeliveryTrackings = await repository.AllReadonly<Infrastructure.Data.DataModels.DeliveryTracking>().Where(x => x.DeliveryId == id)
                .Select(x => new DeliveryTrackingViewModel
                {
                    Timestamp = x.Timestamp.ToString("dd-MM-yyyy"),
                    StatusUpdate = x.StatusUpdate,
                    Address = x.Address,
                })
                .ToListAsync();
            var cashRegisters = await repository.AllReadonly<Infrastructure.Data.DataModels.CashRegister>().Where(x => x.DeliveryId == delivery.Id)
                .Select(x => new CashRegisterIndexViewModel()
                {
                    Id = x.Id,
                    DeliveryId = x.DeliveryId,
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

            model.NonStandardCargos = await GetNonStandartCargosForDelivery(id);

            model.Invoice = await GetInvoiceForDelivery(id);

            return model;
        }

        public async Task<List<DeliveryForClientsDeliveriesViewModel>> GetDeliveriesForLogisticsBySearchtermAsync(string? searchTerm = null)
        {
            var deliveries = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>()
               .Include(x => x.Vehicle)
               .Include(x => x.Driver)
               .Include(x => x.Offer)
               .ThenInclude(x => x.Request)
               .ThenInclude(x => x.ClientCompany)
               .Include(x => x.Offer)
               .ThenInclude(x => x.Request)
               .ThenInclude(x => x.PickupAddress)
               .Include(x => x.Offer)
               .ThenInclude(x => x.Request)
               .ThenInclude(x => x.DeliveryAddress)
               .Include(x => x.Invoice)
               .ToListAsync();
            if (string.IsNullOrEmpty(searchTerm) == false)
            {
                deliveries = deliveries
                     .Where(x =>
         x.Offer.Request.DeliveryAddress.City.ToLower().Contains(searchTerm.ToLower()) ||
         x.Offer.Request.DeliveryAddress.County.ToLower().Contains(searchTerm.ToLower()) ||
         x.Offer.Request.DeliveryAddress.Street.ToLower().Contains(searchTerm.ToLower()) ||
         x.Offer.Request.PickupAddress.City.ToLower().Contains(searchTerm.ToLower()) ||
         x.Offer.Request.PickupAddress.County.ToLower().Contains(searchTerm.ToLower()) ||
         x.Offer.Request.PickupAddress.Street.ToLower().Contains(searchTerm.ToLower()) ||
         x.ReferenceNumber.ToLower().Contains(searchTerm.ToLower()) ||
         (decimal.TryParse(searchTerm, out decimal finalPrice) && x.Offer.FinalPrice == finalPrice) ||
         x.Offer.Request.ExpectedDeliveryDate.ToString("dd-MM-yyyy").Contains(searchTerm) ||
         x.Offer.Request.TotalWeight.ToString().Contains(searchTerm) ||
         x.Offer.Request.TotalVolume.ToString().Contains(searchTerm) ||
         x.Offer.Request.NumberOfNonStandartGoods.ToString().Contains(searchTerm) ||
         x.Offer.Request.StandartCargo.NumberOfPallets.ToString().Contains(searchTerm) ||
         x.Offer.Request.TypeOfGoods.ToLower().Contains(searchTerm.ToLower()) ||
         x.Offer.Request.CargoType.ToLower().Contains(searchTerm.ToLower()) ||
         x.Offer.Request.SpecialInstructions.ToLower().Contains(searchTerm.ToLower()) ||
         x.Offer.Request.IsRefrigerated.ToString().ToLower().Contains(searchTerm.ToLower()) ||
         x.Offer.Request.SharedTruck.ToString().ToLower().Contains(searchTerm.ToLower()) ||
         x.Offer.Request.ClientCompany.Name.ToLower().Contains(searchTerm.ToLower())
     )
     .ToList();
                return deliveries.Select(x => new DeliveryForClientsDeliveriesViewModel()
                {
                    Id = x.Id,
                    ReferenceNumber = x.ReferenceNumber,
                    DeliveryAddress = $"{x.Offer.Request.DeliveryAddress.Street}, {x.Offer.Request.DeliveryAddress.City}, {x.Offer.Request.DeliveryAddress.County}",
                    PickupAddress = $"{x.Offer.Request.PickupAddress.Street}, {x.Offer.Request.PickupAddress.City}, {x.Offer.Request.PickupAddress.County}",
                    ExpectedDeliveryDate = x.Offer.Request.ExpectedDeliveryDate.ToString("dd-MM-yyyy"),
                    FinalPrice = x.Offer.FinalPrice.ToString(),
                    IsPaid = x.Invoice.IsPaid,
                    IsDelivered = x.DeliveryStep == 4 ? true : false,
                    TotalWeight = x.Offer.Request.TotalWeight.ToString(),
                    TotalVolume = x.Offer.Request.TotalVolume.ToString(),
                    TotalItems = (x.Offer.Request.StandartCargo?.NumberOfPallets ?? 0) + (x.Offer.Request.NumberOfNonStandartGoods ?? 0).ToString(),
                    ActualDeliveryDate = x.ActualDeliveryDate.GetValueOrDefault().ToString("dd-MM-yyyy")
                }).ToList();
            }
            
            return new List<DeliveryForClientsDeliveriesViewModel>();
        }

        public async Task<List<DeliveryForClientsDeliveriesViewModel>> GetDeliveriesForLogisticsAsync(bool isDelivered, bool isPaid, string? referenceNumber = null, DateTime? endDate = null, DateTime? startDate = null, decimal? minPrice = null, decimal? maxPrice = null, string? pickupAddress = null, string? deliveryAddress = null)
        {
            var deliveries = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>()
                .Include(x => x.Vehicle)
                .Include(x => x.Driver)
                .Include(x => x.Offer)
                .ThenInclude(x => x.Request)
                .ThenInclude(x => x.ClientCompany)
                .Include(x => x.Offer)
                .ThenInclude(x => x.Request)
                .ThenInclude(x => x.PickupAddress)
                .Include(x => x.Offer)
                .ThenInclude(x => x.Request)
                .ThenInclude(x => x.DeliveryAddress)
                .Include(x => x.Invoice)
                .ToListAsync();
            if (isDelivered)
            {
                deliveries = deliveries.Where(x => x.DeliveryStep == 4).ToList();
            }
            if (isPaid)
            {
                deliveries = deliveries.Where(x => x.Invoice.IsPaid == true).ToList();
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
            if (minPrice != null)
            {
                deliveries = deliveries.Where(x => x.Offer.FinalPrice >= minPrice).ToList();
            }
            if (maxPrice != null)
            {
                deliveries = deliveries.Where(x => x.Offer.FinalPrice <= maxPrice).ToList();
            }
            if (string.IsNullOrEmpty(pickupAddress) == false)
            {
                deliveries = deliveries.Where(x => x.Offer.Request.PickupAddress.City.ToLower().Contains(pickupAddress.ToLower()) || x.Offer.Request.PickupAddress.County.ToLower().Contains(pickupAddress.ToLower()) || x.Offer.Request.PickupAddress.Street.ToLower().Contains(pickupAddress.ToLower())).ToList();
            }
            if (string.IsNullOrEmpty(deliveryAddress) == false)
            {
                deliveries = deliveries.Where(x => x.Offer.Request.DeliveryAddress.City.ToLower().Contains(deliveryAddress.ToLower()) || x.Offer.Request.DeliveryAddress.County.ToLower().Contains(deliveryAddress.ToLower()) || x.Offer.Request.DeliveryAddress.Street.ToLower().Contains(deliveryAddress.ToLower())).ToList();
            }
            var model = deliveries.Select(x => new DeliveryForClientsDeliveriesViewModel()
            {
                Id = x.Id,
                ReferenceNumber = x.ReferenceNumber,
                DeliveryAddress = $"{x.Offer.Request.DeliveryAddress.Street}, {x.Offer.Request.DeliveryAddress.City}, {x.Offer.Request.DeliveryAddress.County}",
                PickupAddress = $"{x.Offer.Request.PickupAddress.Street}, {x.Offer.Request.PickupAddress.City}, {x.Offer.Request.PickupAddress.County}",
                ExpectedDeliveryDate = x.Offer.Request.ExpectedDeliveryDate.ToString("dd-MM-yyyy"),
                FinalPrice = x.Offer.FinalPrice.ToString(),
                IsPaid = x.Invoice.IsPaid,
                IsDelivered = x.DeliveryStep == 4 ? true : false,
                TotalWeight = x.Offer.Request.TotalWeight.ToString(),
                TotalVolume = x.Offer.Request.TotalVolume.ToString(),
                TotalItems = (x.Offer.Request.StandartCargo?.NumberOfPallets ?? 0) + (x.Offer.Request.NumberOfNonStandartGoods ?? 0).ToString(),
                ActualDeliveryDate = x.ActualDeliveryDate.GetValueOrDefault().ToString("dd-MM-yyyy")
            }).ToList();
            return model;
        }

        //ToDo: calculate enddate
        public async Task ReserveDeliveryAsync(int driverId, int vehicleId, int requestId, DateTime startDate)
        {
            var reservedDelivery = new ReservedForDelivery
            {
                DriverId = driverId,
                VehicleId = vehicleId,
                RequestId = requestId,
                Start = startDate,
                End = startDate,
                OfferId = await repository.AllReadonly<Offer>().Where(x => x.RequestId == requestId).Select(x => x.Id).FirstOrDefaultAsync()
            };

            await repository.AddAsync(reservedDelivery);
            await repository.SaveChangesAsync();
        }
    }
}

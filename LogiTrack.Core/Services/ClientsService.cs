using LogisticsSystem.Infrastructure.Data.DataModels;
using LogiTrack.Core.Constants;
using LogiTrack.Core.Contracts;
using LogiTrack.Core.ViewModels.Clients;
using LogiTrack.Core.ViewModels.Delivery;
using LogiTrack.Core.ViewModels.Invoice;
using LogiTrack.Core.ViewModels.Offer;
using LogiTrack.Core.ViewModels.Request;
using LogiTrack.Core.ViewModels.Vehicle;
using LogiTrack.Infrastructure.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace LogiTrack.Core.Services
{
    public class ClientsService : IClientsService
    {
        private readonly IRepository repository;

        public ClientsService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IdentityUser> ApprovePendingRegistrationForCompanyWithIdAsync(int id)
        {
            var company = await repository.All<LogisticsSystem.Infrastructure.Data.DataModels.ClientCompany>().FirstOrDefaultAsync(x => x.Id == id);
            company.RegistrationStatus = StatusConstants.Approved;
            await repository.SaveChangesAsync();
            return await repository.AllReadonly<IdentityUser>().FirstOrDefaultAsync(x => x.Id == company.UserId);
        }

        public async Task<bool> CompanyWithIdExistsAsync(int id)
        {
            return await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.ClientCompany>().AnyAsync(x => x.Id == id);
        }

        public async Task<CompanyDetailsViewModel?> GetCompanyDetailsAsync(string username)
        {
            return await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.ClientCompany>()
                 .Include(x => x.Address)
                 .Where(x => x.User.UserName == username)
                 .Select(x => new CompanyDetailsViewModel
                 {
                     Name = x.Name,
                     RegistrationNumber = x.RegistrationNumber,
                     Industry = x.Industry,
                     Street = x.Address.Street,
                     City = x.Address.City,
                     PostalCode = x.Address.PostalCode,
                     Country = x.Address.County,
                     CreatedAt = x.CreatedAt.ToString("dd/MM/yyyy"),
                 })
                 .FirstOrDefaultAsync();
        }
       
        public async Task<List<PendingRegistrationsViewModel>?> GetPendingRegistrationsAsync()
        {
            return await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.ClientCompany>()
                .Where(x => x.RegistrationStatus == StatusConstants.Pending)
                .OrderByDescending(x => x.CreatedAt)
                .Select(x => new PendingRegistrationsViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    RegistrationNumber = x.RegistrationNumber,
                    PhoneNumber = x.User.PhoneNumber,
                    CreatedAt = x.CreatedAt.ToString("dd/MM/yyyy"),
                    Email = x.User.Email
                })
                .ToListAsync();
        }

        public async Task RegisterClientCompanyAsync(RegisterViewModel model, IdentityUser user)
        {
            var client = new LogisticsSystem.Infrastructure.Data.DataModels.ClientCompany
            {
                Name = model.Name,
                /*Street = model.Street,
                City = model.City,
                PostalCode = model.PostalCode,
                Country = model.Country,*/ //TODO
                Industry = model.Industry,
                AlternativePhoneNumber = model.AlternativePhoneNumber,
                RegistrationNumber = model.RegistrationNumber,
                RegistrationStatus = StatusConstants.Pending,
                ContactPerson = model.ContactPerson,
                UserId = user.Id,
                CreatedAt = DateTime.Now,
            };
            await repository.AddAsync(client);
            await repository.SaveChangesAsync();
        }

        public async Task<IdentityUser> RegisterUserAsync(RegisterViewModel model)
        {
            var user = new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber
            };
            await repository.AddAsync(user);
            await repository.SaveChangesAsync();
            return user;
        }

        public async Task RejectPendingRegistrationForCompanyWithIdAsync(int id)
        {
            var company = await repository.All<LogisticsSystem.Infrastructure.Data.DataModels.ClientCompany>().FirstOrDefaultAsync(x => x.Id == id);
            company.RegistrationStatus = StatusConstants.Rejected;
            await repository.SaveChangesAsync();
        }

        public async Task<bool> UserWithEmailExistsAsync(string email)
        {
            return await repository.AllReadonly<IdentityUser>().AnyAsync(x => x.Email == email);
        }

        public async Task<bool> UserWithPhoneNumberExistsAsync(string phoneNumber)
        {
            return await repository.AllReadonly<IdentityUser>().AnyAsync(x => x.PhoneNumber == phoneNumber);
        }

        public async Task<ContactDetailsViewModel?> GetCompanyContactDetailsAsync(string username)
        {
            return await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.ClientCompany>()
                 .Where(x => x.User.UserName == username)
                 .Select(x => new ContactDetailsViewModel
                 {
                     Id = x.Id,
                     Username = x.User.UserName,
                     ContactPerson = x.ContactPerson,
                     AlternativePhoneNumber = x.AlternativePhoneNumber,
                     PhoneNumber = x.User.PhoneNumber,
                     Email = x.User.Email
                 })
                 .FirstOrDefaultAsync();
        }

        public async Task<ClientsDashboardViewModel?> GetClientCompanyDashboardAsync(string username)
        {
            var company = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.ClientCompany>().FirstOrDefaultAsync(x => x.User.UserName == username);
            var offers = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Offer>().Where(x => x.Request.ClientCompanyId == company.Id && x.OfferStatus == StatusConstants.Pending).Take(5)
                .Select(x => new OfferForDashboardViewModel
                {
                    Id = x.Id,
                    PickupAddress = $"{x.Request.PickupAddress.Street}, {x.Request.PickupAddress.City}, {x.Request.PickupAddress.County}",
                    DeliveryAddress = $"{x.Request.DeliveryAddress.Street}, {x.Request.DeliveryAddress.City}, {x.Request.DeliveryAddress.County}",
                    Price = x.FinalPrice.ToString(),
                }).ToListAsync();
            var invoices = await repository.AllReadonly<Invoice>().Where(x => x.Delivery.Offer.Request.ClientCompanyId == company.Id).Take(5)
                 .Select(x => new InvoiceForDashboardViewModel
                 {
                   Id = x.Id,
                   Date = DateTime.Now.ToString("dd-MM-yyyy"),
                   InvoiceNumber = x.InvoiceNumber,
                   Amount = x.Delivery.Offer.FinalPrice.ToString(),
                   CreationDate = x.InvoiceDate.ToString("dd-MM-yyyy"),
                   IsPaid = x.IsPaid
                 })
                .ToListAsync();

            var deliveries = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>().Where(x => x.Offer.Request.ClientCompanyId == company.Id).Take(5)
                .Select(x => new DeliveryTrackingForDashboardViewModel
                {
                    Id = x.Id,
                   ReferenceNumber = x.ReferenceNumber,
                   DeliveryStep = x.DeliveryStep,
                    PickupAddress = $"{x.Offer.Request.PickupAddress.Street}, {x.Offer.Request.PickupAddress.City}, {x.Offer.Request.PickupAddress.County}",
                    DeliveryAddress = $"{x.Offer.Request.DeliveryAddress.Street}, {x.Offer.Request.DeliveryAddress.City}, {x.Offer.Request.DeliveryAddress.County}",
                   StatusUpdate = x.Status,
                }).ToListAsync();
            var model = new ClientsDashboardViewModel
            {
                LastFivePendingOffers = offers,
                LastFiveDeliveries = deliveries,
                LastFiveInvoices = invoices,
                DueAmountForDeliveries =  await repository.AllReadonly<Invoice>().Where(x => x.Delivery.Offer.Request.ClientCompanyId == company.Id && x.IsPaid == false).SumAsync(x => x.Delivery.Offer.Request.CalculatedPrice),
                RequestsCount = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Request>().Where(x => x.ClientCompanyId == company.Id).CountAsync(),
                RequestsLastMonthCount = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Request>().Where(x => x.ClientCompanyId == company.Id && x.CreatedAt.Month == DateTime.Now.Month - 1).CountAsync(),
                BookedOffersCount = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Offer>().Where(x => x.Request.ClientCompanyId == company.Id && x.OfferStatus == StatusConstants.Approved).CountAsync(),
                BookedOffersLastMonthCount = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Offer>().Where(x => x.Request.ClientCompanyId == company.Id && x.OfferStatus == StatusConstants.Approved && x.OfferDate.Month == DateTime.Now.Month - 1).CountAsync(),
                InvoicesCount = await repository.AllReadonly<Invoice>().Where(x => x.Delivery.Offer.Request.ClientCompanyId == company.Id).CountAsync(),
                InvoiceLastMonthCount = await repository.AllReadonly<Invoice>().Where(x => x.Delivery.Offer.Request.ClientCompanyId == company.Id && x.InvoiceDate.Month == DateTime.Now.Month - 1).CountAsync(),
                DomesticDeliveriesCount = await repository.AllReadonly<LogiTrack.Infrastructure.Data.DataModels.Delivery>().Where(x => x.Offer.Request.ClientCompanyId == company.Id && x.Offer.Request.Type == RequestTypeConstants.Domestic).CountAsync(),
                InternationalDeliveriesCount = await repository.AllReadonly<LogiTrack.Infrastructure.Data.DataModels.Delivery>().Where(x => x.Offer.Request.ClientCompanyId == company.Id && x.Offer.Request.Type == RequestTypeConstants.International).CountAsync(),
            };
            return model;
        }

        public async Task<List<CalendarEventViewModel>?> GetClientCompanyEventsAsync(string username)
        {
            return await repository.AllReadonly<LogiTrack.Infrastructure.Data.DataModels.CalendarEvent>().Where(x => x.ClientCompany.User.UserName == username)
                .Select(x => new CalendarEventViewModel()
                {
                    Id = x.Id,
                    Date = x.Date,
                    Title = x.Title,
                    Type = x.EventType,
                }).ToListAsync();
        }

        public async Task<RequestViewModel?> GetRequestDetailsAsync(int id)
        {
            var model = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Request>().Where(x => x.Id == id)
                .Select(x => new RequestViewModel
                {
                    Id = x.Id,
                    CargoType = x.CargoType,
                    NumberOfNonStandartGoods = x.NumberOfNonStandartGoods.ToString(),
                    TypeOfGoods = x.TypeOfGoods,
                    PickupAddress = $"{x.PickupAddress.Street}, {x.PickupAddress.City}, {x.PickupAddress.County}",
                    DeliveryAddress = $"{x.DeliveryAddress.Street}, {x.DeliveryAddress.City}, {x.DeliveryAddress.County}",
                    SharedTruck = x.SharedTruck,
                    ApproximatePrice = x.ApproximatePrice.ToString(),
                    ExpectedDeliveryDate = x.ExpectedDeliveryDate.ToString("dd-MM-yyyy"),
                    Status = x.Status,
                    SpecialInstructions = x.SpecialInstructions,
                    IsRefrigerated = x.IsRefrigerated,
                    CreatedAt = x.CreatedAt.ToString("dd/MM/yyyy"),
                    Kilometers = x.Kilometers.ToString(),
                    TotalWeight = x.TotalWeight.ToString(),
                    TotalVolume = x.TotalVolume.ToString(),
                    PalletsCount = x.StandartCargo != null ? x.StandartCargo.NumberOfPallets.ToString() : string.Empty,
                    PalletsLength = x.StandartCargo != null ? x.StandartCargo.PalletLength.ToString() : string.Empty,
                    PalletsHeight = x.StandartCargo != null ? x.StandartCargo.PalletHeight.ToString() : string.Empty,
                    PalletsWidth = x.StandartCargo != null ? x.StandartCargo.PalletWidth.ToString() : string.Empty,
                    
                }).FirstOrDefaultAsync();
            var nonStandardCargos = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Request>().Where(x => x.Id == id).SelectMany(x => x.NonStandardCargos).ToListAsync();
            foreach (var item in nonStandardCargos)
            {
                var nonStandardCargo = new NonStandardCargoRequestViewModel
                {
                    Length = item.Length.ToString(),
                    Width = item.Width.ToString(),
                    Height = item.Height.ToString(),
                    Weight = item.Weight
                };
                model.NonStandardCargo.Add(nonStandardCargo);
            }
            return model;
        }

        public async Task<bool> LogisticsUserWithUsernameExistsAsync(string username)
        {
            return await repository.AllReadonly<IdentityUser>().AnyAsync(x => x.UserName == username);
        }

        public Task<string?> GetLogisticsCompanyDashboardAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<NewCompanyDetailsForLogisticsViewModel?> GetNewCompanyDetailsForLogisticsAsync(int id)
        {
            return await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.ClientCompany>()
                .Include(x => x.Address)
                .Where(x => x.Id == id)
                .Select(x => new NewCompanyDetailsForLogisticsViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    RegistrationNumber = x.RegistrationNumber,
                    Email = x.User.Email,
                    AlternativePhoneNumber = x.AlternativePhoneNumber,
                    ContactPerson = x.ContactPerson,
                    PhoneNumber = x.User.PhoneNumber,
                    Industry = x.Industry,
                    Street = x.Address.Street,
                    City = x.Address.City,
                    PostalCode = x.Address.PostalCode,
                    Country = x.Address.County,
                    CreatedAt = x.CreatedAt.ToString("dd/MM/yyyy"),
                })
                .FirstOrDefaultAsync();
        }

        public async Task<List<ClientsForClientregisterViewModel>> GetClientsForClientsRegisterAsync(bool? active, string? name, string? email, string? registrationNumber)
        {
            var clients = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.ClientCompany>()
                .Include(x => x.Address).Include(x => x.User).ToListAsync();
            if (active != null)
            {
                var deliveriesForClientsIds = await repository.AllReadonly<LogiTrack.Infrastructure.Data.DataModels.Delivery>().OrderByDescending(x => x.Offer.FinalPrice).Select(x => x.Offer.Request.ClientCompanyId).Take(10).ToListAsync();
                clients = clients.Where(x => deliveriesForClientsIds.Contains(x.Id)).ToList();
            }
            if (string.IsNullOrEmpty(name) == false)
            {
                clients = clients.Where(x => x.Name.ToLower().Contains(name.ToLower())).ToList();
            }
            if (string.IsNullOrEmpty(email) == false)
            {
                clients = clients.Where(x => x.User.Email.ToLower().Contains(email.ToLower())).ToList();
            }
            if (string.IsNullOrEmpty(registrationNumber) == false)
            {
                clients = clients.Where(x => x.RegistrationNumber.ToLower().Contains(registrationNumber.ToLower())).ToList();
            }
            return clients.Select(x => new ClientsForClientregisterViewModel
            {
                Id = x.Id,
                Name = x.Name,
                 RegisterNumber= x.RegistrationNumber,
                 Address = $"{x.Address.Street}, {x.Address.City}, {x.Address.County}",
                Email = x.User.Email,
                Phone = x.User != null ? x.User.PhoneNumber : "No Phone Number"
            }).ToList();
        }

        public async Task<List<ClientsForClientregisterViewModel>> GetClientsForClientsRegisterBySearchTermAsync(string? searchTerm)
        {
            var clients = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.ClientCompany>().Include(x => x.Address).Include(x => x.User).ToListAsync();

            if (string.IsNullOrEmpty(searchTerm) == false)
            {
                clients = clients.Where(x => x.RegistrationNumber.ToLower().Contains(searchTerm.ToLower())
                || x.Name.ToLower().Contains(searchTerm.ToLower())
                || x.Address.City.ToLower().Contains(searchTerm.ToLower())
                || x.Address.County.ToLower().Contains(searchTerm.ToLower())
                || x.Address.Street.ToLower().Contains(searchTerm.ToLower())
                || x.Address.PostalCode.ToLower().Contains(searchTerm.ToLower())).ToList();
            }
            //TODO
            return clients.Select(x => new ClientsForClientregisterViewModel
            {
                Id = x.Id,
                Name = x.Name,
                RegisterNumber = x.RegistrationNumber,
                Address = $"{x.Address.Street}, {x.Address.City}, {x.Address.County}",
                //Email = x.User.Email,
                //Phone = x.User != null ? x.User.PhoneNumber : "No Phone Number"
            }).ToList();
        }

        public async Task<ClientDetailsViewModel?> GetClientDetailsAsync(int id)
        {
            var company = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.ClientCompany>()
                .Include(x => x.Address).Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id);
            var model = new ClientDetailsViewModel()
            {
                Id = company.Id,
                Name = company.Name,
                RegistrationNumber = company.RegistrationNumber,
                Industry = company.Industry,
                Street = company.Address.Street,
                City = company.Address.City,
                PostalCode = company.Address.PostalCode,
                Country = company.Address.County,
                ContactPerson = company.ContactPerson,
                PhoneNumber = company.User.PhoneNumber,
                AlternativePhoneNumber = company.AlternativePhoneNumber,
                Email = company.User.Email,
                Username = company.User.UserName,
                CreatedAt = company.CreatedAt.ToString("dd/MM/yyyy"),
            };
            model.Deliveries = await repository.AllReadonly<LogiTrack.Infrastructure.Data.DataModels.Delivery>().Where(x => x.Offer.Request.ClientCompanyId == company.Id).Select(x => new DeliveryForClientsDeliveriesViewModel
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
                TotalItems = x.Offer.Request.StandartCargo == null ? x.Offer.Request.NumberOfNonStandartGoods.ToString() : x.Offer.Request.StandartCargo.NumberOfPallets.ToString(),
                ActualDeliveryDate = x.ActualDeliveryDate.GetValueOrDefault().ToString("dd-MM-yyyy")
            }).ToListAsync();
            return model;
        }

        Task<string?> IClientsService.GetLogisticsCompanyDashboardAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<VehicleDetailsViewModel>> GetVehiclesAsync(bool refrigerated, string? registrationNumber = null, string? vehicleType = null, double? minWeightCapacity = null, double? maxWeightCapacity = null, double? minVolume = null, double? maxVolume = null)
        {
            var vehicles = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Vehicle>().ToListAsync();
            if (refrigerated)
            {
                vehicles = vehicles.Where(x => x.IsRefrigerated == true).ToList();
            }
            if (string.IsNullOrEmpty(registrationNumber) == false)
            {
                vehicles = vehicles.Where(x => x.RegistrationNumber.ToLower().Contains(registrationNumber.ToLower())).ToList();
            }
            if (string.IsNullOrEmpty(vehicleType) == false)
            {
                vehicles = vehicles.Where(x => x.VehicleType.ToLower().Contains(vehicleType.ToLower())).ToList();
            }
            if (minWeightCapacity != null)
            {
                vehicles = vehicles.Where(x => x.MaxWeightCapacity >= minWeightCapacity).ToList();
            }
            if (maxWeightCapacity != null)
            {
                vehicles = vehicles.Where(x => x.MaxWeightCapacity <= maxWeightCapacity).ToList();
            }
            if (minVolume != null)
            {
                vehicles = vehicles.Where(x => x.Volume >= minVolume).ToList();
            }
            if (maxVolume != null)
            {
                vehicles = vehicles.Where(x => x.Volume <= maxVolume).ToList();
            }
            return vehicles.Select(x => new VehicleDetailsViewModel
            {
                Id = x.Id,
                RegistrationNumber = x.RegistrationNumber,
                VehicleType = x.VehicleType,
                MaxWeightCapacity = x.MaxWeightCapacity.ToString(),
                Length = x.Length.ToString(),
                Width = x.Width.ToString(),
                Height = x.Height.ToString(),
                Volume = x.Volume.ToString(),
                IsRefrigerated = x.IsRefrigerated,
                VehicleStatus = x.VehicleStatus
            }).ToList();
        }

        public async Task<List<VehicleDetailsViewModel>> GetVehiclesBySearchTermAsync(string? searchTerm)
        {
            var vehicles = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Vehicle>().ToListAsync();
            if (string.IsNullOrEmpty(searchTerm) == false)
            {
                vehicles = vehicles.Where(x => x.RegistrationNumber.ToLower().Contains(searchTerm.ToLower())
                               || x.VehicleType.ToLower().Contains(searchTerm.ToLower())
                               || x.MaxWeightCapacity.ToString().Contains(searchTerm.ToLower())
                               || x.Volume.ToString().Contains(searchTerm.ToLower())
                               || x.VehicleStatus.ToLower().Contains(searchTerm.ToLower())).ToList();
            }
            return vehicles.Select(x => new VehicleDetailsViewModel
            {
                Id = x.Id,
                RegistrationNumber = x.RegistrationNumber,
                VehicleType = x.VehicleType,
                MaxWeightCapacity = x.MaxWeightCapacity.ToString(),
                Length = x.Length.ToString(),
                Width = x.Width.ToString(),
                Height = x.Height.ToString(),
                Volume = x.Volume.ToString(),
                IsRefrigerated = x.IsRefrigerated,
                VehicleStatus = x.VehicleStatus
            }).ToList();
        }
        public async Task<bool> VehicleWithIdExistsAsync(int id)
        {
            return await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Vehicle>().AnyAsync(x => x.Id == id);
        }
        public async Task<VehicleDetailsViewModel?> GetVehicleDetailsAsync(int id)
        {
            var model = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Vehicle>().Where(x => x.Id == id)
                .Select(x => new VehicleDetailsViewModel
                {
                    Id = x.Id,
                    RegistrationNumber = x.RegistrationNumber,
                    VehicleType = x.VehicleType,
                    MaxWeightCapacity = x.MaxWeightCapacity.ToString(),
                    Length = x.Length.ToString(),
                    Width = x.Width.ToString(),
                    Height = x.Height.ToString(),
                    Volume = x.Volume.ToString(),
                    IsRefrigerated = x.IsRefrigerated,
                    VehicleStatus = x.VehicleStatus,
                    EuroPalletCapacity = x.EuroPalletCapacity.ToString(),
                    IndustrialPalletCapacity = x.IndustrialPalletCapacity.ToString(),
                    ArePalletsStackable = x.ArePalletsStackable,
                    FuelConsumptionPer100Km = x.FuelConsumptionPer100Km.ToString(),
                    DaysTillMaintenance = DateTime.Now.Subtract(x.LastYearMaintenance).Days.ToString(),
                    LastYearMaintenance = x.LastYearMaintenance,
                    KilometersDriven = x.KilometersDriven.ToString(),
                    KilometersLeftToChangeParts = (x.KilometersToChangeParts - x.KilometersDriven).ToString(),
                    PurchasePrice = x.PurchasePrice.ToString(),
                    ContantsExpenses = x.ContantsExpenses.ToString()
                }).FirstOrDefaultAsync();
            model.Deliveries = await repository.AllReadonly<LogiTrack.Infrastructure.Data.DataModels.Delivery>().Where(x => x.VehicleId == id).Select(x => new DeliveryForClientsDeliveriesViewModel
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
                TotalItems = x.Offer.Request.StandartCargo == null ? x.Offer.Request.NumberOfNonStandartGoods.ToString() : x.Offer.Request.StandartCargo.NumberOfPallets.ToString(),
                ActualDeliveryDate = x.ActualDeliveryDate.GetValueOrDefault().ToString("dd-MM-yyyy")
            }).ToListAsync();
            return model;
        }

        public async Task<(int domesticDeliveries, int internationalDeliveries)> GetDeliveryTypesForCompanyAsync(string username)
        {
            var domesticDeliveries = await repository.AllReadonly<LogiTrack.Infrastructure.Data.DataModels.Delivery>().Where(x => x.Offer.Request.ClientCompany.User.UserName == username && x.Offer.Request.Type == RequestTypeConstants.Domestic).CountAsync();
            var internationalDeliveries = await repository.AllReadonly<LogiTrack.Infrastructure.Data.DataModels.Delivery>().Where(x => x.Offer.Request.ClientCompany.User.UserName == username && x.Offer.Request.Type == RequestTypeConstants.International).CountAsync();
            return (domesticDeliveries, internationalDeliveries);
        }

        public async Task<(List<string>, List<int>)> GetDeliveryCountsForCompanyAsync(string username)
        {
            var company = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.ClientCompany>().FirstOrDefaultAsync(x => x.User.UserName == username);
            var deliveries = await repository.AllReadonly<LogiTrack.Infrastructure.Data.DataModels.Delivery>().Where(x => x.Offer.Request.ClientCompanyId == company.Id)
                .GroupBy(x => new { x.Offer.Request.CreatedAt.Month, x.Offer.Request.CreatedAt.Year })
                .Select(x => new
                {
                    Month = x.Key.Month,
                    Year = x.Key.Year,
                    Count = x.Count()
                }).OrderBy(x => x.Year).ThenBy(x => x.Month).ToListAsync();
            var months = new[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            var data = deliveries.Select(x => x.Count).ToList();    
            var list = deliveries.Select(x => $"{months[x.Month - 1]}").ToList();
            return (list, data);

        }
    }   }

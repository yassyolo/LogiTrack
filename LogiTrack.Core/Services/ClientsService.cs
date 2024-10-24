using LogisticsSystem.Infrastructure.Data.DataModels;
using LogiTrack.Core.Constants;
using LogiTrack.Core.Contracts;
using LogiTrack.Core.CustomExceptions;
using LogiTrack.Core.ViewModels.Clients;
using LogiTrack.Infrastructure.Data.DataModels;
using LogiTrack.Infrastructure.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static LogiTrack.Core.Constants.MessageConstants.ErrorMessages;
using static LogiTrack.Infrastructure.Data.DataConstants.DataModelConstants;

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
                 .Where(x => x.User.UserName == username)
                 .Select(x => new CompanyDetailsViewModel
                 {
                     Name = x.Name,
                     RegistrationNumber = x.RegistrationNumber,
                     Industry = x.Industry,
                     Street = x.Street,
                     City = x.City,
                     PostalCode = x.PostalCode,
                     Country = x.Country,
                     CreatedAt = x.CreatedAt.ToString("dd/MM/yyyy"),
                 })
                 .FirstOrDefaultAsync();
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

        public async Task<List<PendingRegistrationsViewModel>?> GetPendingRegistrationsAsync()
        {
            return await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.ClientCompany>()
                .Where(x => x.RegistrationStatus == StatusConstants.Pending)
                .OrderByDescending(x => x.CreatedAt)
                .Select(x => new PendingRegistrationsViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ContactPerson = x.ContactPerson,
                    AlternativePhoneNumber = x.AlternativePhoneNumber,
                    RegistrationNumber = x.RegistrationNumber,
                    Industry = x.Industry,
                    Street = x.Street,
                    City = x.City,
                    PostalCode = x.PostalCode,
                    Country = x.Country,
                    PhoneNumber = x.User.PhoneNumber,
                    CreatedAt = x.CreatedAt.ToString("dd/MM/yyyy"),
                    Email = x.User.Email
                })
                .ToListAsync();
        }

        public async Task MakeRequestAsync(MakeRequestViewModel model, string userEmail)
        {
            var user = await repository.AllReadonly<IdentityUser>().FirstOrDefaultAsync(x => x.Email == userEmail);
            if (user == null)
            {
                throw new UserNotFoundException();
            }
            var client = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.ClientCompany>().FirstOrDefaultAsync(x => x.UserId == user.Id);
            if (client == null)
            {
                throw new ClientCompanyNotFoundException();
            }
            var request = new LogisticsSystem.Infrastructure.Data.DataModels.Request
            {
                ClientCompanyId = client.Id,
                ClientCompany = client,
                CargoType = model.CargoType,
                TypeOfPallet = model.TypeOfPallet,
                NumberOfPallets = model.NumberOfPallets,
                PalletLength = model.PalletLength,
                PalletHeight = model.PalletHeight,
                PalletVolume = model.PalletVolume,
                PalletWidth = model.PalletWidth,
                WeightOfPallets = model.WeightOfPallets,
                PalletsAreStackable = model.PalletsAreStackable,
                NumberOfNonStandartGoods = model.NumberOfNonStandartGoods,
                Length = model.Length,
                Width = model.Width,
                Height = model.Height,
                Volume = model.Volume,
                Weight = model.Weight,
                TypeOfGoods = model.TypeOfGoods,
                Type = model.Type,
                SharedTruck = model.SharedTruck,
                ApproximatePrice = model.ApproximatePrice,
                ExpectedDeliveryDate = model.ExpectedDeliveryDate,
                SpecialInstructions = model.SpecialInstructions,
                IsRefrigerated = model.IsRefrigerated,
                Status = StatusConstants.Pending,
                CreatedAt = DateTime.Now
            };

            await repository.AddAsync(request);
            await repository.SaveChangesAsync();
        }

        public async Task RegisterClientCompanyAsync(RegisterViewModel model, IdentityUser user)
        {
            var client = new LogisticsSystem.Infrastructure.Data.DataModels.ClientCompany
            {
                Name = model.Name,
                Street = model.Street,
                City = model.City,
                PostalCode = model.PostalCode,
                Industry = model.Industry,
                Country = model.Country,
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

        Task<ContactDetailsViewModel?> IClientsService.GetCompanyContactDetailsAsync(string username)
        {
            throw new NotImplementedException();
        }

        public async Task<DashboardViewModel?> GetClientCompanyDashboardAsync(string username)
        {
            var company = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.ClientCompany>().FirstOrDefaultAsync(x => x.User.UserName == username);
            var offers = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Offer>().Where(x => x.Request.ClientCompanyId == company.Id && x.OfferStatus == StatusConstants.Pending).Take(5)
                .Select(x => new OfferIndexViewModel
                {
                    Id = x.Id,
                    PickupAddress = x.Request.PickupAddress,
                    DeliveryAddress = x.Request.DeliveryAddress,
                    Price = x.FinalPrice.ToString(),
                }).ToListAsync();
            var invoices = await repository.AllReadonly<Invoice>().Where(x => x.Offer.Request.ClientCompanyId == company.Id).Take(5)
                 .Select(x => new InvoiceIndexViewModel
                 {
                   Id = x.Id,
                   Number = x.InvoiceNumber,
                   Amount = x.Offer.FinalPrice.ToString(),
                   CreationDate = x.InvoiceDate.ToString("dd/MM/yyyy"),
                 })
                .ToListAsync();

            var deliveries = await repository.AllReadonly<Infrastructure.Data.DataModels.Delivery>().Where(x => x.Offer.Request.ClientCompanyId == company.Id).Take(5)
                .Select(x => new DeliveryTrackingIndexViewModel
                {
                   Id = x.Id,
                   PickupAddress = x.Offer.Request.PickupAddress,
                   DeliveryAddress = x.Offer.Request.DeliveryAddress,
                   StatusUpdate = x.Status,
                }).ToListAsync();
            var model = new DashboardViewModel
            {
                LastFivePendingOffers = offers,
                LastFiveDeliveries = deliveries,
                LastFiveInvoices = invoices,
                RequestsCount = company.Requests.Count(),
                BookedOffers = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Offer>().Where(x => x.Request.ClientCompanyId == company.Id && x.OfferStatus == StatusConstants.Approved).CountAsync(),
                Invoices = await repository.AllReadonly<Invoice>().Where(x => x.Offer.Request.ClientCompanyId == company.Id).CountAsync(),
                DomesticDeliveries = await repository.AllReadonly<LogiTrack.Infrastructure.Data.DataModels.Delivery>().Where(x => x.Offer.Request.ClientCompanyId == company.Id && x.Offer.Request.Type == RequestTypeConstants.Domestic).CountAsync(),
                InternationalDeliveries = await repository.AllReadonly<LogiTrack.Infrastructure.Data.DataModels.Delivery>().Where(x => x.Offer.Request.ClientCompanyId == company.Id && x.Offer.Request.Type == RequestTypeConstants.International).CountAsync(),
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

        public async Task<List<OfferForSearchViewModel>?> GetOffersForCompanyAsync(string username, string? deliveryAddress = null, string? pickupAddress = null, DateTime? startDate = null, DateTime? endDate = null)
        {
            var company = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.ClientCompany>().FirstOrDefaultAsync(x => x.User.UserName == username);

            var offers = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Offer>().Where(x => x.Request.ClientCompanyId == company.Id && x.OfferStatus == StatusConstants.Approved).ToListAsync();

            if (deliveryAddress != null)
            {
                offers = offers.Where(x => x.Request.DeliveryAddress.ToLower().Contains(deliveryAddress.ToLower())).ToList();
            }
            if (pickupAddress != null)
            {
                offers = offers.Where(x => x.Request.PickupAddress.ToLower().Contains(pickupAddress.ToLower())).ToList();
            }
            if (startDate != null)
            {
                offers = offers.Where(x => x.OfferDate >= startDate).ToList();
            }
            if (endDate != null)
            {
                offers = offers.Where(x => x.OfferDate <= endDate).ToList();
            }
            var offersToShow = offers.Select(x => new OfferForSearchViewModel
            {
                Id = x.Id,
                PickupAddress = x.Request.PickupAddress,
                DeliveryAddress = x.Request.DeliveryAddress,
                NumberOfPallets = x.Request.NumberOfPallets,
                PalletLength = x.Request.PalletLength.ToString(),
                PalletWidth = x.Request.PalletWidth.ToString(),
                PalletHeight = x.Request.PalletHeight.ToString(),
                NumberOfNonStandartGoods = x.Request.NumberOfNonStandartGoods.ToString(),
                Length = x.Request.Length.ToString(),
                Width = x.Request.Width.ToString(),
                Height = x.Request.Height.ToString(),
                Volume = x.Request.Volume.ToString(),
                Weight = x.Request.Weight.ToString(),
                ExpectedDeliveryDate = x.Request.ExpectedDeliveryDate.ToString(),
                FinalPrice = x.FinalPrice.ToString(),
                OfferDate = x.OfferDate.ToString("dd/MM/yyyy"),                
              }).ToList();
            return offersToShow;
        }

        public async Task BookOfferAsync(int id, string username)
        {
            var company = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.ClientCompany>().FirstOrDefaultAsync(x => x.User.UserName == username);
            var offer = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Offer>().FirstOrDefaultAsync(x => x.Id == id && x.Request.ClientCompanyId == company.Id);
            offer.OfferStatus = StatusConstants.Approved;
            await repository.SaveChangesAsync();
            var invoice = new Invoice()
            {
                OfferId = offer.Id,
                InvoiceNumber = Guid.NewGuid().ToString(),
                InvoiceDate = DateTime.Now,
            };
            await repository.AddAsync(invoice);
            await repository.SaveChangesAsync();           
        }

        public async Task<bool> OfferWithIdExistsAsync(int id)
        {
            return await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Offer>().AnyAsync(x => x.Id == id);
        }

        public async Task<bool> OfferWithCompanyExistsAsync(int id, string username)
        {
            var company = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.ClientCompany>().FirstOrDefaultAsync(x => x.User.UserName == username);

            return await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Offer>().AnyAsync(x => x.Id == id && x.Request.ClientCompanyId == company.Id);
        }
    }   }

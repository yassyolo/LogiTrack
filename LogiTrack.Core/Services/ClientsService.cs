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
            var client = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.ClientCompany>().FirstOrDefaultAsync(x => x.User.Email == userEmail);
            if (client == null)
            {
                throw new ClientCompanyNotFoundException();
            }
            var request = new LogisticsSystem.Infrastructure.Data.DataModels.Request
            {
                ClientCompanyId = client.Id,
                CargoType = model.CargoType,
                NumberOfNonStandartGoods = model.NumberOfNonStandartGoods,
                TypeOfGoods = model.TypeOfGoods,
                Type = model.Type,
                SharedTruck = model.SharedTruck,
                ApproximatePrice = model.ApproximatePrice,
                ExpectedDeliveryDate = model.ExpectedDeliveryDate,
                SpecialInstructions = model.SpecialInstructions,
                IsRefrigerated = model.IsRefrigerated,
                Status = StatusConstants.Pending,
                CreatedAt = DateTime.Now,
                PickupAddress = model.PickupAddress,
                PickupLatitude = model.PickupLatitude,
                PickupLongitude = model.PickupLongitude,
                DeliveryAddress = model.DeliveryAddress,
                DeliveryLatitude = model.DeliveryLatitude,
                DeliveryLongitude = model.DeliveryLongitude,
                Kilometers = CalculateDistance(model.PickupLatitude, model.PickupLongitude, model.DeliveryLatitude, model.DeliveryLongitude),
            };
            await repository.AddAsync(request);

            if (model.PalletLength != null)
            {
                var standartCargo = new StandartCargo
                {
                    TypeOfPallet = model.TypeOfPallet,
                    NumberOfPallets = model.NumberOfPallets,
                    PalletLength = model.PalletLength,
                    PalletHeight = model.PalletHeight,
                    PalletWidth = model.PalletWidth,
                    RequestId = request.Id,
                    WeightOfPallets = model.WeightOfPallets,
                    PalletsAreStackable = model.PalletsAreStackable,
                    PalletVolume = model.PalletLength * model.PalletWidth * model.PalletHeight / 1000000.0
                };
                await repository.AddAsync(standartCargo);
                request.StandartCargoId = standartCargo.Id;
            }
        
            if (model.Length != null && model.Length.Length > 0)
            {
                for (int i = 0; i < model.Length.Length; i++)
                {
                    var nonStandardCargo = new NonStandardCargo
                    {
                        RequestId = request.Id,
                        Description = model.Description[i], 
                        Length = model.Length[i],
                        Width = model.Width[i],
                        Height = model.Height[i],
                        Weight = model.Weight[i]
                    };
                    nonStandardCargo.Volume = nonStandardCargo.Length * nonStandardCargo.Width * nonStandardCargo.Height / 1000000.0;

                    await repository.AddAsync(nonStandardCargo);
                }
            }
         
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

        public async Task<ClientsDashboardViewModel?> GetClientCompanyDashboardAsync(string username)
        {
            var company = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.ClientCompany>().FirstOrDefaultAsync(x => x.User.UserName == username);
            var offers = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Offer>().Where(x => x.Request.ClientCompanyId == company.Id && x.OfferStatus == StatusConstants.Pending).Take(5)
                .Select(x => new OfferForDashboardViewModel
                {
                    Id = x.Id,
                    PickupAddress = x.Request.PickupAddress,
                    DeliveryAddress = x.Request.DeliveryAddress,
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
                   ReferenceNumber = x.ReferenceNumber,
                   DeliveryStep = x.DeliveryStep,
                   PickupAddress = x.Offer.Request.PickupAddress,
                   DeliveryAddress = x.Offer.Request.DeliveryAddress,
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
                /*NumberOfPallets = x.Request.NumberOfPallets,
                PalletLength = x.Request.PalletLength.ToString(),
                PalletWidth = x.Request.PalletWidth.ToString(),
                PalletHeight = x.Request.PalletHeight.ToString(),*/
                NumberOfNonStandartGoods = x.Request.NumberOfNonStandartGoods.ToString(),
                ExpectedDeliveryDate = x.Request.ExpectedDeliveryDate.ToString(),
                FinalPrice = x.FinalPrice.ToString(),
                OfferDate = x.OfferDate.ToString("dd/MM/yyyy"),                
              }).ToList();
            return offersToShow;
        }

        //TODO: Implement this method   
        public async Task BookOfferAsync(int id, string username)
        {
            var company = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.ClientCompany>().FirstOrDefaultAsync(x => x.User.UserName == username);
            var offer = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Offer>().FirstOrDefaultAsync(x => x.Id == id && x.Request.ClientCompanyId == company.Id);
            offer.OfferStatus = StatusConstants.Approved;
            await repository.SaveChangesAsync();
            /*var invoice = new Invoice()
            {
                Delivery = id,
                InvoiceNumber = Guid.NewGuid().ToString(),
                InvoiceDate = DateTime.Now,
            };
            await repository.AddAsync(invoice);*/
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

        public double CalculateDistance(double pickupLatitude, double pickupLongitude, double deliveryLatitude, double deliveryLongitude)
        {
            const double R = 6371.0; 
            double lat1 = pickupLatitude * (Math.PI / 180.0);
            double lon1 = pickupLongitude * (Math.PI / 180.0);
            double lat2 = deliveryLatitude * (Math.PI / 180.0);
            double lon2 = deliveryLongitude * (Math.PI / 180.0);

            double dLat = lat2 - lat1;
            double dLon = lon2 - lon1;

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Cos(lat1) * Math.Cos(lat2) *Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            double distance = R * c; 

            return distance;
        }

        public async Task<IEnumerable<RequestsForSearchViewModel>> GetRequestsForCompanyAsync(string companyUsername, DateTime? startDate = null, DateTime? endDate = null, string? pickupAddress = null, string? deliveryAddress = null, bool? isApproved = null)
        {
            var requests = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Request>().Where(x => x.ClientCompany.User.UserName == companyUsername).ToListAsync();
            if (startDate != null)
            {
                requests = requests.Where(x => x.CreatedAt >= startDate).ToList();
            }
            if (endDate != null)
            {
                requests = requests.Where(x => x.CreatedAt <= endDate).ToList();
            }
            if (pickupAddress != null)
            {
                requests = requests.Where(x => x.PickupAddress.ToLower().Contains(pickupAddress.ToLower())).ToList();
            }
            if (deliveryAddress != null)
            {
                requests = requests.Where(x => x.DeliveryAddress.ToLower().Contains(deliveryAddress.ToLower())).ToList();
            }
            if (isApproved != null)
            {
                requests = requests.Where(x => x.Status == StatusConstants.Approved).ToList();
            }
            return requests.Select(x => new RequestsForSearchViewModel
            {
                PickupAddress = x.PickupAddress,
                DeliveryAddress = x.DeliveryAddress,
                ExpectedDeliveryDate = x.ExpectedDeliveryDate.ToString(),
                CreationDate = x.CreatedAt.ToString("dd/MM/yyyy"),
                Approved = x.Status == StatusConstants.Approved,
                /*NumberOfItems = x.NumberOfPallets.ToString(),
                Weight = x.WeightOfPallets.ToString(),
                Volume = x.PalletVolume.ToString()*/
            });

        }
}   }

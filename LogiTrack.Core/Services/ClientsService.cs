using LogisticsSystem.Infrastructure.Data.DataModels;
using LogiTrack.Core.Constants;
using LogiTrack.Core.Contracts;
using LogiTrack.Core.CustomExceptions;
using LogiTrack.Core.ViewModels.Clients;
using LogiTrack.Core.ViewModels.Logistics;
using LogiTrack.Infrastructure.Data.DataModels;
using LogiTrack.Infrastructure.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using System;
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
                    Email = x.EmailAddress
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
                /*PickupAddress = model.PickupAddress,
                PickupLatitude = model.PickupLatitude,
                PickupLongitude = model.PickupLongitude,
                DeliveryAddress = model.DeliveryAddress,
                DeliveryLatitude = model.DeliveryLatitude,
                DeliveryLongitude = model.DeliveryLongitude,
                Kilometers = CalculateDistance(model.PickupLatitude, model.PickupLongitude, model.DeliveryLatitude, model.DeliveryLongitude),*/ //TODO
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

        public async Task<List<OfferForSearchViewModel>?> GetOffersForCompanyAsync(string username, string? deliveryAddress = null, string? pickupAddress = null, DateTime? startDate = null, DateTime? endDate = null, decimal? minPrice = null, decimal? maxPrice = null, bool? isApproved = null)
        {
            var company = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.ClientCompany>().FirstOrDefaultAsync(x => x.User.UserName == username);

            var offers = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Offer>().Include(x => x.Request).ThenInclude(x => x.PickupAddress)
                .Include(x => x.Request).ThenInclude(x => x.DeliveryAddress).Where(x => x.Request.ClientCompanyId == company.Id && x.OfferStatus == StatusConstants.Approved).ToListAsync();

            if (string.IsNullOrEmpty(deliveryAddress) == false)
            {
                offers = offers.Where(x => x.Request.DeliveryAddress.City.ToLower().Contains(deliveryAddress.ToLower()) || x.Request.DeliveryAddress.County.ToLower().Contains(deliveryAddress.ToLower()) || x.Request.DeliveryAddress.Street.ToLower().Contains(deliveryAddress.ToLower())).ToList();
            }
            if (string.IsNullOrEmpty(pickupAddress) == false)
            {
                offers = offers.Where(x => x.Request.PickupAddress.City.ToLower().Contains(pickupAddress.ToLower()) || x.Request.PickupAddress.County.ToLower().Contains(pickupAddress.ToLower()) || x.Request.PickupAddress.Street.ToLower().Contains(pickupAddress.ToLower())).ToList();
            }
            if (startDate != null)
            {
                offers = offers.Where(x => x.OfferDate >= startDate).ToList();
            }
            if (endDate != null)
            {
                offers = offers.Where(x => x.OfferDate <= endDate).ToList();
            }
            if (minPrice != null)
            {
                offers = offers.Where(x => x.FinalPrice >= minPrice).ToList();
            }
            if (maxPrice != null)
            {
                offers = offers.Where(x => x.FinalPrice <= maxPrice).ToList();
            }
            if (isApproved != null)
            {
                offers = offers.Where(x => x.OfferStatus == StatusConstants.Approved).ToList();
            }
            var offersToShow = offers.Select(x => new OfferForSearchViewModel
            {
                OfferNumber = x?.OfferNumber,
                Id = x.Id,
                PickupAddress = $"{x.Request.PickupAddress.Street}, {x.Request.PickupAddress.City}, {x.Request.PickupAddress.County}",
                DeliveryAddress = $"{x.Request.DeliveryAddress.Street}, {x.Request.DeliveryAddress.City}, {x.Request.DeliveryAddress.County}",
                NumberOfPallets = x.Request.StandartCargo?.NumberOfPallets.ToString() ?? "0",
                TotalVolume = x.Request.TotalVolume.ToString(),
                TotalWeight = x.Request.TotalWeight.ToString(),
                NumberOfNonStandartGoods = x.Request.NumberOfNonStandartGoods.ToString(),
                ExpectedDeliveryDate = x.Request.ExpectedDeliveryDate.ToString(),
                FinalPrice = x.FinalPrice.ToString(),
                OfferDate = x.OfferDate.ToString("dd-MM-yyyy"),  
                Booked = x.OfferStatus == StatusConstants.Approved,
                TotalItems = x.Request.StandartCargo != null ? x.Request.StandartCargo.NumberOfPallets.ToString() : x.Request.NumberOfNonStandartGoods.ToString(),
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
            var requests = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Request>().Include(x => x.PickupAddress).Include(x => x.DeliveryAddress).Where(x => x.ClientCompany.User.UserName == companyUsername).ToListAsync();
            if (startDate != null)
            {
                requests = requests.Where(x => x.CreatedAt >= startDate).ToList();
            }
            if (endDate != null)
            {
                requests = requests.Where(x => x.CreatedAt <= endDate).ToList();
            }
            if (string.IsNullOrEmpty(deliveryAddress) == false)
            {
                requests = requests.Where(x => x.DeliveryAddress.City.ToLower().Contains(deliveryAddress.ToLower()) || x.DeliveryAddress.County.ToLower().Contains(deliveryAddress.ToLower()) || x.DeliveryAddress.Street.ToLower().Contains(deliveryAddress.ToLower())).ToList();
            }
            if (string.IsNullOrEmpty(pickupAddress) == false)
            {
                requests = requests.Where(x => x.PickupAddress.City.ToLower().Contains(pickupAddress.ToLower()) || x.PickupAddress.County.ToLower().Contains(pickupAddress.ToLower()) || x.PickupAddress.Street.ToLower().Contains(pickupAddress.ToLower())).ToList();
            }
            return requests.Select(x => new RequestsForSearchViewModel
            {
                Id = x.Id,
                PickupAddress = $"{x.PickupAddress.Street}, {x.PickupAddress.City}, {x.PickupAddress.County}",
                DeliveryAddress = $"{x.DeliveryAddress.Street}, {x.DeliveryAddress.City}, {x.DeliveryAddress.County}",
                ExpectedDeliveryDate = x.ExpectedDeliveryDate.ToString(),
                CreationDate = x.CreatedAt.ToString("dd/MM/yyyy"),
                Approved = x.Status == StatusConstants.Approved,
                NumberOfItems = x.StandartCargo != null ? x.StandartCargo.NumberOfPallets.ToString() : x.NumberOfNonStandartGoods.ToString(),
                TotalWeight = x.TotalWeight.ToString(),
                TotalVolume = x.TotalVolume.ToString()
            });

        }

        public async Task<IEnumerable<RequestsForSearchViewModel>> GetRequestsForCompanyBySearchTermAsync(string companyUsername, string? searchTerm)
        {
            var requests = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Request>()
                .Include(x => x.PickupAddress).Include(x => x.DeliveryAddress).Where(x => x.ClientCompany.User.UserName == companyUsername).ToListAsync();
            
            if (string.IsNullOrEmpty(searchTerm) == false)
            {
                requests = requests.Where(x => x.DeliveryAddress.City.ToLower().Contains(searchTerm.ToLower()) || x.DeliveryAddress.County.ToLower().Contains(searchTerm.ToLower()) || x.DeliveryAddress.Street.ToLower().Contains(searchTerm.ToLower())
                || x.PickupAddress.City.ToLower().Contains(searchTerm.ToLower()) || x.PickupAddress.County.ToLower().Contains(searchTerm.ToLower()) || x.PickupAddress.Street.ToLower().Contains(searchTerm.ToLower())
                || x.CargoType.ToLower().Contains(searchTerm.ToLower())
                || x.SpecialInstructions.ToLower().Contains(searchTerm.ToLower())
                || x.Status.ToLower().Contains(searchTerm.ToLower())).ToList();
            }
           
            return requests.Select(x => new RequestsForSearchViewModel
            {
                Id = x.Id,
                PickupAddress = $"{x.PickupAddress.Street}, {x.PickupAddress.City}, {x.PickupAddress.County}",
                DeliveryAddress = $"{x.DeliveryAddress.Street}, {x.DeliveryAddress.City}, {x.DeliveryAddress.County}",
                ExpectedDeliveryDate = x.ExpectedDeliveryDate.ToString(),
                CreationDate = x.CreatedAt.ToString("dd/MM/yyyy"),
                Approved = x.Status == StatusConstants.Approved,
                NumberOfItems = x.StandartCargo != null ? x.StandartCargo.NumberOfPallets.ToString() : x.NumberOfNonStandartGoods.ToString(),
                TotalWeight = x.TotalWeight.ToString(),
                TotalVolume = x.TotalVolume.ToString()
            });
        }

        public async Task<bool> RequestWithIdExistsAsync(int id)
        {
            return await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Request>().AnyAsync(x => x.Id == id);
        }

        public async Task<bool> RequestWithCompanyExistsAsync(int id, string username)
        {
            return await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Request>().AnyAsync(x => x.Id == id && x.ClientCompany.User.UserName == username);
        }

        public async Task<RequestDetailsViewModel?> GetRequestDetailsAsync(int id)
        {
            var model = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Request>().Where(x => x.Id == id)
                .Select(x => new RequestDetailsViewModel
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

        public async Task<int> GetOfferIdByOfferNumberAsync(string offerNumber)
        {
            return await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Offer>().Where(x => x.OfferNumber == offerNumber).Select(x => x.Id).FirstOrDefaultAsync();
        }

        public async Task<List<OfferForSearchViewModel>?> GetOffersForCompanyBySearchTermAsync(string username, string? searchTerm = null)
        {
           var offers = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Offer>().Include(x => x.Request).Where(x => x.Request.ClientCompany.User.UserName == username).ToListAsync();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                offers = offers.Where(x =>
                    x.Request.DeliveryAddress.City.ToLower().Contains(searchTerm.ToLower()) ||
                    x.Request.DeliveryAddress.County.ToLower().Contains(searchTerm.ToLower()) ||
                    x.Request.DeliveryAddress.Street.ToLower().Contains(searchTerm.ToLower()) ||
                    x.Request.PickupAddress.City.ToLower().Contains(searchTerm.ToLower()) ||
                    x.Request.PickupAddress.County.ToLower().Contains(searchTerm.ToLower()) ||
                    x.Request.PickupAddress.Street.ToLower().Contains(searchTerm.ToLower()) ||
                    x.Request.CargoType.ToLower().Contains(searchTerm.ToLower()) ||
                    x.Request.SpecialInstructions.ToLower().Contains(searchTerm.ToLower()) ||
                    x.Request.Status.ToLower().Contains(searchTerm.ToLower()) ||
                    x.FinalPrice >= decimal.Parse(searchTerm) ||
                    x.FinalPrice <= decimal.Parse(searchTerm)
                ).ToList();
            }
            return (offers.Select(x => new OfferForSearchViewModel
            {
                Id = x.Id,
                PickupAddress = $"{x.Request.PickupAddress.Street}, {x.Request.PickupAddress.City}, {x.Request.PickupAddress.County}",
                DeliveryAddress = $"{x.Request.DeliveryAddress.Street}, {x.Request.DeliveryAddress.City}, {x.Request.DeliveryAddress.County}",
                NumberOfNonStandartGoods = x.Request.NumberOfNonStandartGoods.ToString(),
                ExpectedDeliveryDate = x.Request.ExpectedDeliveryDate.ToString(),
                FinalPrice = x.FinalPrice.ToString(),
                OfferDate = x.OfferDate.ToString("dd/MM/yyyy"),
            }).ToList());
        }

        public async Task<OfferDetailsViewModel?> GetOfferDetailsAsync(int id)
        {
            var model = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Offer>().Where(x => x.Id == id)
                .Select(x => new OfferDetailsViewModel
                {
                    Id = x.Id,
                    CargoType = x.Request.CargoType,
                    NumberOfNonStandartGoods = x.Request.NumberOfNonStandartGoods.ToString(),
                    TypeOfGoods = x.Request.TypeOfGoods,
                    PickupAddress = $"{x.Request.PickupAddress.Street}, {x.Request.PickupAddress.City}, {x.Request.PickupAddress.County}",
                    DeliveryAddress = $"{x.Request.DeliveryAddress.Street}, {x.Request.DeliveryAddress.City}, {x.Request.DeliveryAddress.County}",
                    SharedTruck = x.Request.SharedTruck,
                    ApproximatePrice = x.Request.ApproximatePrice.ToString(),
                    ExpectedDeliveryDate = x.Request.ExpectedDeliveryDate.ToString(),
                    Status = x.Request.Status,
                    SpecialInstructions = x.Request.SpecialInstructions,
                    IsRefrigerated = x.Request.IsRefrigerated,
                    CreatedAt = x.Request.CreatedAt.ToString("dd-MM-yyyy"),
                    Kilometers = x.Request.Kilometers.ToString(),
                    TotalWeight = x.Request.TotalWeight.ToString(),
                    TotalVolume = x.Request.TotalVolume.ToString(),
                    PalletsCount = x.Request.StandartCargo != null ? x.Request.StandartCargo.NumberOfPallets.ToString() : string.Empty,
                    PalletsLength = x.Request.StandartCargo != null ? x.Request.StandartCargo.PalletLength.ToString() : string.Empty,
                    PalletsHeight = x.Request.StandartCargo != null ? x.Request.StandartCargo.PalletHeight.ToString() : string.Empty,
                    PalletsWidth = x.Request.StandartCargo != null ? x.Request.StandartCargo.PalletWidth.ToString() : string.Empty,
                    FinalPrice = x.FinalPrice.ToString(),
                    OfferDate = x.OfferDate.ToString("dd-MM-yyyy"),
                    OfferStatus = x.OfferStatus,
                    Notes = x.Notes,
                    Booked = x.OfferStatus == StatusConstants.Approved,

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
                    Email = x.EmailAddress,
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
                clients = clients.Where(x => x.EmailAddress.ToLower().Contains(email.ToLower())).ToList();
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
                Email = x.EmailAddress,
                Phone = x.User != null ? x.User.PhoneNumber : "No Phone Number"
            }).ToList();
        }

        public async Task<List<ClientsForClientregisterViewModel>> GetClientsForClientsRegisterBySearchTermAsync(string? searchTerm)
        {
            var clients = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.ClientCompany>().Include(x => x.Address).ToListAsync();

            if (string.IsNullOrEmpty(searchTerm) == false)
            {
                clients = clients.Where(x => x.RegistrationNumber.ToLower().Contains(searchTerm.ToLower())
                || x.Name.ToLower().Contains(searchTerm.ToLower())
                || x.Address.City.ToLower().Contains(searchTerm.ToLower())
                || x.Address.County.ToLower().Contains(searchTerm.ToLower())
                || x.Address.Street.ToLower().Contains(searchTerm.ToLower())
                || x.Address.PostalCode.ToLower().Contains(searchTerm.ToLower())).ToList();
            }
            return clients.Select(x => new ClientsForClientregisterViewModel
            {
                Id = x.Id,
                Name = x.Name,
                RegisterNumber = x.RegistrationNumber,
                Address = $"{x.Address.Street}, {x.Address.City}, {x.Address.County}",
                Email = x.EmailAddress,
                Phone = x.User != null ? x.User.PhoneNumber : "No Phone Number"
            }).ToList();
        }
    }   }

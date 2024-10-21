using LogisticsSystem.Infrastructure.Data.DataModels;
using LogiTrack.Core.Constants;
using LogiTrack.Core.Contracts;
using LogiTrack.Core.CustomExceptions;
using LogiTrack.Core.ViewModels.Clients;
using LogiTrack.Infrastructure.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static LogiTrack.Core.Constants.MessageConstants.ErrorMessages;

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
            var company = await repository.All<ClientCompany>().FirstOrDefaultAsync(x => x.Id == id);
            company.RegistrationStatus = StatusConstants.Approved;
            await repository.SaveChangesAsync();
            return await repository.AllReadonly<IdentityUser>().FirstOrDefaultAsync(x => x.Id == company.UserId);
        }

        public async Task<bool> CompanyWithIdExistsAsync(int id)
        {
            return await repository.AllReadonly<ClientCompany>().AnyAsync(x => x.Id == id);
        }

        public async Task<CompanyDetailsViewModel?> GetCompanyDetailsAsync(string username)
        {
           return await repository.AllReadonly<ClientCompany>()
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
           return await repository.AllReadonly<ClientCompany>()
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
            return await repository.AllReadonly<ClientCompany>()
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
            var client = await repository.AllReadonly<ClientCompany>().FirstOrDefaultAsync(x => x.UserId == user.Id);
            if (client == null)
            {
                throw new ClientCompanyNotFoundException();
            }
            var request = new Request
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
            var client = new ClientCompany
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
            var company = await repository.All<ClientCompany>().FirstOrDefaultAsync(x => x.Id == id);
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
    }
}

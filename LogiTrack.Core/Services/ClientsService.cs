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
                UserId = user.Id
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

        public async Task<bool> UserWithEmailExistsAsync(string email)
        {
            return await repository.AllReadonly<IdentityUser>().AnyAsync(x => x.Email == email);
        }

        public async Task<bool> UserWithPhoneNumberExistsAsync(string phoneNumber)
        {
            return await repository.AllReadonly<IdentityUser>().AnyAsync(x => x.PhoneNumber == phoneNumber);
        }
    }
}

using LogiTrack.Core.Constants;
using LogiTrack.Core.Contracts;
using LogiTrack.Core.ViewModels.Clients;
using LogiTrack.Core.ViewModels.Offer;
using LogiTrack.Core.ViewModels.Request;
using LogiTrack.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiTrack.Core.Services
{
    public class OfferService : IOfferService
    {
        private readonly IRepository repository;

        public OfferService(IRepository repository)
        {
            this.repository = repository;
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

        public async Task<List<OfferForSearchViewModel>?> GetOffersForCompanyBySearchTermAsync(string username, string? searchTerm = null)
        {
            var offers = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Offer>()
                 .Include(x => x.Request).ThenInclude(x => x.PickupAddress).Include(x => x.Request).ThenInclude(x => x.DeliveryAddress).Where(x => x.Request.ClientCompany.User.UserName == username).ToListAsync();
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
        public async Task<bool> OfferWithIdExistsAsync(int id)
        {
            return await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Offer>().AnyAsync(x => x.Id == id);
        }
        public async Task<bool> OfferWithCompanyExistsAsync(int id, string username)
        {
            var company = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.ClientCompany>().FirstOrDefaultAsync(x => x.User.UserName == username);

            return await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Offer>().AnyAsync(x => x.Id == id && x.Request.ClientCompanyId == company.Id);
        }
        public async Task<int> GetOfferIdByOfferNumberAsync(string offerNumber)
        {
            return await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Offer>().Where(x => x.OfferNumber == offerNumber).Select(x => x.Id).FirstOrDefaultAsync();
        }



        public async Task<OfferViewModel?> GetOfferDetailsAsync(int id)
        {
            var model = await repository.AllReadonly<LogisticsSystem.Infrastructure.Data.DataModels.Offer>().Where(x => x.Id == id)
                .Select(x => new OfferViewModel
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


    }
}

﻿using LogisticsSystem.Infrastructure.Data.DataModels;
using LogiTrack.Core.ViewModels.Delivery;

namespace LogiTrack.Core.ViewModels.Request
{
    public class PendingRequestDetailsViewModel
    {
        public int Id { get; set; }
        public bool GivenOffer { get; set; }
        public string? OfferNumber { get; set; }
        public string? OfferDate { get; set; }
        public string? FinalPrice { get; set; }
        public int? OfferId { get; set; }
        public bool Reserved { get; set; }
        public string ReferenceNumber { get; set; } = string.Empty;
        public string ClientAddress { get; set; } = string.Empty;
        public string ClientPhone { get; set; } = string.Empty;
        public string ClientEmail { get; set; } = string.Empty;
        public DateTime SuggestedStartDate { get; set; } 
        public int NeededVehiclesCount { get; set; }
        public List<(PossibleVehiclesForDeliveryViewModel Primary, PossibleVehiclesForDeliveryViewModel Seconary, VehiclePairsLegend Legend)> NeededVehiclePairs { get; set; } = new List<(PossibleVehiclesForDeliveryViewModel Primary, PossibleVehiclesForDeliveryViewModel Seconary, VehiclePairsLegend Legend)>();
        public int ClientId { get; set; }
        public string CreatedOn { get; set; } = string.Empty;
        public string ClientCompanyName { get; set; } = string.Empty;
        public string RegistrationNumber { get; set; } = string.Empty;
        public string CargoType { get; set; } = string.Empty;
        public string? TypeOfPallet { get; set; } = string.Empty;
        public string? NumberOfPallets { get; set; }
        public string? PalletLength { get; set; }
        public string? PalletWidth { get; set; }
        public string? PalletHeight { get; set; }
        public string? PalletVolume { get; set; }
        public string? WeightOfPallets { get; set; }
        public string? PalletsAreStackable { get; set; }
        public string? NumberOfNonStandartGoods { get; set; }
        public string TypeOfGoods { get; set; } = string.Empty;
        public string PickupCity { get; set; } = string.Empty;
        public string PickupCountry { get; set; } = string.Empty;
        public string PickupStreet { get; set; } = string.Empty;
        public string PickupLatitude { get; set; } = string.Empty;
        public string PickupLongitude { get; set; } = string.Empty;
        public string DeliveryCity { get; set; } = string.Empty;
        public string DeliveryCountry { get; set; } = string.Empty;
        public string DeliveryStreet { get; set; } = string.Empty;
        public string DeliveryLatitude { get; set; } = string.Empty;
        public string DeliveryLongitude { get; set; } = string.Empty;
        public string SharedTruck { get; set; } = string.Empty;
        public string ExpectedDeliveryDate { get; set; } = string.Empty;
        public string SpecialInstructions { get; set; } = string.Empty;
        public string IsRefrigerated { get; set; } = string.Empty;
        public string ApproximatePrice { get; set; } = string.Empty;
        public int RequiredVehicleCount { get; set; }
        public List<PossibleVehiclesForDeliveryViewModel> PossibleVehicles { get; set; } = new List<PossibleVehiclesForDeliveryViewModel>();
        public List<PossibleDriversForDeliveryViewModel> PossibleDrivers { get; set; } = new List<PossibleDriversForDeliveryViewModel>();
        public IEnumerable<NonStandardCargosViewModel> NonStandardCargos { get; set; } = new List<NonStandardCargosViewModel>();
    }

    
}

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using LogiTrack.Core.ViewModels.Driver;

namespace LogiTrack.Core.ViewModels.Driver
{
    public class DeliveryForDriverViewModel
    {
        public int Id { get; set; }
        public int DeliveryStep { get; set; }
        public string ClientCompanyName { get; set; } = string.Empty;
        public string CargoType { get; set; } = string.Empty; //standard , not standard
        public string? TypeOfPallet { get; set; } = string.Empty; //euro, industrial
        public string? NumberOfPallets { get; set; }
        public string? PalletLength { get; set; } //in cm
        public string? PalletWidth { get; set; }
        public string? PalletHeight { get; set; }
        public string? PalletVolume { get; set; }
        public string? WeightOfPallets { get; set; }
        public bool? PalletsAreStackable { get; set; } //only if the truck is not shared
        public string? NumberOfNonStandartGoods { get; set; }
        public string TypeOfGoods { get; set; } = string.Empty;
        public string PickupAddress { get; set; } = string.Empty;
        public string PickupLatitude { get; set; } = string.Empty;
        public string PickupLongitude { get; set; } = string.Empty;
        public string DeliveryAddress { get; set; } = string.Empty;
        public string DeliveryLatitude { get; set; } = string.Empty;
        public string DeliveryLongitude { get; set; } = string.Empty;
        public bool SharedTruck { get; set; }
        public string ExpectedDeliveryDate { get; set; } = string.Empty;
        public string SpecialInstructions { get; set; } = string.Empty;
        public bool IsRefrigerated { get; set; }
        public string ReferenceNumber { get; set; } = string.Empty;
        public string RegistrationNumber { get; set; } = string.Empty;
        public string VehicleType { get; set; } = string.Empty;
        public IEnumerable<DeliveryTrackingViewModel> DeliveryTrackings { get; set; } = new List<DeliveryTrackingViewModel>();
        public IEnumerable<NonStandardCargosViewModel> NonStandardCargos { get; set; } = new List<NonStandardCargosViewModel>();
    }
}

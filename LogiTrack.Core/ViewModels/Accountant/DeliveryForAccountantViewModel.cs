using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LogiTrack.Core.ViewModels.Accountant
{
    public class DeliveryForAccountantViewModel
    {
        public int Id { get; set; }
        public string ClientCompanyName { get; set; } = string.Empty;
        public string CargoType { get; set; } = string.Empty; //standard , not standard
        public string? TypeOfPallet { get; set; } = string.Empty; //euro, industrial
        public int? NumberOfPallets { get; set; }
        public string? PalletLength { get; set; } = string.Empty;
        public string? PalletWidth { get; set; } = string.Empty;
        public string? PalletHeight { get; set; } = string.Empty;
        public string? PalletVolume { get; set; } = string.Empty;
        public string? WeightOfPallets { get; set; } = string.Empty;
        public bool? PalletsAreStackable { get; set; } //only if the truck is not shared
        public int? NumberOfNonStandartGoods { get; set; }
        public string? Length { get; set; } = string.Empty;
        public string? Width { get; set; } = string.Empty;
        public string? Height { get; set; } = string.Empty;
        public string? Volume { get; set; } = string.Empty;
        public string? Weight { get; set; } = string.Empty;
        public string TypeOfGoods { get; set; } = string.Empty;
        public string PickupAddress { get; set; } = string.Empty;
        public string DeliveryAddress { get; set; } = string.Empty;
        public bool SharedTruck { get; set; }
        public bool IsRefrigerated { get; set; }
        public string VehicleRegistrationNumber { get; set; } = string.Empty;
        public string DriverName { get; set; } = string.Empty;
        public string TotalExpenses { get; set; } = string.Empty;
        public string Profit { get; set; } = string.Empty;
        public string ReferenceNumber { get; set; } = string.Empty;
        public IEnumerable<CashRegisterIndexViewModel> CashRegisters { get; set; } = new List<CashRegisterIndexViewModel>();
    }
}

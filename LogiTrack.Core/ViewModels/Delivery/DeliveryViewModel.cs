namespace LogiTrack.Core.ViewModels.Delivery
{
    public class DeliveryViewModel
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public int ClientCompanyId { get; set; }    
        public string ClientCompanyName { get; set; } = string.Empty;
        public string CargoType { get; set; } = string.Empty; //standard , not standard
        public string? TypeOfPallet { get; set; } = string.Empty; //euro, industrial
        public string? NumberOfPallets { get; set; } = string.Empty;
        public string? PalletLength { get; set; } = string.Empty;
        public string? PalletWidth { get; set; } = string.Empty;
        public string? PalletHeight { get; set; } = string.Empty;
        public string? PalletVolume { get; set; } = string.Empty;
        public string? WeightOfPallets { get; set; } = string.Empty;
        public bool? PalletsAreStackable { get; set; } //only if the truck is not shared
        public string? NumberOfNonStandartGoods { get; set; } = string.Empty;
        public string? Length { get; set; } = string.Empty;
        public string? Width { get; set; } = string.Empty;
        public string? Height { get; set; } = string.Empty;
        public string? Volume { get; set; } = string.Empty;
        public string? Weight { get; set; } = string.Empty;
        public string TypeOfGoods { get; set; } = string.Empty;
        public string PickupAddress { get; set; } = string.Empty;
        public string DeliveryAddress { get; set; } = string.Empty;
        public bool SharedTruck { get; set; }
        public string ExpectedDeliveryDate { get; set; } = string.Empty;
        public string SpecialInstructions { get; set; } = string.Empty;
        public bool IsRefrigerated { get; set; }
        public string ReferenceNumber { get; set; } = string.Empty;
       public bool IsPaid { get; set; }
        public bool IsNew { get; set; }
        public string TotalWeight { get; set; } = string.Empty;
        public string TotalVolume { get; set; } = string.Empty;
        public int TotalCargos { get; set; }
    }
}

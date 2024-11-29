namespace LogiTrack.Core.ViewModels.Delivery
{
    public class DeliveryForDriverViewModel
    {
        public int Id { get; set; }
        public string CurrentTime { get; set; } = string.Empty;
        public int DeliveryStep { get; set; }
        public string ClientCompanyName { get; set; } = string.Empty;
        public string? NumberOfPallets { get; set; }
        public string? PalletLength { get; set; } 
        public string? PalletWidth { get; set; }
        public string? PalletHeight { get; set; }
        public string? PalletVolume { get; set; }
        public string? WeightOfPallets { get; set; }
        public string? PalletsAreStackable { get; set; } 
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
        public string ReferenceNumber { get; set; } = string.Empty;
        public string RegistrationNumber { get; set; } = string.Empty;
        public string VehicleType { get; set; } = string.Empty;
        public string FuelConsumptionPer100Km { get; set; } = string.Empty;
        public string VehicleLength { get; set; } = string.Empty;
        public string VehicleWidth { get; set; } = string.Empty;
        public string VehicleHeight { get; set; } = string.Empty;
        public string VehicleWeightCapacity { get; set; } = string.Empty;

        public IEnumerable<DeliveryTrackingViewModel> DeliveryTrackings { get; set; } = new List<DeliveryTrackingViewModel>();
        public IEnumerable<NonStandardCargosViewModel> NonStandardCargos { get; set; } = new List<NonStandardCargosViewModel>();
    }
}

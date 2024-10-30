namespace LogiTrack.Core.ViewModels.Clients
{
    public class RequestsForSearchViewModel
    {
        public string PickupAddress { get; set; } = string.Empty;
        public string DeliveryAddress { get; set; } = string.Empty;
        public string ExpectedDeliveryDate { get; set; } = string.Empty;
        public string CreationDate { get; set; } = string.Empty;
        public bool Approved { get; set; }
        public string NumberOfItems { get; set; } = string.Empty;
        public string Weight { get; set; } = string.Empty;
        public string Volume { get; set; } = string.Empty;
    }
}

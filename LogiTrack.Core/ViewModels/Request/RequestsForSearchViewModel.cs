namespace LogiTrack.Core.ViewModels.Request
{
    public class RequestsForSearchViewModel
    {
        public int Id { get; set; }
        public string Price { get; set; } = string.Empty;
        public string ReferenceNumber { get; set; } = string.Empty;
        public string PickupAddress { get; set; } = string.Empty;
        public string DeliveryAddress { get; set; } = string.Empty;
        public string ExpectedDeliveryDate { get; set; } = string.Empty;
        public string CreationDate { get; set; } = string.Empty;
        public bool Approved { get; set; }
        public string NumberOfItems { get; set; } = string.Empty;
        public string TotalWeight { get; set; } = string.Empty;
        public string TotalVolume { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
    }
}

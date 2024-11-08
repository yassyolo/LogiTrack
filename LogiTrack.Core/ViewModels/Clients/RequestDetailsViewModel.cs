using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LogiTrack.Core.ViewModels.Clients
{
    public class RequestDetailsViewModel
    {
        public int Id { get; set; }
        public string CargoType { get; set; } = string.Empty; //standard , not standard
        public string? NumberOfNonStandartGoods { get; set; }
        public string TypeOfGoods { get; set; } = string.Empty;
        public string PickupAddress { get; set; } = string.Empty;
        public string DeliveryAddress { get; set; } = string.Empty;
        public bool SharedTruck { get; set; }
        public string ApproximatePrice { get; set; } = string.Empty; //given by the company
        public string ExpectedDeliveryDate { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty; //pending, accepted, rejected
        public string SpecialInstructions { get; set; } = string.Empty;
        public bool IsRefrigerated { get; set; }

        public string CreatedAt { get; set; } = string.Empty;
        public string Kilometers { get; set; } = string.Empty;
       
        public string TotalWeight { get; set; } = string.Empty;
        public string TotalVolume { get; set; } = string.Empty;
        public string PalletsCount { get; set; } = string.Empty;
        public string PalletsLength { get; set; } = string.Empty;
        public string PalletsHeight { get; set; } = string.Empty;
        public string PalletsWidth { get; set; } = string.Empty;
        public List<NonStandardCargoRequestViewModel> NonStandardCargo { get; set; } = new List<NonStandardCargoRequestViewModel>();
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiTrack.Core.ViewModels.Clients
{
    public class OfferForSearchViewModel
    {
        public int Id { get; set; }
        public int? NumberOfPallets { get; set; }
        public string? PalletLength { get; set; } = string.Empty;
        public string? PalletWidth { get; set; } = string.Empty;
        public string? PalletHeight { get; set; } = string.Empty;
        public string? NumberOfNonStandartGoods { get; set; } = string.Empty;
        public string? Length { get; set; } = string.Empty;
        public string? Width { get; set; } = string.Empty;
        public string? Height { get; set; } = string.Empty;
        public string? Volume { get; set; } = string.Empty;
        public string? Weight { get; set; } = string.Empty;
        public string PickupAddress { get; set; } = string.Empty;
        public string DeliveryAddress { get; set; } = string.Empty;
        public string ExpectedDeliveryDate { get; set; } = string.Empty;
        public string FinalPrice { get; set; } = string.Empty;
        public string OfferDate { get; set; } = string.Empty;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiTrack.Core.ViewModels.Offer
{
    public class OfferForDashboardViewModel
    {
        public int Id { get; set; }
        public string PickupAddress { get; set; } = string.Empty;
        public string DeliveryAddress { get; set; } = string.Empty;
        public string Price { get; set; } = string.Empty;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiTrack.Core.ViewModels.Clients
{
    public class DeliveryTrackingIndexViewModel
    {
        public int Id { get; set; }

        public string PickupAddress { get; set; } = string.Empty;
        public string DeliveryAddress { get; set; } = string.Empty;
        public string StatusUpdate { get; set; } = string.Empty;
    }
}

using LogiTrack.Core.ViewModels.Delivery;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace LogiTrack.Core.ViewModels.Accountant
{
    public class SearchDeliveryViewModel
    {
        public string SearchTerm { get; set; } = string.Empty;
        public DeliveryIndexViewModel DeliveryIndex { get; set; } = null!;

        public DeliveryViewModel Delivery { get; set; } = null!;
    }
}

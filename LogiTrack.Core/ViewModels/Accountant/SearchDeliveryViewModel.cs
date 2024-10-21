using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace LogiTrack.Core.ViewModels.Accountant
{
    public class SearchDeliveryViewModel
    {
        public string SearchTerm { get; set; } = string.Empty;
        public DeliveryIndexViewModel Delivery { get; set; } = null!;
    }
}

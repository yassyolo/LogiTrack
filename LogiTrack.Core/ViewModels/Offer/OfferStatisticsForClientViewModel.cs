using System.Xml.Schema;

namespace LogiTrack.Core.ViewModels.Offer
{
    public class OfferStatisticsForClientViewModel
    {
        public double AverageWeight { get; set; }
        public double AverageVolume { get; set; }
        public decimal AveragePrice { get; set; }
        public int TotalPallets { get; set; }
    }
}

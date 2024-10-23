using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiTrack.Core.ViewModels.Clients
{
    public class DashboardViewModel
    {
        public int RequestsCount { get; set; }
        public int BookedOffers { get; set; }
        public int Invoices { get; set; }

        public IEnumerable<OfferIndexViewModel> LastFivePendingOffers { get; set; } = new List<OfferIndexViewModel>();
        public IEnumerable<InvoiceIndexViewModel> LastFiveInvoices { get; set; } = new List<InvoiceIndexViewModel>();
        public IEnumerable<DeliveryTrackingIndexViewModel> LastFiveDeliveries { get; set; } = new List<DeliveryTrackingIndexViewModel>();

        public int DomesticDeliveries { get; set; }
        public int InternationalDeliveries { get; set; }
    }
}

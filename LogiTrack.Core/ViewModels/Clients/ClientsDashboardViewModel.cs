namespace LogiTrack.Core.ViewModels.Clients
{
    public class ClientsDashboardViewModel
    {
        public int RequestsCount { get; set; }
        public int RequestsLastMonthCount { get; set; }
        public int BookedOffersCount { get; set; }
        public int BookedOffersLastMonthCount { get; set; }
        public int InvoicesCount { get; set; }
        public int InvoiceLastMonthCount { get; set; }
        public decimal DueAmountForDeliveries { get; set; }

        public IEnumerable<OfferForDashboardViewModel> LastFivePendingOffers { get; set; } = new List<OfferForDashboardViewModel>();
        public IEnumerable<InvoiceForDashboardViewModel> LastFiveInvoices { get; set; } = new List<InvoiceForDashboardViewModel>();
        public IEnumerable<DeliveryTrackingForDashboardViewModel> LastFiveDeliveries { get; set; } = new List<DeliveryTrackingForDashboardViewModel>();

        public int DomesticDeliveriesCount { get; set; }
        public int InternationalDeliveriesCount { get; set; }
    }
}

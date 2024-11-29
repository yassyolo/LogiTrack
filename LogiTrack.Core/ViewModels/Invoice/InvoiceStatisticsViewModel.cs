namespace LogiTrack.Core.ViewModels.Invoice
{
    public class InvoiceStatisticsViewModel
    {
        public decimal OverdueAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public int ClientsWithOverdueInvoices { get; set; }
        public double AveragePaymentTime { get; set; }
    }
}

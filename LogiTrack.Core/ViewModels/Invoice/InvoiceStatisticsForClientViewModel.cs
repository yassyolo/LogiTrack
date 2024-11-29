namespace LogiTrack.Core.ViewModels.Invoice
{
    public class InvoiceStatisticsForClientViewModel
    {
        public int PendingInvoices { get; set; }
        public decimal PendingAmount { get; set; }
        public int OverdueInvoices { get; set; }
        public decimal OverdueAmount { get; set; }
        public int PaidInvoices { get; set; }
        public decimal PaidAmount { get; set; }
        public double AveragePaymentTime { get; set; }
    }
}

﻿namespace LogiTrack.Core.ViewModels.Accountant
{
    public class MarkAsPaidInvoiceViewModel
    {
        public int DeliveryId { get; set; }
        public int InvoiceId { get; set; }
        public string ClientName { get; set; } = string.Empty;
        public string ClientRegistrationNumber { get; set; } = string.Empty;
        public string InvoiceNumber { get; set; } = string.Empty;
        public string InvoiceDate { get; set; } = string.Empty;
        public string Amount { get; set; } = string.Empty;
        public string Today { get; set; } = string.Empty;
    }
}

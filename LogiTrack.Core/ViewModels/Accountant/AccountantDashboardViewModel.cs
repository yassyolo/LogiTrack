﻿using LogiTrack.Core.ViewModels.Clients;

namespace LogiTrack.Core.ViewModels.Accountant
{
    public class AccountantDashboardViewModel
    {
        public int NewFinishedDeliveries { get; set; }
        public int NotPaidDeliveries { get; set; }
        public int InvoicesCnt { get; set; }
        public string DueAmountForDeliveries { get; set; } = string.Empty;
        public List<InvoiceIndexViewModel> Last5NotPaidInvoices { get; set; } = new List<InvoiceIndexViewModel>();
        public List<DeliveryForAccountantViewModel> Last5NewDeliveries { get; set; } = new List<DeliveryForAccountantViewModel>();
    }
}
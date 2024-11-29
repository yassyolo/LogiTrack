namespace LogiTrack.Core.ViewModels.CashRegister
{
    public class CashRegisterStatisticsViewModel
    {
        public int DeliveriesWithAdditionalCosts { get; set; }
        public decimal TotalAdditionalCosts { get; set; }
        public int DeliveriesWithAdditionalCostsRatio { get; set; }
        public int TotalCashRegisters { get; set; }
    }
}

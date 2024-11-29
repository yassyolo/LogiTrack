namespace LogiTrack.Core.ViewModels.FuelPrice
{
    public class FilterFuelPricesViewModel
    {
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public List<FuelPriceViewModel> FuelPrices { get; set; } = new List<FuelPriceViewModel>();
    }
}

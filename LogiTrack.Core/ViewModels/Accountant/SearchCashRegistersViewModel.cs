using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiTrack.Core.ViewModels.Accountant
{
    public class SearchCashRegistersViewModel
    {
        public List<CashRegisterIndexViewModel> CashRegisters { get; set; } = new List<CashRegisterIndexViewModel>();
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? CompanyName { get; set; }
        public string? DeliveryReferenceNumber { get; set; }
        public string? SearchTerm { get; set; }
        public string Type { get; set; } = string.Empty;
    }
}

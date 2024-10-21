using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LogiTrack.Core.ViewModels.Accountant
{
    public class DeliveryIndexViewModel
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public int DriverId { get; set; }
        public string TotalExpenses { get; set; } = string.Empty;
        public string Profit { get; set; } = string.Empty;
        public string ReferenceNumber { get; set; } = string.Empty;
        public IEnumerable<CashRegisterIndexViewModel> CashRegisters { get; set; } = new List<CashRegisterIndexViewModel>();
    }
}

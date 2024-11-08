using LogiTrack.Core.ViewModels.Driver;

namespace LogiTrack.Core.ViewModels.Accountant
{
    public class DeliveryForAccountantViewModel
    {
        public int Id { get; set; }
        public string ClientAddress { get; set; } = string.Empty;
        public string ClientPhone { get; set; } = string.Empty;
        public string ClientEmail { get; set; } = string.Empty;
        public string ClientCompanyName { get; set; } = string.Empty;
        public string PickupAddress { get; set; } = string.Empty;
        public string DeliveryAddress { get; set; } = string.Empty;
        public string VehicleRegistrationNumber { get; set; } = string.Empty;
        public string DriverName { get; set; } = string.Empty;
        public string TotalExpenses { get; set; } = string.Empty;
        public string Profit { get; set; } = string.Empty;
        public string ReferenceNumber { get; set; } = string.Empty;
        public string VehicleType { get; set; } = string.Empty;
        public string RegistrationNumber { get; set; } = string.Empty;
        public string Age { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string YearOfExperience { get; set; } = string.Empty;
        public string MonthsOfExperience { get; set; } = string.Empty;
        public string Salary { get; set; } = string.Empty;
        public bool IsPaid { get; set; }
        public int DeliveryStep { get; set; }
        public InvoiceForDeliveryViewModel Invoice { get; set; } = new InvoiceForDeliveryViewModel();
        public IEnumerable<CashRegisterIndexViewModel> CashRegisters { get; set; } = new List<CashRegisterIndexViewModel>();
        public IEnumerable<NonStandardCargosViewModel> NonStandardCargos { get; set; } = new List<NonStandardCargosViewModel>();
    }
}

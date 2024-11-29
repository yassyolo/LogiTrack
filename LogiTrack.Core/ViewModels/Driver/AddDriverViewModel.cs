namespace LogiTrack.Core.ViewModels.Driver
{
    public class AddDriverViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string LicenseNumber { get; set; } = string.Empty;

        public DateTime LicenseExpiryDate { get; set; }

        public decimal Salary { get; set; }

        public int Age { get; set; }

        public int YearOfExperience { get; set; }

        public int MonthsOfExperience { get; set; }

        public string? Preferrences { get; set; }
    }
}


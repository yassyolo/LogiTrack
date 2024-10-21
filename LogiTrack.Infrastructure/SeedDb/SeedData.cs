using LogisticsSystem.Infrastructure.Data.DataModels;
using LogiTrack.Infrastructure.Data.DataModels;
using Microsoft.AspNetCore.Identity;

namespace LogiTrack.Infrastructure.SeedDb
{
    public class SeedData
    {
        public IdentityUser ClientCompany1User { get; set; } = null!;
        public IdentityUser LogiticsCompanyUser { get; set; } = null!;
        public IdentityUser SecretaryUser { get; set; } = null!;
        public IdentityUser SpeditorUser { get; set; } = null!;

        public IdentityRole ClientCompanyRole { get; set; } = null!;
        public IdentityRole LogisticsCompanyRole { get; set; } = null!;
        public IdentityRole AccountRole { get; set; } = null!;
        public IdentityRole SpeditorRole { get; set; } = null!;

        public IdentityUserRole<string> ClientCompanyUserRole { get; set; } = null!;
        public IdentityUserRole<string> LogisticsCompanyUserRole { get; set; } = null!;
        public IdentityUserRole<string> AccountantUserRole { get; set; } = null!;
        public IdentityUserRole<string> SpeditorUserRole { get; set; } = null!;

        public ClientCompany ClientCompany1 { get; set; } = null!;
        public ClientCompany ClientCompany2 { get; set; } = null!;

        public Request Request1 { get; set; } = null!;
        public Request Request2 { get; set; } = null!;
        public Request Request3 { get; set; } = null!;
        public Request Request4 { get; set; } = null!;

        public Offer OfferForRequest1 { get; set; } = null!;

        public Delivery DeliveryForOfferForRequest1 { get; set; } = null!;

        public Driver Driver1ForDelivery { get; set; } = null!;
        public Driver Driver2 { get; set; } = null!;

        public Vehicle Vehicle1ForDelivery { get; set; } = null!;
        public Vehicle Vehicle2 { get; set; } = null!;

        public CashRegister CashRegisterForDriver1 { get; set; } = null!;
        public CashRegister CashRegisterForVehicle1 { get; set; } = null!;

        public Invoice InvoiceForOfferForRequest1 { get; set; } = null!;

        public PricesPerSize PricesForVehicle1 { get; set; } = null!;
        public PricesPerSize PricesForVehicle2 { get; set; } = null!;

        public SeedData()
        {
            SeedUsers();
            SeedRoles();
            SeedUserRoles();
            SeedClientCompanies();
            SeedRequests();
            SeedOffers();
            SeedInvoices();
            SeedDrivers();
            SeedVehicles();
            SeedDeliveries();      
            SeedCashRegisters();
            SeedPricesPerSize();
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            ClientCompany1User = new IdentityUser
            {
                UserName = "clientcompany1",
                Email = "clientcompany1@example.com",
                Id = "20450cff-816f-49c8-9546-1c603aec0301", 
                PhoneNumber = "1234567890",
                EmailConfirmed = true
            };
            ClientCompany1User.PasswordHash = hasher.HashPassword(ClientCompany1User, "clientcompany1");

            LogiticsCompanyUser = new IdentityUser
            {
                UserName = "logistics",
                Email = "logistics@example.com",
                Id = "6bab54d5-5a88-4128-92d2-4d12ad0baa32", 
                EmailConfirmed = true
            };
            LogiticsCompanyUser.PasswordHash = hasher.HashPassword(LogiticsCompanyUser, "logistics");

            SecretaryUser = new IdentityUser
            {
                UserName = "secretary",
                Email = "secretary@example.com",
                Id = "38ba6810-2800-4ac8-b005-5c27e8248951", 
                EmailConfirmed = true
            };
            SecretaryUser.PasswordHash = hasher.HashPassword(SecretaryUser, "secretary");

            SpeditorUser = new IdentityUser
            {
                UserName = "speditor",
                Email = "speditor@example.com",
                Id = "2e8be95a-186e-403b-b4aa-3874750a3563",
                EmailConfirmed = true
            };
            SpeditorUser.PasswordHash = hasher.HashPassword(SpeditorUser, "speditor");
        }

        private void SeedRoles()
        {
            ClientCompanyRole = new IdentityRole
            {
                Id = "5d000e64-c056-419a-950f-1992bd1e910d", 
                Name = "ClientCompany",
                NormalizedName = "CLIENTCOMPANY"
            };

            LogisticsCompanyRole = new IdentityRole
            {
                Id = "99027aaa-d346-4dd9-a467-15d74576c080", 
                Name = "LogisticsCompany",
                NormalizedName = "LOGISTICSCOMPANY"
            };

            AccountRole = new IdentityRole
            {
                Id = "20ddc22c-ca6d-4feb-a688-0f31a430b5eb", 
                Name = "Accountant",
                NormalizedName = "ACCOUNTANT"
            };

            SpeditorRole = new IdentityRole
            {
                Id = "27609f35-fbc8-4dc4-9d12-7ff2dd400327", 
                Name = "Speditor",
                NormalizedName = "SPEDITOR"
            };
        }
        private void SeedUserRoles()
        {
            ClientCompanyUserRole = new IdentityUserRole<string>
            {
                UserId = "20450cff-816f-49c8-9546-1c603aec0301", 
                RoleId = "5d000e64-c056-419a-950f-1992bd1e910d" 
            };

            LogisticsCompanyUserRole = new IdentityUserRole<string>
            {
                UserId = "6bab54d5-5a88-4128-92d2-4d12ad0baa32", 
                RoleId = "99027aaa-d346-4dd9-a467-15d74576c080"  
            };

            AccountantUserRole = new IdentityUserRole<string>
            {
                UserId = "38ba6810-2800-4ac8-b005-5c27e8248951", 
                RoleId = "20ddc22c-ca6d-4feb-a688-0f31a430b5eb" 
            };

            SpeditorUserRole = new IdentityUserRole<string>
            {
                UserId = "2e8be95a-186e-403b-b4aa-3874750a3563", 
                RoleId = "27609f35-fbc8-4dc4-9d12-7ff2dd400327"  
            };
        }
        private void SeedClientCompanies()
        {
            ClientCompany1 = new ClientCompany
            {
                Id = 1,
                Name = "Client Company 1",
                UserId = ClientCompany1User.Id,
                RegistrationStatus = "Approved",
                ContactPerson = "John Doe",
                AlternativePhoneNumber = "1234567891",
                RegistrationNumber = "REG123456",
                Industry = "Manufacturing",
                Street = "Sini kamani 28",
                City = "Sliven",
                PostalCode = "8800",
                Country = "Bulgaria"
            };

            ClientCompany2 = new ClientCompany
            {
                Id = 2,
                Name = "Client Company 2",
                RegistrationStatus = "Rejected",
                ContactPerson = "Jane Smith",
                AlternativePhoneNumber = "9876543210",
                RegistrationNumber = "REG654321",
                Industry = "Fashion",
                Street = "Osogovo 5a",
                City = "Sofia",
                PostalCode = "1000",
                Country = "Bulgaria"
            };
        }
        private void SeedRequests()
        {
            Request1 = new Request()
            {
                Id = 1,
                ClientCompanyId = 1,
                CargoType = "Standard",
                TypeOfPallet = "Euro",
                NumberOfPallets = 10,
                PalletLength = 120,
                PalletWidth = 80,
                PalletHeight = 144,
                PalletVolume = 1.3824, 
                WeightOfPallets = 500, 
                PalletsAreStackable = true,
                TypeOfGoods = "Electronics",
                Type = "International",
                PickupLatitude = 42.6812,  
                PickupLongitude = 26.3187, 
                DeliveryLatitude = 48.8566, 
                DeliveryLongitude = 2.3522,
                SharedTruck = false,
                ApproximatePrice = 2000.00M,
                CalculatedPrice = 2100.00M,
                ExpectedDeliveryDate = new DateTime(2024, 11, 1),
                Status = "Approved",
                SpecialInstructions = "Handle with care",
                IsRefrigerated = true,
                CreatedAt = DateTime.Now
            };

            Request2 = new Request()
            {
                Id = 2,
                ClientCompanyId = 1,
                CargoType = "Standard",
                TypeOfPallet = "Euro",
                NumberOfPallets = 15,
                PalletLength = 120,
                PalletWidth = 80,
                PalletHeight = 160,
                PalletVolume = 1.536, 
                WeightOfPallets = 750,
                PalletsAreStackable = true,
                TypeOfGoods = "Food Products",
                Type = "Domestic",
                PickupLatitude = 42.6812, 
                PickupLongitude = 26.3187, 
                DeliveryLatitude = 42.6977, 
                DeliveryLongitude = 23.3219, 
                SharedTruck = false,
                ApproximatePrice = 1500.00M,
                CalculatedPrice = 1550.00M,
                ExpectedDeliveryDate = new DateTime(2024, 11, 5),
                Status = "pending",
                SpecialInstructions = "Keep refrigerated",
                IsRefrigerated = true,
                CreatedAt = DateTime.Now
            };

            Request3 = new Request()
            {
                Id = 3,
                ClientCompanyId = 1,
                CargoType = "Standard",
                TypeOfPallet = "Industrial",
                NumberOfPallets = 8,
                PalletLength = 120,
                PalletWidth = 100,
                PalletHeight = 150,
                PalletVolume = 1.8,
                WeightOfPallets = 400,
                PalletsAreStackable = false,
                TypeOfGoods = "Furniture",
                Type = "International",
                PickupLatitude = 42.6812,  
                PickupLongitude = 26.3187, 
                DeliveryLatitude = 48.2082, 
                DeliveryLongitude = 16.3738, 
                SharedTruck = true,
                ApproximatePrice = 1800.00M,
                CalculatedPrice = 1850.00M,
                ExpectedDeliveryDate = new DateTime(2024, 11, 10),
                Status = "Pending",
                SpecialInstructions = "Use soft padding",
                IsRefrigerated = false,
                CreatedAt = DateTime.Now
            };

            Request4 = new Request()
            {
                Id = 4,
                ClientCompanyId = 1,
                CargoType = "Standard",
                TypeOfPallet = "Industrial",
                NumberOfPallets = 12,
                PalletLength = 120,
                PalletWidth = 100,
                PalletHeight = 130,
                PalletVolume = 1.56, 
                WeightOfPallets = 600,
                PalletsAreStackable = true,
                TypeOfGoods = "Machinery Parts",
                Type = "Domestic",
                PickupLatitude = 42.6812,  
                PickupLongitude = 26.3187, 
                DeliveryLatitude = 43.8356,  
                DeliveryLongitude = 25.9657, 
                SharedTruck = true,
                ApproximatePrice = 1700.00M,
                CalculatedPrice = 1750.00M,
                ExpectedDeliveryDate = new DateTime(2024, 11, 15),
                Status = "Pending",
                IsRefrigerated = false,
                SpecialInstructions = "Avoid moisture",
                CreatedAt = DateTime.Now
            };
        }
        private void SeedOffers()
        {
            OfferForRequest1 = new Offer
            {
                Id = 1,
                RequestId = 1,
                FinalPrice = 4800m,
                OfferStatus = "Accepted",
                OfferDate = DateTime.UtcNow.AddDays(-1),
                Notes = "Confirmed by client"
            };
        }
        private void SeedInvoices()
        {
            InvoiceForOfferForRequest1 = new Invoice
            {
                Id = 1,
                OfferId = OfferForRequest1.Id,
                InvoiceNumber = "INV-2024-0001",
                InvoiceDate = DateTime.UtcNow
            };
        }
        private void SeedDrivers()
        {
            Driver1ForDelivery = new Driver
            {
                Id = 1,
                Name = "Paul Smith",
                LicenseNumber = "DL123456",
                LicenseExpiryDate = DateTime.UtcNow.AddYears(2),
                UserId = SpeditorUser.Id,
                Salary = 3000m,
                Age = 35,
                YearOfExperience = 10,
                MonthsOfExperience = 6,
                IsAvailable = false,
                Preferrences = "Long-distance deliveries"
            };

            Driver2 = new Driver
            {
                Id = 2,
                Name = "Mark Driver",
                LicenseNumber = "DL654321",
                LicenseExpiryDate = DateTime.UtcNow.AddYears(3),
                UserId = SecretaryUser.Id,
                Salary = 2800m,
                Age = 32,
                YearOfExperience = 8,
                MonthsOfExperience = 4,
                IsAvailable = true,
                Preferrences = "Short-distance deliveries"
            };
        }
        private void SeedVehicles()
        {
            Vehicle1ForDelivery = new Vehicle
            {
                Id = 1,
                RegistrationNumber = "BG1234RE",
                VehicleType = "Refrigerated Truck",
                Length = 7.5,
                Width = 2.5,
                Height = 2.6,
                Volume = 48.75,
                EuroPalletCapacity = 10,
                IndustrialPalletCapacity = 8,
                ArePalletsStackable = true,
                MaxWeightCapacity = 10_000,
                FuelConsumptionPer100Km = 28.5,
                VehicleStatus = "Not Available",
                LastYearMaintenance = new DateTime(2024, 8, 1),
            };

            Vehicle2 = new Vehicle
            {
                Id = 2,
                RegistrationNumber = "BG5678TT",
                VehicleType = "Tent Truck",
                Length = 13.6,
                Width = 2.5,
                Height = 2.7,
                Volume = 91.8,
                EuroPalletCapacity = 33,
                IndustrialPalletCapacity = 26,
                ArePalletsStackable = true,
                MaxWeightCapacity = 24_000,
                FuelConsumptionPer100Km = 32.0,
                VehicleStatus = "Available",
                LastYearMaintenance = new DateTime(2023, 01, 15),
            };
        }
        private void SeedDeliveries()
        {
            DeliveryForOfferForRequest1 = new Delivery
            {
                Id = 1,
                OfferId = 1,
                VehicleId = 1, 
                DriverId = 1, 
                Status = "In Progress",
                TotalExpenses = 500m,
                Profit = 4300m,
                ReferenceNumber = "REF-2024-0001"
            };
        }     
        private void SeedCashRegisters()
        {
            CashRegisterForDriver1 = new CashRegister
            {
                Id = 1,
                DeliveryId = DeliveryForOfferForRequest1.Id,
                Description = "Fuel cost",
                Type = "Expense",
                Amount = 200m,
                DateSubmitted = DateTime.UtcNow
            };

            CashRegisterForVehicle1 = new CashRegister
            {
                Id = 2,
                DeliveryId = DeliveryForOfferForRequest1.Id,
                Description = "Toll fee",
                Type = "Expense",
                Amount = 50m,
                DateSubmitted = DateTime.UtcNow
            };
        }
        public void SeedPricesPerSize()
        {
            PricesForVehicle1 = new PricesPerSize
            {
                Id = 1,
                VehicleId = 1, 
                DomesticPriceForNotSharedTruck = 500m,   
                DomesticPriceForSharedTruck = 300m,      
                InternationalPriceForNotSharedTruck = 1000m, 
                InternationalPriceForSharedTruck = 700m,     
            };

            
            PricesForVehicle2 = new PricesPerSize
            {
                Id = 2,
                VehicleId = 2, 
                DomesticPriceForNotSharedTruck = 550m,
                DomesticPriceForSharedTruck = 320m,
                InternationalPriceForNotSharedTruck = 1050m,
                InternationalPriceForSharedTruck = 750m,
            };
        }
    }
}

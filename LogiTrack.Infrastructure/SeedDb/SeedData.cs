using LogisticsSystem.Infrastructure.Data.DataModels;
using LogiTrack.Infrastructure.Data.DataModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LogiTrack.Infrastructure.SeedDb
{
    public class SeedData
    {
        public IdentityUser ClientCompany1User { get; set; } = null!;
        public IdentityUser LogiticsCompanyUser { get; set; } = null!;
        public IdentityUser SecretaryUser { get; set; } = null!;
        public IdentityUser SpeditorUser { get; set; } = null!;
        public IdentityUser DriverUser1 { get; set; } = null!;
        public IdentityUser DriverUser2 { get; set; } = null!;

        public IdentityRole ClientCompanyRole { get; set; } = null!;
        public IdentityRole LogisticsCompanyRole { get; set; } = null!;
        public IdentityRole AccountRole { get; set; } = null!;
        public IdentityRole SpeditorRole { get; set; } = null!;
        public IdentityRole DriverRole { get; set; } = null!;

        public IdentityUserRole<string> ClientCompanyUserRole { get; set; } = null!;
        public IdentityUserRole<string> LogisticsCompanyUserRole { get; set; } = null!;
        public IdentityUserRole<string> AccountantUserRole { get; set; } = null!;
        public IdentityUserRole<string> SpeditorUserRole { get; set; } = null!;
        public IdentityUserRole<string> Driver1UserRole { get; set; } = null!;
        public IdentityUserRole<string> Driver2UserRole { get; set; } = null!;

        public ClientCompany ClientCompany1 { get; set; } = null!;
        public ClientCompany ClientCompany2 { get; set; } = null!;
        public StandartCargo StandartCargo1 { get; set; } = null!;
        public StandartCargo StandartCargo2 { get; set; } = null!;
        public StandartCargo StandartCargo3 { get; set; } = null!;
        public NonStandardCargo NonStandardCargo1 { get; set; } = null!;
        public NonStandardCargo NonStandardCargo2 { get; set; } = null!;
        public NonStandardCargo NonStandardCargo3 { get; set; } = null!;
        public NonStandardCargo NonStandardCargo4 { get; set; } = null!;
        public Request Request1 { get; set; } = null!;
        public Request Request2 { get; set; } = null!;
        public Request Request3 { get; set; } = null!;
        public Request Request4 { get; set; } = null!;
        public Request Request5 { get; set; } = null!;


        public Offer Offer1 { get; set; } = null!;
        public Offer Offer2 { get; set; } = null!;
        public Offer Offer3 { get; set; } = null!;
        public Offer Offer4 { get; set; } = null!;
        public Offer Offer5 { get; set; } = null!;
        public Vehicle Vehicle1 { get; set; } = null!;
        public Vehicle Vehicle2 { get; set; } = null!;
        public PricesPerSize PricesPerSize1{ get; set; } = null!;
        public PricesPerSize PricesPerSize2 { get; set; } = null!;     
        public Driver Driver1 { get; set; } = null!;
        public Driver Driver2 { get; set; } = null!;

        public Delivery Delivery1 { get; set; } = null!;
        public Delivery Delivery2 { get; set; } = null!;
        public Delivery Delivery3 { get; set; } = null!;
        public Delivery Delivery4 { get; set; } = null!;
        public Delivery Delivery5 { get; set; } = null!;

        public FuelPrice FuelPrice1 { get; set; } = null!;
        public FuelPrice FuelPrice2 { get; set; } = null!;

        public CashRegister CashRegister1 { get; set; } = null!;
        public CashRegister CashRegister2 { get; set; } = null!;
        public CashRegister CashRegister3 { get; set; } = null!;
        public CashRegister CashRegister4 { get; set; } = null!;
        public CashRegister CashRegister5 { get; set; } = null!;
        public CashRegister CashRegister6 { get; set; } = null!;

        public Invoice Invoice1 { get; set; } = null!;
        public Invoice Invoice2 { get; set; } = null!;
        public Invoice Invoice3 { get; set; } = null!;
        public Invoice Invoice4 { get; set; } = null!;
        public Invoice Invoice5 { get; set; } = null!;
       
        public DeliveryTracking DeliveryTracking1 { get; set; } = null!;
        public DeliveryTracking DeliveryTracking2 { get; set; } = null!;
        public DeliveryTracking DeliveryTracking3 { get; set; } = null!;
        public DeliveryTracking DeliveryTracking4 { get; set; } = null!;
        public DeliveryTracking DeliveryTracking5 { get; set; } = null!;

        public CalendarEvent CalendarEvent1 { get; set; } = null!;
        public CalendarEvent CalendarEvent2 { get; set; } = null!;
        public CalendarEvent CalendarEvent3 { get; set; } = null!;

        public SeedData()
        {
            SeedUsers();
            SeedRoles();
            SeedUserRoles();
            SeedClientCompanies();
                    
            SeedRequests();
            SeedStandartCargos();
            SeedNonStandartCargos();
            SeedOffers();      
            SeedDrivers();
            SeedVehicles();
            SeedDeliveries();
            SeedFuelPrices();
            SeedInvoices();
            SeedCashRegisters();
            SeedPricesPerSize();
            SeedDeliveryTrackings();
            SeedCalendarEvents();
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

            DriverUser1 = new IdentityUser
            {
                Id = "driverUser1", 
                UserName = "driver1@example.com",
                NormalizedUserName = "DRIVER1@EXAMPLE.COM",
                Email = "driver1@example.com",
                NormalizedEmail = "DRIVER1@EXAMPLE.COM",
                EmailConfirmed = true
            };
            DriverUser1.PasswordHash = hasher.HashPassword(DriverUser1, "driver1");
            DriverUser2 = new IdentityUser
            {
                Id = "driverUser2",
                UserName = "driver2@example.com",
                NormalizedUserName = "DRIVER2@EXAMPLE.COM",
                Email = "driver2@example.com",
                NormalizedEmail = "DRIVER2@EXAMPLE.COM",
                EmailConfirmed = true,
            };
            DriverUser1.PasswordHash = hasher.HashPassword(DriverUser1, "driver2");
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
            DriverRole = new IdentityRole
            {
                Id = "350868c0-bf0f-4f70-b4c9-155351bc6429",
                Name = "Driver",
                NormalizedName = "DRIVER"
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

            Driver1UserRole = new IdentityUserRole<string>
            {
                UserId = "driverUser1",
                RoleId = "350868c0-bf0f-4f70-b4c9-155351bc6429"
            };
            Driver2UserRole = new IdentityUserRole<string>
            {
                UserId = "driverUser2",
                RoleId = "350868c0-bf0f-4f70-b4c9-155351bc6429"
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
                CreatedAt = DateTime.Now.AddDays(-20),
                Country = "Bulgaria"
            };

            ClientCompany2 = new ClientCompany
            {
                Id = 2,
                Name = "Client Company 2",
                RegistrationStatus = "Pending",
                ContactPerson = "Jane Smith",
                AlternativePhoneNumber = "9876543210",
                RegistrationNumber = "REG654321",
                Industry = "Fashion",
                Street = "Osogovo 5a",
                City = "Sofia",
                PostalCode = "1000",
                CreatedAt = DateTime.Now.AddDays(-10),
                Country = "Bulgaria"
            };
        }
       
        private void SeedRequests()
        {          
            Request1 = new Request
            {
                Id = 1,
                ClientCompanyId = 1,
                CargoType = "Standard",
                TypeOfGoods = "Electronics",
                Type = "Domestic",
                PickupAddress = "123 Pickup St.",
                PickupLatitude = 42.6977,
                PickupLongitude = 23.3219,
                DeliveryAddress = "456 Delivery St.",
                DeliveryLatitude = 42.6977,
                DeliveryLongitude = 23.3219,
                SharedTruck = false,
                ApproximatePrice = 500,
                CalculatedPrice = 450,
                ExpectedDeliveryDate = DateTime.Now.AddDays(7),
                Status = "Pending",
                SpecialInstructions = "Handle with care",
                IsRefrigerated = false,
                CreatedAt = DateTime.Now,
                //StandartCargoId = 1,
                TotalWeight = 300,
                TotalVolume = 12,
                Kilometers = 500
            };

        Request2 = new Request
        {
            Id = 2,
            ClientCompanyId = 1,
            CargoType = "Standard",
            TypeOfGoods = "Furniture",
            Type = "International",
            PickupAddress = "789 Pickup Ave.",
            PickupLatitude = 40.7128,
            PickupLongitude = -74.0060,
            DeliveryAddress = "123 Delivery Ave.",
            DeliveryLatitude = 41.8781,
            DeliveryLongitude = -87.6298,
            SharedTruck = true,
            ApproximatePrice = 1200,
            CalculatedPrice = 1150,
            ExpectedDeliveryDate = DateTime.Now.AddDays(10),
            Status = "Accepted",
            SpecialInstructions = "Keep dry",
            IsRefrigerated = false,
            CreatedAt = DateTime.Now,
            //StandartCargoId = 2,
            TotalWeight = 500,
            TotalVolume = 20,
            Kilometers = 1000
        };

        Request3 = new Request
        {
            Id = 3,
            ClientCompanyId = 1,
            CargoType = "Non-Standard",
            TypeOfGoods = "Machinery",
            Type = "Domestic",
            PickupAddress = "15 Industrial Blvd.",
            PickupLatitude = 34.0522,
            PickupLongitude = -118.2437,
            DeliveryAddress = "25 Factory Rd.",
            DeliveryLatitude = 36.7783,
            DeliveryLongitude = -119.4179,
            SharedTruck = false,
            ApproximatePrice = 2000,
            CalculatedPrice = 1900,
            ExpectedDeliveryDate = DateTime.Now.AddDays(15),
            Status = "Pending",
            SpecialInstructions = "Requires crane",
            IsRefrigerated = false,
            CreatedAt = DateTime.Now,
            TotalWeight = 2000,
            TotalVolume = 50,
            Kilometers = 2000
        };

        Request4  = new Request
        {
            Id = 4,
            ClientCompanyId = 1,
            CargoType = "Standard",
            TypeOfGoods = "Textiles",
            Type = "Domestic",
            PickupAddress = "Market Square 9",
            PickupLatitude = 33.7490,
            PickupLongitude = -84.3880,
            DeliveryAddress = "Warehouse 23",
            DeliveryLatitude = 34.7465,
            DeliveryLongitude = -92.2896,
            SharedTruck = true,
            ApproximatePrice = 350,
            CalculatedPrice = 340,
            ExpectedDeliveryDate = DateTime.Now.AddDays(3),
            Status = "Pending",
            SpecialInstructions = "Do not compress",
            IsRefrigerated = false,
            CreatedAt = DateTime.Now,
            //StandartCargoId = 3,
            TotalWeight = 150,
            TotalVolume = 8,
            Kilometers = 500
        };

        Request5 = new Request
        {
            Id = 5,
            ClientCompanyId = 1,
            CargoType = "Standard",
            TypeOfGoods = "Books",
            Type = "International",
            PickupAddress = "Library Lane",
            PickupLatitude = 40.7128,
            PickupLongitude = -74.0060,
            DeliveryAddress = "Learning Center",
            DeliveryLatitude = 38.9072,
            DeliveryLongitude = -77.0369,
            SharedTruck = false,
            ApproximatePrice = 220,
            CalculatedPrice = 210,
            ExpectedDeliveryDate = DateTime.Now.AddDays(4),
            Status = "Pending",
            SpecialInstructions = "Fragile binding",
            IsRefrigerated = false,
            CreatedAt = DateTime.Now,
            //StandartCargoId = 4,
            TotalWeight = 300,
            TotalVolume = 1.8,
            Kilometers = 1000
        };
    }
        private void SeedStandartCargos()
        {
            StandartCargo1 = new StandartCargo
            {
                Id = 1,
                RequestId = 1,
                TypeOfPallet = "Euro",
                NumberOfPallets = 5,
                PalletLength = 120,
                PalletWidth = 80,
                PalletHeight = 100,
                PalletVolume = 0.96,
                WeightOfPallets = 500,
                PalletsAreStackable = true
            };

            StandartCargo2 = new StandartCargo
            {
                Id = 2,
                RequestId = 2,
                TypeOfPallet = "Industrial",
                NumberOfPallets = 3,
                PalletLength = 130,
                PalletWidth = 90,
                PalletHeight = 110,
                PalletVolume = 1.29,
                WeightOfPallets = 700,
                PalletsAreStackable = false
            };

            StandartCargo3 = new StandartCargo
            {
                Id = 3,
                RequestId = 4,
                TypeOfPallet = "Standard",
                NumberOfPallets = 4,
                PalletLength = 120,
                PalletWidth = 80,
                PalletHeight = 100,
                PalletVolume = 0.96,
                WeightOfPallets = 450,
                PalletsAreStackable = true
            };
        }

        private void SeedNonStandartCargos()
        {
            NonStandardCargo1 = new NonStandardCargo
            { 
                Id = 1,
                Length = 120,
                Width = 100,
                Height = 150,
                Volume = 1.8,
                Weight = 300,
                Description = "Large industrial machine",
                RequestId = 3
            };

            NonStandardCargo2 = new NonStandardCargo
            {
                Id = 2,
                Length = 90,
                Width = 75,
                Height = 80,
                Volume = 0.6,
                Weight = 120,
                Description = "Auxiliary machine part",
                RequestId = 3
            };

            NonStandardCargo3 = new NonStandardCargo
            {
                Id = 3,
                Length = 150,
                Width = 80,
                Height = 100,
                Volume = 1.2,
                Weight = 450,
                Description = "High-pressure pump",
                RequestId = 3
            };
            NonStandardCargo4 = new NonStandardCargo
            {
                Id = 4,
                RequestId = Request5.Id,  
                Length = 150,            
                Width = 120,              
                Height = 100,             
                Volume = 1.8,             
                Weight = 300,             
                Description = "Extra non-standard cargo for Request5"
            };
        }
        private void SeedOffers()
        {
            Offer1 = new Offer
            {
                Id = 1,
                RequestId = 1, 
                FinalPrice = 1200.0m,
                OfferStatus = "Pending",
                OfferDate = DateTime.Now.AddDays(-10),
                Notes = "Initial offer for Request 1",
            };
            Offer2 = new Offer
            {
                Id = 2,
                RequestId = 2, 
                FinalPrice = 1500.0m,
                OfferStatus = "Approved",
                OfferDate = DateTime.Now.AddDays(-8),
                Notes = "Offer accepted for Request 2",
            };
            Offer3 = new Offer
            {
                Id = 3,
                RequestId = 3,
                FinalPrice = 1800.0m,
                OfferStatus = "Approved",
                OfferDate = DateTime.Now.AddDays(-5),
                Notes = "Offer approved for Request 3",
                DeliveryId = null
            };
            Offer4 = new Offer
            {
                Id = 4,
                RequestId = 4, 
                FinalPrice = 2100.0m,
                OfferStatus = "Approved",
                OfferDate = DateTime.Now.AddDays(-2),
                Notes = "Approved offer for Request 4",

            };
            Offer5 = new Offer
            {
                Id = 5,
                RequestId = 5,
                FinalPrice = 2300.0m,
                OfferStatus = "Accepted",
                OfferDate = DateTime.Now,
                Notes = "Finalized offer for Request 5",

            };
        }
        private void SeedDrivers()
        {
            Driver1 = new Driver
            {
                Id = 1,
                Name = "John Doe",
                LicenseNumber = "D12345678",
                LicenseExpiryDate = DateTime.Now.AddYears(1),
                UserId = "driverUser1",
                Salary = 3000.0m,
                Age = 30,
                YearOfExperience = 5,
                MonthsOfExperience = 6,
                IsAvailable = true,
                Preferrences = "No night shifts"
            };
            Driver2 = new Driver
            {
                Id = 2,
                Name = "Jane Smith",
                LicenseNumber = "D87654321",
                LicenseExpiryDate = DateTime.Now.AddYears(1),
                UserId = "driverUser2",
                Salary = 3200.0m,
                Age = 28,
                YearOfExperience = 4,
                MonthsOfExperience = 8,
                IsAvailable = false,
                Preferrences = "Prefers city deliveries"
            };
        }
        private void SeedVehicles()
        {
            Vehicle1 = new Vehicle
            {
                Id = 1,
                RegistrationNumber = "ABC123",
                VehicleType = "Truck",
                Length = 12.0,
                Width = 2.5,
                Height = 2.8,
                Volume = 84.0,
                EuroPalletCapacity = 33,
                IndustrialPalletCapacity = 20,
                ArePalletsStackable = true,
                MaxWeightCapacity = 18000,
                FuelConsumptionPer100Km = 12.5,
                VehicleStatus = "Available",
                LastYearMaintenance = DateTime.Now.AddMonths(-3),
                KilometersDriven = 150000,
                KilometersLeftToChangeParts = 50000,
                PurchasePrice = 75000.0m,
                ContantsExpenses = 5000.0m
            };
            Vehicle2 = new Vehicle
            {
                Id = 2,
                RegistrationNumber = "XYZ789",
                VehicleType = "Van",
                Length = 6.0,
                Width = 2.0,
                Height = 2.5,
                Volume = 30.0,
                EuroPalletCapacity = 10,
                IndustrialPalletCapacity = 8,
                ArePalletsStackable = false,
                MaxWeightCapacity = 3500,
                FuelConsumptionPer100Km = 8.0,
                VehicleStatus = "Available",
                LastYearMaintenance = DateTime.Now.AddMonths(-1),
                KilometersDriven = 90000,
                KilometersLeftToChangeParts = 30000,
                PurchasePrice = 25000.0m,
                ContantsExpenses = 2000.0m
            };
        }
        private void SeedDeliveries()
         {
            Delivery1 = new Delivery
            {
                Id = 1,
                VehicleId = 1,
                DriverId = 1,
                OfferId = 1,
                Status = "In Transit",
                TotalExpenses = 500.00m,
                Profit = 750.00m,
                ReferenceNumber = "DEL0001",
                DeliveryStep = 2,
                ActualDeliveryDate = DateTime.Now.AddDays(-1)
            };
            Delivery2 = new Delivery
            {
                Id = 2,
                VehicleId = 1,
                DriverId = 1,
                OfferId = 2,
                Status = "Booked",
                TotalExpenses = 450.00m,
                Profit = 700.00m,
                ReferenceNumber = "DEL0002",
                DeliveryStep = 1,
                ActualDeliveryDate = DateTime.Now.AddDays(-2)
            };
            Delivery3 = new Delivery
            {
                Id = 3,
                VehicleId = 1,
                DriverId = 1,
                OfferId = 3,
                Status = "Delivered",
                TotalExpenses = 600.00m,
                Profit = 800.00m,
                ReferenceNumber = "DEL0003",
                DeliveryStep = 4,
                ActualDeliveryDate = DateTime.Now.AddDays(-3)
            };
            Delivery4 = new Delivery
            {
                Id = 4,
                VehicleId = 1,
                DriverId = 1,
                OfferId = 4,
                Status = "In Transit",
                TotalExpenses = 520.00m,
                Profit = 780.00m,
                ReferenceNumber = "DEL0004",
                DeliveryStep = 2,
                ActualDeliveryDate = DateTime.Now.AddDays(-4)
            };
            Delivery5 = new Delivery
            {
                Id = 5,
                VehicleId = 1,
                DriverId = 1,
                OfferId = 5,
                Status = "Booked",
                TotalExpenses = 480.00m,
                Profit = 720.00m,
                ReferenceNumber = "DEL0005",
                DeliveryStep = 3,
                ActualDeliveryDate = DateTime.Now.AddDays(-5)

            };
         }
         private void SeedInvoices()
         {
            Invoice1 = new Invoice
            {
                Id = 1,
                DeliveryId = 1,
                InvoiceNumber = "INV001",
                InvoiceDate = DateTime.Now.AddDays(-10),
                Description = "Invoice for Delivery 1",
                IsPaid = true 
            };
            Invoice2 = new Invoice
            {
                Id = 2,
                DeliveryId = 2,
                InvoiceNumber = "INV002",
                InvoiceDate = DateTime.Now.AddDays(-9),
                Description = "Invoice for Delivery 2",
                IsPaid = false 
            };
            Invoice3 = new Invoice
            {
                Id = 3,
                DeliveryId = 3,
                InvoiceNumber = "INV003",
                InvoiceDate = DateTime.Now.AddDays(-8),
                Description = "Invoice for Delivery 3",
                IsPaid = true 
            };
            Invoice4 = new Invoice
            {
                Id = 4,
                DeliveryId = 4,
                InvoiceNumber = "INV004",
                InvoiceDate = DateTime.Now.AddDays(-7),
                Description = "Invoice for Delivery 4",
                IsPaid = false
            };
            Invoice5 = new Invoice
            {
            Id = 5,
            DeliveryId = 5,
            InvoiceNumber = "INV005",
            InvoiceDate = DateTime.Now.AddDays(-6),
            Description = "Invoice for Delivery 5",
            IsPaid = true 
            };
         }
         private void SeedCashRegisters()
         {
            CashRegister1 = new CashRegister
            {
                Id = 1,
                DeliveryId = 1,
                Description = "Fuel Expense",
                Type = "Vehicle Expenses",
                Amount = 100.00m,
                DateSubmitted = DateTime.Now.AddDays(-5)
            };
            CashRegister2 = new CashRegister
            {
                Id = 2,
                DeliveryId = 1,
                Description = "Toll Fee",
                Type = "Vehicle Expenses",
                Amount = 50.00m,
                DateSubmitted = DateTime.Now.AddDays(-4)
            };
            CashRegister3 = new CashRegister
            {
                Id = 3,
                DeliveryId = 2,
                Description = "Driver Lunch",
                Type = "Driver Expenses",
                Amount = 20.00m,
                DateSubmitted = DateTime.Now.AddDays(-3)

            };
            CashRegister4 = new CashRegister
            {
                Id = 4,
                DeliveryId = 3,
                Description = "Repair Costs",
                Type = "Vehicle Expenses",
                Amount = 150.00m,
                DateSubmitted = DateTime.Now.AddDays(-2)
            };
            CashRegister5 = new CashRegister
            {
                Id = 5,
                DeliveryId = 4,
                Description = "Accommodation",
                Type = "Driver Expenses",
                Amount = 80.00m,
                DateSubmitted = DateTime.Now.AddDays(-1)
            };
            CashRegister6 = new CashRegister
            {
                Id = 6,
                DeliveryId = 5,
                Description = "Miscellaneous",
                Type = "Other Expenses",
                Amount = 40.00m,
                DateSubmitted = DateTime.Now
            };
         }
        public void SeedPricesPerSize()
        {
            PricesPerSize1 = new PricesPerSize
            {
                Id = 1,
                VehicleId = 1, 
                QuotientForDomesticNotSharedTruck = 1.2,
                QuotientForDomesticSharedTruck = 0.9,
                QuotientForInternationalNotSharedTruck = 1.5,
                QuotientForInternationalSharedTruck = 1.1,
                DomesticPriceForNotSharedTruck = 1000.0m,
                DomesticPriceForSharedTruck = 800.0m,
                InternationalPriceForNotSharedTruck = 1500.0m,
                InternationalPriceForSharedTruck = 1200.0m
            };
            PricesPerSize2 = new PricesPerSize
            {
                Id = 2,
                VehicleId = 2,
                QuotientForDomesticNotSharedTruck = 1.3,
                QuotientForDomesticSharedTruck = 0.85,
                QuotientForInternationalNotSharedTruck = 1.6,
                QuotientForInternationalSharedTruck = 1.2,
                DomesticPriceForNotSharedTruck = 1100.0m,
                DomesticPriceForSharedTruck = 850.0m,
                InternationalPriceForNotSharedTruck = 1600.0m,
                InternationalPriceForSharedTruck = 1300.0m
            };
        }
        private void SeedFuelPrices()
        {
            FuelPrice1 = new FuelPrice
            {
                Id = 1,
                Price = 2.50m,
                Date = DateTime.Now.AddDays(-3)
            };
            FuelPrice2 = new FuelPrice
            {
                Id = 2,
                Price = 2.60m,
                Date = DateTime.Now.AddDays(-2)
            };
        }
        public void SeedDeliveryTrackings()
        {
            DeliveryTracking1 = new DeliveryTracking
            {
                Id = 1,
                DeliveryId = 1,
                DriverId = 1,
                StatusUpdate = "Delivered",
                Notes = "Delivery completed successfully.",
                Timestamp = DateTime.Now.AddDays(-5),
                Latitude = 42.6977, 
                Longitude = 23.3219,
                Address = "Sofia, Bulgaria"
            };
            DeliveryTracking2 = new DeliveryTracking
            {
                Id = 2,
                DeliveryId = 2,
                DriverId = 1,
                StatusUpdate = "Booked",
                Notes = "Delivery scheduled.",
                Timestamp = DateTime.Now.AddDays(-4),
                Latitude = 43.2141,
                Longitude = 27.9147,
                Address = "Varna, Bulgaria"
            };
            DeliveryTracking3 = new DeliveryTracking
            {
                Id = 3,
                DeliveryId = 3,
                DriverId = 1,
                StatusUpdate = "Delivered",
                Notes = "Delivered on time.",
                Timestamp = DateTime.Now.AddDays(-3),
                Latitude = 42.1354,
                Longitude = 24.7453,
                Address = "Plovdiv, Bulgaria"
            };
            DeliveryTracking4 = new DeliveryTracking
            {
                Id = 4,
                DeliveryId = 4,
                DriverId = 1,
                StatusUpdate = "Delivered",
                Notes = "Awaiting driver assignment.",
                Timestamp = DateTime.Now.AddDays(-2),
                Latitude = 41.6321,
                Longitude = 25.3790,
                Address = "Kardzhali, Bulgaria"
            };
            DeliveryTracking5 = new DeliveryTracking
            {
                Id = 5,
                DeliveryId = 5,
                DriverId = 1,
                StatusUpdate = "Booked",
                Notes = "Package left with neighbor.",
                Timestamp = DateTime.Now.AddDays(-1),
                Latitude = 42.5048,
                Longitude = 27.4626,
                Address = "Burgas, Bulgaria"
            };
        }
        private void SeedCalendarEvents()
        {
            var now = DateTime.UtcNow;

            CalendarEvent1 = new CalendarEvent
            {
                Id = 1,
                Title = "Monthly Payment Due",
                Date = DateTime.Now.AddMonths(-1),
                EventType = "Paid",
                ClientCompanyId = 1
            };
            CalendarEvent2 = new CalendarEvent
            {
                Id = 2,
                Title = "Quarterly Review",
                Date = DateTime.Now.AddMonths(-3),
                EventType = "Paid",
                ClientCompanyId = 1
            };
            CalendarEvent3 = new CalendarEvent
            {
                Id = 3,
                Title = "Annual Delivery Milestone",
                Date = DateTime.Now.AddMonths(-6),
                EventType = "Delivered",
                ClientCompanyId = 1
            };
        }
    }
}

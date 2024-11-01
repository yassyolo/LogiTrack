using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogiTrack.Infrastructure.Migrations
{
    public partial class SeedDataInNewDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "350868c0-bf0f-4f70-b4c9-155351bc6429", "f3b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20ddc22c-ca6d-4feb-a688-0f31a430b5eb",
                column: "ConcurrencyStamp",
                value: "1ad87b54-705e-4d25-b911-b5de37d4fb86");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27609f35-fbc8-4dc4-9d12-7ff2dd400327",
                column: "ConcurrencyStamp",
                value: "a64be1a0-7ef2-4ae2-996c-44fe07634f4c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "350868c0-bf0f-4f70-b4c9-155351bc6429",
                column: "ConcurrencyStamp",
                value: "111ff830-e4b9-4cf0-9002-c929d4209652");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d000e64-c056-419a-950f-1992bd1e910d",
                column: "ConcurrencyStamp",
                value: "c233e827-2dc7-47e5-8b21-829211c66158");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99027aaa-d346-4dd9-a467-15d74576c080",
                column: "ConcurrencyStamp",
                value: "838d3307-e6f5-40b5-92bc-c135573cc0a5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20450cff-816f-49c8-9546-1c603aec0301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1777f374-43f3-4d52-a7cf-35f0bed5b45b", "AQAAAAEAACcQAAAAEJrR4YP0sclQYrYKAjjPHVFYnTh4U+F/LiOU1rI2feas8bs9vituj5H1uI/CiQ0Gjw==", "ee9b26a0-117e-447e-ba6c-f308c2ef2d65" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e8be95a-186e-403b-b4aa-3874750a3563",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "05b135f1-7436-47c1-ab05-d3400fc5aee7", "AQAAAAEAACcQAAAAEL85qk4IcKpq3YVfEfHCXO5fWqLxkxbZlTx+GQ7V17LX+xVMl/C0UYLiP9iZou8xxg==", "3c96ce24-69e0-4cff-aedc-2587749cce83" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38ba6810-2800-4ac8-b005-5c27e8248951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6fe2543c-42a9-4b25-9d30-2a44968b89e8", "AQAAAAEAACcQAAAAEJYETUsjK5RHZgHp6oiHqQNayHu6C18a+m053q1Iqwm0sQ9/SEsRHoR+/t6/YuPF0g==", "afd4caf7-e030-4b7e-8f17-1f1bb8f828f9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6bab54d5-5a88-4128-92d2-4d12ad0baa32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5707bda8-43a5-4d04-87b7-dd2cb2eb7b60", "AQAAAAEAACcQAAAAEATEuEVAp/I+HPDs58b0H2McT4BEeNjROIvXh+66891QPR7ScS5daShs2j0KLn0e7Q==", "a2e9d3db-1707-46bc-be57-2d65e3f95847" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "driverUser1", 0, "c4a1f9b5-c45b-4e09-92f9-d9dea4e2cd71", "driver1@example.com", true, false, null, "DRIVER1@EXAMPLE.COM", "DRIVER1@EXAMPLE.COM", "AQAAAAEAACcQAAAAEFXeeYM2YUs8S+ov8QN4cYhugspiL2lzQmsIrRaAe8xdyQA9kAn+Y++P483wOT5gyA==", null, false, "9b0139c3-ba64-49be-9a5b-a2c8788ec144", false, "driver1@example.com" },
                    { "driverUser2", 0, "bc20c0bc-a30c-43a7-914b-33915a1e155f", "driver2@example.com", true, false, null, "DRIVER2@EXAMPLE.COM", "DRIVER2@EXAMPLE.COM", null, null, false, "70e12973-286c-458d-8639-7a92e40c2006", false, "driver2@example.com" }
                });

            migrationBuilder.InsertData(
                table: "CalendarEvents",
                columns: new[] { "Id", "ClientCompanyId", "Date", "EventType", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 9, 30, 15, 45, 10, 995, DateTimeKind.Local).AddTicks(5173), "Paid", "Monthly Payment Due" },
                    { 2, 1, new DateTime(2024, 7, 31, 15, 45, 10, 995, DateTimeKind.Local).AddTicks(5175), "Paid", "Quarterly Review" },
                    { 3, 1, new DateTime(2024, 4, 30, 15, 45, 10, 995, DateTimeKind.Local).AddTicks(5177), "Delivered", "Annual Delivery Milestone" }
                });

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 11, 15, 45, 9, 177, DateTimeKind.Local).AddTicks(9651));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 21, 15, 45, 9, 177, DateTimeKind.Local).AddTicks(9682));

            migrationBuilder.InsertData(
                table: "FuelPrices",
                columns: new[] { "Id", "Date", "Price" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 28, 15, 45, 10, 989, DateTimeKind.Local).AddTicks(3644), 2.50m },
                    { 2, new DateTime(2024, 10, 29, 15, 45, 10, 989, DateTimeKind.Local).AddTicks(3645), 2.60m }
                });

            migrationBuilder.InsertData(
                table: "Requests",
                columns: new[] { "Id", "ApproximatePrice", "CalculatedPrice", "CargoType", "ClientCompanyId", "CreatedAt", "DeliveryAddress", "DeliveryLatitude", "DeliveryLongitude", "ExpectedDeliveryDate", "IsRefrigerated", "Kilometers", "NumberOfNonStandartGoods", "OfferId", "PickupAddress", "PickupLatitude", "PickupLongitude", "SharedTruck", "SpecialInstructions", "StandartCargoId", "Status", "TotalVolume", "TotalWeight", "Type", "TypeOfGoods" },
                values: new object[,]
                {
                    { 1, 500m, 450m, "Standard", 1, new DateTime(2024, 10, 31, 15, 45, 10, 204, DateTimeKind.Local).AddTicks(5123), "456 Delivery St.", 42.697699999999998, 23.321899999999999, new DateTime(2024, 11, 7, 15, 45, 10, 204, DateTimeKind.Local).AddTicks(5120), false, 500.0, null, null, "123 Pickup St.", 42.697699999999998, 23.321899999999999, false, "Handle with care", 0, "Pending", 12.0, 300.0, "Domestic", "Electronics" },
                    { 2, 1200m, 1150m, "Standard", 1, new DateTime(2024, 10, 31, 15, 45, 10, 204, DateTimeKind.Local).AddTicks(5129), "123 Delivery Ave.", 41.878100000000003, -87.629800000000003, new DateTime(2024, 11, 10, 15, 45, 10, 204, DateTimeKind.Local).AddTicks(5127), false, 1000.0, null, null, "789 Pickup Ave.", 40.712800000000001, -74.006, true, "Keep dry", 0, "Accepted", 20.0, 500.0, "International", "Furniture" },
                    { 3, 2000m, 1900m, "Non-Standard", 1, new DateTime(2024, 10, 31, 15, 45, 10, 204, DateTimeKind.Local).AddTicks(5141), "25 Factory Rd.", 36.778300000000002, -119.4179, new DateTime(2024, 11, 15, 15, 45, 10, 204, DateTimeKind.Local).AddTicks(5139), false, 2000.0, null, null, "15 Industrial Blvd.", 34.052199999999999, -118.2437, false, "Requires crane", 0, "Pending", 50.0, 2000.0, "Domestic", "Machinery" },
                    { 4, 350m, 340m, "Standard", 1, new DateTime(2024, 10, 31, 15, 45, 10, 204, DateTimeKind.Local).AddTicks(5159), "Warehouse 23", 34.746499999999997, -92.289599999999993, new DateTime(2024, 11, 3, 15, 45, 10, 204, DateTimeKind.Local).AddTicks(5158), false, 500.0, null, null, "Market Square 9", 33.749000000000002, -84.388000000000005, true, "Do not compress", 0, "Pending", 8.0, 150.0, "Domestic", "Textiles" },
                    { 5, 220m, 210m, "Standard", 1, new DateTime(2024, 10, 31, 15, 45, 10, 204, DateTimeKind.Local).AddTicks(5169), "Learning Center", 38.907200000000003, -77.036900000000003, new DateTime(2024, 11, 4, 15, 45, 10, 204, DateTimeKind.Local).AddTicks(5167), false, 1000.0, null, null, "Library Lane", 40.712800000000001, -74.006, false, "Fragile binding", 0, "Pending", 1.8, 300.0, "International", "Books" }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "ArePalletsStackable", "ContantsExpenses", "EuroPalletCapacity", "FuelConsumptionPer100Km", "Height", "IndustrialPalletCapacity", "KilometersDriven", "KilometersLeftToChangeParts", "LastYearMaintenance", "Length", "MaxWeightCapacity", "PurchasePrice", "RegistrationNumber", "VehicleStatus", "VehicleType", "Volume", "Width" },
                values: new object[,]
                {
                    { 1, true, 5000.0m, 33, 12.5, 2.7999999999999998, 20, 150000.0, 50000.0, new DateTime(2024, 7, 31, 15, 45, 10, 970, DateTimeKind.Local).AddTicks(8100), 12.0, 18000.0, 75000.0m, "ABC123", "Available", "Truck", 84.0, 2.5 },
                    { 2, false, 2000.0m, 10, 8.0, 2.5, 8, 90000.0, 30000.0, new DateTime(2024, 9, 30, 15, 45, 10, 970, DateTimeKind.Local).AddTicks(8103), 6.0, 3500.0, 25000.0m, "XYZ789", "Available", "Van", 30.0, 2.0 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "350868c0-bf0f-4f70-b4c9-155351bc6429", "driverUser1" },
                    { "350868c0-bf0f-4f70-b4c9-155351bc6429", "driverUser2" }
                });

            migrationBuilder.InsertData(
     table: "Drivers",
     columns: new[] { "Id", "Age", "IsAvailable", "LicenseExpiryDate", "LicenseNumber", "MonthsOfExperience", "Name", "Preferrences", "Salary", "UserId", "YearOfExperience" },
     values: new object[] { 1, 30, true, new DateTime(2025, 10, 31, 15, 45, 10, 224, DateTimeKind.Local).AddTicks(4394), "D12345678", 6, "John Doe", "No night shifts", 3000.0m, "driverUser1", 5 });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "Age", "IsAvailable", "LicenseExpiryDate", "LicenseNumber", "MonthsOfExperience", "Name", "Preferrences", "Salary", "UserId", "YearOfExperience" },
                values: new object[] { 2, 28, false, new DateTime(2025, 10, 31, 15, 45, 10, 224, DateTimeKind.Local).AddTicks(4398), "D87654321", 8, "Jane Smith", "Prefers city deliveries", 3200.0m, "driverUser2", 4 });

            migrationBuilder.InsertData(
                table: "NonStandardCargos",
                columns: new[] { "Id", "Description", "Height", "Length", "RequestId", "Volume", "Weight", "Width" },
                values: new object[,]
                {
                    { 1, "Large industrial machine", 150.0, 120.0, 3, 1.8, 300.0, 100.0 },
                    { 2, "Auxiliary machine part", 80.0, 90.0, 3, 0.59999999999999998, 120.0, 75.0 },
                    { 3, "High-pressure pump", 100.0, 150.0, 3, 1.2, 450.0, 80.0 },
                    { 4, "Extra non-standard cargo for Request5", 100.0, 150.0, 5, 1.8, 300.0, 120.0 }
                });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "ClientCompanyId", "DeliveryId", "FinalPrice", "Notes", "OfferDate", "OfferStatus", "RequestId" },
                values: new object[,]
                {
                    { 1, null, null, 1200.0m, "Initial offer for Request 1", new DateTime(2024, 10, 21, 15, 45, 9, 191, DateTimeKind.Local).AddTicks(4873), "Pending", 1 },
                    { 2, null, null, 1500.0m, "Offer accepted for Request 2", new DateTime(2024, 10, 23, 15, 45, 9, 191, DateTimeKind.Local).AddTicks(4874), "Approved", 2 },
                    { 3, null, null, 1800.0m, "Offer approved for Request 3", new DateTime(2024, 10, 26, 15, 45, 9, 191, DateTimeKind.Local).AddTicks(4876), "Approved", 3 },
                    { 4, null, null, 2100.0m, "Approved offer for Request 4", new DateTime(2024, 10, 29, 15, 45, 9, 191, DateTimeKind.Local).AddTicks(4877), "Approved", 4 },
                    { 5, null, null, 2300.0m, "Finalized offer for Request 5", new DateTime(2024, 10, 31, 15, 45, 9, 191, DateTimeKind.Local).AddTicks(4879), "Accepted", 5 }
                });

            migrationBuilder.InsertData(
                table: "PricesPerSize",
                columns: new[] { "Id", "DomesticPriceForNotSharedTruck", "DomesticPriceForSharedTruck", "InternationalPriceForNotSharedTruck", "InternationalPriceForSharedTruck", "QuotientForDomesticNotSharedTruck", "QuotientForDomesticSharedTruck", "QuotientForInternationalNotSharedTruck", "QuotientForInternationalSharedTruck", "VehicleId" },
                values: new object[,]
                {
                    { 1, 1000.0m, 800.0m, 1500.0m, 1200.0m, 1.2, 0.90000000000000002, 1.5, 1.1000000000000001, 1 },
                    { 2, 1100.0m, 850.0m, 1600.0m, 1300.0m, 1.3, 0.84999999999999998, 1.6000000000000001, 1.2, 2 }
                });

            migrationBuilder.InsertData(
                table: "StandartCargos",
                columns: new[] { "Id", "NumberOfPallets", "PalletHeight", "PalletLength", "PalletVolume", "PalletWidth", "PalletsAreStackable", "RequestId", "TypeOfPallet", "WeightOfPallets" },
                values: new object[,]
                {
                    { 1, 5, 100.0, 120.0, 0.95999999999999996, 80.0, true, 1, "Euro", 500.0 },
                    { 2, 3, 110.0, 130.0, 1.29, 90.0, false, 2, "Industrial", 700.0 },
                    { 3, 4, 100.0, 120.0, 0.95999999999999996, 80.0, true, 4, "Standard", 450.0 }
                });

            migrationBuilder.InsertData(
                table: "Deliveries",
                columns: new[] { "Id", "ActualDeliveryDate", "DeliveryStep", "DriverId", "InvoiceId", "OfferId", "Profit", "ReferenceNumber", "Status", "TotalExpenses", "VehicleId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 30, 15, 45, 10, 964, DateTimeKind.Local).AddTicks(6116), 2, 1, null, 1, 750.00m, "DEL0001", "In Transit", 500.00m, 1 },
                    { 2, new DateTime(2024, 10, 29, 15, 45, 10, 964, DateTimeKind.Local).AddTicks(6121), 1, 1, null, 2, 700.00m, "DEL0002", "Booked", 450.00m, 1 },
                    { 3, new DateTime(2024, 10, 28, 15, 45, 10, 964, DateTimeKind.Local).AddTicks(6124), 4, 1, null, 3, 800.00m, "DEL0003", "Delivered", 600.00m, 1 },
                    { 4, new DateTime(2024, 10, 27, 15, 45, 10, 964, DateTimeKind.Local).AddTicks(6125), 2, 1, null, 4, 780.00m, "DEL0004", "In Transit", 520.00m, 1 },
                    { 5, new DateTime(2024, 10, 26, 15, 45, 10, 964, DateTimeKind.Local).AddTicks(6127), 3, 1, null, 5, 720.00m, "DEL0005", "Booked", 480.00m, 1 }
                });

            migrationBuilder.InsertData(
                table: "CashRegisters",
                columns: new[] { "Id", "Amount", "DateSubmitted", "DeliveryId", "Description", "FileId", "Type" },
                values: new object[,]
                {
                    { 1, 100.00m, new DateTime(2024, 10, 26, 15, 45, 9, 171, DateTimeKind.Local).AddTicks(8725), 1, "Fuel Expense", "", "Vehicle Expenses" },
                    { 2, 50.00m, new DateTime(2024, 10, 27, 15, 45, 9, 171, DateTimeKind.Local).AddTicks(8727), 1, "Toll Fee", "", "Vehicle Expenses" },
                    { 3, 20.00m, new DateTime(2024, 10, 28, 15, 45, 9, 171, DateTimeKind.Local).AddTicks(8728), 2, "Driver Lunch", "", "Driver Expenses" },
                    { 4, 150.00m, new DateTime(2024, 10, 29, 15, 45, 9, 171, DateTimeKind.Local).AddTicks(8755), 3, "Repair Costs", "", "Vehicle Expenses" },
                    { 5, 80.00m, new DateTime(2024, 10, 30, 15, 45, 9, 171, DateTimeKind.Local).AddTicks(8757), 4, "Accommodation", "", "Driver Expenses" },
                    { 6, 40.00m, new DateTime(2024, 10, 31, 15, 45, 9, 171, DateTimeKind.Local).AddTicks(8759), 5, "Miscellaneous", "", "Other Expenses" }
                });

            migrationBuilder.InsertData(
                table: "DeliveryTrackings",
                columns: new[] { "Id", "Address", "DeliveryId", "DriverId", "Latitude", "Longitude", "Notes", "StatusUpdate", "Timestamp" },
                values: new object[,]
                {
                    { 1, "Sofia, Bulgaria", 1, 1, 42.697699999999998, 23.321899999999999, "Delivery completed successfully.", "Delivered", new DateTime(2024, 10, 26, 15, 45, 10, 977, DateTimeKind.Local).AddTicks(406) },
                    { 2, "Varna, Bulgaria", 2, 1, 43.214100000000002, 27.9147, "Delivery scheduled.", "Booked", new DateTime(2024, 10, 27, 15, 45, 10, 977, DateTimeKind.Local).AddTicks(408) },
                    { 3, "Plovdiv, Bulgaria", 3, 1, 42.135399999999997, 24.7453, "Delivered on time.", "Delivered", new DateTime(2024, 10, 28, 15, 45, 10, 977, DateTimeKind.Local).AddTicks(410) },
                    { 4, "Kardzhali, Bulgaria", 4, 1, 41.632100000000001, 25.379000000000001, "Awaiting driver assignment.", "Delivered", new DateTime(2024, 10, 29, 15, 45, 10, 977, DateTimeKind.Local).AddTicks(411) },
                    { 5, "Burgas, Bulgaria", 5, 1, 42.504800000000003, 27.462599999999998, "Package left with neighbor.", "Booked", new DateTime(2024, 10, 30, 15, 45, 10, 977, DateTimeKind.Local).AddTicks(415) }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "ClientCompanyId1", "DeliveryId", "Description", "FileId", "InvoiceDate", "InvoiceNumber", "IsPaid" },
                values: new object[,]
                {
                    { 1, null, 1, "Invoice for Delivery 1", "", new DateTime(2024, 10, 21, 15, 45, 9, 185, DateTimeKind.Local).AddTicks(6536), "INV001", true },
                    { 2, null, 2, "Invoice for Delivery 2", "", new DateTime(2024, 10, 22, 15, 45, 9, 185, DateTimeKind.Local).AddTicks(6540), "INV002", false },
                    { 3, null, 3, "Invoice for Delivery 3", "", new DateTime(2024, 10, 23, 15, 45, 9, 185, DateTimeKind.Local).AddTicks(6542), "INV003", true },
                    { 4, null, 4, "Invoice for Delivery 4", "", new DateTime(2024, 10, 24, 15, 45, 9, 185, DateTimeKind.Local).AddTicks(6543), "INV004", false },
                    { 5, null, 5, "Invoice for Delivery 5", "", new DateTime(2024, 10, 25, 15, 45, 9, 185, DateTimeKind.Local).AddTicks(6545), "INV005", true }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "350868c0-bf0f-4f70-b4c9-155351bc6429", "driverUser1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "350868c0-bf0f-4f70-b4c9-155351bc6429", "driverUser2" });

            migrationBuilder.DeleteData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FuelPrices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FuelPrices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "NonStandardCargos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "NonStandardCargos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "NonStandardCargos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "NonStandardCargos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PricesPerSize",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PricesPerSize",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StandartCargos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StandartCargos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StandartCargos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "driverUser1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "driverUser2");

            migrationBuilder.DeleteData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20ddc22c-ca6d-4feb-a688-0f31a430b5eb",
                column: "ConcurrencyStamp",
                value: "efb093d3-fa78-4c5e-b1b1-d147283fa35f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27609f35-fbc8-4dc4-9d12-7ff2dd400327",
                column: "ConcurrencyStamp",
                value: "4f2ac73f-42a3-4c7e-abf1-9946033a9ab6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "350868c0-bf0f-4f70-b4c9-155351bc6429",
                column: "ConcurrencyStamp",
                value: "a056c4e7-69a5-414f-89a7-25f19ec8097c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d000e64-c056-419a-950f-1992bd1e910d",
                column: "ConcurrencyStamp",
                value: "342055a1-d3ca-43be-a5d6-09755e57eb65");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99027aaa-d346-4dd9-a467-15d74576c080",
                column: "ConcurrencyStamp",
                value: "5a6af522-1ef7-4aba-bcdb-3b27ac35d2cf");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20450cff-816f-49c8-9546-1c603aec0301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5a837666-39de-43e9-872b-ad6d842063a3", "AQAAAAEAACcQAAAAEAHD5fxDFdCsT5fDmyFTRPxzXrdVJsvDE1bDPnRTfX36VQq0xQUZEHWZ42SBycCGEA==", "e70b5344-4538-45f4-bd49-3c23bcaf8130" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e8be95a-186e-403b-b4aa-3874750a3563",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "df90c9ab-e967-446e-b7c3-84324bd3117f", "AQAAAAEAACcQAAAAEHlbjNkqUo+fYrfhweWcrA8qjdVLGBRVJ4JG997FbcXQYLoAKsL3UrKBoGAoSzXkqg==", "d588fab7-be8a-414b-bf4b-6269c088d451" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38ba6810-2800-4ac8-b005-5c27e8248951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e6e4329f-2b6e-4b11-afc4-a3236178feb6", "AQAAAAEAACcQAAAAEN/S0Y+ZCYK9KldsKcLoESeH7sXMknjBUgu6tjgdQB0lxJg564f2VIKkADUeYovniQ==", "d24415c0-eb56-4dfd-a0e3-bd9799a7fe79" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6bab54d5-5a88-4128-92d2-4d12ad0baa32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3282f92b-9105-481e-b419-d954e5b4de55", "AQAAAAEAACcQAAAAEPOUWqnAIhLPVwOqSAx+yiRIg84xLGCtZOgHGj/rwNjIioRDUTf3WbP1oswdufl8KQ==", "1da329df-15e2-4e00-9ec5-143f4c399173" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f3b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b", 0, "f9d85ba4-c981-4ed4-84b9-232fe7701a42", "driver@example.com", true, false, null, null, null, "AQAAAAEAACcQAAAAEDidkBHNOb+G01syluWD59SgoXNomMchwBTyDH1YN6+3mTdKW5OTJThg7hHoZrFBbg==", null, false, "3888318a-543a-4527-aa2f-6c5b6b1aa6c2", false, "driver" });

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 10, 19, 34, 44, 763, DateTimeKind.Local).AddTicks(3198));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 20, 19, 34, 44, 763, DateTimeKind.Local).AddTicks(3233));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "350868c0-bf0f-4f70-b4c9-155351bc6429", "f3b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b" });

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Age", "IsAvailable", "LicenseExpiryDate", "LicenseNumber", "Name", "Preferrences", "UserId", "YearOfExperience" },
                values: new object[] { 35, false, new DateTime(2026, 10, 30, 17, 34, 44, 772, DateTimeKind.Utc).AddTicks(8595), "DL123456", "Paul Smith", "Long-distance deliveries", "f3b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b", 10 });
        }
    }
}

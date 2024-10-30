using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogiTrack.Infrastructure.Migrations
{
    public partial class InitialMigrationToNewDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PricesPerSize",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PricesPerSize",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20ddc22c-ca6d-4feb-a688-0f31a430b5eb",
                column: "ConcurrencyStamp",
                value: "82dc2d15-ff7c-47c4-93ca-7dec6ad75598");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27609f35-fbc8-4dc4-9d12-7ff2dd400327",
                column: "ConcurrencyStamp",
                value: "32abf858-9498-4595-b660-ad721d775b2f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d000e64-c056-419a-950f-1992bd1e910d",
                column: "ConcurrencyStamp",
                value: "1489fcaa-9685-4da4-babf-fead30ff1b1e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99027aaa-d346-4dd9-a467-15d74576c080",
                column: "ConcurrencyStamp",
                value: "84bb71f9-940f-4e07-942c-6acb07993016");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20450cff-816f-49c8-9546-1c603aec0301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8087c70d-5dcb-471e-a35a-161ef31cfc0a", "AQAAAAEAACcQAAAAEDMKBIP0yBoCZruZD6dkucaXGh1fvz+hG4rCgvvOSCWG1ZkKe58eeNHExgvzd7bbdw==", "e232110f-29bd-4a30-b0b8-9b90e1627530" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e8be95a-186e-403b-b4aa-3874750a3563",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7e38c56e-edd1-43d6-8c93-c78d67d9b5f5", "AQAAAAEAACcQAAAAEAIw+iQxurK/8zyvnQf9OC9nEJdl1vZWP5BAXfnv5hp6Nv9XGrd47df4DpGbHPvaAQ==", "fc8fd112-d48a-467d-82a8-0e9a682e52f8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38ba6810-2800-4ac8-b005-5c27e8248951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d1c671f2-735f-4d2f-884e-67da5bf5ca06", "AQAAAAEAACcQAAAAEGeASuXE2sMD5wXy51f6LZEAGJsmnAKfPl8kUAm0PMqeX3SBNBWv5YInLyr8/1SxoA==", "50bd3e0d-8b3d-4754-b126-149b0b405ea3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6bab54d5-5a88-4128-92d2-4d12ad0baa32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "446feff0-673c-4a2d-bfe5-b8242e947006", "AQAAAAEAACcQAAAAEMa01FR5ZksVwWf0UuxqzW+pWT5Lpx95FONQmMVWominO8r9cDQVwKmsWQh2gayGSA==", "b1a3d398-eb40-4787-93b0-a0edf75fef97" });

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 10, 19, 15, 56, 528, DateTimeKind.Local).AddTicks(4805));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 20, 19, 15, 56, 528, DateTimeKind.Local).AddTicks(4830));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "LicenseExpiryDate", "UserId" },
                values: new object[] { new DateTime(2026, 10, 30, 17, 15, 56, 537, DateTimeKind.Utc).AddTicks(3092), "f3b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20ddc22c-ca6d-4feb-a688-0f31a430b5eb",
                column: "ConcurrencyStamp",
                value: "44d2d16c-e0be-4d85-9df6-de96f39ed850");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27609f35-fbc8-4dc4-9d12-7ff2dd400327",
                column: "ConcurrencyStamp",
                value: "598cc835-300b-43a5-81bd-9241362f80b5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d000e64-c056-419a-950f-1992bd1e910d",
                column: "ConcurrencyStamp",
                value: "0a6174bf-2f5f-433e-a5b0-c02d207a6892");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99027aaa-d346-4dd9-a467-15d74576c080",
                column: "ConcurrencyStamp",
                value: "53bd6605-4f49-46cf-bd0d-5fbfb0a17057");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20450cff-816f-49c8-9546-1c603aec0301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ed2ac369-c162-40d5-a5cf-2d229eeb4f96", "AQAAAAEAACcQAAAAEIY8JEyXZMHDDE1goQzGkDFLu4xMZXNVxTuE+CvGmehb83Wux0zAY8Ab10LSmnwHCw==", "4a72e924-f087-4b81-9e14-884517db9cae" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e8be95a-186e-403b-b4aa-3874750a3563",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a71f9d4e-87dc-44d6-8111-b5743741423f", "AQAAAAEAACcQAAAAEKgEREBuqz+wpphl6NS6NE+qv4NYfBDl2FrRyxvh+tDcgSn1Z2wkuyGO6eyYBBKi0w==", "1a8e72a5-9fbd-4753-b880-e07b1150b07e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38ba6810-2800-4ac8-b005-5c27e8248951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3d4d46a7-552c-4bc6-8542-28e863eaccab", "AQAAAAEAACcQAAAAEOVVJaaEx7cnM4OHB7OlVe2KwTdlKT64mmIZ6esgLYsnYEdFOIGaDJrmybZ5qbxRAQ==", "20bd2f96-9a71-41d6-b58f-798d9bf5ac24" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6bab54d5-5a88-4128-92d2-4d12ad0baa32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "129547b1-57fa-462e-bdd6-029cc5a489aa", "AQAAAAEAACcQAAAAEDtKooZJYB5dhjUJ7b5iI62Jx1vNkvpZw6duSpuk6g3yi8AtS1N7+LKLvzA48ffJOg==", "e4fd26d4-81b9-46a2-a690-9cc4df5da9c9" });

            migrationBuilder.InsertData(
                table: "CalendarEvents",
                columns: new[] { "Id", "ClientCompanyId", "Date", "EventType", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 10, 31, 17, 4, 40, 597, DateTimeKind.Utc).AddTicks(3041), "Delivered", "Delivered goods" },
                    { 2, 1, new DateTime(2024, 9, 20, 17, 4, 40, 597, DateTimeKind.Utc).AddTicks(3041), "Pickup", "Picked up goods" },
                    { 3, 1, new DateTime(2024, 11, 2, 17, 4, 40, 597, DateTimeKind.Utc).AddTicks(3041), "Paid", "Paid delivery" }
                });

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 10, 19, 4, 39, 388, DateTimeKind.Local).AddTicks(1972));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 20, 19, 4, 39, 388, DateTimeKind.Local).AddTicks(2026));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "LicenseExpiryDate", "UserId" },
                values: new object[] { new DateTime(2026, 10, 30, 17, 4, 39, 395, DateTimeKind.Utc).AddTicks(578), "2e8be95a-186e-403b-b4aa-3874750a3563" });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "Age", "IsAvailable", "LicenseExpiryDate", "LicenseNumber", "MonthsOfExperience", "Name", "Preferrences", "Salary", "UserId", "YearOfExperience" },
                values: new object[] { 2, 32, true, new DateTime(2027, 10, 30, 17, 4, 39, 395, DateTimeKind.Utc).AddTicks(583), "DL654321", 4, "Mark Driver", "Short-distance deliveries", 2800m, "38ba6810-2800-4ac8-b005-5c27e8248951", 8 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "ArePalletsStackable", "ContantsExpenses", "EuroPalletCapacity", "FuelConsumptionPer100Km", "Height", "IndustrialPalletCapacity", "KilometersDriven", "KilometersLeftToChangeParts", "LastYearMaintenance", "Length", "MaxWeightCapacity", "PurchasePrice", "RegistrationNumber", "VehicleStatus", "VehicleType", "Volume", "Width" },
                values: new object[,]
                {
                    { 1, true, 0m, 10, 28.5, 2.6000000000000001, 8, 0.0, 0.0, new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.5, 10000.0, 0m, "BG1234RE", "Not Available", "Refrigerated Truck", 48.75, 2.5 },
                    { 2, true, 0m, 33, 32.0, 2.7000000000000002, 26, 0.0, 0.0, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 13.6, 24000.0, 0m, "BG5678TT", "Available", "Tent Truck", 91.799999999999997, 2.5 }
                });

            migrationBuilder.InsertData(
                table: "PricesPerSize",
                columns: new[] { "Id", "DomesticPriceForNotSharedTruck", "DomesticPriceForSharedTruck", "InternationalPriceForNotSharedTruck", "InternationalPriceForSharedTruck", "QuotientForDomesticNotSharedTruck", "QuotientForDomesticSharedTruck", "QuotientForInternationalNotSharedTruck", "QuotientForInternationalSharedTruck", "VehicleId" },
                values: new object[] { 1, 500m, 300m, 1000m, 700m, 0.0, 0.0, 0.0, 0.0, 1 });

            migrationBuilder.InsertData(
                table: "PricesPerSize",
                columns: new[] { "Id", "DomesticPriceForNotSharedTruck", "DomesticPriceForSharedTruck", "InternationalPriceForNotSharedTruck", "InternationalPriceForSharedTruck", "QuotientForDomesticNotSharedTruck", "QuotientForDomesticSharedTruck", "QuotientForInternationalNotSharedTruck", "QuotientForInternationalSharedTruck", "VehicleId" },
                values: new object[] { 2, 550m, 320m, 1050m, 750m, 0.0, 0.0, 0.0, 0.0, 2 });
        }
    }
}

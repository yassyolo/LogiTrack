using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogiTrack.Infrastructure.Migrations
{
    public partial class AddedFuelPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MaintenanceDue",
                table: "Vehicles",
                newName: "LastYearMaintenance");

            migrationBuilder.AddColumn<decimal>(
                name: "ContantsExpenses",
                table: "Vehicles",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                comment: "Vehicle's constant expences");

            migrationBuilder.AddColumn<double>(
                name: "KilometersDriven",
                table: "Vehicles",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                comment: "Kilometers driven");

            migrationBuilder.AddColumn<double>(
                name: "KilometersLeftToChangeParts",
                table: "Vehicles",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                comment: "Kilometers left to change parts");

            migrationBuilder.AddColumn<decimal>(
                name: "PurchasePrice",
                table: "Vehicles",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                comment: "Vehicle's purchase price");

            migrationBuilder.AddColumn<double>(
                name: "QuotientForDomesticNotSharedTruck",
                table: "PricesPerSize",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                comment: "Quotient for domestic not shared truck");

            migrationBuilder.AddColumn<double>(
                name: "QuotientForDomesticSharedTruck",
                table: "PricesPerSize",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                comment: "Quotient for domestic shared truck");

            migrationBuilder.AddColumn<double>(
                name: "QuotientForInternationalNotSharedTruck",
                table: "PricesPerSize",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                comment: "Quotient for international not shared truck");

            migrationBuilder.AddColumn<double>(
                name: "QuotientForInternationalSharedTruck",
                table: "PricesPerSize",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                comment: "Quotient for international shared truck");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20ddc22c-ca6d-4feb-a688-0f31a430b5eb",
                column: "ConcurrencyStamp",
                value: "5b36ed11-e053-4858-ada1-dd1ca3418b5e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27609f35-fbc8-4dc4-9d12-7ff2dd400327",
                column: "ConcurrencyStamp",
                value: "2e8ccd70-e1e1-4eb7-86a4-048c11ad3560");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d000e64-c056-419a-950f-1992bd1e910d",
                column: "ConcurrencyStamp",
                value: "9ff6fda8-d21a-4a36-abfb-2970c7e61cd6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99027aaa-d346-4dd9-a467-15d74576c080",
                column: "ConcurrencyStamp",
                value: "d05a128e-a48b-4e1e-89a9-58376164f46b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20450cff-816f-49c8-9546-1c603aec0301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "69fa766a-180e-4cc1-9962-41206001baae", "AQAAAAEAACcQAAAAEP9QvH9CF3emTmdd1qt+zEkL9a3vv5rOrpF3diwHOxXV4Vd+YUTy9i682MFxCk1oNg==", "922baa4a-5ddf-40f4-a29d-c761b17db521" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e8be95a-186e-403b-b4aa-3874750a3563",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "caa4ca76-2453-4a8f-99d7-82a12ce18fcd", "AQAAAAEAACcQAAAAEJ65G9gtrJ1FAZZ+JsExEfzyAOVAWdzH/gZ2V0DwupTjxEBwuo9yIf8bSGlNXc741Q==", "17ad0259-9470-4e3b-a2cd-7fa5c7bdc5fc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38ba6810-2800-4ac8-b005-5c27e8248951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a4d1472b-71c2-4a4b-87b0-df8ef0b3a11d", "AQAAAAEAACcQAAAAEJKkVId+hTzXRiaWnLxKLGGdj7+HlDYJujFZ/Qm5IUqK/HC/ETs1Bf3Wms5wxQrPmQ==", "b44b3063-85b5-426d-b8b0-6e8099740201" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6bab54d5-5a88-4128-92d2-4d12ad0baa32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5c98e020-1b5e-4d70-88e3-8d5bd9c91b6d", "AQAAAAEAACcQAAAAENro+caseMj8obtRc8KHyJK1lEQj6rGBl5YLaF9UyMwQP6bfTXLz4BR7ih4L/EdEUA==", "50abfb93-b9e0-4261-b0f2-919d8af335db" });

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateSubmitted",
                value: new DateTime(2024, 10, 20, 20, 4, 3, 925, DateTimeKind.Utc).AddTicks(7058));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateSubmitted",
                value: new DateTime(2024, 10, 20, 20, 4, 3, 925, DateTimeKind.Utc).AddTicks(7060));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1,
                column: "LicenseExpiryDate",
                value: new DateTime(2026, 10, 20, 20, 4, 3, 949, DateTimeKind.Utc).AddTicks(428));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 2,
                column: "LicenseExpiryDate",
                value: new DateTime(2027, 10, 20, 20, 4, 3, 949, DateTimeKind.Utc).AddTicks(433));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                column: "InvoiceDate",
                value: new DateTime(2024, 10, 20, 20, 4, 4, 276, DateTimeKind.Utc).AddTicks(7101));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 1,
                column: "OfferDate",
                value: new DateTime(2024, 10, 19, 20, 4, 4, 283, DateTimeKind.Utc).AddTicks(8592));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 20, 23, 4, 4, 295, DateTimeKind.Local).AddTicks(4711));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 20, 23, 4, 4, 295, DateTimeKind.Local).AddTicks(4802));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 20, 23, 4, 4, 295, DateTimeKind.Local).AddTicks(4825));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 20, 23, 4, 4, 295, DateTimeKind.Local).AddTicks(4835));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastYearMaintenance",
                value: new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastYearMaintenance",
                value: new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContantsExpenses",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "KilometersDriven",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "KilometersLeftToChangeParts",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "PurchasePrice",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "QuotientForDomesticNotSharedTruck",
                table: "PricesPerSize");

            migrationBuilder.DropColumn(
                name: "QuotientForDomesticSharedTruck",
                table: "PricesPerSize");

            migrationBuilder.DropColumn(
                name: "QuotientForInternationalNotSharedTruck",
                table: "PricesPerSize");

            migrationBuilder.DropColumn(
                name: "QuotientForInternationalSharedTruck",
                table: "PricesPerSize");

            migrationBuilder.RenameColumn(
                name: "LastYearMaintenance",
                table: "Vehicles",
                newName: "MaintenanceDue");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20ddc22c-ca6d-4feb-a688-0f31a430b5eb",
                column: "ConcurrencyStamp",
                value: "57803dac-4585-45b3-82aa-de8c2f879a2b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27609f35-fbc8-4dc4-9d12-7ff2dd400327",
                column: "ConcurrencyStamp",
                value: "9d262c24-12f6-464f-b59c-3109f18c056b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d000e64-c056-419a-950f-1992bd1e910d",
                column: "ConcurrencyStamp",
                value: "80e213f9-f1b4-48f9-b237-f6458eae432c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99027aaa-d346-4dd9-a467-15d74576c080",
                column: "ConcurrencyStamp",
                value: "c70b4669-c658-41f9-86ae-6821a90a0b1e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20450cff-816f-49c8-9546-1c603aec0301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "121db358-287e-4300-aa60-d50e8bb537b3", "AQAAAAEAACcQAAAAEDiCWYD3B0sB9HDZbTxaELDb5pyeDMURkowBJ1eO4NngKeWgZs02UiIfcAmI3rLiJw==", "d647140f-0dce-405d-bd5a-d8cde495bfb1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e8be95a-186e-403b-b4aa-3874750a3563",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d05f20d5-5e21-41fd-9121-727188eb916f", "AQAAAAEAACcQAAAAEF0h/37KyauIOmHYpwx1lzS2AhBkhdR7lqXRXW3/ut569+BuFNbfhIp23kvaYrogxA==", "152dc5f3-b17d-4593-9df7-f7c4476b5cf9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38ba6810-2800-4ac8-b005-5c27e8248951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5e66d39c-62bf-40b8-9245-58addde3048d", "AQAAAAEAACcQAAAAENvBIEnFboTd2ClZP3XJLH+I0Gsryzl7J51tWQrM6Cn/vKJJVj2YQGL+86YOiqfrAw==", "31a9700d-081e-4486-9caf-80baf34745e2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6bab54d5-5a88-4128-92d2-4d12ad0baa32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7ac7d5c8-10a0-430f-ba9f-02b503100d31", "AQAAAAEAACcQAAAAEDffBG6yWjgnuzV2CMEHWJys0mtcMYpH0Xn9IHrRQ6Q+48aVcVUFdbyTN67MWC4D6g==", "f2c304af-faff-47d9-944d-6872fdf6fa01" });

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateSubmitted",
                value: new DateTime(2024, 10, 20, 12, 6, 9, 750, DateTimeKind.Utc).AddTicks(1798));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateSubmitted",
                value: new DateTime(2024, 10, 20, 12, 6, 9, 750, DateTimeKind.Utc).AddTicks(1800));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1,
                column: "LicenseExpiryDate",
                value: new DateTime(2026, 10, 20, 12, 6, 9, 772, DateTimeKind.Utc).AddTicks(1366));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 2,
                column: "LicenseExpiryDate",
                value: new DateTime(2027, 10, 20, 12, 6, 9, 772, DateTimeKind.Utc).AddTicks(1371));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                column: "InvoiceDate",
                value: new DateTime(2024, 10, 20, 12, 6, 10, 644, DateTimeKind.Utc).AddTicks(4055));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 1,
                column: "OfferDate",
                value: new DateTime(2024, 10, 19, 12, 6, 10, 652, DateTimeKind.Utc).AddTicks(94));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 20, 15, 6, 10, 665, DateTimeKind.Local).AddTicks(5212));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 20, 15, 6, 10, 665, DateTimeKind.Local).AddTicks(5431));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 20, 15, 6, 10, 665, DateTimeKind.Local).AddTicks(5473));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 20, 15, 6, 10, 665, DateTimeKind.Local).AddTicks(5487));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "MaintenanceDue",
                value: new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                column: "MaintenanceDue",
                value: new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}

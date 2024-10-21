using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogiTrack.Infrastructure.Migrations
{
    public partial class TestFuelPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FuelPrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Fuel Price identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Fuel price"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelPrices", x => x.Id);
                },
                comment: "Fuel Prices Entity");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20ddc22c-ca6d-4feb-a688-0f31a430b5eb",
                column: "ConcurrencyStamp",
                value: "fd86fa06-5cbf-4bb8-8c58-ca1fcfe5f524");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27609f35-fbc8-4dc4-9d12-7ff2dd400327",
                column: "ConcurrencyStamp",
                value: "4fc5779f-3a1f-4c51-8d78-7b774ed7e350");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d000e64-c056-419a-950f-1992bd1e910d",
                column: "ConcurrencyStamp",
                value: "7888674d-2fce-434f-a25a-6ccec02f9dc9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99027aaa-d346-4dd9-a467-15d74576c080",
                column: "ConcurrencyStamp",
                value: "67da2b77-a2d7-420c-875e-5ce8eee2ccc9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20450cff-816f-49c8-9546-1c603aec0301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "35acd8c0-7bb8-4c67-a7c2-5387e06ff85d", "AQAAAAEAACcQAAAAEIX8FA0tACloh1mNV7ZtvRPL1GSQAR8JmBJpPbH5jro3v71tGwGr1NufkHTZaqNf+A==", "e1bca2c4-f31f-4743-ad3d-8673f9a3d1c2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e8be95a-186e-403b-b4aa-3874750a3563",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7cdc1362-3f73-443f-a405-8cc687a9feec", "AQAAAAEAACcQAAAAEPIKpUgoa6aFvcYpIjE+sSnclQMa0+jgYEDQD6UsQE+L/MeqHIVt42NxqgahaVpR6A==", "7b6ed76f-7e64-400e-9506-0ca9aacb2f38" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38ba6810-2800-4ac8-b005-5c27e8248951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "64cdb4f9-84fa-4ecb-850d-6feb93e6a1a1", "AQAAAAEAACcQAAAAEAc35pXQrDDGrNh27rU2kAF8JZTFf6CnH8xfpLSzrGPyjyTrHuwlZcZMzQPaRIVXIA==", "40570f73-9d90-47a2-b643-853de56ea891" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6bab54d5-5a88-4128-92d2-4d12ad0baa32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "303f8e88-dcde-449d-84ba-b243b69e4e49", "AQAAAAEAACcQAAAAELYGoK3WTOfq7fyPCdF6UfbHDdcVEfpiCq+/jnBexqnZttNVYnqBPRQ9VPBR057Xfg==", "392064d2-924b-4bbb-914b-8785dce23c24" });

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateSubmitted",
                value: new DateTime(2024, 10, 20, 20, 8, 51, 146, DateTimeKind.Utc).AddTicks(670));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateSubmitted",
                value: new DateTime(2024, 10, 20, 20, 8, 51, 146, DateTimeKind.Utc).AddTicks(672));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1,
                column: "LicenseExpiryDate",
                value: new DateTime(2026, 10, 20, 20, 8, 51, 163, DateTimeKind.Utc).AddTicks(5057));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 2,
                column: "LicenseExpiryDate",
                value: new DateTime(2027, 10, 20, 20, 8, 51, 163, DateTimeKind.Utc).AddTicks(5061));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                column: "InvoiceDate",
                value: new DateTime(2024, 10, 20, 20, 8, 51, 631, DateTimeKind.Utc).AddTicks(6981));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 1,
                column: "OfferDate",
                value: new DateTime(2024, 10, 19, 20, 8, 51, 636, DateTimeKind.Utc).AddTicks(3797));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 20, 23, 8, 51, 645, DateTimeKind.Local).AddTicks(7203));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 20, 23, 8, 51, 645, DateTimeKind.Local).AddTicks(7282));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 20, 23, 8, 51, 645, DateTimeKind.Local).AddTicks(7426));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 20, 23, 8, 51, 645, DateTimeKind.Local).AddTicks(7431));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FuelPrices");

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
        }
    }
}

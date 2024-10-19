using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogiTrack.Infrastructure.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20ddc22c-ca6d-4feb-a688-0f31a430b5eb",
                column: "ConcurrencyStamp",
                value: "4b69ec24-4dc8-4cb0-97bf-c912c4a627c8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27609f35-fbc8-4dc4-9d12-7ff2dd400327",
                column: "ConcurrencyStamp",
                value: "2f6eb017-ef3e-4b1c-ab49-8cbb8d59af86");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d000e64-c056-419a-950f-1992bd1e910d",
                column: "ConcurrencyStamp",
                value: "398093c2-15a8-4282-94a8-8c93269131ac");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99027aaa-d346-4dd9-a467-15d74576c080",
                column: "ConcurrencyStamp",
                value: "e3ef4f83-ca6e-460a-bad7-f95b41acf3e2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20450cff-816f-49c8-9546-1c603aec0301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7ed4eb45-1fba-477b-a84c-e097f6542222", "AQAAAAEAACcQAAAAEIeWgS4FRlGaJIktGDbvoqT/5UxY37NVFTssJ6oLLq3QfoJOckar81bWYrgmeiBGhA==", "a096abd8-f984-4d3c-9e7f-ef7a981e3b46" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e8be95a-186e-403b-b4aa-3874750a3563",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c95e9cc0-9cc2-4470-991b-47bd4efe9942", "AQAAAAEAACcQAAAAEAUcl63CFFvvMCLIUL0s+i1Y1tGpC1r8OhQLUxKrCK+i/ZdOKaNxDRd0QgIZxQ2krg==", "96b72427-6121-4c08-90b0-527624d3d86b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38ba6810-2800-4ac8-b005-5c27e8248951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "46b006dd-bf9a-47b8-9d0d-e792a817b632", "AQAAAAEAACcQAAAAEK6jwLAml+Iza+HzShXoQB+WAKcg6P6z6now1OAVjeZHvxqIqSIDxcw9MjaM7ygZIA==", "63e5106b-9e72-48a2-ab1b-c2ea175634ee" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6bab54d5-5a88-4128-92d2-4d12ad0baa32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5abdcb8d-5885-4013-be05-394c82ef2b2a", "AQAAAAEAACcQAAAAEEE01UKz3R8FfZLMhrpqP70r5h81XnQnoa1CrfTJjJ9DKtcByqWj1FFSA4E5KtLEOQ==", "952f2971-deb2-4dd4-a30d-4c5c86905273" });

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateSubmitted",
                value: new DateTime(2024, 10, 19, 1, 10, 32, 327, DateTimeKind.Utc).AddTicks(6324));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateSubmitted",
                value: new DateTime(2024, 10, 19, 1, 10, 32, 327, DateTimeKind.Utc).AddTicks(6325));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReferenceNumber",
                value: "REF-2024-0001");

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1,
                column: "LicenseExpiryDate",
                value: new DateTime(2026, 10, 19, 1, 10, 32, 342, DateTimeKind.Utc).AddTicks(7910));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 2,
                column: "LicenseExpiryDate",
                value: new DateTime(2027, 10, 19, 1, 10, 32, 342, DateTimeKind.Utc).AddTicks(7913));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                column: "InvoiceDate",
                value: new DateTime(2024, 10, 19, 1, 10, 32, 348, DateTimeKind.Utc).AddTicks(6835));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 1,
                column: "OfferDate",
                value: new DateTime(2024, 10, 18, 1, 10, 32, 353, DateTimeKind.Utc).AddTicks(1524));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 19, 4, 10, 33, 295, DateTimeKind.Local).AddTicks(5667));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 19, 4, 10, 33, 295, DateTimeKind.Local).AddTicks(5803));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 19, 4, 10, 33, 295, DateTimeKind.Local).AddTicks(5812));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 19, 4, 10, 33, 295, DateTimeKind.Local).AddTicks(5820));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20ddc22c-ca6d-4feb-a688-0f31a430b5eb",
                column: "ConcurrencyStamp",
                value: "10ab5af2-eaaa-4ce5-87d2-00548197bc38");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27609f35-fbc8-4dc4-9d12-7ff2dd400327",
                column: "ConcurrencyStamp",
                value: "891fa2a9-7d34-4a07-91fc-9bc5b0bc7b1c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d000e64-c056-419a-950f-1992bd1e910d",
                column: "ConcurrencyStamp",
                value: "80e7ebd3-95f1-44c6-9ae7-7d78c2006058");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99027aaa-d346-4dd9-a467-15d74576c080",
                column: "ConcurrencyStamp",
                value: "693c3bd6-9e81-4212-b36c-ead34d7cf794");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20450cff-816f-49c8-9546-1c603aec0301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f442b5bb-5fe4-4897-af6c-bacb7ab67b6b", "AQAAAAEAACcQAAAAEFu8R7Ckw2oNsLy/3/D2fXFoI3sp8XqWhkzW1L3vaBS0xcL59pp2sL0HEjimRe2Zzg==", "11614547-885b-498d-8ff9-9f88a8b031af" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e8be95a-186e-403b-b4aa-3874750a3563",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b55e952c-fdac-46e3-8d54-1afecb30c667", "AQAAAAEAACcQAAAAEGuWG00E2zBV8EkRvBxRq1OfP6QseEC2SPhAhwWo/5bRaNFoSaXV3TNnLzOq3NjOQA==", "882e2b8f-827a-4cc1-8d73-f65901d6556d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38ba6810-2800-4ac8-b005-5c27e8248951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "08583d03-8c7f-4e63-8a4f-46be7df760db", "AQAAAAEAACcQAAAAEI5fNNisfRkOSRtzz4cdCTAJe089AZ3Cp3mkGDkQlgfjtcmZHZaWUrV2u3VhSkrkZA==", "58cc8a65-819a-48fb-8eea-3705ad611ed5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6bab54d5-5a88-4128-92d2-4d12ad0baa32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fe966ef2-422a-4291-b886-211aec5dd0d5", "AQAAAAEAACcQAAAAEPiVZV7b9WXFsCF+dl2w9tYyhARcRKpr9DO8+7Jx4AHKwYZZLabLXLQpBBI8U0eeog==", "f2172c3f-3466-4109-9d56-08184b3af76c" });

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateSubmitted",
                value: new DateTime(2024, 10, 19, 0, 49, 50, 204, DateTimeKind.Utc).AddTicks(1836));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateSubmitted",
                value: new DateTime(2024, 10, 19, 0, 49, 50, 204, DateTimeKind.Utc).AddTicks(1838));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReferenceNumber",
                value: "");

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1,
                column: "LicenseExpiryDate",
                value: new DateTime(2026, 10, 19, 0, 49, 50, 221, DateTimeKind.Utc).AddTicks(8845));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 2,
                column: "LicenseExpiryDate",
                value: new DateTime(2027, 10, 19, 0, 49, 50, 221, DateTimeKind.Utc).AddTicks(8850));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                column: "InvoiceDate",
                value: new DateTime(2024, 10, 19, 0, 49, 51, 341, DateTimeKind.Utc).AddTicks(5318));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 1,
                column: "OfferDate",
                value: new DateTime(2024, 10, 18, 0, 49, 51, 348, DateTimeKind.Utc).AddTicks(5758));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 19, 3, 49, 51, 361, DateTimeKind.Local).AddTicks(1835));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 19, 3, 49, 51, 361, DateTimeKind.Local).AddTicks(1963));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 19, 3, 49, 51, 361, DateTimeKind.Local).AddTicks(1987));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 19, 3, 49, 51, 361, DateTimeKind.Local).AddTicks(1994));
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogiTrack.Infrastructure.Migrations
{
    public partial class AddedCreationDateOfRegistrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ClientCompanies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Registration created at");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20ddc22c-ca6d-4feb-a688-0f31a430b5eb",
                column: "ConcurrencyStamp",
                value: "7b6851ab-cf8c-409f-81b2-9fc1926952bd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27609f35-fbc8-4dc4-9d12-7ff2dd400327",
                column: "ConcurrencyStamp",
                value: "97748a7a-eda7-4328-9631-bb778c731345");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d000e64-c056-419a-950f-1992bd1e910d",
                column: "ConcurrencyStamp",
                value: "449e69f9-4a12-428f-af01-bdc58bbf7d56");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99027aaa-d346-4dd9-a467-15d74576c080",
                column: "ConcurrencyStamp",
                value: "fdd85c89-a196-4a36-b3bc-c333278d8a11");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20450cff-816f-49c8-9546-1c603aec0301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d08e1c48-e86e-4611-9a9f-f0e1be407a35", "AQAAAAEAACcQAAAAED0OYgzCy0CQ0FbYs+5EIGe2kw6mXY7dDMNm0+wL32lga926iG/3Er2LYfEn5lUYQw==", "f5b034bf-ae83-47e0-b444-030cb0f99807" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e8be95a-186e-403b-b4aa-3874750a3563",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "163c9515-bfd3-49bc-af11-f0e6a772dbea", "AQAAAAEAACcQAAAAEJ5jgZLj4iVr0RSAvEouV7Z1aqwU1942+QTcdDJeQfkCn09xvTmQPa6glIdQwNQrIg==", "3a29d64e-2b45-499c-ac9e-33761ee9e1a9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38ba6810-2800-4ac8-b005-5c27e8248951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4f3a3423-fe90-4e94-a6f9-5fc3bfd2302a", "AQAAAAEAACcQAAAAEP66qcs9+NX6lD+LEWORFLKTTWSmPCJ7e4T/5+/GuWI5s50ScYucJu2KhXMiZk5hAw==", "1b693ff6-3270-4d47-982f-dca0754ebeff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6bab54d5-5a88-4128-92d2-4d12ad0baa32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2ccaef5d-5453-4bad-abe1-ff482e2c4c32", "AQAAAAEAACcQAAAAEA3VSXK3slbTg3lDAEFaqC4Gsh/hcpd+F6hMI0/LTNLigILZ1ZsZUDCSgOyFxYdgQQ==", "ba9109c9-2829-46b2-b85e-22a9b6aaa97a" });

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateSubmitted",
                value: new DateTime(2024, 10, 21, 12, 22, 10, 765, DateTimeKind.Utc).AddTicks(5177));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateSubmitted",
                value: new DateTime(2024, 10, 21, 12, 22, 10, 765, DateTimeKind.Utc).AddTicks(5179));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 1, 15, 22, 10, 772, DateTimeKind.Local).AddTicks(438));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "RegistrationStatus" },
                values: new object[] { new DateTime(2024, 10, 11, 15, 22, 10, 772, DateTimeKind.Local).AddTicks(474), "Pending" });

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1,
                column: "LicenseExpiryDate",
                value: new DateTime(2026, 10, 21, 12, 22, 10, 786, DateTimeKind.Utc).AddTicks(9285));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 2,
                column: "LicenseExpiryDate",
                value: new DateTime(2027, 10, 21, 12, 22, 10, 786, DateTimeKind.Utc).AddTicks(9290));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                column: "InvoiceDate",
                value: new DateTime(2024, 10, 21, 12, 22, 10, 882, DateTimeKind.Utc).AddTicks(8560));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 1,
                column: "OfferDate",
                value: new DateTime(2024, 10, 20, 12, 22, 10, 889, DateTimeKind.Utc).AddTicks(270));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 21, 15, 22, 10, 900, DateTimeKind.Local).AddTicks(6357));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 21, 15, 22, 10, 900, DateTimeKind.Local).AddTicks(6366));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 21, 15, 22, 10, 900, DateTimeKind.Local).AddTicks(6371));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 21, 15, 22, 10, 900, DateTimeKind.Local).AddTicks(6376));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ClientCompanies");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20ddc22c-ca6d-4feb-a688-0f31a430b5eb",
                column: "ConcurrencyStamp",
                value: "ab3e55a4-66a1-464c-ac65-73ed0c74d89c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27609f35-fbc8-4dc4-9d12-7ff2dd400327",
                column: "ConcurrencyStamp",
                value: "9b38c602-01e5-4722-abb7-2d98e88719cf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d000e64-c056-419a-950f-1992bd1e910d",
                column: "ConcurrencyStamp",
                value: "27677e4a-5b30-45f6-a5bb-96735003f012");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99027aaa-d346-4dd9-a467-15d74576c080",
                column: "ConcurrencyStamp",
                value: "d97237c8-25f8-471b-9dcb-f91756799a42");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20450cff-816f-49c8-9546-1c603aec0301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b5905048-1f0b-4eef-9a89-39f7ee8da955", "AQAAAAEAACcQAAAAEOI5hZBNlCSL7uXD1qO/NXYpAQXf7bwaB4iuEYW1Lpb9G8mEc/ni8Ba1hEt5Q/cGHA==", "2c9f651f-c2bc-40f0-acb9-52b8a5aa635e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e8be95a-186e-403b-b4aa-3874750a3563",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "26826c73-660e-4797-b349-ec133045663d", "AQAAAAEAACcQAAAAENyeXTrUA7ixu1qirfDrTiNRg7h0z4TD3et2uUvEjHI3IiXGuwS1Z/XYEg3khc0LZQ==", "6dc20a10-e8f9-4187-8c03-22531a2e6638" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38ba6810-2800-4ac8-b005-5c27e8248951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e2ca50f3-943d-41a6-9278-7a32e33fbd63", "AQAAAAEAACcQAAAAEBqXpJ1Cb4xovFJMHUQSfmXjOhgWbW8K5T5GWmv/3FeBoylxa7gRGA+9qbeDz3JuyA==", "91d6a641-a97e-4280-b388-2a76b1d2f455" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6bab54d5-5a88-4128-92d2-4d12ad0baa32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5acadad6-a9fa-499a-a92b-a690089d7dc9", "AQAAAAEAACcQAAAAEKq8H28rlzJZYcRHkzY39QUJpgQkG3bA/jadeQOB6+gUcSN+dv5959j62y4S6WBtPw==", "7e7bf1c5-8c67-41ac-971d-ea4a66ab8f6e" });

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateSubmitted",
                value: new DateTime(2024, 10, 21, 8, 11, 22, 986, DateTimeKind.Utc).AddTicks(3916));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateSubmitted",
                value: new DateTime(2024, 10, 21, 8, 11, 22, 986, DateTimeKind.Utc).AddTicks(3918));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegistrationStatus",
                value: "Rejected");

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1,
                column: "LicenseExpiryDate",
                value: new DateTime(2026, 10, 21, 8, 11, 23, 3, DateTimeKind.Utc).AddTicks(409));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 2,
                column: "LicenseExpiryDate",
                value: new DateTime(2027, 10, 21, 8, 11, 23, 3, DateTimeKind.Utc).AddTicks(413));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                column: "InvoiceDate",
                value: new DateTime(2024, 10, 21, 8, 11, 23, 334, DateTimeKind.Utc).AddTicks(3912));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 1,
                column: "OfferDate",
                value: new DateTime(2024, 10, 20, 8, 11, 23, 342, DateTimeKind.Utc).AddTicks(5703));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 21, 11, 11, 23, 355, DateTimeKind.Local).AddTicks(4997));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 21, 11, 11, 23, 355, DateTimeKind.Local).AddTicks(5185));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 21, 11, 11, 23, 355, DateTimeKind.Local).AddTicks(5219));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 21, 11, 11, 23, 355, DateTimeKind.Local).AddTicks(5227));
        }
    }
}

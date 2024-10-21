using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogiTrack.Infrastructure.Migrations
{
    public partial class AddedFileIdToCashRegisters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileId",
                table: "CashRegisters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "File identifier in Google drive");

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
                columns: new[] { "DateSubmitted", "FileId" },
                values: new object[] { new DateTime(2024, 10, 21, 8, 11, 22, 986, DateTimeKind.Utc).AddTicks(3916), "" });

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateSubmitted", "FileId" },
                values: new object[] { new DateTime(2024, 10, 21, 8, 11, 22, 986, DateTimeKind.Utc).AddTicks(3918), "" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileId",
                table: "CashRegisters");

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
    }
}

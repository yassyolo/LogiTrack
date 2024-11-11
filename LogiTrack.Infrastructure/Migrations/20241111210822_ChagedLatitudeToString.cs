using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogiTrack.Infrastructure.Migrations
{
    public partial class ChagedLatitudeToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "ClientCompanies");

            migrationBuilder.AlterColumn<string>(
                name: "Longitude",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Longitude of the address",
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true,
                oldComment: "Longitude of the address");

            migrationBuilder.AlterColumn<string>(
                name: "Latitude",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Latitude of the address",
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true,
                oldComment: "Latitude of the address");

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { "40.7128", "-74.0060" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Latitude", "Longitude", "PostalCode" },
                values: new object[] { "37.7749", "-122.4194", "10003" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Latitude", "Longitude", "PostalCode" },
                values: new object[] { "39.9526", "-75.1652", "10004" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Latitude", "Longitude", "PostalCode" },
                values: new object[] { "38.0293", "-78.4767", "10005" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Latitude", "Longitude", "PostalCode" },
                values: new object[] { "36.8508", "-76.2859", "10006" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Latitude", "Longitude", "PostalCode" },
                values: new object[] { "34.0522", "-118.2437", "10007" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Latitude", "Longitude", "PostalCode" },
                values: new object[] { "32.7157", "-117.1611", "10008" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Latitude", "Longitude", "PostalCode" },
                values: new object[] { "40.7580", "-111.8762", "10009" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Latitude", "Longitude", "PostalCode" },
                values: new object[] { "47.6062", "-122.3321", "10010" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Latitude", "Longitude", "PostalCode" },
                values: new object[] { "35.2271", "-80.8431", "10011" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Latitude", "Longitude", "PostalCode" },
                values: new object[] { "33.7490", "-84.3880", "10012" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20ddc22c-ca6d-4feb-a688-0f31a430b5eb",
                column: "ConcurrencyStamp",
                value: "aa165549-dd7c-4a75-9caf-4a5a26561177");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27609f35-fbc8-4dc4-9d12-7ff2dd400327",
                column: "ConcurrencyStamp",
                value: "cd915dc6-9239-4f1a-bc71-8f828c27f9ca");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "350868c0-bf0f-4f70-b4c9-155351bc6429",
                column: "ConcurrencyStamp",
                value: "12a2e20b-1f2b-4f42-9d35-fee6e754f235");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d000e64-c056-419a-950f-1992bd1e910d",
                column: "ConcurrencyStamp",
                value: "c5e154f1-ab9a-4b98-9d49-6eee797990d5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99027aaa-d346-4dd9-a467-15d74576c080",
                column: "ConcurrencyStamp",
                value: "837aa30d-fef5-4cba-9f62-e9ec7cdd11e1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20450cff-816f-49c8-9546-1c603aec0301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "17170840-70b1-4789-9863-8f8c5149c669", "AQAAAAEAACcQAAAAEOr8xP1Z/HAgCnMb4q2ufcLjxqJ1WVGtZpDRXs1JudSeQhTbuD4sDQnq7BdIK+wZjw==", "53264d0e-a394-40ac-8736-aa8c2cd86ce5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e8be95a-186e-403b-b4aa-3874750a3563",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a319de7-bd20-4ffc-9e84-06870234d155", "AQAAAAEAACcQAAAAEF25xDRlUcpa5H53frKLDFFx1a7C/yOCMHhwuFTfV2c27+3Fi/5+VPp3WKRBjpMX0g==", "8e6b4e01-c286-4937-bb29-bf511559c9e6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38ba6810-2800-4ac8-b005-5c27e8248951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f7e951cb-7b79-4aab-bf2a-738286980d7c", "AQAAAAEAACcQAAAAEGgXuPDPkP6SGpv/FwQNczGRpilpwENVigAnCFL2kg77Lu9A94+a0w44hLB0mKfQNw==", "8489cf5a-ba75-496c-8aa6-fe3dbf07626f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6bab54d5-5a88-4128-92d2-4d12ad0baa32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f5c10b6a-0bf6-40c1-9ed0-7cfeafab90c2", "AQAAAAEAACcQAAAAEHeB29iL5A+NMUoX/hK/UUyxZbVB8IC+jXXks78zPOka8iKOxlUWbS/bZE4Y3Q7gGg==", "7e5c5001-1268-4406-92d8-5cb328ab448c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "driverUser1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "0d9be9d3-9a4c-47d2-975a-da57081e11ff", "AQAAAAEAACcQAAAAEIDb22IQwfrxSGIbzgKmj7IecJxdzlxPNUhhW5JNSV3XSX3UF20cqNc3Qm4OJox2qA==", "1234567893", "2c2bb34b-bd71-4163-a40d-db10ef6dfa34" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "driverUser2",
                columns: new[] { "ConcurrencyStamp", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "41a89ea9-1435-4bf3-b4ee-0e587ff083c7", "0987654321", "aeb6dfee-8fc8-42ce-b77b-baebba7568b9" });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 10, 11, 23, 8, 21, 640, DateTimeKind.Local).AddTicks(7402));

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 8, 11, 23, 8, 21, 640, DateTimeKind.Local).AddTicks(7404));

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 5, 11, 23, 8, 21, 640, DateTimeKind.Local).AddTicks(7406));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 6, 23, 8, 19, 533, DateTimeKind.Local).AddTicks(7553));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 7, 23, 8, 19, 533, DateTimeKind.Local).AddTicks(7556));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 8, 23, 8, 19, 533, DateTimeKind.Local).AddTicks(7558));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 9, 23, 8, 19, 533, DateTimeKind.Local).AddTicks(7560));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 10, 23, 8, 19, 533, DateTimeKind.Local).AddTicks(7561));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 11, 23, 8, 19, 533, DateTimeKind.Local).AddTicks(7563));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 22, 23, 8, 19, 541, DateTimeKind.Local).AddTicks(7148));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 1, 23, 8, 19, 541, DateTimeKind.Local).AddTicks(7205));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 1,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 10, 23, 8, 21, 603, DateTimeKind.Local).AddTicks(8985));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 2,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 9, 23, 8, 21, 603, DateTimeKind.Local).AddTicks(8993));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 3,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 8, 23, 8, 21, 603, DateTimeKind.Local).AddTicks(8995));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 4,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 7, 23, 8, 21, 603, DateTimeKind.Local).AddTicks(8998));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 5,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 6, 23, 8, 21, 603, DateTimeKind.Local).AddTicks(9000));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2024, 11, 6, 23, 8, 21, 619, DateTimeKind.Local).AddTicks(6607));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2024, 11, 7, 23, 8, 21, 619, DateTimeKind.Local).AddTicks(6611));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2024, 11, 8, 23, 8, 21, 619, DateTimeKind.Local).AddTicks(6613));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 4,
                column: "Timestamp",
                value: new DateTime(2024, 11, 9, 23, 8, 21, 619, DateTimeKind.Local).AddTicks(6615));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 5,
                column: "Timestamp",
                value: new DateTime(2024, 11, 10, 23, 8, 21, 619, DateTimeKind.Local).AddTicks(6618));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1,
                column: "LicenseExpiryDate",
                value: new DateTime(2025, 11, 11, 23, 8, 20, 409, DateTimeKind.Local).AddTicks(6453));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 2,
                column: "LicenseExpiryDate",
                value: new DateTime(2025, 11, 11, 23, 8, 20, 409, DateTimeKind.Local).AddTicks(6460));

            migrationBuilder.UpdateData(
                table: "FuelPrices",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 11, 8, 23, 8, 21, 633, DateTimeKind.Local).AddTicks(8686));

            migrationBuilder.UpdateData(
                table: "FuelPrices",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 11, 9, 23, 8, 21, 633, DateTimeKind.Local).AddTicks(8689));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                column: "InvoiceDate",
                value: new DateTime(2024, 11, 1, 23, 8, 19, 550, DateTimeKind.Local).AddTicks(6683));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 2,
                column: "InvoiceDate",
                value: new DateTime(2024, 11, 2, 23, 8, 19, 550, DateTimeKind.Local).AddTicks(6686));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 3,
                column: "InvoiceDate",
                value: new DateTime(2024, 11, 3, 23, 8, 19, 550, DateTimeKind.Local).AddTicks(6734));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 4,
                column: "InvoiceDate",
                value: new DateTime(2024, 11, 4, 23, 8, 19, 550, DateTimeKind.Local).AddTicks(6736));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 5,
                column: "InvoiceDate",
                value: new DateTime(2024, 11, 5, 23, 8, 19, 550, DateTimeKind.Local).AddTicks(6738));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 1,
                column: "OfferDate",
                value: new DateTime(2024, 11, 1, 23, 8, 19, 557, DateTimeKind.Local).AddTicks(7639));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 2,
                column: "OfferDate",
                value: new DateTime(2024, 11, 3, 23, 8, 19, 557, DateTimeKind.Local).AddTicks(7643));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 3,
                column: "OfferDate",
                value: new DateTime(2024, 11, 6, 23, 8, 19, 557, DateTimeKind.Local).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 4,
                column: "OfferDate",
                value: new DateTime(2024, 11, 9, 23, 8, 19, 557, DateTimeKind.Local).AddTicks(7647));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 5,
                column: "OfferDate",
                value: new DateTime(2024, 11, 11, 23, 8, 19, 557, DateTimeKind.Local).AddTicks(7649));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 11, 23, 8, 20, 386, DateTimeKind.Local).AddTicks(6591), new DateTime(2024, 11, 18, 23, 8, 20, 386, DateTimeKind.Local).AddTicks(6588) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 11, 23, 8, 20, 386, DateTimeKind.Local).AddTicks(6597), new DateTime(2024, 11, 21, 23, 8, 20, 386, DateTimeKind.Local).AddTicks(6595) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 11, 23, 8, 20, 386, DateTimeKind.Local).AddTicks(6613), new DateTime(2024, 11, 26, 23, 8, 20, 386, DateTimeKind.Local).AddTicks(6611) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 11, 23, 8, 20, 386, DateTimeKind.Local).AddTicks(6623), new DateTime(2024, 11, 14, 23, 8, 20, 386, DateTimeKind.Local).AddTicks(6620) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 11, 23, 8, 20, 386, DateTimeKind.Local).AddTicks(6632), new DateTime(2024, 11, 15, 23, 8, 20, 386, DateTimeKind.Local).AddTicks(6630) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastYearMaintenance",
                value: new DateTime(2024, 8, 11, 23, 8, 21, 611, DateTimeKind.Local).AddTicks(580));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastYearMaintenance",
                value: new DateTime(2024, 10, 11, 23, 8, 21, 611, DateTimeKind.Local).AddTicks(588));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "ClientCompanies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                table: "Addresses",
                type: "float",
                nullable: true,
                comment: "Longitude of the address",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "Longitude of the address");

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "Addresses",
                type: "float",
                nullable: true,
                comment: "Latitude of the address",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "Latitude of the address");

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Latitude", "Longitude", "PostalCode" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Latitude", "Longitude", "PostalCode" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Latitude", "Longitude", "PostalCode" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Latitude", "Longitude", "PostalCode" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Latitude", "Longitude", "PostalCode" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Latitude", "Longitude", "PostalCode" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Latitude", "Longitude", "PostalCode" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Latitude", "Longitude", "PostalCode" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Latitude", "Longitude", "PostalCode" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Latitude", "Longitude", "PostalCode" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20ddc22c-ca6d-4feb-a688-0f31a430b5eb",
                column: "ConcurrencyStamp",
                value: "8694664e-8572-4577-9874-3535c34b1643");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27609f35-fbc8-4dc4-9d12-7ff2dd400327",
                column: "ConcurrencyStamp",
                value: "4e704932-9813-4771-acc0-f13efa31942d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "350868c0-bf0f-4f70-b4c9-155351bc6429",
                column: "ConcurrencyStamp",
                value: "1bc878f6-1c2c-41b4-a9e0-043bd333721b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d000e64-c056-419a-950f-1992bd1e910d",
                column: "ConcurrencyStamp",
                value: "96e8b0ef-8f83-45c6-bbf5-3a319f77ab41");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99027aaa-d346-4dd9-a467-15d74576c080",
                column: "ConcurrencyStamp",
                value: "496dd42c-45f6-4907-8fef-dec395a68fa2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20450cff-816f-49c8-9546-1c603aec0301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "05044377-74b3-42ba-8eda-f54172d28293", "AQAAAAEAACcQAAAAEJyYcVlj/TNOnCr8AcLQxsVu7nGJPlYYfORcissyE0c7F7oh6MiJwm/VtGw0MeRFDw==", "261c6865-0b43-4469-88e4-4f961792b19e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e8be95a-186e-403b-b4aa-3874750a3563",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9bcec42f-2f89-46bc-b458-2e74a91b05b7", "AQAAAAEAACcQAAAAEDPR9F3MYceiXwswnkPXMdwNPev+oVdekICx47FvC/zV5oFGIzLuWrdjc/R2kmdU9w==", "5601b09f-c14e-479a-85fa-99d75ba745b3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38ba6810-2800-4ac8-b005-5c27e8248951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2f0d962d-e7f2-4185-8635-9ac630402de7", "AQAAAAEAACcQAAAAEOz7/+yH4vDy6s3u4anWYjCeNUSNwC0o8q75VEUWVTheHKaZkzIPmL9Va9IFqryR1w==", "f59cffbf-b38a-4406-947e-a9342003771a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6bab54d5-5a88-4128-92d2-4d12ad0baa32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e50f9bb5-b701-41b4-8fb2-df09d492e835", "AQAAAAEAACcQAAAAEC8CvHSBQ939jDr+T4uUHyciDaNtJpO1wiL2WXfNHw9GkACv8K115rNWttPce5dvLw==", "370846b7-f077-4b9f-beb5-bf68cc682764" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "driverUser1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "8ad2baff-24e1-4627-995f-d653eda93236", "AQAAAAEAACcQAAAAEJqoHuznAUK3v2TG7IybsPfE2Nac/lFihiISBS5KUqEc55DPDBactYNDV9CGSSv5dA==", null, "df65b492-5fa0-4dc4-8dfd-9f4a9c113e9d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "driverUser2",
                columns: new[] { "ConcurrencyStamp", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "9a4f9030-d5a1-4d4d-8077-1c3c4616d003", null, "bd65825d-85a6-4f29-8086-60ca4e577b28" });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 10, 11, 0, 14, 30, 500, DateTimeKind.Local).AddTicks(8971));

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 8, 11, 0, 14, 30, 500, DateTimeKind.Local).AddTicks(8975));

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 5, 11, 0, 14, 30, 500, DateTimeKind.Local).AddTicks(8979));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 6, 0, 14, 28, 500, DateTimeKind.Local).AddTicks(6570));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 7, 0, 14, 28, 500, DateTimeKind.Local).AddTicks(6572));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 8, 0, 14, 28, 500, DateTimeKind.Local).AddTicks(6574));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 9, 0, 14, 28, 500, DateTimeKind.Local).AddTicks(6576));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 10, 0, 14, 28, 500, DateTimeKind.Local).AddTicks(6578));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 11, 0, 14, 28, 500, DateTimeKind.Local).AddTicks(6580));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EmailAddress" },
                values: new object[] { new DateTime(2024, 10, 22, 0, 14, 28, 509, DateTimeKind.Local).AddTicks(5324), "" });

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EmailAddress" },
                values: new object[] { new DateTime(2024, 11, 1, 0, 14, 28, 509, DateTimeKind.Local).AddTicks(5354), "yyotova@tu-sofia.bg" });

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 1,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 10, 0, 14, 30, 452, DateTimeKind.Local).AddTicks(4128));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 2,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 9, 0, 14, 30, 452, DateTimeKind.Local).AddTicks(4144));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 3,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 8, 0, 14, 30, 452, DateTimeKind.Local).AddTicks(4147));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 4,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 7, 0, 14, 30, 452, DateTimeKind.Local).AddTicks(4150));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 5,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 6, 0, 14, 30, 452, DateTimeKind.Local).AddTicks(4153));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2024, 11, 6, 0, 14, 30, 471, DateTimeKind.Local).AddTicks(2255));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2024, 11, 7, 0, 14, 30, 471, DateTimeKind.Local).AddTicks(2260));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2024, 11, 8, 0, 14, 30, 471, DateTimeKind.Local).AddTicks(2262));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 4,
                column: "Timestamp",
                value: new DateTime(2024, 11, 9, 0, 14, 30, 471, DateTimeKind.Local).AddTicks(2267));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 5,
                column: "Timestamp",
                value: new DateTime(2024, 11, 10, 0, 14, 30, 471, DateTimeKind.Local).AddTicks(2270));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1,
                column: "LicenseExpiryDate",
                value: new DateTime(2025, 11, 11, 0, 14, 29, 345, DateTimeKind.Local).AddTicks(3077));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 2,
                column: "LicenseExpiryDate",
                value: new DateTime(2025, 11, 11, 0, 14, 29, 345, DateTimeKind.Local).AddTicks(3086));

            migrationBuilder.UpdateData(
                table: "FuelPrices",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 11, 8, 0, 14, 30, 490, DateTimeKind.Local).AddTicks(3218));

            migrationBuilder.UpdateData(
                table: "FuelPrices",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 11, 9, 0, 14, 30, 490, DateTimeKind.Local).AddTicks(3220));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                column: "InvoiceDate",
                value: new DateTime(2024, 11, 1, 0, 14, 28, 519, DateTimeKind.Local).AddTicks(285));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 2,
                column: "InvoiceDate",
                value: new DateTime(2024, 11, 2, 0, 14, 28, 519, DateTimeKind.Local).AddTicks(287));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 3,
                column: "InvoiceDate",
                value: new DateTime(2024, 11, 3, 0, 14, 28, 519, DateTimeKind.Local).AddTicks(290));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 4,
                column: "InvoiceDate",
                value: new DateTime(2024, 11, 4, 0, 14, 28, 519, DateTimeKind.Local).AddTicks(292));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 5,
                column: "InvoiceDate",
                value: new DateTime(2024, 11, 5, 0, 14, 28, 519, DateTimeKind.Local).AddTicks(293));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 1,
                column: "OfferDate",
                value: new DateTime(2024, 11, 1, 0, 14, 28, 526, DateTimeKind.Local).AddTicks(2992));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 2,
                column: "OfferDate",
                value: new DateTime(2024, 11, 3, 0, 14, 28, 526, DateTimeKind.Local).AddTicks(2996));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 3,
                column: "OfferDate",
                value: new DateTime(2024, 11, 6, 0, 14, 28, 526, DateTimeKind.Local).AddTicks(2998));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 4,
                column: "OfferDate",
                value: new DateTime(2024, 11, 9, 0, 14, 28, 526, DateTimeKind.Local).AddTicks(3000));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 5,
                column: "OfferDate",
                value: new DateTime(2024, 11, 11, 0, 14, 28, 526, DateTimeKind.Local).AddTicks(3002));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 11, 0, 14, 29, 313, DateTimeKind.Local).AddTicks(6025), new DateTime(2024, 11, 18, 0, 14, 29, 313, DateTimeKind.Local).AddTicks(6019) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 11, 0, 14, 29, 313, DateTimeKind.Local).AddTicks(6032), new DateTime(2024, 11, 21, 0, 14, 29, 313, DateTimeKind.Local).AddTicks(6030) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 11, 0, 14, 29, 313, DateTimeKind.Local).AddTicks(6056), new DateTime(2024, 11, 26, 0, 14, 29, 313, DateTimeKind.Local).AddTicks(6054) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 11, 0, 14, 29, 313, DateTimeKind.Local).AddTicks(6075), new DateTime(2024, 11, 14, 0, 14, 29, 313, DateTimeKind.Local).AddTicks(6072) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 11, 0, 14, 29, 313, DateTimeKind.Local).AddTicks(6086), new DateTime(2024, 11, 15, 0, 14, 29, 313, DateTimeKind.Local).AddTicks(6084) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastYearMaintenance",
                value: new DateTime(2024, 8, 11, 0, 14, 30, 461, DateTimeKind.Local).AddTicks(9031));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastYearMaintenance",
                value: new DateTime(2024, 10, 11, 0, 14, 30, 461, DateTimeKind.Local).AddTicks(9041));
        }
    }
}

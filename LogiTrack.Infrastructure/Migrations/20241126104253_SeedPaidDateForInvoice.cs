using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogiTrack.Infrastructure.Migrations
{
    public partial class SeedPaidDateForInvoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PaidDate",
                table: "Invoices",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20ddc22c-ca6d-4feb-a688-0f31a430b5eb",
                column: "ConcurrencyStamp",
                value: "b4364b68-1c49-4397-a2f7-f274eaa92f82");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27609f35-fbc8-4dc4-9d12-7ff2dd400327",
                column: "ConcurrencyStamp",
                value: "e9d53cfe-0e28-4920-8c53-41df50e6d9c9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "350868c0-bf0f-4f70-b4c9-155351bc6429",
                column: "ConcurrencyStamp",
                value: "6f390d81-c448-45d2-9ad9-21ef5464ccc2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d000e64-c056-419a-950f-1992bd1e910d",
                column: "ConcurrencyStamp",
                value: "6903f1bf-c43d-4ec2-9106-3854c4c02a92");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99027aaa-d346-4dd9-a467-15d74576c080",
                column: "ConcurrencyStamp",
                value: "82a989cc-78ef-45b4-a5be-2a7700b5b939");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20450cff-816f-49c8-9546-1c603aec0301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f844bd81-5743-4c98-9da1-ef6c3367993e", "AQAAAAEAACcQAAAAEHXGi5xWdwNDVmHTiRD1j5R5BG1zJkakwO8z8yykIiLYYglPzTjRzSNTOsQuEnbIMQ==", "4bd291cc-dc16-42fa-8dd7-73aa47ccdd66" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e8be95a-186e-403b-b4aa-3874750a3563",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "02c06319-c9b9-409d-8162-33051924081b", "AQAAAAEAACcQAAAAEPulVECI/xbZsKF4rsb1nW58cUnkCoM4xXN/sYxUNUDzIPg6cFTjti/DCX/J8g8NCQ==", "f3957724-0bf0-42cf-bd9c-3ff3b9ca0eaf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38ba6810-2800-4ac8-b005-5c27e8248951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1104599f-329a-4478-ba66-df0b909651c7", "AQAAAAEAACcQAAAAEJSRODrMUrEqI1mfhwarMuPN9wK6+5p49lAd+z4q3BGGz1ZX+xRN/uNZ1A4CHkNaXw==", "9e533e27-e656-4726-83e1-5335da3e636c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6bab54d5-5a88-4128-92d2-4d12ad0baa32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "811cd568-2602-42bb-97c8-94ec102d9108", "AQAAAAEAACcQAAAAEOrmziUIsoN2rqe8zWL9UdpPO3NKAop24WhjncUy3taEAtCkhTuIZLYuapI2/kd0uw==", "d6609110-7c13-48d1-8f17-6e5d5c357b43" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "driverUser1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5b8571b4-ce92-41d3-85f2-7d13ce4d623d", "AQAAAAEAACcQAAAAEBZl4mIAc83agWCQC7wKbbTLfeGQkeznrc0LpMiE1SYARhe37nEbtucJ3a/BiRVEQQ==", "f5052cbc-45de-4b80-9592-4ff7731e6b1f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "driverUser2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "cba913d6-441d-4ee0-8c21-34c0d7aef9cd", "d6767349-7670-48b5-9e1e-188e1534be5f" });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 10, 26, 12, 42, 51, 950, DateTimeKind.Local).AddTicks(7449));

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 8, 26, 12, 42, 51, 950, DateTimeKind.Local).AddTicks(7451));

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 5, 26, 12, 42, 51, 950, DateTimeKind.Local).AddTicks(7453));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 21, 12, 42, 50, 406, DateTimeKind.Local).AddTicks(7479));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 22, 12, 42, 50, 406, DateTimeKind.Local).AddTicks(7482));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 23, 12, 42, 50, 406, DateTimeKind.Local).AddTicks(7483));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 24, 12, 42, 50, 406, DateTimeKind.Local).AddTicks(7485));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 25, 12, 42, 50, 406, DateTimeKind.Local).AddTicks(7487));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 26, 12, 42, 50, 406, DateTimeKind.Local).AddTicks(7489));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 6, 12, 42, 50, 412, DateTimeKind.Local).AddTicks(9185));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 16, 12, 42, 50, 412, DateTimeKind.Local).AddTicks(9214));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 1,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 25, 12, 42, 51, 921, DateTimeKind.Local).AddTicks(2475));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 2,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 24, 12, 42, 51, 921, DateTimeKind.Local).AddTicks(2488));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 3,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 23, 12, 42, 51, 921, DateTimeKind.Local).AddTicks(2504));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 4,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 22, 12, 42, 51, 921, DateTimeKind.Local).AddTicks(2506));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 5,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 21, 12, 42, 51, 921, DateTimeKind.Local).AddTicks(2508));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2024, 11, 21, 12, 42, 51, 933, DateTimeKind.Local).AddTicks(145));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2024, 11, 22, 12, 42, 51, 933, DateTimeKind.Local).AddTicks(147));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2024, 11, 23, 12, 42, 51, 933, DateTimeKind.Local).AddTicks(149));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 4,
                column: "Timestamp",
                value: new DateTime(2024, 11, 24, 12, 42, 51, 933, DateTimeKind.Local).AddTicks(150));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 5,
                column: "Timestamp",
                value: new DateTime(2024, 11, 25, 12, 42, 51, 933, DateTimeKind.Local).AddTicks(152));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1,
                column: "LicenseExpiryDate",
                value: new DateTime(2025, 11, 26, 12, 42, 51, 112, DateTimeKind.Local).AddTicks(2622));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 2,
                column: "LicenseExpiryDate",
                value: new DateTime(2025, 11, 26, 12, 42, 51, 112, DateTimeKind.Local).AddTicks(2626));

            migrationBuilder.UpdateData(
                table: "FuelPrices",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 11, 23, 12, 42, 51, 944, DateTimeKind.Local).AddTicks(8129));

            migrationBuilder.UpdateData(
                table: "FuelPrices",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 11, 24, 12, 42, 51, 944, DateTimeKind.Local).AddTicks(8130));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InvoiceDate", "PaidDate" },
                values: new object[] { new DateTime(2024, 11, 16, 12, 42, 50, 420, DateTimeKind.Local).AddTicks(9306), new DateTime(2024, 11, 21, 12, 42, 50, 420, DateTimeKind.Local).AddTicks(9304) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 2,
                column: "InvoiceDate",
                value: new DateTime(2024, 11, 17, 12, 42, 50, 420, DateTimeKind.Local).AddTicks(9309));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "InvoiceDate", "PaidDate" },
                values: new object[] { new DateTime(2024, 11, 18, 12, 42, 50, 420, DateTimeKind.Local).AddTicks(9312), new DateTime(2024, 11, 20, 12, 42, 50, 420, DateTimeKind.Local).AddTicks(9311) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 4,
                column: "InvoiceDate",
                value: new DateTime(2024, 11, 19, 12, 42, 50, 420, DateTimeKind.Local).AddTicks(9314));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 5,
                column: "InvoiceDate",
                value: new DateTime(2024, 11, 20, 12, 42, 50, 420, DateTimeKind.Local).AddTicks(9316));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 1,
                column: "OfferDate",
                value: new DateTime(2024, 11, 11, 12, 42, 50, 426, DateTimeKind.Local).AddTicks(7537));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 2,
                column: "OfferDate",
                value: new DateTime(2024, 11, 10, 12, 42, 50, 426, DateTimeKind.Local).AddTicks(7539));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 3,
                column: "OfferDate",
                value: new DateTime(2024, 11, 11, 12, 42, 50, 426, DateTimeKind.Local).AddTicks(7540));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 4,
                column: "OfferDate",
                value: new DateTime(2024, 11, 14, 12, 42, 50, 426, DateTimeKind.Local).AddTicks(7542));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 5,
                column: "OfferDate",
                value: new DateTime(2024, 11, 13, 12, 42, 50, 426, DateTimeKind.Local).AddTicks(7543));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 42, 51, 92, DateTimeKind.Local).AddTicks(2983), new DateTime(2024, 12, 3, 12, 42, 51, 92, DateTimeKind.Local).AddTicks(2979) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 5, 12, 42, 51, 92, DateTimeKind.Local).AddTicks(2988), new DateTime(2024, 12, 6, 12, 42, 51, 92, DateTimeKind.Local).AddTicks(2987) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 4, 12, 42, 51, 92, DateTimeKind.Local).AddTicks(2999), new DateTime(2024, 12, 1, 12, 42, 51, 92, DateTimeKind.Local).AddTicks(2997) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 3, 12, 42, 51, 92, DateTimeKind.Local).AddTicks(3010), new DateTime(2024, 11, 23, 12, 42, 51, 92, DateTimeKind.Local).AddTicks(3008) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 2, 12, 42, 51, 92, DateTimeKind.Local).AddTicks(3017), new DateTime(2024, 11, 21, 12, 42, 51, 92, DateTimeKind.Local).AddTicks(3015) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastYearMaintenance",
                value: new DateTime(2024, 8, 26, 12, 42, 51, 927, DateTimeKind.Local).AddTicks(1172));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastYearMaintenance",
                value: new DateTime(2024, 10, 26, 12, 42, 51, 927, DateTimeKind.Local).AddTicks(1176));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaidDate",
                table: "Invoices");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20ddc22c-ca6d-4feb-a688-0f31a430b5eb",
                column: "ConcurrencyStamp",
                value: "2bc6ad30-8ab3-48d7-b87d-2cc1db89e8b5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27609f35-fbc8-4dc4-9d12-7ff2dd400327",
                column: "ConcurrencyStamp",
                value: "50779537-a518-4971-9dc9-abf2ffeae6b2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "350868c0-bf0f-4f70-b4c9-155351bc6429",
                column: "ConcurrencyStamp",
                value: "21b6bd4f-7417-4e3c-8561-cbcae9a334c5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d000e64-c056-419a-950f-1992bd1e910d",
                column: "ConcurrencyStamp",
                value: "a60d2b2a-cca1-4118-b81a-af73b9877fce");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99027aaa-d346-4dd9-a467-15d74576c080",
                column: "ConcurrencyStamp",
                value: "d0f7f23b-4ed0-400d-af9e-9ab2d5b727dc");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20450cff-816f-49c8-9546-1c603aec0301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b2b7902e-153e-4033-8781-9d2b609867b1", "AQAAAAEAACcQAAAAEDdOtzwtZwlz1LE2UNGeF239RIXDqAophBIItkoZ3G90ZHqnf54bPe6Wln3rEjAqsw==", "2143a6d2-9dbc-4537-807d-c5d6564c6e9f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e8be95a-186e-403b-b4aa-3874750a3563",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bf4d386c-3fda-4c2d-8c68-f1e1af90338b", "AQAAAAEAACcQAAAAECsbMsxHJqhKVru4aFHzLsjaCND9/Z+OXesatIwZ8ppwoNwi0Yo/IYTPR/xh3HQJeA==", "ade47802-a74e-4432-b491-6d1d1b69ef6d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38ba6810-2800-4ac8-b005-5c27e8248951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ef584253-b26d-4f89-ac75-606cd2110506", "AQAAAAEAACcQAAAAEEkwI6yV32HWaacRMhG3Y9siCYijd0dcbuJEZh51qJYJr7AD5eOEkHCgCvrdxKPySw==", "1a40f5e9-963d-41d6-a39c-a8b58fd16249" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6bab54d5-5a88-4128-92d2-4d12ad0baa32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "48af9efe-bb57-4d8d-a612-96f0c7da6926", "AQAAAAEAACcQAAAAEOYj8niyizOUbVpTFvE8tsaChifQMi58BvThpP/uHq2F4aZgpWAE68+ST12Q9rzTUw==", "241e097f-3900-49f0-9dd4-3a92ce71d77f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "driverUser1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "87ddc2ca-a8cb-4854-9ffb-f1b5585980ec", "AQAAAAEAACcQAAAAECDA57jIk1mom0sjmuTQIlQ50g+UvH6y4g7Sfh0IAXSxHqPke8EHOYBuBdZZGlZsjQ==", "dd53b995-f0f8-4e25-a557-27817578e55f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "driverUser2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f2347718-8c68-4e17-a5b9-4def37c70315", "2f617ba2-9035-44fc-a67a-a7ba57dd6d36" });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 10, 23, 12, 46, 44, 736, DateTimeKind.Local).AddTicks(1042));

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 8, 23, 12, 46, 44, 736, DateTimeKind.Local).AddTicks(1046));

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 5, 23, 12, 46, 44, 736, DateTimeKind.Local).AddTicks(1048));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 18, 12, 46, 42, 826, DateTimeKind.Local).AddTicks(4092));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 19, 12, 46, 42, 826, DateTimeKind.Local).AddTicks(4096));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 20, 12, 46, 42, 826, DateTimeKind.Local).AddTicks(4099));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 21, 12, 46, 42, 826, DateTimeKind.Local).AddTicks(4102));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 22, 12, 46, 42, 826, DateTimeKind.Local).AddTicks(4105));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 23, 12, 46, 42, 826, DateTimeKind.Local).AddTicks(4108));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 3, 12, 46, 42, 835, DateTimeKind.Local).AddTicks(1665));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 13, 12, 46, 42, 835, DateTimeKind.Local).AddTicks(1703));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 1,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 22, 12, 46, 44, 686, DateTimeKind.Local).AddTicks(2323));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 2,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 21, 12, 46, 44, 686, DateTimeKind.Local).AddTicks(2336));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 3,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 20, 12, 46, 44, 686, DateTimeKind.Local).AddTicks(2341));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 4,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 19, 12, 46, 44, 686, DateTimeKind.Local).AddTicks(2344));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 5,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 18, 12, 46, 44, 686, DateTimeKind.Local).AddTicks(2347));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2024, 11, 18, 12, 46, 44, 705, DateTimeKind.Local).AddTicks(7187));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2024, 11, 19, 12, 46, 44, 705, DateTimeKind.Local).AddTicks(7191));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2024, 11, 20, 12, 46, 44, 705, DateTimeKind.Local).AddTicks(7194));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 4,
                column: "Timestamp",
                value: new DateTime(2024, 11, 21, 12, 46, 44, 705, DateTimeKind.Local).AddTicks(7197));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 5,
                column: "Timestamp",
                value: new DateTime(2024, 11, 22, 12, 46, 44, 705, DateTimeKind.Local).AddTicks(7199));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1,
                column: "LicenseExpiryDate",
                value: new DateTime(2025, 11, 23, 12, 46, 43, 624, DateTimeKind.Local).AddTicks(2542));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 2,
                column: "LicenseExpiryDate",
                value: new DateTime(2025, 11, 23, 12, 46, 43, 624, DateTimeKind.Local).AddTicks(2552));

            migrationBuilder.UpdateData(
                table: "FuelPrices",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 11, 20, 12, 46, 44, 726, DateTimeKind.Local).AddTicks(8455));

            migrationBuilder.UpdateData(
                table: "FuelPrices",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 11, 21, 12, 46, 44, 726, DateTimeKind.Local).AddTicks(8458));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                column: "InvoiceDate",
                value: new DateTime(2024, 11, 13, 12, 46, 42, 844, DateTimeKind.Local).AddTicks(1641));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 2,
                column: "InvoiceDate",
                value: new DateTime(2024, 11, 14, 12, 46, 42, 844, DateTimeKind.Local).AddTicks(1646));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 3,
                column: "InvoiceDate",
                value: new DateTime(2024, 11, 15, 12, 46, 42, 844, DateTimeKind.Local).AddTicks(1649));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 4,
                column: "InvoiceDate",
                value: new DateTime(2024, 11, 16, 12, 46, 42, 844, DateTimeKind.Local).AddTicks(1652));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 5,
                column: "InvoiceDate",
                value: new DateTime(2024, 11, 17, 12, 46, 42, 844, DateTimeKind.Local).AddTicks(1655));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 1,
                column: "OfferDate",
                value: new DateTime(2024, 11, 8, 12, 46, 42, 852, DateTimeKind.Local).AddTicks(2470));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 2,
                column: "OfferDate",
                value: new DateTime(2024, 11, 7, 12, 46, 42, 852, DateTimeKind.Local).AddTicks(2473));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 3,
                column: "OfferDate",
                value: new DateTime(2024, 11, 8, 12, 46, 42, 852, DateTimeKind.Local).AddTicks(2475));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 4,
                column: "OfferDate",
                value: new DateTime(2024, 11, 11, 12, 46, 42, 852, DateTimeKind.Local).AddTicks(2478));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 5,
                column: "OfferDate",
                value: new DateTime(2024, 11, 10, 12, 46, 42, 852, DateTimeKind.Local).AddTicks(2480));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 3, 12, 46, 43, 590, DateTimeKind.Local).AddTicks(7815), new DateTime(2024, 11, 30, 12, 46, 43, 590, DateTimeKind.Local).AddTicks(7801) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 2, 12, 46, 43, 590, DateTimeKind.Local).AddTicks(8037), new DateTime(2024, 12, 3, 12, 46, 43, 590, DateTimeKind.Local).AddTicks(8034) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 1, 12, 46, 43, 590, DateTimeKind.Local).AddTicks(8102), new DateTime(2024, 11, 28, 12, 46, 43, 590, DateTimeKind.Local).AddTicks(8099) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 10, 31, 12, 46, 43, 590, DateTimeKind.Local).AddTicks(8190), new DateTime(2024, 11, 20, 12, 46, 43, 590, DateTimeKind.Local).AddTicks(8179) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 10, 30, 12, 46, 43, 590, DateTimeKind.Local).AddTicks(8286), new DateTime(2024, 11, 18, 12, 46, 43, 590, DateTimeKind.Local).AddTicks(8272) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastYearMaintenance",
                value: new DateTime(2024, 8, 23, 12, 46, 44, 696, DateTimeKind.Local).AddTicks(446));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastYearMaintenance",
                value: new DateTime(2024, 10, 23, 12, 46, 44, 696, DateTimeKind.Local).AddTicks(455));
        }
    }
}

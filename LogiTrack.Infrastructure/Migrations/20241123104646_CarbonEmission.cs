using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogiTrack.Infrastructure.Migrations
{
    public partial class CarbonEmission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "EmissionFactor",
                table: "Vehicles",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                comment: "Emission factor (kg CO2 per liter)");

            migrationBuilder.AddColumn<double>(
                name: "CarbonEmission",
                table: "Deliveries",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                comment: "Carbon emission blueprint (in kg CO2)");

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
                columns: new[] { "ActualDeliveryDate", "CarbonEmission" },
                values: new object[] { new DateTime(2024, 11, 22, 12, 46, 44, 686, DateTimeKind.Local).AddTicks(2323), 38.700000000000003 });

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ActualDeliveryDate", "CarbonEmission" },
                values: new object[] { new DateTime(2024, 11, 21, 12, 46, 44, 686, DateTimeKind.Local).AddTicks(2336), 40.0 });

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ActualDeliveryDate", "CarbonEmission" },
                values: new object[] { new DateTime(2024, 11, 20, 12, 46, 44, 686, DateTimeKind.Local).AddTicks(2341), 35.0 });

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ActualDeliveryDate", "CarbonEmission" },
                values: new object[] { new DateTime(2024, 11, 19, 12, 46, 44, 686, DateTimeKind.Local).AddTicks(2344), 45.0 });

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ActualDeliveryDate", "CarbonEmission" },
                values: new object[] { new DateTime(2024, 11, 18, 12, 46, 44, 686, DateTimeKind.Local).AddTicks(2347), 50.0 });

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
                columns: new[] { "EmissionFactor", "LastYearMaintenance" },
                values: new object[] { 2.6299999999999999, new DateTime(2024, 8, 23, 12, 46, 44, 696, DateTimeKind.Local).AddTicks(446) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EmissionFactor", "LastYearMaintenance" },
                values: new object[] { 2.6299999999999999, new DateTime(2024, 10, 23, 12, 46, 44, 696, DateTimeKind.Local).AddTicks(455) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmissionFactor",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "CarbonEmission",
                table: "Deliveries");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20ddc22c-ca6d-4feb-a688-0f31a430b5eb",
                column: "ConcurrencyStamp",
                value: "ac78000b-60aa-463f-9654-353f75d81a8c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27609f35-fbc8-4dc4-9d12-7ff2dd400327",
                column: "ConcurrencyStamp",
                value: "c57cf7f1-c6b8-457f-a355-a1dc6587da00");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "350868c0-bf0f-4f70-b4c9-155351bc6429",
                column: "ConcurrencyStamp",
                value: "5dd7fdc6-93f5-41c4-ac8c-a357a33b7fa4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d000e64-c056-419a-950f-1992bd1e910d",
                column: "ConcurrencyStamp",
                value: "ecbe2cd5-b7cf-46bd-8880-ce10bbb2329e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99027aaa-d346-4dd9-a467-15d74576c080",
                column: "ConcurrencyStamp",
                value: "37d6be99-e6b2-4127-8476-c8da397a7fb9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20450cff-816f-49c8-9546-1c603aec0301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c8abac24-cb1a-4f4c-a9f9-ed2dc86551c6", "AQAAAAEAACcQAAAAECE5tzr6QQFCTECzK2CQBKsUACbKJPkFZ7Oxt8TqgPPBM6ZsE6MMNsi6BIY7T5XkPQ==", "9d8ccfbe-73f3-4816-92d4-4dd14c890e4a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e8be95a-186e-403b-b4aa-3874750a3563",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0b7631e5-b462-4600-b572-2b744e7de37a", "AQAAAAEAACcQAAAAEB5QSA0/ejVlk3banMHVp3Abhb+tZziP3nmmcZbLq7GoWpTW1avTEiKy1fDH9hA56g==", "e85bc6b8-671e-4d10-951e-410c7b93ff95" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38ba6810-2800-4ac8-b005-5c27e8248951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "01457993-42f1-4426-ada5-2735146a7e6b", "AQAAAAEAACcQAAAAED8KBSep0haSOHHU8CcJoGddXTAFavYL35RAeXRDuQ1SlhewB4SWc7bHRKOALT+baQ==", "54976d66-e475-48cf-ad4f-f4140edc5691" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6bab54d5-5a88-4128-92d2-4d12ad0baa32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7c4c34a7-4567-49fc-9d7e-ad50fc601da5", "AQAAAAEAACcQAAAAEBfXAL1EvtzZZTFvChFTxVKlTZ4hzZ47xyxeC8x8Wc33YkGNp/VQx8+6G7Ytak0q7g==", "f7051709-90ef-4ff5-9d37-861007ac5f26" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "driverUser1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "37978fcd-5e0d-4d56-88fa-104fececac35", "AQAAAAEAACcQAAAAENU3HpGtKbxseeO3mP3/NIK7tqq4xqYIzCN93Wl3J0rIS2SVHisvgq6l1dFiEd6wAw==", "2f8ce2b8-d2c7-4a55-8d05-4cd5563fcf3a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "driverUser2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f9b4b31a-4ffa-4636-ac3b-197ff8acbcdd", "b18047b0-5c84-4f15-a69c-4711baa5deae" });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 10, 22, 0, 22, 56, 318, DateTimeKind.Local).AddTicks(6604));

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 8, 22, 0, 22, 56, 318, DateTimeKind.Local).AddTicks(6608));

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 5, 22, 0, 22, 56, 318, DateTimeKind.Local).AddTicks(6610));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 17, 0, 22, 54, 456, DateTimeKind.Local).AddTicks(1061));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 18, 0, 22, 54, 456, DateTimeKind.Local).AddTicks(1065));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 19, 0, 22, 54, 456, DateTimeKind.Local).AddTicks(1068));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 20, 0, 22, 54, 456, DateTimeKind.Local).AddTicks(1070));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 21, 0, 22, 54, 456, DateTimeKind.Local).AddTicks(1073));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 22, 0, 22, 54, 456, DateTimeKind.Local).AddTicks(1075));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 2, 0, 22, 54, 466, DateTimeKind.Local).AddTicks(3694));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 12, 0, 22, 54, 466, DateTimeKind.Local).AddTicks(3749));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 1,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 21, 0, 22, 56, 270, DateTimeKind.Local).AddTicks(3672));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 2,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 20, 0, 22, 56, 270, DateTimeKind.Local).AddTicks(3687));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 3,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 19, 0, 22, 56, 270, DateTimeKind.Local).AddTicks(3692));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 4,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 18, 0, 22, 56, 270, DateTimeKind.Local).AddTicks(3697));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 5,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 17, 0, 22, 56, 270, DateTimeKind.Local).AddTicks(3702));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2024, 11, 17, 0, 22, 56, 289, DateTimeKind.Local).AddTicks(9393));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2024, 11, 18, 0, 22, 56, 289, DateTimeKind.Local).AddTicks(9397));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2024, 11, 19, 0, 22, 56, 289, DateTimeKind.Local).AddTicks(9401));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 4,
                column: "Timestamp",
                value: new DateTime(2024, 11, 20, 0, 22, 56, 289, DateTimeKind.Local).AddTicks(9403));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 5,
                column: "Timestamp",
                value: new DateTime(2024, 11, 21, 0, 22, 56, 289, DateTimeKind.Local).AddTicks(9409));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1,
                column: "LicenseExpiryDate",
                value: new DateTime(2025, 11, 22, 0, 22, 55, 447, DateTimeKind.Local).AddTicks(3999));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 2,
                column: "LicenseExpiryDate",
                value: new DateTime(2025, 11, 22, 0, 22, 55, 447, DateTimeKind.Local).AddTicks(4012));

            migrationBuilder.UpdateData(
                table: "FuelPrices",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 11, 19, 0, 22, 56, 309, DateTimeKind.Local).AddTicks(1356));

            migrationBuilder.UpdateData(
                table: "FuelPrices",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 11, 20, 0, 22, 56, 309, DateTimeKind.Local).AddTicks(1359));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                column: "InvoiceDate",
                value: new DateTime(2024, 11, 12, 0, 22, 54, 478, DateTimeKind.Local).AddTicks(2765));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 2,
                column: "InvoiceDate",
                value: new DateTime(2024, 11, 13, 0, 22, 54, 478, DateTimeKind.Local).AddTicks(2770));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 3,
                column: "InvoiceDate",
                value: new DateTime(2024, 11, 14, 0, 22, 54, 478, DateTimeKind.Local).AddTicks(2773));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 4,
                column: "InvoiceDate",
                value: new DateTime(2024, 11, 15, 0, 22, 54, 478, DateTimeKind.Local).AddTicks(2776));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 5,
                column: "InvoiceDate",
                value: new DateTime(2024, 11, 16, 0, 22, 54, 478, DateTimeKind.Local).AddTicks(2779));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 1,
                column: "OfferDate",
                value: new DateTime(2024, 11, 7, 0, 22, 54, 488, DateTimeKind.Local).AddTicks(1861));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 2,
                column: "OfferDate",
                value: new DateTime(2024, 11, 6, 0, 22, 54, 488, DateTimeKind.Local).AddTicks(1865));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 3,
                column: "OfferDate",
                value: new DateTime(2024, 11, 7, 0, 22, 54, 488, DateTimeKind.Local).AddTicks(1868));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 4,
                column: "OfferDate",
                value: new DateTime(2024, 11, 10, 0, 22, 54, 488, DateTimeKind.Local).AddTicks(1942));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 5,
                column: "OfferDate",
                value: new DateTime(2024, 11, 9, 0, 22, 54, 488, DateTimeKind.Local).AddTicks(1946));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 2, 0, 22, 55, 413, DateTimeKind.Local).AddTicks(6776), new DateTime(2024, 11, 29, 0, 22, 55, 413, DateTimeKind.Local).AddTicks(6770) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 1, 0, 22, 55, 413, DateTimeKind.Local).AddTicks(6785), new DateTime(2024, 12, 2, 0, 22, 55, 413, DateTimeKind.Local).AddTicks(6782) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 10, 31, 0, 22, 55, 413, DateTimeKind.Local).AddTicks(6807), new DateTime(2024, 11, 27, 0, 22, 55, 413, DateTimeKind.Local).AddTicks(6805) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 10, 30, 0, 22, 55, 413, DateTimeKind.Local).AddTicks(6823), new DateTime(2024, 11, 19, 0, 22, 55, 413, DateTimeKind.Local).AddTicks(6821) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 10, 29, 0, 22, 55, 413, DateTimeKind.Local).AddTicks(6839), new DateTime(2024, 11, 17, 0, 22, 55, 413, DateTimeKind.Local).AddTicks(6835) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastYearMaintenance",
                value: new DateTime(2024, 8, 22, 0, 22, 56, 279, DateTimeKind.Local).AddTicks(8470));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastYearMaintenance",
                value: new DateTime(2024, 10, 22, 0, 22, 56, 279, DateTimeKind.Local).AddTicks(8479));
        }
    }
}

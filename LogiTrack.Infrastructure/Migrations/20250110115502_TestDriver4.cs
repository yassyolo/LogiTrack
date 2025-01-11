using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogiTrack.Infrastructure.Migrations
{
    public partial class TestDriver4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20ddc22c-ca6d-4feb-a688-0f31a430b5eb",
                column: "ConcurrencyStamp",
                value: "0a37ff45-9ce3-4e73-bcaf-6333ba366179");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27609f35-fbc8-4dc4-9d12-7ff2dd400327",
                column: "ConcurrencyStamp",
                value: "5e3ea5b9-364b-4fa3-979f-78738b5b9cf7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "350868c0-bf0f-4f70-b4c9-155351bc6429",
                column: "ConcurrencyStamp",
                value: "4a2ff5ef-2fd6-4e25-8355-4b4252259310");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d000e64-c056-419a-950f-1992bd1e910d",
                column: "ConcurrencyStamp",
                value: "d4546adf-c529-4bcd-808a-e267d5f81875");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99027aaa-d346-4dd9-a467-15d74576c080",
                column: "ConcurrencyStamp",
                value: "e9287a14-1c15-43fb-819a-35b69d52e0e8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20450cff-816f-49c8-9546-1c603aec0301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3dbbe63b-eb75-4066-aec0-139c906ed855", "AQAAAAEAACcQAAAAEMHRCHV5mf0o1JYKmYFz74wddZbOxvcNnUeq3zhQgbEA3MFToAVjRRfxB6nKPppDpw==", "e1f57227-d1ec-46ee-a93c-fd115e83056c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e8be95a-186e-403b-b4aa-3874750a3563",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2ffddce9-5a70-4d5f-a209-1aff22a569e4", "AQAAAAEAACcQAAAAEC8/GT6YIleAUeLJr2C2Zw9Ol76+vMCOthKj0lmZP3D5odUIQiNS1AEg51BhplGKOw==", "28d02390-7a63-4585-8fd5-422b871ab0e0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38ba6810-2800-4ac8-b005-5c27e8248951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2ec77d74-e290-4b0c-9779-dd640f8712d3", "AQAAAAEAACcQAAAAEJOebUyuag0mSI9wIlmg6HRpf2f4ZtViJL14eRxjXbb+knzU5PBVDZQFA6jt2W0+BQ==", "842bb01a-6697-4342-b722-2141403e086e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6bab54d5-5a88-4128-92d2-4d12ad0baa32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "62dc386a-d17d-4026-b5e3-730907d1faff", "AQAAAAEAACcQAAAAEAdUCLK/zYRidLiX25aYWVRaMDxmhc8RzOpy1wUPtnURh7l11hegsToRGqmAPL2iOw==", "1d8196e8-3dff-4863-918e-a7489bde2319" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "driverUser1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "494ca703-dcf1-4e94-a0a5-2ca259faf9cf", "AQAAAAEAACcQAAAAEOyHcLI+TuulV6b5J6oDnyqFXLarRaf6Bq+Go5LT2Du+FEqz+UmCuTn/fD/BWEk/WA==", "374095e5-fe1c-4007-90ba-5aaa198c0b13" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "driverUser2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "597ed493-7fbc-439c-9953-9c1bb24c9851", "AQAAAAEAACcQAAAAEHf95Xx03TVWjgbGfi/Lhig+SX8Ym3nAA5ZO42tk2CTL8KW9GKJiJVYd2uuUvS4Lvw==", "5baa76af-180c-4f62-9709-18c90e644f53" });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 12, 10, 13, 55, 1, 413, DateTimeKind.Local).AddTicks(2068));

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 10, 10, 13, 55, 1, 413, DateTimeKind.Local).AddTicks(2070));

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 7, 10, 13, 55, 1, 413, DateTimeKind.Local).AddTicks(2072));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateSubmitted",
                value: new DateTime(2025, 1, 5, 13, 55, 1, 327, DateTimeKind.Local).AddTicks(9452));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateSubmitted",
                value: new DateTime(2025, 1, 6, 13, 55, 1, 327, DateTimeKind.Local).AddTicks(9454));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateSubmitted",
                value: new DateTime(2025, 1, 7, 13, 55, 1, 327, DateTimeKind.Local).AddTicks(9456));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateSubmitted",
                value: new DateTime(2025, 1, 8, 13, 55, 1, 327, DateTimeKind.Local).AddTicks(9458));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateSubmitted",
                value: new DateTime(2025, 1, 9, 13, 55, 1, 327, DateTimeKind.Local).AddTicks(9460));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateSubmitted",
                value: new DateTime(2025, 1, 10, 13, 55, 1, 327, DateTimeKind.Local).AddTicks(9461));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 12, 21, 13, 55, 1, 334, DateTimeKind.Local).AddTicks(8374));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 12, 31, 13, 55, 1, 334, DateTimeKind.Local).AddTicks(8408));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 1,
                column: "ActualDeliveryDate",
                value: new DateTime(2025, 1, 9, 13, 55, 1, 382, DateTimeKind.Local).AddTicks(9173));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 2,
                column: "ActualDeliveryDate",
                value: new DateTime(2025, 1, 8, 13, 55, 1, 382, DateTimeKind.Local).AddTicks(9176));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 3,
                column: "ActualDeliveryDate",
                value: new DateTime(2025, 1, 7, 13, 55, 1, 382, DateTimeKind.Local).AddTicks(9178));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 4,
                column: "ActualDeliveryDate",
                value: new DateTime(2025, 1, 6, 13, 55, 1, 382, DateTimeKind.Local).AddTicks(9181));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 5,
                column: "ActualDeliveryDate",
                value: new DateTime(2025, 1, 5, 13, 55, 1, 382, DateTimeKind.Local).AddTicks(9183));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2025, 1, 5, 13, 55, 1, 395, DateTimeKind.Local).AddTicks(2695));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2025, 1, 6, 13, 55, 1, 395, DateTimeKind.Local).AddTicks(2698));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2025, 1, 7, 13, 55, 1, 395, DateTimeKind.Local).AddTicks(2700));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 4,
                column: "Timestamp",
                value: new DateTime(2025, 1, 8, 13, 55, 1, 395, DateTimeKind.Local).AddTicks(2702));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 5,
                column: "Timestamp",
                value: new DateTime(2025, 1, 9, 13, 55, 1, 395, DateTimeKind.Local).AddTicks(2703));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1,
                column: "LicenseExpiryDate",
                value: new DateTime(2026, 1, 10, 13, 55, 1, 374, DateTimeKind.Local).AddTicks(5307));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 2,
                column: "LicenseExpiryDate",
                value: new DateTime(2026, 1, 10, 13, 55, 1, 374, DateTimeKind.Local).AddTicks(5310));

            migrationBuilder.UpdateData(
                table: "FuelPrices",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2025, 1, 7, 13, 55, 1, 407, DateTimeKind.Local).AddTicks(1479));

            migrationBuilder.UpdateData(
                table: "FuelPrices",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2025, 1, 8, 13, 55, 1, 407, DateTimeKind.Local).AddTicks(1481));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InvoiceDate", "PaidDate" },
                values: new object[] { new DateTime(2024, 12, 31, 13, 55, 1, 340, DateTimeKind.Local).AddTicks(9740), new DateTime(2025, 1, 5, 13, 55, 1, 340, DateTimeKind.Local).AddTicks(9738) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 2,
                column: "InvoiceDate",
                value: new DateTime(2025, 1, 3, 13, 55, 1, 340, DateTimeKind.Local).AddTicks(9743));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 3,
                column: "InvoiceDate",
                value: new DateTime(2025, 1, 4, 13, 55, 1, 340, DateTimeKind.Local).AddTicks(9745));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 1,
                column: "OfferDate",
                value: new DateTime(2024, 12, 26, 13, 55, 1, 346, DateTimeKind.Local).AddTicks(9028));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 2,
                column: "OfferDate",
                value: new DateTime(2024, 12, 25, 13, 55, 1, 346, DateTimeKind.Local).AddTicks(9030));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 3,
                column: "OfferDate",
                value: new DateTime(2024, 12, 26, 13, 55, 1, 346, DateTimeKind.Local).AddTicks(9031));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 4,
                column: "OfferDate",
                value: new DateTime(2024, 12, 29, 13, 55, 1, 346, DateTimeKind.Local).AddTicks(9033));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 5,
                column: "OfferDate",
                value: new DateTime(2024, 12, 28, 13, 55, 1, 346, DateTimeKind.Local).AddTicks(9035));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 12, 21, 13, 55, 1, 362, DateTimeKind.Local).AddTicks(1769), new DateTime(2025, 1, 17, 13, 55, 1, 362, DateTimeKind.Local).AddTicks(1766) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 12, 20, 13, 55, 1, 362, DateTimeKind.Local).AddTicks(1774), new DateTime(2025, 1, 20, 13, 55, 1, 362, DateTimeKind.Local).AddTicks(1772) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 12, 19, 13, 55, 1, 362, DateTimeKind.Local).AddTicks(1778), new DateTime(2025, 1, 15, 13, 55, 1, 362, DateTimeKind.Local).AddTicks(1777) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 12, 18, 13, 55, 1, 362, DateTimeKind.Local).AddTicks(1782), new DateTime(2025, 1, 7, 13, 55, 1, 362, DateTimeKind.Local).AddTicks(1781) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 12, 17, 13, 55, 1, 362, DateTimeKind.Local).AddTicks(1786), new DateTime(2025, 1, 5, 13, 55, 1, 362, DateTimeKind.Local).AddTicks(1784) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastYearMaintenance",
                value: new DateTime(2024, 10, 10, 13, 55, 1, 388, DateTimeKind.Local).AddTicks(8010));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastYearMaintenance",
                value: new DateTime(2024, 12, 10, 13, 55, 1, 388, DateTimeKind.Local).AddTicks(8013));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20ddc22c-ca6d-4feb-a688-0f31a430b5eb",
                column: "ConcurrencyStamp",
                value: "568225d5-25db-4635-91db-7157be4e4eee");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27609f35-fbc8-4dc4-9d12-7ff2dd400327",
                column: "ConcurrencyStamp",
                value: "ed65a756-3609-4ac7-9e5d-df2cdbb4bdcf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "350868c0-bf0f-4f70-b4c9-155351bc6429",
                column: "ConcurrencyStamp",
                value: "1bd7ba65-4157-4615-94cd-b9322bb7cad8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d000e64-c056-419a-950f-1992bd1e910d",
                column: "ConcurrencyStamp",
                value: "7bd37faf-668e-4e49-9c72-7dff27c7e44c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99027aaa-d346-4dd9-a467-15d74576c080",
                column: "ConcurrencyStamp",
                value: "193cd088-760b-430e-a41e-3cb36e51f35b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20450cff-816f-49c8-9546-1c603aec0301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "32f96c92-81e8-40e3-a67b-09a04e144a38", "AQAAAAEAACcQAAAAENNMpRxWbdvomPaIeyYWhjSZ3ODewDFnS/s76kK3CHHWUpr4z5bJ9gLT6Pw37uIS9w==", "169b3e57-e3b1-4858-89e9-d81ba8c6708c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e8be95a-186e-403b-b4aa-3874750a3563",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d8c33af7-c3d5-4d07-9d57-754e685f4209", "AQAAAAEAACcQAAAAEHQov+9g09S0jajWnIPWrPSnn49d7BgdKddZ9dyno2tJKy7sWCVbjrPos2v4ybnHPQ==", "a811e383-58b8-4e0f-a152-eef179c99579" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38ba6810-2800-4ac8-b005-5c27e8248951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "52b8fa4e-4d70-400c-8919-a9a1f2e765db", "AQAAAAEAACcQAAAAEKN786W0j8rGAaWPn7qfNk8hhZw7/HLq0oFySi3aqiLCKOz8SRjtF3upur9VitUkUw==", "1df0954d-a621-4a78-ba22-eb3a49c5617f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6bab54d5-5a88-4128-92d2-4d12ad0baa32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "17e7ae4e-e8dc-45dd-b457-a43a805bf5e8", "AQAAAAEAACcQAAAAED75mFhflSm4TQ3Y6Jwfbyc0HQN/9Z7N6ZpyOhSAZzcXyeRgCFBBzVsqm1nxfpPVPQ==", "d1623ed7-7f44-4d30-a006-e59facb71e8b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "driverUser1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d109071b-08da-465d-aa7f-efdfe42dd0a1", "AQAAAAEAACcQAAAAEHV0DKxBlHQwVPp/LMWGEN1vsmdjuPcDZG6cNlxd5oVu5R6UMbCQ0cKihB9TVKOQ2g==", "05b02dc8-f2ca-41e0-94eb-c3daf430b859" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "driverUser2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "919644f3-ad01-4ddc-8c3b-17cd2148cd1b", "AQAAAAEAACcQAAAAEKfaHoEZXtLKDRgpf2y4OIQm6HLolCKJw8qZTR2N4ii9WcdBBZPCqtBzYzCE/HFpmw==", "5613d9be-9efd-46f9-a45b-be6451480ea0" });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 12, 10, 13, 52, 45, 813, DateTimeKind.Local).AddTicks(9739));

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 10, 10, 13, 52, 45, 813, DateTimeKind.Local).AddTicks(9741));

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 7, 10, 13, 52, 45, 813, DateTimeKind.Local).AddTicks(9743));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateSubmitted",
                value: new DateTime(2025, 1, 5, 13, 52, 45, 729, DateTimeKind.Local).AddTicks(1721));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateSubmitted",
                value: new DateTime(2025, 1, 6, 13, 52, 45, 729, DateTimeKind.Local).AddTicks(1724));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateSubmitted",
                value: new DateTime(2025, 1, 7, 13, 52, 45, 729, DateTimeKind.Local).AddTicks(1725));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateSubmitted",
                value: new DateTime(2025, 1, 8, 13, 52, 45, 729, DateTimeKind.Local).AddTicks(1727));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateSubmitted",
                value: new DateTime(2025, 1, 9, 13, 52, 45, 729, DateTimeKind.Local).AddTicks(1729));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateSubmitted",
                value: new DateTime(2025, 1, 10, 13, 52, 45, 729, DateTimeKind.Local).AddTicks(1730));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 12, 21, 13, 52, 45, 735, DateTimeKind.Local).AddTicks(4015));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 12, 31, 13, 52, 45, 735, DateTimeKind.Local).AddTicks(4056));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 1,
                column: "ActualDeliveryDate",
                value: new DateTime(2025, 1, 9, 13, 52, 45, 784, DateTimeKind.Local).AddTicks(618));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 2,
                column: "ActualDeliveryDate",
                value: new DateTime(2025, 1, 8, 13, 52, 45, 784, DateTimeKind.Local).AddTicks(622));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 3,
                column: "ActualDeliveryDate",
                value: new DateTime(2025, 1, 7, 13, 52, 45, 784, DateTimeKind.Local).AddTicks(627));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 4,
                column: "ActualDeliveryDate",
                value: new DateTime(2025, 1, 6, 13, 52, 45, 784, DateTimeKind.Local).AddTicks(630));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 5,
                column: "ActualDeliveryDate",
                value: new DateTime(2025, 1, 5, 13, 52, 45, 784, DateTimeKind.Local).AddTicks(632));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2025, 1, 5, 13, 52, 45, 795, DateTimeKind.Local).AddTicks(8193));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2025, 1, 6, 13, 52, 45, 795, DateTimeKind.Local).AddTicks(8196));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2025, 1, 7, 13, 52, 45, 795, DateTimeKind.Local).AddTicks(8199));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 4,
                column: "Timestamp",
                value: new DateTime(2025, 1, 8, 13, 52, 45, 795, DateTimeKind.Local).AddTicks(8201));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 5,
                column: "Timestamp",
                value: new DateTime(2025, 1, 9, 13, 52, 45, 795, DateTimeKind.Local).AddTicks(8202));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1,
                column: "LicenseExpiryDate",
                value: new DateTime(2026, 1, 10, 13, 52, 45, 775, DateTimeKind.Local).AddTicks(3986));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 2,
                column: "LicenseExpiryDate",
                value: new DateTime(2026, 1, 10, 13, 52, 45, 775, DateTimeKind.Local).AddTicks(3992));

            migrationBuilder.UpdateData(
                table: "FuelPrices",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2025, 1, 7, 13, 52, 45, 807, DateTimeKind.Local).AddTicks(9332));

            migrationBuilder.UpdateData(
                table: "FuelPrices",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2025, 1, 8, 13, 52, 45, 807, DateTimeKind.Local).AddTicks(9335));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InvoiceDate", "PaidDate" },
                values: new object[] { new DateTime(2024, 12, 31, 13, 52, 45, 741, DateTimeKind.Local).AddTicks(5286), new DateTime(2025, 1, 5, 13, 52, 45, 741, DateTimeKind.Local).AddTicks(5282) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 2,
                column: "InvoiceDate",
                value: new DateTime(2025, 1, 3, 13, 52, 45, 741, DateTimeKind.Local).AddTicks(5289));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 3,
                column: "InvoiceDate",
                value: new DateTime(2025, 1, 4, 13, 52, 45, 741, DateTimeKind.Local).AddTicks(5291));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 1,
                column: "OfferDate",
                value: new DateTime(2024, 12, 26, 13, 52, 45, 747, DateTimeKind.Local).AddTicks(5921));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 2,
                column: "OfferDate",
                value: new DateTime(2024, 12, 25, 13, 52, 45, 747, DateTimeKind.Local).AddTicks(5922));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 3,
                column: "OfferDate",
                value: new DateTime(2024, 12, 26, 13, 52, 45, 747, DateTimeKind.Local).AddTicks(5924));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 4,
                column: "OfferDate",
                value: new DateTime(2024, 12, 29, 13, 52, 45, 747, DateTimeKind.Local).AddTicks(5928));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 5,
                column: "OfferDate",
                value: new DateTime(2024, 12, 28, 13, 52, 45, 747, DateTimeKind.Local).AddTicks(5930));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 12, 21, 13, 52, 45, 763, DateTimeKind.Local).AddTicks(2660), new DateTime(2025, 1, 17, 13, 52, 45, 763, DateTimeKind.Local).AddTicks(2657) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 12, 20, 13, 52, 45, 763, DateTimeKind.Local).AddTicks(2667), new DateTime(2025, 1, 20, 13, 52, 45, 763, DateTimeKind.Local).AddTicks(2665) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 12, 19, 13, 52, 45, 763, DateTimeKind.Local).AddTicks(2671), new DateTime(2025, 1, 15, 13, 52, 45, 763, DateTimeKind.Local).AddTicks(2670) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 12, 18, 13, 52, 45, 763, DateTimeKind.Local).AddTicks(2676), new DateTime(2025, 1, 7, 13, 52, 45, 763, DateTimeKind.Local).AddTicks(2675) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 12, 17, 13, 52, 45, 763, DateTimeKind.Local).AddTicks(2679), new DateTime(2025, 1, 5, 13, 52, 45, 763, DateTimeKind.Local).AddTicks(2678) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastYearMaintenance",
                value: new DateTime(2024, 10, 10, 13, 52, 45, 789, DateTimeKind.Local).AddTicks(9375));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastYearMaintenance",
                value: new DateTime(2024, 12, 10, 13, 52, 45, 789, DateTimeKind.Local).AddTicks(9378));
        }
    }
}

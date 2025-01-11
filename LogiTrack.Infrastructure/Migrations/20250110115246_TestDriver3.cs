using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogiTrack.Infrastructure.Migrations
{
    public partial class TestDriver3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20ddc22c-ca6d-4feb-a688-0f31a430b5eb",
                column: "ConcurrencyStamp",
                value: "2a8ab609-4020-4c04-90d9-2861b9486990");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27609f35-fbc8-4dc4-9d12-7ff2dd400327",
                column: "ConcurrencyStamp",
                value: "e32ca711-412c-4ddc-9e2b-cace434d0975");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "350868c0-bf0f-4f70-b4c9-155351bc6429",
                column: "ConcurrencyStamp",
                value: "4df1fd9e-2eda-41d3-8e06-df662c812e5c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d000e64-c056-419a-950f-1992bd1e910d",
                column: "ConcurrencyStamp",
                value: "6ad1b9ef-6d11-48c5-b162-88ee88010342");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99027aaa-d346-4dd9-a467-15d74576c080",
                column: "ConcurrencyStamp",
                value: "e1a2baeb-a621-4d2e-878b-c91d8c11830e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20450cff-816f-49c8-9546-1c603aec0301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3cf2edd2-31a4-4c6f-9bf3-be8b0cd1dd81", "AQAAAAEAACcQAAAAELNGAPAiK/kH1Z0LrUDDQtK3+B0c5Nreg85dSPnphY1OEzJV5vzvj3TCncab6bdHSQ==", "b46c4228-f416-4681-b2fe-795bc1f24e3a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e8be95a-186e-403b-b4aa-3874750a3563",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d55a96fd-eda1-4db1-9ff8-da8ed91ff11b", "AQAAAAEAACcQAAAAELewwla326b1aaOtkS0yj8zlRrgxmNvubjb7/DxL46XfUuZQ4l5aI6bUseNGprsiKw==", "3659003e-ad24-48ea-aebe-a7a7fda5d0a0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38ba6810-2800-4ac8-b005-5c27e8248951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "41fb34dc-2b5c-42da-a222-a0bf25465fbe", "AQAAAAEAACcQAAAAEBvM+OFkYZCZlsSRZmsP6Cksyue+GvIwGpakb8SJkHKRJZMOmb3ASdbOVxV9JLYiWA==", "5e04863d-658b-4e19-96a2-b8f2bbee0a72" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6bab54d5-5a88-4128-92d2-4d12ad0baa32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a1b02525-53ad-4545-978d-186852cc5e8b", "AQAAAAEAACcQAAAAEFlkwXOQilKXtoyFWKUP9pbCKknkxOaciUCyh8E4Ejwlu9qE1djIhbfcUIFPKkMnLA==", "8422e8fe-8ca1-4c04-8b33-fd0abb6c47e1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "driverUser1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b758973f-b74b-4afd-b7ac-bf48a441eb65", "AQAAAAEAACcQAAAAEM1W30ZUhYebyVoQioWqHS88wFxOSwXnFishcBY/D19lZzGadaWJqq5te8U3TfiRZQ==", "28296104-e2b7-4ca2-9ce3-1b8ce3c10b5a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "driverUser2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "03833fa6-6e6d-452a-ac3d-9f7bd84b4901", null, "349a859a-12fb-4ae6-95da-8c0122052382" });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 12, 10, 13, 43, 26, 580, DateTimeKind.Local).AddTicks(7067));

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 10, 10, 13, 43, 26, 580, DateTimeKind.Local).AddTicks(7070));

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 7, 10, 13, 43, 26, 580, DateTimeKind.Local).AddTicks(7072));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateSubmitted",
                value: new DateTime(2025, 1, 5, 13, 43, 26, 497, DateTimeKind.Local).AddTicks(189));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateSubmitted",
                value: new DateTime(2025, 1, 6, 13, 43, 26, 497, DateTimeKind.Local).AddTicks(191));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateSubmitted",
                value: new DateTime(2025, 1, 7, 13, 43, 26, 497, DateTimeKind.Local).AddTicks(193));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateSubmitted",
                value: new DateTime(2025, 1, 8, 13, 43, 26, 497, DateTimeKind.Local).AddTicks(195));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateSubmitted",
                value: new DateTime(2025, 1, 9, 13, 43, 26, 497, DateTimeKind.Local).AddTicks(199));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateSubmitted",
                value: new DateTime(2025, 1, 10, 13, 43, 26, 497, DateTimeKind.Local).AddTicks(201));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 12, 21, 13, 43, 26, 503, DateTimeKind.Local).AddTicks(4830));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 12, 31, 13, 43, 26, 503, DateTimeKind.Local).AddTicks(4844));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 1,
                column: "ActualDeliveryDate",
                value: new DateTime(2025, 1, 9, 13, 43, 26, 550, DateTimeKind.Local).AddTicks(6653));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 2,
                column: "ActualDeliveryDate",
                value: new DateTime(2025, 1, 8, 13, 43, 26, 550, DateTimeKind.Local).AddTicks(6656));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 3,
                column: "ActualDeliveryDate",
                value: new DateTime(2025, 1, 7, 13, 43, 26, 550, DateTimeKind.Local).AddTicks(6658));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 4,
                column: "ActualDeliveryDate",
                value: new DateTime(2025, 1, 6, 13, 43, 26, 550, DateTimeKind.Local).AddTicks(6661));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 5,
                column: "ActualDeliveryDate",
                value: new DateTime(2025, 1, 5, 13, 43, 26, 550, DateTimeKind.Local).AddTicks(6663));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2025, 1, 5, 13, 43, 26, 563, DateTimeKind.Local).AddTicks(629));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2025, 1, 6, 13, 43, 26, 563, DateTimeKind.Local).AddTicks(632));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2025, 1, 7, 13, 43, 26, 563, DateTimeKind.Local).AddTicks(634));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 4,
                column: "Timestamp",
                value: new DateTime(2025, 1, 8, 13, 43, 26, 563, DateTimeKind.Local).AddTicks(635));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 5,
                column: "Timestamp",
                value: new DateTime(2025, 1, 9, 13, 43, 26, 563, DateTimeKind.Local).AddTicks(637));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1,
                column: "LicenseExpiryDate",
                value: new DateTime(2026, 1, 10, 13, 43, 26, 542, DateTimeKind.Local).AddTicks(2416));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 2,
                column: "LicenseExpiryDate",
                value: new DateTime(2026, 1, 10, 13, 43, 26, 542, DateTimeKind.Local).AddTicks(2420));

            migrationBuilder.UpdateData(
                table: "FuelPrices",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2025, 1, 7, 13, 43, 26, 574, DateTimeKind.Local).AddTicks(7474));

            migrationBuilder.UpdateData(
                table: "FuelPrices",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2025, 1, 8, 13, 43, 26, 574, DateTimeKind.Local).AddTicks(7476));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InvoiceDate", "PaidDate" },
                values: new object[] { new DateTime(2024, 12, 31, 13, 43, 26, 509, DateTimeKind.Local).AddTicks(5580), new DateTime(2025, 1, 5, 13, 43, 26, 509, DateTimeKind.Local).AddTicks(5579) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 2,
                column: "InvoiceDate",
                value: new DateTime(2025, 1, 3, 13, 43, 26, 509, DateTimeKind.Local).AddTicks(5583));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 3,
                column: "InvoiceDate",
                value: new DateTime(2025, 1, 4, 13, 43, 26, 509, DateTimeKind.Local).AddTicks(5585));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 1,
                column: "OfferDate",
                value: new DateTime(2024, 12, 26, 13, 43, 26, 515, DateTimeKind.Local).AddTicks(7988));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 2,
                column: "OfferDate",
                value: new DateTime(2024, 12, 25, 13, 43, 26, 515, DateTimeKind.Local).AddTicks(7989));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 3,
                column: "OfferDate",
                value: new DateTime(2024, 12, 26, 13, 43, 26, 515, DateTimeKind.Local).AddTicks(7991));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 4,
                column: "OfferDate",
                value: new DateTime(2024, 12, 29, 13, 43, 26, 515, DateTimeKind.Local).AddTicks(7992));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 5,
                column: "OfferDate",
                value: new DateTime(2024, 12, 28, 13, 43, 26, 515, DateTimeKind.Local).AddTicks(7994));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 12, 21, 13, 43, 26, 530, DateTimeKind.Local).AddTicks(2589), new DateTime(2025, 1, 17, 13, 43, 26, 530, DateTimeKind.Local).AddTicks(2586) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 12, 20, 13, 43, 26, 530, DateTimeKind.Local).AddTicks(2598), new DateTime(2025, 1, 20, 13, 43, 26, 530, DateTimeKind.Local).AddTicks(2596) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 12, 19, 13, 43, 26, 530, DateTimeKind.Local).AddTicks(2603), new DateTime(2025, 1, 15, 13, 43, 26, 530, DateTimeKind.Local).AddTicks(2602) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 12, 18, 13, 43, 26, 530, DateTimeKind.Local).AddTicks(2607), new DateTime(2025, 1, 7, 13, 43, 26, 530, DateTimeKind.Local).AddTicks(2606) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 12, 17, 13, 43, 26, 530, DateTimeKind.Local).AddTicks(2613), new DateTime(2025, 1, 5, 13, 43, 26, 530, DateTimeKind.Local).AddTicks(2612) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastYearMaintenance",
                value: new DateTime(2024, 10, 10, 13, 43, 26, 556, DateTimeKind.Local).AddTicks(5526));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastYearMaintenance",
                value: new DateTime(2024, 12, 10, 13, 43, 26, 556, DateTimeKind.Local).AddTicks(5529));
        }
    }
}

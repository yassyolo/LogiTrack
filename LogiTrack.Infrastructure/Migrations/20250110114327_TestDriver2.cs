using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogiTrack.Infrastructure.Migrations
{
    public partial class TestDriver2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "b758973f-b74b-4afd-b7ac-bf48a441eb65", null, null, "AQAAAAEAACcQAAAAEM1W30ZUhYebyVoQioWqHS88wFxOSwXnFishcBY/D19lZzGadaWJqq5te8U3TfiRZQ==", "28296104-e2b7-4ca2-9ce3-1b8ce3c10b5a", "driver" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "driverUser2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "03833fa6-6e6d-452a-ac3d-9f7bd84b4901", "349a859a-12fb-4ae6-95da-8c0122052382" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20ddc22c-ca6d-4feb-a688-0f31a430b5eb",
                column: "ConcurrencyStamp",
                value: "6deb877e-aa34-4400-9ba4-64ce43107fe8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27609f35-fbc8-4dc4-9d12-7ff2dd400327",
                column: "ConcurrencyStamp",
                value: "4eca1dc3-7761-4c4c-baca-94e5f8a99521");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "350868c0-bf0f-4f70-b4c9-155351bc6429",
                column: "ConcurrencyStamp",
                value: "fc7f253c-990c-4a59-bc2a-bab47c872356");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d000e64-c056-419a-950f-1992bd1e910d",
                column: "ConcurrencyStamp",
                value: "c5915d3a-c446-4763-97c3-95a61b04897e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99027aaa-d346-4dd9-a467-15d74576c080",
                column: "ConcurrencyStamp",
                value: "441da9c0-37e8-4b0c-8be1-8bbfd5000255");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20450cff-816f-49c8-9546-1c603aec0301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b1687734-8d25-4afb-8f21-83376d765c15", "AQAAAAEAACcQAAAAEERX3CshPWKJNOcG9OlgpOowz2qNFtMEX2isjgv4CGZhRJ3h8I2HED6vkHpZVWz/5g==", "5262ec88-4445-44f1-9378-66a979792f0f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e8be95a-186e-403b-b4aa-3874750a3563",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4bf2ce1a-dbf3-4197-b27f-de6548af95b0", "AQAAAAEAACcQAAAAEJUKXUQGs/52I0CJMGW2kunvldY4iAMsEfGgpCc2SRduzjaAnf4lLzItXHXsfv9tIw==", "dba75992-5d02-496e-9362-41ab4bfb5825" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38ba6810-2800-4ac8-b005-5c27e8248951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "06175f33-f6f2-485f-a351-19e6c12fe200", "AQAAAAEAACcQAAAAEHsPVEfCBk5L56ALfOPjsgW57EoKo9k/KWSF5RKk+2hGztcv1wxvrXbLZTR4saqaXQ==", "17d94b5f-9779-4367-a80a-fca27b936091" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6bab54d5-5a88-4128-92d2-4d12ad0baa32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "43ac5dc8-962b-494f-a594-f0e602277f69", "AQAAAAEAACcQAAAAEHAndRJnNPaYSpHMusomfh8CqN7uYYjr87805xVw2R5WnW7GArE0LOxpBBT+KjyU5g==", "28a8e6ed-8dbe-4544-b190-dac77e24e8ba" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "driverUser1",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "6139e0bb-0dc3-41a9-a214-f053f4eeb591", "DRIVER1@EXAMPLE.COM", "DRIVER1", "AQAAAAEAACcQAAAAEHFHWzx5WmoN/msYzpzTuQXuZtxd+rSjd3c02au9dKM3MHjveeM7aG8mmqs4hqBrJg==", "3055aa69-75cd-472d-8331-1596818f5dce", "driver1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "driverUser2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "916f7cb4-c7f3-4984-a4dd-67e7f4bb5ba7", "fb94f484-69f4-4838-b5d0-83abdfa80a62" });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 12, 10, 13, 36, 4, 320, DateTimeKind.Local).AddTicks(2479));

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 10, 10, 13, 36, 4, 320, DateTimeKind.Local).AddTicks(2481));

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 7, 10, 13, 36, 4, 320, DateTimeKind.Local).AddTicks(2483));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateSubmitted",
                value: new DateTime(2025, 1, 5, 13, 36, 4, 237, DateTimeKind.Local).AddTicks(7177));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateSubmitted",
                value: new DateTime(2025, 1, 6, 13, 36, 4, 237, DateTimeKind.Local).AddTicks(7180));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateSubmitted",
                value: new DateTime(2025, 1, 7, 13, 36, 4, 237, DateTimeKind.Local).AddTicks(7181));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateSubmitted",
                value: new DateTime(2025, 1, 8, 13, 36, 4, 237, DateTimeKind.Local).AddTicks(7183));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateSubmitted",
                value: new DateTime(2025, 1, 9, 13, 36, 4, 237, DateTimeKind.Local).AddTicks(7185));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateSubmitted",
                value: new DateTime(2025, 1, 10, 13, 36, 4, 237, DateTimeKind.Local).AddTicks(7187));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 12, 21, 13, 36, 4, 244, DateTimeKind.Local).AddTicks(784));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 12, 31, 13, 36, 4, 244, DateTimeKind.Local).AddTicks(817));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 1,
                column: "ActualDeliveryDate",
                value: new DateTime(2025, 1, 9, 13, 36, 4, 290, DateTimeKind.Local).AddTicks(5688));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 2,
                column: "ActualDeliveryDate",
                value: new DateTime(2025, 1, 8, 13, 36, 4, 290, DateTimeKind.Local).AddTicks(5691));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 3,
                column: "ActualDeliveryDate",
                value: new DateTime(2025, 1, 7, 13, 36, 4, 290, DateTimeKind.Local).AddTicks(5693));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 4,
                column: "ActualDeliveryDate",
                value: new DateTime(2025, 1, 6, 13, 36, 4, 290, DateTimeKind.Local).AddTicks(5696));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 5,
                column: "ActualDeliveryDate",
                value: new DateTime(2025, 1, 5, 13, 36, 4, 290, DateTimeKind.Local).AddTicks(5699));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2025, 1, 5, 13, 36, 4, 302, DateTimeKind.Local).AddTicks(4525));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2025, 1, 6, 13, 36, 4, 302, DateTimeKind.Local).AddTicks(4528));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2025, 1, 7, 13, 36, 4, 302, DateTimeKind.Local).AddTicks(4530));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 4,
                column: "Timestamp",
                value: new DateTime(2025, 1, 8, 13, 36, 4, 302, DateTimeKind.Local).AddTicks(4532));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 5,
                column: "Timestamp",
                value: new DateTime(2025, 1, 9, 13, 36, 4, 302, DateTimeKind.Local).AddTicks(4534));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1,
                column: "LicenseExpiryDate",
                value: new DateTime(2026, 1, 10, 13, 36, 4, 282, DateTimeKind.Local).AddTicks(8229));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 2,
                column: "LicenseExpiryDate",
                value: new DateTime(2026, 1, 10, 13, 36, 4, 282, DateTimeKind.Local).AddTicks(8233));

            migrationBuilder.UpdateData(
                table: "FuelPrices",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2025, 1, 7, 13, 36, 4, 314, DateTimeKind.Local).AddTicks(3675));

            migrationBuilder.UpdateData(
                table: "FuelPrices",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2025, 1, 8, 13, 36, 4, 314, DateTimeKind.Local).AddTicks(3676));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InvoiceDate", "PaidDate" },
                values: new object[] { new DateTime(2024, 12, 31, 13, 36, 4, 250, DateTimeKind.Local).AddTicks(330), new DateTime(2025, 1, 5, 13, 36, 4, 250, DateTimeKind.Local).AddTicks(328) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 2,
                column: "InvoiceDate",
                value: new DateTime(2025, 1, 3, 13, 36, 4, 250, DateTimeKind.Local).AddTicks(333));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 3,
                column: "InvoiceDate",
                value: new DateTime(2025, 1, 4, 13, 36, 4, 250, DateTimeKind.Local).AddTicks(335));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 1,
                column: "OfferDate",
                value: new DateTime(2024, 12, 26, 13, 36, 4, 256, DateTimeKind.Local).AddTicks(4472));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 2,
                column: "OfferDate",
                value: new DateTime(2024, 12, 25, 13, 36, 4, 256, DateTimeKind.Local).AddTicks(4475));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 3,
                column: "OfferDate",
                value: new DateTime(2024, 12, 26, 13, 36, 4, 256, DateTimeKind.Local).AddTicks(4477));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 4,
                column: "OfferDate",
                value: new DateTime(2024, 12, 29, 13, 36, 4, 256, DateTimeKind.Local).AddTicks(4479));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 5,
                column: "OfferDate",
                value: new DateTime(2024, 12, 28, 13, 36, 4, 256, DateTimeKind.Local).AddTicks(4481));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 12, 21, 13, 36, 4, 271, DateTimeKind.Local).AddTicks(150), new DateTime(2025, 1, 17, 13, 36, 4, 271, DateTimeKind.Local).AddTicks(145) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 12, 20, 13, 36, 4, 271, DateTimeKind.Local).AddTicks(158), new DateTime(2025, 1, 20, 13, 36, 4, 271, DateTimeKind.Local).AddTicks(156) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 12, 19, 13, 36, 4, 271, DateTimeKind.Local).AddTicks(162), new DateTime(2025, 1, 15, 13, 36, 4, 271, DateTimeKind.Local).AddTicks(161) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 12, 18, 13, 36, 4, 271, DateTimeKind.Local).AddTicks(167), new DateTime(2025, 1, 7, 13, 36, 4, 271, DateTimeKind.Local).AddTicks(166) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 12, 17, 13, 36, 4, 271, DateTimeKind.Local).AddTicks(172), new DateTime(2025, 1, 5, 13, 36, 4, 271, DateTimeKind.Local).AddTicks(170) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastYearMaintenance",
                value: new DateTime(2024, 10, 10, 13, 36, 4, 296, DateTimeKind.Local).AddTicks(4027));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastYearMaintenance",
                value: new DateTime(2024, 12, 10, 13, 36, 4, 296, DateTimeKind.Local).AddTicks(4031));
        }
    }
}

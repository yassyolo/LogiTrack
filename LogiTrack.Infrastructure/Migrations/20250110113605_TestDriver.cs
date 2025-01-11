using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogiTrack.Infrastructure.Migrations
{
    public partial class TestDriver : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "6139e0bb-0dc3-41a9-a214-f053f4eeb591", "DRIVER1", "AQAAAAEAACcQAAAAEHFHWzx5WmoN/msYzpzTuQXuZtxd+rSjd3c02au9dKM3MHjveeM7aG8mmqs4hqBrJg==", "3055aa69-75cd-472d-8331-1596818f5dce", "driver1" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20ddc22c-ca6d-4feb-a688-0f31a430b5eb",
                column: "ConcurrencyStamp",
                value: "f0aca81a-4699-4ae4-a2ae-cf8de0b7cae8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27609f35-fbc8-4dc4-9d12-7ff2dd400327",
                column: "ConcurrencyStamp",
                value: "f87dcc9b-8303-4f5c-bd99-9cf1b825f6f9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "350868c0-bf0f-4f70-b4c9-155351bc6429",
                column: "ConcurrencyStamp",
                value: "0b398f10-cb00-41cb-92e3-7a5e1a5a4f70");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d000e64-c056-419a-950f-1992bd1e910d",
                column: "ConcurrencyStamp",
                value: "99b81efe-b16f-43c1-a6aa-037b92dec465");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99027aaa-d346-4dd9-a467-15d74576c080",
                column: "ConcurrencyStamp",
                value: "7d51c5be-e406-4263-8702-5fa0fb453a12");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20450cff-816f-49c8-9546-1c603aec0301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a230e7bd-32e1-4993-b664-8c150bc17b3b", "AQAAAAEAACcQAAAAEJt6kNEEKESvVkfy44T2kiCB+Z9embaWhnsMkE5luJD1ZVOtHPsLwbCyGkWSMUtoOA==", "5e805166-b4aa-450f-9102-a1f45037ce0c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e8be95a-186e-403b-b4aa-3874750a3563",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6876ebaf-d135-46ca-a408-568469926c5f", "AQAAAAEAACcQAAAAENO8Qct1jDq3ZR4yUZTMxZHsoHNGIxxiYP+u7FudUmonPYg/uQM9M+EB+2EiyV33Fg==", "93d905de-25e6-4606-b3a2-4c8bc298bcae" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38ba6810-2800-4ac8-b005-5c27e8248951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9e0f5253-caf5-4960-a422-338eca0ede65", "AQAAAAEAACcQAAAAEAKfzsyS7RdJ8jCxb5jYSPzdfW0EhMz26b6FliILsLS0lZEcLJFJ01Hhq+tBaQRaMA==", "79c5a8b3-35c8-4a31-bfbf-dcceb1addb40" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6bab54d5-5a88-4128-92d2-4d12ad0baa32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e15711b2-64f7-4a97-ad5c-1c7afef66fc2", "AQAAAAEAACcQAAAAEFul3r2Oy/JMNmO3dRBcP9v8SzHvTIPkXtMPR13P8wqSYYAdA6LRIje1V33Mc8Ojpw==", "13ba36f4-9ff7-47e3-a906-7912e7437625" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "driverUser1",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "5344217a-c12a-449f-914f-f1f21316dfef", "DRIVER1@EXAMPLE.COM", "AQAAAAEAACcQAAAAEKMBBnf+CRtJjhVndcTAn5kXYDqnNg+LDVjkIsNH7vQnYCTCFqjm3TMfB2E0E3KiNw==", "24660675-b293-437f-affd-bcb90ede95cc", "driver1@example.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "driverUser2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6e1fe3f9-2916-4146-a072-c5953eacddfe", "00079f60-8a63-4356-a208-44d7c2a78d1c" });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 11, 9, 20, 11, 29, 392, DateTimeKind.Local).AddTicks(7207));

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 9, 9, 20, 11, 29, 392, DateTimeKind.Local).AddTicks(7210));

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 6, 9, 20, 11, 29, 392, DateTimeKind.Local).AddTicks(7213));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateSubmitted",
                value: new DateTime(2024, 12, 4, 20, 11, 29, 276, DateTimeKind.Local).AddTicks(4677));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateSubmitted",
                value: new DateTime(2024, 12, 5, 20, 11, 29, 276, DateTimeKind.Local).AddTicks(4679));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateSubmitted",
                value: new DateTime(2024, 12, 6, 20, 11, 29, 276, DateTimeKind.Local).AddTicks(4681));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateSubmitted",
                value: new DateTime(2024, 12, 7, 20, 11, 29, 276, DateTimeKind.Local).AddTicks(4683));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateSubmitted",
                value: new DateTime(2024, 12, 8, 20, 11, 29, 276, DateTimeKind.Local).AddTicks(4685));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateSubmitted",
                value: new DateTime(2024, 12, 9, 20, 11, 29, 276, DateTimeKind.Local).AddTicks(4687));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 19, 20, 11, 29, 284, DateTimeKind.Local).AddTicks(4431));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 29, 20, 11, 29, 284, DateTimeKind.Local).AddTicks(4476));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 1,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 12, 8, 20, 11, 29, 350, DateTimeKind.Local).AddTicks(2636));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 2,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 12, 7, 20, 11, 29, 350, DateTimeKind.Local).AddTicks(2641));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 3,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 12, 6, 20, 11, 29, 350, DateTimeKind.Local).AddTicks(2745));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 4,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 12, 5, 20, 11, 29, 350, DateTimeKind.Local).AddTicks(2750));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 5,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 12, 4, 20, 11, 29, 350, DateTimeKind.Local).AddTicks(2753));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2024, 12, 4, 20, 11, 29, 367, DateTimeKind.Local).AddTicks(3377));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2024, 12, 5, 20, 11, 29, 367, DateTimeKind.Local).AddTicks(3381));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2024, 12, 6, 20, 11, 29, 367, DateTimeKind.Local).AddTicks(3384));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 4,
                column: "Timestamp",
                value: new DateTime(2024, 12, 7, 20, 11, 29, 367, DateTimeKind.Local).AddTicks(3387));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 5,
                column: "Timestamp",
                value: new DateTime(2024, 12, 8, 20, 11, 29, 367, DateTimeKind.Local).AddTicks(3391));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1,
                column: "LicenseExpiryDate",
                value: new DateTime(2025, 12, 9, 20, 11, 29, 339, DateTimeKind.Local).AddTicks(9368));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 2,
                column: "LicenseExpiryDate",
                value: new DateTime(2025, 12, 9, 20, 11, 29, 339, DateTimeKind.Local).AddTicks(9373));

            migrationBuilder.UpdateData(
                table: "FuelPrices",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 12, 6, 20, 11, 29, 383, DateTimeKind.Local).AddTicks(9429));

            migrationBuilder.UpdateData(
                table: "FuelPrices",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 12, 7, 20, 11, 29, 383, DateTimeKind.Local).AddTicks(9432));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InvoiceDate", "PaidDate" },
                values: new object[] { new DateTime(2024, 11, 29, 20, 11, 29, 293, DateTimeKind.Local).AddTicks(2083), new DateTime(2024, 12, 4, 20, 11, 29, 293, DateTimeKind.Local).AddTicks(2078) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 2,
                column: "InvoiceDate",
                value: new DateTime(2024, 12, 2, 20, 11, 29, 293, DateTimeKind.Local).AddTicks(2088));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 3,
                column: "InvoiceDate",
                value: new DateTime(2024, 12, 3, 20, 11, 29, 293, DateTimeKind.Local).AddTicks(2091));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 1,
                column: "OfferDate",
                value: new DateTime(2024, 11, 24, 20, 11, 29, 301, DateTimeKind.Local).AddTicks(7198));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 2,
                column: "OfferDate",
                value: new DateTime(2024, 11, 23, 20, 11, 29, 301, DateTimeKind.Local).AddTicks(7204));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 3,
                column: "OfferDate",
                value: new DateTime(2024, 11, 24, 20, 11, 29, 301, DateTimeKind.Local).AddTicks(7450));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 4,
                column: "OfferDate",
                value: new DateTime(2024, 11, 27, 20, 11, 29, 301, DateTimeKind.Local).AddTicks(7454));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 5,
                column: "OfferDate",
                value: new DateTime(2024, 11, 26, 20, 11, 29, 301, DateTimeKind.Local).AddTicks(7457));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 19, 20, 11, 29, 322, DateTimeKind.Local).AddTicks(4834), new DateTime(2024, 12, 16, 20, 11, 29, 322, DateTimeKind.Local).AddTicks(4830) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 18, 20, 11, 29, 322, DateTimeKind.Local).AddTicks(4844), new DateTime(2024, 12, 19, 20, 11, 29, 322, DateTimeKind.Local).AddTicks(4842) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 17, 20, 11, 29, 322, DateTimeKind.Local).AddTicks(4851), new DateTime(2024, 12, 14, 20, 11, 29, 322, DateTimeKind.Local).AddTicks(4848) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 16, 20, 11, 29, 322, DateTimeKind.Local).AddTicks(4857), new DateTime(2024, 12, 6, 20, 11, 29, 322, DateTimeKind.Local).AddTicks(4855) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 15, 20, 11, 29, 322, DateTimeKind.Local).AddTicks(4863), new DateTime(2024, 12, 4, 20, 11, 29, 322, DateTimeKind.Local).AddTicks(4861) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastYearMaintenance",
                value: new DateTime(2024, 9, 9, 20, 11, 29, 358, DateTimeKind.Local).AddTicks(9393));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastYearMaintenance",
                value: new DateTime(2024, 11, 9, 20, 11, 29, 358, DateTimeKind.Local).AddTicks(9399));
        }
    }
}

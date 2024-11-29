using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogiTrack.Infrastructure.Migrations
{
    public partial class StartDateForDelivery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Offers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20ddc22c-ca6d-4feb-a688-0f31a430b5eb",
                column: "ConcurrencyStamp",
                value: "3f7c3fff-7a1c-4e28-b8b6-42af30e84f41");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27609f35-fbc8-4dc4-9d12-7ff2dd400327",
                column: "ConcurrencyStamp",
                value: "85846c49-80a9-46d0-a444-a83ca8d90fe3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "350868c0-bf0f-4f70-b4c9-155351bc6429",
                column: "ConcurrencyStamp",
                value: "4282f918-1559-413b-884a-cc6fad88a646");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d000e64-c056-419a-950f-1992bd1e910d",
                column: "ConcurrencyStamp",
                value: "6020163e-6b78-49d6-9b9e-b597232928b0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99027aaa-d346-4dd9-a467-15d74576c080",
                column: "ConcurrencyStamp",
                value: "138cf7e3-f221-4f90-97d8-e04a4acf675b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20450cff-816f-49c8-9546-1c603aec0301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ec497b82-c718-4ac2-8006-4dbe2c15ce49", "AQAAAAEAACcQAAAAEAjFs6rW1i4+OWZ3VDYr5PBRX1obv1PiKNnTA5TEWhV6tKGdRU53L7pTrt0SNCbO3A==", "ed864276-3459-47c9-ba5e-2ec075bd30b5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e8be95a-186e-403b-b4aa-3874750a3563",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8d81235f-17bd-4ac1-8d02-83e21042debc", "AQAAAAEAACcQAAAAEG7SJjFMWKmdqPWurOZRqb1MQdwWhYUs0X9ZZ1G1H0mfpKppnlBlYaecepF/sD1X2A==", "e38316ca-660f-4036-b786-6c12ae34983e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38ba6810-2800-4ac8-b005-5c27e8248951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4e420048-a96c-4818-aabe-9ed379196b11", "AQAAAAEAACcQAAAAELs+sMCRFaxqd3IQbwLUgzRvQDfPWuSlhqYcMaEVGT++5irw/usQuwd19fAC2cOMLg==", "8f0eb1db-7d70-4fba-967f-019ffd34b827" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6bab54d5-5a88-4128-92d2-4d12ad0baa32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5e38d722-ca17-41a0-a134-1917bd7bbc0c", "AQAAAAEAACcQAAAAELS3GDRbuvlZZzX0iOxJs6QDQy40REKJCUFpEVMPrsDBlDKLRFTgZddsWek1Bb3iyA==", "9d7f14eb-efda-425c-a966-c25c0be7456b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "driverUser1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "66dd8ca8-f0f3-4d09-9276-d2d7e981f8ab", "AQAAAAEAACcQAAAAED7Kh2B9zk928/irWjYKRG841WRiliX/+tI87VtrSMcycEThsCK1IEry923DUxYr0A==", "29e757fb-a42a-43ac-a011-fa5cac53b868" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "driverUser2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "92324262-4441-4c0e-a00d-aee2cb9d3828", "805f2b52-cf11-4cc4-8f22-dad267354113" });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 10, 29, 19, 57, 53, 884, DateTimeKind.Local).AddTicks(116));

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 8, 29, 19, 57, 53, 884, DateTimeKind.Local).AddTicks(118));

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 5, 29, 19, 57, 53, 884, DateTimeKind.Local).AddTicks(120));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 24, 19, 57, 52, 383, DateTimeKind.Local).AddTicks(3399));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 25, 19, 57, 52, 383, DateTimeKind.Local).AddTicks(3401));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 26, 19, 57, 52, 383, DateTimeKind.Local).AddTicks(3403));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 27, 19, 57, 52, 383, DateTimeKind.Local).AddTicks(3404));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 28, 19, 57, 52, 383, DateTimeKind.Local).AddTicks(3406));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 29, 19, 57, 52, 383, DateTimeKind.Local).AddTicks(3408));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 9, 19, 57, 52, 389, DateTimeKind.Local).AddTicks(5717));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 19, 19, 57, 52, 389, DateTimeKind.Local).AddTicks(5742));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 1,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 28, 19, 57, 53, 853, DateTimeKind.Local).AddTicks(9182));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 2,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 27, 19, 57, 53, 853, DateTimeKind.Local).AddTicks(9190));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 3,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 26, 19, 57, 53, 853, DateTimeKind.Local).AddTicks(9198));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 4,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 25, 19, 57, 53, 853, DateTimeKind.Local).AddTicks(9200));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 5,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 24, 19, 57, 53, 853, DateTimeKind.Local).AddTicks(9202));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2024, 11, 24, 19, 57, 53, 865, DateTimeKind.Local).AddTicks(9474));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2024, 11, 25, 19, 57, 53, 865, DateTimeKind.Local).AddTicks(9476));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2024, 11, 26, 19, 57, 53, 865, DateTimeKind.Local).AddTicks(9478));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 4,
                column: "Timestamp",
                value: new DateTime(2024, 11, 27, 19, 57, 53, 865, DateTimeKind.Local).AddTicks(9479));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 5,
                column: "Timestamp",
                value: new DateTime(2024, 11, 28, 19, 57, 53, 865, DateTimeKind.Local).AddTicks(9481));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1,
                column: "LicenseExpiryDate",
                value: new DateTime(2025, 11, 29, 19, 57, 53, 10, DateTimeKind.Local).AddTicks(9927));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 2,
                column: "LicenseExpiryDate",
                value: new DateTime(2025, 11, 29, 19, 57, 53, 10, DateTimeKind.Local).AddTicks(9934));

            migrationBuilder.UpdateData(
                table: "FuelPrices",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 11, 26, 19, 57, 53, 878, DateTimeKind.Local).AddTicks(19));

            migrationBuilder.UpdateData(
                table: "FuelPrices",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 11, 27, 19, 57, 53, 878, DateTimeKind.Local).AddTicks(21));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InvoiceDate", "PaidDate" },
                values: new object[] { new DateTime(2024, 11, 19, 19, 57, 52, 397, DateTimeKind.Local).AddTicks(1474), new DateTime(2024, 11, 24, 19, 57, 52, 397, DateTimeKind.Local).AddTicks(1472) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 2,
                column: "InvoiceDate",
                value: new DateTime(2024, 11, 20, 19, 57, 52, 397, DateTimeKind.Local).AddTicks(1477));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "InvoiceDate", "PaidDate" },
                values: new object[] { new DateTime(2024, 11, 21, 19, 57, 52, 397, DateTimeKind.Local).AddTicks(1480), new DateTime(2024, 11, 23, 19, 57, 52, 397, DateTimeKind.Local).AddTicks(1479) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 4,
                column: "InvoiceDate",
                value: new DateTime(2024, 11, 22, 19, 57, 52, 397, DateTimeKind.Local).AddTicks(1482));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 5,
                column: "InvoiceDate",
                value: new DateTime(2024, 11, 23, 19, 57, 52, 397, DateTimeKind.Local).AddTicks(1484));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 1,
                column: "OfferDate",
                value: new DateTime(2024, 11, 14, 19, 57, 52, 403, DateTimeKind.Local).AddTicks(10));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 2,
                column: "OfferDate",
                value: new DateTime(2024, 11, 13, 19, 57, 52, 403, DateTimeKind.Local).AddTicks(12));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 3,
                column: "OfferDate",
                value: new DateTime(2024, 11, 14, 19, 57, 52, 403, DateTimeKind.Local).AddTicks(13));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 4,
                column: "OfferDate",
                value: new DateTime(2024, 11, 17, 19, 57, 52, 403, DateTimeKind.Local).AddTicks(15));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 5,
                column: "OfferDate",
                value: new DateTime(2024, 11, 16, 19, 57, 52, 403, DateTimeKind.Local).AddTicks(17));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 9, 19, 57, 52, 990, DateTimeKind.Local).AddTicks(7198), new DateTime(2024, 12, 6, 19, 57, 52, 990, DateTimeKind.Local).AddTicks(7195) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 8, 19, 57, 52, 990, DateTimeKind.Local).AddTicks(7204), new DateTime(2024, 12, 9, 19, 57, 52, 990, DateTimeKind.Local).AddTicks(7202) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 7, 19, 57, 52, 990, DateTimeKind.Local).AddTicks(7217), new DateTime(2024, 12, 4, 19, 57, 52, 990, DateTimeKind.Local).AddTicks(7215) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 6, 19, 57, 52, 990, DateTimeKind.Local).AddTicks(7229), new DateTime(2024, 11, 26, 19, 57, 52, 990, DateTimeKind.Local).AddTicks(7227) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 5, 19, 57, 52, 990, DateTimeKind.Local).AddTicks(7237), new DateTime(2024, 11, 24, 19, 57, 52, 990, DateTimeKind.Local).AddTicks(7236) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastYearMaintenance",
                value: new DateTime(2024, 8, 29, 19, 57, 53, 859, DateTimeKind.Local).AddTicks(8679));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastYearMaintenance",
                value: new DateTime(2024, 10, 29, 19, 57, 53, 859, DateTimeKind.Local).AddTicks(8684));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Offers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20ddc22c-ca6d-4feb-a688-0f31a430b5eb",
                column: "ConcurrencyStamp",
                value: "38c3afac-a625-4e6e-a0f5-c2a250f94fcf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27609f35-fbc8-4dc4-9d12-7ff2dd400327",
                column: "ConcurrencyStamp",
                value: "9d7f2aaf-dc06-4878-b10d-e2016b1e7b2a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "350868c0-bf0f-4f70-b4c9-155351bc6429",
                column: "ConcurrencyStamp",
                value: "b59ae789-af35-49dc-bf77-825ed09ce129");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d000e64-c056-419a-950f-1992bd1e910d",
                column: "ConcurrencyStamp",
                value: "e0c59188-2b80-4c8c-a619-3c7d992501b5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99027aaa-d346-4dd9-a467-15d74576c080",
                column: "ConcurrencyStamp",
                value: "0d2a5e03-f6fb-451c-8570-f834804c3309");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20450cff-816f-49c8-9546-1c603aec0301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "28060b82-646c-4b51-8206-f221091c129f", "AQAAAAEAACcQAAAAEGPtqAqPST+lJZD4CE00NzdiA7hrhVKEXsg9eJ5foy8XSbh0wIR7NPJQj6Biuhz9PA==", "ece6e058-2c42-456a-94f9-546ca7b089b9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e8be95a-186e-403b-b4aa-3874750a3563",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "20817e65-ff40-4ed9-9fa1-560f98c876e0", "AQAAAAEAACcQAAAAEMfMEMiR+QWgqg9TZsnJR1wkmihVtRg8rFm7Ny4ROH+Tna8UEQ/fB5SV3vEq5YumtA==", "8d5e9041-75db-4b01-9c12-17eb2474deff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38ba6810-2800-4ac8-b005-5c27e8248951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "945256a6-0528-4f05-b829-e0e35fd9678e", "AQAAAAEAACcQAAAAEOeKg4ySvglWAsygSWW9CYOKbETkTL0iXR+o4hEoRf/OoeILIofOFQuzZM9kUa72ag==", "22842c1f-fc0d-44f0-b0d4-848c4ada3523" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6bab54d5-5a88-4128-92d2-4d12ad0baa32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dc26af28-65f4-4006-82f9-32a45eec223f", "AQAAAAEAACcQAAAAEHAcekz76MYZOy41kVqt2Uev51T/huUng8hRx36o9mMVAe+iS7iRMpUMxxw3U0tAWg==", "d47018f4-0620-4fd4-b928-01c84f2ff0f7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "driverUser1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6e8b2b2c-b5cb-4c78-9689-d6417b0d91ee", "AQAAAAEAACcQAAAAEFYZBnghcamwYUqe5xIkU5VmKqSruA5DN35X9a4LEltUc2dPOriGiL1gE/obApy1ow==", "fba56ea4-5506-40fc-8a87-33537688293b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "driverUser2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "11754452-7d69-41de-a32f-f7d06da651d3", "82cebc70-70a1-451c-bad7-049664bbf975" });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 10, 29, 16, 11, 45, 546, DateTimeKind.Local).AddTicks(442));

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 8, 29, 16, 11, 45, 546, DateTimeKind.Local).AddTicks(446));

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 5, 29, 16, 11, 45, 546, DateTimeKind.Local).AddTicks(448));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 24, 16, 11, 43, 997, DateTimeKind.Local).AddTicks(7660));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 25, 16, 11, 43, 997, DateTimeKind.Local).AddTicks(7663));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 26, 16, 11, 43, 997, DateTimeKind.Local).AddTicks(7665));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 27, 16, 11, 43, 997, DateTimeKind.Local).AddTicks(7668));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 28, 16, 11, 43, 997, DateTimeKind.Local).AddTicks(7669));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 29, 16, 11, 43, 997, DateTimeKind.Local).AddTicks(7671));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 9, 16, 11, 44, 6, DateTimeKind.Local).AddTicks(8732));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 19, 16, 11, 44, 6, DateTimeKind.Local).AddTicks(8785));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 1,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 28, 16, 11, 45, 509, DateTimeKind.Local).AddTicks(9776));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 2,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 27, 16, 11, 45, 509, DateTimeKind.Local).AddTicks(9787));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 3,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 26, 16, 11, 45, 509, DateTimeKind.Local).AddTicks(9794));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 4,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 25, 16, 11, 45, 509, DateTimeKind.Local).AddTicks(9796));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 5,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 24, 16, 11, 45, 509, DateTimeKind.Local).AddTicks(9798));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2024, 11, 24, 16, 11, 45, 523, DateTimeKind.Local).AddTicks(9924));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2024, 11, 25, 16, 11, 45, 523, DateTimeKind.Local).AddTicks(9928));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2024, 11, 26, 16, 11, 45, 523, DateTimeKind.Local).AddTicks(9930));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 4,
                column: "Timestamp",
                value: new DateTime(2024, 11, 27, 16, 11, 45, 523, DateTimeKind.Local).AddTicks(9932));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 5,
                column: "Timestamp",
                value: new DateTime(2024, 11, 28, 16, 11, 45, 523, DateTimeKind.Local).AddTicks(9933));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1,
                column: "LicenseExpiryDate",
                value: new DateTime(2025, 11, 29, 16, 11, 44, 595, DateTimeKind.Local).AddTicks(8007));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 2,
                column: "LicenseExpiryDate",
                value: new DateTime(2025, 11, 29, 16, 11, 44, 595, DateTimeKind.Local).AddTicks(8012));

            migrationBuilder.UpdateData(
                table: "FuelPrices",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 11, 26, 16, 11, 45, 538, DateTimeKind.Local).AddTicks(4935));

            migrationBuilder.UpdateData(
                table: "FuelPrices",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 11, 27, 16, 11, 45, 538, DateTimeKind.Local).AddTicks(4936));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InvoiceDate", "PaidDate" },
                values: new object[] { new DateTime(2024, 11, 19, 16, 11, 44, 16, DateTimeKind.Local).AddTicks(2608), new DateTime(2024, 11, 24, 16, 11, 44, 16, DateTimeKind.Local).AddTicks(2606) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 2,
                column: "InvoiceDate",
                value: new DateTime(2024, 11, 20, 16, 11, 44, 16, DateTimeKind.Local).AddTicks(2612));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "InvoiceDate", "PaidDate" },
                values: new object[] { new DateTime(2024, 11, 21, 16, 11, 44, 16, DateTimeKind.Local).AddTicks(2615), new DateTime(2024, 11, 23, 16, 11, 44, 16, DateTimeKind.Local).AddTicks(2614) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 4,
                column: "InvoiceDate",
                value: new DateTime(2024, 11, 22, 16, 11, 44, 16, DateTimeKind.Local).AddTicks(2617));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 5,
                column: "InvoiceDate",
                value: new DateTime(2024, 11, 23, 16, 11, 44, 16, DateTimeKind.Local).AddTicks(2619));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 1,
                column: "OfferDate",
                value: new DateTime(2024, 11, 14, 16, 11, 44, 23, DateTimeKind.Local).AddTicks(9986));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 2,
                column: "OfferDate",
                value: new DateTime(2024, 11, 13, 16, 11, 44, 23, DateTimeKind.Local).AddTicks(9997));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 3,
                column: "OfferDate",
                value: new DateTime(2024, 11, 14, 16, 11, 44, 24, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 4,
                column: "OfferDate",
                value: new DateTime(2024, 11, 17, 16, 11, 44, 24, DateTimeKind.Local).AddTicks(5));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 5,
                column: "OfferDate",
                value: new DateTime(2024, 11, 16, 16, 11, 44, 24, DateTimeKind.Local).AddTicks(10));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 9, 16, 11, 44, 571, DateTimeKind.Local).AddTicks(7338), new DateTime(2024, 12, 6, 16, 11, 44, 571, DateTimeKind.Local).AddTicks(7334) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 8, 16, 11, 44, 571, DateTimeKind.Local).AddTicks(7344), new DateTime(2024, 12, 9, 16, 11, 44, 571, DateTimeKind.Local).AddTicks(7342) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 7, 16, 11, 44, 571, DateTimeKind.Local).AddTicks(7357), new DateTime(2024, 12, 4, 16, 11, 44, 571, DateTimeKind.Local).AddTicks(7355) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 6, 16, 11, 44, 571, DateTimeKind.Local).AddTicks(7365), new DateTime(2024, 11, 26, 16, 11, 44, 571, DateTimeKind.Local).AddTicks(7364) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 5, 16, 11, 44, 571, DateTimeKind.Local).AddTicks(7374), new DateTime(2024, 11, 24, 16, 11, 44, 571, DateTimeKind.Local).AddTicks(7372) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastYearMaintenance",
                value: new DateTime(2024, 8, 29, 16, 11, 45, 516, DateTimeKind.Local).AddTicks(7089));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastYearMaintenance",
                value: new DateTime(2024, 10, 29, 16, 11, 45, 516, DateTimeKind.Local).AddTicks(7099));
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogiTrack.Infrastructure.Migrations
{
    public partial class RemovedRequestIdFromCargo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StandartCargos_Requests_RequestId",
                table: "StandartCargos");

            migrationBuilder.DropIndex(
                name: "IX_StandartCargos_RequestId",
                table: "StandartCargos");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "StandartCargos");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20ddc22c-ca6d-4feb-a688-0f31a430b5eb",
                column: "ConcurrencyStamp",
                value: "af180716-342d-4bc8-86b4-46f5d176ef3d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27609f35-fbc8-4dc4-9d12-7ff2dd400327",
                column: "ConcurrencyStamp",
                value: "253ae90b-63e5-45a8-8dc7-f211ad79b201");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "350868c0-bf0f-4f70-b4c9-155351bc6429",
                column: "ConcurrencyStamp",
                value: "0497ddd2-d742-4943-abde-447b622aa118");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d000e64-c056-419a-950f-1992bd1e910d",
                column: "ConcurrencyStamp",
                value: "9912b150-e03f-4dab-93d7-b40767eaddb8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99027aaa-d346-4dd9-a467-15d74576c080",
                column: "ConcurrencyStamp",
                value: "ea5c7b5a-fe90-412d-b2da-3bdd4437c2e5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20450cff-816f-49c8-9546-1c603aec0301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9343f695-d117-45ca-aeca-9d92a4cd441b", "AQAAAAEAACcQAAAAEFvTwo8Jbtzy4LeZtavo25YmU7LAgvqoZ1ilgTY7cBr+7Yv9f8I+/CC1H6UvOqsX2A==", "3b42e325-bc58-4911-9c4c-cb8eb9d6a5f4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e8be95a-186e-403b-b4aa-3874750a3563",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "963032ff-05aa-406c-a7b5-bf2bf9f2c8da", "AQAAAAEAACcQAAAAEMtmO24KpVpqN6T+PPlZh3CbgnofhZe/T3AXwyMhRwLILopU7NxU+Uc0MZAV0Q+8Mw==", "54525c7c-0aba-49bf-ae31-70d7cb12f572" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38ba6810-2800-4ac8-b005-5c27e8248951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fc687b03-750e-4c4d-8309-708be414e377", "AQAAAAEAACcQAAAAECOcFjhBudx8Biu+SNovVEpnj7l29o8MjDDnsCb+B4L+w1TQIFSUq5sIa4Dn2uzDxg==", "21c4eb1d-9c73-4cd1-a3af-1f5890c99c1e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6bab54d5-5a88-4128-92d2-4d12ad0baa32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d45c7f9e-2af4-45dd-8946-46c422571190", "AQAAAAEAACcQAAAAEFNrNrmjEtK7FcEGYwtvIqdtIP6dw9MaeYTUU4anWXB4QtmC+fQLjcfTzNLGah5/Ow==", "f93871c0-bc6b-450a-a571-cd238c423965" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "driverUser1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bc12fbe7-226d-4fa6-94d2-27a3bd19ebe6", "AQAAAAEAACcQAAAAEF5puuxJlag3gjdIvtTlHvZcVUTm2aldwaOXVabPqvbHbZrc8313j5ieBI3tn+Pw0w==", "3a7e8e7c-c236-4e45-8fb1-ae3ab3ff7b8f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "driverUser2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "096b2d79-b176-4e3d-bb78-2de08d0e0116", "59824b6e-bf2c-49b8-bae2-10b69c38c94f" });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 10, 30, 1, 20, 19, 50, DateTimeKind.Local).AddTicks(9899));

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 8, 30, 1, 20, 19, 50, DateTimeKind.Local).AddTicks(9903));

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 5, 30, 1, 20, 19, 50, DateTimeKind.Local).AddTicks(9905));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 25, 1, 20, 18, 849, DateTimeKind.Local).AddTicks(159));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 26, 1, 20, 18, 849, DateTimeKind.Local).AddTicks(162));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 27, 1, 20, 18, 849, DateTimeKind.Local).AddTicks(164));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 28, 1, 20, 18, 849, DateTimeKind.Local).AddTicks(166));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 29, 1, 20, 18, 849, DateTimeKind.Local).AddTicks(168));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 30, 1, 20, 18, 849, DateTimeKind.Local).AddTicks(170));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 10, 1, 20, 18, 856, DateTimeKind.Local).AddTicks(1898));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 20, 1, 20, 18, 856, DateTimeKind.Local).AddTicks(1956));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 1,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 29, 1, 20, 19, 15, DateTimeKind.Local).AddTicks(3131));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 2,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 28, 1, 20, 19, 15, DateTimeKind.Local).AddTicks(3137));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 3,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 27, 1, 20, 19, 15, DateTimeKind.Local).AddTicks(3147));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 4,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 26, 1, 20, 19, 15, DateTimeKind.Local).AddTicks(3150));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 5,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 25, 1, 20, 19, 15, DateTimeKind.Local).AddTicks(3152));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2024, 11, 25, 1, 20, 19, 29, DateTimeKind.Local).AddTicks(5092));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2024, 11, 26, 1, 20, 19, 29, DateTimeKind.Local).AddTicks(5096));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2024, 11, 27, 1, 20, 19, 29, DateTimeKind.Local).AddTicks(5099));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 4,
                column: "Timestamp",
                value: new DateTime(2024, 11, 28, 1, 20, 19, 29, DateTimeKind.Local).AddTicks(5102));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 5,
                column: "Timestamp",
                value: new DateTime(2024, 11, 29, 1, 20, 19, 29, DateTimeKind.Local).AddTicks(5104));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1,
                column: "LicenseExpiryDate",
                value: new DateTime(2025, 11, 30, 1, 20, 19, 6, DateTimeKind.Local).AddTicks(1320));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 2,
                column: "LicenseExpiryDate",
                value: new DateTime(2025, 11, 30, 1, 20, 19, 6, DateTimeKind.Local).AddTicks(1326));

            migrationBuilder.UpdateData(
                table: "FuelPrices",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 11, 27, 1, 20, 19, 43, DateTimeKind.Local).AddTicks(8782));

            migrationBuilder.UpdateData(
                table: "FuelPrices",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 11, 28, 1, 20, 19, 43, DateTimeKind.Local).AddTicks(8784));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InvoiceDate", "PaidDate" },
                values: new object[] { new DateTime(2024, 11, 20, 1, 20, 18, 865, DateTimeKind.Local).AddTicks(8601), new DateTime(2024, 11, 25, 1, 20, 18, 865, DateTimeKind.Local).AddTicks(8599) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 2,
                column: "InvoiceDate",
                value: new DateTime(2024, 11, 21, 1, 20, 18, 865, DateTimeKind.Local).AddTicks(8604));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "InvoiceDate", "PaidDate" },
                values: new object[] { new DateTime(2024, 11, 22, 1, 20, 18, 865, DateTimeKind.Local).AddTicks(8608), new DateTime(2024, 11, 24, 1, 20, 18, 865, DateTimeKind.Local).AddTicks(8607) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 4,
                column: "InvoiceDate",
                value: new DateTime(2024, 11, 23, 1, 20, 18, 865, DateTimeKind.Local).AddTicks(8610));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 5,
                column: "InvoiceDate",
                value: new DateTime(2024, 11, 24, 1, 20, 18, 865, DateTimeKind.Local).AddTicks(8612));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 1,
                column: "OfferDate",
                value: new DateTime(2024, 11, 15, 1, 20, 18, 873, DateTimeKind.Local).AddTicks(6928));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 2,
                column: "OfferDate",
                value: new DateTime(2024, 11, 14, 1, 20, 18, 873, DateTimeKind.Local).AddTicks(6933));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 3,
                column: "OfferDate",
                value: new DateTime(2024, 11, 15, 1, 20, 18, 873, DateTimeKind.Local).AddTicks(6936));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 4,
                column: "OfferDate",
                value: new DateTime(2024, 11, 18, 1, 20, 18, 873, DateTimeKind.Local).AddTicks(6938));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 5,
                column: "OfferDate",
                value: new DateTime(2024, 11, 17, 1, 20, 18, 873, DateTimeKind.Local).AddTicks(6941));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate", "StandartCargoId" },
                values: new object[] { new DateTime(2024, 11, 10, 1, 20, 18, 985, DateTimeKind.Local).AddTicks(1142), new DateTime(2024, 12, 7, 1, 20, 18, 985, DateTimeKind.Local).AddTicks(1138), 1 });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate", "StandartCargoId" },
                values: new object[] { new DateTime(2024, 11, 9, 1, 20, 18, 985, DateTimeKind.Local).AddTicks(1148), new DateTime(2024, 12, 10, 1, 20, 18, 985, DateTimeKind.Local).AddTicks(1147), 2 });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 8, 1, 20, 18, 985, DateTimeKind.Local).AddTicks(1171), new DateTime(2024, 12, 5, 1, 20, 18, 985, DateTimeKind.Local).AddTicks(1169) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate", "StandartCargoId" },
                values: new object[] { new DateTime(2024, 11, 7, 1, 20, 18, 985, DateTimeKind.Local).AddTicks(1182), new DateTime(2024, 11, 27, 1, 20, 18, 985, DateTimeKind.Local).AddTicks(1181), 3 });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate", "StandartCargoId" },
                values: new object[] { new DateTime(2024, 11, 6, 1, 20, 18, 985, DateTimeKind.Local).AddTicks(1192), new DateTime(2024, 11, 25, 1, 20, 18, 985, DateTimeKind.Local).AddTicks(1190), 4 });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastYearMaintenance",
                value: new DateTime(2024, 8, 30, 1, 20, 19, 22, DateTimeKind.Local).AddTicks(2654));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastYearMaintenance",
                value: new DateTime(2024, 10, 30, 1, 20, 19, 22, DateTimeKind.Local).AddTicks(2664));

            migrationBuilder.CreateIndex(
                name: "IX_Requests_StandartCargoId",
                table: "Requests",
                column: "StandartCargoId");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropIndex(
                name: "IX_Requests_StandartCargoId",
                table: "Requests");

            migrationBuilder.AddColumn<int>(
                name: "RequestId",
                table: "StandartCargos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Request identifier");

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
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate", "StandartCargoId" },
                values: new object[] { new DateTime(2024, 11, 9, 19, 57, 52, 990, DateTimeKind.Local).AddTicks(7198), new DateTime(2024, 12, 6, 19, 57, 52, 990, DateTimeKind.Local).AddTicks(7195), 0 });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate", "StandartCargoId" },
                values: new object[] { new DateTime(2024, 11, 8, 19, 57, 52, 990, DateTimeKind.Local).AddTicks(7204), new DateTime(2024, 12, 9, 19, 57, 52, 990, DateTimeKind.Local).AddTicks(7202), 0 });

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
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate", "StandartCargoId" },
                values: new object[] { new DateTime(2024, 11, 6, 19, 57, 52, 990, DateTimeKind.Local).AddTicks(7229), new DateTime(2024, 11, 26, 19, 57, 52, 990, DateTimeKind.Local).AddTicks(7227), 0 });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate", "StandartCargoId" },
                values: new object[] { new DateTime(2024, 11, 5, 19, 57, 52, 990, DateTimeKind.Local).AddTicks(7237), new DateTime(2024, 11, 24, 19, 57, 52, 990, DateTimeKind.Local).AddTicks(7236), 0 });

            migrationBuilder.UpdateData(
                table: "StandartCargos",
                keyColumn: "Id",
                keyValue: 1,
                column: "RequestId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "StandartCargos",
                keyColumn: "Id",
                keyValue: 2,
                column: "RequestId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "StandartCargos",
                keyColumn: "Id",
                keyValue: 3,
                column: "RequestId",
                value: 4);

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

            migrationBuilder.CreateIndex(
                name: "IX_StandartCargos_RequestId",
                table: "StandartCargos",
                column: "RequestId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StandartCargos_Requests_RequestId",
                table: "StandartCargos",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

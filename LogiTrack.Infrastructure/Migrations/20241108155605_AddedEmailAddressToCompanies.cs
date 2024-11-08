using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogiTrack.Infrastructure.Migrations
{
    public partial class AddedEmailAddressToCompanies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "ClientCompanies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20ddc22c-ca6d-4feb-a688-0f31a430b5eb",
                column: "ConcurrencyStamp",
                value: "06d54a1b-acde-4dcd-bdb0-523f9e6f2c80");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27609f35-fbc8-4dc4-9d12-7ff2dd400327",
                column: "ConcurrencyStamp",
                value: "7977cb58-56d9-4325-ae3b-d206d248af5d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "350868c0-bf0f-4f70-b4c9-155351bc6429",
                column: "ConcurrencyStamp",
                value: "92e754a4-50b2-4a4a-ae48-b5bff7e17a36");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d000e64-c056-419a-950f-1992bd1e910d",
                column: "ConcurrencyStamp",
                value: "b8a34dbe-8421-451b-9f6a-4d57d7833010");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99027aaa-d346-4dd9-a467-15d74576c080",
                column: "ConcurrencyStamp",
                value: "c5a01987-c494-42c2-9983-c978397e7b1a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20450cff-816f-49c8-9546-1c603aec0301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "63671d40-439b-4a7d-9f87-3ad6f9c4eac4", "AQAAAAEAACcQAAAAELS9tvO6XLrJznkt5Hp0I2CIPH9tRJ0n6eXPB6GwzrVCO41hGQ1wB/RopTdNSxrNmA==", "96117ea1-7e81-42a2-a8ec-eb3978fda9bf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e8be95a-186e-403b-b4aa-3874750a3563",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "039bb3a9-c168-4dc6-a291-fd9652403e57", "AQAAAAEAACcQAAAAEOyh6mftTQa6CCmbduyEjTO+kJeASZ3eCuFkUKfOir8P9rAsHbajnSrhiOtAS53WwA==", "374645f3-7ea5-4c92-9519-5fe5a98fd662" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38ba6810-2800-4ac8-b005-5c27e8248951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8fe1604a-ac93-4baa-bee1-e58df32cfe02", "AQAAAAEAACcQAAAAEG+m+DqbmoYJSeQqA3RAPw93vQ15Ervgj/O0IC2Joy2s2bnAMXMKeg+Ssdn/OgzClA==", "23d96e5e-085b-45d7-9a5b-efc7969ba9e0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6bab54d5-5a88-4128-92d2-4d12ad0baa32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f15aaeb2-bdeb-4141-8ab1-658beae79894", "AQAAAAEAACcQAAAAEO8KRnvnjIGrSuCNT/qk9BB9MP1FUuImSIeHK/SbZ7d+p5i2Efh1Fe8Vm3Yg+lkxkg==", "86b1a73d-8333-4001-90ab-478e657bf2e4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "driverUser1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bb77eadc-dafe-4f52-a18a-9efbbab5d3ab", "AQAAAAEAACcQAAAAEDa+n8BT42wM4rQzG8Ae+5vwU+LvfRvk2vriA1D0Sqc/YvSZhipt6emjvmjfkbk1qw==", "8d2bf959-4ea5-421b-bfab-77f45e54c910" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "driverUser2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "24f030cb-be56-40d1-9851-930a9891a3a9", "bbe9b708-4f9d-4382-b7d9-21ac46845949" });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 10, 8, 17, 56, 3, 625, DateTimeKind.Local).AddTicks(874));

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 8, 8, 17, 56, 3, 625, DateTimeKind.Local).AddTicks(877));

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 5, 8, 17, 56, 3, 625, DateTimeKind.Local).AddTicks(879));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 3, 17, 56, 2, 395, DateTimeKind.Local).AddTicks(8771));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 4, 17, 56, 2, 395, DateTimeKind.Local).AddTicks(8777));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 5, 17, 56, 2, 395, DateTimeKind.Local).AddTicks(8781));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 6, 17, 56, 2, 395, DateTimeKind.Local).AddTicks(8784));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 7, 17, 56, 2, 395, DateTimeKind.Local).AddTicks(8788));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 8, 17, 56, 2, 395, DateTimeKind.Local).AddTicks(8792));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EmailAddress" },
                values: new object[] { new DateTime(2024, 10, 19, 17, 56, 2, 407, DateTimeKind.Local).AddTicks(1122), "" });

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EmailAddress" },
                values: new object[] { new DateTime(2024, 10, 29, 17, 56, 2, 407, DateTimeKind.Local).AddTicks(1174), "yyotova@tu-sofia.bg" });

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 1,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 7, 17, 56, 3, 571, DateTimeKind.Local).AddTicks(435));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 2,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 6, 17, 56, 3, 571, DateTimeKind.Local).AddTicks(441));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 3,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 5, 17, 56, 3, 571, DateTimeKind.Local).AddTicks(445));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 4,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 4, 17, 56, 3, 571, DateTimeKind.Local).AddTicks(448));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 5,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 3, 17, 56, 3, 571, DateTimeKind.Local).AddTicks(455));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2024, 11, 3, 17, 56, 3, 595, DateTimeKind.Local).AddTicks(1778));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2024, 11, 4, 17, 56, 3, 595, DateTimeKind.Local).AddTicks(1783));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2024, 11, 5, 17, 56, 3, 595, DateTimeKind.Local).AddTicks(1787));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 4,
                column: "Timestamp",
                value: new DateTime(2024, 11, 6, 17, 56, 3, 595, DateTimeKind.Local).AddTicks(1790));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 5,
                column: "Timestamp",
                value: new DateTime(2024, 11, 7, 17, 56, 3, 595, DateTimeKind.Local).AddTicks(1793));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1,
                column: "LicenseExpiryDate",
                value: new DateTime(2025, 11, 8, 17, 56, 2, 717, DateTimeKind.Local).AddTicks(6592));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 2,
                column: "LicenseExpiryDate",
                value: new DateTime(2025, 11, 8, 17, 56, 2, 717, DateTimeKind.Local).AddTicks(6604));

            migrationBuilder.UpdateData(
                table: "FuelPrices",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 11, 5, 17, 56, 3, 614, DateTimeKind.Local).AddTicks(3538));

            migrationBuilder.UpdateData(
                table: "FuelPrices",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 11, 6, 17, 56, 3, 614, DateTimeKind.Local).AddTicks(3540));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                column: "InvoiceDate",
                value: new DateTime(2024, 10, 29, 17, 56, 2, 663, DateTimeKind.Local).AddTicks(5923));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 2,
                column: "InvoiceDate",
                value: new DateTime(2024, 10, 30, 17, 56, 2, 663, DateTimeKind.Local).AddTicks(5948));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 3,
                column: "InvoiceDate",
                value: new DateTime(2024, 10, 31, 17, 56, 2, 663, DateTimeKind.Local).AddTicks(6013));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 4,
                column: "InvoiceDate",
                value: new DateTime(2024, 11, 1, 17, 56, 2, 663, DateTimeKind.Local).AddTicks(6016));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 5,
                column: "InvoiceDate",
                value: new DateTime(2024, 11, 2, 17, 56, 2, 663, DateTimeKind.Local).AddTicks(6020));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 1,
                column: "OfferDate",
                value: new DateTime(2024, 10, 29, 17, 56, 2, 673, DateTimeKind.Local).AddTicks(95));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 2,
                column: "OfferDate",
                value: new DateTime(2024, 10, 31, 17, 56, 2, 673, DateTimeKind.Local).AddTicks(101));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 3,
                column: "OfferDate",
                value: new DateTime(2024, 11, 3, 17, 56, 2, 673, DateTimeKind.Local).AddTicks(104));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 4,
                column: "OfferDate",
                value: new DateTime(2024, 11, 6, 17, 56, 2, 673, DateTimeKind.Local).AddTicks(107));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 5,
                column: "OfferDate",
                value: new DateTime(2024, 11, 8, 17, 56, 2, 673, DateTimeKind.Local).AddTicks(109));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 8, 17, 56, 2, 686, DateTimeKind.Local).AddTicks(2405), new DateTime(2024, 11, 15, 17, 56, 2, 686, DateTimeKind.Local).AddTicks(2401) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 8, 17, 56, 2, 686, DateTimeKind.Local).AddTicks(2413), new DateTime(2024, 11, 18, 17, 56, 2, 686, DateTimeKind.Local).AddTicks(2411) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 8, 17, 56, 2, 686, DateTimeKind.Local).AddTicks(2421), new DateTime(2024, 11, 23, 17, 56, 2, 686, DateTimeKind.Local).AddTicks(2417) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 8, 17, 56, 2, 686, DateTimeKind.Local).AddTicks(2428), new DateTime(2024, 11, 11, 17, 56, 2, 686, DateTimeKind.Local).AddTicks(2425) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 8, 17, 56, 2, 686, DateTimeKind.Local).AddTicks(2447), new DateTime(2024, 11, 12, 17, 56, 2, 686, DateTimeKind.Local).AddTicks(2445) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastYearMaintenance",
                value: new DateTime(2024, 8, 8, 17, 56, 3, 581, DateTimeKind.Local).AddTicks(1610));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastYearMaintenance",
                value: new DateTime(2024, 10, 8, 17, 56, 3, 581, DateTimeKind.Local).AddTicks(1616));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "ClientCompanies");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20ddc22c-ca6d-4feb-a688-0f31a430b5eb",
                column: "ConcurrencyStamp",
                value: "09b6c40d-b530-4366-8170-052652683df4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27609f35-fbc8-4dc4-9d12-7ff2dd400327",
                column: "ConcurrencyStamp",
                value: "cd05c3ca-8c70-479f-8c68-5a3981eade49");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "350868c0-bf0f-4f70-b4c9-155351bc6429",
                column: "ConcurrencyStamp",
                value: "2b273e33-f4a1-4c7b-988c-363e9e2a8de0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d000e64-c056-419a-950f-1992bd1e910d",
                column: "ConcurrencyStamp",
                value: "c19bcd41-1277-4197-96d6-9987e5795b11");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99027aaa-d346-4dd9-a467-15d74576c080",
                column: "ConcurrencyStamp",
                value: "5f125b94-826e-4411-8bb3-b39c9eb373b9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20450cff-816f-49c8-9546-1c603aec0301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b867800e-06b9-4ec8-bbdf-d097fd31ee30", "AQAAAAEAACcQAAAAEBcFWZqc/Aymhkvojca4rceWLXJpHZ1GIO779WkCCdG+f3r3CtGh5K+UMkzP9etjSQ==", "6664513d-933e-4aa2-a3ac-604550d6f7f9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e8be95a-186e-403b-b4aa-3874750a3563",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d7abcb50-9302-4ce9-a592-4dcddd94e286", "AQAAAAEAACcQAAAAEE2zyDzHrqBE1XnwbXbjFGe3xvcdVzGtvHm/7RWWpAWS0KIxP0qnD2WSO4CD1nL8kQ==", "ee2370a6-5910-4752-940d-605e1582b3fd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38ba6810-2800-4ac8-b005-5c27e8248951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "996ee4dc-8637-446d-b3c1-298d04b40b30", "AQAAAAEAACcQAAAAEJ3XyZanXJTzWc0kidV7TFpRWlcaHp+TxmtQ/1RsivDSndhQwAfCDmSTfvPijq3LYQ==", "e7e1fb9c-8c04-448d-bf8a-33521c60b18d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6bab54d5-5a88-4128-92d2-4d12ad0baa32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "675fc702-8cf9-4c4b-99b2-8a064a60ae09", "AQAAAAEAACcQAAAAEGdk7q9uBNc6Ss5/Lp9vgklWBfyKzkU5n/6J7q9HY+GM3F4hMYOs6pQUcHT+VcPlmQ==", "cea532cb-26e0-420e-b07f-7d0722056424" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "driverUser1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cbc9dea0-e932-4120-8a95-1d97a4d13ebf", "AQAAAAEAACcQAAAAEI4VorIQdF6/qXgKdMI0JM4sRMtyHh4GsQpCDQxU0eRkb6OraLNGEZwUlEGWQYNibA==", "20e6d1a2-9c0a-4286-83b6-1f0ec0362aaf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "driverUser2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a1fbeb75-294e-46ec-acdd-aaf9616c2b79", "fd6f916b-5edf-47ff-abb0-e0afc24f2844" });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 10, 8, 15, 40, 25, 582, DateTimeKind.Local).AddTicks(8));

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 8, 8, 15, 40, 25, 582, DateTimeKind.Local).AddTicks(11));

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 5, 8, 15, 40, 25, 582, DateTimeKind.Local).AddTicks(13));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 3, 15, 40, 24, 324, DateTimeKind.Local).AddTicks(4350));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 4, 15, 40, 24, 324, DateTimeKind.Local).AddTicks(4354));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 5, 15, 40, 24, 324, DateTimeKind.Local).AddTicks(4357));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 6, 15, 40, 24, 324, DateTimeKind.Local).AddTicks(4359));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 7, 15, 40, 24, 324, DateTimeKind.Local).AddTicks(4362));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 8, 15, 40, 24, 324, DateTimeKind.Local).AddTicks(4364));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 19, 15, 40, 24, 333, DateTimeKind.Local).AddTicks(5608));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 29, 15, 40, 24, 333, DateTimeKind.Local).AddTicks(5703));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 1,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 7, 15, 40, 25, 526, DateTimeKind.Local).AddTicks(4746));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 2,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 6, 15, 40, 25, 526, DateTimeKind.Local).AddTicks(4758));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 3,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 5, 15, 40, 25, 526, DateTimeKind.Local).AddTicks(4763));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 4,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 4, 15, 40, 25, 526, DateTimeKind.Local).AddTicks(4767));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 5,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 3, 15, 40, 25, 526, DateTimeKind.Local).AddTicks(4771));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2024, 11, 3, 15, 40, 25, 547, DateTimeKind.Local).AddTicks(8140));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2024, 11, 4, 15, 40, 25, 547, DateTimeKind.Local).AddTicks(8144));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2024, 11, 5, 15, 40, 25, 547, DateTimeKind.Local).AddTicks(8147));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 4,
                column: "Timestamp",
                value: new DateTime(2024, 11, 6, 15, 40, 25, 547, DateTimeKind.Local).AddTicks(8150));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 5,
                column: "Timestamp",
                value: new DateTime(2024, 11, 7, 15, 40, 25, 547, DateTimeKind.Local).AddTicks(8152));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1,
                column: "LicenseExpiryDate",
                value: new DateTime(2025, 11, 8, 15, 40, 24, 630, DateTimeKind.Local).AddTicks(2411));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 2,
                column: "LicenseExpiryDate",
                value: new DateTime(2025, 11, 8, 15, 40, 24, 630, DateTimeKind.Local).AddTicks(2419));

            migrationBuilder.UpdateData(
                table: "FuelPrices",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 11, 5, 15, 40, 25, 569, DateTimeKind.Local).AddTicks(5120));

            migrationBuilder.UpdateData(
                table: "FuelPrices",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 11, 6, 15, 40, 25, 569, DateTimeKind.Local).AddTicks(5123));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                column: "InvoiceDate",
                value: new DateTime(2024, 10, 29, 15, 40, 24, 345, DateTimeKind.Local).AddTicks(2744));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 2,
                column: "InvoiceDate",
                value: new DateTime(2024, 10, 30, 15, 40, 24, 345, DateTimeKind.Local).AddTicks(2747));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 3,
                column: "InvoiceDate",
                value: new DateTime(2024, 10, 31, 15, 40, 24, 345, DateTimeKind.Local).AddTicks(2750));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 4,
                column: "InvoiceDate",
                value: new DateTime(2024, 11, 1, 15, 40, 24, 345, DateTimeKind.Local).AddTicks(2752));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 5,
                column: "InvoiceDate",
                value: new DateTime(2024, 11, 2, 15, 40, 24, 345, DateTimeKind.Local).AddTicks(2755));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 1,
                column: "OfferDate",
                value: new DateTime(2024, 10, 29, 15, 40, 24, 354, DateTimeKind.Local).AddTicks(7317));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 2,
                column: "OfferDate",
                value: new DateTime(2024, 10, 31, 15, 40, 24, 354, DateTimeKind.Local).AddTicks(7322));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 3,
                column: "OfferDate",
                value: new DateTime(2024, 11, 3, 15, 40, 24, 354, DateTimeKind.Local).AddTicks(7326));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 4,
                column: "OfferDate",
                value: new DateTime(2024, 11, 6, 15, 40, 24, 354, DateTimeKind.Local).AddTicks(7330));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 5,
                column: "OfferDate",
                value: new DateTime(2024, 11, 8, 15, 40, 24, 354, DateTimeKind.Local).AddTicks(7333));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 8, 15, 40, 24, 602, DateTimeKind.Local).AddTicks(2501), new DateTime(2024, 11, 15, 15, 40, 24, 602, DateTimeKind.Local).AddTicks(2498) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 8, 15, 40, 24, 602, DateTimeKind.Local).AddTicks(2508), new DateTime(2024, 11, 18, 15, 40, 24, 602, DateTimeKind.Local).AddTicks(2506) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 8, 15, 40, 24, 602, DateTimeKind.Local).AddTicks(2533), new DateTime(2024, 11, 23, 15, 40, 24, 602, DateTimeKind.Local).AddTicks(2530) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 8, 15, 40, 24, 602, DateTimeKind.Local).AddTicks(2544), new DateTime(2024, 11, 11, 15, 40, 24, 602, DateTimeKind.Local).AddTicks(2542) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 8, 15, 40, 24, 602, DateTimeKind.Local).AddTicks(2553), new DateTime(2024, 11, 12, 15, 40, 24, 602, DateTimeKind.Local).AddTicks(2551) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastYearMaintenance",
                value: new DateTime(2024, 8, 8, 15, 40, 25, 537, DateTimeKind.Local).AddTicks(4333));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastYearMaintenance",
                value: new DateTime(2024, 10, 8, 15, 40, 25, 537, DateTimeKind.Local).AddTicks(4340));
        }
    }
}

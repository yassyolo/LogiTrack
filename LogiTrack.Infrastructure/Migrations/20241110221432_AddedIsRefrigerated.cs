using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogiTrack.Infrastructure.Migrations
{
    public partial class AddedIsRefrigerated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "KilometersLeftToChangeParts",
                table: "Vehicles",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldComment: "Kilometers left to change parts");

            migrationBuilder.AddColumn<bool>(
                name: "IsRefrigerated",
                table: "Vehicles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "KilometersToChangeParts",
                table: "Vehicles",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                comment: "Kilometers to change parts");

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8ad2baff-24e1-4627-995f-d653eda93236", "AQAAAAEAACcQAAAAEJqoHuznAUK3v2TG7IybsPfE2Nac/lFihiISBS5KUqEc55DPDBactYNDV9CGSSv5dA==", "df65b492-5fa0-4dc4-8dfd-9f4a9c113e9d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "driverUser2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9a4f9030-d5a1-4d4d-8077-1c3c4616d003", "bd65825d-85a6-4f29-8086-60ca4e577b28" });

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
                column: "CreatedAt",
                value: new DateTime(2024, 10, 22, 0, 14, 28, 509, DateTimeKind.Local).AddTicks(5324));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 1, 0, 14, 28, 509, DateTimeKind.Local).AddTicks(5354));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRefrigerated",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "KilometersToChangeParts",
                table: "Vehicles");

            migrationBuilder.AlterColumn<double>(
                name: "KilometersLeftToChangeParts",
                table: "Vehicles",
                type: "float",
                nullable: false,
                comment: "Kilometers left to change parts",
                oldClrType: typeof(double),
                oldType: "float");

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
                column: "CreatedAt",
                value: new DateTime(2024, 10, 19, 17, 56, 2, 407, DateTimeKind.Local).AddTicks(1122));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 29, 17, 56, 2, 407, DateTimeKind.Local).AddTicks(1174));

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
    }
}

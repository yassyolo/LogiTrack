using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogiTrack.Infrastructure.Migrations
{
    public partial class AddedSuggestedStartDateToDelivery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Offers");

            migrationBuilder.AddColumn<DateTime>(
                name: "SuggestedDate",
                table: "Deliveries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20ddc22c-ca6d-4feb-a688-0f31a430b5eb",
                column: "ConcurrencyStamp",
                value: "265ffa95-19d4-4304-8fcc-086aea834b96");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27609f35-fbc8-4dc4-9d12-7ff2dd400327",
                column: "ConcurrencyStamp",
                value: "f4d9aea8-d1e2-42f0-8093-97269bb9db63");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "350868c0-bf0f-4f70-b4c9-155351bc6429",
                column: "ConcurrencyStamp",
                value: "e2823e02-8369-447c-912c-451e8942fec8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d000e64-c056-419a-950f-1992bd1e910d",
                column: "ConcurrencyStamp",
                value: "ba2c6ce9-d724-4729-b830-e818f4d9af84");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99027aaa-d346-4dd9-a467-15d74576c080",
                column: "ConcurrencyStamp",
                value: "4b7bb3ff-3782-4968-a092-34d1ee2761b1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20450cff-816f-49c8-9546-1c603aec0301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a9826aa2-7e4f-4218-b4e1-5298625cee0e", "AQAAAAEAACcQAAAAEEYQlxaqTX2qnBaZmutWjxr5jIFxn4i1Ly0aXWm9gRY8Q/CBdTlK4PRf2q77D/msvw==", "566fb86c-3e5e-4b1c-b61c-71fb0bcac2ab" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e8be95a-186e-403b-b4aa-3874750a3563",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c67a94a8-15df-4c53-8a73-00343d3a4cbe", "AQAAAAEAACcQAAAAENDbjiDRH8jwx9acEqPE37mdzvZGkyOpdyXLeJ+Hv08iFk0zVz3vyurgd6SIIk8mfA==", "664a8f01-4102-4e86-a7a4-07dc4ca3737e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38ba6810-2800-4ac8-b005-5c27e8248951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2ade61f2-ce57-4256-9e24-9a94bd15f138", "AQAAAAEAACcQAAAAENE+btZtvoDSG/V3bQItfhzfvSmg85TSm1gI9gDwmv6q66pvy3ovwYqq6JPZDriDzA==", "9705c184-ba3a-4ca5-b989-726a099bfa29" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6bab54d5-5a88-4128-92d2-4d12ad0baa32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a28a9d5a-8fae-45cb-a597-8455cf73943e", "AQAAAAEAACcQAAAAEOdJvJqhYr2kUJSxy/s+fQ5n7GvZ7fRp3sHb/a9wiMVA+ZoLeYUCkIvFrEKUAVaFdg==", "74d79e7e-bc51-4bca-9368-acf80abc1db2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "driverUser1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "beb6e75c-a375-4c07-a2ad-c66b381a4c31", "AQAAAAEAACcQAAAAEGFy2kXndHrB72v/mnno4/t6/TAcM4DlqqKeBwwsL9cjRjbGYXNVHSUSADYi6vSWQA==", "14261d52-05b1-4c27-a681-36eb02d12d4c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "driverUser2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "efcbd08f-912b-4abe-a6d9-f6a42710450e", "4ceb203c-26f2-46dd-b717-2f71339977a6" });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 11, 8, 20, 13, 4, 693, DateTimeKind.Local).AddTicks(9927));

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 9, 8, 20, 13, 4, 693, DateTimeKind.Local).AddTicks(9930));

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 6, 8, 20, 13, 4, 693, DateTimeKind.Local).AddTicks(9932));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateSubmitted",
                value: new DateTime(2024, 12, 3, 20, 13, 4, 586, DateTimeKind.Local).AddTicks(4065));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateSubmitted",
                value: new DateTime(2024, 12, 4, 20, 13, 4, 586, DateTimeKind.Local).AddTicks(4068));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateSubmitted",
                value: new DateTime(2024, 12, 5, 20, 13, 4, 586, DateTimeKind.Local).AddTicks(4070));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateSubmitted",
                value: new DateTime(2024, 12, 6, 20, 13, 4, 586, DateTimeKind.Local).AddTicks(4072));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateSubmitted",
                value: new DateTime(2024, 12, 7, 20, 13, 4, 586, DateTimeKind.Local).AddTicks(4074));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateSubmitted",
                value: new DateTime(2024, 12, 8, 20, 13, 4, 586, DateTimeKind.Local).AddTicks(4076));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 18, 20, 13, 4, 594, DateTimeKind.Local).AddTicks(2427));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 28, 20, 13, 4, 594, DateTimeKind.Local).AddTicks(2483));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 1,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 12, 7, 20, 13, 4, 655, DateTimeKind.Local).AddTicks(8618));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 2,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 12, 6, 20, 13, 4, 655, DateTimeKind.Local).AddTicks(8626));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 3,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 12, 5, 20, 13, 4, 655, DateTimeKind.Local).AddTicks(8631));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 4,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 12, 4, 20, 13, 4, 655, DateTimeKind.Local).AddTicks(8636));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 5,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 12, 3, 20, 13, 4, 655, DateTimeKind.Local).AddTicks(8640));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2024, 12, 3, 20, 13, 4, 670, DateTimeKind.Local).AddTicks(8433));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2024, 12, 4, 20, 13, 4, 670, DateTimeKind.Local).AddTicks(8439));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2024, 12, 5, 20, 13, 4, 670, DateTimeKind.Local).AddTicks(8443));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 4,
                column: "Timestamp",
                value: new DateTime(2024, 12, 6, 20, 13, 4, 670, DateTimeKind.Local).AddTicks(8446));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 5,
                column: "Timestamp",
                value: new DateTime(2024, 12, 7, 20, 13, 4, 670, DateTimeKind.Local).AddTicks(8449));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1,
                column: "LicenseExpiryDate",
                value: new DateTime(2025, 12, 8, 20, 13, 4, 645, DateTimeKind.Local).AddTicks(1488));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 2,
                column: "LicenseExpiryDate",
                value: new DateTime(2025, 12, 8, 20, 13, 4, 645, DateTimeKind.Local).AddTicks(1495));

            migrationBuilder.UpdateData(
                table: "FuelPrices",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 12, 5, 20, 13, 4, 686, DateTimeKind.Local).AddTicks(9290));

            migrationBuilder.UpdateData(
                table: "FuelPrices",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 12, 6, 20, 13, 4, 686, DateTimeKind.Local).AddTicks(9292));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InvoiceDate", "PaidDate" },
                values: new object[] { new DateTime(2024, 11, 28, 20, 13, 4, 604, DateTimeKind.Local).AddTicks(431), new DateTime(2024, 12, 3, 20, 13, 4, 604, DateTimeKind.Local).AddTicks(429) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 2,
                column: "InvoiceDate",
                value: new DateTime(2024, 11, 29, 20, 13, 4, 604, DateTimeKind.Local).AddTicks(435));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "InvoiceDate", "PaidDate" },
                values: new object[] { new DateTime(2024, 11, 30, 20, 13, 4, 604, DateTimeKind.Local).AddTicks(439), new DateTime(2024, 12, 2, 20, 13, 4, 604, DateTimeKind.Local).AddTicks(437) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 4,
                column: "InvoiceDate",
                value: new DateTime(2024, 12, 1, 20, 13, 4, 604, DateTimeKind.Local).AddTicks(441));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 5,
                column: "InvoiceDate",
                value: new DateTime(2024, 12, 2, 20, 13, 4, 604, DateTimeKind.Local).AddTicks(445));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 1,
                column: "OfferDate",
                value: new DateTime(2024, 11, 23, 20, 13, 4, 611, DateTimeKind.Local).AddTicks(1690));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 2,
                column: "OfferDate",
                value: new DateTime(2024, 11, 22, 20, 13, 4, 611, DateTimeKind.Local).AddTicks(1693));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 3,
                column: "OfferDate",
                value: new DateTime(2024, 11, 23, 20, 13, 4, 611, DateTimeKind.Local).AddTicks(1695));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 4,
                column: "OfferDate",
                value: new DateTime(2024, 11, 26, 20, 13, 4, 611, DateTimeKind.Local).AddTicks(1697));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 5,
                column: "OfferDate",
                value: new DateTime(2024, 11, 25, 20, 13, 4, 611, DateTimeKind.Local).AddTicks(1699));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 18, 20, 13, 4, 621, DateTimeKind.Local).AddTicks(8885), new DateTime(2024, 12, 15, 20, 13, 4, 621, DateTimeKind.Local).AddTicks(8882) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 17, 20, 13, 4, 621, DateTimeKind.Local).AddTicks(8979), new DateTime(2024, 12, 18, 20, 13, 4, 621, DateTimeKind.Local).AddTicks(8973) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 16, 20, 13, 4, 621, DateTimeKind.Local).AddTicks(8984), new DateTime(2024, 12, 13, 20, 13, 4, 621, DateTimeKind.Local).AddTicks(8983) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 15, 20, 13, 4, 621, DateTimeKind.Local).AddTicks(8989), new DateTime(2024, 12, 5, 20, 13, 4, 621, DateTimeKind.Local).AddTicks(8987) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 14, 20, 13, 4, 621, DateTimeKind.Local).AddTicks(8996), new DateTime(2024, 12, 3, 20, 13, 4, 621, DateTimeKind.Local).AddTicks(8993) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastYearMaintenance",
                value: new DateTime(2024, 9, 8, 20, 13, 4, 663, DateTimeKind.Local).AddTicks(641));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastYearMaintenance",
                value: new DateTime(2024, 11, 8, 20, 13, 4, 663, DateTimeKind.Local).AddTicks(650));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SuggestedDate",
                table: "Deliveries");

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
                value: "7ea73673-a4df-4a1e-8404-5337a110697a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27609f35-fbc8-4dc4-9d12-7ff2dd400327",
                column: "ConcurrencyStamp",
                value: "c59d1895-8138-45ea-aa05-b41c7a1ac94f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "350868c0-bf0f-4f70-b4c9-155351bc6429",
                column: "ConcurrencyStamp",
                value: "8e41fa78-b4b2-4c60-8ba2-22225a96e7a3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d000e64-c056-419a-950f-1992bd1e910d",
                column: "ConcurrencyStamp",
                value: "6cfec2a7-8639-4770-bf30-ae735d41e3c9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99027aaa-d346-4dd9-a467-15d74576c080",
                column: "ConcurrencyStamp",
                value: "edcc96f7-bbd5-4a4a-9d51-80e8017fb517");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20450cff-816f-49c8-9546-1c603aec0301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9be52c1b-6423-488a-846a-ef490539adb3", "AQAAAAEAACcQAAAAEIGiD+d0yfYcHdnWd6orWhSgwdZB+lNA4sxCvh8kPJktNtq6eaLxtqQjAxgTDSB6KQ==", "77c6ccfd-8e60-4755-aead-abf8cdd4d0f1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e8be95a-186e-403b-b4aa-3874750a3563",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "68558fcf-50b9-4471-890f-52b5052889f4", "AQAAAAEAACcQAAAAEGeVA1HVyezUIPdvcYLl3xUY6qsHPgCYz++rGLMFcBTqRz2gbK/caLsbx4RPCLvt/Q==", "7f87cc6e-e57b-498a-b179-e9b278667353" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38ba6810-2800-4ac8-b005-5c27e8248951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59a9df3f-adf9-45e7-bfa6-028cf4b68be0", "AQAAAAEAACcQAAAAENDKekVYVSA89vlZ8WmrxH2Z/T8Tetz6TCD1VV9P/aKmDh9iQ4AToj/Cx3DPLF44dg==", "ce805fe8-e992-4328-aca1-e362fcba3f2a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6bab54d5-5a88-4128-92d2-4d12ad0baa32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "419d2c4c-010d-4e27-acee-1cdf31ab5ba9", "AQAAAAEAACcQAAAAEASMP4jM6KTndr+sELwtqWUGA23YxdjiRJXLJyOvs0sJ1XLe4x7hq5BWu2kovEF1zQ==", "962a9d10-1ca9-48c7-956b-c7ff8d916994" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "driverUser1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8b6eedba-ed08-4c6c-b64d-2af5330a3c50", "AQAAAAEAACcQAAAAEN2MKjJTs0p5nTeSlIlKv85qiQdaf+4H0i4z1F4Wh7G3e28Ak/vqftjai1gg5X/ZxQ==", "406200ff-ef6b-49a0-a785-9550ea11709f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "driverUser2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "577ee4e7-b9d7-4027-af8c-bb19d4cc89b3", "7293a624-edc1-4e27-bffd-24eced306e0b" });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 11, 5, 12, 43, 19, 43, DateTimeKind.Local).AddTicks(6424));

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 9, 5, 12, 43, 19, 43, DateTimeKind.Local).AddTicks(6426));

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 6, 5, 12, 43, 19, 43, DateTimeKind.Local).AddTicks(6428));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 30, 12, 43, 18, 971, DateTimeKind.Local).AddTicks(6622));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateSubmitted",
                value: new DateTime(2024, 12, 1, 12, 43, 18, 971, DateTimeKind.Local).AddTicks(6624));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateSubmitted",
                value: new DateTime(2024, 12, 2, 12, 43, 18, 971, DateTimeKind.Local).AddTicks(6625));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateSubmitted",
                value: new DateTime(2024, 12, 3, 12, 43, 18, 971, DateTimeKind.Local).AddTicks(6627));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateSubmitted",
                value: new DateTime(2024, 12, 4, 12, 43, 18, 971, DateTimeKind.Local).AddTicks(6628));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateSubmitted",
                value: new DateTime(2024, 12, 5, 12, 43, 18, 971, DateTimeKind.Local).AddTicks(6630));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 15, 12, 43, 18, 977, DateTimeKind.Local).AddTicks(680));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 25, 12, 43, 18, 977, DateTimeKind.Local).AddTicks(691));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 1,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 12, 4, 12, 43, 19, 17, DateTimeKind.Local).AddTicks(6668));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 2,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 12, 3, 12, 43, 19, 17, DateTimeKind.Local).AddTicks(6671));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 3,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 12, 2, 12, 43, 19, 17, DateTimeKind.Local).AddTicks(6673));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 4,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 12, 1, 12, 43, 19, 17, DateTimeKind.Local).AddTicks(6675));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 5,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 30, 12, 43, 19, 17, DateTimeKind.Local).AddTicks(6677));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2024, 11, 30, 12, 43, 19, 28, DateTimeKind.Local).AddTicks(789));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2024, 12, 1, 12, 43, 19, 28, DateTimeKind.Local).AddTicks(791));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2024, 12, 2, 12, 43, 19, 28, DateTimeKind.Local).AddTicks(793));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 4,
                column: "Timestamp",
                value: new DateTime(2024, 12, 3, 12, 43, 19, 28, DateTimeKind.Local).AddTicks(794));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 5,
                column: "Timestamp",
                value: new DateTime(2024, 12, 4, 12, 43, 19, 28, DateTimeKind.Local).AddTicks(796));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1,
                column: "LicenseExpiryDate",
                value: new DateTime(2025, 12, 5, 12, 43, 19, 11, DateTimeKind.Local).AddTicks(3320));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 2,
                column: "LicenseExpiryDate",
                value: new DateTime(2025, 12, 5, 12, 43, 19, 11, DateTimeKind.Local).AddTicks(3324));

            migrationBuilder.UpdateData(
                table: "FuelPrices",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 12, 2, 12, 43, 19, 38, DateTimeKind.Local).AddTicks(3986));

            migrationBuilder.UpdateData(
                table: "FuelPrices",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 12, 3, 12, 43, 19, 38, DateTimeKind.Local).AddTicks(3987));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InvoiceDate", "PaidDate" },
                values: new object[] { new DateTime(2024, 11, 25, 12, 43, 18, 983, DateTimeKind.Local).AddTicks(2986), new DateTime(2024, 11, 30, 12, 43, 18, 983, DateTimeKind.Local).AddTicks(2985) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 2,
                column: "InvoiceDate",
                value: new DateTime(2024, 11, 26, 12, 43, 18, 983, DateTimeKind.Local).AddTicks(2988));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "InvoiceDate", "PaidDate" },
                values: new object[] { new DateTime(2024, 11, 27, 12, 43, 18, 983, DateTimeKind.Local).AddTicks(2991), new DateTime(2024, 11, 29, 12, 43, 18, 983, DateTimeKind.Local).AddTicks(2990) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 4,
                column: "InvoiceDate",
                value: new DateTime(2024, 11, 28, 12, 43, 18, 983, DateTimeKind.Local).AddTicks(2993));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 5,
                column: "InvoiceDate",
                value: new DateTime(2024, 11, 29, 12, 43, 18, 983, DateTimeKind.Local).AddTicks(2994));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 1,
                column: "OfferDate",
                value: new DateTime(2024, 11, 20, 12, 43, 18, 988, DateTimeKind.Local).AddTicks(5093));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 2,
                column: "OfferDate",
                value: new DateTime(2024, 11, 19, 12, 43, 18, 988, DateTimeKind.Local).AddTicks(5095));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 3,
                column: "OfferDate",
                value: new DateTime(2024, 11, 20, 12, 43, 18, 988, DateTimeKind.Local).AddTicks(5097));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 4,
                column: "OfferDate",
                value: new DateTime(2024, 11, 23, 12, 43, 18, 988, DateTimeKind.Local).AddTicks(5099));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 5,
                column: "OfferDate",
                value: new DateTime(2024, 11, 22, 12, 43, 18, 988, DateTimeKind.Local).AddTicks(5100));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 15, 12, 43, 18, 995, DateTimeKind.Local).AddTicks(6216), new DateTime(2024, 12, 12, 12, 43, 18, 995, DateTimeKind.Local).AddTicks(6214) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 14, 12, 43, 18, 995, DateTimeKind.Local).AddTicks(6221), new DateTime(2024, 12, 15, 12, 43, 18, 995, DateTimeKind.Local).AddTicks(6219) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 13, 12, 43, 18, 995, DateTimeKind.Local).AddTicks(6224), new DateTime(2024, 12, 10, 12, 43, 18, 995, DateTimeKind.Local).AddTicks(6223) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 12, 12, 43, 18, 995, DateTimeKind.Local).AddTicks(6227), new DateTime(2024, 12, 2, 12, 43, 18, 995, DateTimeKind.Local).AddTicks(6226) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 11, 12, 43, 18, 995, DateTimeKind.Local).AddTicks(6231), new DateTime(2024, 11, 30, 12, 43, 18, 995, DateTimeKind.Local).AddTicks(6230) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastYearMaintenance",
                value: new DateTime(2024, 9, 5, 12, 43, 19, 22, DateTimeKind.Local).AddTicks(8322));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastYearMaintenance",
                value: new DateTime(2024, 11, 5, 12, 43, 19, 22, DateTimeKind.Local).AddTicks(8325));
        }
    }
}

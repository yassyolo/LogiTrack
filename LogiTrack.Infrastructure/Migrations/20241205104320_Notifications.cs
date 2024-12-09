using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogiTrack.Infrastructure.Migrations
{
    public partial class Notifications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

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
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 10, 1, 20, 18, 985, DateTimeKind.Local).AddTicks(1142), new DateTime(2024, 12, 7, 1, 20, 18, 985, DateTimeKind.Local).AddTicks(1138) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 9, 1, 20, 18, 985, DateTimeKind.Local).AddTicks(1148), new DateTime(2024, 12, 10, 1, 20, 18, 985, DateTimeKind.Local).AddTicks(1147) });

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
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 7, 1, 20, 18, 985, DateTimeKind.Local).AddTicks(1182), new DateTime(2024, 11, 27, 1, 20, 18, 985, DateTimeKind.Local).AddTicks(1181) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 6, 1, 20, 18, 985, DateTimeKind.Local).AddTicks(1192), new DateTime(2024, 11, 25, 1, 20, 18, 985, DateTimeKind.Local).AddTicks(1190) });

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
        }
    }
}

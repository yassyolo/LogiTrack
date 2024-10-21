using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogiTrack.Infrastructure.Migrations
{
    public partial class ChagedToAccountantRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_ClientCompanies_ClientCompanyId",
                table: "Invoices");

            migrationBuilder.RenameColumn(
                name: "ClientCompanyId",
                table: "Invoices",
                newName: "ClientCompanyId1");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_ClientCompanyId",
                table: "Invoices",
                newName: "IX_Invoices_ClientCompanyId1");

            migrationBuilder.AddColumn<string>(
                name: "DeliveryAddress",
                table: "Requests",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                comment: "Delivery address");

            migrationBuilder.AddColumn<string>(
                name: "PickupAddress",
                table: "Requests",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                comment: "Pickup address");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20ddc22c-ca6d-4feb-a688-0f31a430b5eb",
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "57803dac-4585-45b3-82aa-de8c2f879a2b", "Accountant", "ACCOUNTANT" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27609f35-fbc8-4dc4-9d12-7ff2dd400327",
                column: "ConcurrencyStamp",
                value: "9d262c24-12f6-464f-b59c-3109f18c056b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d000e64-c056-419a-950f-1992bd1e910d",
                column: "ConcurrencyStamp",
                value: "80e213f9-f1b4-48f9-b237-f6458eae432c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99027aaa-d346-4dd9-a467-15d74576c080",
                column: "ConcurrencyStamp",
                value: "c70b4669-c658-41f9-86ae-6821a90a0b1e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20450cff-816f-49c8-9546-1c603aec0301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "121db358-287e-4300-aa60-d50e8bb537b3", "AQAAAAEAACcQAAAAEDiCWYD3B0sB9HDZbTxaELDb5pyeDMURkowBJ1eO4NngKeWgZs02UiIfcAmI3rLiJw==", "d647140f-0dce-405d-bd5a-d8cde495bfb1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e8be95a-186e-403b-b4aa-3874750a3563",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d05f20d5-5e21-41fd-9121-727188eb916f", "AQAAAAEAACcQAAAAEF0h/37KyauIOmHYpwx1lzS2AhBkhdR7lqXRXW3/ut569+BuFNbfhIp23kvaYrogxA==", "152dc5f3-b17d-4593-9df7-f7c4476b5cf9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38ba6810-2800-4ac8-b005-5c27e8248951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5e66d39c-62bf-40b8-9245-58addde3048d", "AQAAAAEAACcQAAAAENvBIEnFboTd2ClZP3XJLH+I0Gsryzl7J51tWQrM6Cn/vKJJVj2YQGL+86YOiqfrAw==", "31a9700d-081e-4486-9caf-80baf34745e2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6bab54d5-5a88-4128-92d2-4d12ad0baa32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7ac7d5c8-10a0-430f-ba9f-02b503100d31", "AQAAAAEAACcQAAAAEDffBG6yWjgnuzV2CMEHWJys0mtcMYpH0Xn9IHrRQ6Q+48aVcVUFdbyTN67MWC4D6g==", "f2c304af-faff-47d9-944d-6872fdf6fa01" });

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateSubmitted",
                value: new DateTime(2024, 10, 20, 12, 6, 9, 750, DateTimeKind.Utc).AddTicks(1798));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateSubmitted",
                value: new DateTime(2024, 10, 20, 12, 6, 9, 750, DateTimeKind.Utc).AddTicks(1800));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1,
                column: "LicenseExpiryDate",
                value: new DateTime(2026, 10, 20, 12, 6, 9, 772, DateTimeKind.Utc).AddTicks(1366));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 2,
                column: "LicenseExpiryDate",
                value: new DateTime(2027, 10, 20, 12, 6, 9, 772, DateTimeKind.Utc).AddTicks(1371));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                column: "InvoiceDate",
                value: new DateTime(2024, 10, 20, 12, 6, 10, 644, DateTimeKind.Utc).AddTicks(4055));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 1,
                column: "OfferDate",
                value: new DateTime(2024, 10, 19, 12, 6, 10, 652, DateTimeKind.Utc).AddTicks(94));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DeliveryAddress", "PickupAddress" },
                values: new object[] { new DateTime(2024, 10, 20, 15, 6, 10, 665, DateTimeKind.Local).AddTicks(5212), "", "" });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "DeliveryAddress", "PickupAddress" },
                values: new object[] { new DateTime(2024, 10, 20, 15, 6, 10, 665, DateTimeKind.Local).AddTicks(5431), "", "" });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "DeliveryAddress", "PickupAddress" },
                values: new object[] { new DateTime(2024, 10, 20, 15, 6, 10, 665, DateTimeKind.Local).AddTicks(5473), "", "" });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "DeliveryAddress", "PickupAddress" },
                values: new object[] { new DateTime(2024, 10, 20, 15, 6, 10, 665, DateTimeKind.Local).AddTicks(5487), "", "" });

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_ClientCompanies_ClientCompanyId1",
                table: "Invoices",
                column: "ClientCompanyId1",
                principalTable: "ClientCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_ClientCompanies_ClientCompanyId1",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "DeliveryAddress",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "PickupAddress",
                table: "Requests");

            migrationBuilder.RenameColumn(
                name: "ClientCompanyId1",
                table: "Invoices",
                newName: "ClientCompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_ClientCompanyId1",
                table: "Invoices",
                newName: "IX_Invoices_ClientCompanyId");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20ddc22c-ca6d-4feb-a688-0f31a430b5eb",
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8aaf4106-d583-41cd-9285-2a47846db3ac", "Secretary", "SECRETARY" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27609f35-fbc8-4dc4-9d12-7ff2dd400327",
                column: "ConcurrencyStamp",
                value: "7d916bbf-3d7f-49e3-84c0-aa2a75f891e2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d000e64-c056-419a-950f-1992bd1e910d",
                column: "ConcurrencyStamp",
                value: "23f95f88-97d1-4ed3-8052-ad57048e96fd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99027aaa-d346-4dd9-a467-15d74576c080",
                column: "ConcurrencyStamp",
                value: "236704ce-6621-4b54-aae6-f574623f8bc3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20450cff-816f-49c8-9546-1c603aec0301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3e130086-bfae-48dd-b607-d7510aa8a410", "AQAAAAEAACcQAAAAECmq19fivSMazXU9GwXZjFuoJve0O5ym7N99g9TPr0bLo4hSrhpyBCJOJz463ifUug==", "d14cd0e0-262e-42cb-9cd3-7cc43e34dbcd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e8be95a-186e-403b-b4aa-3874750a3563",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8470c424-392c-4e98-a5ee-1aa462ad5c40", "AQAAAAEAACcQAAAAEOo3173yDPtDoD2o1SpNlKDqgagL0KuoK5AGm1fsXPTc+A8O+FmHkdkyfMfPYUezng==", "6cda594f-dc0e-4bfb-a4b4-3202961a84fa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38ba6810-2800-4ac8-b005-5c27e8248951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3908c448-c10b-48dc-8435-1c73451d4012", "AQAAAAEAACcQAAAAEO+VsskGbpeYW5yHQGVU12S910ry+elfswx2cZyw/jLNYv7pkc7K35V1NHaqN7J2YA==", "8d7c6de5-d4d4-46e8-aa14-b21172099ecc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6bab54d5-5a88-4128-92d2-4d12ad0baa32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "28da5387-d989-4b0f-8fd9-47e76436482f", "AQAAAAEAACcQAAAAEMGz+de4nrpU8/qKS7xo5P9MJlCI6IAL1hZNHrhSW2hS/jDJhYqiZTE1D3ux/nVvuw==", "84ec99d5-3f4d-4b59-82a4-b26abe8d1c0a" });

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateSubmitted",
                value: new DateTime(2024, 10, 19, 11, 0, 51, 921, DateTimeKind.Utc).AddTicks(8692));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateSubmitted",
                value: new DateTime(2024, 10, 19, 11, 0, 51, 921, DateTimeKind.Utc).AddTicks(8694));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1,
                column: "LicenseExpiryDate",
                value: new DateTime(2026, 10, 19, 11, 0, 51, 936, DateTimeKind.Utc).AddTicks(8282));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 2,
                column: "LicenseExpiryDate",
                value: new DateTime(2027, 10, 19, 11, 0, 51, 936, DateTimeKind.Utc).AddTicks(8285));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                column: "InvoiceDate",
                value: new DateTime(2024, 10, 19, 11, 0, 52, 417, DateTimeKind.Utc).AddTicks(5454));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 1,
                column: "OfferDate",
                value: new DateTime(2024, 10, 18, 11, 0, 52, 421, DateTimeKind.Utc).AddTicks(5910));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 19, 14, 0, 52, 428, DateTimeKind.Local).AddTicks(6865));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 19, 14, 0, 52, 428, DateTimeKind.Local).AddTicks(6935));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 19, 14, 0, 52, 428, DateTimeKind.Local).AddTicks(6946));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 19, 14, 0, 52, 428, DateTimeKind.Local).AddTicks(6950));

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_ClientCompanies_ClientCompanyId",
                table: "Invoices",
                column: "ClientCompanyId",
                principalTable: "ClientCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogiTrack.Infrastructure.Migrations
{
    public partial class NonCargoGoodsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Offers_Id",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Length",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Volume",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "OfferId",
                table: "Invoices");

            migrationBuilder.AddColumn<int>(
                name: "DeliveryId",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Delivery identifier");

            migrationBuilder.AlterColumn<string>(
                name: "ReferenceNumber",
                table: "Deliveries",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                comment: "Delivery reference number",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Delivery reference number");

            migrationBuilder.AddColumn<DateTime>(
                name: "ActualDeliveryDate",
                table: "Deliveries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "Deliveries",
                type: "int",
                nullable: true,
                comment: "Invoice identifier");

            migrationBuilder.CreateTable(
                name: "NonStandardCargos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Non-standard cargo identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestId = table.Column<int>(type: "int", nullable: false, comment: "Request identifier"),
                    Length = table.Column<double>(type: "float", nullable: false, comment: "Length of the goods"),
                    Width = table.Column<double>(type: "float", nullable: false, comment: "Width of the goods"),
                    Height = table.Column<double>(type: "float", nullable: false, comment: "Height of the goods"),
                    Volume = table.Column<double>(type: "float", nullable: false, comment: "Volume of the goods"),
                    Weight = table.Column<double>(type: "float", nullable: false, comment: "Weight of the goods"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Description of the non-standard cargo")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NonStandardCargos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NonStandardCargos_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Non-Standard Cargo Entity");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20ddc22c-ca6d-4feb-a688-0f31a430b5eb",
                column: "ConcurrencyStamp",
                value: "194f8719-72eb-48e0-91dc-59e0a664a893");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27609f35-fbc8-4dc4-9d12-7ff2dd400327",
                column: "ConcurrencyStamp",
                value: "6eee4351-e1f0-4bd3-a21c-f4ecead4dc09");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d000e64-c056-419a-950f-1992bd1e910d",
                column: "ConcurrencyStamp",
                value: "eb1f32d0-4d9a-4999-a347-0481b81c4422");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99027aaa-d346-4dd9-a467-15d74576c080",
                column: "ConcurrencyStamp",
                value: "0c62085c-ea0d-4abe-9799-0cc1acbb3892");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20450cff-816f-49c8-9546-1c603aec0301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "312d702f-7677-476f-b0d4-f6fcb398d90e", "AQAAAAEAACcQAAAAEF+5uArE9Q3yN0dUYaRtHKPa0p/nX2bfKxjGj8QGadL0NY0T1R5zQShVkDy+9+iZiQ==", "78e13e0a-2832-4c92-8af3-dedcbd3f3093" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e8be95a-186e-403b-b4aa-3874750a3563",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "66729722-6c78-4e23-8fe8-36e2f3740466", "AQAAAAEAACcQAAAAEFPbtW/KNcXss72FwyinqpHbp4BH0L9VD0ObTZ96PvnbKgNMcJGv0770n6Vo+SwgsQ==", "2258fc05-ca51-492b-8287-5d425198c362" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38ba6810-2800-4ac8-b005-5c27e8248951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1a170280-4d10-494d-8e9c-1ae7beb4dc02", "AQAAAAEAACcQAAAAECc/01pjmLxMm9lsaVh5Zmj9FHzJUO9eAwk0Q9fJ3XvHpIIrybdXzKOYXPrsiCKTzQ==", "7489118c-8d6b-4bd0-a40d-7149209d9570" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6bab54d5-5a88-4128-92d2-4d12ad0baa32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7c4a8be0-87e0-4a06-a30c-7671b06ca1e0", "AQAAAAEAACcQAAAAEAa7HvrQHKJmGbTvPxJ3LlW9M3NA5YZRRe7Ua9rri+8xxVWJ1FkRtKw75w+hNJcgYg==", "3682aa95-cde8-4c2b-b0ee-6b46d6e16150" });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 10, 29, 18, 5, 43, 279, DateTimeKind.Utc).AddTicks(8603));

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 9, 18, 18, 5, 43, 279, DateTimeKind.Utc).AddTicks(8603));

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 10, 31, 18, 5, 43, 279, DateTimeKind.Utc).AddTicks(8603));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateSubmitted",
                value: new DateTime(2024, 10, 28, 18, 5, 42, 401, DateTimeKind.Utc).AddTicks(3971));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateSubmitted",
                value: new DateTime(2024, 10, 28, 18, 5, 42, 401, DateTimeKind.Utc).AddTicks(3973));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 8, 20, 5, 42, 405, DateTimeKind.Local).AddTicks(8648));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 18, 20, 5, 42, 405, DateTimeKind.Local).AddTicks(8662));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1,
                column: "LicenseExpiryDate",
                value: new DateTime(2026, 10, 28, 18, 5, 42, 416, DateTimeKind.Utc).AddTicks(1431));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 2,
                column: "LicenseExpiryDate",
                value: new DateTime(2027, 10, 28, 18, 5, 42, 416, DateTimeKind.Utc).AddTicks(1434));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DeliveryId", "InvoiceDate" },
                values: new object[] { 1, new DateTime(2024, 10, 28, 18, 5, 43, 255, DateTimeKind.Utc).AddTicks(3799) });

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 1,
                column: "OfferDate",
                value: new DateTime(2024, 10, 27, 18, 5, 43, 259, DateTimeKind.Utc).AddTicks(4489));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 28, 20, 5, 43, 267, DateTimeKind.Local).AddTicks(5172));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 28, 20, 5, 43, 267, DateTimeKind.Local).AddTicks(5210));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 28, 20, 5, 43, 267, DateTimeKind.Local).AddTicks(5226));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 28, 20, 5, 43, 267, DateTimeKind.Local).AddTicks(5230));

            migrationBuilder.CreateIndex(
                name: "IX_NonStandardCargos_RequestId",
                table: "NonStandardCargos",
                column: "RequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Deliveries_Id",
                table: "Invoices",
                column: "Id",
                principalTable: "Deliveries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Deliveries_Id",
                table: "Invoices");

            migrationBuilder.DropTable(
                name: "NonStandardCargos");

            migrationBuilder.DropColumn(
                name: "DeliveryId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "ActualDeliveryDate",
                table: "Deliveries");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "Deliveries");

            migrationBuilder.AddColumn<double>(
                name: "Height",
                table: "Requests",
                type: "float",
                nullable: true,
                comment: "Height of the goods");

            migrationBuilder.AddColumn<double>(
                name: "Length",
                table: "Requests",
                type: "float",
                nullable: true,
                comment: "Length of the goods");

            migrationBuilder.AddColumn<double>(
                name: "Volume",
                table: "Requests",
                type: "float",
                nullable: true,
                comment: "Volume of the goods");

            migrationBuilder.AddColumn<double>(
                name: "Weight",
                table: "Requests",
                type: "float",
                nullable: true,
                comment: "Weight of the goods");

            migrationBuilder.AddColumn<double>(
                name: "Width",
                table: "Requests",
                type: "float",
                nullable: true,
                comment: "Width of the goods");

            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "Offers",
                type: "int",
                nullable: true,
                comment: "Invoice identifier");

            migrationBuilder.AddColumn<int>(
                name: "OfferId",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Offer identifier");

            migrationBuilder.AlterColumn<string>(
                name: "ReferenceNumber",
                table: "Deliveries",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Delivery reference number",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldComment: "Delivery reference number");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20ddc22c-ca6d-4feb-a688-0f31a430b5eb",
                column: "ConcurrencyStamp",
                value: "5d515ac9-6b58-46d1-869a-fed627476247");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27609f35-fbc8-4dc4-9d12-7ff2dd400327",
                column: "ConcurrencyStamp",
                value: "e3288943-0420-4ec7-94dc-f1ec1be38ded");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d000e64-c056-419a-950f-1992bd1e910d",
                column: "ConcurrencyStamp",
                value: "5d84b561-c271-4f0d-8edb-6d468c89683b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99027aaa-d346-4dd9-a467-15d74576c080",
                column: "ConcurrencyStamp",
                value: "a4eba3d7-77cf-41f5-89fd-0bb5385660f4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20450cff-816f-49c8-9546-1c603aec0301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3648e640-00c2-40fa-9498-dd7f90966dd3", "AQAAAAEAACcQAAAAENDqBfjhuUw7Ash/tteeSDPV51UQ71Ou71QN5+AkA2RG6wbaRoJxhsS/PXBddHGyYg==", "1b7445e8-b7b5-40a2-aaf6-6ac1e301ce75" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e8be95a-186e-403b-b4aa-3874750a3563",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0f54a963-acfd-44e4-98a2-01910e4e0c57", "AQAAAAEAACcQAAAAEC3TVcYShlQCO9HOTRFo6cfN2gzDrrpFJ8ii8iT8lf++ghSKtfz+9fiYlzuMubi0xw==", "e8299ac3-b139-467e-860d-aedd90090573" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38ba6810-2800-4ac8-b005-5c27e8248951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b938a642-9a4c-4b2f-bd26-7c18e66a00bf", "AQAAAAEAACcQAAAAEJIa6BUl3cJfguNI4jMH2Pf1OC+quI14RqziJ8TwjbhWzJd1o8c/tYAYgjXtxqIrFA==", "2ef2e736-c279-42bc-bc14-2eae7cc6dbd7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6bab54d5-5a88-4128-92d2-4d12ad0baa32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d5694746-70ce-4d58-9906-00d236f74842", "AQAAAAEAACcQAAAAEFHPdvnb5nl3G8asrQGhPvV8XLKha8qhUf1U6RYerEmvvvHD4gT63JeuETfLdFi3hA==", "1cb8ab80-d38b-47e8-a63f-c4ea0b2af06b" });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 10, 27, 16, 8, 30, 788, DateTimeKind.Utc).AddTicks(8065));

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 9, 16, 16, 8, 30, 788, DateTimeKind.Utc).AddTicks(8065));

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 10, 29, 16, 8, 30, 788, DateTimeKind.Utc).AddTicks(8065));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateSubmitted",
                value: new DateTime(2024, 10, 26, 16, 8, 30, 185, DateTimeKind.Utc).AddTicks(8610));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateSubmitted",
                value: new DateTime(2024, 10, 26, 16, 8, 30, 185, DateTimeKind.Utc).AddTicks(8612));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 6, 19, 8, 30, 192, DateTimeKind.Local).AddTicks(8953));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 16, 19, 8, 30, 192, DateTimeKind.Local).AddTicks(8989));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1,
                column: "LicenseExpiryDate",
                value: new DateTime(2026, 10, 26, 16, 8, 30, 209, DateTimeKind.Utc).AddTicks(9589));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 2,
                column: "LicenseExpiryDate",
                value: new DateTime(2027, 10, 26, 16, 8, 30, 209, DateTimeKind.Utc).AddTicks(9598));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InvoiceDate", "OfferId" },
                values: new object[] { new DateTime(2024, 10, 26, 16, 8, 30, 748, DateTimeKind.Utc).AddTicks(6886), 1 });

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 1,
                column: "OfferDate",
                value: new DateTime(2024, 10, 25, 16, 8, 30, 755, DateTimeKind.Utc).AddTicks(2380));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 26, 19, 8, 30, 767, DateTimeKind.Local).AddTicks(7632));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 26, 19, 8, 30, 767, DateTimeKind.Local).AddTicks(7691));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 26, 19, 8, 30, 767, DateTimeKind.Local).AddTicks(7708));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 26, 19, 8, 30, 767, DateTimeKind.Local).AddTicks(7715));

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Offers_Id",
                table: "Invoices",
                column: "Id",
                principalTable: "Offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

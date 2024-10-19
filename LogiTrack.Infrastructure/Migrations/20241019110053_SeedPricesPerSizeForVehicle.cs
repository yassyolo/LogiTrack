using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogiTrack.Infrastructure.Migrations
{
    public partial class SeedPricesPerSizeForVehicle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanySize",
                table: "ClientCompanies");

            migrationBuilder.DropColumn(
                name: "VatNumber",
                table: "ClientCompanies");

            migrationBuilder.CreateTable(
                name: "PricesPerSize",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Prices per size identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(type: "int", nullable: false, comment: "Vehicle identifier"),
                    DomesticPriceForNotSharedTruck = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Domestic price for shared truck"),
                    DomesticPriceForSharedTruck = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Domestic price for shared truck"),
                    InternationalPriceForNotSharedTruck = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "International price for shared truck"),
                    InternationalPriceForSharedTruck = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "International price for shared truck")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PricesPerSize", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PricesPerSize_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Prices per size entity");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20ddc22c-ca6d-4feb-a688-0f31a430b5eb",
                column: "ConcurrencyStamp",
                value: "8aaf4106-d583-41cd-9285-2a47846db3ac");

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

            migrationBuilder.InsertData(
                table: "PricesPerSize",
                columns: new[] { "Id", "DomesticPriceForNotSharedTruck", "DomesticPriceForSharedTruck", "InternationalPriceForNotSharedTruck", "InternationalPriceForSharedTruck", "VehicleId" },
                values: new object[,]
                {
                    { 1, 500m, 300m, 1000m, 700m, 1 },
                    { 2, 550m, 320m, 1050m, 750m, 2 }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_PricesPerSize_VehicleId",
                table: "PricesPerSize",
                column: "VehicleId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PricesPerSize");

            migrationBuilder.AddColumn<string>(
                name: "CompanySize",
                table: "ClientCompanies",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                comment: "Company's size");

            migrationBuilder.AddColumn<string>(
                name: "VatNumber",
                table: "ClientCompanies",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: false,
                defaultValue: "",
                comment: "Company's vat number");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20ddc22c-ca6d-4feb-a688-0f31a430b5eb",
                column: "ConcurrencyStamp",
                value: "4b69ec24-4dc8-4cb0-97bf-c912c4a627c8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27609f35-fbc8-4dc4-9d12-7ff2dd400327",
                column: "ConcurrencyStamp",
                value: "2f6eb017-ef3e-4b1c-ab49-8cbb8d59af86");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d000e64-c056-419a-950f-1992bd1e910d",
                column: "ConcurrencyStamp",
                value: "398093c2-15a8-4282-94a8-8c93269131ac");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99027aaa-d346-4dd9-a467-15d74576c080",
                column: "ConcurrencyStamp",
                value: "e3ef4f83-ca6e-460a-bad7-f95b41acf3e2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20450cff-816f-49c8-9546-1c603aec0301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7ed4eb45-1fba-477b-a84c-e097f6542222", "AQAAAAEAACcQAAAAEIeWgS4FRlGaJIktGDbvoqT/5UxY37NVFTssJ6oLLq3QfoJOckar81bWYrgmeiBGhA==", "a096abd8-f984-4d3c-9e7f-ef7a981e3b46" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e8be95a-186e-403b-b4aa-3874750a3563",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c95e9cc0-9cc2-4470-991b-47bd4efe9942", "AQAAAAEAACcQAAAAEAUcl63CFFvvMCLIUL0s+i1Y1tGpC1r8OhQLUxKrCK+i/ZdOKaNxDRd0QgIZxQ2krg==", "96b72427-6121-4c08-90b0-527624d3d86b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38ba6810-2800-4ac8-b005-5c27e8248951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "46b006dd-bf9a-47b8-9d0d-e792a817b632", "AQAAAAEAACcQAAAAEK6jwLAml+Iza+HzShXoQB+WAKcg6P6z6now1OAVjeZHvxqIqSIDxcw9MjaM7ygZIA==", "63e5106b-9e72-48a2-ab1b-c2ea175634ee" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6bab54d5-5a88-4128-92d2-4d12ad0baa32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5abdcb8d-5885-4013-be05-394c82ef2b2a", "AQAAAAEAACcQAAAAEEE01UKz3R8FfZLMhrpqP70r5h81XnQnoa1CrfTJjJ9DKtcByqWj1FFSA4E5KtLEOQ==", "952f2971-deb2-4dd4-a30d-4c5c86905273" });

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateSubmitted",
                value: new DateTime(2024, 10, 19, 1, 10, 32, 327, DateTimeKind.Utc).AddTicks(6324));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateSubmitted",
                value: new DateTime(2024, 10, 19, 1, 10, 32, 327, DateTimeKind.Utc).AddTicks(6325));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CompanySize", "VatNumber" },
                values: new object[] { "Medium", "VAT123456" });

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CompanySize", "VatNumber" },
                values: new object[] { "Large", "VAT654321" });

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1,
                column: "LicenseExpiryDate",
                value: new DateTime(2026, 10, 19, 1, 10, 32, 342, DateTimeKind.Utc).AddTicks(7910));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 2,
                column: "LicenseExpiryDate",
                value: new DateTime(2027, 10, 19, 1, 10, 32, 342, DateTimeKind.Utc).AddTicks(7913));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                column: "InvoiceDate",
                value: new DateTime(2024, 10, 19, 1, 10, 32, 348, DateTimeKind.Utc).AddTicks(6835));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 1,
                column: "OfferDate",
                value: new DateTime(2024, 10, 18, 1, 10, 32, 353, DateTimeKind.Utc).AddTicks(1524));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 19, 4, 10, 33, 295, DateTimeKind.Local).AddTicks(5667));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 19, 4, 10, 33, 295, DateTimeKind.Local).AddTicks(5803));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 19, 4, 10, 33, 295, DateTimeKind.Local).AddTicks(5812));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 19, 4, 10, 33, 295, DateTimeKind.Local).AddTicks(5820));
        }
    }
}

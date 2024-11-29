using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogiTrack.Infrastructure.Migrations
{
    public partial class ReservedForDelivery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DomesticPriceForNotSharedTruck",
                table: "PricesPerSize");

            migrationBuilder.DropColumn(
                name: "DomesticPriceForSharedTruck",
                table: "PricesPerSize");

            migrationBuilder.DropColumn(
                name: "InternationalPriceForNotSharedTruck",
                table: "PricesPerSize");

            migrationBuilder.DropColumn(
                name: "InternationalPriceForSharedTruck",
                table: "PricesPerSize");

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Vehicles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "ReservedForDeliveries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    OfferId = table.Column<int>(type: "int", nullable: false),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservedForDeliveries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservedForDeliveries_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservedForDeliveries_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservedForDeliveries_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservedForDeliveries_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ReservedForDeliveries_DriverId",
                table: "ReservedForDeliveries",
                column: "DriverId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReservedForDeliveries_OfferId",
                table: "ReservedForDeliveries",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservedForDeliveries_RequestId",
                table: "ReservedForDeliveries",
                column: "RequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReservedForDeliveries_VehicleId",
                table: "ReservedForDeliveries",
                column: "VehicleId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservedForDeliveries");

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Vehicles");

            migrationBuilder.AddColumn<decimal>(
                name: "DomesticPriceForNotSharedTruck",
                table: "PricesPerSize",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                comment: "Domestic price for shared truck");

            migrationBuilder.AddColumn<decimal>(
                name: "DomesticPriceForSharedTruck",
                table: "PricesPerSize",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                comment: "Domestic price for shared truck");

            migrationBuilder.AddColumn<decimal>(
                name: "InternationalPriceForNotSharedTruck",
                table: "PricesPerSize",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                comment: "International price for shared truck");

            migrationBuilder.AddColumn<decimal>(
                name: "InternationalPriceForSharedTruck",
                table: "PricesPerSize",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                comment: "International price for shared truck");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20ddc22c-ca6d-4feb-a688-0f31a430b5eb",
                column: "ConcurrencyStamp",
                value: "b4364b68-1c49-4397-a2f7-f274eaa92f82");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27609f35-fbc8-4dc4-9d12-7ff2dd400327",
                column: "ConcurrencyStamp",
                value: "e9d53cfe-0e28-4920-8c53-41df50e6d9c9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "350868c0-bf0f-4f70-b4c9-155351bc6429",
                column: "ConcurrencyStamp",
                value: "6f390d81-c448-45d2-9ad9-21ef5464ccc2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d000e64-c056-419a-950f-1992bd1e910d",
                column: "ConcurrencyStamp",
                value: "6903f1bf-c43d-4ec2-9106-3854c4c02a92");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99027aaa-d346-4dd9-a467-15d74576c080",
                column: "ConcurrencyStamp",
                value: "82a989cc-78ef-45b4-a5be-2a7700b5b939");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20450cff-816f-49c8-9546-1c603aec0301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f844bd81-5743-4c98-9da1-ef6c3367993e", "AQAAAAEAACcQAAAAEHXGi5xWdwNDVmHTiRD1j5R5BG1zJkakwO8z8yykIiLYYglPzTjRzSNTOsQuEnbIMQ==", "4bd291cc-dc16-42fa-8dd7-73aa47ccdd66" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e8be95a-186e-403b-b4aa-3874750a3563",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "02c06319-c9b9-409d-8162-33051924081b", "AQAAAAEAACcQAAAAEPulVECI/xbZsKF4rsb1nW58cUnkCoM4xXN/sYxUNUDzIPg6cFTjti/DCX/J8g8NCQ==", "f3957724-0bf0-42cf-bd9c-3ff3b9ca0eaf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38ba6810-2800-4ac8-b005-5c27e8248951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1104599f-329a-4478-ba66-df0b909651c7", "AQAAAAEAACcQAAAAEJSRODrMUrEqI1mfhwarMuPN9wK6+5p49lAd+z4q3BGGz1ZX+xRN/uNZ1A4CHkNaXw==", "9e533e27-e656-4726-83e1-5335da3e636c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6bab54d5-5a88-4128-92d2-4d12ad0baa32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "811cd568-2602-42bb-97c8-94ec102d9108", "AQAAAAEAACcQAAAAEOrmziUIsoN2rqe8zWL9UdpPO3NKAop24WhjncUy3taEAtCkhTuIZLYuapI2/kd0uw==", "d6609110-7c13-48d1-8f17-6e5d5c357b43" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "driverUser1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5b8571b4-ce92-41d3-85f2-7d13ce4d623d", "AQAAAAEAACcQAAAAEBZl4mIAc83agWCQC7wKbbTLfeGQkeznrc0LpMiE1SYARhe37nEbtucJ3a/BiRVEQQ==", "f5052cbc-45de-4b80-9592-4ff7731e6b1f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "driverUser2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "cba913d6-441d-4ee0-8c21-34c0d7aef9cd", "d6767349-7670-48b5-9e1e-188e1534be5f" });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 10, 26, 12, 42, 51, 950, DateTimeKind.Local).AddTicks(7449));

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 8, 26, 12, 42, 51, 950, DateTimeKind.Local).AddTicks(7451));

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 5, 26, 12, 42, 51, 950, DateTimeKind.Local).AddTicks(7453));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 21, 12, 42, 50, 406, DateTimeKind.Local).AddTicks(7479));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 22, 12, 42, 50, 406, DateTimeKind.Local).AddTicks(7482));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 23, 12, 42, 50, 406, DateTimeKind.Local).AddTicks(7483));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 24, 12, 42, 50, 406, DateTimeKind.Local).AddTicks(7485));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 25, 12, 42, 50, 406, DateTimeKind.Local).AddTicks(7487));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateSubmitted",
                value: new DateTime(2024, 11, 26, 12, 42, 50, 406, DateTimeKind.Local).AddTicks(7489));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 6, 12, 42, 50, 412, DateTimeKind.Local).AddTicks(9185));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 11, 16, 12, 42, 50, 412, DateTimeKind.Local).AddTicks(9214));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 1,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 25, 12, 42, 51, 921, DateTimeKind.Local).AddTicks(2475));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 2,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 24, 12, 42, 51, 921, DateTimeKind.Local).AddTicks(2488));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 3,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 23, 12, 42, 51, 921, DateTimeKind.Local).AddTicks(2504));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 4,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 22, 12, 42, 51, 921, DateTimeKind.Local).AddTicks(2506));

            migrationBuilder.UpdateData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 5,
                column: "ActualDeliveryDate",
                value: new DateTime(2024, 11, 21, 12, 42, 51, 921, DateTimeKind.Local).AddTicks(2508));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2024, 11, 21, 12, 42, 51, 933, DateTimeKind.Local).AddTicks(145));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2024, 11, 22, 12, 42, 51, 933, DateTimeKind.Local).AddTicks(147));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2024, 11, 23, 12, 42, 51, 933, DateTimeKind.Local).AddTicks(149));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 4,
                column: "Timestamp",
                value: new DateTime(2024, 11, 24, 12, 42, 51, 933, DateTimeKind.Local).AddTicks(150));

            migrationBuilder.UpdateData(
                table: "DeliveryTrackings",
                keyColumn: "Id",
                keyValue: 5,
                column: "Timestamp",
                value: new DateTime(2024, 11, 25, 12, 42, 51, 933, DateTimeKind.Local).AddTicks(152));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1,
                column: "LicenseExpiryDate",
                value: new DateTime(2025, 11, 26, 12, 42, 51, 112, DateTimeKind.Local).AddTicks(2622));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 2,
                column: "LicenseExpiryDate",
                value: new DateTime(2025, 11, 26, 12, 42, 51, 112, DateTimeKind.Local).AddTicks(2626));

            migrationBuilder.UpdateData(
                table: "FuelPrices",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 11, 23, 12, 42, 51, 944, DateTimeKind.Local).AddTicks(8129));

            migrationBuilder.UpdateData(
                table: "FuelPrices",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 11, 24, 12, 42, 51, 944, DateTimeKind.Local).AddTicks(8130));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InvoiceDate", "PaidDate" },
                values: new object[] { new DateTime(2024, 11, 16, 12, 42, 50, 420, DateTimeKind.Local).AddTicks(9306), new DateTime(2024, 11, 21, 12, 42, 50, 420, DateTimeKind.Local).AddTicks(9304) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 2,
                column: "InvoiceDate",
                value: new DateTime(2024, 11, 17, 12, 42, 50, 420, DateTimeKind.Local).AddTicks(9309));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "InvoiceDate", "PaidDate" },
                values: new object[] { new DateTime(2024, 11, 18, 12, 42, 50, 420, DateTimeKind.Local).AddTicks(9312), new DateTime(2024, 11, 20, 12, 42, 50, 420, DateTimeKind.Local).AddTicks(9311) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 4,
                column: "InvoiceDate",
                value: new DateTime(2024, 11, 19, 12, 42, 50, 420, DateTimeKind.Local).AddTicks(9314));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 5,
                column: "InvoiceDate",
                value: new DateTime(2024, 11, 20, 12, 42, 50, 420, DateTimeKind.Local).AddTicks(9316));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 1,
                column: "OfferDate",
                value: new DateTime(2024, 11, 11, 12, 42, 50, 426, DateTimeKind.Local).AddTicks(7537));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 2,
                column: "OfferDate",
                value: new DateTime(2024, 11, 10, 12, 42, 50, 426, DateTimeKind.Local).AddTicks(7539));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 3,
                column: "OfferDate",
                value: new DateTime(2024, 11, 11, 12, 42, 50, 426, DateTimeKind.Local).AddTicks(7540));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 4,
                column: "OfferDate",
                value: new DateTime(2024, 11, 14, 12, 42, 50, 426, DateTimeKind.Local).AddTicks(7542));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 5,
                column: "OfferDate",
                value: new DateTime(2024, 11, 13, 12, 42, 50, 426, DateTimeKind.Local).AddTicks(7543));

            migrationBuilder.UpdateData(
                table: "PricesPerSize",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DomesticPriceForNotSharedTruck", "DomesticPriceForSharedTruck", "InternationalPriceForNotSharedTruck", "InternationalPriceForSharedTruck" },
                values: new object[] { 1000.0m, 800.0m, 1500.0m, 1200.0m });

            migrationBuilder.UpdateData(
                table: "PricesPerSize",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DomesticPriceForNotSharedTruck", "DomesticPriceForSharedTruck", "InternationalPriceForNotSharedTruck", "InternationalPriceForSharedTruck" },
                values: new object[] { 1100.0m, 850.0m, 1600.0m, 1300.0m });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 6, 12, 42, 51, 92, DateTimeKind.Local).AddTicks(2983), new DateTime(2024, 12, 3, 12, 42, 51, 92, DateTimeKind.Local).AddTicks(2979) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 5, 12, 42, 51, 92, DateTimeKind.Local).AddTicks(2988), new DateTime(2024, 12, 6, 12, 42, 51, 92, DateTimeKind.Local).AddTicks(2987) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 4, 12, 42, 51, 92, DateTimeKind.Local).AddTicks(2999), new DateTime(2024, 12, 1, 12, 42, 51, 92, DateTimeKind.Local).AddTicks(2997) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 3, 12, 42, 51, 92, DateTimeKind.Local).AddTicks(3010), new DateTime(2024, 11, 23, 12, 42, 51, 92, DateTimeKind.Local).AddTicks(3008) });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ExpectedDeliveryDate" },
                values: new object[] { new DateTime(2024, 11, 2, 12, 42, 51, 92, DateTimeKind.Local).AddTicks(3017), new DateTime(2024, 11, 21, 12, 42, 51, 92, DateTimeKind.Local).AddTicks(3015) });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastYearMaintenance",
                value: new DateTime(2024, 8, 26, 12, 42, 51, 927, DateTimeKind.Local).AddTicks(1172));

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastYearMaintenance",
                value: new DateTime(2024, 10, 26, 12, 42, 51, 927, DateTimeKind.Local).AddTicks(1176));
        }
    }
}

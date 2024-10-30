using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogiTrack.Infrastructure.Migrations
{
    public partial class SeparatedStandartCargoFromRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Deliveries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "NumberOfPallets",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "PalletHeight",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "PalletLength",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "PalletVolume",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "PalletWidth",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "PalletsAreStackable",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "TypeOfPallet",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "WeightOfPallets",
                table: "Requests");

            migrationBuilder.AddColumn<int>(
                name: "StandartCargoId",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Standart cargo identifier");

            migrationBuilder.AddColumn<double>(
                name: "TotalVolume",
                table: "Requests",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalWeight",
                table: "Requests",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "FileId",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "File identifier in Google drive");

            migrationBuilder.CreateTable(
                name: "StandartCargos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Standard cargo identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestId = table.Column<int>(type: "int", nullable: false, comment: "Request identifier"),
                    TypeOfPallet = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "Type of pallet"),
                    NumberOfPallets = table.Column<int>(type: "int", nullable: true, comment: "Number of pallets"),
                    PalletLength = table.Column<double>(type: "float", nullable: true, comment: "Pallet length"),
                    PalletWidth = table.Column<double>(type: "float", nullable: true, comment: "Pallet width"),
                    PalletHeight = table.Column<double>(type: "float", nullable: true, comment: "Pallet height"),
                    PalletVolume = table.Column<double>(type: "float", nullable: true, comment: "Pallet volume"),
                    WeightOfPallets = table.Column<double>(type: "float", nullable: true, comment: "Weight of pallets"),
                    PalletsAreStackable = table.Column<bool>(type: "bit", nullable: true, comment: "Are the pallets stackable")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandartCargos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StandartCargos_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Standart Cargo Entity");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20ddc22c-ca6d-4feb-a688-0f31a430b5eb",
                column: "ConcurrencyStamp",
                value: "44d2d16c-e0be-4d85-9df6-de96f39ed850");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27609f35-fbc8-4dc4-9d12-7ff2dd400327",
                column: "ConcurrencyStamp",
                value: "598cc835-300b-43a5-81bd-9241362f80b5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d000e64-c056-419a-950f-1992bd1e910d",
                column: "ConcurrencyStamp",
                value: "0a6174bf-2f5f-433e-a5b0-c02d207a6892");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99027aaa-d346-4dd9-a467-15d74576c080",
                column: "ConcurrencyStamp",
                value: "53bd6605-4f49-46cf-bd0d-5fbfb0a17057");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20450cff-816f-49c8-9546-1c603aec0301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ed2ac369-c162-40d5-a5cf-2d229eeb4f96", "AQAAAAEAACcQAAAAEIY8JEyXZMHDDE1goQzGkDFLu4xMZXNVxTuE+CvGmehb83Wux0zAY8Ab10LSmnwHCw==", "4a72e924-f087-4b81-9e14-884517db9cae" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e8be95a-186e-403b-b4aa-3874750a3563",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a71f9d4e-87dc-44d6-8111-b5743741423f", "AQAAAAEAACcQAAAAEKgEREBuqz+wpphl6NS6NE+qv4NYfBDl2FrRyxvh+tDcgSn1Z2wkuyGO6eyYBBKi0w==", "1a8e72a5-9fbd-4753-b880-e07b1150b07e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38ba6810-2800-4ac8-b005-5c27e8248951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3d4d46a7-552c-4bc6-8542-28e863eaccab", "AQAAAAEAACcQAAAAEOVVJaaEx7cnM4OHB7OlVe2KwTdlKT64mmIZ6esgLYsnYEdFOIGaDJrmybZ5qbxRAQ==", "20bd2f96-9a71-41d6-b58f-798d9bf5ac24" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6bab54d5-5a88-4128-92d2-4d12ad0baa32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "129547b1-57fa-462e-bdd6-029cc5a489aa", "AQAAAAEAACcQAAAAEDtKooZJYB5dhjUJ7b5iI62Jx1vNkvpZw6duSpuk6g3yi8AtS1N7+LKLvzA48ffJOg==", "e4fd26d4-81b9-46a2-a690-9cc4df5da9c9" });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 10, 31, 17, 4, 40, 597, DateTimeKind.Utc).AddTicks(3041));

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 9, 20, 17, 4, 40, 597, DateTimeKind.Utc).AddTicks(3041));

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 11, 2, 17, 4, 40, 597, DateTimeKind.Utc).AddTicks(3041));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 10, 19, 4, 39, 388, DateTimeKind.Local).AddTicks(1972));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 20, 19, 4, 39, 388, DateTimeKind.Local).AddTicks(2026));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1,
                column: "LicenseExpiryDate",
                value: new DateTime(2026, 10, 30, 17, 4, 39, 395, DateTimeKind.Utc).AddTicks(578));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 2,
                column: "LicenseExpiryDate",
                value: new DateTime(2027, 10, 30, 17, 4, 39, 395, DateTimeKind.Utc).AddTicks(583));

            migrationBuilder.CreateIndex(
                name: "IX_StandartCargos_RequestId",
                table: "StandartCargos",
                column: "RequestId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StandartCargos");

            migrationBuilder.DropColumn(
                name: "StandartCargoId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "TotalVolume",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "TotalWeight",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "FileId",
                table: "Invoices");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfPallets",
                table: "Requests",
                type: "int",
                nullable: true,
                comment: "Number of pallets");

            migrationBuilder.AddColumn<double>(
                name: "PalletHeight",
                table: "Requests",
                type: "float",
                nullable: true,
                comment: "Pallet height");

            migrationBuilder.AddColumn<double>(
                name: "PalletLength",
                table: "Requests",
                type: "float",
                nullable: true,
                comment: "Pallet length");

            migrationBuilder.AddColumn<double>(
                name: "PalletVolume",
                table: "Requests",
                type: "float",
                nullable: true,
                comment: "Pallet volume");

            migrationBuilder.AddColumn<double>(
                name: "PalletWidth",
                table: "Requests",
                type: "float",
                nullable: true,
                comment: "Pallet width");

            migrationBuilder.AddColumn<bool>(
                name: "PalletsAreStackable",
                table: "Requests",
                type: "bit",
                nullable: true,
                comment: "Are the pallets stackable");

            migrationBuilder.AddColumn<string>(
                name: "TypeOfPallet",
                table: "Requests",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                comment: "Type of pallet");

            migrationBuilder.AddColumn<double>(
                name: "WeightOfPallets",
                table: "Requests",
                type: "float",
                nullable: true,
                comment: "Weight of pallets");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20ddc22c-ca6d-4feb-a688-0f31a430b5eb",
                column: "ConcurrencyStamp",
                value: "1d3565c3-dd93-4c4e-8b87-9303aff46c67");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27609f35-fbc8-4dc4-9d12-7ff2dd400327",
                column: "ConcurrencyStamp",
                value: "c13f70ca-8aea-425a-a87e-c4fc1bbdc8df");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d000e64-c056-419a-950f-1992bd1e910d",
                column: "ConcurrencyStamp",
                value: "54ace769-96a9-4304-9f9d-b49bd6210e63");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99027aaa-d346-4dd9-a467-15d74576c080",
                column: "ConcurrencyStamp",
                value: "03f54612-8476-4d9d-bf2a-9a9385855be1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20450cff-816f-49c8-9546-1c603aec0301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0cfbc946-4621-45dd-a382-4dc435732ed4", "AQAAAAEAACcQAAAAEP6P2C0lqbBONCjPszmJ+kf3uRS+/+hzRGzqMUDv+nZIgBqOcc8NRxaKRW1LGeOssQ==", "016d40e5-a35c-4c31-8f89-cac331b0bd79" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e8be95a-186e-403b-b4aa-3874750a3563",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "24bdd70b-cb16-46d5-a051-2046b255586c", "AQAAAAEAACcQAAAAEE24clqkfhgKAVoF1ivREzZzciFWX74bdcdtuCaO+1d5fAnAZNsT/YzfRNixVO8G0w==", "ad429cb2-6801-43a7-ad8c-03e173aa41f3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38ba6810-2800-4ac8-b005-5c27e8248951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9d70c4a3-85d5-432b-b1f6-a0649ae30b68", "AQAAAAEAACcQAAAAEFWocQnoIoFkHAxWWTH19h7yIKG3zGEl3OLwO3WAHQxcGidzaJFyVsNQphA9PHzBRQ==", "44fd96b1-621f-4a64-9176-4cf2152ca303" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6bab54d5-5a88-4128-92d2-4d12ad0baa32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d1548524-4f3c-4517-babe-aba25f2fe155", "AQAAAAEAACcQAAAAENS0RSGHgpfiH0ZdGeWyo9xABqj6gXXwaF7BmAgqGEXdfQxCIhQM16X3lJZuUSRH8w==", "c2f6be4d-a986-457a-ab15-123fa484d7e2" });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 10, 30, 10, 26, 56, 584, DateTimeKind.Utc).AddTicks(5955));

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 9, 19, 10, 26, 56, 584, DateTimeKind.Utc).AddTicks(5955));

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 11, 1, 10, 26, 56, 584, DateTimeKind.Utc).AddTicks(5955));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 9, 12, 26, 56, 39, DateTimeKind.Local).AddTicks(5207));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 19, 12, 26, 56, 39, DateTimeKind.Local).AddTicks(5250));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1,
                column: "LicenseExpiryDate",
                value: new DateTime(2026, 10, 29, 10, 26, 56, 55, DateTimeKind.Utc).AddTicks(4395));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 2,
                column: "LicenseExpiryDate",
                value: new DateTime(2027, 10, 29, 10, 26, 56, 55, DateTimeKind.Utc).AddTicks(4400));

            migrationBuilder.InsertData(
                table: "Requests",
                columns: new[] { "Id", "ApproximatePrice", "CalculatedPrice", "CargoType", "ClientCompanyId", "CreatedAt", "DeliveryAddress", "DeliveryLatitude", "DeliveryLongitude", "ExpectedDeliveryDate", "IsRefrigerated", "Kilometers", "NumberOfNonStandartGoods", "NumberOfPallets", "OfferId", "PalletHeight", "PalletLength", "PalletVolume", "PalletWidth", "PalletsAreStackable", "PickupAddress", "PickupLatitude", "PickupLongitude", "SharedTruck", "SpecialInstructions", "Status", "Type", "TypeOfGoods", "TypeOfPallet", "WeightOfPallets" },
                values: new object[,]
                {
                    { 1, 2000.00m, 2100.00m, "Standard", 1, new DateTime(2024, 10, 29, 12, 26, 56, 564, DateTimeKind.Local).AddTicks(6086), "", 48.8566, 2.3521999999999998, new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 0.0, null, 10, null, 144.0, 120.0, 1.3824000000000001, 80.0, true, "", 42.681199999999997, 26.3187, false, "Handle with care", "Approved", "International", "Electronics", "Euro", 500.0 },
                    { 2, 1500.00m, 1550.00m, "Standard", 1, new DateTime(2024, 10, 29, 12, 26, 56, 564, DateTimeKind.Local).AddTicks(6167), "", 42.697699999999998, 23.321899999999999, new DateTime(2024, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 0.0, null, 15, null, 160.0, 120.0, 1.536, 80.0, true, "", 42.681199999999997, 26.3187, false, "Keep refrigerated", "pending", "Domestic", "Food Products", "Euro", 750.0 },
                    { 3, 1800.00m, 1850.00m, "Standard", 1, new DateTime(2024, 10, 29, 12, 26, 56, 564, DateTimeKind.Local).AddTicks(6258), "", 48.208199999999998, 16.373799999999999, new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0.0, null, 8, null, 150.0, 120.0, 1.8, 100.0, false, "", 42.681199999999997, 26.3187, true, "Use soft padding", "Pending", "International", "Furniture", "Industrial", 400.0 },
                    { 4, 1700.00m, 1750.00m, "Standard", 1, new DateTime(2024, 10, 29, 12, 26, 56, 564, DateTimeKind.Local).AddTicks(6266), "", 43.835599999999999, 25.965699999999998, new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0.0, null, 12, null, 130.0, 120.0, 1.5600000000000001, 100.0, true, "", 42.681199999999997, 26.3187, true, "Avoid moisture", "Pending", "Domestic", "Machinery Parts", "Industrial", 600.0 }
                });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "ClientCompanyId", "DeliveryId", "FinalPrice", "Notes", "OfferDate", "OfferStatus", "RequestId" },
                values: new object[] { 1, null, null, 4800m, "Confirmed by client", new DateTime(2024, 10, 28, 10, 26, 56, 552, DateTimeKind.Utc).AddTicks(2306), "Accepted", 1 });

            migrationBuilder.InsertData(
                table: "Deliveries",
                columns: new[] { "Id", "ActualDeliveryDate", "DeliveryStep", "DriverId", "InvoiceId", "OfferId", "Profit", "ReferenceNumber", "Status", "TotalExpenses", "VehicleId" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 1, null, 1, 4300m, "REF-2024-0001", "In Progress", 500m, 1 });

            migrationBuilder.InsertData(
                table: "CashRegisters",
                columns: new[] { "Id", "Amount", "DateSubmitted", "DeliveryId", "Description", "FileId", "Type" },
                values: new object[] { 1, 200m, new DateTime(2024, 10, 29, 10, 26, 56, 31, DateTimeKind.Utc).AddTicks(8711), 1, "Fuel cost", "", "Expense" });

            migrationBuilder.InsertData(
                table: "CashRegisters",
                columns: new[] { "Id", "Amount", "DateSubmitted", "DeliveryId", "Description", "FileId", "Type" },
                values: new object[] { 2, 50m, new DateTime(2024, 10, 29, 10, 26, 56, 31, DateTimeKind.Utc).AddTicks(8714), 1, "Toll fee", "", "Expense" });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "ClientCompanyId1", "DeliveryId", "Description", "InvoiceDate", "InvoiceNumber", "IsPaid" },
                values: new object[] { 1, null, 1, "", new DateTime(2024, 10, 29, 10, 26, 56, 544, DateTimeKind.Utc).AddTicks(4373), "INV-2024-0001", false });
        }
    }
}

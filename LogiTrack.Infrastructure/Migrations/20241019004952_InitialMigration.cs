using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogiTrack.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Vehicle identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false, comment: "Vehicle registration number"),
                    VehicleType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Vehicle type"),
                    Length = table.Column<double>(type: "float", nullable: false, comment: "Vehicle length"),
                    Width = table.Column<double>(type: "float", nullable: false, comment: "Vehicle width"),
                    Height = table.Column<double>(type: "float", nullable: false, comment: "Vehicle height"),
                    Volume = table.Column<double>(type: "float", nullable: false, comment: "Vehicle volume"),
                    EuroPalletCapacity = table.Column<int>(type: "int", nullable: false, comment: "Euro pallets capacity"),
                    IndustrialPalletCapacity = table.Column<int>(type: "int", nullable: false, comment: "Industrial pallets capacity"),
                    ArePalletsStackable = table.Column<bool>(type: "bit", nullable: false, comment: "Are the pallets stackable"),
                    MaxWeightCapacity = table.Column<double>(type: "float", nullable: false, comment: "Max weight capacity"),
                    FuelConsumptionPer100Km = table.Column<double>(type: "float", nullable: false, comment: "Fuel consumption per 100 km"),
                    VehicleStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Vehicle status"),
                    MaintenanceDue = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Maintenance due date")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                },
                comment: "Vehicle Entity");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientCompanies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true, comment: "User identifier"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Company Name"),
                    RegistrationStatus = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Company's registration status"),
                    ContactPerson = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Person whom we are contacting"),
                    AlternativePhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "Company's alternative phone number"),
                    VatNumber = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false, comment: "Company's vat number"),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false, comment: "Company's registration number"),
                    Industry = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Company's industry"),
                    CompanySize = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Company's size"),
                    Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Company's address"),
                    City = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false, comment: "Company's city"),
                    PostalCode = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false, comment: "Company's postal code"),
                    Country = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false, comment: "Company's country")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientCompanies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientCompanies_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Client Company Entity");

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Driver identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Driver's name"),
                    LicenseNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "Driver's license number"),
                    LicenseExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Driver's license expiry date"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User identifier"),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Driver's salary"),
                    Age = table.Column<int>(type: "int", nullable: false, comment: "Driver's age"),
                    YearOfExperience = table.Column<int>(type: "int", nullable: false, comment: "Driver's year of experience"),
                    MonthsOfExperience = table.Column<int>(type: "int", nullable: false, comment: "Driver's months of experience"),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false, comment: "Is driver available"),
                    Preferrences = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true, comment: "Driver's preferrences")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drivers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Driver Entity");

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Request identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientCompanyId = table.Column<int>(type: "int", nullable: false, comment: "Client Company identifier"),
                    CargoType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Cargo type"),
                    TypeOfPallet = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "Type of pallet"),
                    NumberOfPallets = table.Column<int>(type: "int", nullable: true, comment: "Number of pallets"),
                    PalletLength = table.Column<double>(type: "float", nullable: true, comment: "Pallet length"),
                    PalletWidth = table.Column<double>(type: "float", nullable: true, comment: "Pallet width"),
                    PalletHeight = table.Column<double>(type: "float", nullable: true, comment: "Pallet height"),
                    PalletVolume = table.Column<double>(type: "float", nullable: true, comment: "Pallet volume"),
                    WeightOfPallets = table.Column<double>(type: "float", nullable: true, comment: "Weight of pallets"),
                    PalletsAreStackable = table.Column<bool>(type: "bit", nullable: true, comment: "Are the pallets stackable"),
                    NumberOfNonStandartGoods = table.Column<int>(type: "int", nullable: true, comment: "Number of non-standart goods"),
                    Length = table.Column<int>(type: "int", nullable: true, comment: "Length of the goods"),
                    Width = table.Column<int>(type: "int", nullable: true, comment: "Width of the goods"),
                    Height = table.Column<int>(type: "int", nullable: true, comment: "Height of the goods"),
                    Volume = table.Column<double>(type: "float", nullable: true, comment: "Volume of the goods"),
                    Weight = table.Column<double>(type: "float", nullable: true, comment: "Weight of the goods"),
                    TypeOfGoods = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Type of goods"),
                    Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Type of the request"),
                    PickupLatitude = table.Column<double>(type: "float", nullable: false, comment: "Pickup address latitude"),
                    PickupLongitude = table.Column<double>(type: "float", nullable: false, comment: "Pickup address longitude"),
                    DeliveryLatitude = table.Column<double>(type: "float", nullable: false, comment: "Delivery address latitude"),
                    DeliveryLongitude = table.Column<double>(type: "float", nullable: false, comment: "Delivery address longitude"),
                    SharedTruck = table.Column<bool>(type: "bit", nullable: false, comment: "Will the vehicle be shared or no"),
                    ApproximatePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Approximate price given by the company"),
                    CalculatedPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Automatically calculated price"),
                    ExpectedDeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Expected delivery date"),
                    Status = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "Status of the request"),
                    SpecialInstructions = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, comment: "Special instructions"),
                    IsRefrigerated = table.Column<bool>(type: "bit", nullable: false, comment: "Is the cargo refrigerated"),
                    OfferId = table.Column<int>(type: "int", nullable: true, comment: "Offer identifier"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of creation")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_ClientCompanies_ClientCompanyId",
                        column: x => x.ClientCompanyId,
                        principalTable: "ClientCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Request Entity");

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Offer identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestId = table.Column<int>(type: "int", nullable: false, comment: "Request identifier"),
                    FinalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Company identifier"),
                    OfferStatus = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "Offer status"),
                    OfferDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Offer date"),
                    Notes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true, comment: "Notes for the offer"),
                    InvoiceId = table.Column<int>(type: "int", nullable: true, comment: "Invoice identifier"),
                    DeliveryId = table.Column<int>(type: "int", nullable: true, comment: "Delivery identifier"),
                    ClientCompanyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offers_ClientCompanies_ClientCompanyId",
                        column: x => x.ClientCompanyId,
                        principalTable: "ClientCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Offers_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Offer Entity");

            migrationBuilder.CreateTable(
                name: "Deliveries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Delivery identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(type: "int", nullable: false, comment: "Vehicle identifier"),
                    DriverId = table.Column<int>(type: "int", nullable: false, comment: "Driver identifier"),
                    OfferId = table.Column<int>(type: "int", nullable: false, comment: "Offer identifier"),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Delivery status"),
                    TotalExpenses = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Delivery total expenses"),
                    Profit = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Delivery total income"),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Delivery reference number")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliveries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deliveries_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Deliveries_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Deliveries_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Delivery Entity");

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Invoice identifier"),
                    OfferId = table.Column<int>(type: "int", nullable: false, comment: "Offer identifier"),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Invoice number"),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Invoice date"),
                    ClientCompanyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_ClientCompanies_ClientCompanyId",
                        column: x => x.ClientCompanyId,
                        principalTable: "ClientCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoices_Offers_Id",
                        column: x => x.Id,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Invoice Entity");

            migrationBuilder.CreateTable(
                name: "CashRegisters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Cash Register identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryId = table.Column<int>(type: "int", nullable: false, comment: "Delivery identifier"),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, comment: "Description of the register"),
                    Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Type of the register"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Amount of the register"),
                    DateSubmitted = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date submitted")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashRegisters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CashRegisters_Deliveries_DeliveryId",
                        column: x => x.DeliveryId,
                        principalTable: "Deliveries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Cash Register Entity");

            migrationBuilder.CreateTable(
                name: "DeliveryTrackings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryId = table.Column<int>(type: "int", nullable: false, comment: "Delivery identifier"),
                    DriverId = table.Column<int>(type: "int", nullable: false, comment: "Driver identifier"),
                    StatusUpdate = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Status update"),
                    Notes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true, comment: "Notes"),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Timestamp"),
                    Latitude = table.Column<double>(type: "float", nullable: false, comment: "Latitude"),
                    Longitude = table.Column<double>(type: "float", nullable: false, comment: "Longitude")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryTrackings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryTrackings_Deliveries_DeliveryId",
                        column: x => x.DeliveryId,
                        principalTable: "Deliveries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryTrackings_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Delivery Tracking Entity");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "20ddc22c-ca6d-4feb-a688-0f31a430b5eb", "10ab5af2-eaaa-4ce5-87d2-00548197bc38", "Secretary", "SECRETARY" },
                    { "27609f35-fbc8-4dc4-9d12-7ff2dd400327", "891fa2a9-7d34-4a07-91fc-9bc5b0bc7b1c", "Speditor", "SPEDITOR" },
                    { "5d000e64-c056-419a-950f-1992bd1e910d", "80e7ebd3-95f1-44c6-9ae7-7d78c2006058", "ClientCompany", "CLIENTCOMPANY" },
                    { "99027aaa-d346-4dd9-a467-15d74576c080", "693c3bd6-9e81-4212-b36c-ead34d7cf794", "LogisticsCompany", "LOGISTICSCOMPANY" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "20450cff-816f-49c8-9546-1c603aec0301", 0, "f442b5bb-5fe4-4897-af6c-bacb7ab67b6b", "clientcompany1@example.com", true, false, null, null, null, "AQAAAAEAACcQAAAAEFu8R7Ckw2oNsLy/3/D2fXFoI3sp8XqWhkzW1L3vaBS0xcL59pp2sL0HEjimRe2Zzg==", "1234567890", false, "11614547-885b-498d-8ff9-9f88a8b031af", false, "clientcompany1" },
                    { "2e8be95a-186e-403b-b4aa-3874750a3563", 0, "b55e952c-fdac-46e3-8d54-1afecb30c667", "speditor@example.com", true, false, null, null, null, "AQAAAAEAACcQAAAAEGuWG00E2zBV8EkRvBxRq1OfP6QseEC2SPhAhwWo/5bRaNFoSaXV3TNnLzOq3NjOQA==", null, false, "882e2b8f-827a-4cc1-8d73-f65901d6556d", false, "speditor" },
                    { "38ba6810-2800-4ac8-b005-5c27e8248951", 0, "08583d03-8c7f-4e63-8a4f-46be7df760db", "secretary@example.com", true, false, null, null, null, "AQAAAAEAACcQAAAAEI5fNNisfRkOSRtzz4cdCTAJe089AZ3Cp3mkGDkQlgfjtcmZHZaWUrV2u3VhSkrkZA==", null, false, "58cc8a65-819a-48fb-8eea-3705ad611ed5", false, "secretary" },
                    { "6bab54d5-5a88-4128-92d2-4d12ad0baa32", 0, "fe966ef2-422a-4291-b886-211aec5dd0d5", "logistics@example.com", true, false, null, null, null, "AQAAAAEAACcQAAAAEPiVZV7b9WXFsCF+dl2w9tYyhARcRKpr9DO8+7Jx4AHKwYZZLabLXLQpBBI8U0eeog==", null, false, "f2172c3f-3466-4109-9d56-08184b3af76c", false, "logistics" }
                });

            migrationBuilder.InsertData(
                table: "ClientCompanies",
                columns: new[] { "Id", "AlternativePhoneNumber", "City", "CompanySize", "ContactPerson", "Country", "Industry", "Name", "PostalCode", "RegistrationNumber", "RegistrationStatus", "Street", "UserId", "VatNumber" },
                values: new object[] { 2, "9876543210", "Sofia", "Large", "Jane Smith", "Bulgaria", "Fashion", "Client Company 2", "1000", "REG654321", "Rejected", "Osogovo 5a", null, "VAT654321" });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "ArePalletsStackable", "EuroPalletCapacity", "FuelConsumptionPer100Km", "Height", "IndustrialPalletCapacity", "Length", "MaintenanceDue", "MaxWeightCapacity", "RegistrationNumber", "VehicleStatus", "VehicleType", "Volume", "Width" },
                values: new object[,]
                {
                    { 1, true, 10, 28.5, 2.6000000000000001, 8, 7.5, new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10000.0, "BG1234RE", "Not Available", "Refrigerated Truck", 48.75, 2.5 },
                    { 2, true, 33, 32.0, 2.7000000000000002, 26, 13.6, new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 24000.0, "BG5678TT", "Available", "Tent Truck", 91.799999999999997, 2.5 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "5d000e64-c056-419a-950f-1992bd1e910d", "20450cff-816f-49c8-9546-1c603aec0301" },
                    { "27609f35-fbc8-4dc4-9d12-7ff2dd400327", "2e8be95a-186e-403b-b4aa-3874750a3563" },
                    { "20ddc22c-ca6d-4feb-a688-0f31a430b5eb", "38ba6810-2800-4ac8-b005-5c27e8248951" },
                    { "99027aaa-d346-4dd9-a467-15d74576c080", "6bab54d5-5a88-4128-92d2-4d12ad0baa32" }
                });

            migrationBuilder.InsertData(
                table: "ClientCompanies",
                columns: new[] { "Id", "AlternativePhoneNumber", "City", "CompanySize", "ContactPerson", "Country", "Industry", "Name", "PostalCode", "RegistrationNumber", "RegistrationStatus", "Street", "UserId", "VatNumber" },
                values: new object[] { 1, "1234567891", "Sliven", "Medium", "John Doe", "Bulgaria", "Manufacturing", "Client Company 1", "8800", "REG123456", "Approved", "Sini kamani 28", "20450cff-816f-49c8-9546-1c603aec0301", "VAT123456" });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "Age", "IsAvailable", "LicenseExpiryDate", "LicenseNumber", "MonthsOfExperience", "Name", "Preferrences", "Salary", "UserId", "YearOfExperience" },
                values: new object[,]
                {
                    { 1, 35, false, new DateTime(2026, 10, 19, 0, 49, 50, 221, DateTimeKind.Utc).AddTicks(8845), "DL123456", 6, "Paul Smith", "Long-distance deliveries", 3000m, "2e8be95a-186e-403b-b4aa-3874750a3563", 10 },
                    { 2, 32, true, new DateTime(2027, 10, 19, 0, 49, 50, 221, DateTimeKind.Utc).AddTicks(8850), "DL654321", 4, "Mark Driver", "Short-distance deliveries", 2800m, "38ba6810-2800-4ac8-b005-5c27e8248951", 8 }
                });

            migrationBuilder.InsertData(
                table: "Requests",
                columns: new[] { "Id", "ApproximatePrice", "CalculatedPrice", "CargoType", "ClientCompanyId", "CreatedAt", "DeliveryLatitude", "DeliveryLongitude", "ExpectedDeliveryDate", "Height", "IsRefrigerated", "Length", "NumberOfNonStandartGoods", "NumberOfPallets", "OfferId", "PalletHeight", "PalletLength", "PalletVolume", "PalletWidth", "PalletsAreStackable", "PickupLatitude", "PickupLongitude", "SharedTruck", "SpecialInstructions", "Status", "Type", "TypeOfGoods", "TypeOfPallet", "Volume", "Weight", "WeightOfPallets", "Width" },
                values: new object[,]
                {
                    { 1, 2000.00m, 2100.00m, "Standard", 1, new DateTime(2024, 10, 19, 3, 49, 51, 361, DateTimeKind.Local).AddTicks(1835), 48.8566, 2.3521999999999998, new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, null, null, 10, null, 144.0, 120.0, 1.3824000000000001, 80.0, true, 42.681199999999997, 26.3187, false, "Handle with care", "Approved", "International", "Electronics", "Euro", null, null, 500.0, null },
                    { 2, 1500.00m, 1550.00m, "Standard", 1, new DateTime(2024, 10, 19, 3, 49, 51, 361, DateTimeKind.Local).AddTicks(1963), 42.697699999999998, 23.321899999999999, new DateTime(2024, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, null, null, 15, null, 160.0, 120.0, 1.536, 80.0, true, 42.681199999999997, 26.3187, false, "Keep refrigerated", "pending", "Domestic", "Food Products", "Euro", null, null, 750.0, null },
                    { 3, 1800.00m, 1850.00m, "Standard", 1, new DateTime(2024, 10, 19, 3, 49, 51, 361, DateTimeKind.Local).AddTicks(1987), 48.208199999999998, 16.373799999999999, new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 8, null, 150.0, 120.0, 1.8, 100.0, false, 42.681199999999997, 26.3187, true, "Use soft padding", "Pending", "International", "Furniture", "Industrial", null, null, 400.0, null },
                    { 4, 1700.00m, 1750.00m, "Standard", 1, new DateTime(2024, 10, 19, 3, 49, 51, 361, DateTimeKind.Local).AddTicks(1994), 43.835599999999999, 25.965699999999998, new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 12, null, 130.0, 120.0, 1.5600000000000001, 100.0, true, 42.681199999999997, 26.3187, true, "Avoid moisture", "Pending", "Domestic", "Machinery Parts", "Industrial", null, null, 600.0, null }
                });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "ClientCompanyId", "DeliveryId", "FinalPrice", "InvoiceId", "Notes", "OfferDate", "OfferStatus", "RequestId" },
                values: new object[] { 1, null, null, 4800m, null, "Confirmed by client", new DateTime(2024, 10, 18, 0, 49, 51, 348, DateTimeKind.Utc).AddTicks(5758), "Accepted", 1 });

            migrationBuilder.InsertData(
                table: "Deliveries",
                columns: new[] { "Id", "DriverId", "OfferId", "Profit", "ReferenceNumber", "Status", "TotalExpenses", "VehicleId" },
                values: new object[] { 1, 1, 1, 4300m, "", "In Progress", 500m, 1 });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "ClientCompanyId", "InvoiceDate", "InvoiceNumber", "OfferId" },
                values: new object[] { 1, null, new DateTime(2024, 10, 19, 0, 49, 51, 341, DateTimeKind.Utc).AddTicks(5318), "INV-2024-0001", 1 });

            migrationBuilder.InsertData(
                table: "CashRegisters",
                columns: new[] { "Id", "Amount", "DateSubmitted", "DeliveryId", "Description", "Type" },
                values: new object[] { 1, 200m, new DateTime(2024, 10, 19, 0, 49, 50, 204, DateTimeKind.Utc).AddTicks(1836), 1, "Fuel cost", "Expense" });

            migrationBuilder.InsertData(
                table: "CashRegisters",
                columns: new[] { "Id", "Amount", "DateSubmitted", "DeliveryId", "Description", "Type" },
                values: new object[] { 2, 50m, new DateTime(2024, 10, 19, 0, 49, 50, 204, DateTimeKind.Utc).AddTicks(1838), 1, "Toll fee", "Expense" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CashRegisters_DeliveryId",
                table: "CashRegisters",
                column: "DeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientCompanies_UserId",
                table: "ClientCompanies",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_OfferId",
                table: "Deliveries",
                column: "OfferId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_DriverId",
                table: "Deliveries",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_VehicleId",
                table: "Deliveries",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryTrackings_DeliveryId",
                table: "DeliveryTrackings",
                column: "DeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryTrackings_DriverId",
                table: "DeliveryTrackings",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_UserId",
                table: "Drivers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ClientCompanyId",
                table: "Invoices",
                column: "ClientCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_DeliveryId",
                table: "Offers",
                column: "DeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_RequestId",
                table: "Offers",
                column: "RequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Offers_ClientCompanyId",
                table: "Offers",
                column: "ClientCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ClientCompanyId",
                table: "Requests",
                column: "ClientCompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CashRegisters");

            migrationBuilder.DropTable(
                name: "DeliveryTrackings");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Deliveries");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "ClientCompanies");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}

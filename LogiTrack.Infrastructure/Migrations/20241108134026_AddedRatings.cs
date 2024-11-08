using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogiTrack.Infrastructure.Migrations
{
    public partial class AddedRatings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Street name and number"),
                    County = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false, comment: "County or region"),
                    City = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false, comment: "City name"),
                    PostalCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true, comment: "Company's postal code"),
                    Latitude = table.Column<double>(type: "float", nullable: true, comment: "Latitude of the address"),
                    Longitude = table.Column<double>(type: "float", nullable: true, comment: "Longitude of the address")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                },
                comment: "Address Entity");

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
                name: "FuelPrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Fuel Price identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Fuel price"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelPrices", x => x.Id);
                },
                comment: "Fuel Prices Entity");

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
                    LastYearMaintenance = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Maintenance due date"),
                    KilometersDriven = table.Column<double>(type: "float", nullable: false, comment: "Kilometers driven"),
                    KilometersLeftToChangeParts = table.Column<double>(type: "float", nullable: false, comment: "Kilometers left to change parts"),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Vehicle's purchase price"),
                    ContantsExpenses = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Vehicle's constant expences")
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
                    RegistrationNumber = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false, comment: "Company's registration number"),
                    Industry = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Company's industry"),
                    AddressId = table.Column<int>(type: "int", nullable: false, comment: "Address of the company identifier"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Registration created at")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientCompanies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientCompanies_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "PricesPerSize",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Prices per size identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(type: "int", nullable: false, comment: "Vehicle identifier"),
                    QuotientForDomesticNotSharedTruck = table.Column<double>(type: "float", nullable: false, comment: "Quotient for domestic not shared truck"),
                    QuotientForDomesticSharedTruck = table.Column<double>(type: "float", nullable: false, comment: "Quotient for domestic shared truck"),
                    QuotientForInternationalNotSharedTruck = table.Column<double>(type: "float", nullable: false, comment: "Quotient for international not shared truck"),
                    QuotientForInternationalSharedTruck = table.Column<double>(type: "float", nullable: false, comment: "Quotient for international shared truck"),
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

            migrationBuilder.CreateTable(
                name: "CalendarEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Calendar Event identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Title"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date"),
                    EventType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Event Type"),
                    ClientCompanyId = table.Column<int>(type: "int", nullable: false, comment: "Client Company identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalendarEvents_ClientCompanies_ClientCompanyId",
                        column: x => x.ClientCompanyId,
                        principalTable: "ClientCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Calendar Event Entity");

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Request identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientCompanyId = table.Column<int>(type: "int", nullable: false, comment: "Client Company identifier"),
                    CargoType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Cargo type"),
                    NumberOfNonStandartGoods = table.Column<int>(type: "int", nullable: true, comment: "Number of non-standart goods"),
                    TypeOfGoods = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Type of goods"),
                    Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Type of the request"),
                    PickupAddressId = table.Column<int>(type: "int", nullable: false, comment: "Pickup address identifier"),
                    DeliveryAddressId = table.Column<int>(type: "int", nullable: false, comment: "Delivery address identifier"),
                    SharedTruck = table.Column<bool>(type: "bit", nullable: false, comment: "Will the vehicle be shared or no"),
                    ApproximatePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Approximate price given by the company"),
                    CalculatedPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Automatically calculated price"),
                    ExpectedDeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Expected delivery date"),
                    Status = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "Status of the request"),
                    SpecialInstructions = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, comment: "Special instructions"),
                    IsRefrigerated = table.Column<bool>(type: "bit", nullable: false, comment: "Is the cargo refrigerated"),
                    OfferId = table.Column<int>(type: "int", nullable: true, comment: "Offer identifier"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of creation"),
                    Kilometers = table.Column<double>(type: "float", nullable: false),
                    StandartCargoId = table.Column<int>(type: "int", nullable: false, comment: "Standart cargo identifier"),
                    TotalWeight = table.Column<double>(type: "float", nullable: false),
                    TotalVolume = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_Addresses_DeliveryAddressId",
                        column: x => x.DeliveryAddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_Addresses_PickupAddressId",
                        column: x => x.PickupAddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_ClientCompanies_ClientCompanyId",
                        column: x => x.ClientCompanyId,
                        principalTable: "ClientCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Request Entity");

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
                    DeliveryId = table.Column<int>(type: "int", nullable: true, comment: "Delivery identifier"),
                    OfferNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    ReferenceNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Delivery reference number"),
                    DeliveryStep = table.Column<int>(type: "int", nullable: false),
                    ActualDeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InvoiceId = table.Column<int>(type: "int", nullable: true, comment: "Invoice identifier")
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
                name: "CashRegisters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Cash Register identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryId = table.Column<int>(type: "int", nullable: false, comment: "Delivery identifier"),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, comment: "Description of the register"),
                    Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Type of the register"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Amount of the register"),
                    DateSubmitted = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date submitted"),
                    FileId = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "File identifier in Google drive")
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
                    Longitude = table.Column<double>(type: "float", nullable: false, comment: "Longitude"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Invoice identifier"),
                    DeliveryId = table.Column<int>(type: "int", nullable: false, comment: "Delivery identifier"),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Invoice number"),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Invoice date"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Invoice description"),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false, comment: "Is invoice paid"),
                    FileId = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "File identifier in Google drive"),
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
                        name: "FK_Invoices_Deliveries_Id",
                        column: x => x.Id,
                        principalTable: "Deliveries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Invoice Entity");

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RatingStars = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_Deliveries_DeliveryId",
                        column: x => x.DeliveryId,
                        principalTable: "Deliveries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Rating Entity");

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "County", "Latitude", "Longitude", "PostalCode", "Street" },
                values: new object[,]
                {
                    { 1, "Metropolis", "Central", null, null, "10001", "123 Main St" },
                    { 2, "Gotham", "Westside", null, null, "10002", "456 Side St" },
                    { 3, "Star City", "Northside", null, null, null, "789 Elm St" },
                    { 4, "Central City", "Eastville", null, null, null, "101 Pine St" },
                    { 5, "Smallville", "Southend", null, null, null, "202 Maple St" },
                    { 6, "Bludhaven", "Old Town", null, null, null, "303 Oak St" },
                    { 7, "Coast City", "Downtown", null, null, null, "404 Birch St" },
                    { 8, "National City", "West End", null, null, null, "505 Cedar St" },
                    { 9, "Ivy Town", "Upper Hill", null, null, null, "606 Cherry St" },
                    { 10, "Gateway City", "Harborview", null, null, null, "707 Aspen St" },
                    { 11, "Opal City", "Lakeside", null, null, null, "808 Willow St" },
                    { 12, "Fawcett City", "Midtown", null, null, null, "909 Fir St" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "20ddc22c-ca6d-4feb-a688-0f31a430b5eb", "09b6c40d-b530-4366-8170-052652683df4", "Accountant", "ACCOUNTANT" },
                    { "27609f35-fbc8-4dc4-9d12-7ff2dd400327", "cd05c3ca-8c70-479f-8c68-5a3981eade49", "Speditor", "SPEDITOR" },
                    { "350868c0-bf0f-4f70-b4c9-155351bc6429", "2b273e33-f4a1-4c7b-988c-363e9e2a8de0", "Driver", "DRIVER" },
                    { "5d000e64-c056-419a-950f-1992bd1e910d", "c19bcd41-1277-4197-96d6-9987e5795b11", "ClientCompany", "CLIENTCOMPANY" },
                    { "99027aaa-d346-4dd9-a467-15d74576c080", "5f125b94-826e-4411-8bb3-b39c9eb373b9", "LogisticsCompany", "LOGISTICSCOMPANY" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "20450cff-816f-49c8-9546-1c603aec0301", 0, "b867800e-06b9-4ec8-bbdf-d097fd31ee30", "clientcompany1@example.com", true, false, null, null, null, "AQAAAAEAACcQAAAAEBcFWZqc/Aymhkvojca4rceWLXJpHZ1GIO779WkCCdG+f3r3CtGh5K+UMkzP9etjSQ==", "1234567890", false, "6664513d-933e-4aa2-a3ac-604550d6f7f9", false, "clientcompany1" },
                    { "2e8be95a-186e-403b-b4aa-3874750a3563", 0, "d7abcb50-9302-4ce9-a592-4dcddd94e286", "speditor@example.com", true, false, null, null, null, "AQAAAAEAACcQAAAAEE2zyDzHrqBE1XnwbXbjFGe3xvcdVzGtvHm/7RWWpAWS0KIxP0qnD2WSO4CD1nL8kQ==", null, false, "ee2370a6-5910-4752-940d-605e1582b3fd", false, "speditor" },
                    { "38ba6810-2800-4ac8-b005-5c27e8248951", 0, "996ee4dc-8637-446d-b3c1-298d04b40b30", "secretary@example.com", true, false, null, null, null, "AQAAAAEAACcQAAAAEJ3XyZanXJTzWc0kidV7TFpRWlcaHp+TxmtQ/1RsivDSndhQwAfCDmSTfvPijq3LYQ==", null, false, "e7e1fb9c-8c04-448d-bf8a-33521c60b18d", false, "secretary" },
                    { "6bab54d5-5a88-4128-92d2-4d12ad0baa32", 0, "675fc702-8cf9-4c4b-99b2-8a064a60ae09", "logistics@example.com", true, false, null, null, null, "AQAAAAEAACcQAAAAEGdk7q9uBNc6Ss5/Lp9vgklWBfyKzkU5n/6J7q9HY+GM3F4hMYOs6pQUcHT+VcPlmQ==", null, false, "cea532cb-26e0-420e-b07f-7d0722056424", false, "logistics" },
                    { "driverUser1", 0, "cbc9dea0-e932-4120-8a95-1d97a4d13ebf", "driver1@example.com", true, false, null, "DRIVER1@EXAMPLE.COM", "DRIVER1@EXAMPLE.COM", "AQAAAAEAACcQAAAAEI4VorIQdF6/qXgKdMI0JM4sRMtyHh4GsQpCDQxU0eRkb6OraLNGEZwUlEGWQYNibA==", null, false, "20e6d1a2-9c0a-4286-83b6-1f0ec0362aaf", false, "driver1@example.com" },
                    { "driverUser2", 0, "a1fbeb75-294e-46ec-acdd-aaf9616c2b79", "driver2@example.com", true, false, null, "DRIVER2@EXAMPLE.COM", "DRIVER2@EXAMPLE.COM", null, null, false, "fd6f916b-5edf-47ff-abb0-e0afc24f2844", false, "driver2@example.com" }
                });

            migrationBuilder.InsertData(
                table: "FuelPrices",
                columns: new[] { "Id", "Date", "Price" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 5, 15, 40, 25, 569, DateTimeKind.Local).AddTicks(5120), 2.50m },
                    { 2, new DateTime(2024, 11, 6, 15, 40, 25, 569, DateTimeKind.Local).AddTicks(5123), 2.60m }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "ArePalletsStackable", "ContantsExpenses", "EuroPalletCapacity", "FuelConsumptionPer100Km", "Height", "IndustrialPalletCapacity", "KilometersDriven", "KilometersLeftToChangeParts", "LastYearMaintenance", "Length", "MaxWeightCapacity", "PurchasePrice", "RegistrationNumber", "VehicleStatus", "VehicleType", "Volume", "Width" },
                values: new object[,]
                {
                    { 1, true, 5000.0m, 33, 12.5, 2.7999999999999998, 20, 150000.0, 50000.0, new DateTime(2024, 8, 8, 15, 40, 25, 537, DateTimeKind.Local).AddTicks(4333), 12.0, 18000.0, 75000.0m, "ABC123", "Available", "Truck", 84.0, 2.5 },
                    { 2, false, 2000.0m, 10, 8.0, 2.5, 8, 90000.0, 30000.0, new DateTime(2024, 10, 8, 15, 40, 25, 537, DateTimeKind.Local).AddTicks(4340), 6.0, 3500.0, 25000.0m, "XYZ789", "Available", "Van", 30.0, 2.0 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "5d000e64-c056-419a-950f-1992bd1e910d", "20450cff-816f-49c8-9546-1c603aec0301" },
                    { "27609f35-fbc8-4dc4-9d12-7ff2dd400327", "2e8be95a-186e-403b-b4aa-3874750a3563" },
                    { "20ddc22c-ca6d-4feb-a688-0f31a430b5eb", "38ba6810-2800-4ac8-b005-5c27e8248951" },
                    { "99027aaa-d346-4dd9-a467-15d74576c080", "6bab54d5-5a88-4128-92d2-4d12ad0baa32" },
                    { "350868c0-bf0f-4f70-b4c9-155351bc6429", "driverUser1" },
                    { "350868c0-bf0f-4f70-b4c9-155351bc6429", "driverUser2" }
                });

            migrationBuilder.InsertData(
                table: "ClientCompanies",
                columns: new[] { "Id", "AddressId", "AlternativePhoneNumber", "ContactPerson", "CreatedAt", "Industry", "Name", "RegistrationNumber", "RegistrationStatus", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "1234567891", "John Doe", new DateTime(2024, 10, 19, 15, 40, 24, 333, DateTimeKind.Local).AddTicks(5608), "Manufacturing", "Client Company 1", "REG123456", "Approved", "20450cff-816f-49c8-9546-1c603aec0301" },
                    { 2, 2, "9876543210", "Jane Smith", new DateTime(2024, 10, 29, 15, 40, 24, 333, DateTimeKind.Local).AddTicks(5703), "Fashion", "Client Company 2", "REG654321", "Pending", null }
                });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "Age", "IsAvailable", "LicenseExpiryDate", "LicenseNumber", "MonthsOfExperience", "Name", "Preferrences", "Salary", "UserId", "YearOfExperience" },
                values: new object[,]
                {
                    { 1, 30, true, new DateTime(2025, 11, 8, 15, 40, 24, 630, DateTimeKind.Local).AddTicks(2411), "D12345678", 6, "John Doe", "No night shifts", 3000.0m, "driverUser1", 5 },
                    { 2, 28, false, new DateTime(2025, 11, 8, 15, 40, 24, 630, DateTimeKind.Local).AddTicks(2419), "D87654321", 8, "Jane Smith", "Prefers city deliveries", 3200.0m, "driverUser2", 4 }
                });

            migrationBuilder.InsertData(
                table: "PricesPerSize",
                columns: new[] { "Id", "DomesticPriceForNotSharedTruck", "DomesticPriceForSharedTruck", "InternationalPriceForNotSharedTruck", "InternationalPriceForSharedTruck", "QuotientForDomesticNotSharedTruck", "QuotientForDomesticSharedTruck", "QuotientForInternationalNotSharedTruck", "QuotientForInternationalSharedTruck", "VehicleId" },
                values: new object[,]
                {
                    { 1, 1000.0m, 800.0m, 1500.0m, 1200.0m, 1.2, 0.90000000000000002, 1.5, 1.1000000000000001, 1 },
                    { 2, 1100.0m, 850.0m, 1600.0m, 1300.0m, 1.3, 0.84999999999999998, 1.6000000000000001, 1.2, 2 }
                });

            migrationBuilder.InsertData(
                table: "CalendarEvents",
                columns: new[] { "Id", "ClientCompanyId", "Date", "EventType", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 10, 8, 15, 40, 25, 582, DateTimeKind.Local).AddTicks(8), "Paid", "Monthly Payment Due" },
                    { 2, 1, new DateTime(2024, 8, 8, 15, 40, 25, 582, DateTimeKind.Local).AddTicks(11), "Paid", "Quarterly Review" },
                    { 3, 1, new DateTime(2024, 5, 8, 15, 40, 25, 582, DateTimeKind.Local).AddTicks(13), "Delivered", "Annual Delivery Milestone" }
                });

            migrationBuilder.InsertData(
                table: "Requests",
                columns: new[] { "Id", "ApproximatePrice", "CalculatedPrice", "CargoType", "ClientCompanyId", "CreatedAt", "DeliveryAddressId", "ExpectedDeliveryDate", "IsRefrigerated", "Kilometers", "NumberOfNonStandartGoods", "OfferId", "PickupAddressId", "SharedTruck", "SpecialInstructions", "StandartCargoId", "Status", "TotalVolume", "TotalWeight", "Type", "TypeOfGoods" },
                values: new object[,]
                {
                    { 1, 500m, 450m, "Standard", 1, new DateTime(2024, 11, 8, 15, 40, 24, 602, DateTimeKind.Local).AddTicks(2501), 4, new DateTime(2024, 11, 15, 15, 40, 24, 602, DateTimeKind.Local).AddTicks(2498), false, 500.0, null, null, 3, false, "Handle with care", 0, "Pending", 12.0, 300.0, "Domestic", "Electronics" },
                    { 2, 1200m, 1150m, "Standard", 1, new DateTime(2024, 11, 8, 15, 40, 24, 602, DateTimeKind.Local).AddTicks(2508), 6, new DateTime(2024, 11, 18, 15, 40, 24, 602, DateTimeKind.Local).AddTicks(2506), false, 1000.0, null, null, 5, true, "Keep dry", 0, "Accepted", 20.0, 500.0, "International", "Furniture" },
                    { 3, 2000m, 1900m, "Non-Standard", 1, new DateTime(2024, 11, 8, 15, 40, 24, 602, DateTimeKind.Local).AddTicks(2533), 8, new DateTime(2024, 11, 23, 15, 40, 24, 602, DateTimeKind.Local).AddTicks(2530), false, 2000.0, null, null, 7, false, "Requires crane", 0, "Pending", 50.0, 2000.0, "Domestic", "Machinery" },
                    { 4, 350m, 340m, "Standard", 1, new DateTime(2024, 11, 8, 15, 40, 24, 602, DateTimeKind.Local).AddTicks(2544), 10, new DateTime(2024, 11, 11, 15, 40, 24, 602, DateTimeKind.Local).AddTicks(2542), false, 500.0, null, null, 9, true, "Do not compress", 0, "Pending", 8.0, 150.0, "Domestic", "Textiles" },
                    { 5, 220m, 210m, "Standard", 1, new DateTime(2024, 11, 8, 15, 40, 24, 602, DateTimeKind.Local).AddTicks(2553), 12, new DateTime(2024, 11, 12, 15, 40, 24, 602, DateTimeKind.Local).AddTicks(2551), false, 1000.0, null, null, 11, false, "Fragile binding", 0, "Pending", 1.8, 300.0, "International", "Books" }
                });

            migrationBuilder.InsertData(
                table: "NonStandardCargos",
                columns: new[] { "Id", "Description", "Height", "Length", "RequestId", "Volume", "Weight", "Width" },
                values: new object[,]
                {
                    { 1, "Large industrial machine", 150.0, 120.0, 3, 1.8, 300.0, 100.0 },
                    { 2, "Auxiliary machine part", 80.0, 90.0, 3, 0.59999999999999998, 120.0, 75.0 },
                    { 3, "High-pressure pump", 100.0, 150.0, 3, 1.2, 450.0, 80.0 },
                    { 4, "Extra non-standard cargo for Request5", 100.0, 150.0, 5, 1.8, 300.0, 120.0 }
                });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "ClientCompanyId", "DeliveryId", "FinalPrice", "Notes", "OfferDate", "OfferNumber", "OfferStatus", "RequestId" },
                values: new object[,]
                {
                    { 1, null, null, 1200.0m, "Initial offer for Request 1", new DateTime(2024, 10, 29, 15, 40, 24, 354, DateTimeKind.Local).AddTicks(7317), "", "Pending", 1 },
                    { 2, null, null, 1500.0m, "Offer accepted for Request 2", new DateTime(2024, 10, 31, 15, 40, 24, 354, DateTimeKind.Local).AddTicks(7322), "", "Approved", 2 },
                    { 3, null, null, 1800.0m, "Offer approved for Request 3", new DateTime(2024, 11, 3, 15, 40, 24, 354, DateTimeKind.Local).AddTicks(7326), "", "Approved", 3 },
                    { 4, null, null, 2100.0m, "Approved offer for Request 4", new DateTime(2024, 11, 6, 15, 40, 24, 354, DateTimeKind.Local).AddTicks(7330), "", "Approved", 4 },
                    { 5, null, null, 2300.0m, "Finalized offer for Request 5", new DateTime(2024, 11, 8, 15, 40, 24, 354, DateTimeKind.Local).AddTicks(7333), "", "Accepted", 5 }
                });

            migrationBuilder.InsertData(
                table: "StandartCargos",
                columns: new[] { "Id", "NumberOfPallets", "PalletHeight", "PalletLength", "PalletVolume", "PalletWidth", "PalletsAreStackable", "RequestId", "TypeOfPallet", "WeightOfPallets" },
                values: new object[,]
                {
                    { 1, 5, 100.0, 120.0, 0.95999999999999996, 80.0, true, 1, "Euro", 500.0 },
                    { 2, 3, 110.0, 130.0, 1.29, 90.0, false, 2, "Industrial", 700.0 },
                    { 3, 4, 100.0, 120.0, 0.95999999999999996, 80.0, true, 4, "Standard", 450.0 }
                });

            migrationBuilder.InsertData(
                table: "Deliveries",
                columns: new[] { "Id", "ActualDeliveryDate", "DeliveryStep", "DriverId", "InvoiceId", "OfferId", "Profit", "ReferenceNumber", "Status", "TotalExpenses", "VehicleId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 7, 15, 40, 25, 526, DateTimeKind.Local).AddTicks(4746), 2, 1, null, 1, 750.00m, "DEL0001", "In Transit", 500.00m, 1 },
                    { 2, new DateTime(2024, 11, 6, 15, 40, 25, 526, DateTimeKind.Local).AddTicks(4758), 1, 1, null, 2, 700.00m, "DEL0002", "Booked", 450.00m, 1 },
                    { 3, new DateTime(2024, 11, 5, 15, 40, 25, 526, DateTimeKind.Local).AddTicks(4763), 4, 1, null, 3, 800.00m, "DEL0003", "Delivered", 600.00m, 1 },
                    { 4, new DateTime(2024, 11, 4, 15, 40, 25, 526, DateTimeKind.Local).AddTicks(4767), 2, 1, null, 4, 780.00m, "DEL0004", "In Transit", 520.00m, 1 },
                    { 5, new DateTime(2024, 11, 3, 15, 40, 25, 526, DateTimeKind.Local).AddTicks(4771), 3, 1, null, 5, 720.00m, "DEL0005", "Booked", 480.00m, 1 }
                });

            migrationBuilder.InsertData(
                table: "CashRegisters",
                columns: new[] { "Id", "Amount", "DateSubmitted", "DeliveryId", "Description", "FileId", "Type" },
                values: new object[,]
                {
                    { 1, 100.00m, new DateTime(2024, 11, 3, 15, 40, 24, 324, DateTimeKind.Local).AddTicks(4350), 1, "Fuel Expense", "", "Vehicle Expenses" },
                    { 2, 50.00m, new DateTime(2024, 11, 4, 15, 40, 24, 324, DateTimeKind.Local).AddTicks(4354), 1, "Toll Fee", "", "Vehicle Expenses" },
                    { 3, 20.00m, new DateTime(2024, 11, 5, 15, 40, 24, 324, DateTimeKind.Local).AddTicks(4357), 2, "Driver Lunch", "", "Driver Expenses" },
                    { 4, 150.00m, new DateTime(2024, 11, 6, 15, 40, 24, 324, DateTimeKind.Local).AddTicks(4359), 3, "Repair Costs", "", "Vehicle Expenses" },
                    { 5, 80.00m, new DateTime(2024, 11, 7, 15, 40, 24, 324, DateTimeKind.Local).AddTicks(4362), 4, "Accommodation", "", "Driver Expenses" },
                    { 6, 40.00m, new DateTime(2024, 11, 8, 15, 40, 24, 324, DateTimeKind.Local).AddTicks(4364), 5, "Miscellaneous", "", "Other Expenses" }
                });

            migrationBuilder.InsertData(
                table: "DeliveryTrackings",
                columns: new[] { "Id", "Address", "DeliveryId", "DriverId", "Latitude", "Longitude", "Notes", "StatusUpdate", "Timestamp" },
                values: new object[,]
                {
                    { 1, "Sofia, Bulgaria", 1, 1, 42.697699999999998, 23.321899999999999, "Delivery completed successfully.", "Delivered", new DateTime(2024, 11, 3, 15, 40, 25, 547, DateTimeKind.Local).AddTicks(8140) },
                    { 2, "Varna, Bulgaria", 2, 1, 43.214100000000002, 27.9147, "Delivery scheduled.", "Booked", new DateTime(2024, 11, 4, 15, 40, 25, 547, DateTimeKind.Local).AddTicks(8144) },
                    { 3, "Plovdiv, Bulgaria", 3, 1, 42.135399999999997, 24.7453, "Delivered on time.", "Delivered", new DateTime(2024, 11, 5, 15, 40, 25, 547, DateTimeKind.Local).AddTicks(8147) },
                    { 4, "Kardzhali, Bulgaria", 4, 1, 41.632100000000001, 25.379000000000001, "Awaiting driver assignment.", "Delivered", new DateTime(2024, 11, 6, 15, 40, 25, 547, DateTimeKind.Local).AddTicks(8150) },
                    { 5, "Burgas, Bulgaria", 5, 1, 42.504800000000003, 27.462599999999998, "Package left with neighbor.", "Booked", new DateTime(2024, 11, 7, 15, 40, 25, 547, DateTimeKind.Local).AddTicks(8152) }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "ClientCompanyId", "DeliveryId", "Description", "FileId", "InvoiceDate", "InvoiceNumber", "IsPaid" },
                values: new object[,]
                {
                    { 1, null, 1, "Invoice for Delivery 1", "", new DateTime(2024, 10, 29, 15, 40, 24, 345, DateTimeKind.Local).AddTicks(2744), "INV001", true },
                    { 2, null, 2, "Invoice for Delivery 2", "", new DateTime(2024, 10, 30, 15, 40, 24, 345, DateTimeKind.Local).AddTicks(2747), "INV002", false },
                    { 3, null, 3, "Invoice for Delivery 3", "", new DateTime(2024, 10, 31, 15, 40, 24, 345, DateTimeKind.Local).AddTicks(2750), "INV003", true },
                    { 4, null, 4, "Invoice for Delivery 4", "", new DateTime(2024, 11, 1, 15, 40, 24, 345, DateTimeKind.Local).AddTicks(2752), "INV004", false },
                    { 5, null, 5, "Invoice for Delivery 5", "", new DateTime(2024, 11, 2, 15, 40, 24, 345, DateTimeKind.Local).AddTicks(2755), "INV005", true }
                });

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
                name: "IX_CalendarEvents_ClientCompanyId",
                table: "CalendarEvents",
                column: "ClientCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CashRegisters_DeliveryId",
                table: "CashRegisters",
                column: "DeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientCompanies_AddressId",
                table: "ClientCompanies",
                column: "AddressId",
                unique: true);

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
                name: "IX_NonStandardCargos_RequestId",
                table: "NonStandardCargos",
                column: "RequestId");

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
                name: "IX_PricesPerSize_VehicleId",
                table: "PricesPerSize",
                column: "VehicleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_DeliveryId",
                table: "Ratings",
                column: "DeliveryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ClientCompanyId",
                table: "Requests",
                column: "ClientCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_DeliveryAddressId",
                table: "Requests",
                column: "DeliveryAddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_PickupAddressId",
                table: "Requests",
                column: "PickupAddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StandartCargos_RequestId",
                table: "StandartCargos",
                column: "RequestId",
                unique: true);
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
                name: "CalendarEvents");

            migrationBuilder.DropTable(
                name: "CashRegisters");

            migrationBuilder.DropTable(
                name: "DeliveryTrackings");

            migrationBuilder.DropTable(
                name: "FuelPrices");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "NonStandardCargos");

            migrationBuilder.DropTable(
                name: "PricesPerSize");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "StandartCargos");

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
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogiTrack.Infrastructure.Migrations
{
    public partial class SeededEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20ddc22c-ca6d-4feb-a688-0f31a430b5eb",
                column: "ConcurrencyStamp",
                value: "5f9bbf33-16e2-450a-b736-68851e735211");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27609f35-fbc8-4dc4-9d12-7ff2dd400327",
                column: "ConcurrencyStamp",
                value: "de1cd646-61e9-4395-95f3-2d95dc54fcb9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d000e64-c056-419a-950f-1992bd1e910d",
                column: "ConcurrencyStamp",
                value: "25a2977c-2ec4-494a-9a86-fbfdf0829a95");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99027aaa-d346-4dd9-a467-15d74576c080",
                column: "ConcurrencyStamp",
                value: "f3a35f93-e790-4aeb-a0a9-0bc56e1969ac");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20450cff-816f-49c8-9546-1c603aec0301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "447f6839-85b9-47fe-bfa3-a130b57bb0f8", "AQAAAAEAACcQAAAAED4D2hfLCyiUsyl0YipwT/HlMHH+rgKkUMNaJu4owgAch+k2r7EmV21rJaG+S827fQ==", "9ddb9007-223d-47ac-b2f5-a4ea08f30117" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e8be95a-186e-403b-b4aa-3874750a3563",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "63ad9b7b-222d-4ea5-a430-85a4c3dbaba1", "AQAAAAEAACcQAAAAEIr7oaOJGtDvTJPvqn0teMfuNakqeTQ45IUwjgFaSkAcXeTI6XkQeTEcCIUD/genkw==", "4ef3d021-cea3-4acc-b2f3-41a2f8e24c15" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38ba6810-2800-4ac8-b005-5c27e8248951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3c3021ed-d187-4ab5-982b-5713700f30bc", "AQAAAAEAACcQAAAAEChnf99yoeUrNQlthhG4916ZAZcu8bSeVdl5DXfSDMw/F8FipsM+nzsMpR+2V3WhjA==", "c7643214-584d-48d1-a8ed-6f6ba0410af6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6bab54d5-5a88-4128-92d2-4d12ad0baa32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "224e4285-a4d0-4fa6-96f2-3bdc1e11bb3e", "AQAAAAEAACcQAAAAEE/eL/uFbN3gJYj7pHD53tIk1a9sVJQTv9TNiWe6XRQe9gdeTFuE1Ono7ZyNVYrrZQ==", "3ee85ad1-6bee-4304-a682-bfaee861b101" });

            migrationBuilder.InsertData(
                table: "CalendarEvents",
                columns: new[] { "Id", "ClientCompanyId", "Date", "EventType", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 10, 24, 15, 53, 53, 16, DateTimeKind.Utc).AddTicks(7734), "Delivered", "Delivered goods" },
                    { 2, 1, new DateTime(2024, 9, 13, 15, 53, 53, 16, DateTimeKind.Utc).AddTicks(7734), "Pickup", "Picked up goods" },
                    { 3, 1, new DateTime(2024, 10, 26, 15, 53, 53, 16, DateTimeKind.Utc).AddTicks(7734), "Paid", "Paid delivery" }
                });

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateSubmitted",
                value: new DateTime(2024, 10, 23, 15, 53, 52, 248, DateTimeKind.Utc).AddTicks(3597));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateSubmitted",
                value: new DateTime(2024, 10, 23, 15, 53, 52, 248, DateTimeKind.Utc).AddTicks(3599));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 3, 18, 53, 52, 252, DateTimeKind.Local).AddTicks(5711));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 13, 18, 53, 52, 252, DateTimeKind.Local).AddTicks(5727));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1,
                column: "LicenseExpiryDate",
                value: new DateTime(2026, 10, 23, 15, 53, 52, 262, DateTimeKind.Utc).AddTicks(4744));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 2,
                column: "LicenseExpiryDate",
                value: new DateTime(2027, 10, 23, 15, 53, 52, 262, DateTimeKind.Utc).AddTicks(4747));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                column: "InvoiceDate",
                value: new DateTime(2024, 10, 23, 15, 53, 52, 993, DateTimeKind.Utc).AddTicks(7499));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 1,
                column: "OfferDate",
                value: new DateTime(2024, 10, 22, 15, 53, 52, 997, DateTimeKind.Utc).AddTicks(7494));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 23, 18, 53, 53, 4, DateTimeKind.Local).AddTicks(6488));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 23, 18, 53, 53, 4, DateTimeKind.Local).AddTicks(6519));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 23, 18, 53, 53, 4, DateTimeKind.Local).AddTicks(6527));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 23, 18, 53, 53, 4, DateTimeKind.Local).AddTicks(6531));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20ddc22c-ca6d-4feb-a688-0f31a430b5eb",
                column: "ConcurrencyStamp",
                value: "038b92dd-dbd1-4bd2-aa13-0e7411dd2bf2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27609f35-fbc8-4dc4-9d12-7ff2dd400327",
                column: "ConcurrencyStamp",
                value: "1e152977-d47a-4086-80e2-1d9a23e93462");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d000e64-c056-419a-950f-1992bd1e910d",
                column: "ConcurrencyStamp",
                value: "64fde655-758b-4ece-9fc7-bf8b5f265287");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99027aaa-d346-4dd9-a467-15d74576c080",
                column: "ConcurrencyStamp",
                value: "27825011-355d-43ff-9cd5-efe30acc6262");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20450cff-816f-49c8-9546-1c603aec0301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6ee0ea69-b5d9-4d74-9fb4-1cbd9b6ef42f", "AQAAAAEAACcQAAAAED+AaLaIlUt/Ry0sPhcm9Hmoo9B8hNqNi8ZbqFClle3kMF8iHykrYiBSjAl70hav3w==", "9246fc06-e781-4e32-a26b-e459b0624598" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e8be95a-186e-403b-b4aa-3874750a3563",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7f13b373-5e00-413a-ab2a-15d3be70f89b", "AQAAAAEAACcQAAAAEKW189JJjoO1sn2D8rJq3OF0eyuufevrdzZDmeh3LenbYhradcpbsuG7SNagGWOj5Q==", "c6503a8b-96e7-4e3d-a2ea-b8de067213d1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38ba6810-2800-4ac8-b005-5c27e8248951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "422a4416-972b-40b0-a349-824783847cd9", "AQAAAAEAACcQAAAAECOfV7RjKZ7gbXL/MV27aAn0vG3zR+idjdrZqpzqVgmtVIc+LuR1z8eBSnke9pysTA==", "2361f39c-f95f-4042-992a-e5acc71e2f4b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6bab54d5-5a88-4128-92d2-4d12ad0baa32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d6498b86-8b49-4a29-bd70-12dda5713f1c", "AQAAAAEAACcQAAAAEF2YJMEd81v00dT5cK1ymx6/m2Qqx3zHpJPrWgsBLmvQdZSPXNTCgKtU+AKULIVmrw==", "88c5bea1-813e-4850-a5b8-c3c70d283639" });

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateSubmitted",
                value: new DateTime(2024, 10, 23, 15, 51, 19, 726, DateTimeKind.Utc).AddTicks(1719));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateSubmitted",
                value: new DateTime(2024, 10, 23, 15, 51, 19, 726, DateTimeKind.Utc).AddTicks(1720));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 3, 18, 51, 19, 730, DateTimeKind.Local).AddTicks(9009));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 13, 18, 51, 19, 730, DateTimeKind.Local).AddTicks(9060));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1,
                column: "LicenseExpiryDate",
                value: new DateTime(2026, 10, 23, 15, 51, 19, 741, DateTimeKind.Utc).AddTicks(3908));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 2,
                column: "LicenseExpiryDate",
                value: new DateTime(2027, 10, 23, 15, 51, 19, 741, DateTimeKind.Utc).AddTicks(3911));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                column: "InvoiceDate",
                value: new DateTime(2024, 10, 23, 15, 51, 20, 302, DateTimeKind.Utc).AddTicks(2772));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 1,
                column: "OfferDate",
                value: new DateTime(2024, 10, 22, 15, 51, 20, 306, DateTimeKind.Utc).AddTicks(2755));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 23, 18, 51, 20, 313, DateTimeKind.Local).AddTicks(1682));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 23, 18, 51, 20, 313, DateTimeKind.Local).AddTicks(1716));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 23, 18, 51, 20, 313, DateTimeKind.Local).AddTicks(1728));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 23, 18, 51, 20, 313, DateTimeKind.Local).AddTicks(1731));
        }
    }
}

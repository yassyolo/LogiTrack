using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogiTrack.Infrastructure.Migrations
{
    public partial class Test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20ddc22c-ca6d-4feb-a688-0f31a430b5eb",
                column: "ConcurrencyStamp",
                value: "511a8721-d460-4e5a-886f-d9f885b56b41");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27609f35-fbc8-4dc4-9d12-7ff2dd400327",
                column: "ConcurrencyStamp",
                value: "23bd7423-8162-4570-a6a0-257b8120e721");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d000e64-c056-419a-950f-1992bd1e910d",
                column: "ConcurrencyStamp",
                value: "b89e7112-2467-40ec-9dbf-239d5c907bc3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99027aaa-d346-4dd9-a467-15d74576c080",
                column: "ConcurrencyStamp",
                value: "b15ff4d0-2d70-4c64-aaf5-9209076cc81f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20450cff-816f-49c8-9546-1c603aec0301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "60243133-60cf-46ec-8a05-1f5799b4c76f", "AQAAAAEAACcQAAAAEJg8wb9iMkNDQDyfn4W/E/MPvqxqbrNYdGouumjsUMyaDVL6Yp06SebQ0hll9RoHcA==", "7f239392-b787-45fa-bf64-307501e8f8a0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e8be95a-186e-403b-b4aa-3874750a3563",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e32354c5-6fd7-45ff-8db5-0efdcc29ad87", "AQAAAAEAACcQAAAAEB5CdeZvRkd11svFsg2S9ldKBA1ejHFoMNwrWuaW5iOqGbGg/hLaFtVYjkL5OUBUKA==", "910fb0ce-303e-4e54-8041-27f56240652c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38ba6810-2800-4ac8-b005-5c27e8248951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5cd45a6f-abaa-4b35-a80f-4dd106b39ad0", "AQAAAAEAACcQAAAAEBQ3DDFyMVjxFyImQJrbStz69hQ5fHuw1/i0ZrfnwwmKjgHACnm73K6awtMBvbQOdQ==", "ab1ecbb0-5d7a-4d8e-86c6-1d159345c37c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6bab54d5-5a88-4128-92d2-4d12ad0baa32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2a7cbf69-0f97-48ee-85c3-9c90bd0c731a", "AQAAAAEAACcQAAAAEDq677FfDnrsQNX9ROOHbN0Uo6nBK6fAikig2XwYIeKhANb/3k6e0mb93E2DScrTBg==", "31368372-704c-4c67-8b43-d62cd53fcd13" });

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateSubmitted",
                value: new DateTime(2024, 10, 23, 15, 44, 8, 240, DateTimeKind.Utc).AddTicks(4249));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateSubmitted",
                value: new DateTime(2024, 10, 23, 15, 44, 8, 240, DateTimeKind.Utc).AddTicks(4250));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 3, 18, 44, 8, 244, DateTimeKind.Local).AddTicks(8504));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 13, 18, 44, 8, 244, DateTimeKind.Local).AddTicks(8528));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1,
                column: "LicenseExpiryDate",
                value: new DateTime(2026, 10, 23, 15, 44, 8, 255, DateTimeKind.Utc).AddTicks(4121));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 2,
                column: "LicenseExpiryDate",
                value: new DateTime(2027, 10, 23, 15, 44, 8, 255, DateTimeKind.Utc).AddTicks(4124));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                column: "InvoiceDate",
                value: new DateTime(2024, 10, 23, 15, 44, 8, 828, DateTimeKind.Utc).AddTicks(2041));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 1,
                column: "OfferDate",
                value: new DateTime(2024, 10, 22, 15, 44, 8, 832, DateTimeKind.Utc).AddTicks(2481));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 23, 18, 44, 8, 839, DateTimeKind.Local).AddTicks(2110));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 23, 18, 44, 8, 839, DateTimeKind.Local).AddTicks(2203));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 23, 18, 44, 8, 839, DateTimeKind.Local).AddTicks(2216));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 23, 18, 44, 8, 839, DateTimeKind.Local).AddTicks(2220));
        }
    }
}

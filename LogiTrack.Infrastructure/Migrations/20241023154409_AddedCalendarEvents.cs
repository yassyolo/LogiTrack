using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogiTrack.Infrastructure.Migrations
{
    public partial class AddedCalendarEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_CalendarEvents_ClientCompanyId",
                table: "CalendarEvents",
                column: "ClientCompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalendarEvents");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20ddc22c-ca6d-4feb-a688-0f31a430b5eb",
                column: "ConcurrencyStamp",
                value: "7b6851ab-cf8c-409f-81b2-9fc1926952bd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27609f35-fbc8-4dc4-9d12-7ff2dd400327",
                column: "ConcurrencyStamp",
                value: "97748a7a-eda7-4328-9631-bb778c731345");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d000e64-c056-419a-950f-1992bd1e910d",
                column: "ConcurrencyStamp",
                value: "449e69f9-4a12-428f-af01-bdc58bbf7d56");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99027aaa-d346-4dd9-a467-15d74576c080",
                column: "ConcurrencyStamp",
                value: "fdd85c89-a196-4a36-b3bc-c333278d8a11");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20450cff-816f-49c8-9546-1c603aec0301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d08e1c48-e86e-4611-9a9f-f0e1be407a35", "AQAAAAEAACcQAAAAED0OYgzCy0CQ0FbYs+5EIGe2kw6mXY7dDMNm0+wL32lga926iG/3Er2LYfEn5lUYQw==", "f5b034bf-ae83-47e0-b444-030cb0f99807" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e8be95a-186e-403b-b4aa-3874750a3563",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "163c9515-bfd3-49bc-af11-f0e6a772dbea", "AQAAAAEAACcQAAAAEJ5jgZLj4iVr0RSAvEouV7Z1aqwU1942+QTcdDJeQfkCn09xvTmQPa6glIdQwNQrIg==", "3a29d64e-2b45-499c-ac9e-33761ee9e1a9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38ba6810-2800-4ac8-b005-5c27e8248951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4f3a3423-fe90-4e94-a6f9-5fc3bfd2302a", "AQAAAAEAACcQAAAAEP66qcs9+NX6lD+LEWORFLKTTWSmPCJ7e4T/5+/GuWI5s50ScYucJu2KhXMiZk5hAw==", "1b693ff6-3270-4d47-982f-dca0754ebeff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6bab54d5-5a88-4128-92d2-4d12ad0baa32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2ccaef5d-5453-4bad-abe1-ff482e2c4c32", "AQAAAAEAACcQAAAAEA3VSXK3slbTg3lDAEFaqC4Gsh/hcpd+F6hMI0/LTNLigILZ1ZsZUDCSgOyFxYdgQQ==", "ba9109c9-2829-46b2-b85e-22a9b6aaa97a" });

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateSubmitted",
                value: new DateTime(2024, 10, 21, 12, 22, 10, 765, DateTimeKind.Utc).AddTicks(5177));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateSubmitted",
                value: new DateTime(2024, 10, 21, 12, 22, 10, 765, DateTimeKind.Utc).AddTicks(5179));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 1, 15, 22, 10, 772, DateTimeKind.Local).AddTicks(438));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 11, 15, 22, 10, 772, DateTimeKind.Local).AddTicks(474));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1,
                column: "LicenseExpiryDate",
                value: new DateTime(2026, 10, 21, 12, 22, 10, 786, DateTimeKind.Utc).AddTicks(9285));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 2,
                column: "LicenseExpiryDate",
                value: new DateTime(2027, 10, 21, 12, 22, 10, 786, DateTimeKind.Utc).AddTicks(9290));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                column: "InvoiceDate",
                value: new DateTime(2024, 10, 21, 12, 22, 10, 882, DateTimeKind.Utc).AddTicks(8560));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 1,
                column: "OfferDate",
                value: new DateTime(2024, 10, 20, 12, 22, 10, 889, DateTimeKind.Utc).AddTicks(270));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 21, 15, 22, 10, 900, DateTimeKind.Local).AddTicks(6357));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 21, 15, 22, 10, 900, DateTimeKind.Local).AddTicks(6366));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 21, 15, 22, 10, 900, DateTimeKind.Local).AddTicks(6371));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 21, 15, 22, 10, 900, DateTimeKind.Local).AddTicks(6376));
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogiTrack.Infrastructure.Migrations
{
    public partial class AddedKilometersForRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Kilometers",
                table: "Requests",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

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
                column: "InvoiceDate",
                value: new DateTime(2024, 10, 26, 16, 8, 30, 748, DateTimeKind.Utc).AddTicks(6886));

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kilometers",
                table: "Requests");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20ddc22c-ca6d-4feb-a688-0f31a430b5eb",
                column: "ConcurrencyStamp",
                value: "4d13e632-fbac-4409-b2d0-93a1de4d50a1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27609f35-fbc8-4dc4-9d12-7ff2dd400327",
                column: "ConcurrencyStamp",
                value: "3c592bd8-614d-44b3-a50c-ed09e3903945");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d000e64-c056-419a-950f-1992bd1e910d",
                column: "ConcurrencyStamp",
                value: "32ce9816-6e0c-48a4-bba0-9cf5a36b8781");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99027aaa-d346-4dd9-a467-15d74576c080",
                column: "ConcurrencyStamp",
                value: "5033d770-66e8-4536-a4f2-055f8330493e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20450cff-816f-49c8-9546-1c603aec0301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d1c21c2c-24dd-4e21-a4f7-f6b3eb32de8a", "AQAAAAEAACcQAAAAEKzxm0CsATeP+3DlrLXHlIymhMRWqAEMClhWopfbo76jVmnBlWxIRzQ8rf9fqLv4YA==", "afbb9afa-dded-47eb-a1ae-b52a213eaaca" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e8be95a-186e-403b-b4aa-3874750a3563",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8131c858-f468-42e0-ad3a-d711edcabd57", "AQAAAAEAACcQAAAAEKv+LWeHK5UZ+tdiXNUl+pouUgGNvk9hjH0mIK1cmgRjdSHDmJOFN2zhx+GOc6/qyQ==", "aebb2a47-06b4-440e-b594-bd04f0c83df5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38ba6810-2800-4ac8-b005-5c27e8248951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "101a74cd-c6bc-43e3-9f79-320bed439e83", "AQAAAAEAACcQAAAAED4WS03K+pBeIEhjzuga0xmLIYK0n2naEtjJMM6Die2tOdFFLHs1qztaxTo+KIZbiA==", "7018e718-72bf-447a-9e68-011b631ee74a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6bab54d5-5a88-4128-92d2-4d12ad0baa32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a8272c76-00cc-44cb-881e-6ed2495d72dc", "AQAAAAEAACcQAAAAEI/O1bRHbM4NXa0aUNYCL17D0ySnDYSfie+JEIcP6gPzQqP/JnNEJXlCNKYo+aHokA==", "c56ed834-9178-43f1-8717-13686abf502f" });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 10, 26, 16, 43, 6, 68, DateTimeKind.Utc).AddTicks(6201));

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 9, 15, 16, 43, 6, 68, DateTimeKind.Utc).AddTicks(6201));

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 10, 28, 16, 43, 6, 68, DateTimeKind.Utc).AddTicks(6201));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateSubmitted",
                value: new DateTime(2024, 10, 25, 16, 43, 5, 280, DateTimeKind.Utc).AddTicks(7280));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateSubmitted",
                value: new DateTime(2024, 10, 25, 16, 43, 5, 280, DateTimeKind.Utc).AddTicks(7283));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 5, 19, 43, 5, 287, DateTimeKind.Local).AddTicks(5334));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 15, 19, 43, 5, 287, DateTimeKind.Local).AddTicks(5382));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1,
                column: "LicenseExpiryDate",
                value: new DateTime(2026, 10, 25, 16, 43, 5, 304, DateTimeKind.Utc).AddTicks(916));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 2,
                column: "LicenseExpiryDate",
                value: new DateTime(2027, 10, 25, 16, 43, 5, 304, DateTimeKind.Utc).AddTicks(937));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                column: "InvoiceDate",
                value: new DateTime(2024, 10, 25, 16, 43, 6, 40, DateTimeKind.Utc).AddTicks(9347));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 1,
                column: "OfferDate",
                value: new DateTime(2024, 10, 24, 16, 43, 6, 45, DateTimeKind.Utc).AddTicks(4643));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 25, 19, 43, 6, 54, DateTimeKind.Local).AddTicks(6119));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 25, 19, 43, 6, 54, DateTimeKind.Local).AddTicks(6166));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 25, 19, 43, 6, 54, DateTimeKind.Local).AddTicks(6197));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 25, 19, 43, 6, 54, DateTimeKind.Local).AddTicks(6202));
        }
    }
}

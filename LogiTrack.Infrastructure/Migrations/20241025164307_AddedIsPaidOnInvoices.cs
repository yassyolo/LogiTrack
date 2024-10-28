using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogiTrack.Infrastructure.Migrations
{
    public partial class AddedIsPaidOnInvoices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Width",
                table: "Requests",
                type: "float",
                nullable: true,
                comment: "Width of the goods",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "Width of the goods");

            migrationBuilder.AlterColumn<double>(
                name: "Length",
                table: "Requests",
                type: "float",
                nullable: true,
                comment: "Length of the goods",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "Length of the goods");

            migrationBuilder.AlterColumn<double>(
                name: "Height",
                table: "Requests",
                type: "float",
                nullable: true,
                comment: "Height of the goods",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "Height of the goods");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Invoice description");

            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                table: "Invoices",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Is invoice paid");

            migrationBuilder.AddColumn<int>(
                name: "DeliveryStep",
                table: "Deliveries",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                columns: new[] { "Description", "InvoiceDate" },
                values: new object[] { "", new DateTime(2024, 10, 25, 16, 43, 6, 40, DateTimeKind.Utc).AddTicks(9347) });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "DeliveryStep",
                table: "Deliveries");

            migrationBuilder.AlterColumn<int>(
                name: "Width",
                table: "Requests",
                type: "int",
                nullable: true,
                comment: "Width of the goods",
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true,
                oldComment: "Width of the goods");

            migrationBuilder.AlterColumn<int>(
                name: "Length",
                table: "Requests",
                type: "int",
                nullable: true,
                comment: "Length of the goods",
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true,
                oldComment: "Length of the goods");

            migrationBuilder.AlterColumn<int>(
                name: "Height",
                table: "Requests",
                type: "int",
                nullable: true,
                comment: "Height of the goods",
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true,
                oldComment: "Height of the goods");

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

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 10, 24, 15, 53, 53, 16, DateTimeKind.Utc).AddTicks(7734));

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 9, 13, 15, 53, 53, 16, DateTimeKind.Utc).AddTicks(7734));

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 10, 26, 15, 53, 53, 16, DateTimeKind.Utc).AddTicks(7734));

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
    }
}

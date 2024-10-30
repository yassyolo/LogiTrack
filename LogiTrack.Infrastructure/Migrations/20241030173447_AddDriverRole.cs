using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogiTrack.Infrastructure.Migrations
{
    public partial class AddDriverRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20ddc22c-ca6d-4feb-a688-0f31a430b5eb",
                column: "ConcurrencyStamp",
                value: "efb093d3-fa78-4c5e-b1b1-d147283fa35f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27609f35-fbc8-4dc4-9d12-7ff2dd400327",
                column: "ConcurrencyStamp",
                value: "4f2ac73f-42a3-4c7e-abf1-9946033a9ab6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d000e64-c056-419a-950f-1992bd1e910d",
                column: "ConcurrencyStamp",
                value: "342055a1-d3ca-43be-a5d6-09755e57eb65");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99027aaa-d346-4dd9-a467-15d74576c080",
                column: "ConcurrencyStamp",
                value: "5a6af522-1ef7-4aba-bcdb-3b27ac35d2cf");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "350868c0-bf0f-4f70-b4c9-155351bc6429", "a056c4e7-69a5-414f-89a7-25f19ec8097c", "Driver", "DRIVER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20450cff-816f-49c8-9546-1c603aec0301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5a837666-39de-43e9-872b-ad6d842063a3", "AQAAAAEAACcQAAAAEAHD5fxDFdCsT5fDmyFTRPxzXrdVJsvDE1bDPnRTfX36VQq0xQUZEHWZ42SBycCGEA==", "e70b5344-4538-45f4-bd49-3c23bcaf8130" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e8be95a-186e-403b-b4aa-3874750a3563",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "df90c9ab-e967-446e-b7c3-84324bd3117f", "AQAAAAEAACcQAAAAEHlbjNkqUo+fYrfhweWcrA8qjdVLGBRVJ4JG997FbcXQYLoAKsL3UrKBoGAoSzXkqg==", "d588fab7-be8a-414b-bf4b-6269c088d451" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38ba6810-2800-4ac8-b005-5c27e8248951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e6e4329f-2b6e-4b11-afc4-a3236178feb6", "AQAAAAEAACcQAAAAEN/S0Y+ZCYK9KldsKcLoESeH7sXMknjBUgu6tjgdQB0lxJg564f2VIKkADUeYovniQ==", "d24415c0-eb56-4dfd-a0e3-bd9799a7fe79" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6bab54d5-5a88-4128-92d2-4d12ad0baa32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3282f92b-9105-481e-b419-d954e5b4de55", "AQAAAAEAACcQAAAAEPOUWqnAIhLPVwOqSAx+yiRIg84xLGCtZOgHGj/rwNjIioRDUTf3WbP1oswdufl8KQ==", "1da329df-15e2-4e00-9ec5-143f4c399173" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f3b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b", 0, "f9d85ba4-c981-4ed4-84b9-232fe7701a42", "driver@example.com", true, false, null, null, null, "AQAAAAEAACcQAAAAEDidkBHNOb+G01syluWD59SgoXNomMchwBTyDH1YN6+3mTdKW5OTJThg7hHoZrFBbg==", null, false, "3888318a-543a-4527-aa2f-6c5b6b1aa6c2", false, "driver" });

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 10, 19, 34, 44, 763, DateTimeKind.Local).AddTicks(3198));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 20, 19, 34, 44, 763, DateTimeKind.Local).AddTicks(3233));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1,
                column: "LicenseExpiryDate",
                value: new DateTime(2026, 10, 30, 17, 34, 44, 772, DateTimeKind.Utc).AddTicks(8595));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "350868c0-bf0f-4f70-b4c9-155351bc6429", "f3b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "350868c0-bf0f-4f70-b4c9-155351bc6429", "f3b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "350868c0-bf0f-4f70-b4c9-155351bc6429");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20ddc22c-ca6d-4feb-a688-0f31a430b5eb",
                column: "ConcurrencyStamp",
                value: "82dc2d15-ff7c-47c4-93ca-7dec6ad75598");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27609f35-fbc8-4dc4-9d12-7ff2dd400327",
                column: "ConcurrencyStamp",
                value: "32abf858-9498-4595-b660-ad721d775b2f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d000e64-c056-419a-950f-1992bd1e910d",
                column: "ConcurrencyStamp",
                value: "1489fcaa-9685-4da4-babf-fead30ff1b1e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99027aaa-d346-4dd9-a467-15d74576c080",
                column: "ConcurrencyStamp",
                value: "84bb71f9-940f-4e07-942c-6acb07993016");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20450cff-816f-49c8-9546-1c603aec0301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8087c70d-5dcb-471e-a35a-161ef31cfc0a", "AQAAAAEAACcQAAAAEDMKBIP0yBoCZruZD6dkucaXGh1fvz+hG4rCgvvOSCWG1ZkKe58eeNHExgvzd7bbdw==", "e232110f-29bd-4a30-b0b8-9b90e1627530" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e8be95a-186e-403b-b4aa-3874750a3563",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7e38c56e-edd1-43d6-8c93-c78d67d9b5f5", "AQAAAAEAACcQAAAAEAIw+iQxurK/8zyvnQf9OC9nEJdl1vZWP5BAXfnv5hp6Nv9XGrd47df4DpGbHPvaAQ==", "fc8fd112-d48a-467d-82a8-0e9a682e52f8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38ba6810-2800-4ac8-b005-5c27e8248951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d1c671f2-735f-4d2f-884e-67da5bf5ca06", "AQAAAAEAACcQAAAAEGeASuXE2sMD5wXy51f6LZEAGJsmnAKfPl8kUAm0PMqeX3SBNBWv5YInLyr8/1SxoA==", "50bd3e0d-8b3d-4754-b126-149b0b405ea3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6bab54d5-5a88-4128-92d2-4d12ad0baa32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "446feff0-673c-4a2d-bfe5-b8242e947006", "AQAAAAEAACcQAAAAEMa01FR5ZksVwWf0UuxqzW+pWT5Lpx95FONQmMVWominO8r9cDQVwKmsWQh2gayGSA==", "b1a3d398-eb40-4787-93b0-a0edf75fef97" });

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 10, 19, 15, 56, 528, DateTimeKind.Local).AddTicks(4805));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 20, 19, 15, 56, 528, DateTimeKind.Local).AddTicks(4830));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1,
                column: "LicenseExpiryDate",
                value: new DateTime(2026, 10, 30, 17, 15, 56, 537, DateTimeKind.Utc).AddTicks(3092));
        }
    }
}

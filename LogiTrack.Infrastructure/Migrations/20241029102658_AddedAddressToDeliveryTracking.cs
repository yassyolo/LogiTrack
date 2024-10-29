using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogiTrack.Infrastructure.Migrations
{
    public partial class AddedAddressToDeliveryTracking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "DeliveryTrackings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateSubmitted",
                value: new DateTime(2024, 10, 29, 10, 26, 56, 31, DateTimeKind.Utc).AddTicks(8711));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateSubmitted",
                value: new DateTime(2024, 10, 29, 10, 26, 56, 31, DateTimeKind.Utc).AddTicks(8714));

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

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                column: "InvoiceDate",
                value: new DateTime(2024, 10, 29, 10, 26, 56, 544, DateTimeKind.Utc).AddTicks(4373));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 1,
                column: "OfferDate",
                value: new DateTime(2024, 10, 28, 10, 26, 56, 552, DateTimeKind.Utc).AddTicks(2306));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 29, 12, 26, 56, 564, DateTimeKind.Local).AddTicks(6086));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 29, 12, 26, 56, 564, DateTimeKind.Local).AddTicks(6167));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 29, 12, 26, 56, 564, DateTimeKind.Local).AddTicks(6258));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 29, 12, 26, 56, 564, DateTimeKind.Local).AddTicks(6266));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "DeliveryTrackings");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20ddc22c-ca6d-4feb-a688-0f31a430b5eb",
                column: "ConcurrencyStamp",
                value: "194f8719-72eb-48e0-91dc-59e0a664a893");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27609f35-fbc8-4dc4-9d12-7ff2dd400327",
                column: "ConcurrencyStamp",
                value: "6eee4351-e1f0-4bd3-a21c-f4ecead4dc09");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d000e64-c056-419a-950f-1992bd1e910d",
                column: "ConcurrencyStamp",
                value: "eb1f32d0-4d9a-4999-a347-0481b81c4422");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99027aaa-d346-4dd9-a467-15d74576c080",
                column: "ConcurrencyStamp",
                value: "0c62085c-ea0d-4abe-9799-0cc1acbb3892");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20450cff-816f-49c8-9546-1c603aec0301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "312d702f-7677-476f-b0d4-f6fcb398d90e", "AQAAAAEAACcQAAAAEF+5uArE9Q3yN0dUYaRtHKPa0p/nX2bfKxjGj8QGadL0NY0T1R5zQShVkDy+9+iZiQ==", "78e13e0a-2832-4c92-8af3-dedcbd3f3093" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2e8be95a-186e-403b-b4aa-3874750a3563",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "66729722-6c78-4e23-8fe8-36e2f3740466", "AQAAAAEAACcQAAAAEFPbtW/KNcXss72FwyinqpHbp4BH0L9VD0ObTZ96PvnbKgNMcJGv0770n6Vo+SwgsQ==", "2258fc05-ca51-492b-8287-5d425198c362" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38ba6810-2800-4ac8-b005-5c27e8248951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1a170280-4d10-494d-8e9c-1ae7beb4dc02", "AQAAAAEAACcQAAAAECc/01pjmLxMm9lsaVh5Zmj9FHzJUO9eAwk0Q9fJ3XvHpIIrybdXzKOYXPrsiCKTzQ==", "7489118c-8d6b-4bd0-a40d-7149209d9570" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6bab54d5-5a88-4128-92d2-4d12ad0baa32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7c4a8be0-87e0-4a06-a30c-7671b06ca1e0", "AQAAAAEAACcQAAAAEAa7HvrQHKJmGbTvPxJ3LlW9M3NA5YZRRe7Ua9rri+8xxVWJ1FkRtKw75w+hNJcgYg==", "3682aa95-cde8-4c2b-b0ee-6b46d6e16150" });

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 10, 29, 18, 5, 43, 279, DateTimeKind.Utc).AddTicks(8603));

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 9, 18, 18, 5, 43, 279, DateTimeKind.Utc).AddTicks(8603));

            migrationBuilder.UpdateData(
                table: "CalendarEvents",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 10, 31, 18, 5, 43, 279, DateTimeKind.Utc).AddTicks(8603));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateSubmitted",
                value: new DateTime(2024, 10, 28, 18, 5, 42, 401, DateTimeKind.Utc).AddTicks(3971));

            migrationBuilder.UpdateData(
                table: "CashRegisters",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateSubmitted",
                value: new DateTime(2024, 10, 28, 18, 5, 42, 401, DateTimeKind.Utc).AddTicks(3973));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 8, 20, 5, 42, 405, DateTimeKind.Local).AddTicks(8648));

            migrationBuilder.UpdateData(
                table: "ClientCompanies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 18, 20, 5, 42, 405, DateTimeKind.Local).AddTicks(8662));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1,
                column: "LicenseExpiryDate",
                value: new DateTime(2026, 10, 28, 18, 5, 42, 416, DateTimeKind.Utc).AddTicks(1431));

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 2,
                column: "LicenseExpiryDate",
                value: new DateTime(2027, 10, 28, 18, 5, 42, 416, DateTimeKind.Utc).AddTicks(1434));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                column: "InvoiceDate",
                value: new DateTime(2024, 10, 28, 18, 5, 43, 255, DateTimeKind.Utc).AddTicks(3799));

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 1,
                column: "OfferDate",
                value: new DateTime(2024, 10, 27, 18, 5, 43, 259, DateTimeKind.Utc).AddTicks(4489));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 28, 20, 5, 43, 267, DateTimeKind.Local).AddTicks(5172));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 28, 20, 5, 43, 267, DateTimeKind.Local).AddTicks(5210));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 28, 20, 5, 43, 267, DateTimeKind.Local).AddTicks(5226));

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 28, 20, 5, 43, 267, DateTimeKind.Local).AddTicks(5230));
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Data.Migrations
{
    public partial class CreateRoleEntityMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("921f7bb8-6edf-469a-8b49-e784d4d7f6b6"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9e969f71-4b19-4757-85f4-c03c6169289e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ed08be8d-49b3-4056-b266-c05ce9573d38"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("0e345309-84e6-44a2-a176-4c0cd82aff23"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("14a6f743-c8fa-4633-b82f-531be49529f1"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("23ed4b00-b7d3-492e-ab42-a6c42ccb0be8"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("58cd0035-c182-470c-9d86-6c32587a1d45"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("77ba1c5e-f2f3-4305-a548-2b5405e0e8e2"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("9b65b7c1-e7aa-4019-89f7-fc2b0bf3cbaf"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("d2c310cd-a572-4bae-9a1c-725ac2a67883"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("da516830-bb86-45e5-8896-454ff669b83e"), "db12afc0-175b-4ba2-ad15-6e04d5a41c4a", "SuperAdmin", "SUPERADMIN" },
                    { new Guid("105a1998-7a91-4537-80b8-91281a4dc991"), "67ffa612-85d3-4378-ae5a-00b38a11735c", "Admin", "ADMIN" },
                    { new Guid("056553c7-0632-4c51-b99d-6697bbba6f83"), "b340156f-69f9-4071-b378-eb836ec17165", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("cd1c06ee-e880-4142-8230-d58573045d8d"), "ავტობიოგრაფია" },
                    { new Guid("381d6e13-c7a3-42ac-9785-22bb4d040499"), "ბიოგრაფია" },
                    { new Guid("daad61b2-3380-42a3-853d-f4b33f2e9329"), "ბელეტრისტიკა" },
                    { new Guid("ee9f3bdc-c496-45b3-9c47-b36f49867d03"), "პროზა" },
                    { new Guid("18c8911d-bd80-466b-9f8a-179a79526037"), "რომანი" },
                    { new Guid("142771c0-5213-4184-a5d1-5295d4d427fe"), "დეტექტივი" },
                    { new Guid("3a8e0ac3-d011-49cc-834d-44d3ef1055a8"), "დრამა" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("056553c7-0632-4c51-b99d-6697bbba6f83"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("105a1998-7a91-4537-80b8-91281a4dc991"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("da516830-bb86-45e5-8896-454ff669b83e"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("142771c0-5213-4184-a5d1-5295d4d427fe"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("18c8911d-bd80-466b-9f8a-179a79526037"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("381d6e13-c7a3-42ac-9785-22bb4d040499"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("3a8e0ac3-d011-49cc-834d-44d3ef1055a8"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("cd1c06ee-e880-4142-8230-d58573045d8d"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("daad61b2-3380-42a3-853d-f4b33f2e9329"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("ee9f3bdc-c496-45b3-9c47-b36f49867d03"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("921f7bb8-6edf-469a-8b49-e784d4d7f6b6"), "9f8ed707-2273-44fe-a2de-e307c7501160", "SuperAdmin", "SUPERADMIN" },
                    { new Guid("9e969f71-4b19-4757-85f4-c03c6169289e"), "5d189b90-6d1d-491c-bc48-5fff7b34b868", "Admin", "ADMIN" },
                    { new Guid("ed08be8d-49b3-4056-b266-c05ce9573d38"), "37706b96-629a-4ee4-9e95-583d0672576a", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("77ba1c5e-f2f3-4305-a548-2b5405e0e8e2"), "ავტობიოგრაფია" },
                    { new Guid("9b65b7c1-e7aa-4019-89f7-fc2b0bf3cbaf"), "ბიოგრაფია" },
                    { new Guid("58cd0035-c182-470c-9d86-6c32587a1d45"), "ბელეტრისტიკა" },
                    { new Guid("d2c310cd-a572-4bae-9a1c-725ac2a67883"), "პროზა" },
                    { new Guid("14a6f743-c8fa-4633-b82f-531be49529f1"), "რომანი" },
                    { new Guid("23ed4b00-b7d3-492e-ab42-a6c42ccb0be8"), "დეტექტივი" },
                    { new Guid("0e345309-84e6-44a2-a176-4c0cd82aff23"), "დრამა" }
                });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Data.Migrations
{
    public partial class CreateBookShelveTableEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "BookShelve",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "NULL",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedAt",
                table: "BookShelve",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "NULL",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "BookShelve",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("cee356de-2ba8-4ac1-9cc6-498d2867920a"), "c5fd6a00-d5a8-4a8d-8ee4-56160fa8e494", "SuperAdmin", "SUPERADMIN" },
                    { new Guid("d6435d77-a103-4fce-b3ad-daef39e7bf36"), "8e387e5d-74e3-4d7b-acc3-37a9a4bae638", "Admin", "ADMIN" },
                    { new Guid("f99c3f89-9264-4edd-be30-e78b5490d896"), "e3075ca9-c69f-4e47-9147-26ea721e4538", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("063fac97-1c9b-46b3-be6c-40e7ac84ab27"), "ავტობიოგრაფია" },
                    { new Guid("ee46348f-9e92-4548-b544-425ecdb71959"), "ბიოგრაფია" },
                    { new Guid("0795f188-650e-4359-9a15-5da5fefd2f14"), "ბელეტრისტიკა" },
                    { new Guid("32126c56-c470-4939-9aa7-10b76e283aae"), "პროზა" },
                    { new Guid("e33cdbb9-f3b1-44e6-addb-877a8d99a816"), "რომანი" },
                    { new Guid("806dd329-958c-4e35-a5dd-e8bc1a225737"), "დეტექტივი" },
                    { new Guid("6ced4e9f-a014-4876-99bf-051df03c920a"), "დრამა" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookShelve_Id",
                table: "BookShelve",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BookShelve_Id",
                table: "BookShelve");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cee356de-2ba8-4ac1-9cc6-498d2867920a"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d6435d77-a103-4fce-b3ad-daef39e7bf36"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f99c3f89-9264-4edd-be30-e78b5490d896"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("063fac97-1c9b-46b3-be6c-40e7ac84ab27"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("0795f188-650e-4359-9a15-5da5fefd2f14"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("32126c56-c470-4939-9aa7-10b76e283aae"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("6ced4e9f-a014-4876-99bf-051df03c920a"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("806dd329-958c-4e35-a5dd-e8bc1a225737"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("e33cdbb9-f3b1-44e6-addb-877a8d99a816"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("ee46348f-9e92-4548-b544-425ecdb71959"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "BookShelve",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "NULL");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedAt",
                table: "BookShelve",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "NULL");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "BookShelve",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

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
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Data.Migrations
{
    public partial class CreateSectorTableEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                table: "Sector",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "NULL",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedAt",
                table: "Sector",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "NULL",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Sector",
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
                    { new Guid("d29f1e06-aed2-4d03-a80c-46e97c321377"), "b6f84dc5-0e0e-422a-abcd-f29911d5fb1a", "SuperAdmin", "SUPERADMIN" },
                    { new Guid("f538da19-a416-4c09-b27b-7545b648d578"), "aeb5d980-dbed-43a9-af07-27ca2889f2c5", "Admin", "ADMIN" },
                    { new Guid("6b7f9963-e09b-4e91-9d99-79dd917f4bfa"), "0f2327c7-eaf0-4a46-84c4-f52464ed937b", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("4683542f-311e-43dc-960b-238d0f859b99"), "ავტობიოგრაფია" },
                    { new Guid("32ffa870-b2a8-4334-9f1c-d868dae0e963"), "ბიოგრაფია" },
                    { new Guid("50df7129-14ed-4f92-83af-a8d961ec7bbb"), "ბელეტრისტიკა" },
                    { new Guid("f35dc5d6-691f-4a3e-8977-6d835138c25c"), "პროზა" },
                    { new Guid("c222f134-1e24-4c70-b552-4e7e490bf417"), "რომანი" },
                    { new Guid("2aed8960-dd9d-454b-a4fe-5ca91ecd693a"), "დეტექტივი" },
                    { new Guid("ffa817ab-5809-4c03-b654-46308267c47f"), "დრამა" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sector_Id",
                table: "Sector",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Sector_Id",
                table: "Sector");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6b7f9963-e09b-4e91-9d99-79dd917f4bfa"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d29f1e06-aed2-4d03-a80c-46e97c321377"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f538da19-a416-4c09-b27b-7545b648d578"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("2aed8960-dd9d-454b-a4fe-5ca91ecd693a"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("32ffa870-b2a8-4334-9f1c-d868dae0e963"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("4683542f-311e-43dc-960b-238d0f859b99"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("50df7129-14ed-4f92-83af-a8d961ec7bbb"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("c222f134-1e24-4c70-b552-4e7e490bf417"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("f35dc5d6-691f-4a3e-8977-6d835138c25c"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("ffa817ab-5809-4c03-b654-46308267c47f"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Sector",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "NULL");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedAt",
                table: "Sector",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "NULL");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Sector",
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
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Data.Migrations
{
    public partial class CreateGenreTableMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6365f89b-23ab-4842-9f70-17c849cbe510"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("90ced0d9-c6df-4b0d-87a9-38a5d6ca0fed"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b0190a1f-eeca-4242-b009-f247d42ac9ad"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Genre",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "NULL",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Genre",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedAt",
                table: "Genre",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "NULL",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Genre",
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

            migrationBuilder.CreateIndex(
                name: "IX_Genre_Id",
                table: "Genre",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Genre_Name",
                table: "Genre",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Genre_Id",
                table: "Genre");

            migrationBuilder.DropIndex(
                name: "IX_Genre_Name",
                table: "Genre");

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

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Genre",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "NULL");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Genre",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedAt",
                table: "Genre",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "NULL");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Genre",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("90ced0d9-c6df-4b0d-87a9-38a5d6ca0fed"), "9af7c74b-cded-4844-992c-bbce0cb50608", "SuperAdmin", "SUPERADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("b0190a1f-eeca-4242-b009-f247d42ac9ad"), "59f95da5-3c0f-4f11-9da3-575d88aab7a7", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("6365f89b-23ab-4842-9f70-17c849cbe510"), "5a8b6691-dca0-4be1-9230-4e949ce471ae", "User", "USER" });
        }
    }
}

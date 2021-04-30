using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Data.Migrations
{
    public partial class FinishedDatabaseModeling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0bfb4448-44c5-48e1-85dd-e7f50388008b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("57276aec-ae91-4704-a68f-b25eb72b3033"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("582981df-368b-4bb2-8b73-3a86864b1450"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("177bd4cb-ad16-4c74-bfc3-03c179572250"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("21e08f08-924c-492f-a506-9a9a1678ac0e"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("476245ee-e367-48b2-9831-5b0ef9a6d5e0"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("68da1090-4367-46d3-81b5-e00f62598674"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("84bc9227-f4a4-4f84-90e7-327ea9b864e7"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("8b703c1b-17d7-47f2-b996-58f3e726ff7e"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("e953f1c9-8c95-4267-aede-494a3d4127d1"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Sector",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Section",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "NULL",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedAt",
                table: "Section",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "NULL",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Section",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Customer",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "NULL",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Customer",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "IdentityNumber",
                table: "Customer",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Customer",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedAt",
                table: "Customer",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "NULL",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Customer",
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
                    { new Guid("87aab860-4113-4fb6-aed6-4a48a96a2969"), "0462dd23-a95c-420b-b59b-00cdbe27417a", "SuperAdmin", "SUPERADMIN" },
                    { new Guid("6cee0115-7f65-45c6-a8e6-3b27920741b1"), "c6c448e7-b4e2-4d9c-a2e8-0fb51f3946a2", "Admin", "ADMIN" },
                    { new Guid("745f267a-779c-4a62-ab44-54a02fa08980"), "09e709a1-b122-4651-b152-2da1a82329fd", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("66512934-d410-4dd6-a7b2-d858de8c5b4b"), "ავტობიოგრაფია" },
                    { new Guid("1fbbc2da-4dff-47f5-94e0-b1bb336f3474"), "ბიოგრაფია" },
                    { new Guid("eab7a555-0f43-4646-9c7e-66f9743d1453"), "ბელეტრისტიკა" },
                    { new Guid("20648d03-0bdd-4b9b-afb6-0e80925e41f2"), "პროზა" },
                    { new Guid("c94ed4fc-ed72-42f8-a51a-25ef053d379d"), "რომანი" },
                    { new Guid("f7ec91d4-7d07-444b-b760-90353e90b2b3"), "დეტექტივი" },
                    { new Guid("6ef016f5-2c77-4d0c-8857-37057ff4659f"), "დრამა" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sector_Name",
                table: "Sector",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Section_Id",
                table: "Section",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Id",
                table: "Customer",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_IdentityNumber_Phone_Email",
                table: "Customer",
                columns: new[] { "IdentityNumber", "Phone", "Email" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Sector_Name",
                table: "Sector");

            migrationBuilder.DropIndex(
                name: "IX_Section_Id",
                table: "Section");

            migrationBuilder.DropIndex(
                name: "IX_Customer_Id",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_IdentityNumber_Phone_Email",
                table: "Customer");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6cee0115-7f65-45c6-a8e6-3b27920741b1"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("745f267a-779c-4a62-ab44-54a02fa08980"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("87aab860-4113-4fb6-aed6-4a48a96a2969"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("1fbbc2da-4dff-47f5-94e0-b1bb336f3474"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("20648d03-0bdd-4b9b-afb6-0e80925e41f2"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("66512934-d410-4dd6-a7b2-d858de8c5b4b"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("6ef016f5-2c77-4d0c-8857-37057ff4659f"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("c94ed4fc-ed72-42f8-a51a-25ef053d379d"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("eab7a555-0f43-4646-9c7e-66f9743d1453"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("f7ec91d4-7d07-444b-b760-90353e90b2b3"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Sector",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Section",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "NULL");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedAt",
                table: "Section",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "NULL");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Section",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Customer",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "NULL");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "IdentityNumber",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedAt",
                table: "Customer",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "NULL");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Customer",
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
                    { new Guid("582981df-368b-4bb2-8b73-3a86864b1450"), "2ccf8b29-2cc2-4808-a53f-d819081f60bb", "SuperAdmin", "SUPERADMIN" },
                    { new Guid("0bfb4448-44c5-48e1-85dd-e7f50388008b"), "28654014-c106-4d0d-9af8-aea22e57f794", "Admin", "ADMIN" },
                    { new Guid("57276aec-ae91-4704-a68f-b25eb72b3033"), "27bcbebe-a885-4c0c-a633-d272ac21d10c", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("8b703c1b-17d7-47f2-b996-58f3e726ff7e"), "ავტობიოგრაფია" },
                    { new Guid("21e08f08-924c-492f-a506-9a9a1678ac0e"), "ბიოგრაფია" },
                    { new Guid("476245ee-e367-48b2-9831-5b0ef9a6d5e0"), "ბელეტრისტიკა" },
                    { new Guid("177bd4cb-ad16-4c74-bfc3-03c179572250"), "პროზა" },
                    { new Guid("e953f1c9-8c95-4267-aede-494a3d4127d1"), "რომანი" },
                    { new Guid("68da1090-4367-46d3-81b5-e00f62598674"), "დეტექტივი" },
                    { new Guid("84bc9227-f4a4-4f84-90e7-327ea9b864e7"), "დრამა" }
                });
        }
    }
}

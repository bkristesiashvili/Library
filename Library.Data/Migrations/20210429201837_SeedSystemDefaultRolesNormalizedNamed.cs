using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Data.Migrations
{
    public partial class SeedSystemDefaultRolesNormalizedNamed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("862aebdb-fe34-4414-848e-e6a7acc80895"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a733637e-57d4-413c-a76c-29aa9d5baec7"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b36ff38c-640a-4c81-81fa-9fb99c052dbc"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("b36ff38c-640a-4c81-81fa-9fb99c052dbc"), "89b506ac-bc03-425d-890f-b5e1b11effe0", "SuperAdmin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("a733637e-57d4-413c-a76c-29aa9d5baec7"), "fcaa4e36-3f3f-4605-bb25-b4837df6e18a", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("862aebdb-fe34-4414-848e-e6a7acc80895"), "ece33937-c63b-413c-aff8-1779cc66cbb9", "User", null });
        }
    }
}

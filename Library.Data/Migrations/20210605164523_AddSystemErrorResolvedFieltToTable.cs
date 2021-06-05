using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Data.Migrations
{
    public partial class AddSystemErrorResolvedFieltToTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("df856f47-a7f3-41e3-95d3-6a3e05b39d1b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f1e6c378-e921-4a60-a0d3-95fe559e98ba"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f6207010-df54-486e-9344-b1491e076214"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("1f163870-1636-4299-bf4e-e04428f615aa"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("20d870f7-7cc1-4211-bec8-647af3a1d040"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("24087776-0b96-456a-bb9f-50217a58faea"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("4d234d0f-8acb-416c-a67c-5759c2dfa25f"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("4f0d016a-02a1-412b-b658-d76adf124a92"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("68efc68f-78be-44a9-8343-eaeb5e6d7008"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("e09a315a-8d28-4b60-812e-48cc513e6d52"));

            migrationBuilder.AddColumn<bool>(
                name: "Resolved",
                table: "SystemErrors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("b5c4266c-3bcb-43e5-b349-e0f28245a3b3"), "34eaed3b-45a6-4b64-ada1-391771142618", "SuperAdmin", "SUPERADMIN" },
                    { new Guid("78fb2d47-9a88-4682-9861-7b42a8996c06"), "e69a2688-57dc-4c42-b082-5e58cae188a8", "Admin", "ADMIN" },
                    { new Guid("ffe2dd7f-89e5-49db-9a14-b39c97c03cf7"), "0b918cab-b98d-44f4-bd7d-761e3356c3bb", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("f79f7470-35cd-445b-acd3-865672a3ee1a"), "ავტობიოგრაფია" },
                    { new Guid("b21888ce-c428-46a7-8291-ed2720a21774"), "ბიოგრაფია" },
                    { new Guid("2d0c2981-8c16-4aaa-822b-e0f2f7f90842"), "ბელეტრისტიკა" },
                    { new Guid("0a3d8f34-b4eb-44fc-ba59-391b905a9487"), "პროზა" },
                    { new Guid("538da775-9f40-404a-be4b-f5c6084cbcbb"), "რომანი" },
                    { new Guid("306fdea3-d1a2-457e-9bdb-f180126929d9"), "დეტექტივი" },
                    { new Guid("d155a800-5d76-40d3-94e8-676ac9d7ebf1"), "დრამა" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("78fb2d47-9a88-4682-9861-7b42a8996c06"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b5c4266c-3bcb-43e5-b349-e0f28245a3b3"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ffe2dd7f-89e5-49db-9a14-b39c97c03cf7"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("0a3d8f34-b4eb-44fc-ba59-391b905a9487"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("2d0c2981-8c16-4aaa-822b-e0f2f7f90842"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("306fdea3-d1a2-457e-9bdb-f180126929d9"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("538da775-9f40-404a-be4b-f5c6084cbcbb"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("b21888ce-c428-46a7-8291-ed2720a21774"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("d155a800-5d76-40d3-94e8-676ac9d7ebf1"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("f79f7470-35cd-445b-acd3-865672a3ee1a"));

            migrationBuilder.DropColumn(
                name: "Resolved",
                table: "SystemErrors");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("f1e6c378-e921-4a60-a0d3-95fe559e98ba"), "cd3cbcf7-258f-4316-9844-87ee1f5def4b", "SuperAdmin", "SUPERADMIN" },
                    { new Guid("df856f47-a7f3-41e3-95d3-6a3e05b39d1b"), "a3eec40b-5376-43cc-aede-d5f631833728", "Admin", "ADMIN" },
                    { new Guid("f6207010-df54-486e-9344-b1491e076214"), "a894fdf1-d257-4263-a266-45197d2ba543", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("4f0d016a-02a1-412b-b658-d76adf124a92"), "ავტობიოგრაფია" },
                    { new Guid("e09a315a-8d28-4b60-812e-48cc513e6d52"), "ბიოგრაფია" },
                    { new Guid("1f163870-1636-4299-bf4e-e04428f615aa"), "ბელეტრისტიკა" },
                    { new Guid("4d234d0f-8acb-416c-a67c-5759c2dfa25f"), "პროზა" },
                    { new Guid("24087776-0b96-456a-bb9f-50217a58faea"), "რომანი" },
                    { new Guid("20d870f7-7cc1-4211-bec8-647af3a1d040"), "დეტექტივი" },
                    { new Guid("68efc68f-78be-44a9-8343-eaeb5e6d7008"), "დრამა" }
                });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Data.Migrations
{
    public partial class CreateSystemErrorTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0ded8b9f-f4f5-4efc-8bf0-c36b08a9e6de"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("39ea1bd0-9447-4118-9b46-aab89ec5d652"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a157b7df-80e9-4f6e-84e5-454653f45524"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("3cb31e7e-616c-46a1-a580-9b1331069dde"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("4e79ed20-3bd0-48bc-90af-695db9d69ec2"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("6ac546b2-d526-4748-b28d-027bc0f37bb9"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("71d82d0d-7bb5-4f8f-a426-24999201b92c"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("92928974-b761-451b-b655-00394fb1b7d5"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("b9b657fb-2d95-4c72-8bc2-66ae1ba1bd57"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("df6598de-7176-444b-ac4c-46c72b449b6b"));

            migrationBuilder.CreateTable(
                name: "SystemErrors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LogType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "NULL"),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "NULL")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemErrors", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SystemErrors");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("0ded8b9f-f4f5-4efc-8bf0-c36b08a9e6de"), "eca23c8b-b221-4235-8d7b-27d2f1958602", "SuperAdmin", "SUPERADMIN" },
                    { new Guid("a157b7df-80e9-4f6e-84e5-454653f45524"), "92fa0a14-0322-4a2f-a9cc-3d6e4ef70fce", "Admin", "ADMIN" },
                    { new Guid("39ea1bd0-9447-4118-9b46-aab89ec5d652"), "6cd2f399-2bef-4935-88c8-983fa04575d6", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("3cb31e7e-616c-46a1-a580-9b1331069dde"), "ავტობიოგრაფია" },
                    { new Guid("b9b657fb-2d95-4c72-8bc2-66ae1ba1bd57"), "ბიოგრაფია" },
                    { new Guid("df6598de-7176-444b-ac4c-46c72b449b6b"), "ბელეტრისტიკა" },
                    { new Guid("71d82d0d-7bb5-4f8f-a426-24999201b92c"), "პროზა" },
                    { new Guid("6ac546b2-d526-4748-b28d-027bc0f37bb9"), "რომანი" },
                    { new Guid("4e79ed20-3bd0-48bc-90af-695db9d69ec2"), "დეტექტივი" },
                    { new Guid("92928974-b761-451b-b655-00394fb1b7d5"), "დრამა" }
                });
        }
    }
}

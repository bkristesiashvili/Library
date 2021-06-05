using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Data.Migrations
{
    public partial class AddSystemErrorCommentFieldToTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "SystemErrors",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("ec70f4de-014a-45e4-b804-99b72c78ba9e"), "0bfe76ad-9035-41db-8386-12cd8273fa5e", "SuperAdmin", "SUPERADMIN" },
                    { new Guid("c7e3137f-c8f0-4ab2-938f-0cf1216124c5"), "e1c08ba1-d71e-419a-a245-23b8ce8c4e0e", "Admin", "ADMIN" },
                    { new Guid("fb0a0647-61a6-4d04-9a98-9805cd0a2f0f"), "b7177ed1-cfe5-4e85-ae12-598af65a4d43", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("c6f7a14f-fa81-4cc7-a82a-17a965b0b1ba"), "ავტობიოგრაფია" },
                    { new Guid("d936fbb2-e5b1-433c-bb23-dfff74e93dfa"), "ბიოგრაფია" },
                    { new Guid("4f9355c8-d59b-4a1a-a66a-403e2fbe637f"), "ბელეტრისტიკა" },
                    { new Guid("d03900fa-0f6d-4a32-8a6b-b3c2d807f9cd"), "პროზა" },
                    { new Guid("50d87a96-c184-489f-8fa2-9becac53fa7f"), "რომანი" },
                    { new Guid("4e5a6084-0e93-4bcd-97cf-bfb0bac3ce5b"), "დეტექტივი" },
                    { new Guid("c5d28e85-b5bf-456e-9b6c-c4a7331aa328"), "დრამა" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c7e3137f-c8f0-4ab2-938f-0cf1216124c5"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ec70f4de-014a-45e4-b804-99b72c78ba9e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fb0a0647-61a6-4d04-9a98-9805cd0a2f0f"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("4e5a6084-0e93-4bcd-97cf-bfb0bac3ce5b"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("4f9355c8-d59b-4a1a-a66a-403e2fbe637f"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("50d87a96-c184-489f-8fa2-9becac53fa7f"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("c5d28e85-b5bf-456e-9b6c-c4a7331aa328"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("c6f7a14f-fa81-4cc7-a82a-17a965b0b1ba"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("d03900fa-0f6d-4a32-8a6b-b3c2d807f9cd"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("d936fbb2-e5b1-433c-bb23-dfff74e93dfa"));

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "SystemErrors");

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
    }
}

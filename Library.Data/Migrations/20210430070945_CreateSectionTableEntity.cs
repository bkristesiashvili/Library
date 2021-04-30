using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Data.Migrations
{
    public partial class CreateSectionTableEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("91c20d46-cc5e-44f4-b368-e906ffac5079"), "f2cc9db0-a6ee-4e01-8ddc-358928273c54", "SuperAdmin", "SUPERADMIN" },
                    { new Guid("c8d2e12f-155b-4cd3-85ce-b3176d5ff023"), "588b0cfa-18d3-45a5-8237-ef1d0d96f3db", "Admin", "ADMIN" },
                    { new Guid("4481b95d-fd16-4414-abd6-b5a66bcc1d87"), "f9d7fd1c-4d36-4f7a-b67b-d949f6e37b4a", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("80c0994b-fc7b-4354-be72-db9fe634a75e"), "ავტობიოგრაფია" },
                    { new Guid("52a697b9-130f-417c-a222-05c7feaa82b5"), "ბიოგრაფია" },
                    { new Guid("59a9e17e-531d-49b5-a08b-9ff61fc28d49"), "ბელეტრისტიკა" },
                    { new Guid("22c72a7f-1dd1-4b20-aca8-a9e555e447ff"), "პროზა" },
                    { new Guid("60631b09-db77-471d-9403-bbca652f0a4c"), "რომანი" },
                    { new Guid("6927100a-37dd-4445-98c7-940aec342934"), "დეტექტივი" },
                    { new Guid("46fd5ce4-caa2-44a9-9e11-5bc2150cac85"), "დრამა" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4481b95d-fd16-4414-abd6-b5a66bcc1d87"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("91c20d46-cc5e-44f4-b368-e906ffac5079"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c8d2e12f-155b-4cd3-85ce-b3176d5ff023"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("22c72a7f-1dd1-4b20-aca8-a9e555e447ff"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("46fd5ce4-caa2-44a9-9e11-5bc2150cac85"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("52a697b9-130f-417c-a222-05c7feaa82b5"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("59a9e17e-531d-49b5-a08b-9ff61fc28d49"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("60631b09-db77-471d-9403-bbca652f0a4c"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("6927100a-37dd-4445-98c7-940aec342934"));

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: new Guid("80c0994b-fc7b-4354-be72-db9fe634a75e"));

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
        }
    }
}

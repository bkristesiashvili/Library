using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Data.Migrations
{
    public partial class ChangeBorrowStatusDefaultValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HeThongQuanLyCongTacKhaoThi.Data.Migrations
{
    public partial class FixDatetimeNofitication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime",
                table: "NOTIFICATION",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 5, 5, 16, 19, 28, 190, DateTimeKind.Local).AddTicks(8168));

            migrationBuilder.UpdateData(
                table: "ACCOUNT",
                keyColumn: "Id",
                keyValue: new Guid("4a2d9b6e-97c4-41bd-a929-f778972db109"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "56c612f9-ba17-4aeb-be8d-322b98324d1c", "AQAAAAEAACcQAAAAEEe/XRpPf8r1cwYUaAdqjwIjIoP+Nj86ch+U8iltlW05eFgU2DBsdAxwcyUl8GZwwg==" });

            migrationBuilder.UpdateData(
                table: "ACCOUNT",
                keyColumn: "Id",
                keyValue: new Guid("8bc30f33-6382-45fd-a54a-0dec677631d9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "eb22da46-d7cb-43f3-97e1-87171800f84e", "AQAAAAEAACcQAAAAEKPRPolEJRoWyAG54O5xNBNGLPRYRYpXc3fIrOZrR2ktzeYZwIgdzXILo4tgE9d6Tg==" });

            migrationBuilder.UpdateData(
                table: "ACCOUNT",
                keyColumn: "Id",
                keyValue: new Guid("9e7773ef-083c-4a8e-8ed2-9e36cd704913"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "79f3c59a-7a10-4f3e-bc30-bc8e2d85c472", "AQAAAAEAACcQAAAAEPJlxzhhh94Itd1MUK7ugg4//ZdpBdl8nW+A5dalrfpRIL2Sxsw0bg+fEEGk3pFw1g==" });

            migrationBuilder.UpdateData(
                table: "ACCOUNT",
                keyColumn: "Id",
                keyValue: new Guid("efe5c78c-bbc5-40e5-a106-1f07d4b4fcdb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "14769004-6589-4421-a6ed-7056ea201cc1", "AQAAAAEAACcQAAAAEPIioNTqJ/rQlmI1oKJel7i3Xuv26wFwO3p9zarePd0JWvr4GK5T11+D2pcGmiGQPQ==" });

            migrationBuilder.UpdateData(
                table: "ROLE",
                keyColumn: "Id",
                keyValue: new Guid("1e6d489f-1df4-4dab-b873-ce3224d87f94"),
                column: "ConcurrencyStamp",
                value: "803e035b-b25e-4127-afb6-a5eca042e676");

            migrationBuilder.UpdateData(
                table: "ROLE",
                keyColumn: "Id",
                keyValue: new Guid("61a4fad5-402c-4ce0-845d-1fbd2b91956f"),
                column: "ConcurrencyStamp",
                value: "37636680-7ad8-48d3-b872-0ab67223af8b");

            migrationBuilder.UpdateData(
                table: "ROLE",
                keyColumn: "Id",
                keyValue: new Guid("9a34bdd4-fa97-4e2f-9960-b19a68826be9"),
                column: "ConcurrencyStamp",
                value: "22cfb2aa-eb8a-49f2-bf34-ebba65c64bee");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime",
                table: "NOTIFICATION",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 5, 5, 16, 19, 28, 190, DateTimeKind.Local).AddTicks(8168),
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getdate()");

            migrationBuilder.UpdateData(
                table: "ACCOUNT",
                keyColumn: "Id",
                keyValue: new Guid("4a2d9b6e-97c4-41bd-a929-f778972db109"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e05399ce-40a9-46e5-a768-6fe0da3d5553", "AQAAAAEAACcQAAAAEGJCTPkxhLcYvXqRn7oFzYAr2RmZ5ZP0SC4E4o27UJj/6XMIIWtz3Nvce7M8FeUgjg==" });

            migrationBuilder.UpdateData(
                table: "ACCOUNT",
                keyColumn: "Id",
                keyValue: new Guid("8bc30f33-6382-45fd-a54a-0dec677631d9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1e48af8e-4154-43e9-9891-113ba512bb4f", "AQAAAAEAACcQAAAAEHYlfT8+RgCgOBWWz/HBA4IN6mXL5XMCZv/mfYxYktOvI0DEJBA9QMLWFi3oC3qcIg==" });

            migrationBuilder.UpdateData(
                table: "ACCOUNT",
                keyColumn: "Id",
                keyValue: new Guid("9e7773ef-083c-4a8e-8ed2-9e36cd704913"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4710478e-d8d9-4b63-9145-dfb32dd3c22a", "AQAAAAEAACcQAAAAEAOEP7MshOSLne9GA2WjR3APRmXNAU4y462/9HhRCMzJC2GNVwVynKm3ftN4Qz3Ouw==" });

            migrationBuilder.UpdateData(
                table: "ACCOUNT",
                keyColumn: "Id",
                keyValue: new Guid("efe5c78c-bbc5-40e5-a106-1f07d4b4fcdb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "87f7500c-13ab-4d9a-b74f-29fe6f8c662f", "AQAAAAEAACcQAAAAENsmXRBFCgI6e9x8/9x4giBtkU9ACueNmLjlA6QzkYA/0AiMFf9us0AKkX+7HWW0DQ==" });

            migrationBuilder.UpdateData(
                table: "ROLE",
                keyColumn: "Id",
                keyValue: new Guid("1e6d489f-1df4-4dab-b873-ce3224d87f94"),
                column: "ConcurrencyStamp",
                value: "9016cdb4-5e75-4db1-b958-566432b1d7d8");

            migrationBuilder.UpdateData(
                table: "ROLE",
                keyColumn: "Id",
                keyValue: new Guid("61a4fad5-402c-4ce0-845d-1fbd2b91956f"),
                column: "ConcurrencyStamp",
                value: "c0695c2a-2e30-4c57-89a4-87b30f92a406");

            migrationBuilder.UpdateData(
                table: "ROLE",
                keyColumn: "Id",
                keyValue: new Guid("9a34bdd4-fa97-4e2f-9960-b19a68826be9"),
                column: "ConcurrencyStamp",
                value: "5a3d97c4-75b5-4ac1-9df1-606344250e0e");
        }
    }
}

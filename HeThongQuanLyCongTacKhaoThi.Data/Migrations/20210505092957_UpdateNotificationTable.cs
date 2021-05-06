using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HeThongQuanLyCongTacKhaoThi.Data.Migrations
{
    public partial class UpdateNotificationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SubjectID",
                table: "NOTIFICATION",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<int>(
                name: "StudentAnswerID",
                table: "NOTIFICATION",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "ACCOUNT",
                keyColumn: "Id",
                keyValue: new Guid("4a2d9b6e-97c4-41bd-a929-f778972db109"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7b62dc57-3864-4dcc-bfe4-706462a2bb5c", "AQAAAAEAACcQAAAAEGnRAM04c44G/aNzKAegi5GnoBam/dimcSI7CgSdSJpVmBBdmFJxjfBvJAQ/+hqaVw==" });

            migrationBuilder.UpdateData(
                table: "ACCOUNT",
                keyColumn: "Id",
                keyValue: new Guid("8bc30f33-6382-45fd-a54a-0dec677631d9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1cb9b86c-4d52-49fe-bc30-6bf9b4ba2584", "AQAAAAEAACcQAAAAEB2upcPqr5ND23tl2lQRbQwym31FPHe3eJ1hOTnU4x66Z0M6VxI0AQQDayRgGeKEww==" });

            migrationBuilder.UpdateData(
                table: "ACCOUNT",
                keyColumn: "Id",
                keyValue: new Guid("9e7773ef-083c-4a8e-8ed2-9e36cd704913"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "684f8819-29e1-4fab-90c1-71a846b76171", "AQAAAAEAACcQAAAAEGHBWr6LTPxEDvS4ak66/wf4AvblkG2E2LNIEgAnuwDdgyWo8hp4RQIAa63tmQSQig==" });

            migrationBuilder.UpdateData(
                table: "ACCOUNT",
                keyColumn: "Id",
                keyValue: new Guid("efe5c78c-bbc5-40e5-a106-1f07d4b4fcdb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e35444ea-1fde-4321-ae68-c1d984e6219b", "AQAAAAEAACcQAAAAEF/nWHQfLuBP4GDOGP2dRmX1vmBbWM7li7Mp50SNzRZETlGXCwLOX8LkTU7xTjdvCg==" });

            migrationBuilder.UpdateData(
                table: "ROLE",
                keyColumn: "Id",
                keyValue: new Guid("1e6d489f-1df4-4dab-b873-ce3224d87f94"),
                column: "ConcurrencyStamp",
                value: "d09dd46a-c257-411d-b45f-c56984ab7bd8");

            migrationBuilder.UpdateData(
                table: "ROLE",
                keyColumn: "Id",
                keyValue: new Guid("61a4fad5-402c-4ce0-845d-1fbd2b91956f"),
                column: "ConcurrencyStamp",
                value: "1c4ecf35-cf75-48eb-a6b6-dad548909cbc");

            migrationBuilder.UpdateData(
                table: "ROLE",
                keyColumn: "Id",
                keyValue: new Guid("9a34bdd4-fa97-4e2f-9960-b19a68826be9"),
                column: "ConcurrencyStamp",
                value: "fd3f7365-43d3-4f59-b2e1-414310488a3b");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SubjectID",
                table: "NOTIFICATION",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StudentAnswerID",
                table: "NOTIFICATION",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValue: 0);

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
    }
}

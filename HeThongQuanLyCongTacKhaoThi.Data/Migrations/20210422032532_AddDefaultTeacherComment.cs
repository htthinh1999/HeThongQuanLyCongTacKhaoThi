using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HeThongQuanLyCongTacKhaoThi.Data.Migrations
{
    public partial class AddDefaultTeacherComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Teacher2Comment",
                table: "STUDENT_ANSWER_DETAIL",
                nullable: true,
                defaultValue: "Chưa có nhận xét!",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Teacher1Comment",
                table: "STUDENT_ANSWER_DETAIL",
                nullable: true,
                defaultValue: "Chưa có nhận xét!",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "ACCOUNT",
                keyColumn: "Id",
                keyValue: new Guid("4a2d9b6e-97c4-41bd-a929-f778972db109"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "70e3dc61-3a67-43ba-b73e-bb38e7ed45c4", "AQAAAAEAACcQAAAAEBqhSo15lnBTLB7XiStK2gZ0saWQagXEl+ER+ejj4UBTKiT42+bB3e9Ml3Q0/k3SnA==" });

            migrationBuilder.UpdateData(
                table: "ACCOUNT",
                keyColumn: "Id",
                keyValue: new Guid("8bc30f33-6382-45fd-a54a-0dec677631d9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2f38f2db-013b-409e-b897-4bd14b42bd4b", "AQAAAAEAACcQAAAAEIqfOGIOImJfBNsir+7sTGBDNOQqFHHv0MgFUyFIN9kTfiOgxnhVRMftdKHdXo3tjg==" });

            migrationBuilder.UpdateData(
                table: "ACCOUNT",
                keyColumn: "Id",
                keyValue: new Guid("9e7773ef-083c-4a8e-8ed2-9e36cd704913"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "889f4fe5-491b-4e98-a938-44dd147b6fc1", "AQAAAAEAACcQAAAAEHF4rKc0DSXWPl7Rh7K6wo2zdAGvBMWKV7jg4Tn+KLSl3S2YpsnWZvAq0H+YKX8FhQ==" });

            migrationBuilder.UpdateData(
                table: "ACCOUNT",
                keyColumn: "Id",
                keyValue: new Guid("efe5c78c-bbc5-40e5-a106-1f07d4b4fcdb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "304bb0d0-5a5c-439c-9ed7-dbb699e4182d", "AQAAAAEAACcQAAAAEHonaD7CGEo6EK6sfQh54rOl/CASwx+BfeJ/epsoLfJqwEzjrvH45ygXFiXG4siOuA==" });

            migrationBuilder.UpdateData(
                table: "ROLE",
                keyColumn: "Id",
                keyValue: new Guid("1e6d489f-1df4-4dab-b873-ce3224d87f94"),
                column: "ConcurrencyStamp",
                value: "b767ffdd-3d1c-4c05-a259-c61e9eb487b9");

            migrationBuilder.UpdateData(
                table: "ROLE",
                keyColumn: "Id",
                keyValue: new Guid("61a4fad5-402c-4ce0-845d-1fbd2b91956f"),
                column: "ConcurrencyStamp",
                value: "b20a6930-f4d6-4e25-ad05-4bf56b614986");

            migrationBuilder.UpdateData(
                table: "ROLE",
                keyColumn: "Id",
                keyValue: new Guid("9a34bdd4-fa97-4e2f-9960-b19a68826be9"),
                column: "ConcurrencyStamp",
                value: "dc9dac44-3a85-4afc-aae4-f9f480abbc46");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Teacher2Comment",
                table: "STUDENT_ANSWER_DETAIL",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true,
                oldDefaultValue: "Chưa có nhận xét!");

            migrationBuilder.AlterColumn<string>(
                name: "Teacher1Comment",
                table: "STUDENT_ANSWER_DETAIL",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true,
                oldDefaultValue: "Chưa có nhận xét!");

            migrationBuilder.UpdateData(
                table: "ACCOUNT",
                keyColumn: "Id",
                keyValue: new Guid("4a2d9b6e-97c4-41bd-a929-f778972db109"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2567a79b-bfa0-42b3-b107-a14ebcbc88bf", "AQAAAAEAACcQAAAAEA27/o9uHE2sC3oeLTD/igz3uPmJXS1OmsCqZR+0n76w6mSi/F7exH1bJrMfpNDg9Q==" });

            migrationBuilder.UpdateData(
                table: "ACCOUNT",
                keyColumn: "Id",
                keyValue: new Guid("8bc30f33-6382-45fd-a54a-0dec677631d9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "694bfc85-61dd-42c6-978f-5c89eea50097", "AQAAAAEAACcQAAAAEJ3iu8vrgBkUEiS5jr9Wd//GbF0wCDa6glLJstl8ISHjTQQg/UQL0Aok2co1RClZxg==" });

            migrationBuilder.UpdateData(
                table: "ACCOUNT",
                keyColumn: "Id",
                keyValue: new Guid("9e7773ef-083c-4a8e-8ed2-9e36cd704913"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ad9cb337-e654-4263-b793-339f1199d47b", "AQAAAAEAACcQAAAAEHDGwqCeqy32Uhmvsw88hPDpY4OECa6AqQKCRnY1eRg6PH8o5WYy2LJjzOeBqovLzA==" });

            migrationBuilder.UpdateData(
                table: "ACCOUNT",
                keyColumn: "Id",
                keyValue: new Guid("efe5c78c-bbc5-40e5-a106-1f07d4b4fcdb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "82f6897c-2adc-4085-a10a-bf45461f63e8", "AQAAAAEAACcQAAAAENbpjGW7tg4R7k6R7xlmH295J7uZio0zbPCBFVmzHCxjoEP5JdUrAsEVlzqa0yXGtg==" });

            migrationBuilder.UpdateData(
                table: "ROLE",
                keyColumn: "Id",
                keyValue: new Guid("1e6d489f-1df4-4dab-b873-ce3224d87f94"),
                column: "ConcurrencyStamp",
                value: "a14f557d-7778-453c-80e4-b18faa3e6523");

            migrationBuilder.UpdateData(
                table: "ROLE",
                keyColumn: "Id",
                keyValue: new Guid("61a4fad5-402c-4ce0-845d-1fbd2b91956f"),
                column: "ConcurrencyStamp",
                value: "56812a60-a93e-4c2e-ba2d-32b2a5d9bc94");

            migrationBuilder.UpdateData(
                table: "ROLE",
                keyColumn: "Id",
                keyValue: new Guid("9a34bdd4-fa97-4e2f-9960-b19a68826be9"),
                column: "ConcurrencyStamp",
                value: "757bcdde-81bd-4455-b527-44ed1fd1788f");
        }
    }
}

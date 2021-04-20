using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HeThongQuanLyCongTacKhaoThi.Data.Migrations
{
    public partial class RedesignDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ROLE_ACCOUNT");

            migrationBuilder.CreateTable(
                name: "ROLE",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Description = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLE", x => x.Id);
                });

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

            migrationBuilder.InsertData(
                table: "ROLE",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("61a4fad5-402c-4ce0-845d-1fbd2b91956f"), "56812a60-a93e-4c2e-ba2d-32b2a5d9bc94", "Vai trò quản trị viên", "Admin", "admin" },
                    { new Guid("1e6d489f-1df4-4dab-b873-ce3224d87f94"), "a14f557d-7778-453c-80e4-b18faa3e6523", "Vai trò giảng viên", "Teacher", "teacher" },
                    { new Guid("9a34bdd4-fa97-4e2f-9960-b19a68826be9"), "757bcdde-81bd-4455-b527-44ed1fd1788f", "Vai trò học viên", "Student", "student" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ROLE");

            migrationBuilder.CreateTable(
                name: "ROLE_ACCOUNT",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLE_ACCOUNT", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "ACCOUNT",
                keyColumn: "Id",
                keyValue: new Guid("4a2d9b6e-97c4-41bd-a929-f778972db109"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c7d2a329-0fc0-4f5f-b269-244c736d8054", "AQAAAAEAACcQAAAAEFuWynppxV0IAqbB5nBze9H0pFGrac8r3PA9ja2c+Uw5Guck0Xn/7pkLTY8NWjL1JA==" });

            migrationBuilder.UpdateData(
                table: "ACCOUNT",
                keyColumn: "Id",
                keyValue: new Guid("8bc30f33-6382-45fd-a54a-0dec677631d9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cbfec896-34fc-4784-951f-f352e3f4903d", "AQAAAAEAACcQAAAAEFmrDEiXNR+CUz0ORjdvXdmHOJ3YvChDN0Uo2HOOvPTTDI9PQq9sCxDMVno3QmxCGA==" });

            migrationBuilder.UpdateData(
                table: "ACCOUNT",
                keyColumn: "Id",
                keyValue: new Guid("9e7773ef-083c-4a8e-8ed2-9e36cd704913"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3fe4d8fd-641e-4c1e-898f-bcc8133c835f", "AQAAAAEAACcQAAAAEMiwblurtGqYBPKXkWQFJNDhqZEbgHDFu8zsMrjP0Gb1IgY7EqmdbgbbjIplRcbpDw==" });

            migrationBuilder.UpdateData(
                table: "ACCOUNT",
                keyColumn: "Id",
                keyValue: new Guid("efe5c78c-bbc5-40e5-a106-1f07d4b4fcdb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "494b1860-6238-478b-96b9-f50cd3ef9cb8", "AQAAAAEAACcQAAAAELdZPwUMQzzWlLVgIKmN6mgmNQloPSbZBLvNBHOcnhW0AaYw8+Xc3+8HVeamIg+v2A==" });

            migrationBuilder.InsertData(
                table: "ROLE_ACCOUNT",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("61a4fad5-402c-4ce0-845d-1fbd2b91956f"), "5c88f114-df60-4cb1-9bce-2625b69745a0", "Vai trò quản trị viên", "Admin", "admin" },
                    { new Guid("1e6d489f-1df4-4dab-b873-ce3224d87f94"), "b097fffe-325a-421d-9425-2c4e49052249", "Vai trò giảng viên", "Teacher", "teacher" },
                    { new Guid("9a34bdd4-fa97-4e2f-9960-b19a68826be9"), "82fbbd0b-8e0a-421b-9205-a4e498c6b486", "Vai trò học viên", "Student", "student" }
                });
        }
    }
}

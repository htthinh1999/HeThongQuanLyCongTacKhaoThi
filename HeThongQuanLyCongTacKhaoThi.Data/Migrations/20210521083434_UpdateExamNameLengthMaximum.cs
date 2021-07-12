using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HeThongQuanLyCongTacKhaoThi.Data.Migrations
{
    public partial class UpdateExamNameLengthMaximum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "EXAM",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.UpdateData(
                table: "ACCOUNT",
                keyColumn: "Id",
                keyValue: new Guid("4a2d9b6e-97c4-41bd-a929-f778972db109"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9f5c8e36-62c2-4cae-8afd-9e8a925c8667", "AQAAAAEAACcQAAAAEI8JE49PXqxFg6s5OMhnFZAuZVtx8fpFyjDG9dKxtzEgWM8pkDG8CIS6M6AJTwbdig==" });

            migrationBuilder.UpdateData(
                table: "ACCOUNT",
                keyColumn: "Id",
                keyValue: new Guid("8bc30f33-6382-45fd-a54a-0dec677631d9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e339e03b-89fb-49ad-be79-3c9ac501fbe4", "AQAAAAEAACcQAAAAEC0oJfblAcM4tXspBOVuw8WZZlZjH2lf6skxuYofqzfC49Ox62R7IPKqfz5HXOQ4Ww==" });

            migrationBuilder.UpdateData(
                table: "ACCOUNT",
                keyColumn: "Id",
                keyValue: new Guid("9e7773ef-083c-4a8e-8ed2-9e36cd704913"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e8fe953c-1ef0-4e6c-8324-dbfd2ee46010", "AQAAAAEAACcQAAAAEOgRXVCrX7tWPeVkraM9IQ8bWsNi354265WFEbvugzSIeDZvCf/vUSME0lCZ3sZbQQ==" });

            migrationBuilder.UpdateData(
                table: "ACCOUNT",
                keyColumn: "Id",
                keyValue: new Guid("efe5c78c-bbc5-40e5-a106-1f07d4b4fcdb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "80cfa4eb-9745-47a3-8b0c-aded87136bf0", "AQAAAAEAACcQAAAAENoV+l0pWD/kzjBPI3Bptz2/OAYpPAKV4EvUqDcbe0OfBHxL9H0iZryBhMJvOvSyJw==" });

            migrationBuilder.UpdateData(
                table: "ROLE",
                keyColumn: "Id",
                keyValue: new Guid("1e6d489f-1df4-4dab-b873-ce3224d87f94"),
                column: "ConcurrencyStamp",
                value: "3c6c4652-923c-45dc-afb2-3e817e93abfe");

            migrationBuilder.UpdateData(
                table: "ROLE",
                keyColumn: "Id",
                keyValue: new Guid("61a4fad5-402c-4ce0-845d-1fbd2b91956f"),
                column: "ConcurrencyStamp",
                value: "f1db34f7-f762-4270-94fc-0324dc216cf2");

            migrationBuilder.UpdateData(
                table: "ROLE",
                keyColumn: "Id",
                keyValue: new Guid("9a34bdd4-fa97-4e2f-9960-b19a68826be9"),
                column: "ConcurrencyStamp",
                value: "6a085597-60d8-492b-b804-4970d853c269");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "EXAM",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.UpdateData(
                table: "ACCOUNT",
                keyColumn: "Id",
                keyValue: new Guid("4a2d9b6e-97c4-41bd-a929-f778972db109"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "60aa65bf-92f8-40a4-bd44-c68e466a1f2e", "AQAAAAEAACcQAAAAEOhaedMDJ2LDx/Yc0Nhag3x8uvgCmXhJ+shs6AHJZfvG28sYqGGWUOvy+WsO+A6ahg==" });

            migrationBuilder.UpdateData(
                table: "ACCOUNT",
                keyColumn: "Id",
                keyValue: new Guid("8bc30f33-6382-45fd-a54a-0dec677631d9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9c28af2d-37ee-44bf-8099-0734373a2dc2", "AQAAAAEAACcQAAAAEFcsOKSDO69SvpRGdjhOoihRVr4wrPh3DE0GMvUDv8EM2MfsLDvT2fcosnUWzft3DA==" });

            migrationBuilder.UpdateData(
                table: "ACCOUNT",
                keyColumn: "Id",
                keyValue: new Guid("9e7773ef-083c-4a8e-8ed2-9e36cd704913"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3325f9aa-8c17-4090-9cb6-430f45a5dfcf", "AQAAAAEAACcQAAAAENAzwoEybsGMjeZKNYC+nLJgR4GeA1N+N/VQkFhC8rjIr/llXk2Kr3rqp6V47z1s/g==" });

            migrationBuilder.UpdateData(
                table: "ACCOUNT",
                keyColumn: "Id",
                keyValue: new Guid("efe5c78c-bbc5-40e5-a106-1f07d4b4fcdb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fe0d6fd9-b56d-47a2-a9d2-fd53d51b01f0", "AQAAAAEAACcQAAAAED2OjnuFkjkr7i9+sOA+XUz3UQrTiP2ZrhKt4BEqfvEh0d1WvY4NgqosGAFjVl3eVQ==" });

            migrationBuilder.UpdateData(
                table: "ROLE",
                keyColumn: "Id",
                keyValue: new Guid("1e6d489f-1df4-4dab-b873-ce3224d87f94"),
                column: "ConcurrencyStamp",
                value: "8efadec6-f9b6-41cd-ba4a-359b15bd3205");

            migrationBuilder.UpdateData(
                table: "ROLE",
                keyColumn: "Id",
                keyValue: new Guid("61a4fad5-402c-4ce0-845d-1fbd2b91956f"),
                column: "ConcurrencyStamp",
                value: "5ecb7e35-fd4f-4057-a2f0-9f31ae1704e6");

            migrationBuilder.UpdateData(
                table: "ROLE",
                keyColumn: "Id",
                keyValue: new Guid("9a34bdd4-fa97-4e2f-9960-b19a68826be9"),
                column: "ConcurrencyStamp",
                value: "d5cc3ef4-3b73-4635-8165-9d62b6c86244");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HeThongQuanLyCongTacKhaoThi.Data.Migrations
{
    public partial class AddMark1AndMark2ToResultTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Mark",
                table: "RESULT",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<float>(
                name: "Mark1",
                table: "RESULT",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Mark2",
                table: "RESULT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ACCOUNT",
                keyColumn: "Id",
                keyValue: new Guid("4a2d9b6e-97c4-41bd-a929-f778972db109"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7806ff71-d649-4daf-86aa-ce3ed53b6cbb", "AQAAAAEAACcQAAAAEOxzoEwhW1zmeBU9gEJOGhakamQ7axS01znf87EMzkBErsmoj2MKhe9zkFfd83Dn2g==" });

            migrationBuilder.UpdateData(
                table: "ACCOUNT",
                keyColumn: "Id",
                keyValue: new Guid("8bc30f33-6382-45fd-a54a-0dec677631d9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6f066c5d-e29a-4a3c-9571-d5132dbf8ef2", "AQAAAAEAACcQAAAAEO0PIY2FNsXwHoVAbnTqRTAyGEo8yBf1sy8eWkN4VUr5hQXNqxTW+wKwlkTcZpEzKA==" });

            migrationBuilder.UpdateData(
                table: "ACCOUNT",
                keyColumn: "Id",
                keyValue: new Guid("9e7773ef-083c-4a8e-8ed2-9e36cd704913"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ae6e868d-2a35-4ed2-8738-a7792a2ad45b", "AQAAAAEAACcQAAAAEOugTTKMtFEEhwH68Mpu8W9yK+hBq0iDmifaeuIkEN3nozYW+v+23uCHNQ8vKJckkA==" });

            migrationBuilder.UpdateData(
                table: "ACCOUNT",
                keyColumn: "Id",
                keyValue: new Guid("efe5c78c-bbc5-40e5-a106-1f07d4b4fcdb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "524b73ce-e888-401c-b945-64744395ee9e", "AQAAAAEAACcQAAAAEI+t7hxF7L+m8rnF/cAu/u9WLmfUINohBmY/uhAExMSEH3WWUGAXD9ScC+y4tePV1w==" });

            migrationBuilder.UpdateData(
                table: "ROLE",
                keyColumn: "Id",
                keyValue: new Guid("1e6d489f-1df4-4dab-b873-ce3224d87f94"),
                column: "ConcurrencyStamp",
                value: "e367054f-9639-4cf3-9f4b-2cd3a2a5cce6");

            migrationBuilder.UpdateData(
                table: "ROLE",
                keyColumn: "Id",
                keyValue: new Guid("61a4fad5-402c-4ce0-845d-1fbd2b91956f"),
                column: "ConcurrencyStamp",
                value: "81084cb4-6a3d-4bb0-a54c-82a484db7623");

            migrationBuilder.UpdateData(
                table: "ROLE",
                keyColumn: "Id",
                keyValue: new Guid("9a34bdd4-fa97-4e2f-9960-b19a68826be9"),
                column: "ConcurrencyStamp",
                value: "bed4eb16-2bd1-4a36-b718-768b74cd0d78");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mark1",
                table: "RESULT");

            migrationBuilder.DropColumn(
                name: "Mark2",
                table: "RESULT");

            migrationBuilder.AlterColumn<float>(
                name: "Mark",
                table: "RESULT",
                type: "real",
                nullable: false,
                oldClrType: typeof(float),
                oldNullable: true);

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
    }
}

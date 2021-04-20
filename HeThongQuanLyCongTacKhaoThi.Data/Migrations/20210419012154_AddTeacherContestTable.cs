using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HeThongQuanLyCongTacKhaoThi.Data.Migrations
{
    public partial class AddTeacherContestTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_CLASS_ClassID",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_RESULT_Account_UserID",
                table: "RESULT");

            migrationBuilder.DropForeignKey(
                name: "FK_STUDENT_ANSWER_Account_UserID",
                table: "STUDENT_ANSWER");

            migrationBuilder.DropForeignKey(
                name: "FK_SUBJECT_ACCOUNT_Account_UserID",
                table: "SUBJECT_ACCOUNT");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Account",
                table: "Account");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleAccount",
                table: "RoleAccount");

            migrationBuilder.RenameTable(
                name: "Account",
                newName: "ACCOUNT");

            migrationBuilder.RenameTable(
                name: "RoleAccount",
                newName: "ROLE_ACCOUNT");

            migrationBuilder.RenameIndex(
                name: "IX_Account_ClassID",
                table: "ACCOUNT",
                newName: "IX_ACCOUNT_ClassID");

            migrationBuilder.AddColumn<string>(
                name: "Teacher1Comment",
                table: "STUDENT_ANSWER_DETAIL",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Teacher2Comment",
                table: "STUDENT_ANSWER_DETAIL",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "CONTEST",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "CONTEST",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "CONTEST",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ACCOUNT",
                table: "ACCOUNT",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ROLE_ACCOUNT",
                table: "ROLE_ACCOUNT",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TEACHER_CONTEST",
                columns: table => new
                {
                    TeacherID = table.Column<Guid>(nullable: false),
                    ContestID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TEACHER_CONTEST", x => new { x.TeacherID, x.ContestID });
                    table.ForeignKey(
                        name: "FK_TEACHER_CONTEST_CONTEST_ContestID",
                        column: x => x.ContestID,
                        principalTable: "CONTEST",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TEACHER_CONTEST_ACCOUNT_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "ACCOUNT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.UpdateData(
                table: "ROLE_ACCOUNT",
                keyColumn: "Id",
                keyValue: new Guid("1e6d489f-1df4-4dab-b873-ce3224d87f94"),
                column: "ConcurrencyStamp",
                value: "b097fffe-325a-421d-9425-2c4e49052249");

            migrationBuilder.UpdateData(
                table: "ROLE_ACCOUNT",
                keyColumn: "Id",
                keyValue: new Guid("61a4fad5-402c-4ce0-845d-1fbd2b91956f"),
                column: "ConcurrencyStamp",
                value: "5c88f114-df60-4cb1-9bce-2625b69745a0");

            migrationBuilder.UpdateData(
                table: "ROLE_ACCOUNT",
                keyColumn: "Id",
                keyValue: new Guid("9a34bdd4-fa97-4e2f-9960-b19a68826be9"),
                column: "ConcurrencyStamp",
                value: "82fbbd0b-8e0a-421b-9205-a4e498c6b486");

            migrationBuilder.CreateIndex(
                name: "IX_TEACHER_CONTEST_ContestID",
                table: "TEACHER_CONTEST",
                column: "ContestID");

            migrationBuilder.AddForeignKey(
                name: "FK_ACCOUNT_CLASS_ClassID",
                table: "ACCOUNT",
                column: "ClassID",
                principalTable: "CLASS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RESULT_ACCOUNT_UserID",
                table: "RESULT",
                column: "UserID",
                principalTable: "ACCOUNT",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_STUDENT_ANSWER_ACCOUNT_UserID",
                table: "STUDENT_ANSWER",
                column: "UserID",
                principalTable: "ACCOUNT",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SUBJECT_ACCOUNT_ACCOUNT_UserID",
                table: "SUBJECT_ACCOUNT",
                column: "UserID",
                principalTable: "ACCOUNT",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ACCOUNT_CLASS_ClassID",
                table: "ACCOUNT");

            migrationBuilder.DropForeignKey(
                name: "FK_RESULT_ACCOUNT_UserID",
                table: "RESULT");

            migrationBuilder.DropForeignKey(
                name: "FK_STUDENT_ANSWER_ACCOUNT_UserID",
                table: "STUDENT_ANSWER");

            migrationBuilder.DropForeignKey(
                name: "FK_SUBJECT_ACCOUNT_ACCOUNT_UserID",
                table: "SUBJECT_ACCOUNT");

            migrationBuilder.DropTable(
                name: "TEACHER_CONTEST");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ACCOUNT",
                table: "ACCOUNT");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ROLE_ACCOUNT",
                table: "ROLE_ACCOUNT");

            migrationBuilder.DropColumn(
                name: "Teacher1Comment",
                table: "STUDENT_ANSWER_DETAIL");

            migrationBuilder.DropColumn(
                name: "Teacher2Comment",
                table: "STUDENT_ANSWER_DETAIL");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "CONTEST");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "CONTEST");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "CONTEST");

            migrationBuilder.RenameTable(
                name: "ACCOUNT",
                newName: "Account");

            migrationBuilder.RenameTable(
                name: "ROLE_ACCOUNT",
                newName: "RoleAccount");

            migrationBuilder.RenameIndex(
                name: "IX_ACCOUNT_ClassID",
                table: "Account",
                newName: "IX_Account_ClassID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Account",
                table: "Account",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleAccount",
                table: "RoleAccount",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("4a2d9b6e-97c4-41bd-a929-f778972db109"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c20c0f7e-7855-4a14-87a5-3f1f19d3ed9e", "AQAAAAEAACcQAAAAEFCFxBOuubAyrefBShxACZ8zhP+tLgCB89V61mVhsxztqJ9TlSEtacKvTAwvER/GSQ==" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("8bc30f33-6382-45fd-a54a-0dec677631d9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d0dabca3-1570-4314-8f7b-5a6ec087812e", "AQAAAAEAACcQAAAAEI1xVz2MLIfDOI4eyBUwX9EKRO4G/8RPGrtI0lmXU04H5N85Q+vN1gsO7RWOzhij4Q==" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("9e7773ef-083c-4a8e-8ed2-9e36cd704913"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bc71caa5-4018-4ba4-9922-a8d260cef50c", "AQAAAAEAACcQAAAAEODoEXTN7CKLuibhCIkzdDYF10VQRwgGpyDgzRCzJHCAuJB8DM6FMTPvw9A5Uzh/dA==" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("efe5c78c-bbc5-40e5-a106-1f07d4b4fcdb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "790f73c6-661a-4cbe-a517-68d9742654c2", "AQAAAAEAACcQAAAAEBpEK0vLkn3xS/Xsh3PM1ftWX1T8DdGkg32FP3CaJZOxxWtry1W2j2h1O783l1JoZg==" });

            migrationBuilder.UpdateData(
                table: "RoleAccount",
                keyColumn: "Id",
                keyValue: new Guid("1e6d489f-1df4-4dab-b873-ce3224d87f94"),
                column: "ConcurrencyStamp",
                value: "70634c23-8843-4837-8a33-419389f8f53f");

            migrationBuilder.UpdateData(
                table: "RoleAccount",
                keyColumn: "Id",
                keyValue: new Guid("61a4fad5-402c-4ce0-845d-1fbd2b91956f"),
                column: "ConcurrencyStamp",
                value: "aafe4371-31cb-463e-8d16-d192a44a1592");

            migrationBuilder.UpdateData(
                table: "RoleAccount",
                keyColumn: "Id",
                keyValue: new Guid("9a34bdd4-fa97-4e2f-9960-b19a68826be9"),
                column: "ConcurrencyStamp",
                value: "bcff8ece-035c-4f88-90a7-34d9b954aa58");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_CLASS_ClassID",
                table: "Account",
                column: "ClassID",
                principalTable: "CLASS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RESULT_Account_UserID",
                table: "RESULT",
                column: "UserID",
                principalTable: "Account",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_STUDENT_ANSWER_Account_UserID",
                table: "STUDENT_ANSWER",
                column: "UserID",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SUBJECT_ACCOUNT_Account_UserID",
                table: "SUBJECT_ACCOUNT",
                column: "UserID",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

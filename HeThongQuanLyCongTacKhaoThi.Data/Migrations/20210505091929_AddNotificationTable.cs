using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HeThongQuanLyCongTacKhaoThi.Data.Migrations
{
    public partial class AddNotificationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NOTIFICATION",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountID = table.Column<Guid>(nullable: false),
                    StudentAnswerID = table.Column<int>(nullable: false),
                    Message = table.Column<string>(nullable: true, defaultValue: ""),
                    DateTime = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2021, 5, 5, 16, 19, 28, 190, DateTimeKind.Local).AddTicks(8168)),
                    IsRead = table.Column<bool>(nullable: false, defaultValue: false),
                    SubjectID = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NOTIFICATION", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NOTIFICATION_ACCOUNT_AccountID",
                        column: x => x.AccountID,
                        principalTable: "ACCOUNT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NOTIFICATION_STUDENT_ANSWER_StudentAnswerID",
                        column: x => x.StudentAnswerID,
                        principalTable: "STUDENT_ANSWER",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_NOTIFICATION_SUBJECT_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "SUBJECT",
                        principalColumn: "ID");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_NOTIFICATION_AccountID",
                table: "NOTIFICATION",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_NOTIFICATION_StudentAnswerID",
                table: "NOTIFICATION",
                column: "StudentAnswerID");

            migrationBuilder.CreateIndex(
                name: "IX_NOTIFICATION_SubjectID",
                table: "NOTIFICATION",
                column: "SubjectID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NOTIFICATION");

            migrationBuilder.UpdateData(
                table: "ACCOUNT",
                keyColumn: "Id",
                keyValue: new Guid("4a2d9b6e-97c4-41bd-a929-f778972db109"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0fdd59b5-f09d-4b86-992e-756a9220327e", "AQAAAAEAACcQAAAAEEqut3QJckkParEqwCKP4/Sggkup+CdNYLeeyT7DNsdo7OQoLk5T/eK2PN/vqQ5Vzw==" });

            migrationBuilder.UpdateData(
                table: "ACCOUNT",
                keyColumn: "Id",
                keyValue: new Guid("8bc30f33-6382-45fd-a54a-0dec677631d9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b7d97d9d-573c-41c3-ab44-8840a4c16955", "AQAAAAEAACcQAAAAELBUA4LUAcvtHXs+sUpd2b5YKz6hswOCq8dM6KOEPvy7iSIW2BpnK5OwdxZa/Lza9w==" });

            migrationBuilder.UpdateData(
                table: "ACCOUNT",
                keyColumn: "Id",
                keyValue: new Guid("9e7773ef-083c-4a8e-8ed2-9e36cd704913"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0b5f6cdf-b6bd-4d25-8c42-39a2cc9622a9", "AQAAAAEAACcQAAAAEJiEHwIfUwpoQnNbpUgKAgyEyopzMPbMs+M6ygR6+bqe5xcpNeeyyxFZr0RlSY+omQ==" });

            migrationBuilder.UpdateData(
                table: "ACCOUNT",
                keyColumn: "Id",
                keyValue: new Guid("efe5c78c-bbc5-40e5-a106-1f07d4b4fcdb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1db7db94-9eb9-457b-8d9c-e07ef973f112", "AQAAAAEAACcQAAAAENJ4XbbkVP38iidkuvWm66z2RyRhzvOnAswdeLGXJwqhhBc4X9wU6qOP+SBPR3AKpQ==" });

            migrationBuilder.UpdateData(
                table: "ROLE",
                keyColumn: "Id",
                keyValue: new Guid("1e6d489f-1df4-4dab-b873-ce3224d87f94"),
                column: "ConcurrencyStamp",
                value: "926811ae-040b-4bbc-aa66-cd92b617709e");

            migrationBuilder.UpdateData(
                table: "ROLE",
                keyColumn: "Id",
                keyValue: new Guid("61a4fad5-402c-4ce0-845d-1fbd2b91956f"),
                column: "ConcurrencyStamp",
                value: "21e5381e-4ccd-4b07-89d8-3d7229733b12");

            migrationBuilder.UpdateData(
                table: "ROLE",
                keyColumn: "Id",
                keyValue: new Guid("9a34bdd4-fa97-4e2f-9960-b19a68826be9"),
                column: "ConcurrencyStamp",
                value: "b2edaa9a-9a13-41a5-a619-d868c765d1f7");
        }
    }
}

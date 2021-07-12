using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HeThongQuanLyCongTacKhaoThi.Data.Migrations
{
    public partial class InitDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CLASS",
                columns: table => new
                {
                    ID = table.Column<string>(maxLength: 15, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    StudentCount = table.Column<int>(nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLASS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "QUESTION_GROUP",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QUESTION_GROUP", x => x.ID);
                });

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

            migrationBuilder.CreateTable(
                name: "ROLE_CLAIM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLE_CLAIM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SUBJECT",
                columns: table => new
                {
                    ID = table.Column<string>(maxLength: 10, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    LessonCount = table.Column<int>(nullable: false),
                    CreditCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUBJECT", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "USER_CLAIM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_CLAIM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "USER_LOGIN",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: true),
                    ProviderKey = table.Column<string>(nullable: true),
                    ProviderDisplayName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_LOGIN", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "USER_ROLE",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_ROLE", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "USER_TOKEN",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_TOKEN", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "ACCOUNT",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Student_TeacherID = table.Column<string>(maxLength: 10, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Gender = table.Column<bool>(nullable: false),
                    Birthday = table.Column<DateTime>(nullable: false),
                    ClassID = table.Column<string>(maxLength: 15, nullable: true),
                    Address = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACCOUNT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ACCOUNT_CLASS_ClassID",
                        column: x => x.ClassID,
                        principalTable: "CLASS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QUESTION",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectID = table.Column<string>(maxLength: 10, nullable: false),
                    GroupID = table.Column<int>(nullable: false),
                    Content = table.Column<string>(nullable: false),
                    IsMultipleChoice = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QUESTION", x => x.ID);
                    table.ForeignKey(
                        name: "FK_QUESTION_QUESTION_GROUP_GroupID",
                        column: x => x.GroupID,
                        principalTable: "QUESTION_GROUP",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QUESTION_SUBJECT_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "SUBJECT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SCORE_TYPE",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectID = table.Column<string>(maxLength: 10, nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Percent = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SCORE_TYPE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SCORE_TYPE_SUBJECT_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "SUBJECT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SUBJECT_ACCOUNT",
                columns: table => new
                {
                    UserID = table.Column<Guid>(nullable: false),
                    SubjectID = table.Column<string>(maxLength: 10, nullable: false),
                    ClassID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUBJECT_ACCOUNT", x => new { x.UserID, x.SubjectID });
                    table.ForeignKey(
                        name: "FK_SUBJECT_ACCOUNT_CLASS_ClassID",
                        column: x => x.ClassID,
                        principalTable: "CLASS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SUBJECT_ACCOUNT_SUBJECT_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "SUBJECT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SUBJECT_ACCOUNT_ACCOUNT_UserID",
                        column: x => x.UserID,
                        principalTable: "ACCOUNT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ANSWER",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionID = table.Column<int>(nullable: false),
                    Content = table.Column<string>(nullable: false),
                    IsCorrect = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ANSWER", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ANSWER_QUESTION_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "QUESTION",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CONTEST",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    SubjectID = table.Column<string>(nullable: false),
                    ScoreTypeID = table.Column<int>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    Duration = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTEST", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CONTEST_SCORE_TYPE_ScoreTypeID",
                        column: x => x.ScoreTypeID,
                        principalTable: "SCORE_TYPE",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_CONTEST_SUBJECT_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "SUBJECT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EXAM",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectID = table.Column<string>(maxLength: 10, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ContestID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXAM", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EXAM_CONTEST_ContestID",
                        column: x => x.ContestID,
                        principalTable: "CONTEST",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EXAM_SUBJECT_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "SUBJECT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateTable(
                name: "EXAM_DETAIL",
                columns: table => new
                {
                    ExamID = table.Column<int>(nullable: false),
                    QuestionID = table.Column<int>(nullable: false),
                    MaxQuestionMark = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXAM_DETAIL", x => new { x.ExamID, x.QuestionID });
                    table.ForeignKey(
                        name: "FK_EXAM_DETAIL_EXAM_ExamID",
                        column: x => x.ExamID,
                        principalTable: "EXAM",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EXAM_DETAIL_QUESTION_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "QUESTION",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "STUDENT_ANSWER",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    UserID = table.Column<Guid>(nullable: false),
                    ExamID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STUDENT_ANSWER", x => x.ID);
                    table.ForeignKey(
                        name: "FK_STUDENT_ANSWER_EXAM_ExamID",
                        column: x => x.ExamID,
                        principalTable: "EXAM",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_STUDENT_ANSWER_ACCOUNT_UserID",
                        column: x => x.UserID,
                        principalTable: "ACCOUNT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NOTIFICATION",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountID = table.Column<Guid>(nullable: false),
                    StudentAnswerID = table.Column<Guid>(nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
                    Message = table.Column<string>(nullable: true, defaultValue: ""),
                    DateTime = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    IsRead = table.Column<bool>(nullable: false, defaultValue: false),
                    SubjectID = table.Column<string>(maxLength: 10, nullable: true)
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

            migrationBuilder.CreateTable(
                name: "RESULT",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<Guid>(nullable: false),
                    SubjectID = table.Column<string>(maxLength: 10, nullable: false),
                    ContestID = table.Column<int>(nullable: false),
                    ExamID = table.Column<int>(nullable: false),
                    StudentAnswerID = table.Column<Guid>(nullable: false),
                    Mark = table.Column<float>(nullable: false),
                    Time = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESULT", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RESULT_CONTEST_ContestID",
                        column: x => x.ContestID,
                        principalTable: "CONTEST",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_RESULT_EXAM_ExamID",
                        column: x => x.ExamID,
                        principalTable: "EXAM",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_RESULT_STUDENT_ANSWER_StudentAnswerID",
                        column: x => x.StudentAnswerID,
                        principalTable: "STUDENT_ANSWER",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_RESULT_SUBJECT_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "SUBJECT",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_RESULT_ACCOUNT_UserID",
                        column: x => x.UserID,
                        principalTable: "ACCOUNT",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "STUDENT_ANSWER_DETAIL",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentAnswerID = table.Column<Guid>(nullable: false),
                    QuestionID = table.Column<int>(nullable: false),
                    AnswerID = table.Column<int>(nullable: true),
                    EssayPath = table.Column<string>(nullable: true),
                    StudentAnswerContent = table.Column<string>(nullable: true),
                    Teacher1Comment = table.Column<string>(nullable: true, defaultValue: "Chưa có nhận xét!"),
                    Teacher2Comment = table.Column<string>(nullable: true, defaultValue: "Chưa có nhận xét!"),
                    Mark1 = table.Column<float>(nullable: true),
                    Mark2 = table.Column<float>(nullable: true),
                    Mark = table.Column<float>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STUDENT_ANSWER_DETAIL", x => x.ID);
                    table.ForeignKey(
                        name: "FK_STUDENT_ANSWER_DETAIL_ANSWER_AnswerID",
                        column: x => x.AnswerID,
                        principalTable: "ANSWER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_STUDENT_ANSWER_DETAIL_QUESTION_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "QUESTION",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_STUDENT_ANSWER_DETAIL_STUDENT_ANSWER_StudentAnswerID",
                        column: x => x.StudentAnswerID,
                        principalTable: "STUDENT_ANSWER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ACCOUNT",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Birthday", "ClassID", "ConcurrencyStamp", "Email", "EmailConfirmed", "Gender", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Student_TeacherID", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("efe5c78c-bbc5-40e5-a106-1f07d4b4fcdb"), 0, null, new DateTime(1999, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "fe0d6fd9-b56d-47a2-a9d2-fd53d51b01f0", "keycodemon@gmail.com", true, true, false, null, "Keycode Mon", "keycodemon@gmail.com", "admin", "AQAAAAEAACcQAAAAED2OjnuFkjkr7i9+sOA+XUz3UQrTiP2ZrhKt4BEqfvEh0d1WvY4NgqosGAFjVl3eVQ==", null, false, "", null, false, "admin" });

            migrationBuilder.InsertData(
                table: "CLASS",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { "DHCN1A", "Đại học công nghệ 1A" },
                    { "DHCN1B", "Đại học công nghệ 1B" },
                    { "DHCN1C", "Đại học công nghệ 1C" },
                    { "DHCN1D", "Đại học công nghệ 1D" },
                    { "DHCN2A", "Đại học công nghệ 2A" },
                    { "DHCN2B", "Đại học công nghệ 2B" },
                    { "DHCN3A", "Đại học công nghệ 3A" },
                    { "DHCN3B", "Đại học công nghệ 3B" },
                    { "DHCN3C", "Đại học công nghệ 3C" },
                    { "DHCN4A", "Đại học công nghệ 4A" },
                    { "DHCN4B", "Đại học công nghệ 4B" },
                    { "DHVT1", "Đại học viễn thông 1" },
                    { "DHVT2", "Đại học viễn thông 2" }
                });

            migrationBuilder.InsertData(
                table: "QUESTION_GROUP",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 5, "Nhóm câu hỏi chương 5" },
                    { 3, "Nhóm câu hỏi chương 3" },
                    { 4, "Nhóm câu hỏi chương 4" },
                    { 1, "Nhóm câu hỏi chương 1" },
                    { 2, "Nhóm câu hỏi chương 2" }
                });

            migrationBuilder.InsertData(
                table: "ROLE",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("61a4fad5-402c-4ce0-845d-1fbd2b91956f"), "5ecb7e35-fd4f-4057-a2f0-9f31ae1704e6", "Vai trò quản trị viên", "Admin", "admin" },
                    { new Guid("1e6d489f-1df4-4dab-b873-ce3224d87f94"), "8efadec6-f9b6-41cd-ba4a-359b15bd3205", "Vai trò giảng viên", "Teacher", "teacher" },
                    { new Guid("9a34bdd4-fa97-4e2f-9960-b19a68826be9"), "d5cc3ef4-3b73-4635-8165-9d62b6c86244", "Vai trò học viên", "Student", "student" }
                });

            migrationBuilder.InsertData(
                table: "SUBJECT",
                columns: new[] { "ID", "CreditCount", "LessonCount", "Name" },
                values: new object[,]
                {
                    { "DC4204", 4, 45, "Cơ sở dữ liệu" },
                    { "CC4206", 3, 45, "Nhập môn lập trình" },
                    { "DH4202", 3, 45, "Kỹ thuật lập trình" },
                    { "DH4203", 4, 45, "Cấu trúc dữ liệu & giải thuật" },
                    { "TC4209", 4, 45, "Lập trình hướng đối tượng" },
                    { "DC4106", 4, 45, "Kiến trúc máy tính" },
                    { "DT4208", 4, 45, "Lập trình Java" },
                    { "DT4315", 4, 45, "Công nghệ phần mềm" },
                    { "DT4205", 4, 45, "SQL Server" },
                    { "DT4301", 4, 45, "Mạng máy tính" }
                });

            migrationBuilder.InsertData(
                table: "USER_ROLE",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("4a2d9b6e-97c4-41bd-a929-f778972db109"), new Guid("1e6d489f-1df4-4dab-b873-ce3224d87f94") },
                    { new Guid("9e7773ef-083c-4a8e-8ed2-9e36cd704913"), new Guid("9a34bdd4-fa97-4e2f-9960-b19a68826be9") },
                    { new Guid("efe5c78c-bbc5-40e5-a106-1f07d4b4fcdb"), new Guid("61a4fad5-402c-4ce0-845d-1fbd2b91956f") },
                    { new Guid("8bc30f33-6382-45fd-a54a-0dec677631d9"), new Guid("9a34bdd4-fa97-4e2f-9960-b19a68826be9") }
                });

            migrationBuilder.InsertData(
                table: "ACCOUNT",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Birthday", "ClassID", "ConcurrencyStamp", "Email", "EmailConfirmed", "Gender", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Student_TeacherID", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("4a2d9b6e-97c4-41bd-a929-f778972db109"), 0, "Số 80 - Hai Bà Trưng - Vạn Giã - Vạn Ninh - Khánh Hoà", new DateTime(1999, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "DHCN4A", "60aa65bf-92f8-40a4-bd44-c68e466a1f2e", "htthinh1999@gmail.com", true, true, false, null, "Huỳnh Tấn Thịnh", "htthinh1999@gmail.com", "htthinh", "AQAAAAEAACcQAAAAEOhaedMDJ2LDx/Yc0Nhag3x8uvgCmXhJ+shs6AHJZfvG28sYqGGWUOvy+WsO+A6ahg==", "0977393641", false, "", "17ĐC027", false, "htthinh" },
                    { new Guid("9e7773ef-083c-4a8e-8ed2-9e36cd704913"), 0, "Khánh Hoà", new DateTime(2000, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "DHCN4A", "3325f9aa-8c17-4090-9cb6-430f45a5dfcf", "sv1@gmail.com", true, true, false, null, "Sinh viên 1", "sv1@gmail.com", "sv1", "AQAAAAEAACcQAAAAENAzwoEybsGMjeZKNYC+nLJgR4GeA1N+N/VQkFhC8rjIr/llXk2Kr3rqp6V47z1s/g==", "0987333644", false, "", "17ĐC028", false, "sv1" },
                    { new Guid("8bc30f33-6382-45fd-a54a-0dec677631d9"), 0, "Khánh Hoà", new DateTime(2000, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "DHCN4A", "9c28af2d-37ee-44bf-8099-0734373a2dc2", "sv2@gmail.com", true, true, false, null, "Sinh viên 2", "sv2@gmail.com", "sv2", "AQAAAAEAACcQAAAAEFcsOKSDO69SvpRGdjhOoihRVr4wrPh3DE0GMvUDv8EM2MfsLDvT2fcosnUWzft3DA==", "0987666644", false, "", "17ĐC023", false, "sv2" }
                });

            migrationBuilder.InsertData(
                table: "QUESTION",
                columns: new[] { "ID", "Content", "GroupID", "IsMultipleChoice", "SubjectID" },
                values: new object[,]
                {
                    { 5, "Trong các phương pháp sắp xếp: lựa chọn, chèn, đổi chỗ(nổi bọt), quicksort (sắp xếp nhanh), mergesort (sắp xếp trộn), thì phương pháp nào là phù hợp nhất để sắp xếp trên danh sách liên kết đơn ? Giải thích ? ", 2, false, "CC4206" },
                    { 4, "Nhận định nào sau đây KHÔNG ĐÚNG về đệ quy vô hạn?", 2, true, "CC4206" },
                    { 6, "Trình bày sự khác biệt giữa mảng cấp phát bộ nhớ động và mảng cấp phát tĩnh? Khi nào dùng mảng cấp phát động, mảng cấp phát tĩnh ? Cho ví dụ ?", 2, false, "CC4206" },
                    { 2, "Một biến được gọi là biến toàn cục nếu:", 1, true, "CC4206" },
                    { 1, "Những tên biến nào dưới đây được viết đúng theo quy tắc đặt tên của ngôn ngữ lập trình C?", 1, true, "CC4206" },
                    { 3, "Một biến được gọi là biến cục bộ nếu:", 1, true, "CC4206" }
                });

            migrationBuilder.InsertData(
                table: "SCORE_TYPE",
                columns: new[] { "ID", "Name", "Percent", "SubjectID" },
                values: new object[,]
                {
                    { 28, "Điểm kết thúc môn", 0.5f, "DT4208" },
                    { 22, "Điểm thường xuyên", 0.2f, "DC4106" },
                    { 23, "Điểm giữa môn", 0.2f, "DC4106" },
                    { 24, "Điểm kết thúc môn", 0.5f, "DC4106" },
                    { 25, "Điểm chuyên cần", 0.1f, "DT4208" },
                    { 26, "Điểm thường xuyên", 0.2f, "DT4208" },
                    { 27, "Điểm giữa môn", 0.2f, "DT4208" },
                    { 29, "Điểm chuyên cần", 0.1f, "DT4315" },
                    { 34, "Điểm thường xuyên", 0.2f, "DT4205" },
                    { 31, "Điểm giữa môn", 0.2f, "DT4315" },
                    { 32, "Điểm kết thúc môn", 0.5f, "DT4315" },
                    { 33, "Điểm chuyên cần", 0.1f, "DT4205" },
                    { 21, "Điểm chuyên cần", 0.1f, "DC4106" },
                    { 35, "Điểm giữa môn", 0.2f, "DT4205" },
                    { 36, "Điểm kết thúc môn", 0.5f, "DT4205" },
                    { 37, "Điểm chuyên cần", 0.1f, "DT4301" },
                    { 38, "Điểm thường xuyên", 0.2f, "DT4301" },
                    { 30, "Điểm thường xuyên", 0.2f, "DT4315" },
                    { 20, "Điểm kết thúc môn", 0.5f, "DC4204" },
                    { 16, "Điểm kết thúc môn", 0.5f, "TC4209" },
                    { 18, "Điểm thường xuyên", 0.2f, "DC4204" },
                    { 1, "Điểm chuyên cần", 0.1f, "CC4206" },
                    { 2, "Điểm thường xuyên", 0.2f, "CC4206" },
                    { 3, "Điểm giữa môn", 0.2f, "CC4206" },
                    { 4, "Điểm kết thúc môn", 0.5f, "CC4206" },
                    { 5, "Điểm chuyên cần", 0.1f, "DH4202" },
                    { 6, "Điểm thường xuyên", 0.2f, "DH4202" },
                    { 7, "Điểm giữa môn", 0.2f, "DH4202" },
                    { 8, "Điểm kết thúc môn", 0.5f, "DH4202" },
                    { 9, "Điểm chuyên cần", 0.1f, "DH4203" },
                    { 10, "Điểm thường xuyên", 0.2f, "DH4203" },
                    { 11, "Điểm giữa môn", 0.2f, "DH4203" },
                    { 12, "Điểm kết thúc môn", 0.5f, "DH4203" },
                    { 13, "Điểm chuyên cần", 0.1f, "TC4209" },
                    { 14, "Điểm thường xuyên", 0.2f, "TC4209" },
                    { 15, "Điểm giữa môn", 0.2f, "TC4209" },
                    { 39, "Điểm giữa môn", 0.2f, "DT4301" },
                    { 17, "Điểm chuyên cần", 0.1f, "DC4204" },
                    { 19, "Điểm giữa môn", 0.2f, "DC4204" },
                    { 40, "Điểm kết thúc môn", 0.5f, "DT4301" }
                });

            migrationBuilder.InsertData(
                table: "ANSWER",
                columns: new[] { "ID", "Content", "IsCorrect", "QuestionID" },
                values: new object[,]
                {
                    { 1, "diem toan", false, 1 },
                    { 2, "3diemtoan", false, 1 },
                    { 3, "_diemtoan", true, 1 },
                    { 4, "-diemtoan", false, 1 },
                    { 5, "Nó được khai báo tất cả các hàm, ngoại trừ hàm main()", false, 2 },
                    { 6, "Nó được khai báo ngoài tất cả các hàm kể cả hàm main()", true, 2 },
                    { 7, "Nó được khai báo bên ngoài hàm main()", false, 2 },
                    { 8, "Nó được khai báo bên trong hàm main()", false, 2 },
                    { 9, "Nó được khai báo bên trong các hàm hoặc thủ tục, kể cả hàm main()", true, 3 },
                    { 10, "Nó được khai báo bên trong các hàm ngoại trừ hàm main()", false, 3 },
                    { 11, "Nó được khai báo bên trong hàm main()", false, 3 },
                    { 12, "Nó được khai báo bên ngoài các hàm kể cả hàm main()", false, 3 },
                    { 13, "Đệ quy khiến chương trình bị treo.", false, 4 },
                    { 14, "Đệ quy vô hạn tiêu tốn toàn bộ bộ nhớ của hệ thống dành cho chương trình và khiến cho chương trình kết thúc một cách bất thường.", false, 4 },
                    { 15, "	Gọi đệ quy gián tiếp luôn gây ra đệ quy vô hạn.", true, 4 },
                    { 16, "Nếu lời gọi đệ quy không đi đến điểm dừng (base case) thì đệ quy vô hạn sẽ xuất hiện.", false, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ACCOUNT_ClassID",
                table: "ACCOUNT",
                column: "ClassID");

            migrationBuilder.CreateIndex(
                name: "IX_ANSWER_QuestionID",
                table: "ANSWER",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_CONTEST_ScoreTypeID",
                table: "CONTEST",
                column: "ScoreTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_CONTEST_SubjectID",
                table: "CONTEST",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_EXAM_ContestID",
                table: "EXAM",
                column: "ContestID");

            migrationBuilder.CreateIndex(
                name: "IX_EXAM_SubjectID",
                table: "EXAM",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_EXAM_DETAIL_QuestionID",
                table: "EXAM_DETAIL",
                column: "QuestionID");

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

            migrationBuilder.CreateIndex(
                name: "IX_QUESTION_GroupID",
                table: "QUESTION",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_QUESTION_SubjectID",
                table: "QUESTION",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_RESULT_ContestID",
                table: "RESULT",
                column: "ContestID");

            migrationBuilder.CreateIndex(
                name: "IX_RESULT_ExamID",
                table: "RESULT",
                column: "ExamID");

            migrationBuilder.CreateIndex(
                name: "IX_RESULT_StudentAnswerID",
                table: "RESULT",
                column: "StudentAnswerID");

            migrationBuilder.CreateIndex(
                name: "IX_RESULT_SubjectID",
                table: "RESULT",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_RESULT_UserID",
                table: "RESULT",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_SCORE_TYPE_SubjectID",
                table: "SCORE_TYPE",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_STUDENT_ANSWER_ExamID",
                table: "STUDENT_ANSWER",
                column: "ExamID");

            migrationBuilder.CreateIndex(
                name: "IX_STUDENT_ANSWER_UserID",
                table: "STUDENT_ANSWER",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_STUDENT_ANSWER_DETAIL_AnswerID",
                table: "STUDENT_ANSWER_DETAIL",
                column: "AnswerID");

            migrationBuilder.CreateIndex(
                name: "IX_STUDENT_ANSWER_DETAIL_QuestionID",
                table: "STUDENT_ANSWER_DETAIL",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_STUDENT_ANSWER_DETAIL_StudentAnswerID",
                table: "STUDENT_ANSWER_DETAIL",
                column: "StudentAnswerID");

            migrationBuilder.CreateIndex(
                name: "IX_SUBJECT_ACCOUNT_ClassID",
                table: "SUBJECT_ACCOUNT",
                column: "ClassID");

            migrationBuilder.CreateIndex(
                name: "IX_SUBJECT_ACCOUNT_SubjectID",
                table: "SUBJECT_ACCOUNT",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_TEACHER_CONTEST_ContestID",
                table: "TEACHER_CONTEST",
                column: "ContestID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EXAM_DETAIL");

            migrationBuilder.DropTable(
                name: "NOTIFICATION");

            migrationBuilder.DropTable(
                name: "RESULT");

            migrationBuilder.DropTable(
                name: "ROLE");

            migrationBuilder.DropTable(
                name: "ROLE_CLAIM");

            migrationBuilder.DropTable(
                name: "STUDENT_ANSWER_DETAIL");

            migrationBuilder.DropTable(
                name: "SUBJECT_ACCOUNT");

            migrationBuilder.DropTable(
                name: "TEACHER_CONTEST");

            migrationBuilder.DropTable(
                name: "USER_CLAIM");

            migrationBuilder.DropTable(
                name: "USER_LOGIN");

            migrationBuilder.DropTable(
                name: "USER_ROLE");

            migrationBuilder.DropTable(
                name: "USER_TOKEN");

            migrationBuilder.DropTable(
                name: "ANSWER");

            migrationBuilder.DropTable(
                name: "STUDENT_ANSWER");

            migrationBuilder.DropTable(
                name: "QUESTION");

            migrationBuilder.DropTable(
                name: "EXAM");

            migrationBuilder.DropTable(
                name: "ACCOUNT");

            migrationBuilder.DropTable(
                name: "QUESTION_GROUP");

            migrationBuilder.DropTable(
                name: "CONTEST");

            migrationBuilder.DropTable(
                name: "CLASS");

            migrationBuilder.DropTable(
                name: "SCORE_TYPE");

            migrationBuilder.DropTable(
                name: "SUBJECT");
        }
    }
}

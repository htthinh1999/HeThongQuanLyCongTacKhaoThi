using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HeThongQuanLyCongTacKhaoThi.Data.Migrations
{
    public partial class Init_Database : Migration
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
                name: "RoleAccount",
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
                    table.PrimaryKey("PK_RoleAccount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SCORE",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SCORE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SUBJECT",
                columns: table => new
                {
                    ID = table.Column<string>(maxLength: 10, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    AssiduousScorePercent = table.Column<float>(nullable: false, defaultValue: 0.1f),
                    FrequentScorePercent = table.Column<float>(nullable: false, defaultValue: 0.2f),
                    MiddleScorePercent = table.Column<float>(nullable: false, defaultValue: 0.2f),
                    FinalScorePercent = table.Column<float>(nullable: false, defaultValue: 0.5f),
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
                name: "Account",
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
                    table.PrimaryKey("PK_Account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Account_CLASS_ClassID",
                        column: x => x.ClassID,
                        principalTable: "CLASS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EXAM",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectID = table.Column<string>(maxLength: 10, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXAM", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EXAM_SUBJECT_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "SUBJECT",
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
                name: "SubjectTeacher",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<Guid>(nullable: false),
                    SubjectID = table.Column<string>(nullable: true),
                    ClassID = table.Column<string>(nullable: true),
                    AccountId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectTeacher", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SubjectTeacher_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubjectTeacher_CLASS_ClassID",
                        column: x => x.ClassID,
                        principalTable: "CLASS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubjectTeacher_SUBJECT_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "SUBJECT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "STUDENT_ANSWER",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        name: "FK_STUDENT_ANSWER_Account_UserID",
                        column: x => x.UserID,
                        principalTable: "Account",
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
                name: "EXAM_DETAIL",
                columns: table => new
                {
                    ExamID = table.Column<int>(nullable: false),
                    QuestionID = table.Column<int>(nullable: false)
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
                name: "RESULT",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<Guid>(nullable: false),
                    SubjectID = table.Column<string>(maxLength: 10, nullable: false),
                    ScoreID = table.Column<int>(nullable: false),
                    ExamID = table.Column<int>(nullable: false),
                    StudentAnswerID = table.Column<int>(nullable: false),
                    Mark = table.Column<float>(nullable: false),
                    Time = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESULT", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RESULT_EXAM_ExamID",
                        column: x => x.ExamID,
                        principalTable: "EXAM",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RESULT_SCORE_ScoreID",
                        column: x => x.ScoreID,
                        principalTable: "SCORE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RESULT_STUDENT_ANSWER_StudentAnswerID",
                        column: x => x.StudentAnswerID,
                        principalTable: "STUDENT_ANSWER",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_RESULT_SUBJECT_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "SUBJECT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RESULT_Account_UserID",
                        column: x => x.UserID,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "STUDENT_ANSWER_DETAIL",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentAnswerID = table.Column<int>(nullable: false),
                    QuestionID = table.Column<int>(nullable: false),
                    AnswerID = table.Column<int>(nullable: false),
                    EssayPath = table.Column<string>(nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
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
                table: "Account",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Birthday", "ClassID", "ConcurrencyStamp", "Email", "EmailConfirmed", "Gender", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Student_TeacherID", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("efe5c78c-bbc5-40e5-a106-1f07d4b4fcdb"), 0, null, new DateTime(1999, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "441e82b5-80cb-40b3-b96e-72315bab6ded", "keycodemon@gmail.com", true, true, false, null, "Keycode Mon", "keycodemon@gmail.com", "admin", "AQAAAAEAACcQAAAAEKAFDN/+G8PuwX4QdgOCh05TCbuOJPYH9Vyh+Ef7No+qdXugZVgXdCni9t9VNZhuHw==", null, false, "", null, false, "admin" });

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
                    { 4, "Nhóm câu hỏi chương 4" },
                    { 3, "Nhóm câu hỏi chương 3" },
                    { 5, "Nhóm câu hỏi chương 5" },
                    { 1, "Nhóm câu hỏi chương 1" },
                    { 2, "Nhóm câu hỏi chương 2" }
                });

            migrationBuilder.InsertData(
                table: "RoleAccount",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("61a4fad5-402c-4ce0-845d-1fbd2b91956f"), "a7e19840-e048-416c-81f2-96d69ebee2d3", "Vai trò quản trị viên", "admin", "admin" },
                    { new Guid("1e6d489f-1df4-4dab-b873-ce3224d87f94"), "c60c4428-f557-4848-9b2a-4c2be25b25fd", "Vai trò giảng viên", "teacher", "teacher" }
                });

            migrationBuilder.InsertData(
                table: "SCORE",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Điểm chuyên cần" },
                    { 2, "Điểm thường xuyên" },
                    { 3, "Điểm giữa môn" },
                    { 4, "Điểm kết thúc môn" }
                });

            migrationBuilder.InsertData(
                table: "SUBJECT",
                columns: new[] { "ID", "CreditCount", "Name" },
                values: new object[,]
                {
                    { "DT4301", 4, "Mạng máy tính" },
                    { "DT4205", 4, "SQL Server" },
                    { "DT4315", 4, "Công nghệ phần mềm" },
                    { "DT4208", 4, "Lập trình Java" },
                    { "DC4106", 4, "Kiến trúc máy tính" },
                    { "DH4202", 3, "Kỹ thuật lập trình" },
                    { "TC4209", 4, "Lập trình hướng đối tượng" },
                    { "DH4203", 4, "Cấu trúc dữ liệu & giải thuật" },
                    { "CC4206", 3, "Nhập môn lập trình" },
                    { "DC4204", 4, "Cơ sở dữ liệu" }
                });

            migrationBuilder.InsertData(
                table: "USER_ROLE",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("efe5c78c-bbc5-40e5-a106-1f07d4b4fcdb"), new Guid("61a4fad5-402c-4ce0-845d-1fbd2b91956f") },
                    { new Guid("4a2d9b6e-97c4-41bd-a929-f778972db109"), new Guid("1e6d489f-1df4-4dab-b873-ce3224d87f94") }
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Birthday", "ClassID", "ConcurrencyStamp", "Email", "EmailConfirmed", "Gender", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Student_TeacherID", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("4a2d9b6e-97c4-41bd-a929-f778972db109"), 0, "Số 80 - Hai Bà Trưng - Vạn Giã - Vạn Ninh - Khánh Hoà", new DateTime(1999, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "DHCN4A", "7c5e693a-1816-45cc-b055-ddbd7ce693ad", "htthinh1999@gmail.com", true, true, false, null, "Huỳnh Tấn Thịnh", "htthinh1999@gmail.com", "htthinh", "AQAAAAEAACcQAAAAEAQ1FIOr3R0CvTBjjrVK/6vMTclUmn5XOWITvyA7H1ffN46W62/LVJ6qXCc90kvmdg==", "0977393641", false, "", "17ĐC027", false, "htthinh" });

            migrationBuilder.InsertData(
                table: "QUESTION",
                columns: new[] { "ID", "Content", "GroupID", "IsMultipleChoice", "SubjectID" },
                values: new object[,]
                {
                    { 1, "Những tên biến nào dưới đây được viết đúng theo quy tắc đặt tên của ngôn ngữ lập trình C?", 1, true, "CC4206" },
                    { 2, "Một biến được gọi là biến toàn cục nếu:", 1, true, "CC4206" },
                    { 3, "Một biến được gọi là biến cục bộ nếu:", 1, true, "CC4206" }
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
                    { 12, "Nó được khai báo bên ngoài các hàm kể cả hàm main()", false, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_ClassID",
                table: "Account",
                column: "ClassID");

            migrationBuilder.CreateIndex(
                name: "IX_ANSWER_QuestionID",
                table: "ANSWER",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_EXAM_SubjectID",
                table: "EXAM",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_EXAM_DETAIL_QuestionID",
                table: "EXAM_DETAIL",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_QUESTION_GroupID",
                table: "QUESTION",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_QUESTION_SubjectID",
                table: "QUESTION",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_RESULT_ExamID",
                table: "RESULT",
                column: "ExamID");

            migrationBuilder.CreateIndex(
                name: "IX_RESULT_ScoreID",
                table: "RESULT",
                column: "ScoreID");

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
                name: "IX_SubjectTeacher_AccountId",
                table: "SubjectTeacher",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTeacher_ClassID",
                table: "SubjectTeacher",
                column: "ClassID");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTeacher_SubjectID",
                table: "SubjectTeacher",
                column: "SubjectID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EXAM_DETAIL");

            migrationBuilder.DropTable(
                name: "RESULT");

            migrationBuilder.DropTable(
                name: "ROLE_CLAIM");

            migrationBuilder.DropTable(
                name: "RoleAccount");

            migrationBuilder.DropTable(
                name: "STUDENT_ANSWER_DETAIL");

            migrationBuilder.DropTable(
                name: "SubjectTeacher");

            migrationBuilder.DropTable(
                name: "USER_CLAIM");

            migrationBuilder.DropTable(
                name: "USER_LOGIN");

            migrationBuilder.DropTable(
                name: "USER_ROLE");

            migrationBuilder.DropTable(
                name: "USER_TOKEN");

            migrationBuilder.DropTable(
                name: "SCORE");

            migrationBuilder.DropTable(
                name: "ANSWER");

            migrationBuilder.DropTable(
                name: "STUDENT_ANSWER");

            migrationBuilder.DropTable(
                name: "QUESTION");

            migrationBuilder.DropTable(
                name: "EXAM");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "QUESTION_GROUP");

            migrationBuilder.DropTable(
                name: "SUBJECT");

            migrationBuilder.DropTable(
                name: "CLASS");
        }
    }
}

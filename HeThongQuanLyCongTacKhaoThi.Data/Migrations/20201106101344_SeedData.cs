using Microsoft.EntityFrameworkCore.Migrations;

namespace HeThongQuanLyCongTacKhaoThi.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CLASS",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    StudentCount = table.Column<int>(nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLASS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EXAM",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXAM", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SCORE",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SCORE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SUBJECT",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
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
                name: "STUDENT_ANSWER",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "QUESTION",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectID = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: false),
                    IsMultipleChoice = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QUESTION", x => x.ID);
                    table.ForeignKey(
                        name: "FK_QUESTION_SUBJECT_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "SUBJECT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RESULT",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: false),
                    SubjectID = table.Column<string>(nullable: false),
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
                    EssayPath = table.Column<string>(nullable: false)
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
                table: "SCORE",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 4, "Điểm kết thúc môn" },
                    { 3, "Điểm giữa môn" },
                    { 1, "Điểm chuyên cần" },
                    { 2, "Điểm thường xuyên" }
                });

            migrationBuilder.InsertData(
                table: "SUBJECT",
                columns: new[] { "ID", "CreditCount", "Name" },
                values: new object[,]
                {
                    { "DT4205", 4, "SQL Server" },
                    { "CC4206", 3, "Nhập môn lập trình" },
                    { "DH4202", 3, "Kỹ thuật lập trình" },
                    { "DH4203", 4, "Cấu trúc dữ liệu & giải thuật" },
                    { "TC4209", 4, "Lập trình hướng đối tượng" },
                    { "DC4204", 4, "Cơ sở dữ liệu" },
                    { "DC4106", 4, "Kiến trúc máy tính" },
                    { "DT4208", 4, "Lập trình Java" },
                    { "DT4315", 4, "Công nghệ phần mềm" },
                    { "DT4301", 4, "Mạng máy tính" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ANSWER_QuestionID",
                table: "ANSWER",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_EXAM_DETAIL_QuestionID",
                table: "EXAM_DETAIL",
                column: "QuestionID");

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
                name: "IX_STUDENT_ANSWER_ExamID",
                table: "STUDENT_ANSWER",
                column: "ExamID");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CLASS");

            migrationBuilder.DropTable(
                name: "EXAM_DETAIL");

            migrationBuilder.DropTable(
                name: "RESULT");

            migrationBuilder.DropTable(
                name: "STUDENT_ANSWER_DETAIL");

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
                name: "SUBJECT");
        }
    }
}

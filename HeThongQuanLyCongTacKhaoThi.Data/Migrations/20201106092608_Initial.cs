using Microsoft.EntityFrameworkCore.Migrations;

namespace HeThongQuanLyCongTacKhaoThi.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CLASS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    AssiduousScorePercent = table.Column<float>(nullable: false),
                    FrequentScorePercent = table.Column<float>(nullable: false),
                    MiddleScorePercent = table.Column<float>(nullable: false),
                    FinalScorePercent = table.Column<float>(nullable: false),
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
                    SubjectID = table.Column<int>(nullable: false),
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
                    SubjectID = table.Column<int>(nullable: false),
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

using System.Collections.Generic;

namespace HeThongQuanLyCongTacKhaoThi.Data.Entities
{
    public class Exam
    {
        public int ID { get; set; }
        public string SubjectID { get; set; }
        public string Name { get; set; }
        public int ContestID { get; set; }

        public Subject Subject { get; set; }
        public Contest Contest { get; set; }

        public List<ExamDetail> ExamDetails { get; set; }
        public List<StudentAnswer> StudentAnswers { get; set; }
        public List<Result> Results { get; set; }
        public List<StudentContest> StudentContests { get; set; }

    }
}
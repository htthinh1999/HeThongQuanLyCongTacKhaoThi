using System.Collections.Generic;

namespace HeThongQuanLyCongTacKhaoThi.Data.Entities
{
    public class Subject
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public float AssiduousScorePercent { get; set; }
        public float FrequentScorePercent { get; set; }
        public float MiddleScorePercent { get; set; }
        public float FinalScorePercent { get; set; }
        public int CreditCount { get; set; }

        public List<Question> Questions { get; set; }
        public List<Result> Results { get; set; }
        public List<SubjectTeacher> SubjectTeachers { get; set; }
        public List<Exam> Exams { get; set; }
    }
}
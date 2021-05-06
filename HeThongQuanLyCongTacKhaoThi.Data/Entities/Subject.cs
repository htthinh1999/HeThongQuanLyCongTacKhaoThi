using System.Collections.Generic;

namespace HeThongQuanLyCongTacKhaoThi.Data.Entities
{
    public class Subject
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int LessonCount { get; set; }
        public int CreditCount { get; set; }

        public List<ScoreType> ScoreTypes { get; set; }
        public List<Question> Questions { get; set; }
        public List<Result> Results { get; set; }
        public List<SubjectAccount> SubjectAccounts { get; set; }
        public List<Exam> Exams { get; set; }
        public List<Contest> Contests { get; set; }
        public List<Notification> Notifications { get; set; }
    }
}
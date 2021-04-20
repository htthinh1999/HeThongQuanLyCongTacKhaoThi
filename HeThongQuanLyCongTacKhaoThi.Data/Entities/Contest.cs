using System;
using System.Collections.Generic;
using System.Text;

namespace HeThongQuanLyCongTacKhaoThi.Data.Entities
{
    public class Contest
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SubjectID { get; set; }
        public int ScoreTypeID { get; set; }
        public DateTime StartTime { get; set; }
        public int Duration { get; set; }

        public Subject Subject { get; set; }
        public ScoreType ScoreType { get; set; }

        public List<Result> Results { get; set; }
        public List<Exam> Exams { get; set; }
        public List<TeacherContest> TeacherContests { get; set; }
    }
}

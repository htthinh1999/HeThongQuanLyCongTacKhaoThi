using System;
using System.Collections.Generic;
using System.Text;

namespace HeThongQuanLyCongTacKhaoThi.Data.Entities
{
    public class Contest
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string SubjectID { get; set; }

        public Subject Subject { get; set; }

        public List<Result> Results { get; set; }
        public List<Exam> Exams { get; set; }
        public List<StudentContest> StudentContests { get; set; }
    }
}

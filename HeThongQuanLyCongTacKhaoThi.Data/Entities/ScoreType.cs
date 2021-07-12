using System.Collections.Generic;

namespace HeThongQuanLyCongTacKhaoThi.Data.Entities
{
    public class ScoreType
    {
        public int ID { get; set; }
        public string SubjectID { get; set; }
        public string Name { get; set; }
        public float Percent { get; set; }

        public Subject Subject { get; set; }

        public List<Contest> Contests { get; set; }
    }
}
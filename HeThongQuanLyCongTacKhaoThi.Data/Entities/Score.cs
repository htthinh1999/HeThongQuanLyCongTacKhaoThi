using System.Collections.Generic;

namespace HeThongQuanLyCongTacKhaoThi.Data.Entities
{
    public class Score
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public List<Result> Results { get; set; }
    }
}
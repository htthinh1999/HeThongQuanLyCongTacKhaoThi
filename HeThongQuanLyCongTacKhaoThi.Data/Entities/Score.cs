using System;
using System.Collections.Generic;
using System.Text;

namespace HeThongQuanLyCongTacKhaoThi.Data.Entities
{
    public class Score
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public List<Result> Results { get; set; }
    }
}

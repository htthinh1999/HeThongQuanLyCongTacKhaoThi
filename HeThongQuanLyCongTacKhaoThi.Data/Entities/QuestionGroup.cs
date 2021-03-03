using System;
using System.Collections.Generic;
using System.Text;

namespace HeThongQuanLyCongTacKhaoThi.Data.Entities
{
    public class QuestionGroup
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public List<Question> Questions { get; set; }
    }
}

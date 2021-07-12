using System.Collections.Generic;

namespace HeThongQuanLyCongTacKhaoThi.Data.Entities
{
    public class QuestionGroup
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public List<Question> Questions { get; set; }
    }
}
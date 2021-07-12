using System;
using System.Collections.Generic;
using System.Text;

namespace HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Results
{
    public class ScoreListFromDBModel
    {
        public string StudentID { get; set; }
        public string Name { get; set; }
        public string SubjectName { get; set; }
        public string ScoreName { get; set; }
        public float Percent { get; set; }
        public float? Score { get; set; }
    }
}

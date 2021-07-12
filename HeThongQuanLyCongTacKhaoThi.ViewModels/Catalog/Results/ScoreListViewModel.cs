using System;
using System.Collections.Generic;
using System.Text;

namespace HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Results
{
    public class ScoreListViewModel
    {
        public List<StudentResult> StudentResults { get; set; } = new List<StudentResult>();

        public class StudentResult
        {
            public string StudentID { get; set; }
            public string Name { get; set; }

            public List<SubjectResult> SubjectResults { get; set; } = new List<SubjectResult>();
        }

        public class SubjectResult
        {
            public string Name { get; set; }
            public float? FinalScore { get; set; }

            public List<ScoreModel> Scores { get; set; } = new List<ScoreModel>();
        }

        public class ScoreModel
        {
            public string Name { get; set; }
            public float? Score { get; set; }
            public float Percent { get; set; }
        }
    }
}

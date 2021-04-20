using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Exams;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Contests
{
    public class ContestViewModel
    {
        [DisplayName("Mã kỳ kiểm tra")]
        public int ID { get; set; }
        [DisplayName("Têb kỳ kiểm tra")]
        public string Name { get; set; }
        [DisplayName("Mã môn học")]
        public string SubjectID { get; set; }
        [DisplayName("Mã loại điểm")]
        public int ScoreTypeID { get; set; }
        [DisplayName("Loại điểm")]
        public string ScoreTypeName { get; set; }

        public List<ExamViewModel> Exams { get; set; }
    }
}

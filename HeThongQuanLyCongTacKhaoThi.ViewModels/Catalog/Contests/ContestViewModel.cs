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
        [DisplayName("Tên kỳ kiểm tra")]
        public string Name { get; set; }
        [DisplayName("Mã môn học")]
        public string SubjectID { get; set; }
        [DisplayName("Mã loại điểm")]
        public int ScoreTypeID { get; set; }
        [DisplayName("Loại điểm")]
        public string ScoreTypeName { get; set; }
        [DisplayName("Mô tả kỳ kiểm tra")]
        public string Description { get; set; }
        [DisplayName("Thời gian bắt đầu thi")]
        public DateTime StartTime { get; set; }
        [DisplayName("Thời gian thi")]
        public int Duration { get; set; }
        [DisplayName("Giáo viên 1")]
        public string Teacher1Name { get; set; }
        [DisplayName("Giáo viên 2")]
        public string Teacher2Name { get; set; }
        [DisplayName("Giáo viên chấm thi")]
        public string TeacherNames { get; set; }
        [DisplayName("Mã giáo viên 1")]
        public Guid Teacher1ID { get; set; }
        [DisplayName("Mã giáo viên 2")]
        public Guid Teacher2ID { get; set; }

        public List<ExamViewModel> Exams { get; set; }
    }
}

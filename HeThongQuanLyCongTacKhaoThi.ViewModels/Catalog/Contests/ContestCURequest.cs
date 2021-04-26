using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.ScoreType;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Subjects;
using HeThongQuanLyCongTacKhaoThi.ViewModels.System.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Contests
{
    public class ContestCURequest
    {
        [DisplayName("Mã kỳ kiểm tra")]
        public int ID { get; set; }
        [DisplayName("Tên kỳ kiểm tra")]
        public string Name { get; set; }
        [DisplayName("Mã môn học")]
        public string SubjectID { get; set; }
        [DisplayName("Mã loại điểm")]
        public int ScoreTypeID { get; set; }
        [DisplayName("Mô tả kỳ kiểm tra")]
        public string Description { get; set; }
        [DisplayName("Thời gian bắt đầu thi")]
        public DateTime StartTime { get; set; }
        [DisplayName("Thời gian thi")]
        public int Duration { get; set; }
        [DisplayName("Mã giáo viên 1")]
        public Guid Teacher1ID { get; set; }
        [DisplayName("Mã giáo viên 2")]
        public Guid Teacher2ID { get; set; }

        public List<SubjectViewModel> Subjects { get; set; }
        public List<ScoreTypeViewModel> ScoreTypes { get; set; }
        public List<AccountViewModel> Teachers { get; set; }
    }
}

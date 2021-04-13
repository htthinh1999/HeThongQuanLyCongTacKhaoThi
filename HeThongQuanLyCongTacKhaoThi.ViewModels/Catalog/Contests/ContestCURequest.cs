using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Subjects;
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

        public List<SubjectViewModel> Subjects { get; set; }
    }
}

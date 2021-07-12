using System.ComponentModel;

namespace HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Subjects
{
    public class SubjectViewModel
    {
        public string ID { get; set; }

        [DisplayName("Tên môn học")]
        public string Name { get; set; }

        [DisplayName("Số lượng tiết học")]
        public int LessonCount { get; set; }

        [DisplayName("Số lượng đơn vị học trình")]
        public int CreditCount { get; set; }
    }
}
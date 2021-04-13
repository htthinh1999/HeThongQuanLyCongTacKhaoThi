using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Subjects
{
    public class SubjectCURequest
    {
        [DisplayName("Mã môn học")]
        public string ID { get; set; }

        [DisplayName("Tên môn học")]
        public string Name { get; set; }

        [DisplayName("Số lượng tiết học")]
        public int LessonCount { get; set; }

        [DisplayName("Số lượng đơn vị học trình")]
        [Range(1, 10)]
        public int CreditCount { get; set; }
    }
}
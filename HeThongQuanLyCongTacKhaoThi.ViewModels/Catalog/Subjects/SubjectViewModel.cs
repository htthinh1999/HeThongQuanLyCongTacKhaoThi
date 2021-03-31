using System.ComponentModel;

namespace HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Subjects
{
    public class SubjectViewModel
    {
        public string ID { get; set; }

        [DisplayName("Tên môn học")]
        public string Name { get; set; }

        [DisplayName("Hệ số điểm chuyên cần")]
        public float AssiduousScorePercent { get; set; }

        [DisplayName("Hệ số điểm thường xuyên")]
        public float FrequentScorePercent { get; set; }

        [DisplayName("Hệ số điểm giữa môn")]
        public float MiddleScorePercent { get; set; }

        [DisplayName("Hệ số điểm kết thúc môn")]
        public float FinalScorePercent { get; set; }

        [DisplayName("Số lượng tín chỉ")]
        public int CreditCount { get; set; }
    }
}
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

        [DisplayName("Hệ số điểm chuyên cần")]
        [Range(0.1, 1f)]
        public float AssiduousScorePercent { get; set; }

        [DisplayName("Hệ số điểm thường xuyên")]
        [Range(0.1, 1f)]
        public float FrequentScorePercent { get; set; }

        [DisplayName("Hệ số điểm giữa môn")]
        [Range(0.1, 1f)]
        public float MiddleScorePercent { get; set; }

        [DisplayName("Hệ số điểm kết thúc môn")]
        [Range(0.1, 1f)]
        public float FinalScorePercent { get; set; }

        [DisplayName("Số lượng tín chỉ")]
        [Range(1, 10)]
        public int CreditCount { get; set; }
    }
}
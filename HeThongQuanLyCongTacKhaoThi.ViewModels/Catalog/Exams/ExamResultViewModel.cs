using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.StudentAnswers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Exams
{
    public class ExamResultViewModel
    {
        [DisplayName("Đề thi")]
        public string Name { get; set; }

        [DisplayName("Kỳ kiểm tra")]
        public string ContestName { get; set; }

        [DisplayName("Số lượng câu hỏi trắc nghiệm")]
        public int MultipleChoiceQuestionCount { get; set; }

        [DisplayName("Số lượng câu hỏi tự luận")]
        public int EssayQuestionCount { get; set; }

        [DisplayName("Mã phách bài thi")]
        public Guid StudentAnswerID { get; set; }

        [DisplayName("Điểm giáo viên 1")]
        public float? Mark1 { get; set; }

        [DisplayName("Điểm giáo viên 2")]
        public float? Mark2 { get; set; }


        [DisplayName("Điểm kết quả")]
        public float? Mark { get; set; }



        public List<StudentAnswerDetailViewModel> studentAnswerDetails { get; set; } = new List<StudentAnswerDetailViewModel>();
        
    }
}

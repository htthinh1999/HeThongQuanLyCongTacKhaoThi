using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.StudentAnswers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Exams
{
    public class ExamResultViewModel
    {
        [DisplayName("Tên đề thi")]
        public string Name { get; set; }

        [DisplayName("Số lượng câu hỏi trắc nghiệm")]
        public int MultipleChoiceQuestionCount { get; set; }

        [DisplayName("Số lượng câu hỏi tự luận")]
        public int EssayQuestionCount { get; set; }

        public Guid StudentAnswerID { get; set; }

        public List<StudentAnswerDetailViewModel> studentAnswerDetails { get; set; } = new List<StudentAnswerDetailViewModel>();
        
    }
}

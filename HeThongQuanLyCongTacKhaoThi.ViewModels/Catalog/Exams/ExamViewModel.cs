using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Subjects;
using System.Collections.Generic;
using System.ComponentModel;

namespace HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Exams
{
    public class ExamViewModel
    {
        [DisplayName("Mã đề thi")]
        public int ID { get; set; }

        [DisplayName("Mã môn học")]
        public string SubjectID { get; set; }

        [DisplayName("Tên đề thi")]
        public string Name { get; set; }

        [DisplayName("Số lượng câu hỏi trắc nghiệm")]
        public int MultipleChoiceQuestionCount { get; set; }

        [DisplayName("Số lượng câu hỏi tự luận")]
        public int EssayQuestionCount { get; set; }

        [DisplayName("Nhóm câu hỏi")]
        public List<int> QuestionGroups { get; set; } = new List<int>();

        public List<ExamDetailCURequest> ExamDetails { get; set; } = new List<ExamDetailCURequest>();
        
        public List<SubjectViewModel> Subjects { get; set; }
    }
}
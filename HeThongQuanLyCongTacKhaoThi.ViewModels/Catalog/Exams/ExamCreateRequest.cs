using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.QuestionGroups;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Subjects;
using System.Collections.Generic;
using System.ComponentModel;

namespace HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Exams
{
    public class ExamCreateRequest
    {
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
        public List<QuestionGroupViewModel> QuestionGroupViewModels { get; set; } = new List<QuestionGroupViewModel>();

        public List<int> QuestionGroups { get; set; }
        public List<SubjectViewModel> Subjects { get; set; }
    }
}
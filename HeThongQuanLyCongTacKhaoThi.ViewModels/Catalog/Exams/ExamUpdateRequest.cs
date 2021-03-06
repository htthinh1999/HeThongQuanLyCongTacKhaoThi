﻿using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Contests;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Subjects;
using System.Collections.Generic;
using System.ComponentModel;

namespace HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Exams
{
    public class ExamUpdateRequest
    {
        public int ID { get; set; }

        [DisplayName("Mã cuộc thi")]
        public int ContestID { get; set; }

        [DisplayName("Mã môn học")]
        public string SubjectID { get; set; }

        [DisplayName("Tên đề thi")]
        public string Name { get; set; }

        [DisplayName("Tạo lại đề")]
        public bool ReRandom { get; set; }

        [DisplayName("Số lượng câu hỏi trắc nghiệm")]
        public int MultipleChoiceQuestionCount { get; set; }

        [DisplayName("Số lượng câu hỏi tự luận")]
        public int EssayQuestionCount { get; set; }

        public SubjectViewModel Subject { get; set; }
        public List<ContestViewModel> Contests { get; set; }
        public List<int> QuestionGroups { get; set; }
    }
}
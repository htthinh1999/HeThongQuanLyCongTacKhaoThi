﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HeThongQuanLyCongTacKhaoThi.Data.Entities
{
    public class StudentAnswerDetail
    {
        public int ID { get; set; }
        public int StudentAnswerID { get; set; }
        public int QuestionID { get; set; }
        public int AnswerID { get; set; }
        public string EssayPath { get; set; }

        public StudentAnswer StudentAnswer { get; set; }
        public Question Question { get; set; }
        public Answer Answer { get; set; }
    }
}
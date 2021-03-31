using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace HeThongQuanLyCongTacKhaoThi.Data.Entities
{
    public class Account : IdentityUser<Guid>
    {
        public string Student_TeacherID { get; set; }
        public string Name { get; set; }
        public bool Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string ClassID { get; set; }
        public string Address { get; set; }

        public Class Class { get; set; }

        public List<Result> Results { get; set; }
        public List<SubjectTeacher> SubjectTeachers { get; set; }
        public List<StudentAnswer> StudentAnswers { get; set; }
    }
}
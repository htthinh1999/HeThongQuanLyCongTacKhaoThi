using HeThongQuanLyCongTacKhaoThi.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace HeThongQuanLyCongTacKhaoThi.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            /***************************** SEED CLASS *****************************/
            modelBuilder.Entity<Class>().HasData(
                new Class() { ID = "DHCN1A", Name = "Đại học công nghệ 1A" },
                new Class() { ID = "DHCN1B", Name = "Đại học công nghệ 1B" },
                new Class() { ID = "DHCN1C", Name = "Đại học công nghệ 1C" },
                new Class() { ID = "DHCN1D", Name = "Đại học công nghệ 1D" },
                new Class() { ID = "DHCN2A", Name = "Đại học công nghệ 2A" },
                new Class() { ID = "DHCN2B", Name = "Đại học công nghệ 2B" },
                new Class() { ID = "DHCN3A", Name = "Đại học công nghệ 3A" },
                new Class() { ID = "DHCN3B", Name = "Đại học công nghệ 3B" },
                new Class() { ID = "DHCN3C", Name = "Đại học công nghệ 3C" },
                new Class() { ID = "DHCN4A", Name = "Đại học công nghệ 4A" },
                new Class() { ID = "DHCN4B", Name = "Đại học công nghệ 4B" },
                new Class() { ID = "DHVT1", Name = "Đại học viễn thông 1" },
                new Class() { ID = "DHVT2", Name = "Đại học viễn thông 2" }
                );

            /***************************** SEED SUBJECT *****************************/
            modelBuilder.Entity<Subject>().HasData(
                new Subject() { ID = "CC4206", Name = "Nhập môn lập trình", CreditCount = 3 },
                new Subject() { ID = "DH4202", Name = "Kỹ thuật lập trình", CreditCount = 3 },
                new Subject() { ID = "DH4203", Name = "Cấu trúc dữ liệu & giải thuật", CreditCount = 4 },
                new Subject() { ID = "TC4209", Name = "Lập trình hướng đối tượng", CreditCount = 4 },
                new Subject() { ID = "DC4204", Name = "Cơ sở dữ liệu", CreditCount = 4 },
                new Subject() { ID = "DC4106", Name = "Kiến trúc máy tính", CreditCount = 4 },
                new Subject() { ID = "DT4208", Name = "Lập trình Java", CreditCount = 4 },
                new Subject() { ID = "DT4315", Name = "Công nghệ phần mềm", CreditCount = 4 },
                new Subject() { ID = "DT4205", Name = "SQL Server", CreditCount = 4 },
                new Subject() { ID = "DT4301", Name = "Mạng máy tính", CreditCount = 4 }
                );

            /***************************** SEED SCORE *****************************/
            modelBuilder.Entity<Score>().HasData(
                new Score() { ID = 1, Name = "Điểm chuyên cần" },
                new Score() { ID = 2, Name = "Điểm thường xuyên" },
                new Score() { ID = 3, Name = "Điểm giữa môn" },
                new Score() { ID = 4, Name = "Điểm kết thúc môn" }
                );

            /***************************** SEED ACCOUNT & ROLE ACCOUNT *****************************/
            // Create admin account
            Guid ADMIN_ID = new Guid("EFE5C78C-BBC5-40E5-A106-1F07D4B4FCDB");
            Guid ADMIN_ROLE_ID = new Guid("61A4FAD5-402C-4CE0-845D-1FBD2B91956F");
            modelBuilder.Entity<RoleAccount>().HasData(new RoleAccount
            {
                Id = ADMIN_ROLE_ID,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Vai trò quản trị viên"
            });

            var hasher = new PasswordHasher<Account>();
            modelBuilder.Entity<Account>().HasData(new Account
            {
                Id = ADMIN_ID,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "keycodemon@gmail.com",
                NormalizedEmail = "keycodemon@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "admin123"),
                SecurityStamp = string.Empty,
                Student_TeacherID = null,
                Name = "Keycode Mon",
                Gender = true,
                Birthday = new DateTime(1999, 09, 27),
                ClassID = null,
                Address = null
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = ADMIN_ROLE_ID,
                UserId = ADMIN_ID
            });


            // Create htthinh account
            Guid TEACHER_ID = new Guid("4A2D9B6E-97C4-41BD-A929-F778972DB109");
            Guid TEACHER_ROLE_ID = new Guid("1E6D489F-1DF4-4DAB-B873-CE3224D87F94");

            modelBuilder.Entity<RoleAccount>().HasData(new RoleAccount
            {
                Id = TEACHER_ROLE_ID,
                Name = "teacher",
                NormalizedName = "teacher",
                Description = "Vai trò giảng viên"
            });

            hasher = new PasswordHasher<Account>();
            modelBuilder.Entity<Account>().HasData(new Account
            {
                Id = TEACHER_ID,
                UserName = "htthinh",
                NormalizedUserName = "htthinh",
                Email = "htthinh1999@gmail.com",
                NormalizedEmail = "htthinh1999@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "htthinh123"),
                SecurityStamp = string.Empty,
                Student_TeacherID = "17ĐC027",
                Name = "Huỳnh Tấn Thịnh",
                Gender = true,
                Birthday = new DateTime(1999, 09, 27),
                ClassID = "DHCN4A",
                Address = "Số 80 - Hai Bà Trưng - Vạn Giã - Vạn Ninh - Khánh Hoà",
                PhoneNumber = "0977393641"
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = TEACHER_ROLE_ID,
                UserId = TEACHER_ID
            });


            /***************************** SEED QUESTION GROUP *****************************/
            modelBuilder.Entity<QuestionGroup>().HasData(new QuestionGroup
            {
                ID = 1,
                Name = "Nhóm câu hỏi chương 1"
            });

            modelBuilder.Entity<QuestionGroup>().HasData(new QuestionGroup
            {
                ID = 2,
                Name = "Nhóm câu hỏi chương 2"
            });

            modelBuilder.Entity<QuestionGroup>().HasData(new QuestionGroup
            {
                ID = 3,
                Name = "Nhóm câu hỏi chương 3"
            });

            modelBuilder.Entity<QuestionGroup>().HasData(new QuestionGroup
            {
                ID = 4,
                Name = "Nhóm câu hỏi chương 4"
            });

            modelBuilder.Entity<QuestionGroup>().HasData(new QuestionGroup
            {
                ID = 5,
                Name = "Nhóm câu hỏi chương 5"
            });


            /***************************** SEED QUESTION *****************************/
            modelBuilder.Entity<Question>().HasData(new Question
            {
                ID = 1,
                SubjectID = "CC4206",
                GroupID = 1,
                Content = "Những tên biến nào dưới đây được viết đúng theo quy tắc đặt tên của ngôn ngữ lập trình C?",
                IsMultipleChoice = true
            });

            modelBuilder.Entity<Question>().HasData(new Question
            {
                ID = 2,
                SubjectID = "CC4206",
                GroupID = 1,
                Content = "Một biến được gọi là biến toàn cục nếu:",
                IsMultipleChoice = true
            });

            modelBuilder.Entity<Question>().HasData(new Question
            {
                ID = 3,
                SubjectID = "CC4206",
                GroupID = 1,
                Content = "Một biến được gọi là biến cục bộ nếu:",
                IsMultipleChoice = true
            });

            /***************************** SEED ANSWER *****************************/
            modelBuilder.Entity<Answer>().HasData(new Answer
            {
                ID = 1,
                QuestionID = 1,
                Content = "diem toan",
                IsCorrect = false
            });

            modelBuilder.Entity<Answer>().HasData(new Answer
            {
                ID = 2,
                QuestionID = 1,
                Content = "3diemtoan",
                IsCorrect = false
            });

            modelBuilder.Entity<Answer>().HasData(new Answer
            {
                ID = 3,
                QuestionID = 1,
                Content = "_diemtoan",
                IsCorrect = true
            });

            modelBuilder.Entity<Answer>().HasData(new Answer
            {
                ID = 4,
                QuestionID = 1,
                Content = "-diemtoan",
                IsCorrect = false
            });

            modelBuilder.Entity<Answer>().HasData(new Answer
            {
                ID = 5,
                QuestionID = 2,
                Content = "Nó được khai báo tất cả các hàm, ngoại trừ hàm main()",
                IsCorrect = false
            });

            modelBuilder.Entity<Answer>().HasData(new Answer
            {
                ID = 6,
                QuestionID = 2,
                Content = "Nó được khai báo ngoài tất cả các hàm kể cả hàm main()",
                IsCorrect = true
            });

            modelBuilder.Entity<Answer>().HasData(new Answer
            {
                ID = 7,
                QuestionID = 2,
                Content = "Nó được khai báo bên ngoài hàm main()",
                IsCorrect = false
            });

            modelBuilder.Entity<Answer>().HasData(new Answer
            {
                ID = 8,
                QuestionID = 2,
                Content = "Nó được khai báo bên trong hàm main()",
                IsCorrect = false
            });

            modelBuilder.Entity<Answer>().HasData(new Answer
            {
                ID = 9,
                QuestionID = 3,
                Content = "Nó được khai báo bên trong các hàm hoặc thủ tục, kể cả hàm main()",
                IsCorrect = true
            });

            modelBuilder.Entity<Answer>().HasData(new Answer
            {
                ID = 10,
                QuestionID = 3,
                Content = "Nó được khai báo bên trong các hàm ngoại trừ hàm main()",
                IsCorrect = false
            });

            modelBuilder.Entity<Answer>().HasData(new Answer
            {
                ID = 11,
                QuestionID = 3,
                Content = "Nó được khai báo bên trong hàm main()",
                IsCorrect = false
            });

            modelBuilder.Entity<Answer>().HasData(new Answer
            {
                ID = 12,
                QuestionID = 3,
                Content = "Nó được khai báo bên ngoài các hàm kể cả hàm main()",
                IsCorrect = false
            });


        }
    }
}

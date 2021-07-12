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
                new Subject() { ID = "CC4206", Name = "Nhập môn lập trình", LessonCount = 45, CreditCount = 3 },
                new Subject() { ID = "DH4202", Name = "Kỹ thuật lập trình", LessonCount = 45, CreditCount = 3 },
                new Subject() { ID = "DH4203", Name = "Cấu trúc dữ liệu & giải thuật", LessonCount = 45, CreditCount = 4 },
                new Subject() { ID = "TC4209", Name = "Lập trình hướng đối tượng", LessonCount = 45, CreditCount = 4 },
                new Subject() { ID = "DC4204", Name = "Cơ sở dữ liệu", LessonCount = 45, CreditCount = 4 },
                new Subject() { ID = "DC4106", Name = "Kiến trúc máy tính", LessonCount = 45, CreditCount = 4 },
                new Subject() { ID = "DT4208", Name = "Lập trình Java", LessonCount = 45, CreditCount = 4 },
                new Subject() { ID = "DT4315", Name = "Công nghệ phần mềm", LessonCount = 45, CreditCount = 4 },
                new Subject() { ID = "DT4205", Name = "SQL Server", LessonCount = 45, CreditCount = 4 },
                new Subject() { ID = "DT4301", Name = "Mạng máy tính", LessonCount = 45, CreditCount = 4 }
                );

            /***************************** SEED SCORE *****************************/
            modelBuilder.Entity<ScoreType>().HasData(
                new ScoreType() { ID = 1, Name = "Điểm chuyên cần", SubjectID = "CC4206", Percent = 0.1f },
                new ScoreType() { ID = 2, Name = "Điểm thường xuyên", SubjectID = "CC4206", Percent = 0.2f },
                new ScoreType() { ID = 3, Name = "Điểm giữa môn", SubjectID = "CC4206", Percent = 0.2f },
                new ScoreType() { ID = 4, Name = "Điểm kết thúc môn", SubjectID = "CC4206", Percent = 0.5f },

                new ScoreType() { ID = 5, Name = "Điểm chuyên cần", SubjectID = "DH4202", Percent = 0.1f },
                new ScoreType() { ID = 6, Name = "Điểm thường xuyên", SubjectID = "DH4202", Percent = 0.2f },
                new ScoreType() { ID = 7, Name = "Điểm giữa môn", SubjectID = "DH4202", Percent = 0.2f },
                new ScoreType() { ID = 8, Name = "Điểm kết thúc môn", SubjectID = "DH4202", Percent = 0.5f },

                new ScoreType() { ID = 9, Name = "Điểm chuyên cần", SubjectID = "DH4203", Percent = 0.1f },
                new ScoreType() { ID = 10, Name = "Điểm thường xuyên", SubjectID = "DH4203", Percent = 0.2f },
                new ScoreType() { ID = 11, Name = "Điểm giữa môn", SubjectID = "DH4203", Percent = 0.2f },
                new ScoreType() { ID = 12, Name = "Điểm kết thúc môn", SubjectID = "DH4203", Percent = 0.5f },

                new ScoreType() { ID = 13, Name = "Điểm chuyên cần", SubjectID = "TC4209", Percent = 0.1f },
                new ScoreType() { ID = 14, Name = "Điểm thường xuyên", SubjectID = "TC4209", Percent = 0.2f },
                new ScoreType() { ID = 15, Name = "Điểm giữa môn", SubjectID = "TC4209", Percent = 0.2f },
                new ScoreType() { ID = 16, Name = "Điểm kết thúc môn", SubjectID = "TC4209", Percent = 0.5f },

                new ScoreType() { ID = 17, Name = "Điểm chuyên cần", SubjectID = "DC4204", Percent = 0.1f },
                new ScoreType() { ID = 18, Name = "Điểm thường xuyên", SubjectID = "DC4204", Percent = 0.2f },
                new ScoreType() { ID = 19, Name = "Điểm giữa môn", SubjectID = "DC4204", Percent = 0.2f },
                new ScoreType() { ID = 20, Name = "Điểm kết thúc môn", SubjectID = "DC4204", Percent = 0.5f },

                new ScoreType() { ID = 21, Name = "Điểm chuyên cần", SubjectID = "DC4106", Percent = 0.1f },
                new ScoreType() { ID = 22, Name = "Điểm thường xuyên", SubjectID = "DC4106", Percent = 0.2f },
                new ScoreType() { ID = 23, Name = "Điểm giữa môn", SubjectID = "DC4106", Percent = 0.2f },
                new ScoreType() { ID = 24, Name = "Điểm kết thúc môn", SubjectID = "DC4106", Percent = 0.5f },

                new ScoreType() { ID = 25, Name = "Điểm chuyên cần", SubjectID = "DT4208", Percent = 0.1f },
                new ScoreType() { ID = 26, Name = "Điểm thường xuyên", SubjectID = "DT4208", Percent = 0.2f },
                new ScoreType() { ID = 27, Name = "Điểm giữa môn", SubjectID = "DT4208", Percent = 0.2f },
                new ScoreType() { ID = 28, Name = "Điểm kết thúc môn", SubjectID = "DT4208", Percent = 0.5f },

                new ScoreType() { ID = 29, Name = "Điểm chuyên cần", SubjectID = "DT4315", Percent = 0.1f },
                new ScoreType() { ID = 30, Name = "Điểm thường xuyên", SubjectID = "DT4315", Percent = 0.2f },
                new ScoreType() { ID = 31, Name = "Điểm giữa môn", SubjectID = "DT4315", Percent = 0.2f },
                new ScoreType() { ID = 32, Name = "Điểm kết thúc môn", SubjectID = "DT4315", Percent = 0.5f },

                new ScoreType() { ID = 33, Name = "Điểm chuyên cần", SubjectID = "DT4205", Percent = 0.1f },
                new ScoreType() { ID = 34, Name = "Điểm thường xuyên", SubjectID = "DT4205", Percent = 0.2f },
                new ScoreType() { ID = 35, Name = "Điểm giữa môn", SubjectID = "DT4205", Percent = 0.2f },
                new ScoreType() { ID = 36, Name = "Điểm kết thúc môn", SubjectID = "DT4205", Percent = 0.5f },

                new ScoreType() { ID = 37, Name = "Điểm chuyên cần", SubjectID = "DT4301", Percent = 0.1f },
                new ScoreType() { ID = 38, Name = "Điểm thường xuyên", SubjectID = "DT4301", Percent = 0.2f },
                new ScoreType() { ID = 39, Name = "Điểm giữa môn", SubjectID = "DT4301", Percent = 0.2f },
                new ScoreType() { ID = 40, Name = "Điểm kết thúc môn", SubjectID = "DT4301", Percent = 0.5f }
                );

            /***************************** SEED ROLE ACCOUNT *****************************/
            // Admin Role
            Guid ADMIN_ROLE_ID = new Guid("61A4FAD5-402C-4CE0-845D-1FBD2B91956F");
            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = ADMIN_ROLE_ID,
                Name = "Admin",
                NormalizedName = "admin",
                Description = "Vai trò quản trị viên"
            });

            // Teacher Role
            Guid TEACHER_ROLE_ID = new Guid("1E6D489F-1DF4-4DAB-B873-CE3224D87F94");

            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = TEACHER_ROLE_ID,
                Name = "Teacher",
                NormalizedName = "teacher",
                Description = "Vai trò giảng viên"
            });

            // Student Role
            Guid STUDENT_ROLE_ID = new Guid("9A34BDD4-FA97-4E2F-9960-B19A68826BE9");

            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = STUDENT_ROLE_ID,
                Name = "Student",
                NormalizedName = "student",
                Description = "Vai trò học viên"
            });

            /***************************** SEED ACCOUNT *****************************/
            // Create admin account
            Guid ADMIN_ID = new Guid("EFE5C78C-BBC5-40E5-A106-1F07D4B4FCDB");
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
            Guid HTTHINH_ID = new Guid("4A2D9B6E-97C4-41BD-A929-F778972DB109");
            hasher = new PasswordHasher<Account>();
            modelBuilder.Entity<Account>().HasData(new Account
            {
                Id = HTTHINH_ID,
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
                UserId = HTTHINH_ID
            });

            // Create sinhvien 1 account
            Guid STUDENT1_ID = new Guid("9E7773EF-083C-4A8E-8ED2-9E36CD704913");
            hasher = new PasswordHasher<Account>();
            modelBuilder.Entity<Account>().HasData(new Account
            {
                Id = STUDENT1_ID,
                UserName = "sv1",
                NormalizedUserName = "sv1",
                Email = "sv1@gmail.com",
                NormalizedEmail = "sv1@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "sinhvien123"),
                SecurityStamp = string.Empty,
                Student_TeacherID = "17ĐC028",
                Name = "Sinh viên 1",
                Gender = true,
                Birthday = new DateTime(2000, 10, 27),
                ClassID = "DHCN4A",
                Address = "Khánh Hoà",
                PhoneNumber = "0987333644"
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = STUDENT_ROLE_ID,
                UserId = STUDENT1_ID
            });

            // Create sinhvien 2 account
            Guid STUDENT2_ID = new Guid("8BC30F33-6382-45FD-A54A-0DEC677631D9");
            hasher = new PasswordHasher<Account>();
            modelBuilder.Entity<Account>().HasData(new Account
            {
                Id = STUDENT2_ID,
                UserName = "sv2",
                NormalizedUserName = "sv2",
                Email = "sv2@gmail.com",
                NormalizedEmail = "sv2@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "sinhvien123"),
                SecurityStamp = string.Empty,
                Student_TeacherID = "17ĐC023",
                Name = "Sinh viên 2",
                Gender = true,
                Birthday = new DateTime(2000, 03, 20),
                ClassID = "DHCN4A",
                Address = "Khánh Hoà",
                PhoneNumber = "0987666644"
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = STUDENT_ROLE_ID,
                UserId = STUDENT2_ID
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

            modelBuilder.Entity<Question>().HasData(new Question
            {
                ID = 4,
                SubjectID = "CC4206",
                GroupID = 2,
                Content = "Nhận định nào sau đây KHÔNG ĐÚNG về đệ quy vô hạn?",
                IsMultipleChoice = true
            });

            modelBuilder.Entity<Question>().HasData(new Question
            {
                ID = 5,
                SubjectID = "CC4206",
                GroupID = 2,
                Content = "Trong các phương pháp sắp xếp: lựa chọn, chèn, đổi chỗ(nổi bọt), quicksort (sắp xếp nhanh), mergesort (sắp xếp trộn), thì phương pháp nào là phù hợp nhất để sắp xếp trên danh sách liên kết đơn ? Giải thích ? ",
                IsMultipleChoice = false
            });

            modelBuilder.Entity<Question>().HasData(new Question
            {
                ID = 6,
                SubjectID = "CC4206",
                GroupID = 2,
                Content = "Trình bày sự khác biệt giữa mảng cấp phát bộ nhớ động và mảng cấp phát tĩnh? Khi nào dùng mảng cấp phát động, mảng cấp phát tĩnh ? Cho ví dụ ?",
                IsMultipleChoice = false
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

            modelBuilder.Entity<Answer>().HasData(new Answer
            {
                ID = 13,
                QuestionID = 4,
                Content = "Đệ quy khiến chương trình bị treo.",
                IsCorrect = false
            });

            modelBuilder.Entity<Answer>().HasData(new Answer
            {
                ID = 14,
                QuestionID = 4,
                Content = "Đệ quy vô hạn tiêu tốn toàn bộ bộ nhớ của hệ thống dành cho chương trình và khiến cho chương trình kết thúc một cách bất thường.",
                IsCorrect = false
            });

            modelBuilder.Entity<Answer>().HasData(new Answer
            {
                ID = 15,
                QuestionID = 4,
                Content = "	Gọi đệ quy gián tiếp luôn gây ra đệ quy vô hạn.",
                IsCorrect = true
            });

            modelBuilder.Entity<Answer>().HasData(new Answer
            {
                ID = 16,
                QuestionID = 4,
                Content = "Nếu lời gọi đệ quy không đi đến điểm dừng (base case) thì đệ quy vô hạn sẽ xuất hiện.",
                IsCorrect = false
            });
        }
    }
}
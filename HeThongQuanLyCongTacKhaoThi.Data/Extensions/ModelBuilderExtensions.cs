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

            /***************************** SEED ROLE ACCOUNT *****************************/
            // Admin Role
            Guid ADMIN_ROLE_ID = new Guid("61A4FAD5-402C-4CE0-845D-1FBD2B91956F");
            modelBuilder.Entity<RoleAccount>().HasData(new RoleAccount
            {
                Id = ADMIN_ROLE_ID,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Vai trò quản trị viên"
            });

            // Teacher Role
            Guid TEACHER_ROLE_ID = new Guid("1E6D489F-1DF4-4DAB-B873-CE3224D87F94");

            modelBuilder.Entity<RoleAccount>().HasData(new RoleAccount
            {
                Id = TEACHER_ROLE_ID,
                Name = "teacher",
                NormalizedName = "teacher",
                Description = "Vai trò giảng viên"
            });

            // Student Role
            Guid STUDENT_ROLE_ID = new Guid("9A34BDD4-FA97-4E2F-9960-B19A68826BE9");

            modelBuilder.Entity<RoleAccount>().HasData(new RoleAccount
            {
                Id = STUDENT_ROLE_ID,
                Name = "teacher",
                NormalizedName = "teacher",
                Description = "Vai trò giảng viên"
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

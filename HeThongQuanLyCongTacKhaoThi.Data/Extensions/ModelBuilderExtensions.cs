using HeThongQuanLyCongTacKhaoThi.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeThongQuanLyCongTacKhaoThi.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
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

            modelBuilder.Entity<Score>().HasData(
                new Score() { ID = 1, Name = "Điểm chuyên cần" },
                new Score() { ID = 2, Name = "Điểm thường xuyên" },
                new Score() { ID = 3, Name = "Điểm giữa môn" },
                new Score() { ID = 4, Name = "Điểm kết thúc môn" }
                );

            Guid ADMIN_ID = new Guid("EFE5C78C-BBC5-40E5-A106-1F07D4B4FCDB");
            Guid ROLE_ID = ADMIN_ID;
            modelBuilder.Entity<RoleAccount>().HasData(new RoleAccount
            {
                Id = ROLE_ID,
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
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });
        }
    }
}

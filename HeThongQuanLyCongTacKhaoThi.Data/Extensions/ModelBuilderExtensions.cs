using HeThongQuanLyCongTacKhaoThi.Data.Entities;
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

        }
    }
}

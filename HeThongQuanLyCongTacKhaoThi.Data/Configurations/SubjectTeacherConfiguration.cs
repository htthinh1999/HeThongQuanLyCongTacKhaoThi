using HeThongQuanLyCongTacKhaoThi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeThongQuanLyCongTacKhaoThi.Data.Configurations
{
    public class SubjectTeacherConfiguration : IEntityTypeConfiguration<SubjectTeacher>
    {
        public void Configure(EntityTypeBuilder<SubjectTeacher> builder)
        {
            builder.ToTable("SUBJECT_TEACHER");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.UserID).IsRequired();
            builder.Property(x => x.SubjectID).IsRequired().HasMaxLength(10);
            builder.Property(x => x.ClassID).IsRequired().HasMaxLength(15);

            builder.HasOne(x => x.Account).WithMany(a => a.SubjectTeachers).HasForeignKey(x => x.UserID);
            builder.HasOne(x => x.Subject).WithMany(s => s.SubjectTeachers).HasForeignKey(x => x.SubjectID);
            builder.HasOne(x => x.Class).WithMany(c => c.SubjectTeachers).HasForeignKey(x => x.Class);
        }
    }
}

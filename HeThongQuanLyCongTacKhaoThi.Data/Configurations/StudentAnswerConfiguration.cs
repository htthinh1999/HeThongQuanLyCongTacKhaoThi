using HeThongQuanLyCongTacKhaoThi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeThongQuanLyCongTacKhaoThi.Data.Configurations
{
    public class StudentAnswerConfiguration : IEntityTypeConfiguration<StudentAnswer>
    {
        public void Configure(EntityTypeBuilder<StudentAnswer> builder)
        {
            builder.ToTable("STUDENT_ANSWER");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Username).IsRequired();
            builder.Property(x => x.ExamID).IsRequired();

            builder.HasOne(x => x.Exam).WithMany(e => e.StudentAnswers).HasForeignKey(x => x.ExamID);
        }
    }
}

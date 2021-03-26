using HeThongQuanLyCongTacKhaoThi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeThongQuanLyCongTacKhaoThi.Data.Configurations
{
    public class ExamDetailConfiguration : IEntityTypeConfiguration<ExamDetail>
    {
        public void Configure(EntityTypeBuilder<ExamDetail> builder)
        {
            builder.ToTable("EXAM_DETAIL");
            builder.HasKey(x => new { x.ExamID, x.QuestionID });

            builder.HasOne(x => x.Exam).WithMany(e => e.ExamDetails).HasForeignKey(x => x.ExamID);
            builder.HasOne(x => x.Question).WithMany(e => e.ExamDetails).HasForeignKey(x => x.QuestionID).OnDelete(DeleteBehavior.Restrict); ;
        }
    }
}

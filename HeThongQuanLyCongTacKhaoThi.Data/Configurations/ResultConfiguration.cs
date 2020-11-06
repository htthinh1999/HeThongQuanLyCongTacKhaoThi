using HeThongQuanLyCongTacKhaoThi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeThongQuanLyCongTacKhaoThi.Data.Configurations
{
    class ResultConfiguration : IEntityTypeConfiguration<Result>
    {
        public void Configure(EntityTypeBuilder<Result> builder)
        {
            builder.ToTable("RESULT");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Username).IsRequired();
            builder.Property(x => x.SubjectID).IsRequired();
            builder.Property(x => x.ScoreID).IsRequired();
            builder.Property(x => x.ExamID).IsRequired();
            builder.Property(x => x.StudentAnswerID).IsRequired();
            builder.Property(x => x.Mark).IsRequired();
            builder.Property(x => x.Time).IsRequired();

            builder.HasOne(x => x.Subject).WithMany(s => s.Results).HasForeignKey(x => x.SubjectID);
            builder.HasOne(x => x.Score).WithMany(s => s.Results).HasForeignKey(x => x.ScoreID);
            builder.HasOne(x => x.Exam).WithMany(s => s.Results).HasForeignKey(x => x.ExamID);
            builder.HasOne(x => x.StudentAnswer).WithMany(s => s.Results).HasForeignKey(x => x.StudentAnswerID).OnDelete(DeleteBehavior.NoAction);
        }
    }
}

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
            builder.Property(x => x.UserID).IsRequired();
            builder.Property(x => x.SubjectID).IsRequired().HasMaxLength(10);
            builder.Property(x => x.ScoreID).IsRequired();
            builder.Property(x => x.ExamID).IsRequired();
            builder.Property(x => x.StudentAnswerID).IsRequired();
            builder.Property(x => x.Mark).IsRequired();
            builder.Property(x => x.Time).IsRequired();

            builder.HasOne(x => x.Subject).WithMany(s => s.Results).HasForeignKey(x => x.SubjectID);
            builder.HasOne(x => x.Score).WithMany(s => s.Results).HasForeignKey(x => x.ScoreID);
            builder.HasOne(x => x.Exam).WithMany(s => s.Results).HasForeignKey(x => x.ExamID);
            builder.HasOne(x => x.StudentAnswer).WithMany(s => s.Results).HasForeignKey(x => x.StudentAnswerID).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Account).WithMany(a => a.Results).HasForeignKey(x => x.UserID);
        }
    }
}

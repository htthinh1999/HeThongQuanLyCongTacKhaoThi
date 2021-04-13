using HeThongQuanLyCongTacKhaoThi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HeThongQuanLyCongTacKhaoThi.Data.Configurations
{
    internal class ResultConfiguration : IEntityTypeConfiguration<Result>
    {
        public void Configure(EntityTypeBuilder<Result> builder)
        {
            builder.ToTable("RESULT");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.UserID).IsRequired();
            builder.Property(x => x.SubjectID).IsRequired().HasMaxLength(10);
            builder.Property(x => x.ScoreTypeID).IsRequired();
            builder.Property(x => x.ContestID).IsRequired();
            builder.Property(x => x.ExamID).IsRequired();
            builder.Property(x => x.StudentAnswerID).IsRequired();
            builder.Property(x => x.Mark).IsRequired();
            builder.Property(x => x.Time).IsRequired();

            builder.HasOne(x => x.Subject).WithMany(s => s.Results).HasForeignKey(x => x.SubjectID).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.ScoreType).WithMany(s => s.Results).HasForeignKey(x => x.ScoreTypeID).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Contest).WithMany(c => c.Results).HasForeignKey(x => x.ContestID).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Exam).WithMany(s => s.Results).HasForeignKey(x => x.ExamID).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.StudentAnswer).WithMany(s => s.Results).HasForeignKey(x => x.StudentAnswerID).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Account).WithMany(a => a.Results).HasForeignKey(x => x.UserID).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
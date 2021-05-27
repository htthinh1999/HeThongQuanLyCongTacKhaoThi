using HeThongQuanLyCongTacKhaoThi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HeThongQuanLyCongTacKhaoThi.Data.Configurations
{
    public class StudentAnswerDetailConfiguration : IEntityTypeConfiguration<StudentAnswerDetail>
    {
        public void Configure(EntityTypeBuilder<StudentAnswerDetail> builder)
        {
            builder.ToTable("STUDENT_ANSWER_DETAIL");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.StudentAnswerID).IsRequired();
            builder.Property(x => x.QuestionID).IsRequired();
            builder.Property(x => x.AnswerID).HasDefaultValue();
            builder.Property(x => x.EssayPath).HasDefaultValue();
            builder.Property(x => x.StudentAnswerContent).HasDefaultValue().IsUnicode();
            builder.Property(x => x.Teacher1Comment).HasDefaultValue("Chưa có nhận xét!");
            builder.Property(x => x.Teacher2Comment).HasDefaultValue("Chưa có nhận xét!");

            builder.HasOne(x => x.StudentAnswer).WithMany(sa => sa.StudentAnswerDetails).HasForeignKey(x => x.StudentAnswerID);
            builder.HasOne(x => x.Question).WithMany(sa => sa.StudentAnswerDetails).HasForeignKey(x => x.QuestionID).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Answer).WithMany(sa => sa.StudentAnswerDetails).HasForeignKey(x => x.AnswerID);
        }
    }
}
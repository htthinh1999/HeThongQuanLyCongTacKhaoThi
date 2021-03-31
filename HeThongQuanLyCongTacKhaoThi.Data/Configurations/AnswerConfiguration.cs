using HeThongQuanLyCongTacKhaoThi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HeThongQuanLyCongTacKhaoThi.Data.Configurations
{
    public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.ToTable("ANSWER");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.QuestionID).IsRequired();
            builder.Property(x => x.Content).IsRequired().IsUnicode();
            builder.Property(x => x.IsCorrect).IsRequired();

            builder.HasOne(x => x.Question).WithMany(q => q.Answers).HasForeignKey(x => x.QuestionID);
        }
    }
}
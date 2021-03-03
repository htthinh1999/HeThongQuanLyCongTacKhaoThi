using HeThongQuanLyCongTacKhaoThi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeThongQuanLyCongTacKhaoThi.Data.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable("QUESTION");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.SubjectID).IsRequired().HasMaxLength(10);
            builder.Property(x => x.GroupID).IsRequired();
            builder.Property(x => x.Content).IsRequired().IsUnicode();
            builder.Property(x => x.IsMultipleChoice).IsRequired();

            builder.HasOne(x => x.Subject).WithMany(s => s.Questions).HasForeignKey(x => x.SubjectID);
            builder.HasOne(x => x.Group).WithMany(s => s.Questions).HasForeignKey(x => x.GroupID);
        }
    }
}

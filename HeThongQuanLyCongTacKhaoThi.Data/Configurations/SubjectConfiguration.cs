using HeThongQuanLyCongTacKhaoThi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeThongQuanLyCongTacKhaoThi.Data.Configurations
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.ToTable("SUBJECT");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).HasMaxLength(10);
            builder.Property(x => x.Name).IsRequired().IsUnicode().HasMaxLength(50);
            builder.Property(x => x.AssiduousScorePercent).IsRequired().HasDefaultValue(0.1f);
            builder.Property(x => x.FrequentScorePercent).IsRequired().HasDefaultValue(.2f);
            builder.Property(x => x.MiddleScorePercent).IsRequired().HasDefaultValue(.2f);
            builder.Property(x => x.FinalScorePercent).IsRequired().HasDefaultValue(.5f);
            builder.Property(x => x.CreditCount).IsRequired();
        }
    }
}

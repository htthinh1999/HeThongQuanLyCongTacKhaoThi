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
            builder.Property(x => x.Name).IsRequired().IsUnicode();
            builder.Property(x => x.AssiduousScorePercent).IsRequired();
            builder.Property(x => x.FrequentScorePercent).IsRequired();
            builder.Property(x => x.MiddleScorePercent).IsRequired();
            builder.Property(x => x.FinalScorePercent).IsRequired();
            builder.Property(x => x.CreditCount).IsRequired();
        }
    }
}

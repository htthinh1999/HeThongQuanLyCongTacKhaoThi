using HeThongQuanLyCongTacKhaoThi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeThongQuanLyCongTacKhaoThi.Data.Configurations
{
    public class ContestConfiguration : IEntityTypeConfiguration<Contest>
    {
        public void Configure(EntityTypeBuilder<Contest> builder)
        {
            builder.ToTable("CONTEST");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Name).IsRequired().IsUnicode().HasMaxLength(50);
            builder.Property(x => x.SubjectID).IsRequired();
            builder.Property(x => x.ScoreTypeID).IsRequired();
            builder.Property(x => x.StartTime).IsRequired();
            builder.Property(x => x.Duration).IsRequired();

            builder.HasOne(x => x.Subject).WithMany(a => a.Contests).HasForeignKey(x => x.SubjectID);
            builder.HasOne(x => x.ScoreType).WithMany(s => s.Contests).HasForeignKey(x => x.ScoreTypeID).OnDelete(DeleteBehavior.NoAction);
        }
    }
}

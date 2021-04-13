using HeThongQuanLyCongTacKhaoThi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HeThongQuanLyCongTacKhaoThi.Data.Configurations
{
    public class ScoreTypeConfiguration : IEntityTypeConfiguration<ScoreType>
    {
        public void Configure(EntityTypeBuilder<ScoreType> builder)
        {
            builder.ToTable("SCORE_TYPE");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Name).IsRequired().IsUnicode().HasMaxLength(20);
            builder.Property(x => x.SubjectID).IsRequired().HasMaxLength(10);
            builder.Property(x => x.Percent).IsRequired();

            builder.HasOne(x => x.Subject).WithMany(s => s.ScoreTypes).HasForeignKey(x => x.SubjectID);
        }
    }
}
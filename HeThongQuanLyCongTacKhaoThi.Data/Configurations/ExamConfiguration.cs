using HeThongQuanLyCongTacKhaoThi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HeThongQuanLyCongTacKhaoThi.Data.Configurations
{
    public class ExamConfiguration : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.ToTable("EXAM");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Name).IsRequired().IsUnicode().HasMaxLength(50);
            builder.Property(x => x.SubjectID).IsRequired().HasMaxLength(10);
            builder.Property(x => x.ContestID).IsRequired();

            builder.HasOne(x => x.Subject).WithMany(s => s.Exams).HasForeignKey(x => x.SubjectID).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Contest).WithMany(c => c.Exams).HasForeignKey(x => x.ContestID).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
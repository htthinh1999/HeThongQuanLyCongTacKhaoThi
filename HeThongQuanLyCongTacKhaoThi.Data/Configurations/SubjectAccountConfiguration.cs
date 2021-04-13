using HeThongQuanLyCongTacKhaoThi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HeThongQuanLyCongTacKhaoThi.Data.Configurations
{
    public class SubjectAccountConfiguration : IEntityTypeConfiguration<SubjectAccount>
    {
        public void Configure(EntityTypeBuilder<SubjectAccount> builder)
        {
            builder.ToTable("SUBJECT_ACCOUNT");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.UserID).IsRequired();
            builder.Property(x => x.SubjectID).IsRequired().HasMaxLength(10);
            builder.Property(x => x.ClassID).IsRequired().HasMaxLength(15);

            builder.HasOne(x => x.Account).WithMany(a => a.SubjectAccounts).HasForeignKey(x => x.UserID);
            builder.HasOne(x => x.Subject).WithMany(s => s.SubjectAccounts).HasForeignKey(x => x.SubjectID);
            builder.HasOne(x => x.Class).WithMany(c => c.SubjectAccounts).HasForeignKey(x => x.ClassID);
        }
    }
}
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
            builder.HasKey(x => new { x.UserID, x.SubjectID });
            builder.Property(x => x.UserID);
            builder.Property(x => x.SubjectID).HasMaxLength(10);

            builder.HasOne(x => x.Account).WithMany(a => a.SubjectAccounts).HasForeignKey(x => x.UserID);
            builder.HasOne(x => x.Subject).WithMany(s => s.SubjectAccounts).HasForeignKey(x => x.SubjectID);
        }
    }
}
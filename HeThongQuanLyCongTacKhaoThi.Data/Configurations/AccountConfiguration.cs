using HeThongQuanLyCongTacKhaoThi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HeThongQuanLyCongTacKhaoThi.Data.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Account");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Student_TeacherID).IsRequired(false).HasMaxLength(10);
            builder.Property(x => x.Name).IsRequired().IsUnicode().HasMaxLength(50);
            builder.Property(x => x.Gender).IsRequired();
            builder.Property(x => x.Birthday).IsRequired();
            builder.Property(x => x.ClassID).IsRequired(false).HasMaxLength(15);
            builder.Property(x => x.Address).IsRequired(false).IsUnicode().HasMaxLength(100);

            builder.HasOne(x => x.Class).WithMany(c => c.Accounts).HasForeignKey(x => x.ClassID);
        }
    }
}
using HeThongQuanLyCongTacKhaoThi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HeThongQuanLyCongTacKhaoThi.Data.Configurations
{
    public class RoleAccountConfiguration : IEntityTypeConfiguration<RoleAccount>
    {
        public void Configure(EntityTypeBuilder<RoleAccount> builder)
        {
            builder.ToTable("RoleAccount");
            builder.Property(x => x.Description).IsRequired().IsUnicode().HasMaxLength(100);
        }
    }
}
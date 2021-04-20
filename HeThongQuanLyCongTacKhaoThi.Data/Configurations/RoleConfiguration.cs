using HeThongQuanLyCongTacKhaoThi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HeThongQuanLyCongTacKhaoThi.Data.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("ROLE");

            builder.Property(x => x.Description).IsRequired().IsUnicode().HasMaxLength(100);
        }
    }
}
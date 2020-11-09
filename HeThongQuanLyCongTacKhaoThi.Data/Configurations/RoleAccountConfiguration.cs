using HeThongQuanLyCongTacKhaoThi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

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

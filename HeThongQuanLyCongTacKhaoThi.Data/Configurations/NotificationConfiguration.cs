using HeThongQuanLyCongTacKhaoThi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeThongQuanLyCongTacKhaoThi.Data.Configurations
{
    class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.ToTable("NOTIFICATION");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.AccountID).IsRequired();
            builder.Property(x => x.StudentAnswerID).HasDefaultValue(Guid.Empty);
            builder.Property(x => x.Message).HasDefaultValue(string.Empty);
            builder.Property(x => x.DateTime).IsRequired().HasDefaultValueSql("getdate()");
            builder.Property(x => x.IsRead).IsRequired().HasDefaultValue(false);
            builder.Property(x => x.SubjectID).IsRequired(false).HasMaxLength(10);

            builder.HasOne(x => x.Account).WithMany(a => a.Notifications).HasForeignKey(x => x.AccountID);
            builder.HasOne(x => x.StudentAnswer).WithMany(sa => sa.Notifications).HasForeignKey(x => x.StudentAnswerID).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Subject).WithMany(s => s.Notifications).HasForeignKey(x => x.SubjectID).OnDelete(DeleteBehavior.NoAction);
        }
    }
}

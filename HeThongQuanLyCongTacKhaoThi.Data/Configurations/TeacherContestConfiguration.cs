using HeThongQuanLyCongTacKhaoThi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeThongQuanLyCongTacKhaoThi.Data.Configurations
{
    class TeacherContestConfiguration : IEntityTypeConfiguration<TeacherContest>
    {
        public void Configure(EntityTypeBuilder<TeacherContest> builder)
        {
            builder.ToTable("TEACHER_CONTEST");
            builder.HasKey(x => new { x.TeacherID, x.ContestID });

            builder.HasOne(x => x.Teacher).WithMany(c => c.TeacherContests).HasForeignKey(x => x.TeacherID);
            builder.HasOne(x => x.Contest).WithMany(c => c.TeacherContests).HasForeignKey(x => x.ContestID);
        }
    }
}

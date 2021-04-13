using HeThongQuanLyCongTacKhaoThi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeThongQuanLyCongTacKhaoThi.Data.Configurations
{
    public class StudentContestConfiguration : IEntityTypeConfiguration<StudentContest>
    {
        public void Configure(EntityTypeBuilder<StudentContest> builder)
        {
            builder.ToTable("STUDENT_CONTEST");
            builder.HasKey(x => new { x.AccountID, x.ContestID, x.ExamID });

            builder.HasOne(x => x.Account).WithMany(a => a.StudentContests).HasForeignKey(x => x.AccountID).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Contest).WithMany(a => a.StudentContests).HasForeignKey(x => x.ContestID).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Exam).WithMany(a => a.StudentContests).HasForeignKey(x => x.ExamID).OnDelete(DeleteBehavior.Restrict);

        }
    }
}

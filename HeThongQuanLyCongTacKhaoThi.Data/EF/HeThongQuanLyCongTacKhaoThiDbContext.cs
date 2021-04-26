using HeThongQuanLyCongTacKhaoThi.Data.Configurations;
using HeThongQuanLyCongTacKhaoThi.Data.Entities;
using HeThongQuanLyCongTacKhaoThi.Data.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace HeThongQuanLyCongTacKhaoThi.Data.EF
{
    public class HeThongQuanLyCongTacKhaoThiDbContext : IdentityDbContext<Account, Role, Guid>
    {
        public HeThongQuanLyCongTacKhaoThiDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuration using Fluent API
            modelBuilder.ApplyConfiguration(new ClassConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());
            modelBuilder.ApplyConfiguration(new ContestConfiguration());
            modelBuilder.ApplyConfiguration(new ScoreTypeConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionGroupConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionConfiguration());
            modelBuilder.ApplyConfiguration(new AnswerConfiguration());
            modelBuilder.ApplyConfiguration(new ExamConfiguration());
            modelBuilder.ApplyConfiguration(new ExamDetailConfiguration());
            modelBuilder.ApplyConfiguration(new StudentAnswerConfiguration());
            modelBuilder.ApplyConfiguration(new StudentAnswerDetailConfiguration());
            modelBuilder.ApplyConfiguration(new ResultConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectAccountConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherContestConfiguration());

            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("USER_CLAIM");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("USER_ROLE").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("USER_LOGIN").HasKey(x => x.UserId);
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("ROLE_CLAIM");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("USER_TOKEN").HasKey(x => x.UserId);

            // Data seeding
            modelBuilder.Seed();
        }

        public DbSet<Class> Classes { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<ScoreType> ScoreTypes { get; set; }
        public DbSet<QuestionGroup> QuestionGroups { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamDetail> ExamDetails { get; set; }
        public DbSet<StudentAnswer> StudentAnswers { get; set; }
        public DbSet<StudentAnswerDetail> StudentAnswerDetails { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<SubjectAccount> SubjectAccounts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Contest> Contests { get; set; }
        public DbSet<TeacherContest> TeacherContests { get; set; }
        public DbSet<IdentityUserRole<Guid>> UserRoles { get; set; }
    }
}
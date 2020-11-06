using HeThongQuanLyCongTacKhaoThi.Data.Configurations;
using HeThongQuanLyCongTacKhaoThi.Data.Entities;
using HeThongQuanLyCongTacKhaoThi.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeThongQuanLyCongTacKhaoThi.Data.EF
{
    public class HeThongQuanLyCongTacKhaoThiDbContext : DbContext
    {
        public HeThongQuanLyCongTacKhaoThiDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuration using Fluent API
            modelBuilder.ApplyConfiguration(new ClassConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());
            modelBuilder.ApplyConfiguration(new ScoreConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionConfiguration());
            modelBuilder.ApplyConfiguration(new AnswerConfiguration());
            modelBuilder.ApplyConfiguration(new ExamConfiguration());
            modelBuilder.ApplyConfiguration(new ExamDetailConfiguration());
            modelBuilder.ApplyConfiguration(new StudentAnswerConfiguration());
            modelBuilder.ApplyConfiguration(new StudentAnswerDetailConfiguration());
            modelBuilder.ApplyConfiguration(new ResultConfiguration());

            // Data seeding
            modelBuilder.Seed();
        }

        public DbSet<Class> Classes { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamDetail> ExamDetails { get; set; }
        public DbSet<StudentAnswer> StudentAnswers { get; set; }
        public DbSet<StudentAnswerDetail> StudentAnswerDetails { get; set; }
        public DbSet<Result> Results { get; set; }
    }
}

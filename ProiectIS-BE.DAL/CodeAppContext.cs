using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProiectIS_BE.DAL.Entities;
using ProiectIS_BE.Data.Entities;
using System;
using System.Collections.Generic;


namespace ProiectIS_BE.Data
{
    public class CodeAppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Paragraph> Paragraphs { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<QuizAnswer> QuizAnswers { get; set; }
        public DbSet<QuizQuestion> QuizQuestions { get; set; }

        public CodeAppContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected internal void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Course>()
                .Property(p => p.Image)
                .HasColumnType("image"); 

            modelBuilder.Entity<User>()
                .Property(p => p.Avatar)
                .HasColumnType("image");

            modelBuilder.Entity<User>()
                .HasMany(p => p.AttemptedCourses)
                .WithMany(c => c.UsersAttempted)
                .UsingEntity<CourseUser>(
                    j => j
                        .HasOne(pt => pt.Course)
                        .WithMany(t => t.CourseUserMapping)
                        .HasForeignKey(pt => pt.CourseId),
                    j => j
                        .HasOne(pt => pt.User)
                        .WithMany(p => p.CourseUserMapping)
                        .HasForeignKey(pt => pt.UserId),
                    j =>
                    {
                        j.Property(pt => pt.StartedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
                        j.Property(pt => pt.Points).HasDefaultValue(0);
                    });
        }
    }
}
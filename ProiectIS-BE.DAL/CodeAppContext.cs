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
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<UserExercises> UserExercises { get; set; }

        public CodeAppContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected internal void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Course>()
                .Property(p => p.Image)
                .HasColumnType("image");

            modelBuilder.Entity<Course>()
                .HasOne(p => p.Quiz)
                .WithOne()
                .HasForeignKey("QuizId");

            modelBuilder.Entity<User>()
                .Property(p => p.Avatar)
                .HasColumnType("image");

            modelBuilder.Entity<User>()
                .HasMany(p => p.Courses)
                .WithMany(c => c.Users)
                .UsingEntity("UserCourses");

            modelBuilder.Entity<User>()
                .HasMany(p => p.Exercises)
                .WithMany(p => p.Users)
                .UsingEntity<UserExercises>();
        }
    }
}
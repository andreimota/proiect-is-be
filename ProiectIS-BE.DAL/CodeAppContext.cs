using Microsoft.EntityFrameworkCore;
using ProiectIS_BE.DAL.Entities;
using ProiectIS_BE.Data.Entities;
using System;
using System.Collections.Generic;


namespace ProiectIS_BE.Data
{
    public class CodeAppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Paragraph> Paragraphs { get; set; }

        public CodeAppContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected internal void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>()
                .Property(p => p.Image)
                .HasColumnType("image");
        }
    }
}
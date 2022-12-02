using Microsoft.EntityFrameworkCore;
using ProiectIS_BE.Data.Entities;
using System;
using System.Collections.Generic;


namespace ProiectIS_BE.Data
{
    public class CodeAppContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public CodeAppContext(DbContextOptions<ApplicationDbContext> options)
        {

        }
    }
}
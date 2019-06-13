﻿
using Microsoft.EntityFrameworkCore;


namespace UserPortal.Models
{
    public class SpartaDB : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Cohort> Cohorts { get; set; }
        public DbSet<Specialisation> Specialisations { get; set; } 

        public SpartaDB() { }

        public SpartaDB(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }

}

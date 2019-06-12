
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = System.IO.Path.Combine(System.Environment.CurrentDirectory, "SpartaDB.db");
            optionsBuilder.UseSqlServer(@"Server=tcp:spartaportal.database.windows.net,1433;Initial Catalog=Northwind;Persist Security Info=False;User ID={your_username};Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }

}

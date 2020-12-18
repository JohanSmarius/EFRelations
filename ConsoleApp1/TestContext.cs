using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1
{
    public class TestContext : DbContext
    {
        public DbSet<Primary> Primaries { get; set; }

        public DbSet<Dependent> Dependents { get; set; }
        
        public TestContext()
        {
                        
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\MSSQLLocalDB;Database=TestRelations;Trusted_Connection=True;");


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Tertiary>().HasOne<Primary>();
        }
    }
}
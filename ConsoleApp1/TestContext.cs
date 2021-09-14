using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1
{
    public class TestContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        
        public DbSet<Game> Games { get; set; }

        public DbSet<GamePlayer> GamePlayers { get; set; }
        
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

            modelBuilder.Entity<Game>().
                HasMany(game => game.Players).
                WithMany(player => player.Games).
                UsingEntity<GamePlayer>(
                    j => j.HasOne(pg => pg.Player).WithMany(),
                    j => j.HasOne(pg => pg.Game).WithMany()).Property(gp => gp.Score);
        }
    }
}
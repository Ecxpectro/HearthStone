using HearthStoneApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HearthStoneApp.Infrastructure.Data
{
    public class HearthStoneDbContext : DbContext
    {
        public HearthStoneDbContext(DbContextOptions<HearthStoneDbContext> options)
            : base(options)
        {
        }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<CardSet> CardSets { get; set; }
        public DbSet<PlayerClass> PlayerClasses { get; set; }
        public DbSet<Rarity> Rarities { get; set; }
    }
}

using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.Data
{
    public class HearthStoneDbContext : DbContext
    {
        public HearthStoneDbContext(DbContextOptions<HearthStoneDbContext> options)
            : base(options)
        {
        }
        public DbSet<Card> Cards { get; set; }
    }
}

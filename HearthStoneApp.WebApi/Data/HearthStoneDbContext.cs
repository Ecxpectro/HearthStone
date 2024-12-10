using HearthStoneApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HearthStoneApp.WebApi.Data
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

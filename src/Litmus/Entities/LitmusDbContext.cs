using Microsoft.Data.Entity;

namespace Litmus.Entities
{
    public class LitmusDbContext : DbContext
    {
        public DbSet<Card> Cards { get; set; }
    }
}

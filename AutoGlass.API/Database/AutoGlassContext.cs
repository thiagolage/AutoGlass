using Microsoft.EntityFrameworkCore;

namespace AutoGlass.API.Database
{
    public class AutoGlassContext : DbContext
    {
        public AutoGlassContext(DbContextOptions<AutoGlassContext> options) : base(options)
        {
            
        }

        public DbSet<Produto> Produto { get; set; }
    }
}

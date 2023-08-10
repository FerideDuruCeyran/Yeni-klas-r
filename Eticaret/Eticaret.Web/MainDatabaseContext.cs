using Eticaret.Model;
using Microsoft.EntityFrameworkCore;

namespace Eticaret.Web
{
    public class MainDatabaseContext : DbContext
    {
        public MainDatabaseContext(DbContextOptions<MainDatabaseContext> options) : base(options) { }

        public DbSet<Product> Product { get; set; }
    }
}

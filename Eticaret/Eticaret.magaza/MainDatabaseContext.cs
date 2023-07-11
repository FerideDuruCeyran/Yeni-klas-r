using Eticaret.Model;
using Microsoft.EntityFrameworkCore;

namespace Eticaret.Magaza
{
    // ORM : Nesne ilişkisel eşleme
    public class MainDatabaseContext : DbContext
    {
        public MainDatabaseContext(DbContextOptions<MainDatabaseContext> options) : base(options) { }

        public DbSet<Product> Product { get; set; }
    }
}

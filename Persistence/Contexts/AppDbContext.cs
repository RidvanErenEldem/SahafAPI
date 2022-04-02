using Microsoft.EntityFrameworkCore;
using SahafAPI.Domain.Models;

namespace SahafAPI.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<BookSeller> BookSeller { get; set; }
        public DbSet<Book> Book { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }
    }
}

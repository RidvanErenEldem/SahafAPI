using Microsoft.EntityFrameworkCore;
using SahafAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SahafAPI.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<BookSeller> BookSeller { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }
    }
}

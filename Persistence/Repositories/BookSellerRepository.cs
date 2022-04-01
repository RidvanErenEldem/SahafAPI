using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SahafAPI.Domain.Models;
using SahafAPI.Domain.Repositories;
using SahafAPI.Persistence.Contexts;

namespace SahafAPI.Persistence.Repositories
{
    public class BookSellerRepository : BaseRepository, IBookSellerRepository
    {
        public BookSellerRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(BookSeller bookSeller)
        {
            await context.AddAsync(bookSeller);
        }

        public async Task<List<BookSeller>> ListAsync()
        {
            return await context.BookSeller.ToListAsync();
        }
    }
}
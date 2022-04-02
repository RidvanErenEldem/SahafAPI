using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SahafAPI.Domain.Models;
using SahafAPI.Domain.Repositories;
using SahafAPI.Persistence.Contexts;

namespace SahafAPI.Persistence.Repositories
{
    public class BookRepository : BaseRepository, IBookRepository
    {
        public BookRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Book book)
        {
            await context.AddAsync(book);
        }

        public async Task<Book> FindByIdAsync(int id)
        {
            return await context.Book.FindAsync(id);
        }

        public async Task<List<Book>> ListAsync()
        {
            return await context.Book.ToListAsync();
        }

        public void Remove(Book book)
        {
            context.Book.Remove(book);
        }

        public void Update(Book book)
        {
            context.Book.Update(book);
        }
    }
}
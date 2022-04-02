using System.Collections.Generic;
using System.Threading.Tasks;
using SahafAPI.Domain.Models;

namespace SahafAPI.Domain.Repositories
{
    public interface IBookRepository
    {
        Task<List<Book>> ListAsync();
        Task AddAsync(Book book);

        Task<Book> FindByIdAsync(int id);
        void Update(Book book);
        void Remove(Book book);
    }
}
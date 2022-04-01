using SahafAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SahafAPI.Domain.Repositories
{
    public interface IBookSellerRepository
    {
        Task<List<BookSeller>> ListAsync();
        Task AddAsync(BookSeller bookSeller);
        Task<BookSeller> FindByIdAsync(int id);
        void Update(BookSeller bookSeller);
        void Remove(BookSeller bookSeller);
    }
}

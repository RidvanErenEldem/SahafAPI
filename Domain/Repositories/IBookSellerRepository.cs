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
    }
}

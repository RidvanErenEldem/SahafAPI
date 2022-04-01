using SahafAPI.Domain.Models;
using SahafAPI.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SahafAPI.Domain.Services.Interfaces
{
    public interface IBookSellerService
    {
        Task<List<BookSeller>> ListAsync();
        Task<SaveBookSellerResponse> SaveAsync(BookSeller bookSeller);
        Task<SaveBookSellerResponse> UpdateAsync(int id, BookSeller bookSeller);
    }
}

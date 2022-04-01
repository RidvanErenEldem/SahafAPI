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
        Task<BookSellerResponse> SaveAsync(BookSeller bookSeller);
        Task<BookSellerResponse> UpdateAsync(int id, BookSeller bookSeller);
        Task<BookSellerResponse> DeleteAsync(int id);
    }
}

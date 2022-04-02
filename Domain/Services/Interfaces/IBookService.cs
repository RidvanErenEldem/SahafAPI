using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SahafAPI.Domain.Models;
using SahafAPI.Domain.Services.Communication;

namespace SahafAPI.Domain.Services.Interfaces
{
    public interface IBookService
    {
        Task<List<Book>> ListAsync();
        Task<BookResponse> SaveAsync(Book book);
        Task<BookResponse> UpdateAsync(int id, Book book);
    }
}
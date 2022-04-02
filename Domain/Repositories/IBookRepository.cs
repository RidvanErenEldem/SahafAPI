using System.Collections.Generic;
using System.Threading.Tasks;
using SahafAPI.Domain.Models;

namespace SahafAPI.Domain.Repositories
{
    public interface IBookRepository
    {
        Task<List<Book>> ListAsync();
    }
}
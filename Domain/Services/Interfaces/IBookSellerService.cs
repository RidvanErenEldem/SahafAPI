using SahafAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SahafAPI.Domain.Services.Interfaces
{
    public interface IBookSellerService
    {
        Task<List<BookSeller>> ListAsync();
    }
}

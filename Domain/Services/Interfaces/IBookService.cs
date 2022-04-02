using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SahafAPI.Domain.Models;

namespace SahafAPI.Domain.Services.Interfaces
{
    public interface IBookService
    {
        Task<List<Book>> ListAsync();
    }
}
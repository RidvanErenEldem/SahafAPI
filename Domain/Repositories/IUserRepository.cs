using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SahafAPI.Domain.Models;

namespace SahafAPI.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> ListAsync();
        Task AddAsync(User user);
    }
}
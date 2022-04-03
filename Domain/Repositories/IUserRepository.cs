using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SahafAPI.Domain.Models;
using SahafAPI.Domain.Services.Communication;

namespace SahafAPI.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> ListAsync();
        Task AddAsync(User user);
        Task<User> FindByIdAsync(int id);
        void Update(User user);
    }
}
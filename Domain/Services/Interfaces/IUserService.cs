using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SahafAPI.Domain.Models;
using SahafAPI.Domain.Services.Communication;

namespace SahafAPI.Domain.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> ListAsync();
        Task<UserResponse> SaveAsync(User user);
        Task<UserResponse> UpdateAsync(int id,User user);
        Task<UserResponse> DeleteAsync(int id);
    }
}
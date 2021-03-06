using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SahafAPI.Domain.Models;
using SahafAPI.Domain.Repositories;
using SahafAPI.Persistence.Contexts;

namespace SahafAPI.Persistence.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(User user)
        {
            await context.AddAsync(user);
        }

        public async Task<List<User>> ListAsync()
        {
            return await context.User.ToListAsync();
        }
        public async Task<User> FindByIdAsync(int id)
        {
            return await context.User.FindAsync(id);
        }
        public void Update(User user)
        {
            context.User.Update(user);
        }
        public void Remove(User user)
        {
            context.User.Remove(user);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SahafAPI.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task ComplateAsync();
    }
}
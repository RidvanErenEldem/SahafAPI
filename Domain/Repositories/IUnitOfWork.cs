using System.Threading.Tasks;

namespace SahafAPI.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task ComplateAsync();
    }
}
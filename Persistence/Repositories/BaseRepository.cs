using SahafAPI.Persistence.Contexts;

namespace SahafAPI.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext context;

        protected BaseRepository(AppDbContext context)
        {
            this.context = context;
        }
        
    }
}
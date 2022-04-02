using SahafAPI.Persistence.Contexts;

namespace SahafAPI.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext context;

        public BaseRepository(AppDbContext context)
        {
            this.context = context;
        }
        
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SahafAPI.Domain.Models;
using SahafAPI.Domain.Repositories;
using SahafAPI.Persistence.Contexts;

namespace SahafAPI.Persistence.Repositories
{
    public class DailyReportRepository : BaseRepository, IDailyReportRepository
    {
        public DailyReportRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<DailyReport>> ListAsync()
        {
            return await context.DailyReport.ToListAsync();
        }
    }
}
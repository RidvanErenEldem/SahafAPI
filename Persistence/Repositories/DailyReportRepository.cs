using System;
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

        public async Task AddAsync(DailyReport dailyReport)
        {
            await context.AddAsync(dailyReport);
        }

        public async Task<DailyReport> FindByIdAsync(int id)
        {
            return await context.DailyReport.FindAsync(id);
        }
        public void Update(DailyReport dailyReport)
        {
            context.DailyReport.Update(dailyReport);
        }
        public void Remove(DailyReport dailyReport)
        {
            context.DailyReport.Remove(dailyReport);
        }

        public async Task<List<DailyReport>> CustomSql(string query)
        {
            return await context.DailyReport.FromSqlRaw(query).ToListAsync();
        }
    }
}
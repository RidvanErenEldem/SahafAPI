using System.Collections.Generic;
using System.Threading.Tasks;
using SahafAPI.Domain.Models;

namespace SahafAPI.Domain.Repositories
{
    public interface IDailyReportRepository
    {
        Task <List<DailyReport>> ListAsync();
        Task AddAsync(DailyReport dailyReport);
        Task<DailyReport> FindByIdAsync(int id);
        void Update(DailyReport dailyReport);
        void Remove(DailyReport dailyReport);
    }
}

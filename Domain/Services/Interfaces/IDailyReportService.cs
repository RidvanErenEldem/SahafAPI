using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SahafAPI.Domain.Models;
using SahafAPI.Domain.Services.Communication;

namespace SahafAPI.Domain.Services.Interfaces
{
    public interface IDailyReportService
    {
        Task <List<DailyReport>> ListAsync();
        Task<DailyReportResponse> SaveAsync(DailyReport dailyReport);
        Task<DailyReportResponse> UpdateAsync(int id, DailyReport dailyReport);
        Task<DailyReportResponse> DeleteAsync(int id);
        Task<List<DailyReport>> GetIdByDate();
    }
}
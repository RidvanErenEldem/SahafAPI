using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SahafAPI.Domain.Models;
using SahafAPI.Domain.Repositories;
using SahafAPI.Domain.Services.Interfaces;

namespace SahafAPI.Services
{
    public class DailyReportService : IDailyReportService
    {
        private readonly IDailyReportRepository dailyReportRepository;

        public DailyReportService(IDailyReportRepository dailyReportRepository)
        {
            this.dailyReportRepository = dailyReportRepository;
        }
        public async Task<List<DailyReport>> ListAsync()
        {
            return await dailyReportRepository.ListAsync();
        }
    }
}
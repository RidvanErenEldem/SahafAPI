using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SahafAPI.Domain.Models;
using SahafAPI.Domain.Repositories;
using SahafAPI.Domain.Services.Communication;
using SahafAPI.Domain.Services.Interfaces;

namespace SahafAPI.Services
{
    public class DailyReportService : IDailyReportService
    {
        private readonly IDailyReportRepository dailyReportRepository;
        private readonly IUnitOfWork unitOfWork;

        public DailyReportService(IDailyReportRepository dailyReportRepository, IUnitOfWork unitOfWork)
        {
            this.dailyReportRepository = dailyReportRepository;
            this.unitOfWork = unitOfWork;
        }
        public async Task<List<DailyReport>> ListAsync()
        {
            return await dailyReportRepository.ListAsync();
        }
        public async Task<DailyReportResponse> SaveAsync(DailyReport dailyReport)
        {
            try
            {
                await dailyReportRepository.AddAsync(dailyReport);
                await unitOfWork.ComplateAsync();

                return new DailyReportResponse(dailyReport);
            }
            catch (Exception ex)
            {
                return new DailyReportResponse($"An error occurred when saving the daily report: {ex.Message}");
            }
        }

        public async Task<DailyReportResponse> UpdateAsync(int id, DailyReport dailyReport)
        {
            var existingDailyReport = await dailyReportRepository.FindByIdAsync(id);

            if(existingDailyReport == null)
                return new DailyReportResponse("Daily Report not found.");

            existingDailyReport.date = dailyReport.date;
            existingDailyReport.bookAmount = dailyReport.bookAmount;

            try
            {
                dailyReportRepository.Update(existingDailyReport);
                await unitOfWork.ComplateAsync();

                return new DailyReportResponse(dailyReport);
            }
            catch (Exception ex)
            {
                return new DailyReportResponse($"An error occurred when updating the daily report: {ex.Message}");
            }
        }
        public async Task<DailyReportResponse> DeleteAsync(int id)
        {
            var existingDailyReport = await dailyReportRepository.FindByIdAsync(id);
            if(existingDailyReport == null)
                return new DailyReportResponse("Daily Report not found.");
            
            try
            {
                dailyReportRepository.Remove(existingDailyReport);
                await unitOfWork.ComplateAsync();

                return new DailyReportResponse(existingDailyReport);
            }
            catch (Exception ex)
            {
                return new DailyReportResponse($"An error occurred when deleting the daily report: {ex.Message}");
            }
        }
        public async Task<List<DailyReport>> GetIdByDate()
        {
            const string quote = "\'";
            string query = "SELECT * FROM DailyReport WHERE [date] = " + quote+ DateTime.Now.ToString("yyyy-MM-dd")+quote;
            var existingDailyReport = await dailyReportRepository.CustomSql(query);
            return existingDailyReport;
        }
    }
}
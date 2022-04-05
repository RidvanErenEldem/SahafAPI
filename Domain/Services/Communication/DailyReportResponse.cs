using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SahafAPI.Domain.Models;

namespace SahafAPI.Domain.Services.Communication
{
    public class DailyReportResponse : BaseResponse
    {
        public DailyReport dailyReport { get; set; }

        private DailyReportResponse(bool success, string message,DailyReport dailyReport): base(success, message)
        {
            this.dailyReport = dailyReport;
        }

        public DailyReportResponse(DailyReport dailyReport) : this(true, String.Empty, dailyReport)
        {}

        public DailyReportResponse(string message) : this(false, message, null){}
    }
}
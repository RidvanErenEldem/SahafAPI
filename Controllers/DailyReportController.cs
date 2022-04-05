using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SahafAPI.Domain.Models;
using SahafAPI.Domain.Services.Interfaces;
using SahafAPI.Extensions;
using SahafAPI.Resources;

namespace SahafAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DailyReportController : Controller
    {
        private readonly IDailyReportService dailyReportService;
        private readonly IMapper mapper;

        public DailyReportController(IDailyReportService dailyReportService, IMapper mapper)
        {
            this.dailyReportService = dailyReportService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<List<DailyReportResource>> GetAllAsync()
        {
            var dailyReports = await dailyReportService.ListAsync();
            var resources = mapper.Map<List<DailyReport>, List<DailyReportResource>>(dailyReports);

            return resources;
        }
    }
}
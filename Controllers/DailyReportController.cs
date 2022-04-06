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
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] SaveDailyReportResource resource)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var dailyReport = new DailyReport();
            dailyReport.date = resource.date;
            dailyReport.bookAmount = resource.bookAmount;
            var result = await dailyReportService.SaveAsync(dailyReport);

            if(!result.success)
                return BadRequest(result.message);

            var dailyReportResource = mapper.Map<DailyReport, DailyReportResource>(result.dailyReport);
            return Ok(dailyReportResource);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id,SaveDailyReportResource resource)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var dailyReport = new DailyReport();
            dailyReport.date = resource.date;
            dailyReport.bookAmount = resource.bookAmount;
            var result = await dailyReportService.UpdateAsync(id,dailyReport);

            if(!result.success)
                return BadRequest(result.message);

            var dailyReportResource = mapper.Map<DailyReport, DailyReportResource>(result.dailyReport);
            dailyReportResource.id = id;
            return Ok(dailyReportResource);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await dailyReportService.DeleteAsync(id);
            if(!result.success)
                return BadRequest(result.message);
            
            var dailyReportResource = mapper.Map<DailyReport,DailyReportResource>(result.dailyReport);
            return Ok(dailyReportResource);
        }
    }
}
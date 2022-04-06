using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SahafAPI.Resources
{
    public class SaveDailyReportResource
    {
        [Required]
        public DateTime date { get; set; }
        [Required]
        public int bookAmount { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SahafAPI.Domain.Models
{
    public class DailyReport
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public int bookAmount { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SahafAPI.Domain.Models
{
    public class Book
    {
        public int id { get; set; }
        public string name { get; set; }
        public int bookSellerId { get; set; }
    }
}

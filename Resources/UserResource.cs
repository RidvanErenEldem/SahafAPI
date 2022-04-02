using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SahafAPI.Resources
{
    public class UserResource
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime? bookBorrowDate { get; set;}
        public DateTime? bookReturnDate { get; set;}
        public int? bookId { get; set;}
    }
}
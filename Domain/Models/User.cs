using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SahafAPI.Domain.Models
{
    public class User
    {
        public int? id { get; set;}
        public string name { get; set;}
        public DateTime? bookBorrowDate { get; set;}
        public DateTime? bookReturnDate { get; set;}
        public int? bookId { get; set;}
    }
}
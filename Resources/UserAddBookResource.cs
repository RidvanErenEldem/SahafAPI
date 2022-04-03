using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SahafAPI.Resources
{
    public class UserAddBookResource
    {
        [Required]
        public DateTime bookBorrowDate { get; set;}
        [Required]
        public DateTime bookReturnDate { get; set;}
        [Required]
        public int bookId { get; set;}
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SahafAPI.Resources
{
    public class SaveUserResource
    {
        [Required]
        [MaxLength(50)]
        public string name { get; set; }
        public DateTime? bookReturnDate { get; set; }
        public int? bookId { get; set; }
    }
}
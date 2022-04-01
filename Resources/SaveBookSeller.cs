using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SahafAPI.Resources
{
    public class SaveBookSeller
    {
        [Required]
        [MaxLength(50)]
        public string name { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SahafAPI.Resources
{
    public class SaveBookResource
    {
        [Required]
        [MaxLength(50)]

        public string name { get; set; }
        [Required]
        public int bookSellerId { get; set; }
    }
}
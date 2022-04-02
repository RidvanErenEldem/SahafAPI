using System.ComponentModel.DataAnnotations;

namespace SahafAPI.Resources
{
    public class SaveBookSellerResource
    {
        [Required]
        [MaxLength(50)]
        public string name { get; set; }
    }
}
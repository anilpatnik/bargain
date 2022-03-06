using System.ComponentModel.DataAnnotations;

namespace Bargain.Models
{
    public class Category : Base
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } // Deal category for quick search 
    }
}

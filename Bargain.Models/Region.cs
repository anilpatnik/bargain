using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bargain.Models
{
    public class Region : Base
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(10)]
        public string Code { get; set; }
        
        public ICollection<Location> Locations { get; set; }
    }
}

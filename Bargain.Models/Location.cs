using System.ComponentModel.DataAnnotations;

namespace Bargain.Models
{
    public class Location : Base
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public int RegionId { get; set; }

        [Required]
        public TimezoneType Timezone { get; set; }
        
        public Region Region { get; set; }
    }
}

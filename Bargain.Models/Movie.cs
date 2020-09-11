using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Bargain.Models
{
    public class Movie
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Slug { get; set; }

        [Required]
        [MaxLength(20)]
        public string Code { get; set; }

        [Required]
        public int GenreId { get; set; }

        [JsonIgnore]
        public Genre Genre { get; set; }
    }
}

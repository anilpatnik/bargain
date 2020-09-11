using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Bargain.Models
{
    public class Genre
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        [Column("Description")]
        public string Desc { get; set; }

        [JsonIgnore]
        public List<Movie> Movies { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Bargain.Models
{
    public class TradeFile : Base
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public byte[] File { get; set; } // 600x415 max image size for deals

        [Required]
        public FileType FileType { get; set; }

        public int TradeId { get; set; }
        
        public Trade Trade { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Bargain.Models
{
    public class DealFile
    {
        [Required]
        public int TradeFileId { get; set; }

        [Required]
        public int DealId { get; set; }
        
        public bool IsPrimary { get; set; } = false; // Dashboard Pic

        public Deal Deal { get; set; }
        
        public TradeFile TradeFile { get; set; }
    }
}

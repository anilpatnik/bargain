using System.ComponentModel.DataAnnotations;

namespace Bargain.Models
{
    public class TradeDeal
    {
        [Required]
        public int DealId { get; set; }

        [Required]
        public int TradeId { get; set; }
        
        public Deal Deal { get; set; }
        
        public Trade Trade { get; set; }
    }
}

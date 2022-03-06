using System.ComponentModel.DataAnnotations;

namespace Bargain.Models
{
    public class TradeUser
    {
        [Required]
        public int TradeId { get; set; }

        [Required]
        public int UserId { get; set; }        

        public bool IsEditAllowed { get; set; } = false; // Allow edit trade for non trade admins
                
        public User User { get; set; }
                
        public Trade Trade { get; set; }
    }
}

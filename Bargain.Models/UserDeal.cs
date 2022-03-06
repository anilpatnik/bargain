using System.ComponentModel.DataAnnotations;

namespace Bargain.Models
{
    public class UserDeal
    {
        [Required]
        public int DealId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public string Coupon { get; set; } // Unique deal redeem code

        public bool Inactive { get; set; } = false; // Redeem status

        public Deal Deal { get; set; }
        
        public User User { get; set; }
    }
}

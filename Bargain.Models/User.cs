using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bargain.Models
{
    public class User : Base
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        public RoleType Role { get; set; } = RoleType.Customer;

        [Required]
        public AuthType Type { get; set; }
        
        public bool IsTradeAdmin { get; set; } = false; // Trade admin to edit trade and manage users

        public string Token { get; set; }

        public ICollection<UserDeal> UserDeals { get; set; }
    }
}

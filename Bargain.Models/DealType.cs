using System.ComponentModel.DataAnnotations;

namespace Bargain.Models
{
    public class DealType : Base
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public DiscountType DiscountType { get; set; }

        [Required]
        public double DiscountValue { get; set; }

        [Required]
        public int DealId { get; set; }

        public Deal Deal { get; set; }
    }
}

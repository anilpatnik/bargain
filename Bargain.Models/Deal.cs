using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bargain.Models
{
    public class Deal : Base
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int NoOfDeals { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public string Conditions { get; set; }

        public ActionType Status { get; set; }

        public Category Category { get; set; }

        public ICollection<DealType> DealTypes { get; set; }
        
        public ICollection<DealFile> DealFiles { get; set; }
    }
}

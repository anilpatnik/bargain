using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bargain.Models
{
    public class Base
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public Guid RecordId { get; set; } = Guid.NewGuid();

        public bool Inactive { get; set; } = false;

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public int CreatedBy { get; set; }

        public DateTime UpdatedOn { get; set; } = DateTime.UtcNow;

        public int UpdatedBy { get; set; }        

        [Timestamp]
        public byte[] Timestamp { get; set; }
    }
}

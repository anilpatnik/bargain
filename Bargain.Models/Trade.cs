using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;

namespace Bargain.Models
{
    public class Trade : Base
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public int LocationId { get; set; }

        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        public string Website { get; set; }

        [NotMapped]
        public ICollection<string> OpeningHours { get; set; }

        [JsonIgnore]
        public string TradingHours
        {
            get => OpeningHours?.Count > 0 ? string.Join(",", OpeningHours) : null;
            set => OpeningHours = value?.Split(",")?.ToList();
        }

        // Google identifier that uniquely identifies a place
        // Identifier for external vendors to redeem deal via API
        [Required]
        public string PlaceId { get; set; }        

        public ActionType Status { get; set; }

        public Location Location { get; set; }
        
        public ICollection<TradeFile> TradeFiles { get; set; }
        
        public ICollection<TradeUser> TradeUsers { get; set; }
        
        public ICollection<TradeDeal> TradeDeals { get; set; }
    }
}

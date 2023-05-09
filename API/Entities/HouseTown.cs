using System.ComponentModel.DataAnnotations.Schema;
using API.Entities.Homes;

namespace API.Entities
{
    [Table("HouseTowns")]
    public class HouseTown
    {
        
        public int HouseId { get; set; }
        public House House { get; set; }
        public int TownId { get; set; }
        public Town Town { get; set; }
    }
}
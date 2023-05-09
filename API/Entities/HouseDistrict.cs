using System.ComponentModel.DataAnnotations.Schema;
using API.Entities.Homes;
namespace API.Entities
{
    [Table("HouseTowns")]
    public class HouseDistrict
    {
        public int HouseId { get; set; }
        public House House { get; set; }
        public int DistrictId { get; set; }
        public District District { get; set; }
    }
}
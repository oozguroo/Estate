using API.Entities.Homes;

namespace API.Entities
{
    public class HouseLike
    {
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int HouseId { get; set; }
        public House House { get; set; }
    }
}
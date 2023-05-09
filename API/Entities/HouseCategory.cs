using API.Entities.Homes;

namespace API.Entities
{
    public class HouseCategory
    {

        public int HouseId { get; set; }
        public House House { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
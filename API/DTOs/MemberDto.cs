using API.Entities.Homes;

namespace API.DTOs
{
    public class MemberDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public ICollection<House> Houses { get; set; }
        public ICollection<HouseLikeDto> LikedHouses { get; set; }
    }
}
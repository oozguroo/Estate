using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class HouseLikeDto
    {
        public int AppUserId { get; set; }
        public int HouseId { get; set; }
        public string HouseTitle { get; set; }
        public decimal HousePrice { get; set; }
        public string HousePhotoUrl { get; set; }
        public List<PhotoDto> Photos { get; set; }
    }
}
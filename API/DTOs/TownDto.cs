using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class TownDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
        public CityDto City { get; set; }

        public ICollection<DistrictDto> Districts { get; set; }

    }
}
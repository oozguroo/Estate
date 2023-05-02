using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class DistrictDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TownId { get; set; }
        public TownDto Town { get; set; }

    }
}
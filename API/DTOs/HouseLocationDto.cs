using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
public class HouseLocationDto
{
    public int Id { get; set; }
    public CityDto City { get; set; }
    public TownDto Town { get; set; }
    public DistrictDto District { get; set; }
    // other properties
}

}
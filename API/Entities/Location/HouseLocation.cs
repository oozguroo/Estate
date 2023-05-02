using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Entities.Homes;

namespace API.Entities.Location
{
    public class HouseLocation
{
    [Key]
    public int Id { get; set; }


    public int HouseId { get; set; }

    public House House { get; set; }


    public int LocationCityId  { get; set; }

    public City City { get; set; }


    public int LocationTownId  { get; set; }

    public Town Town { get; set; }

    public int LocationDistrictId  { get; set; }

    public District District { get; set; }
}

}
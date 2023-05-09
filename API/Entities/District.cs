using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace API.Entities
{
    [Table("Districts")]

    public class District
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<HouseDistrict> HouseDistricts { get; set; }
    }
}

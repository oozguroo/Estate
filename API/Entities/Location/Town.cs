using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Entities.Homes;

namespace API.Entities.Location
{
    [Table("Towns")]
    public class Town
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("City")]
        public int CityId { get; set; }
        public City City { get; set; }

    }

}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Entities.Homes;
using API.Entities.Location;

namespace API.Entities
{
    [Table("Cities")]
    public class City
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }

}


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Entities.Homes;

namespace API.Entities.Location
{

    [Table("Districts")]
    public class District
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Town")]
        public int TownId { get; set; }
        public Town Town { get; set; }
    }

}
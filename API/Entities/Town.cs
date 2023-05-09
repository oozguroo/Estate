using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
     [Table("Towns")]
    public class Town
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<HouseTown> HouseTowns { get; set; }
    }
}
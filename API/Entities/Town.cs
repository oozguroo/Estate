using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Entities.Homes;

namespace API.Entities
{
     [Table("Towns")]
    public class Town
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<House> Houses { get; set; }
    }
}
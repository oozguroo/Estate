using System.ComponentModel.DataAnnotations.Schema;
using API.Entities.Homes;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } 
         public ICollection<HouseCategory> HouseCategories { get; set; }

    }
}
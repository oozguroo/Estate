using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
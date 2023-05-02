using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Entities.Homes;

namespace API.Entities
{
public class HouseCategory
{
    [Key]
    public int Id { get; set; }
    public int HouseId { get; set; }
    public House House { get; set; }
    public int ChoosenCategoryId { get; set; }
    public Category Category { get; set; }
}
}
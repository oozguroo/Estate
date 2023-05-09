using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Entities.Homes;

namespace API.Entities
{
    [Table("Photos")]
    public class Photo
    {
        [Key]
        public int Id { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }
        
        [ForeignKey("HouseId")]
        public int HouseId { get; set; }
        public House House { get; set; }

    }
}
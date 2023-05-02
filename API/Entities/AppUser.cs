using System.ComponentModel.DataAnnotations;
using API.Entities.Homes;

namespace API.Entities
{
    public class AppUser
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public ICollection<House> Houses { get; set; }

    }
}
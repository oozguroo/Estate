
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace API.Entities.Homes
{
    [Table("Houses")]
    public class House
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        [ForeignKey("AppUserId")]
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public short Age { get; set; }
        public string Floor { get; set; }
        public string Bathroom { get; set; }
        public string Balcony { get; set; }
        public string Room { get; set; }
        public string Heath { get; set; }
        public string ComplexName { get; set; }
        public string Deed { get; set; } //forget too add this
        public bool? Furnish { get; set; }
        public decimal? Dues { get; set; } //
        public bool? Exchange { get; set; }
        public bool? Credit { get; set; }
        public decimal? Gross { get; set; }
        public decimal? Square { get; set; }

        public bool IsActive { get; set; } = true;
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
        public DateTime ExpirationDate => CreationDate.AddDays(30);
        public List<Photo> Photos { get; set; } = new List<Photo>();
        public ICollection<HouseLike> LikedByUsers { get; set; } // Collection of users who liked this house ad

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int TownId { get; set; }
        public Town Town { get; set; }
        public int DistrictId { get; set; }
        public District District { get; set; }
        //Frontage
        public bool? HasNorthFrontage { get; set; }
        public bool? HasSouthFrontage { get; set; }
        public bool? HasEastFrontage { get; set; }
        public bool? HasWestFrontage { get; set; }
        //View
        public bool? Nature { get; set; }
        public bool? Sea { get; set; }
        public bool? Lake { get; set; }
        //İnterior
        public bool? HasWifi { get; set; }
        public bool? HasSteelDoors { get; set; }
        public bool? HasElevator { get; set; }
        public bool? HasChimney { get; set; }
        //External
        public bool? SwimmingPool { get; set; }
        public bool? Generator { get; set; }
        public bool? Parking { get; set; }
        public bool? Satellite { get; set; }
        //Transport
        public bool? Metro { get; set; }
        public bool? Tramvay { get; set; }
        public bool? Van { get; set; }
        public bool? BusStop { get; set; }
        //Nearby
        public bool? Hospital { get; set; }
        public bool? Gym { get; set; }
        public bool? Pharmacy { get; set; }
        public bool? ShoppingCenter { get; set; }

        public void CheckExpiration()
        {
            if (DateTime.UtcNow > ExpirationDate)
            {
                IsActive = false;
            }
        }


    }


}
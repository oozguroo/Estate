
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
        public int Price { get; set; } //int
        public short Age { get; set; } // short tipi
        public string Floor { get; set; }
        public byte Bathroom { get; set; }// byte
        public byte Balcony { get; set; } // byte
        public string Room { get; set; } //enum yapılacak
        public Heath HeathType { get; set; } // enum for strings
        public string ComplexName { get; set; }
        public Deed DeedType { get; set; } //enum
        public bool Furnish { get; set; }
        public decimal Dues { get; set; } //
        public bool Exchange { get; set; }
        public bool? Credit { get; set; }
        public decimal Gross { get; set; }
        public decimal Square { get; set; }
        public bool? Ramp { get; set; }
        public bool? Elevator { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
        public DateTime ExpirationDate => CreationDate.AddDays(30);
        public List<Photo> Photos { get; set; } = new List<Photo>();
        public List<HouseTown> HouseTowns { get; set; } = new List<HouseTown>();
        public List<HouseDistrict> HouseDistricts { get; set; } = new List<HouseDistrict>();
        public List<HouseCategory> HouseCategories { get; set; } = new List<HouseCategory>();
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

    }
    public enum Heath
    {
        Kömür,
        Doğalgaz,
        Merkezi
    }

    public enum Deed
    {
        Tapu,
        Kat,
    }
}
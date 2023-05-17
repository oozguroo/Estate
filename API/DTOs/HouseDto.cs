using API.Entities.Homes;
namespace API.DTOs
{
    public class HouseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AppUserId { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public int Price { get; set; }
        public short Age { get; set; }
        public string Floor { get; set; }
        public byte Bathroom { get; set; }
        public byte Balcony { get; set; }
        public string Room { get; set; }
        public Heath HeathType { get; set; } // enum for strings
        public string ComplexName { get; set; }
        public Deed DeedType { get; set; } //enum
        public bool Furnish { get; set; }
        public decimal Dues { get; set; }
        public bool Exchange { get; set; }
        public bool? Credit { get; set; }
        public decimal Gross { get; set; }
        public decimal Square { get; set; }
        public bool? Ramp { get; set; }
        public bool? Elevator { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreationDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public List<PhotoDto> Photos { get; set; }= new List<PhotoDto>();
        public List<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
        public List<TownDto> Towns { get; set; } = new List<TownDto>();
        public List<DistrictDto> Districts { get; set; } = new List<DistrictDto>();

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
}
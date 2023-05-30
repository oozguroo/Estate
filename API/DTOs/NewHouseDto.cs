using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class NewHouseDto
    {
        public string Title { get; set; }
        public int AppUserId { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public int Price { get; set; }
        public short Age { get; set; }
        public string Floor { get; set; }
        public string Bathroom { get; set; }
        public string Balcony { get; set; }
        public string Room { get; set; }
        public string Heath { get; set; } // enum for strings
        public string ComplexName { get; set; }
        public string DeedType { get; set; } //enum
        public bool? Furnish { get; set; }
        public decimal? Dues { get; set; }
        public bool? Exchange { get; set; }
        public bool? Credit { get; set; }
        public decimal? Gross { get; set; }
        public decimal? Square { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime ExpirationDate { get; set; }
        public List<PhotoDto> Photos { get; set; } = new List<PhotoDto>();
        public int CategoryId { get; set; } // Property for Category ID
        public int TownId { get; set; } // Property for Town ID
        public int DistrictId { get; set; } // Property for District ID

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
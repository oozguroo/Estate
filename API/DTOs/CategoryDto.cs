using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities.Homes;

namespace API.DTOs
{
    public class CategoryDto
    {
        public class HouseCategoryDto
        {
            public int Id { get; set; }
            public int HouseId { get; set; }
            public int CategoryId { get; set; }
            public string CategoryName { get; set; }
        }

    }
}
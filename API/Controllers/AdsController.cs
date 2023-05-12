using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using API.DTOs;
using API.Entities;
using API.Entities.Homes;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    public class AdsController : BaseApiController
    {
        private readonly IAdRepository _adRepository;
        private readonly IMapper _mapper;

        public AdsController(IAdRepository adRepository, IMapper mapper)
        {
            _mapper = mapper;
            _adRepository = adRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HouseDto>>> GetHouses()
        {
            var houses = await _adRepository.GetHousesAsync();
            return Ok(houses);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<HouseDto>> GetOneHouse(int id)
        {
            return await _adRepository.GetHouseByIdAsync(id);
        }

   [HttpPost("add")]
public async Task<ActionResult<HouseDto>> CreateHouseAsync(HouseDto houseDto)
{
    if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }

    var house = _mapper.Map<HouseDto, House>(houseDto);
    foreach (var categoryDto in houseDto.Categories)
    {
        var category = await _adRepository.GetCategoryAsync(categoryDto.Id);
        if (category == null)
        {
            throw new InvalidOperationException("Category not found");
        }

        house.HouseCategories.Add(new HouseCategory
        {
            CategoryId = category.Id,
        });
    }
    foreach (var townDto in houseDto.Towns)
    {
        var town = await _adRepository.GetTownAsync(townDto.Id);
        if (town == null)
        {
            throw new InvalidOperationException("Town not found");
        }

        house.HouseTowns.Add(new HouseTown
        {
            TownId = town.Id,
        });
    }
    foreach (var districtDto in houseDto.Districts)
    {
        var district = await _adRepository.GetDistrictAsync(districtDto.Id);
        if (district == null)
        {
            throw new InvalidOperationException("District not found");
        }

        house.HouseDistricts.Add(new HouseDistrict
        {
            DistrictId = district.Id,
        });
    }

    var createdHouseDto = await _adRepository.CreateHouseAsync(houseDto);

    return CreatedAtAction(nameof(GetOneHouse), new { id = createdHouseDto.Id }, createdHouseDto);
}



    }
}
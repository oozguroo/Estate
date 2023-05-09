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

       [HttpPost("create")]
public async Task<ActionResult<HouseDto>> CreateHouse(HouseDto houseDto)
{
    try
    {
        // Perform any necessary validation or checks here

        // Map the HouseDto to a House entity
        var house = _mapper.Map<House>(houseDto);

        // Call the repository method to add the house
        _adRepository.AddHouse(house);

        // Save the changes to the database
        if (await _adRepository.SaveAllAsync())
        {
            // Map the created house back to a HouseDto and return it
            var createdHouseDto = _mapper.Map<HouseDto>(house);
            return Ok(createdHouseDto);
        }
    }
    catch (Exception ex)
    {
        // Handle any exceptions that occurred during the creation process
    }

    return BadRequest("Failed to create the house");
}
 


        [HttpGet]
        public async Task<ActionResult<IEnumerable<HouseDto>>> GetHouses()
        {
            var houses = await _adRepository.GetHousesAsync();
            return Ok(houses);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<HouseDto>> GetHouse(int id)
        {
            return await _adRepository.GetHouseAsync(id);
        }



    }
}
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
        public async Task<ActionResult<List<House>>> GetHousesAsync()
        {
            var houses = await _adRepository.GetHousesAsync();
            var housesToReturn = _mapper.Map<IEnumerable<HouseDto>>(houses);
            return Ok(houses);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<HouseDto>> GetHouseByIdAsync(int id)
        {

            var house = await _adRepository.GetHouseByIdAsync(id);
            var appUser = await _adRepository.GetUserByIdAsync(house.AppUserId);
            var houseDto = new HouseDto();
            houseDto.Id = house.Id;
            houseDto.Title = house.Title;
            houseDto.Description = house.Description;
            houseDto.Price = house.Price;
            houseDto.UserName = appUser.UserName;
            return Ok(houseDto);
        }




        [HttpGet("{username}")]
        public async Task<ActionResult<AppUser>> GetUserByUsernameAsync(string username)
        {
            var user = await _adRepository.GetUserByUsernameAsync(username);
            return user;
        }



    }
}
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using API.Data;
using API.DTOs;
using API.Extensions;
using API.Helpers;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace API.Controllers
{
    public class AdsController : BaseApiController
    {
        private readonly IAdRepository _adRepository;
        private readonly IMapper _mapper;
        private readonly IPhotoService _photoService;
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public AdsController(IAdRepository adRepository, IMapper mapper, IPhotoService photoService, IUserRepository userRepository, ITokenService tokenService)
        {
            _tokenService = tokenService;

            _userRepository = userRepository;
            _photoService = photoService;
            _mapper = mapper;
            _adRepository = adRepository;
        }


        [Authorize]
        [HttpPut("update/{id}")]
        public async Task<ActionResult<UpdateHouseDto>> UpdateHouse(int id, [FromForm] UpdateHouseDto updateHouseDto)
        {
            if (id != updateHouseDto.Id)
            {
                return BadRequest("Invalid ID");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var username = User.GetUsername();
            var updatedHouseDto = await _adRepository.UpdateHouseAsync(updateHouseDto, username);
            if (updatedHouseDto == null)
            {
                return NotFound();
            }

            return updatedHouseDto;
        }

        [Authorize]
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteHouseAd(int id)
        {
            var username = HttpContext.User.GetUsername();

            var result = await _adRepository.DeleteHouseAdAsync(id, username);
            if (result == HttpStatusCode.Unauthorized)
                return Unauthorized();

            return Ok("House ad deleted successfully");
        }


        [HttpGet]
        public async Task<ActionResult<PagedList<HouseDto>>> GetHouses([FromQuery]HouseParams houseParams)
        {
            var houses = await _adRepository.GetHousesAsync(houseParams);
            Response.AddPaginationHeader(new PaginationHeader(houses.CurrentPage,houses.PageSize,
            houses.TotalCount,houses.TotalPages));
            return Ok(houses);
        }

        [HttpGet("categories")]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
        {
            var categories = await _adRepository.GetCategoriesAsync();
            return Ok(categories);
        }


        [HttpGet("towns")]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetTowns()
        {
            var towns = await _adRepository.GetTownsAsync();
            return Ok(towns);
        }

        [HttpGet("districts")]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetDistricts()
        {
            var districts = await _adRepository.GetDistrictsAsync();
            return Ok(districts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HouseDto>> GetOneHouse(int id)
        {
            return await _adRepository.GetHouseByIdAsync(id);
        }


        [Authorize]
        [HttpPost("add")]
        public async Task<ActionResult<NewHouseDto>> CreateHouseAsync([FromHeader(Name = "Authorization")] string authorizationHeader, [FromForm] IFormFile file, [FromForm] NewHouseDto newHouseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // Get the username from the token
            var usernameFromToken = HttpContext.User.GetUsername();

            // Get JWT token from Authorization header
            var jwtToken = authorizationHeader.Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwtToken);

            // Get username from JWT token
            if (string.IsNullOrEmpty(usernameFromToken))
            {
                return Unauthorized("Unauthorized operation");
            }

            // Compare the usernames
            if (newHouseDto.UserName != usernameFromToken)
            {
                return Unauthorized("Unauthorized operation");
            }

            // Rest of the code for creating the house ad



            var uploadedFile = Request.Form.Files.FirstOrDefault();
            if (file == null || file.Length == 0)
            {
                return BadRequest("Photo is required.");
            }
            var uploadResult = await _photoService.AddPhotoAsync(file);
            var photoDto = new PhotoDto
            {
                Url = uploadResult.SecureUrl.AbsoluteUri,
                IsMain = true,
                PublicId = uploadResult.PublicId
            };
            newHouseDto.Photos.Add(photoDto);
            var createdHouseDto = await _adRepository.CreateHouseAsync(newHouseDto, usernameFromToken);
            return createdHouseDto;
        }


    }
}
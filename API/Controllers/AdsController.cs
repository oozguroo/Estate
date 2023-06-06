using System.Net;
using System.Security.Claims;
using API.DTOs;
using API.Extensions;
using API.Interfaces;
using AutoMapper;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace API.Controllers
{
    public class AdsController : BaseApiController
    {
        private readonly IAdRepository _adRepository;
        private readonly IMapper _mapper;
        private readonly IPhotoService _photoService;

        public AdsController(IAdRepository adRepository, IMapper mapper, IPhotoService photoService)
        {
            _photoService = photoService;
            _mapper = mapper;
            _adRepository = adRepository;
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<UpdateHouseDto>> UpdateHouse(int id, [FromForm] UpdateHouseDto updateHouseDto)
        {
            if (id != updateHouseDto.Id)
            {
                // Handle ID mismatch case
                return BadRequest("Invalid ID");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Call the repository method to update the house
            var updatedHouseDto = await _adRepository.UpdateHouseAsync(updateHouseDto);
            if (updatedHouseDto == null)
            {
                // Handle house not found case
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
        public async Task<ActionResult<IEnumerable<HouseDto>>> GetHouses()
        {
            var houses = await _adRepository.GetHousesAsync();
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



        [HttpPost("add")]
        public async Task<ActionResult<NewHouseDto>> CreateHouseAsync([FromForm] IFormFile file, [FromForm] NewHouseDto newHouseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var uploadedFile = Request.Form.Files.FirstOrDefault();
            if (file == null || file.Length == 0)
            {
                return BadRequest("Photo is required.");
            }

            // Upload the photo to Cloudinary
            var uploadResult = await _photoService.AddPhotoAsync(file);

            // Create a new PhotoDto object and set its properties
            var photoDto = new PhotoDto
            {
                Url = uploadResult.SecureUrl.AbsoluteUri,
                IsMain = true, // Set this property based on your logic
                PublicId = uploadResult.PublicId
            };

            // Add the photo to the house's Photos list
            newHouseDto.Photos.Add(photoDto);

            // Create the house using the repository method
            var createdHouseDto = await _adRepository.CreateHouseAsync(newHouseDto);


            return createdHouseDto;
        }




    }
}
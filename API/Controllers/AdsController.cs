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
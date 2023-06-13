using API.DTOs;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class LikesController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly ILikesRepository _likesRepository;
        private readonly IMapper _mapper;
        public LikesController(IUserRepository userRepository, ILikesRepository likesRepository, IMapper mapper)
        {
            _mapper = mapper;
            _likesRepository = likesRepository;
            _userRepository = userRepository;
        }

        [HttpPost("adlike")]
        public async Task<IActionResult> AddLike([FromForm] HouseLikeDto likeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _likesRepository.AddLikeAsync(likeDto.AppUserId, likeDto.HouseId);

            if (result == null)
            {
                return BadRequest("You have already liked this ad.");
            }

            return Ok();
        }

        [HttpDelete("unlike/{userId}/{houseId}")]
        public ActionResult UnlikeHouseAd(int userId, int houseId)
        {
            // Delete the liked house ad.
            _likesRepository.DeleteLikedHouseAd(userId, houseId);

            // Return a success message.
            return Ok("The house ad has been unliked.");
        }





        [HttpGet("liked/{userId}")]
        public async Task<ActionResult<IEnumerable<HouseLikeDto>>> GetUserLikes(int userId)
        {

            var likes = await _likesRepository.GetLikedAdsAsync(userId);

            return Ok(_mapper.Map<IEnumerable<HouseLikeDto>>(likes));
        }



    }
}

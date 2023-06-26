using System.Net;
using API.DTOs;
using API.Entities;
using API.Helpers;
using API.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;


namespace API.Data
{
    public class LikesRepository : ILikesRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public LikesRepository(DataContext context, IMapper mapper)
        {

            _mapper = mapper;
            _context = context;
        }
        public async Task<HouseLikeDto> AddLikeAsync(int userId, int houseId)
        {
            // Check if a like already exists for the given user and house
            var existingLike = await _context.HouseLikes
                .FirstOrDefaultAsync(hl => hl.AppUserId == userId && hl.HouseId == houseId);

            // If a like already exists, return null
            if (existingLike != null)
            {
                return null;
            }

            try
            {
                // If a like does not exist, create a new like
                var like = new HouseLike
                {
                    AppUserId = userId,
                    HouseId = houseId
                };

                _context.HouseLikes.Add(like);
                await _context.SaveChangesAsync();

                return _mapper.Map<HouseLikeDto>(like);
            }
            catch (DbUpdateException)
            {
                return null;
            }
        }

        public async Task<PagedList<HouseLikeDto>> GetLikedAdsAsync(LikesParams likesParams)
        {
            var likedHouses = _context.HouseLikes
                .Include(x => x.House)
                .ThenInclude(x => x.Photos)
                .Where(like => like.AppUserId == likesParams.AppUserId)
                .Select(like => new HouseLikeDto
                {
                    AppUserId = like.AppUserId,
                    HouseId = like.HouseId,
                    HouseTitle = like.House.Title,
                    HousePrice = like.House.Price,
                    HousePhotoUrl = like.House.Photos.FirstOrDefault(x => x.IsMain).Url,
                   
                });

            return await PagedList<HouseLikeDto>.CreateAsync(likedHouses, likesParams.PageNumber, likesParams.PageSize);
        }








        public async Task<bool> IsLikedAsync(int userId, int houseId)
        {
            return await _context.HouseLikes
                .AnyAsync(hl => hl.AppUserId == userId && hl.HouseId == houseId);
        }

        public void DeleteLikedHouseAd(int userId, int houseId)
        {
            // Get the HouseLike entity.
            var houseLike = _context.HouseLikes.Include(hl => hl.AppUser).Include(hl => hl.House)
                .SingleOrDefault(hl => hl.AppUserId == userId && hl.HouseId == houseId);

            // Check if the HouseLike entity exists.
            if (houseLike == null)
            {
                // Return an error message.
                return;
            }

            // Remove the liked house ad from the AppUser's LikedHouses collection.
            if (houseLike.AppUser != null && houseLike.AppUser.LikedHouses != null)
            {
                houseLike.AppUser.LikedHouses.Remove(houseLike);
            }

            // Remove the liked house ad from the House's LikedByUsers collection.
            if (houseLike.House != null && houseLike.House.LikedByUsers != null)
            {
                houseLike.House.LikedByUsers.Remove(houseLike);
            }

            // Delete the HouseLike entity.
            _context.HouseLikes.Remove(houseLike);

            // Save the changes to the database.
            _context.SaveChanges();
        }




        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}

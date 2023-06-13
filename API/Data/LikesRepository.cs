using System.Net;
using API.DTOs;
using API.Entities;
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
        public HouseLike GetHouseLikeByUserIdAndHouseId(int userId, int houseId)
        {
            return _context.HouseLikes
                .Where(hl => hl.AppUserId == userId && hl.HouseId == houseId)
                .SingleOrDefault();
        }

        public async Task<IEnumerable<HouseLikeDto>> GetLikedAdsAsync(int userId)
        {
            var likes = await _context.HouseLikes
                .Include(x => x.House)
                .ThenInclude(x => x.Photos)
                .Where(x => x.AppUserId == userId)
                .ToListAsync();

            return _mapper.Map<IEnumerable<HouseLikeDto>>(likes);
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

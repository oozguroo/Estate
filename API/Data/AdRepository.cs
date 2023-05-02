using API.DTOs;
using API.Entities;
using API.Entities.Homes;
using API.Entities.Location;
using API.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class AdRepository : IAdRepository
    {
        private readonly DataContext _context;
        public AdRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<House>> GetHousesAsync()
        {
            return await _context.Houses
                .Include(h => h.HouseLocations)
                    .ThenInclude(l => l.City)
                .Include(h => h.HouseLocations)
                    .ThenInclude(l => l.Town)
                .Include(h => h.HouseLocations)
                    .ThenInclude(l => l.District)
                .Include(h => h.HouseCategories)
                    .ThenInclude(l => l.Category)
                .Include(h => h.Photos)
                .Include(h => h.AppUser) // Include the AppUser entity
                .Select(h => new House
                {
                    AppUserId = h.AppUserId,
                    AppUser = new AppUser
                    {
                        Id = h.AppUser.Id,
                        UserName = h.AppUser.UserName
                    }
                })
                .ToListAsync();
        }






        public async Task<House> GetHouseByIdAsync(int id)
        {
            return await _context.Houses

                     .Include(h => h.HouseLocations)
                    .ThenInclude(l => l.City)
                .Include(h => h.HouseLocations)
                    .ThenInclude(l => l.Town)
                .Include(h => h.HouseLocations)
                    .ThenInclude(l => l.District)
                .Include(h => h.HouseCategories)
                 .ThenInclude(l => l.Category)
                 .Include(h => h.Photos)
    .FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task<AppUser> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.UserName == username);
        }

        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<IEnumerable<House>> GetHousesByUserAsync(string username)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == username);
            if (user == null)
            {
                return null;
            }

            return await _context.Houses
                .Include(h => h.HouseLocations)
                    .ThenInclude(l => l.City)
                .Include(h => h.HouseLocations)
                    .ThenInclude(l => l.Town)
                .Include(h => h.HouseLocations)
                    .ThenInclude(l => l.District)
                .Include(h => h.HouseCategories)
                    .ThenInclude(l => l.Category)
                .Include(h => h.Photos)
                .Where(h => h.AppUserId == user.Id)
                .ToListAsync();
        }


    }
}
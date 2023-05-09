using API.DTOs;
using API.Entities;
using API.Entities.Homes;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class AdRepository : IAdRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public AdRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }



        public async Task<HouseDto> GetHouseAsync(int id)
        {
            return await _context.Houses

            .Where(x => x.Id == id)


      .ProjectTo<HouseDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();

        }




        public async Task<IEnumerable<HouseDto>> GetHousesAsync()
        {
            var houses = await _context.Houses
                .ProjectTo<HouseDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return houses;
        }




        public async Task<AppUser> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.UserName == username);
        }

        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }



        public void Update(House house)
        {
            _context.Entry(house).State = EntityState.Modified;
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void AddHouse(House house)
        {
            // Add the house to the database or perform any necessary operations
            _context.Houses.Add(house);
            _context.SaveChanges();
        }


    }
}
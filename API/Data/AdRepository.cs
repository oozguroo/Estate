using API.DTOs;
using API.Entities;
using API.Entities.Homes;
using API.Interfaces;
using API.Services;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CloudinaryDotNet;
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



        public async Task<HouseDto> GetHouseByIdAsync(int id)
        {
            return await _context.Houses

            .Where(x => x.Id == id)
     .ProjectTo<HouseDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();

        }
        public async Task<MemberDto> GetUserByIdAsync(int id)
        {
            return await _context.Users
          .Where(x => x.Id == id)
   .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
              .SingleOrDefaultAsync();
        }




        public async Task<IEnumerable<HouseDto>> GetHousesAsync()
        {
            var houses = await _context.Houses
                .ProjectTo<HouseDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            var currentDate = DateTime.UtcNow;

            foreach (var house in houses)
            {
                house.IsActive = house.ExpirationDate > currentDate;
            }

            return houses;
        }




        public async Task<AppUser> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.UserName == username);
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


        public async Task<NewHouseDto> CreateHouseAsync(NewHouseDto newHouseDto)
        {
            // Create a new House entity from the NewHouseDto using AutoMapper
            var house = _mapper.Map<House>(newHouseDto);
            foreach (var photoDto in newHouseDto.Photos)
            {
                var photo = new Photo
                {
                    Url = photoDto.Url,
                    IsMain = photoDto.IsMain,
                    PublicId = photoDto.PublicId
                };
                house.Photos.Add(photo);
            }

            // Add the new House entity to the database
            _context.Houses.Add(house);
            await _context.SaveChangesAsync();


            // Map the new House entity to a HouseDto
            var houseDto = _mapper.Map<HouseDto>(house);

            return newHouseDto;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
           return await _context.Categories.ToListAsync();
        }

        public async Task<IEnumerable<Town>> GetTownsAsync()
        {
                 return await _context.Towns.ToListAsync();
        }

        public async Task<IEnumerable<District>> GetDistrictsAsync()
        {
               return await _context.Districts.ToListAsync();
        }
    }
}
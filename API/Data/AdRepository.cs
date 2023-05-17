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
        private readonly IPhotoService _photoService;

        public AdRepository(DataContext context, IMapper mapper, IPhotoService photoService)
        {
            _photoService = photoService;
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


        public async Task<Category> GetCategoryAsync(int categoryId)
        {
            var category = await _context.Categories.SingleOrDefaultAsync(c => c.Id == categoryId);
            return category;
        }

        public async Task<Town> GetTownAsync(int townId)
        {
            var town = await _context.Towns.SingleOrDefaultAsync(c => c.Id == townId);
            return town;
        }

        public async Task<District> GetDistrictAsync(int districtId)
        {
            var district = await _context.Districts.SingleOrDefaultAsync(c => c.Id == districtId);
            return district;
        }

        public async Task<HouseDto> CreateHouseAsync(HouseDto houseDto)
        {
            // Retrieve and validate categories, towns, and districts
            var categoryIds = houseDto.Categories.Select(c => c.Id).ToList();
            var categories = await _context.Categories
                .Where(c => categoryIds.Contains(c.Id))
                .ToListAsync();

            if (categories.Count != categoryIds.Count)
            {
                throw new InvalidOperationException("Invalid categories");
            }

            var townIds = houseDto.Towns.Select(t => t.Id).ToList();
            var towns = await _context.Towns
                .Where(t => townIds.Contains(t.Id))
                .ToListAsync();

            if (towns.Count != townIds.Count)
            {
                throw new InvalidOperationException("Invalid towns");
            }

            var districtIds = houseDto.Districts.Select(d => d.Id).ToList();
            var districts = await _context.Districts
                .Where(d => districtIds.Contains(d.Id))
                .ToListAsync();

            if (districts.Count != districtIds.Count)
            {
                throw new InvalidOperationException("Invalid districts");
            }

            // Create a new House entity
            var house = _mapper.Map<HouseDto, House>(houseDto);

            // Set the AppUserId property
            house.AppUserId = houseDto.AppUserId;

            // Add house categories
            house.HouseCategories.AddRange(categories.Select(c => new HouseCategory { Category = c }));

            // Add house towns
            house.HouseTowns.AddRange(towns.Select(t => new HouseTown { Town = t }));

            // Add house districts
            house.HouseDistricts.AddRange(districts.Select(d => new HouseDistrict { District = d }));

            // Save the house to the database
            _context.Houses.Add(house);
            await _context.SaveChangesAsync();

            // Map the created house back to a HouseDto
            var createdHouseDto = _mapper.Map<House, HouseDto>(house);

            return createdHouseDto;
        }




    }
}
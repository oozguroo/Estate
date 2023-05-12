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



        public async Task<HouseDto> GetHouseByIdAsync(int id)
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
            var house = _mapper.Map<HouseDto, House>(houseDto);

            // Retrieve and validate categories
            var categoryIds = houseDto.Categories.Select(c => c.Id).ToList();
            var categories = await _context.Categories.Where(c => categoryIds.Contains(c.Id)).ToListAsync();
            if (categories.Count != categoryIds.Count)
            {
                throw new InvalidOperationException("Invalid categories");
            }

            // Retrieve and validate towns
            var townIds = houseDto.Towns.Select(t => t.Id).ToList();
            var towns = await _context.Towns.Where(t => townIds.Contains(t.Id)).ToListAsync();
            if (towns.Count != townIds.Count)
            {
                throw new InvalidOperationException("Invalid towns");
            }

            // Retrieve and validate districts
            var districtIds = houseDto.Districts.Select(d => d.Id).ToList();
            var districts = await _context.Districts.Where(d => districtIds.Contains(d.Id)).ToListAsync();
            if (districts.Count != districtIds.Count)
            {
                throw new InvalidOperationException("Invalid districts");
            }

            // Add house categories
            foreach (var category in categories)
            {
                house.HouseCategories.Add(new HouseCategory
                {
                    Category = category
                });
            }

            // Add house towns
            foreach (var town in towns)
            {
                house.HouseTowns.Add(new HouseTown
                {
                    Town = town
                });
            }

            // Add house districts
            foreach (var district in districts)
            {
                house.HouseDistricts.Add(new HouseDistrict
                {
                    District = district
                });
            }

            _context.Houses.Add(house);
            await _context.SaveChangesAsync();

            var createdHouseDto = _mapper.Map<House, HouseDto>(house);
            return createdHouseDto;
        }




    }
}
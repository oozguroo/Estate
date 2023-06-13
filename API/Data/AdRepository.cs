using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using API.DTOs;
using API.Entities;
using API.Entities.Homes;
using API.Extensions;
using API.Interfaces;
using API.Services;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;


namespace API.Data
{
    public class AdRepository : IAdRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly IPhotoService _photoService;
        private readonly IUserRepository _userRepository;

        public AdRepository(DataContext context, IMapper mapper, IConfiguration config, IPhotoService photoService, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _photoService = photoService;
            _mapper = mapper;
            _context = context;
            _config = config;
        }

        public async Task<UpdateHouseDto> UpdateHouseAsync(UpdateHouseDto updateHouseDto, string username)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.UserName == username);
            if (user == null)
            {
                // User not found, handle accordingly
                return null;
            }

            var house = await _context.Houses.FindAsync(updateHouseDto.Id);
            if (house == null)
            {
                return null;
            }

            // Ensure that the user is the owner of the house
            if (house.AppUserId != user.Id)
            {
                // User is not authorized to update this house, handle accordingly
                return null;
            }

            // Update the house entity based on the updateHouseDto
            _mapper.Map(updateHouseDto, house);

            await _context.SaveChangesAsync();
            updateHouseDto.Id = house.Id;
            return updateHouseDto;
        }




        public async Task<HouseDto> GetHouseByIdAsync(int id)
        {
            return await _context.Houses

            .Where(x => x.Id == id)
     .ProjectTo<HouseDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
 
        }

        public async Task<HttpStatusCode> DeleteHouseAdAsync(int id, string username)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.UserName == username);

            if (user == null)
            {
                return HttpStatusCode.Unauthorized;
            }

            var house = await _context.Houses.Include(h => h.Photos).FirstOrDefaultAsync(h => h.Id == id);
            if (house == null)
            {
                return HttpStatusCode.NotFound;
            }

            if (house.AppUserId != user.Id)
            {
                return HttpStatusCode.Unauthorized;
            }

            // Delete the associated photos from Cloudinary
            foreach (var photo in house.Photos)
            {
                if (!string.IsNullOrEmpty(photo.PublicId))
                {
                    await _photoService.DeletePhotoAsync(photo.PublicId);
                }
            }

            _context.Houses.Remove(house);
            await _context.SaveChangesAsync();

            return HttpStatusCode.OK;
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

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }


        public async Task<NewHouseDto> CreateHouseAsync(NewHouseDto newHouseDto, string username)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.UserName == username);

            if (user == null)
            {
                throw new Exception("User not found"); // Handle the case where the user is not found
            }

            var house = _mapper.Map<House>(newHouseDto);
            house.AppUserId = user.Id;

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

            _context.Houses.Add(house);
            await _context.SaveChangesAsync();
            newHouseDto.Id = house.Id;

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
using API.DTOs;
using API.Entities;
using API.Entities.Homes;

namespace API.Interfaces
{
    public interface IAdRepository
    {
        Task<IEnumerable<HouseDto>> GetHousesAsync();
        Task<HouseDto> GetHouseByIdAsync(int id);
        Task<AppUser> GetUserByIdAsync(int id);
        Task<bool> SaveAllAsync();
        void Update(House house);

        Task<Category> GetCategoryAsync(int categoryId);
        Task<Town> GetTownAsync(int townId);
        Task<District> GetDistrictAsync(int districtId);

     Task<HouseDto> CreateHouseAsync(HouseDto houseDto);





    }
}
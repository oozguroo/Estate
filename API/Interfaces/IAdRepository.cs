using API.DTOs;
using API.Entities;
using API.Entities.Homes;

namespace API.Interfaces
{
    public interface IAdRepository
    {
        Task<IEnumerable<HouseDto>> GetHousesAsync();
        Task<HouseDto> GetHouseAsync(int id);
        Task<AppUser> GetUserByIdAsync(int id);
        Task<bool> SaveAllAsync();
         void Update(House house);

        void AddHouse(House house);






    }
} 
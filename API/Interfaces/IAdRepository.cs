using API.DTOs;
using API.Entities;
using API.Entities.Homes;

namespace API.Interfaces
{
    public interface IAdRepository
    {
        Task<IEnumerable<HouseDto>> GetHousesAsync();
        Task<HouseDto> GetHouseByIdAsync(int id);
        Task<MemberDto> GetUserByIdAsync(int id);
        Task<bool> SaveAllAsync();
        void Update(House house);
        Task<AppUser> GetUserByUsernameAsync(string username);
        Task<NewHouseDto> CreateHouseAsync(NewHouseDto newHouseDto);

    }
}
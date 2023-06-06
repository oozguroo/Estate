using System.Net;
using API.DTOs;
using API.Entities;
using API.Entities.Homes;

namespace API.Interfaces
{
    public interface IAdRepository
    {
        Task<IEnumerable<HouseDto>> GetHousesAsync();
        Task<HouseDto> GetHouseByIdAsync(int id);
        Task<bool> SaveAllAsync();

        Task<UpdateHouseDto> UpdateHouseAsync(UpdateHouseDto updateHouseDto);
        Task<NewHouseDto> CreateHouseAsync(NewHouseDto newHouseDto);
         Task<HttpStatusCode> DeleteHouseAdAsync(int id, string token);

        Task<AppUser> GetUserByUsernameAsync(string username);

        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<IEnumerable<Town>> GetTownsAsync();
        Task<IEnumerable<District>> GetDistrictsAsync();

    }
}
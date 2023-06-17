using System.Net;
using API.DTOs;
using API.Entities;
using API.Entities.Homes;
using API.Helpers;

namespace API.Interfaces
{
    public interface IAdRepository
    {
        Task<PagedList<HouseDto>> GetHousesAsync(HouseParams houseParams);
        Task<HouseDto> GetHouseByIdAsync(int id);
        Task<bool> SaveAllAsync();

        Task<UpdateHouseDto> UpdateHouseAsync(UpdateHouseDto updateHouseDto, string username);
        Task<NewHouseDto> CreateHouseAsync(NewHouseDto newHouseDto,string username);
        Task<HttpStatusCode> DeleteHouseAdAsync(int id, string token);

        Task<AppUser> GetUserByUsernameAsync(string username);

        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<IEnumerable<Town>> GetTownsAsync();
        Task<IEnumerable<District>> GetDistrictsAsync();

    }
}
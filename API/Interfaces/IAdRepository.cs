using API.DTOs;
using API.Entities;
using API.Entities.Homes;

namespace API.Interfaces
{
    public interface IAdRepository
    {
        Task<IEnumerable<House>>GetHousesAsync();
        Task<House>GetHouseByIdAsync(int id);

        Task<AppUser>GetUserByUsernameAsync(string username);
        Task<AppUser> GetUserByIdAsync(int id);

        Task<IEnumerable<House>> GetHousesByUserAsync(string username);


    }
}
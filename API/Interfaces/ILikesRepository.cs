using System.Net;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface ILikesRepository
    {
        Task<HouseLikeDto> AddLikeAsync(int userId, int houseId);
        Task<IEnumerable<HouseLikeDto>> GetLikedAdsAsync(int userId);
        Task<bool> IsLikedAsync(int userId, int houseId);
        Task<bool> SaveChangesAsync();
        void DeleteLikedHouseAd(int userId, int houseId);
        HouseLike GetHouseLikeByUserIdAndHouseId(int userId, int houseId);
    }

}


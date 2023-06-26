using System.Net;
using API.DTOs;
using API.Entities;
using API.Helpers;

namespace API.Interfaces
{
    public interface ILikesRepository
    {
        Task<HouseLikeDto> AddLikeAsync(int userId, int houseId); 
        Task<PagedList<HouseLikeDto>> GetLikedAdsAsync(LikesParams likesParams);
        Task<bool> IsLikedAsync(int userId, int houseId);
        Task<bool> SaveChangesAsync();
        void DeleteLikedHouseAd(int userId, int houseId);
/*         HouseLike GetHouseLikeByUserIdAndHouseId(int userId, int houseId); */
    }

}


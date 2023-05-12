using API.DTOs;
using API.Entities;
using API.Entities.Homes;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>();
            CreateMap<AppUser, HouseDto>();

            // Category
            CreateMap<Category, CategoryDto>();
            //Location
            CreateMap<Town, TownDto>();
            CreateMap<District, DistrictDto>();
            CreateMap<TownDto, Town>();
            CreateMap<DistrictDto, District>();


            CreateMap<HouseDto, House>();

            // House
            CreateMap<House, HouseDto>()
 .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.HouseCategories.Select(hc => hc.Category)))
  .ForMember(dest => dest.Towns, opt => opt.MapFrom(src => src.HouseTowns.Select(ht => ht.Town)))
   .ForMember(dest => dest.Districts, opt => opt.MapFrom(src => src.HouseDistricts.Select(hd => hd.District)))
    .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.AppUser.UserName))
    .ForMember(dest => dest.PhotoUrl,
                    opt => opt.MapFrom(src => src.Photos.FirstOrDefault(x => x.IsMain).Url))
    .ForMember(dest => dest.Photos, opt => opt.MapFrom(src => src.Photos.Select(p => new PhotoDto { Id = p.Id, Url = p.Url, IsMain = p.IsMain }).ToList()));
            // Photo
            CreateMap<Photo, PhotoDto>();
            CreateMap<PhotoDto, Photo>(); // Add this mapping


        }

    }

}

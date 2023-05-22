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
            CreateMap<Town, TownDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<District, DistrictDto>();
            CreateMap<TownDto, Town>();
            CreateMap<CategoryDto, Category>();
            CreateMap<DistrictDto, District>();
            CreateMap<HouseDto, House>();
            CreateMap<House, HouseDto>()
            .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => src.Photos.FirstOrDefault(x => x.IsMain).Url))
                    .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.AppUser.UserName))
                .ForMember(dest => dest.Photos, opt => opt.MapFrom(src => src.Photos.Select(p => new PhotoDto { Id = p.Id, Url = p.Url, IsMain = p.IsMain }).ToList())).ReverseMap();
            // Photo
            CreateMap<Photo, PhotoDto>();
            CreateMap<PhotoDto, Photo>();

            CreateMap<House, NewHouseDto>()
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
                .ForMember(dest => dest.TownId, opt => opt.MapFrom(src => src.TownId))
                .ForMember(dest => dest.DistrictId, opt => opt.MapFrom(src => src.DistrictId))
                  .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.AppUser.UserName))
                   .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => src.Photos.FirstOrDefault(x => x.IsMain).Url))
                 .ForMember(dest => dest.Photos, opt => opt.MapFrom(src => src.Photos.Select(p => new PhotoDto { Id = p.Id, Url = p.Url, IsMain = p.IsMain }).ToList())).ReverseMap();

            CreateMap<NewHouseDto, House>()
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
                .ForMember(dest => dest.TownId, opt => opt.MapFrom(src => src.TownId))
                .ForMember(dest => dest.DistrictId, opt => opt.MapFrom(src => src.DistrictId))
                 .ForMember(dest => dest.Photos, opt => opt.MapFrom(src => src.Photos.Select(p => new PhotoDto { Id = p.Id, Url = p.Url, IsMain = p.IsMain }).ToList())).ReverseMap();

        }
    }


}



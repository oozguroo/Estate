using API.DTOs;
using API.Entities;
using API.Entities.Homes;
using API.Entities.Location;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>();

            // HouseLocation
            CreateMap<HouseLocation, HouseLocationDto>();

            // HouseCategory
            CreateMap<HouseCategory, HouseCategoryDto>();

            // Category
            CreateMap<Category, CategoryDto>();

            // House
            CreateMap<House, HouseDto>()
     .ForMember(dest => dest.Photos, opt => opt.MapFrom(src => src.Photos.Select(p => new PhotoDto { Url = p.Url })))
     .ForMember(dest => dest.HouseLocations, opt => opt.MapFrom(src => src.HouseLocations.Select(hl => new HouseLocationDto
     {
         City = new CityDto { Name = hl.City.Name },
         Town = new TownDto { Name = hl.Town.Name },
         District = new DistrictDto { Name = hl.District.Name }
     }).ToList()))
      .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.AppUser.UserName));



            // Photo
            CreateMap<Photo, PhotoDto>();

            // City
            CreateMap<City, CityDto>();

            // Town
            CreateMap<Town, TownDto>();

            // District
            CreateMap<District, DistrictDto>();




        }
    }

}
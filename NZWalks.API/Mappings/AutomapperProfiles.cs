using AutoMapper;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTOs;

namespace NZWalks.API.Mappings
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles() {
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<RegionCreateDto, Region>().ReverseMap();
            CreateMap<UpdateRegionDto, Region>().ReverseMap();
        }
    }
}

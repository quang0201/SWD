
using AutoMapper;
using BusinessObjects.Models;
using ModelViews.Models;

namespace Server.Profile_Maper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Food, FoodViewModel>()
                    .ForMember(dest => dest.FoodProvider, opt => opt.MapFrom(src => src.CreatedByNavigation.Username));
        }
    }
}

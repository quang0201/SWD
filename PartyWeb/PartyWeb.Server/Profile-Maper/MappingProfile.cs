
using AutoMapper;
using BusinessObjects.Models;
using ModelViews.Models;

namespace Server.Profile_Maper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Food, FoodView>().ReverseMap();
        }
    }
}

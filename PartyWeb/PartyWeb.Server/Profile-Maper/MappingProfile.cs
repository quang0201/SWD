
using AutoMapper;
using BusinessObjects.Models;
using ModelViews.Models;
using ModelViews.ModelView;
using ModelViews.ModelView.Accounts;

namespace Server.Profile_Maper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Food, FoodViewModel>()
                    .ForMember(dest => dest.FoodProvider, opt => opt.MapFrom(src => src.CreatedByNavigation.Username)).ReverseMap();
            CreateMap<OrderFood, OrderFoodModel>().ReverseMap();
            CreateMap<OrderDecor, OrderDecorModel>().ReverseMap();
            CreateMap<OrderRoom, OrderRoomModel>().ReverseMap();
            CreateMap<OrderRoomModel, OrderRoom>().ReverseMap();
            CreateMap<Decor, DecorViewModel>()
                    .ForMember(dest => dest.DecorProvider, opt => opt.MapFrom(src => src.CreatedByNavigation.Username)).ReverseMap();
            CreateMap<Room, RoomViewModel>()
                   .ForMember(dest => dest.DecorProvider, opt => opt.MapFrom(src => src.CreatedByNavigation.Username)).ReverseMap();

            // account mappers
            CreateMap<Account, AccountModel>().ReverseMap();
            CreateMap<Account, AddNewAccountModel>().ReverseMap();
            CreateMap<Account, UpdateAccountModel>().ReverseMap();
            CreateMap<Account, ViewAccountModel>().ReverseMap();


            CreateMap<Feedback, FeedbackModel>().ReverseMap();
            CreateMap<PartyPost, PartyPostModel>().ReverseMap();
        }
    }
}

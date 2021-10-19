using AutoMapper;
using RoomScheduler.Services.DataTransferObjects;
using RoomScheduler.Web.ViewModels;

namespace RoomScheduler.Web.Mapping
{
    public class WebAutoMapperProfile : Profile
    {
        public WebAutoMapperProfile()
        {
            CreateMap<RoomDto, RoomAllViewModel>();
            CreateMap<RoomDto, RoomCurrentViewModel>();
            CreateMap<RoomDto, RoomFilterViewModel>();
            CreateMap<TimeSlotDto, TimeSlotViewModel>();
            CreateMap<AvailableTimeDto, AvailableTimeViewModel>();
        }
    }
}

using AutoMapper;
using RoomScheduler.Data.Json;
using RoomScheduler.Data.Models;
using RoomScheduler.Services.DataTransferObjects;

namespace RoomScheduler.Services.Mapping
{
    class ServicesAutoMapperProfile : Profile
    {
        public ServicesAutoMapperProfile()
        {
            CreateMap<ApplicationUser, ApplicationUserDto>();
            CreateMap<Room, RoomDto>();
            CreateMap<TimeSlot, TimeSlotDto>().ForMember(x => x.RoomName, x => x.MapFrom(x => x.Room.Name));

            CreateMap<RoomDto, JsonRoom>().ForMember(x => x.RoomName, x => x.MapFrom(x => x.Name));
            CreateMap<TimeSlotDto, JsonTimeSlot>();
        }
    }
}

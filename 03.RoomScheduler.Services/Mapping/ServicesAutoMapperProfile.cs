using AutoMapper;
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
            CreateMap<TimeSlot, TimeSlotDto>();
        }
    }
}

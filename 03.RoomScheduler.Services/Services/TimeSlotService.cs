using AutoMapper;
using AutoMapper.QueryableExtensions;
using RoomScheduler.Data;
using RoomScheduler.Data.Models;
using RoomScheduler.Services.DataTransferObjects;
using RoomScheduler.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomScheduler.Services.Services
{
    public class TimeSlotService : ITimeSlotService
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public TimeSlotService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        
        public async Task<string> AddTimeSlotAsync(DateTime from, DateTime to, int roomId, string userId)
        {
            TimeSlot timeSlot = new()
            {
                From = from,
                To = to,
                RoomId = roomId,
                CreatorId = userId
            };

            await context.TimeSlots.AddAsync(timeSlot);
            await context.SaveChangesAsync();
            return timeSlot.Guid;
        }

        public async Task<string> DeleteTimeSlotAsync(int timeSlotId)
        {
            TimeSlot timeSlot = context.TimeSlots
                .Where(x => x.Id == timeSlotId)
                .FirstOrDefault();

            context.TimeSlots.Remove(timeSlot);
            await context.SaveChangesAsync();
            return timeSlot.Guid;
        }

        public async Task<string> UpdateTimeSlotFromAsync(int timeSlotId, DateTime from)
        {
            TimeSlot timeSlot = context.TimeSlots
                .Where(x => x.Id == timeSlotId)
                .FirstOrDefault();

            timeSlot.From = from;
            await context.SaveChangesAsync();
            return timeSlot.Guid;
        }

        public async Task<string> UpdateTimeSlotToAsync(int timeSlotId, DateTime to)
        {
            TimeSlot timeSlot = context.TimeSlots
                .Where(x => x.Id == timeSlotId)
                .FirstOrDefault();

            timeSlot.To = to;
            await context.SaveChangesAsync();
            return timeSlot.Guid;
        }

        public async Task<string> UpdateTimeSlotRoomAsync(int timeSlotId, int roomId)
        {
            TimeSlot timeSlot = context.TimeSlots
                .Where(x => x.Id == timeSlotId)
                .FirstOrDefault();

            timeSlot.RoomId = roomId;
            await context.SaveChangesAsync();
            return timeSlot.Guid;
        }

        public List<TimeSlotDto> GetAllTimeSlotsByRoom(int roomId)
        {
            List<TimeSlotDto> timeSlotsDto = context.TimeSlots
                .Where(x => x.RoomId == roomId)
                .ProjectTo<TimeSlotDto>(mapper.ConfigurationProvider)
                .ToList();

            return timeSlotsDto;
        }

        public List<TimeSlotDto> GetAllTimeSlotsByUser(string userId)
        {
            List<TimeSlotDto> timeSlotsDto = context.TimeSlots
                .Where(x => x.CreatorId == userId)
                .ProjectTo<TimeSlotDto>(mapper.ConfigurationProvider)
                .ToList();

            return timeSlotsDto;
        }

        public TimeSlotDto GetTimeSlotById(int timeSlotId)
        {
            TimeSlotDto timeSlotDto = context.TimeSlots
                .Where(x => x.Id == timeSlotId)
                .ProjectTo<TimeSlotDto>(mapper.ConfigurationProvider)
                .FirstOrDefault();

            return timeSlotDto;
        }

        public TimeSlotDto GetTimeSlotByGuid(string timeSlotGuid)
        {
            TimeSlotDto timeSlotDto = context.TimeSlots
                .Where(x => x.Guid == timeSlotGuid)
                .ProjectTo<TimeSlotDto>(mapper.ConfigurationProvider)
                .FirstOrDefault();

            return timeSlotDto;
        }
    }
}

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

        public List<AvailableTimeDto> GetAvailableTimeSlotsByRoom(DateTime date, TimeSpan duration, int roomId)
        {
            List<TimeSlotDto> reservedTimeSlots = context.TimeSlots
                .Where(x => x.RoomId == roomId && x.From.Date == date)
                .ProjectTo<TimeSlotDto>(mapper.ConfigurationProvider)
                .ToList();

            TimeSpan roomAvailableFrom = context.Rooms
                .Where(x => x.Id == roomId)
                .Select(x => x.AvailableFrom)
                .FirstOrDefault();

            TimeSpan roomAvailableTo = context.Rooms
                .Where(x => x.Id == roomId)
                .Select(x => x.AvailableTo)
                .FirstOrDefault();

            List<AvailableTimeDto> roomTimesAvailable = new();

            if (reservedTimeSlots.Count == 0)
            {
                roomTimesAvailable.AddRange(GetAvailableTimeSlotsBetweenTimeSpans(roomAvailableFrom, roomAvailableTo, duration));
                return roomTimesAvailable;
            }

            if (reservedTimeSlots[0].From.TimeOfDay - roomAvailableFrom >= duration)
            {
                roomTimesAvailable.AddRange(GetAvailableTimeSlotsBetweenTimeSpans(roomAvailableFrom, reservedTimeSlots[0].From.TimeOfDay, duration));
            }

            for (int i = 0; i < reservedTimeSlots.Count - 1; i++)
            {
                int index = i;
                var to = reservedTimeSlots[index].To.TimeOfDay;
                var from = reservedTimeSlots[index + 1].From.TimeOfDay;

                if (reservedTimeSlots[index + 1].From.TimeOfDay - reservedTimeSlots[index].To.TimeOfDay >= duration)
                {
                    roomTimesAvailable.AddRange(GetAvailableTimeSlotsBetweenTimeSpans(reservedTimeSlots[index].To.TimeOfDay, reservedTimeSlots[index + 1].From.TimeOfDay, duration));
                }
            }

            if (roomAvailableTo - reservedTimeSlots[reservedTimeSlots.Count - 1].To.TimeOfDay >= duration)
            {
                roomTimesAvailable.AddRange(GetAvailableTimeSlotsBetweenTimeSpans(reservedTimeSlots[reservedTimeSlots.Count - 1].To.TimeOfDay, roomAvailableTo, duration));
            }

            return roomTimesAvailable;
        }

        private static List<AvailableTimeDto> GetAvailableTimeSlotsBetweenTimeSpans(TimeSpan start, TimeSpan end, TimeSpan duration)
        {
            List<AvailableTimeDto> timeSlotsAvailable = new();

            for (TimeSpan i = start; i < end; i += TimeSpan.FromMinutes(15))
            {
                var availableTime = new AvailableTimeDto()
                {
                    From = i,
                    To = i + duration
                };

                if (availableTime.To <= end)
                {
                    timeSlotsAvailable.Add(availableTime);
                }
                else
                {
                    break;
                }
            }

            return timeSlotsAvailable;
        }
    }
}

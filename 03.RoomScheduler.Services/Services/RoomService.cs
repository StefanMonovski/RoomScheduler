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
    public class RoomService : IRoomService
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        
        public RoomService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<string> AddRoomAsync(string name, int capacity, DateTime availableFrom, DateTime availableTo, string userId)
        {
            Room room = new()
            {
                Name = name,
                Capacity = capacity,
                AvailableFrom = availableFrom,
                AvailableTo = availableTo,
                CreatorId = userId
            };

            await context.Rooms.AddAsync(room);
            await context.SaveChangesAsync();
            return room.Guid;
        }

        public async Task<string> DeleteRoomAsync(int roomId)
        {
            Room room = context.Rooms
                .Where(x => x.Id == roomId)
                .FirstOrDefault();

            context.Rooms.Remove(room);
            await context.SaveChangesAsync();

            return room.Guid;
        }

        public async Task<string> UpdateRoomNameAsync(int roomId, string name)
        {
            Room room = context.Rooms
                .Where(x => x.Id == roomId)
                .FirstOrDefault();

            room.Name = name;
            await context.SaveChangesAsync();

            return room.Guid;
        }

        public async Task<string> UpdateRoomCapacityAsync(int roomId, int capacity)
        {
            Room room = context.Rooms
                .Where(x => x.Id == roomId)
                .FirstOrDefault();

            room.Capacity = capacity;
            await context.SaveChangesAsync();

            return room.Guid;
        }

        public async Task<string> UpdateRoomAvailableFromAsync(int roomId, DateTime availableFrom)
        {
            Room room = context.Rooms
                .Where(x => x.Id == roomId)
                .FirstOrDefault();

            room.AvailableFrom = availableFrom;
            await context.SaveChangesAsync();

            return room.Guid;
        }

        public async Task<string> UpdateRoomAvailableToAsync(int roomId, DateTime availableTo)
        {
            Room room = context.Rooms
                .Where(x => x.Id == roomId)
                .FirstOrDefault();

            room.AvailableTo = availableTo;
            await context.SaveChangesAsync();

            return room.Guid;
        }

        public List<RoomDto> GetAllRooms()
        {
            List<RoomDto> roomsDto = context.Rooms
                .ProjectTo<RoomDto>(mapper.ConfigurationProvider)
                .ToList();

            return roomsDto;
        }

        public RoomDto GetRoomById(int roomId)
        {
            RoomDto roomDto = context.Rooms
                .Where(x => x.Id == roomId)
                .ProjectTo<RoomDto>(mapper.ConfigurationProvider)
                .FirstOrDefault();

            return roomDto;
        }

        public RoomDto GetRoomByGuid(string roomGuid)
        {
            RoomDto roomDto = context.Rooms
                .Where(x => x.Guid == roomGuid)
                .ProjectTo<RoomDto>(mapper.ConfigurationProvider)
                .FirstOrDefault();

            return roomDto;
        }
    }
}

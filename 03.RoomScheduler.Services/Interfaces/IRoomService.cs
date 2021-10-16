using RoomScheduler.Services.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoomScheduler.Services.Interfaces
{
    public interface IRoomService
    {
        Task<string> AddRoomAsync(string name, int capacity, TimeSpan availableFrom, TimeSpan availableTo, string userId);

        Task<string> DeleteRoomAsync(int roomId);

        Task<string> UpdateRoomNameAsync(int roomId, string name);

        Task<string> UpdateRoomCapacityAsync(int roomId, int capacity);

        Task<string> UpdateRoomAvailableFromAsync(int roomId, TimeSpan availableFrom);

        Task<string> UpdateRoomAvailableToAsync(int roomId, TimeSpan availableTo);

        List<RoomDto> GetAllRooms();

        RoomDto GetRoomById(int roomId);

        string GetRoomGuidById(int roomId);

        RoomDto GetRoomByGuid(string roomGuid);

        int GetRoomIdByGuid(string roomGuid);
    }
}

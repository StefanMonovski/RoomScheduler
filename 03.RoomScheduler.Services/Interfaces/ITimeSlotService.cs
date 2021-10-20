using RoomScheduler.Services.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoomScheduler.Services.Interfaces
{
    public interface ITimeSlotService
    {
        Task<string> AddTimeSlotAsync(DateTime from, DateTime to, int roomId, string userId);

        Task<string> DeleteTimeSlotAsync(int timeSlotId);

        Task<string> UpdateTimeSlotFromAsync(int timeSlotId, DateTime from);

        Task<string> UpdateTimeSlotToAsync(int timeSlotId, DateTime to);

        Task<string> UpdateTimeSlotRoomAsync(int timeSlotId, int roomId);

        List<TimeSlotDto> GetAllTimeSlotsByRoom(int roomId);

        List<TimeSlotDto> GetAllTimeSlotsByUser(string userId);

        TimeSlotDto GetTimeSlotById(int timeSlotId);

        TimeSlotDto GetTimeSlotByGuid(string timeSlotGuid);

        List<AvailableTimeDto> GetAvailableTimeSlotsByRoom(DateTime date, TimeSpan duration, int roomId);

        List<AvailableTimeDto> GetOptionalAvailableTimeSlotsByRoom(TimeSpan duration, int roomId);
    }
}

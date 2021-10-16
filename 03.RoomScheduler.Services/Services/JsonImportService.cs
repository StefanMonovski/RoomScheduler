using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RoomScheduler.Data.Json;
using RoomScheduler.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace RoomScheduler.Services.Services
{
    public class JsonImportService : IJsonImportService
    {
        public async void Import(string filePath, IServiceProvider serviceProvider)
        {
            string jsonContent = File.ReadAllText(filePath);
            List<JsonRoom> jsonRooms = JsonConvert.DeserializeObject<List<JsonRoom>>(jsonContent);

            using IServiceScope serviceScope = serviceProvider.GetService<IServiceScopeFactory>().CreateScope();
            IRoomService roomService = serviceScope.ServiceProvider.GetService<IRoomService>();
            ITimeSlotService timeSlotService = serviceScope.ServiceProvider.GetService<ITimeSlotService>();

            foreach (var room in jsonRooms)
            {
                string roomGuid = await roomService.AddRoomAsync(room.RoomName, room.Capacity, room.AvailableFrom, room.AvailableTo, null);
                int roomId = roomService.GetRoomIdByGuid(roomGuid);

                foreach (var timeSlot in room.Schedule)
                {
                    await timeSlotService.AddTimeSlotAsync(timeSlot.From, timeSlot.To, roomId, null);
                }
            }
        }
    }
}
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RoomScheduler.Data.Json;
using RoomScheduler.Services.DataTransferObjects;
using RoomScheduler.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace RoomScheduler.Services.Services
{
    public class JsonExportService : IJsonExportService
    {
        public void Export(string filePath, IServiceProvider serviceProvider)
        {
            using IServiceScope serviceScope = serviceProvider.GetService<IServiceScopeFactory>().CreateScope();
            IRoomService roomService = serviceScope.ServiceProvider.GetService<IRoomService>();
            IMapper mapper = serviceScope.ServiceProvider.GetService<IMapper>();

            List<RoomDto> rooms = roomService.GetAllRooms();
            List<JsonRoom> jsonRooms = mapper.Map<List<JsonRoom>>(rooms);

            File.WriteAllText(filePath, JsonConvert.SerializeObject(jsonRooms, Formatting.Indented));
        }
    }
}

using System;
using System.Collections.Generic;

namespace RoomScheduler.Services.DataTransferObjects
{
    public class RoomDto
    {
        public int Id { get; set; }

        public string Guid { get; set; }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public TimeSpan AvailableFrom { get; set; }

        public TimeSpan AvailableTo { get; set; }

        public string CreatorId { get; set; }

        public ApplicationUserDto Creator { get; set; }

        public List<TimeSlotDto> Schedule { get; set; }
    }
}

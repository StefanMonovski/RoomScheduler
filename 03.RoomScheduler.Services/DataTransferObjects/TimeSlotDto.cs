using System;

namespace RoomScheduler.Services.DataTransferObjects
{
    public class TimeSlotDto
    {
        public int Id { get; set; }

        public string Guid { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public int RoomId { get; set; }

        public string RoomGuid { get; set; }

        public string CreatorId { get; set; }

        public ApplicationUserDto Creator { get; set; }
    }
}

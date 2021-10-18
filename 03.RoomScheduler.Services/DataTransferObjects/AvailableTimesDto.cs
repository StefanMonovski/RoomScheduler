using System;

namespace RoomScheduler.Services.DataTransferObjects
{
    public class AvailableTimesDto
    {
        public TimeSpan From { get; set; }

        public TimeSpan To { get; set; }
    }
}

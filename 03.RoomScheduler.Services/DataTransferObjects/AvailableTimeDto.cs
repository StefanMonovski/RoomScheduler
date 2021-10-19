using System;

namespace RoomScheduler.Services.DataTransferObjects
{
    public class AvailableTimeDto
    {
        public TimeSpan From { get; set; }

        public TimeSpan To { get; set; }
    }
}

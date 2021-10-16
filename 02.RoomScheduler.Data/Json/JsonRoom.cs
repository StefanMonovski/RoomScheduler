using System;
using System.Collections.Generic;

namespace RoomScheduler.Data.Json
{
    public class JsonRoom
    {
        public string RoomName { get; set; }

        public int Capacity { get; set; }

        public TimeSpan AvailableFrom { get; set; }

        public TimeSpan AvailableTo { get; set; }

        public List<JsonTimeSlot> Schedule { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace RoomScheduler.Data.Json
{
    public class JsonRoom
    {
        public string RoomName { get; set; }

        public int Capacity { get; set; }

        public DateTime AvailableFrom { get; set; }

        public DateTime AvailableTo { get; set; }

        public List<JsonTimeSlot> Schedule { get; set; }
    }
}

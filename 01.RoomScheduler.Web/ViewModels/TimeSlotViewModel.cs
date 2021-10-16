using System;

namespace RoomScheduler.Web.ViewModels
{
    public class TimeSlotViewModel
    {
        public int Id { get; set; }

        public string Guid { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }
    }
}

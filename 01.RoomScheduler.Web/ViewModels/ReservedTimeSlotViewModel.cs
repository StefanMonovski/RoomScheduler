using System;

namespace RoomScheduler.Web.ViewModels
{
    public class ReservedTimeSlotViewModel
    {
        public int Id { get; set; }

        public string Guid { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public int RoomId { get; set; }

        public string RoomName { get; set; }

        public string CreatorId { get; set; }
    }
}

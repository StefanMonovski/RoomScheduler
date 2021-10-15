using System;
using System.ComponentModel.DataAnnotations;

namespace RoomScheduler.Data.Models
{
    public class TimeSlot : BaseModel<int>
    {
        public TimeSlot()
        {
            Guid = System.Guid.NewGuid().ToString();
        }

        [Required]
        public string Guid { get; private set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public int RoomId { get; set; }

        public Room Room { get; set; }

        public string CreatorId { get; set; }

        public ApplicationUser Creator { get; set; }
    }
}

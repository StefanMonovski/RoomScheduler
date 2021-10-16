using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RoomScheduler.Data.Models
{
    public class Room : BaseModel<int>
    {
        public Room()
        {
            Guid = System.Guid.NewGuid().ToString();
            Schedule = new HashSet<TimeSlot>();
        }

        [Required]
        public string Guid { get; private set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public int Capacity { get; set; }

        public TimeSpan AvailableFrom { get; set; }

        public TimeSpan AvailableTo { get; set; }

        public ICollection<TimeSlot> Schedule { get; set; }

        public string CreatorId { get; set; }

        public ApplicationUser Creator { get; set; }
    }
}

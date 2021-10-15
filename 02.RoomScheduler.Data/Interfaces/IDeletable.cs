using System;

namespace RoomScheduler.Data.Interfaces
{
    public interface IDeletable
    {
        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
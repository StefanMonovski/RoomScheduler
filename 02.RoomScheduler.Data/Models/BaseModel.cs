using RoomScheduler.Data.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace RoomScheduler.Data.Models
{
    public abstract class BaseModel<TKey> : ICreatable, IDeletable
    {
        [Key]
        public TKey Id { get; set; }

        public DateTime CreatedOn { get; private set; } = DateTime.UtcNow;

        public DateTime? DeletedOn { get; set; } = null;

        public bool IsDeleted { get; set; } = false;
    }
}
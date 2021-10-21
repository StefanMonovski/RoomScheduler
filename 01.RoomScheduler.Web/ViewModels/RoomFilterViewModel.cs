using System.Collections.Generic;

namespace RoomScheduler.Web.ViewModels
{
    public class RoomFilterViewModel
    {
        public int Id { get; set; }

        public string Guid { get; set; }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public List<AvailableTimeViewModel> AvailableSchedule { get; set; }
    }
}

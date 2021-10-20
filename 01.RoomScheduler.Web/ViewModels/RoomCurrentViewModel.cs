using System.Collections.Generic;

namespace RoomScheduler.Web.ViewModels
{
    public class RoomCurrentViewModel
    {
        public int Id { get; set; }

        public string Guid { get; set; }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public List<TimeSlotViewModel> Schedule { get; set; }

        public List<AvailableTimeViewModel> AvailableOptionalSchedule { get; set; }

        public int SelectedOptionalHours { get; set; }
    }
}

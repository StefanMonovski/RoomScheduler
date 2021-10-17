using System;
using System.Collections.Generic;

namespace RoomScheduler.Web.ViewModels
{
    public class FilterViewModel
    {
        public DateTime Date { get; set; }

        public int Participants { get; set; }

        public TimeSpan Duration { get; set; }

        public List<RoomFilterViewModel> Rooms { get; set; }
    }
}

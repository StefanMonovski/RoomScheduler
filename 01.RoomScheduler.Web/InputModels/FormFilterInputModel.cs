using Microsoft.AspNetCore.Mvc;
using RoomScheduler.Web.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace RoomScheduler.Web.InputModels
{
    public class FormFilterInputModel
    {
        [FutureDate]
        [Remote("FutureDateClient", "Validate")]
        [Required(ErrorMessage = "Date is required.")]
        public DateTime Date { get; set; }

        [MinimumParticipants]
        [Remote("MinimumParticipantsClient", "Validate")]
        [Required(ErrorMessage = "Participants are required.")]        
        public int Participants { get; set; }

        [ValidDuration]
        [MinimumDuration]
        [Remote("MinimumDurationClient", "Validate", AdditionalFields = "Minutes")]
        public string Hours { get; set; }
        public string Minutes { get; set; }
    }
}

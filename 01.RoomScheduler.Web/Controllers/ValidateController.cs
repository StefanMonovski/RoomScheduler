using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace RoomScheduler.Web.Controllers
{
    public class ValidateController : Controller
    {
        [HttpGet]
        [HttpPost]
        [Authorize]
        public IActionResult MinimumParticipantsClient(int participants)
        {
            if (participants < 2)
            {
                return Json("Participants should be more than 2.");
            }
            else
            {
                return Json(true);
            }
        }

        [HttpGet]
        [HttpPost]
        [Authorize]
        public IActionResult FutureDateClient(DateTime date)
        {
            if (date.Date < DateTime.Today.Date)
            {
                return Json("Date should be greater than today.");
            }
            else
            {
                return Json(true);
            }
        }

        [HttpGet]
        [HttpPost]
        [Authorize]
        public IActionResult MinimumDurationClient(string hours, string minutes)
        {
            if (hours == "00" && minutes == ":00")
            {
                return Json("Duration should be at least 00:15.");
            }
            else
            {
                return Json(true);
            }
        }
    }
}

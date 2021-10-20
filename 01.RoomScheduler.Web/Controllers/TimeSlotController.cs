using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoomScheduler.Services.Interfaces;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RoomScheduler.Web.Controllers
{
    public class TimeSlotController : Controller
    {
        private readonly ITimeSlotService timeSlotService;

        public TimeSlotController(ITimeSlotService timeSlotService)
        {
            this.timeSlotService = timeSlotService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Reserve(DateTime date, TimeSpan from, TimeSpan to, int roomId)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await timeSlotService.AddTimeSlotAsync(date.Add(from), date.Add(to), roomId, userId);

            return RedirectToAction("Reservations", "User");
        }
    }
}

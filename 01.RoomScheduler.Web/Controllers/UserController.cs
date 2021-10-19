using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoomScheduler.Services.Interfaces;
using RoomScheduler.Web.ViewModels;
using System.Collections.Generic;
using System.Security.Claims;

namespace RoomScheduler.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly ITimeSlotService timeSlotService;
        private readonly IMapper mapper;

        public UserController(ITimeSlotService timeSlotService, IMapper mapper)
        {
            this.timeSlotService = timeSlotService;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Reservations()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var timeSlots = timeSlotService.GetAllTimeSlotsByUser(userId);
            var viewModel = mapper.Map<List<ReservedTimeSlotViewModel>>(timeSlots);

            return View(viewModel);
        }
    }
}

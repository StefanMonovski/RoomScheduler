using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoomScheduler.Services.Interfaces;
using RoomScheduler.Web.ViewModels;
using System.Collections.Generic;

namespace RoomScheduler.Web.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomService roomService;
        private readonly IMapper mapper;

        public RoomController(IRoomService roomService, IMapper mapper)
        {
            this.roomService = roomService;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public IActionResult All()
        {
            var rooms = roomService.GetAllRooms();
            var viewModel = mapper.Map<List<RoomAllViewModel>>(rooms);

            return View(viewModel);
        }
    }
}

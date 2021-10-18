using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoomScheduler.Services.Interfaces;
using RoomScheduler.Web.InputModels;
using RoomScheduler.Web.ViewModels;
using System;
using System.Collections.Generic;

namespace RoomScheduler.Web.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomService roomService;
        private readonly ITimeSlotService timeSlotService;
        private readonly IMapper mapper;

        public RoomController(IRoomService roomService, ITimeSlotService timeSlotService, IMapper mapper)
        {
            this.roomService = roomService;
            this.timeSlotService = timeSlotService;
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

        [HttpGet]
        [Authorize]
        public IActionResult Current(string roomGuid)
        {
            var room = roomService.GetRoomByGuid(roomGuid);
            var viewModel = mapper.Map<RoomCurrentViewModel>(room);

            return View(viewModel);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Filter(FormFilterInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            TimeSpan duration = TimeSpan.Parse(inputModel.Hours + inputModel.Minutes);
            var rooms = roomService.GetFilteredRooms(inputModel.Date, inputModel.Participants, duration);

            var viewModel = new FilterViewModel()
            {
                Date = inputModel.Date,
                Participants = inputModel.Participants,
                Duration = duration,
                Rooms = mapper.Map<List<RoomFilterViewModel>>(rooms)
            };

             return View(viewModel);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Available(string roomGuid, TimeSpan duration, DateTime date)
        {
            var room = roomService.GetRoomByGuid(roomGuid);
            var availableTimes = timeSlotService.GetAvailableTimeSlotsByRoom(date, duration, room.Id);

            var viewModel = new AvailableRoomViewModel()
            {
                Id = room.Id,
                Guid = room.Guid,
                Name = room.Name,
                Capacity = room.Capacity,
                AvailableSchedule = mapper.Map<List<AvailableTimeViewModel>>(availableTimes)
            };

            return View(viewModel);
        }
    }
}

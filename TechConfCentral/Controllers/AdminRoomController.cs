using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechConfCentral.BLL;
using TechConfCentral.Models;

namespace TechConfCentral.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminRoomController : Controller
    {
        private readonly RoomService _roomService;

        public AdminRoomController(RoomService roomService)
        {
            _roomService = roomService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Room> rooms = await _roomService.GetRoomsAsync();
            return View(rooms);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Room room)
        {
            if (!ModelState.IsValid) return View(room);

            try
            {
                await _roomService.AddRoomAsync(room);
                return RedirectToAction("Index");
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(room);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Room? room = await _roomService.GetRoomByIdAsync(id);

            if (room == null) return NotFound();

            return View(room);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Room updatedRoom)
        {
            if (!ModelState.IsValid) return View(updatedRoom);

            try
            {
                await _roomService.UpdateRoomAsync(updatedRoom);
                return RedirectToAction("Index");
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(updatedRoom);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _roomService.DeleteRoomAsync(id);
            return RedirectToAction("Index");
        }
    }
}

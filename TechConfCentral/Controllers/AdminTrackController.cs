using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechConfCentral.BLL;
using TechConfCentral.Models;

namespace TechConfCentral.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminTrackController : Controller
    {
        private readonly TrackService _trackService;
        public AdminTrackController(TrackService trackService)
        {
            _trackService = trackService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var tracks = await _trackService.GetTracksAsync();
            return View(tracks);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Track track)
        {
            if (!ModelState.IsValid)
            {
                return View(track);
            }
            try
            {
                await _trackService.AddTrackAsync(track);
                return RedirectToAction("Index");
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(track);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var track = await _trackService.GetTrackByIdAsync(id);

            if (track == null) return NotFound();

            return View(track);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Track updatedTrack)
        {
            if (!ModelState.IsValid) return View(updatedTrack);

            try
            {
                await _trackService.UpdateTrackAsync(updatedTrack);
                return RedirectToAction("Index");
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(updatedTrack);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _trackService.DeleteTrackAsync(id);
            return RedirectToAction("Index");
        }
    }
}

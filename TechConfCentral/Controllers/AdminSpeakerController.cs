using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechConfCentral.BLL;
using TechConfCentral.Models;

namespace TechConfCentral.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminSpeakerController : Controller
    {
        private readonly SpeakerService _speakerService;
        public AdminSpeakerController(SpeakerService speakerService)
        {
            _speakerService = speakerService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Speaker> speakers = await _speakerService.GetSpeakersAsync();
            return View(speakers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Speaker speaker)
        {
            if (!ModelState.IsValid) return View(speaker);

            await _speakerService.AddSpeakerAsync(speaker);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Speaker? speaker = await _speakerService.GetSpeakerByIdAsync(id);

            if (speaker == null) return NotFound();

            return View(speaker);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Speaker updatedSpeaker)
        {
            if (!ModelState.IsValid) return View(updatedSpeaker);

            await _speakerService.UpdateSpeakerAsync(updatedSpeaker);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            Speaker? speaker = await _speakerService.GetSpeakerWithTalksAsync(id);

            if (speaker == null) return NotFound();

            return View(speaker);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _speakerService.DeleteSpeakerAsync(id);
            return RedirectToAction("Index");
        }
    }
}

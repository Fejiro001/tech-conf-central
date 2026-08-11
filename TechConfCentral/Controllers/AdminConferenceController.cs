using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechConfCentral.BLL;
using TechConfCentral.Models;

namespace TechConfCentral.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminConferenceController : Controller
    {
        private readonly ConferenceService _conferenceService;
        public AdminConferenceController(ConferenceService conferenceService)
        {
            _conferenceService = conferenceService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var conferences = await _conferenceService.GetConferencesAsync();
            return View(conferences);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Conference conference)
        {
            if (!ModelState.IsValid)
            {
                return View(conference);
            }
            try
            {
                await _conferenceService.AddConferenceAsync(conference);
                return RedirectToAction("Index");
            }
            catch(ArgumentException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(conference);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var conference = await _conferenceService.GetConferenceByIdAsync(id);
            if (conference == null) return NotFound();
            return View(conference);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Conference updatedConference)
        {
            if (!ModelState.IsValid) return View(updatedConference);

            try
            {
                await _conferenceService.UpdateConferenceAsync(updatedConference);
                return RedirectToAction("Index");
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(updatedConference);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _conferenceService.DeleteConferenceAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var conference = await _conferenceService.GetConferenceWithTalksAsync(id);

            if (conference == null)
            {
                return NotFound();
            }

            return View(conference);
        }
    }
}

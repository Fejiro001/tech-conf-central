using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TechConfCentral.BLL;
using TechConfCentral.Models;

namespace TechConfCentral.Controllers
{
    [Authorize]
    public class SavedTalkController : BaseController
    {
        private readonly SavedTalkService _savedTalkService;
        public SavedTalkController(SavedTalkService savedTalkService)
        {
            _savedTalkService = savedTalkService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null) return Challenge(); // Redirects to Login

            var vm = new SavedTalksViewModel
            {
                SavedTalks = await _savedTalkService.GetSavedTalksForUserAsync(userId)
            };
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveTalk(int talkId)
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return Challenge(); // Redirects to Login

            try
            {
                await _savedTalkService.SaveTalkAsync(userId, talkId);
            }
            catch (InvalidOperationException ex)
            {
                TempData["WarningMessage"] = ex.Message;
            }
            return RedirectToPreviousPage();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveTalk(int talkId)
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return Challenge(); // Redirects to Login

            await _savedTalkService.RemoveSavedTalkAsync(userId, talkId);
            return RedirectToPreviousPage();
        }
    }
}

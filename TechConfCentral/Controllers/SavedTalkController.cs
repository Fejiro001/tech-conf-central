using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TechConfCentral.BLL;
using TechConfCentral.Models;

namespace TechConfCentral.Controllers
{
    [Authorize]
    public class SavedTalkController : Controller
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

            if (userId == null) return Unauthorized();

            var vm = new SavedTalksViewModel
            {
                SavedTalks = await _savedTalkService.GetSavedTalksForUserAsync(userId)
            };
            return View(vm);
        }
    }
}

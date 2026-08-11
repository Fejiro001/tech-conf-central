using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TechConfCentral.BLL;
using TechConfCentral.Models;

namespace TechConfCentral.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ConferenceService _conferenceService;

        public HomeController(ILogger<HomeController> logger, ConferenceService conferenceService)
        {
            _logger = logger;
            _conferenceService = conferenceService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var vm = new HomeViewModel
            {
                Conferences = await _conferenceService.GetConferencesAsync()
            };
            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

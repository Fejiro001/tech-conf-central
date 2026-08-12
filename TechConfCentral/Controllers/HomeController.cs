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
        private readonly TalkService _talkService;
        private readonly SpeakerService _speakerService;
        private readonly TrackService _trackService;

        public HomeController(
            ILogger<HomeController> logger,
            ConferenceService conferenceService,
            TalkService talkService,
            SpeakerService speakerService,
            TrackService trackService)
        {
            _logger = logger;
            _conferenceService = conferenceService;
            _talkService = talkService;
            _speakerService = speakerService;
            _trackService = trackService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Conference> conferences = await _conferenceService.GetConferencesAsync();
            List<Track> tracks = await _trackService.GetTracksAsync();
            List<Speaker> speakers = await _speakerService.GetSpeakersAsync();
            List<Talk> talks = await _talkService.GetTalksAsync();

            var vm = new HomeViewModel
            {
                Conferences = conferences,
                ConferenceCount = conferences.Count,
                TrackCount = tracks.Count,
                SpeakerCount = speakers.Count,
                TalkCount = talks.Count,
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

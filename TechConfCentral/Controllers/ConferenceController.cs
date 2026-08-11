using Microsoft.AspNetCore.Mvc;
using TechConfCentral.BLL;
using TechConfCentral.Models;

namespace TechConfCentral.Controllers
{
    public class ConferenceController : Controller
    {
        private readonly ConferenceService _conferenceService;
        private readonly SpeakerService _speakerService;
        private readonly TalkService _talkService;
        private readonly TrackService _trackService;

        public ConferenceController(ConferenceService conferenceService, TalkService talkService, TrackService trackService)
        {
            _conferenceService = conferenceService;
            _talkService = talkService;
            _trackService = trackService;
        }
        // View a single conference details
        public async Task<IActionResult> Index(int conferenceId)
        {
            var vm = new ConferenceViewModel
            {
                Conference = await _conferenceService.GetConferenceByIdAsync(conferenceId),
                FeaturedKeynote = await _talkService.GetKeynoteTalkAsync(conferenceId),
                Tracks = await _trackService.GetTracksByConferenceAsync(conferenceId),
                FeaturedSpeakers = await _speakerService.GetFeaturedSpeakersAsync(conferenceId),
                FeaturedTalks = await _talkService.GetFeaturedTalksAsync(conferenceId)
            };
            return View(vm);
        }
    }
}

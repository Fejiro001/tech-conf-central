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
        private readonly RoomService _roomService;

        public ConferenceController(ConferenceService conferenceService, SpeakerService speakerService, TalkService talkService, TrackService trackService, RoomService roomService)
        {
            _conferenceService = conferenceService;
            _speakerService = speakerService;
            _talkService = talkService;
            _trackService = trackService;
            _roomService = roomService;
        }
        // View a single conference details
        public async Task<IActionResult> Index(int conferenceId)
        {
            Conference? currentConf = await _conferenceService.GetConferenceByIdAsync(conferenceId);

            if (currentConf == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var vm = new ConferenceViewModel
            {
                Conference = currentConf,
                FeaturedKeynote = await _talkService.GetKeynoteTalkAsync(conferenceId),
                Tracks = await _trackService.GetTracksByConferenceAsync(conferenceId),
                FeaturedSpeakers = await _speakerService.GetFeaturedSpeakersAsync(conferenceId),
                FeaturedTalks = await _talkService.GetFeaturedTalksAsync(conferenceId)
            };
            return View(vm);
        }
        public async Task<IActionResult> Schedule(int conferenceId, int? day, int? trackId, int? roomId)
        {
            var vm = new ScheduleViewModel
            {
                Conference = await _conferenceService.GetConferenceByIdAsync(conferenceId),
                Talks = await _talkService.GetScheduleAsync(conferenceId, day, trackId, roomId),
                Tracks = await _trackService.GetTracksByConferenceAsync(conferenceId),
                Rooms = await _roomService.GetRoomsByConferenceAsync(conferenceId),
                SelectedTrackId = trackId,
                SelectedRoomId = roomId,
                SelectedDay = day
            };
            return View(vm);
        }

        public async Task<IActionResult> Speakers(int conferenceId)
        {
            var vm = new SpeakersViewModel
            {
                Speakers = await _speakerService.GetSpeakersByConferenceAsync(conferenceId)
            };
            return View(vm);
        }
    }
}

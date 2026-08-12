using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechConfCentral.BLL;
using TechConfCentral.Models;

namespace TechConfCentral.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminTalkController : Controller
    {
        private readonly TalkService _talkService;
        private readonly ConferenceService _conferenceService;
        private readonly SpeakerService _speakerService;
        private readonly TrackService _trackService;
        private readonly RoomService _roomService;
        public AdminTalkController(
            TalkService talkService,
            ConferenceService conferenceService,
            SpeakerService speakerService,
            TrackService trackService,
            RoomService roomService)
        {
            _talkService = talkService;
            _conferenceService = conferenceService;
            _speakerService = speakerService;
            _trackService = trackService;
            _roomService = roomService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Talk> talks = await _talkService.GetTalksAsync();
            return View(talks);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var vm = new TalkFormViewModel();
            await PopulateDropdowns(vm);

            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TalkFormViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                await PopulateDropdowns(vm);
                return View(vm);
            }

            try
            {
                await _talkService.AddTalkAsync(vm.Talk);
                return RedirectToAction("Index");
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            await PopulateDropdowns(vm);
            return View(vm);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Talk? talk = await _talkService.GetTalkByIdAsync(id);
            if (talk == null) return NotFound();

            var vm = new TalkFormViewModel
            {
                Talk = talk
            };

            await PopulateDropdowns(vm);
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TalkFormViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                await PopulateDropdowns(vm);
                return View(vm);
            }

            try
            {
                await _talkService.UpdateTalkAsync(vm.Talk);
                return RedirectToAction("Index");
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            await PopulateDropdowns(vm);
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            Talk? talk = await _talkService.GetTalkByIdAsync(id);

            if (talk == null) return NotFound();

            return View(talk);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _talkService.DeleteTalkAsync(id);
            return RedirectToAction("Index");
        }

        private async Task PopulateDropdowns(TalkFormViewModel vm)
        {
            vm.Conferences = await _conferenceService.GetConferencesAsync();
            vm.Tracks = await _trackService.GetTracksAsync();
            vm.Rooms = await _roomService.GetRoomsAsync();
            vm.Speakers = await _speakerService.GetSpeakersAsync();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using TechConfCentral.BLL;
using TechConfCentral.Models;

namespace TechConfCentral.ViewComponents
{
    public class SpeakerDetailsViewComponent : ViewComponent
    {
        private readonly SpeakerService _speakerService;
        public SpeakerDetailsViewComponent(SpeakerService speakerService)
        {
            _speakerService = speakerService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int speakerId)
        {
            var vm = new SpeakerDetailsViewModel
            {
                Speaker = await _speakerService.GetSpeakerWithTalksAsync(speakerId)
            };

            return View(vm);
        }
    }
}

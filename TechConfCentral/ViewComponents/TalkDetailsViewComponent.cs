using Microsoft.AspNetCore.Mvc;
using TechConfCentral.BLL;
using TechConfCentral.Models;

namespace TechConfCentral.ViewComponents
{
    public class TalkDetailsViewComponent : ViewComponent
    {
        private readonly TalkService _talkService;
        public TalkDetailsViewComponent(TalkService talkService)
        {
            _talkService = talkService;
        }
        public async Task<IViewComponentResult> InvokeAsync(int talkId)
        {
            var vm = new TalkDetailsViewModel
            {
                Talk = await _talkService.GetTalkByIdAsync(talkId)
            };
            return View(vm);
        }
    }
}

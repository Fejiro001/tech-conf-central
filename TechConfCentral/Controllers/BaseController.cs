using Microsoft.AspNetCore.Mvc;

namespace TechConfCentral.Controllers
{
    public class BaseController : Controller
    {
        protected IActionResult RedirectToPreviousPage(string fallbackAction = "Schedule", string fallbackController = "Conference")
        {
            string referer = Request.Headers.Referer.ToString();

            if (!string.IsNullOrEmpty(referer))
            {
                Uri uri = new Uri(referer);
                string relativePath = uri.PathAndQuery;

                if (Url.IsLocalUrl(relativePath))
                {
                    return Redirect(relativePath);
                }
            }
            return RedirectToAction(fallbackAction, fallbackController);
        }
    }
}

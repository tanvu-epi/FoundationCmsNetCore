using EPiServer.Web.Mvc;
using Foundation.Features.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Foundation.Features.Pages.LandingPage
{
    public class LandingPageController : PageController<LandingPage>
    {
        public IActionResult Index(LandingPage currentPage)
        {
            var model = ContentViewModel.Create(currentPage);
            return View(model);
        }
    }
}
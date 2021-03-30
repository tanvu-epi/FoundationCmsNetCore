using EPiServer.Web.Mvc;
using Foundation.Features.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Foundation.Features.Pages.ThreeColumnLandingPage
{
    public class ThreeColumnLandingPageController : PageController<ThreeColumnLandingPage>
    {
        public IActionResult Index(ThreeColumnLandingPage currentPage)
        {
            var model = ContentViewModel.Create(currentPage);
            return View(model);
        }
    }
}
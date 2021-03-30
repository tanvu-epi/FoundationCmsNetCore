using EPiServer.Web.Mvc;
using Foundation.Features.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Foundation.Features.Pages.TwoColumnLandingPage
{
    public class TwoColumnLandingPageController : PageController<TwoColumnLandingPage>
    {
        public IActionResult Index(TwoColumnLandingPage currentPage)
        {
            var model = ContentViewModel.Create(currentPage);
            return View(model);
        }
    }
}
using EPiServer.Web.Mvc;
using Foundation.Features.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Foundation.Features.Home
{
    public class HomeController : PageController<HomePage>
    {
        public IActionResult Index(HomePage currentContent)
        {
            return View(ContentViewModel.Create<HomePage>(currentContent));
        }
    }
}
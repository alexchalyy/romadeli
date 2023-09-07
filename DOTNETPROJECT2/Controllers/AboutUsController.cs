using Microsoft.AspNetCore.Mvc;

namespace TorysDeli.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult AboutUs()
        {
            return View("AboutUs");
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace TorysDeli.Controllers
{
    public class ContactUsController : Controller
    {
        public IActionResult ContactUs()
        {
            return View("ContactUs");
        }
    }
}

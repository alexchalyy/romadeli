using Microsoft.AspNetCore.Mvc;

namespace TorysDeli.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Menu()
        {
            return View("Menu");
        }
    }
}

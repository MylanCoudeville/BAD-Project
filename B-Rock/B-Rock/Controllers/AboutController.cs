using Microsoft.AspNetCore.Mvc;

namespace B_Rock.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

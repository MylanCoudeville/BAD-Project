using Microsoft.AspNetCore.Mvc;

namespace B_Rock.Controllers
{
    public class CalendarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

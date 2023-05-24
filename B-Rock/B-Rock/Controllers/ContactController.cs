using Microsoft.AspNetCore.Mvc;

namespace B_Rock.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using B_Rock.Models.Calendar;
using Microsoft.AspNetCore.Mvc;

namespace B_Rock.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddToCart()
        {
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddToCart(int concertId, int Quantity)
        {
            return View();
        }

    }
}

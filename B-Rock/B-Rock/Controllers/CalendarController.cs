using B_Rock.Data;
using B_Rock.Services;
using Microsoft.AspNetCore.Mvc;

namespace B_Rock.Controllers
{
    public class CalendarController : Controller
    {
        private readonly IConcertService _concertService;
        public CalendarController(IConcertService concertService)
        {
            _concertService = concertService;
        }

        public IActionResult Index()
        {
            IEnumerable<Concert> concerts = _concertService.GetAll();
            return View(concerts);
        }
        public IActionResult EditConcert(int Id)
        {
            Concert c = _concertService.GetById(Id);
            //TODO: doe hier verder ben nu te moe...
        }
    }
}

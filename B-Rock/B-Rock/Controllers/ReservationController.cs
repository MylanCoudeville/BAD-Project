using B_Rock.Data;
using B_Rock.Models.Calendar;
using B_Rock.Models.Reservation;
using B_Rock.Services;
using Microsoft.AspNetCore.Mvc;

namespace B_Rock.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ConcertService _concertService;
        public ReservationController(ConcertService concertService)
        {
            _concertService = concertService;
        }
        public IActionResult Index(int concertId, int Quantity)
        {
            Concert c = _concertService.GetById(concertId);
            CheckoutReservationViewModel viewModel= new CheckoutReservationViewModel() {
                ConcertId = c.Id,
                Title = c.Title
            };
            return View();
        }
    }
}

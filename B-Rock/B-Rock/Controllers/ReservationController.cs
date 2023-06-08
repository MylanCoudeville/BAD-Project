using B_Rock.Data;
using B_Rock.Models.Calendar;
using B_Rock.Models.Reservation;
using B_Rock.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace B_Rock.Controllers
{
    public class ReservationController : Controller
    {
        private readonly UserManager<B_RockUser> _userManager;
        private readonly IConcertService _concertService;
        public ReservationController(IConcertService concertService, UserManager<B_RockUser> userManager)
        {
            _concertService = concertService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index(int concertId, int Quantity)
        {
            Concert c = _concertService.GetById(concertId);
            CheckoutReservationViewModel viewModel = new CheckoutReservationViewModel() {
                ConcertId = c.Id,
                Title = c.Title,
                Location = c.Location,
                DateAndTime = c.DateAndTime,
                Quantity = Quantity,
                TotalPrice = (Quantity * c.Price)
            };
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                B_RockUser user = await _userManager.GetUserAsync(HttpContext.User);
                viewModel.UserId = user.Id;
                viewModel.FirstName = user.FirstName;
                viewModel.LastName = user.LastName;
            }
            return View(viewModel);
        }
    }
}

using B_Rock.Data;
using B_Rock.Models.Reservation;
using B_Rock.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace B_Rock.Controllers
{
    public class ReservationController : Controller
    {
        private readonly UserManager<B_RockUser> _userManager;
        private readonly IConcertService _concertService;
        private readonly ITicketService _ticketService;
        public ReservationController(IConcertService concertService, UserManager<B_RockUser> userManager, ITicketService ticketService)
        {
            _concertService = concertService;
            _userManager = userManager;
            _ticketService = ticketService;
        }
        public IActionResult AddOrder()
        {
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Index(int concertId, int Quantity)
        {
            if (concertId == null || Quantity == null) return RedirectToAction("Index", "Calendar");
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
                viewModel.Email = user.Email;
            }
            return View(viewModel);
        }
        [Authorize(Policy = "Customer")]
        public async Task<IActionResult> Overview()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                B_RockUser user = await _userManager.GetUserAsync(HttpContext.User);
                IEnumerable<Ticket> userTickets = _ticketService.GetAllFromUser(user.Id);
                ListOverviewViewModel viewModel = new ListOverviewViewModel();
                foreach (Ticket ticket in userTickets)
                {
                    Concert c = _concertService.GetById(ticket.ConcertId);
                    viewModel.viewModels.Add(new OverviewViewModel()
                    {
                        Id = ticket.Id,
                        ConcertName = c.Title,
                        ConcertDateAndTime = c.DateAndTime,
                        ConcertLocation = c.Location,
                        Quantity = ticket.Quantity,
                        TotalPrice = ticket.TotalPrice
                    });
                }
                return View(viewModel);
            }
            return View();
        }
        public IActionResult Successful() 
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrder(CheckoutReservationViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Ticket newTicket = new Ticket()
                {
                    ConcertId = viewModel.ConcertId,
                    Quantity = viewModel.Quantity,
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    TotalPrice = viewModel.TotalPrice,
                    Email = viewModel.Email,
                    Street = viewModel.Street,
                    Number = viewModel.Number,
                    City = viewModel.City,
                    ZIPCode = viewModel.ZIPCode,
                    Country = viewModel.Country
                };
                if (HttpContext.User.Identity.IsAuthenticated)
                {
                    newTicket.UserId = viewModel.UserId;
                }
                _ticketService.AddTicket(newTicket);
                return RedirectToAction("Successful");
            }
            return View(viewModel);
        }
    }
}

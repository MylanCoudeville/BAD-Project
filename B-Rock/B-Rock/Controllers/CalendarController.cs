using B_Rock.Data;
using B_Rock.Models.Calendar;
using B_Rock.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace B_Rock.Controllers
{
    [Authorize(Policy = "AdminOnly")]
    public class CalendarController : Controller
    {
        private readonly IConcertService _concertService;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostEnvironment;
        public CalendarController(IConcertService concertService, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostEnvironment)
        {
            _concertService = concertService;
            _hostEnvironment = hostEnvironment;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            IEnumerable<Concert> concerts = _concertService.GetAllInFuture();
            return View(concerts);
        }
        public IActionResult AddConcert()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult DetailConcert(int id)
        {
            Concert concert = _concertService.GetById(id);
            DetailConcertViewModel viewModel = new DetailConcertViewModel()
            {
                Id = concert.Id,
                Title = concert.Title,
                PerformedBy = concert.PerformedBy,
                Location = concert.Location,
                City = concert.City,
                Country = concert.Country,
                DateAndTime = concert.DateAndTime,
                UniqueURL = concert.UniqueURL,
                ExternLink = concert.ExternLink,
                Price = concert.Price,
                Quantity = 0
            };
            return View(viewModel);
        }
        public IActionResult EditConcert(int id)
        {
            Concert c = _concertService.GetById(id);
            EditConcertViewModel viewModel = new EditConcertViewModel()
            {
                Id = c.Id,
                Title = c.Title,
                PerformedBy = c.PerformedBy,
                Location = c.Location,
                City = c.City,
                Country = c.Country,
                DateAndTime = c.DateAndTime,
                UniqueURL = c.UniqueURL,
                ExternLink = c.ExternLink,
                Price = c.Price
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(int id)
        {
            Concert toDeleteConcert = _concertService.GetById(id);
            toDeleteConcert.IsDeleted = true;
            _concertService.RemoveConcert(toDeleteConcert);
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddConcert(AddConcertViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = GetUniqueFileName(viewModel.Image.FileName);
                string uploads = Path.Combine(_hostEnvironment.WebRootPath, "img/Concerts");
                string filePath = Path.Combine(uploads, uniqueFileName);
                viewModel.Image.CopyTo(new FileStream(filePath, FileMode.Create));

                Concert newConcert = new Concert()
                {
                    Title = viewModel.Title,
                    PerformedBy = viewModel.PerformedBy,
                    Location = viewModel.Location,
                    City = viewModel.City,
                    Country = viewModel.Country,
                    DateAndTime = viewModel.DateAndTime,
                    ExternLink = viewModel.ExternLink,
                    UniqueURL = uniqueFileName,
                    Price = viewModel.Price
                };
                _concertService.AddConcert(newConcert);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditConcert(EditConcertViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Concert editConcert = new Concert()
                {
                    Id = viewModel.Id,
                    Title = viewModel.Title,
                    PerformedBy = viewModel.PerformedBy,
                    Location = viewModel.Location,
                    City = viewModel.City,
                    Country = viewModel.Country,
                    DateAndTime = viewModel.DateAndTime,
                    UniqueURL = viewModel.UniqueURL,
                    ExternLink = viewModel.ExternLink,
                    Price = viewModel.Price
                };
                if (viewModel.Image != null)
                {
                    string uniqueFileName = GetUniqueFileName(viewModel.Image.FileName);
                    string uploads = Path.Combine(_hostEnvironment.WebRootPath, "img/Concert");
                    string filePath = Path.Combine(uploads, uniqueFileName);
                    viewModel.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                    editConcert.UniqueURL = uniqueFileName;
                }
                _concertService.UpdateConcert(editConcert);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }
        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }
        //https://stackoverflow.com/questions/35379309/how-to-upload-files-in-asp-net-core/35385472#35385472
    }
}

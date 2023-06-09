using B_Rock.Data;
using B_Rock.Models.About;
using B_Rock.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace B_Rock.Controllers
{
    [Authorize(Policy = "AdminOnly")]
    public class AboutController : Controller
    {
        private readonly IArtistService _artistService;
        private readonly IInstrumentService _instrumentService;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostEnvironment;
        public AboutController(IArtistService artistService, IInstrumentService instrumentService, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostEnvironment)
        {
            _artistService = artistService;
            _instrumentService = instrumentService;
            _hostEnvironment = hostEnvironment;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            GetAllDevidedInGroup ArtistsInGroup = new GetAllDevidedInGroup();
            for (int i = 1; i <= _instrumentService.GetAmountInstruments(); i++)
            {
                ArtistsInGroup.artistsInGroups.Add(_artistService.GetByInstrument(i).ToList());
            }
            return View(ArtistsInGroup);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(int id)
        {
            Artist deleteArtist = _artistService.GetById(id);
            deleteArtist.IsDeleted = true;
            _artistService.DeleteArtist(deleteArtist);
            return RedirectToAction("Index");
        }
        public IActionResult AddArtist()
        {
            AddArtistViewModel viewModel = new AddArtistViewModel() { Instruments = _instrumentService.GetAll() };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddArtist(AddArtistViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Artist newArtist = new Artist()
                {
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    Role = viewModel.Role,
                    InstrumentId = viewModel.InstrumentId,
                    Instrument = _instrumentService.GetById(viewModel.InstrumentId)
                };
                if (viewModel.Image != null)
                {
                    string uniqueFileName = GetUniqueFileName(viewModel.Image.FileName);
                    string uploads = Path.Combine(_hostEnvironment.WebRootPath, "img/Artiesten");
                    string filePath = Path.Combine(uploads, uniqueFileName);
                    viewModel.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                    newArtist.UniqueURL = uniqueFileName;
                }
                _artistService.AddArtist(newArtist);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }
        public IActionResult EditArtist(int id)
        {
            Artist a = _artistService.GetById(id);
            EditArtistViewModel viewModel = new EditArtistViewModel()
            {
                Instruments = _instrumentService.GetAll(),
                Id = a.Id,
                FirstName = a.FirstName,
                LastName = a.LastName,
                Role = a.Role,
                InstrumentId = a.InstrumentId,
                UniqueURL = a.UniqueURL
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditArtist(EditArtistViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Artist editedArtist = new Artist()
                {
                    Id = viewModel.Id,
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    Role = viewModel.Role,
                    InstrumentId = viewModel.InstrumentId,
                    Instrument = _instrumentService.GetById(viewModel.InstrumentId),
                    UniqueURL = viewModel.UniqueURL
                };
                if (viewModel.Image != null)
                {
                    string uniqueFileName = GetUniqueFileName(viewModel.Image.FileName);
                    string uploads = Path.Combine(_hostEnvironment.WebRootPath, "img/Artiesten");
                    string filePath = Path.Combine(uploads, uniqueFileName);
                    viewModel.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                    editedArtist.UniqueURL = uniqueFileName;
                }
                _artistService.UpdateArtist(editedArtist);
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

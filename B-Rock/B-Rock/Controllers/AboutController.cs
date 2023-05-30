using B_Rock.Data;
using B_Rock.Models.About;
using B_Rock.Services;
using Microsoft.AspNetCore.Mvc;

namespace B_Rock.Controllers
{
    public class AboutController : Controller
    {
        private readonly IArtistService _artistService;
        private readonly IInstrumentService _instrumentService;
        public AboutController(IArtistService artistService, IInstrumentService instrumentService)
        {
            _artistService = artistService;
            _instrumentService = instrumentService;
        }

        public IActionResult Index()
        {
            GetAllDevidedInGroup ArtistsInGroup = new GetAllDevidedInGroup();
            for (int i = 1; i <= _instrumentService.GetAmountInstruments(); i++)
            {
                ArtistsInGroup.artistsInGroups.Add(_artistService.GetByInstrument(i).ToList());
            }
            return View(ArtistsInGroup);
        }
        
        public IActionResult AddArtist() {
            AddArtistViewModel viewModel = new AddArtistViewModel() { Instruments = _instrumentService.GetAll() };
            return View(viewModel); 
        }
        //TODO: Post van nieuw artist
        public IActionResult EditArtist(int id) {
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
    }
}

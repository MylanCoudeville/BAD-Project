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
    }
}

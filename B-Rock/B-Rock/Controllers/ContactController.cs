using B_Rock.Data;
using B_Rock.Services;
using Microsoft.AspNetCore.Mvc;

namespace B_Rock.Controllers
{
    public class ContactController : Controller
    {
        private readonly IStaffService _staffService;
        public ContactController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        public IActionResult Index()
        {
            IEnumerable<Staff> crew = _staffService.GetAll();
            return View(crew);
        }
    }
}

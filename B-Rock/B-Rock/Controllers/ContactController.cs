using B_Rock.Data;
using B_Rock.Models.Contact;
using B_Rock.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace B_Rock.Controllers
{
    public class ContactController : Controller
    {
        private readonly IStaffService _staffService;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostEnvironment;
        public ContactController(IStaffService staffService, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostEnvironment)
        {
            _staffService = staffService;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            IEnumerable<Staff> crew = _staffService.GetAll();
            return View(crew);
        }
        public IActionResult AddStaff()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddStaff(AddStaffViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Staff newStaff = new Staff()
                {
                    FirstName= viewModel.FirstName,
                    LastName= viewModel.LastName,
                    Role = viewModel.Role,
                    PhoneNumber = viewModel.PhoneNumber,
                    Email= viewModel.Email
                };
                if (viewModel.Image!= null)
                {
                    string uniqueFileName = GetUniqueFileName(viewModel.Image.FileName);
                    string uploads = Path.Combine(_hostEnvironment.WebRootPath, "img/Staff");
                    string filePath = Path.Combine(uploads, uniqueFileName);
                    viewModel.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                    newStaff.UniqueURL = uniqueFileName;
                }
                _staffService.Add(newStaff);
                return RedirectToAction("Index");
            }
            return View();
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

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
        public IActionResult EditStaff(int Id)
        {
            Staff f = _staffService.GetById(Id);
            EditStaffViewModel viewModel = new EditStaffViewModel()
            {
                Id = f.Id,
                FirstName = f.FirstName,
                LastName = f.LastName,
                PhoneNumber = f.PhoneNumber,
                Email = f.Email,
                UniqueURL = f.UniqueURL,
                Role = f.Role
            };
            return View(viewModel);
        }
        public IActionResult DeleteStaff(int Id)
        {
            Staff deleteStaff = _staffService.GetById(Id);
            DeleteStaffViewModel viewModel = new DeleteStaffViewModel()
            {
                Id = deleteStaff.Id,
                FirstName = deleteStaff.FirstName,
                LastName = deleteStaff.LastName,
                Role = deleteStaff.Role,
                UniqueURL = deleteStaff.UniqueURL
            };
            return View(viewModel);
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditStaff(EditStaffViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Staff editStaf = new Staff()
                {
                    Id = viewModel.Id,
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    Role = viewModel.Role,
                    PhoneNumber = viewModel.PhoneNumber,
                    Email = viewModel.Email,
                    UniqueURL = viewModel.UniqueURL
                };
                if (viewModel.Image!= null)
                {
                    string uniqueFileName = GetUniqueFileName(viewModel.Image.FileName);
                    string uploads = Path.Combine(_hostEnvironment.WebRootPath, "img/Staff");
                    string filePath = Path.Combine(uploads, uniqueFileName);
                    viewModel.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                    editStaf.UniqueURL = uniqueFileName;
                }
                _staffService.Update(editStaf);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteStaff(DeleteStaffViewModel viewModel)
        {
                Staff toDelete = _staffService.GetById(viewModel.Id);
                _staffService.Delete(toDelete);
                return RedirectToAction("Index");
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

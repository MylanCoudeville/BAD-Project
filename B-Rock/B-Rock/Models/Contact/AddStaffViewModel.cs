using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace B_Rock.Models.Contact
{
    public class AddStaffViewModel
    {
        [Display(Name = "First name")]
        [Required(ErrorMessage = "Please, fill in the first name of the crew member.")]
        public string FirstName { get; set; }
        [Display(Name = "Last name")]
        [Required(ErrorMessage = "Please, fill in the last name of the crew member.")]
        public string LastName { get; set; }
        public string Role { get; set; }
        [Required(ErrorMessage = "Please, fill in the email of the crew member")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "Phone number")]
        public string? PhoneNumber { get; set; }
        public IFormFile Image { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace B_Rock.Models.Contact
{
    public class EditStaffViewModel
    {
        public int Id { get; set; }
        [Display(Name = "First name")]
        [Required(ErrorMessage = "Please, fill in the first name of the crew member.")]
        public string FirstName { get; set; }
        [Display(Name = "Last name")]
        [Required(ErrorMessage = "Please, fill in the last name of the crew member.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please, fill in the role of the crew member.")]
        public string Role { get; set; }
        [Required(ErrorMessage = "Please, fill in the email of the crew member")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "Phone number")]
        public string? PhoneNumber { get; set; }
        public IFormFile? Image { get; set; }
        public string UniqueURL { get; set; }
    }
}

using B_Rock.Data;
using System.ComponentModel.DataAnnotations;

namespace B_Rock.Models.Contact
{
    public class IndexViewModel
    {
        public IEnumerable<Staff> StaffMembers { get; set; }
        [Required(ErrorMessage = "Fill in your first name.")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Fill in your last name.")]
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Fill in your email address.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Fill in a valid email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Fill in your message.")]
        public string Message { get; set; }
        public string? UserId { get; set; }
    }
}

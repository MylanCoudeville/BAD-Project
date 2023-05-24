using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace B_Rock.Data
{
    public class Staff
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "First name")]
        [Required(ErrorMessage = "Please, fill in the first name of the crew member.")]
        public string FirstName { get; set; }
        [Display(Name = "Last name")]
        [Required(ErrorMessage = "Please, fill in the last name of the crew member.")]
        public string LastName { get; set; }
        public string? Role { get; set; }
        [Required(ErrorMessage = "Please, fill in the email of the crew member")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "Phone number")]
        public string? PhoneNumber { get; set; }
        [NotMapped]
        public IFormFile? Image { get; set; }
        public string? UniqueURL { get; set; }
    }
}

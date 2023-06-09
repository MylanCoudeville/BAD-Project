using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace B_Rock.Data
{
    public class Staff
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Role { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        [NotMapped]
        public IFormFile? Image { get; set; }
        public string? UniqueURL { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}

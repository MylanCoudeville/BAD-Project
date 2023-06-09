using System.ComponentModel.DataAnnotations;

namespace B_Rock.Data
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public string? UserId { get; set; }
        public DateTime Created { get; set; }
        public Boolean IsAnswered { get; set; } = false;
    }
}

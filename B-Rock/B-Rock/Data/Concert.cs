using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace B_Rock.Data
{
    public class Concert
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Fill in the title of the concert.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Fill in the group that is playing at the concert.")]
        public string PerformedBy { get; set; }
        [Required(ErrorMessage = "Fill in the location of the concert.")]
        public string Location { get; set; }
        [Required(ErrorMessage = "Fill in the city of the concert.")]
        public string City { get; set; }
        [Required(ErrorMessage = "Fill in the country of the concert.")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Fill in the date of the concert.")]
        [DataType(DataType.DateTime)]
        public DateTime DateAndTime { get; set; }
        [NotMapped]
        public IFormFile FormFile { get; set; }
        public string UniqueURL { get; set; }
    }
}

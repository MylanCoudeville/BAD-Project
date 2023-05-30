using System.ComponentModel.DataAnnotations;

namespace B_Rock.Models.Calendar
{
    public class EditConcertViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Fill in the title of the concert.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Fill in the group that is playing at the concert.")]
        public string PerformedBy { get; set; }
        [Required(ErrorMessage = "Fill in the location of the concert.")]
        public string Location { get; set; }
        [Required(ErrorMessage = "Fill in the city of the concert.")]
        public String City { get; set; }
        [Required(ErrorMessage = "Fill in the country of the concert.")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Fill in the date of the concert.")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Date and time")]
        public DateTime DateAndTime { get; set; }
        public IFormFile? FormFile { get; set; }
        public string UniqueURL { get; set; }
        public string ExternLink { get; set; }
    }
}

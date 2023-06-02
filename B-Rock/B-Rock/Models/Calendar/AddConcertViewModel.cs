using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace B_Rock.Models.Calendar
{
    public class AddConcertViewModel
    {
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
        [Required(ErrorMessage = "Upload an image of the concert.")]
        public IFormFile Image { get; set; }
        [Required(ErrorMessage = "Fill in the external link to the concert.")]
        [Display(Name = "External link")]
        public string ExternLink { get; set; }
    }
}
